using DevExpress.Data.XtraReports.Native;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using xbd.ControlLib;
using xbd.PressurizationStationPro;
using xbd.s7netplus;
using static PressurizationStationPro.FrmMain;
using Timer = System.Windows.Forms.Timer;

namespace PressurizationStationPro
{
    public partial class FrmMain : Form
    {
        #region 字段和属性
        ///<summary>
        ///系统配置文件的路径
        /// </summary>
        private string sysInfoPath = Application.StartupPath + "\\SysInfo,ini";


        /// <summary>
        /// 系统配置文件的服务对象
        /// </summary>
        private SysInfoService infoService = new SysInfoService();

        /// <summary>
        /// 系统配置对象
        /// </summary>
        private SysInfo sysInfo = new SysInfo();

        /// <summary>
        /// 多线程取消
        /// </summary>
        private CancellationTokenSource cts;

        private PlcDataService dataService = new PlcDataService();

        private S7NetLib siemens = null;

        private Timer updataTimer = new System.Windows.Forms.Timer();

        /// <summary>
        /// 第一次扫描标志位
        /// </summary>
        private bool FirestScan = true;

        //
        private MessageFilter messageFilter = null;

        //记录登录的时间
        private DateTime LoginTime = DateTime.Now;

        //摄像头采集对象
        private CameraHelper camera = null;

        //数据保存
        private HistoryDataService historyService = new HistoryDataService();

        /// <summary>
        /// 记录上次存储的时间
        /// </summary>
        private DateTime lastTime = DateTime.Now;


        #endregion

        public FrmMain()
        {
            InitializeComponent();
            //500ms执行一次
            this.updataTimer.Interval = 500;
            this.updataTimer.Tick += UpdateTimer_Tick;
            this.updataTimer.Start();

            this.Load += FrmMain_Load;
            this.FormClosing += FrmMain_FormClosing;
        }

        private void UpdateTimer_Tick(object sender, EventArgs e)
        {
            //获取当前时间
            this.lbl_Time.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")+" "+new CultureInfo("zh-CN").DateTimeFormat.GetDayName(DateTime.Now.DayOfWeek);
            this.led_PLCState.State = dataService.IsConnected;
            //如果大于0才启用该功能,鼠标键盘无操作
            if(sysInfo.ScreenTime>0)
            {
                Program.TickCount++;

                if(sysInfo.ScreenTime*1000/this.updataTimer.Interval<=Program.TickCount)
                {
                    //锁屏 调用Windows底层的API
                    LockWorkStation();
                    Program.TickCount = 0;

                }
            }
            //启动用户自动注销功能
            if(sysInfo.LogoffTime>0)
            {
                if (Program.CurrentUser != null)
                {
                    TimeSpan timeSpan = DateTime.Now - this.LoginTime;

                    if (timeSpan.TotalSeconds > sysInfo.LogoffTime)
                    {
                        Program.CurrentUser = null;
                        this.btn_UserLogin.Text = "用户登录";
                        this.lbl_User.Text = "未登录";
                    }
                }
            }
        }

        private void FrmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (new FrmMsgWithAck("是否确定退出系统", "退出系统").ShowDialog() == DialogResult.OK)
            {
                //关闭摄像头
                camera?.StopCamera();
                //关定时器
                updataTimer.Stop();

                //令牌翻转
                cts?.Cancel();
            }
            else
            {
                e.Cancel = true;
            }

            
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            //读取数据到sysInfo
            this.sysInfo = infoService.GetSysInfoFromPath(this.sysInfoPath);
            if(this.sysInfo==null)
            {
                new FrmMsgNoAck("系统配置加载失败","系统配置").ShowDialog();
                return;
            }

            //锁屏处理
            if(sysInfo.ScreenTime>0)
            {
                messageFilter = new MessageFilter();
                Application.AddMessageFilter(messageFilter);         
            }

            cts = new CancellationTokenSource();

            Task.Run(new Action(() =>
            {
                PLCCommunication();
            }));

            //采集摄像头
            this.camera = new CameraHelper(sysInfo.CameraIndex, this.vsp_Panel);
        }

        private void PLCCommunication()
        {
            //是否有取消请求//有取消请求线程执行完
            while(!cts.IsCancellationRequested)
            {
                //已连接成功
                if(dataService.IsConnected)
                {
                    var data = dataService.ReadPLCData();
                    if(data.IsSuccess)
                    {
                        //清零错误次数
                        dataService.ErrorTimes = 0;
                        //更新
                        this.UpdataUIData(data.Content);

                        //存储 要保证1s 扫描周期要小于1s
                        int timeSpan = DateTime.Now.Second - lastTime.Second;
                            //59-58         00-59
                        if(timeSpan==1||timeSpan==-59)
                        {
                            historyService.AddHistoryData(new HistoryData()
                            {
                                InsertTime = DateTime.Now,
                                PressureIn = data.Content.PressureIn.ToString("f2"),
                                PressureOut = data.Content.PressureOut.ToString("f2"),
                                TempIn1 = data.Content.TempIn1.ToString("f2"),
                                TempIn2 = data.Content.TempIn2.ToString("f2"),
                                TempOut = data.Content.TempOut.ToString("f2"),
                                PressureTank1 = data.Content.PressureTank1.ToString("f2"),
                                PressureTank2 = data.Content.PressureTank2.ToString("f2"),
                                LevelTank1 = data.Content.LevelTank1.ToString("f2"),
                                LevelTank2 = data.Content.LevelTank2.ToString("f2"),
                                PressureTankOut = data.Content.PressureTankOut.ToString("f2"),
                            });
                        }
                        lastTime = DateTime.Now;
                    }
                    else
                    {
                        //容错次数
                        dataService.ErrorTimes++;
                        if(dataService.ErrorTimes>=dataService.AllowErrorTimes)
                        {
                            dataService.IsConnected = false;
                            dataService.ErrorTimes = 0;
                        }
                    }
                    Thread.Sleep(300);
                }
                //连接
                else
                {
                    //如果是第一次扫描，直接连接
                    //如果不是第一次扫描，先断开再连接

                    if(!dataService.IsFirstScan)
                    {
                        //重连周期
                        Thread.Sleep(3000);
                        //不是第一次扫描，先断开再连接
                        dataService.DisConnect();
                    }
                    else
                    {
                        dataService.IsFirstScan = false;
                    }

                    //连接
                    var result = dataService.Connect(this.sysInfo);

                    dataService.IsConnected = result.IsSuccess;

                }
            }
        }

        


        private void btn_ParamSet_Click(object sender, EventArgs e)
        {
            //加个用户权限判断
            if (Program.CurrentUser != null)
            {
                using (var frm = new FrmParamSet(this.sysInfo, this.infoService, this.sysInfoPath))
                {
                    //如果没点确认则直接返回
                    if (frm.ShowDialog() != DialogResult.OK) return;
                }

                //点了确认，重读文件，断线重连
                // 重新从文件读一遍，保证拿到的是最新配置
                this.sysInfo = infoService.GetSysInfoFromPath(this.sysInfoPath);
            }
            else
            {
                new FrmMsgNoAck("当前用户未登录或权限不足！", "管理用户");
            }

            
            // 通知后台线程：断开，让循环走重连分支
            dataService.DisConnect();
            dataService.IsConnected = false;
        }

        /// <summary>
        /// 通用更新UI界面
        /// </summary>
        /// <param name="plcData"></param>
        private void UpdataUIData(PlcData plcData)
        {
            //在不同线程
            if (this.InvokeRequired)
            {
                //调用UI线程执行
                try
                {
                    this.Invoke(new Action<PlcData>(UpdataUIData), plcData);
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    return;
                }
                
            }
            else
            {
                //第一次扫描
                if(FirestScan)
                {
                    this.toggle_Pump1.Checked = plcData.InPump1State;
                    this.toggle_Pump2.Checked = plcData.InPump2State;
                    FirestScan = false;
                }

                //左侧仪表
                this.lbl_PressureIn.Text = plcData.PressureIn.ToString("f2") + "bar";
                this.lbl_PressureOut.Text = plcData.PressureOut.ToString("f2") + "bar";
                this.meter_PressureIn.Value = plcData.PressureIn;
                this.meter_PressureOut.Value = plcData.PressureOut;

                //底侧仪表
                this.ms_TempIn1.ParamValue = plcData.TempIn1;
                this.ms_TempIn2.ParamValue = plcData.TempIn2;
                this.ms_TempOut.ParamValue = plcData.TempOut;
                this.ms_PressureTank1.ParamValue = plcData.PressureTank1;
                this.ms_PressureTank2.ParamValue = plcData.PressureTank2;
                this.ms_PressureTankOut.ParamValue = plcData.PressureTankOut;

                //系统状态
                this.led_RunState.State = plcData.SysRunState;
                this.led_SysAlarmState.State = plcData.SysAlarmState;

                //系统参数
                this.lbl_PressureTank1.Text = plcData.PressureTank1.ToString("f2");
                this.lbl_LevelTank1.Text = plcData.LevelTank1.ToString("f2");
                this.lbl_PressureTank2.Text = plcData.PressureTank1.ToString("f2");
                this.lbl_LevelTank2.Text = plcData.LevelTank2.ToString("f2");

                //流程图数据
                this.lbl_TempIn1.Text = plcData.TempIn1.ToString("f2");
                this.lbl_TempIn2.Text = plcData.TempIn2.ToString("f2");
                this.lbl_TempOut.Text = plcData.TempOut.ToString("f2");
                this.lbl_PressureTankOut.Text = ms_PressureTankOut.ParamValue.ToString("f2");
                this.lbl_PreTankOut.Text = ms_PressureTankOut.ParamValue.ToString("f2");



                this.pump_In1.IsRun = plcData.InPump1State;
                this.pump_In2.IsRun = plcData.InPump2State;

                this.valve_In.State = plcData.ValveInState;
                this.valve_Out.State = plcData.ValveOutState;

                this.motor_Pump1.PumpState = plcData.CirclePump1State ? PumpState.运行 : PumpState.停止;
                this.motor_Pump2.PumpState = plcData.CirclePump2State ? PumpState.运行 : PumpState.停止;

                //量程
                this.wave_Tank1.Value = Convert.ToInt32((plcData.LevelTank1 / 2.0f) * 100.0f);
                this.wave_Tank2.Value = Convert.ToInt32((plcData.LevelTank2 / 2.0f) * 100.0f);


                this.btn_Pump1.Text = plcData.CirclePump1State ? "停止" : "启动";
                this.btn_Pump2.Text = plcData.CirclePump2State ? "停止" : "启动";

            }

        }

        private void btn_Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_Pump1_Click(object sender, EventArgs e)
        {
             dataService.CirclePump1Control(this.btn_Pump1.Text=="启动");
        }

        private void btn_Pump2_Click(object sender, EventArgs e)
        {
            dataService.CirclePump2Control(this.btn_Pump2.Text=="启动");
        }

        private void toggle_Pump1_CheckedChanged(object sender, EventArgs e)
        {
            //true

            //点后判断当前是否选中
            if(dataService.InPump1Control(this.toggle_Pump1.Checked)==false)
            {
                this.toggle_Pump1.CheckedChanged -= toggle_Pump1_CheckedChanged;
                this.toggle_Pump1.Checked = !this.toggle_Pump1.Checked;
                this.toggle_Pump1.CheckedChanged += toggle_Pump1_CheckedChanged;
            }
        }

        private void toggle_Pump2_CheckedChanged(object sender, EventArgs e)
        {
            //true

            //点后判断当前是否选中
            if (dataService.InPump2Control(this.toggle_Pump2.Checked) == false)
            {
                this.toggle_Pump2.CheckedChanged -= toggle_Pump2_CheckedChanged;
                this.toggle_Pump2.Checked = !this.toggle_Pump2.Checked;
                this.toggle_Pump2.CheckedChanged += toggle_Pump2_CheckedChanged;
            }
        }

        private void btn_SysReset_Click(object sender, EventArgs e)
        {
            dataService.SysReset();
        }

        private void CommonValue_DoubleClick(object sender, EventArgs e)
        {
            if(sender is xbdValve valve)
            {
                FrmValueControl frmValueControl = new FrmValueControl(valve.ValveName, valve.State, this.dataService);
                frmValueControl.ShowDialog();
            }
        }

        #region 系统锁屏

        [DllImport("user32")]
        public static extern bool LockWorkStation();

        #endregion

        private void btn_UserLogin_Click(object sender, EventArgs e)
        {
            if(this.btn_UserLogin.Text== "用户登录")
            {
                DialogResult dialogResult = new FrmLogin().ShowDialog();
                if (DialogResult.OK == dialogResult)
                {
                    this.lbl_User.Text = Program.CurrentUser.LoginName;

                    //记录登录时间
                    LoginTime = DateTime.Now;
                    this.btn_UserLogin.Text = "用户管理";
                }
            }
            else
            {
                //加个用户权限判断
                if(Program.CurrentUser!=null && Program.CurrentUser.RoleName == RoleName.管理员)
                {
                    FrmUserManage frmUserManage = new FrmUserManage();
                    frmUserManage.ShowDialog();
                }
                else
                {
                    new FrmMsgNoAck("当前用户未登录或权限不足！","管理用户");
                }


            }

            
        }
        #region 无边框拖动 

        private Point mPoint;
        private void Panel_MouseDown(object sender, MouseEventArgs e)
        {
            mPoint = new Point(e.X, e.Y);
        }

        private void Panel_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Location = new Point(this.Location.X + e.X - mPoint.X, this.Location.Y + e.Y - mPoint.Y);
            }
        }
        #endregion

        private void btn_History_Click(object sender, EventArgs e)
        {
            new FrmHistory().ShowDialog();
        }

        private void btn_Report_Click(object sender, EventArgs e)
        {
            new FrmReport().ShowDialog();
        }

        private void lbl_User_Click(object sender, EventArgs e)
        {
            if (new FrmMsgWithAck("是否要确认注销登录?", "注销用户").ShowDialog()==DialogResult.OK)
            {
                Program.CurrentUser = null;
                this.btn_UserLogin.Text = "用户登录";
                this.lbl_User.Text = "未登录";
            }

        }
    }


    #region 消息筛选器 
    public class MessageFilter : IMessageFilter
    {
        public bool PreFilterMessage(ref Message m)
        {
            //如果检测到有鼠标或则键盘的消息，则使计数为0.....
            if (m.Msg == 0x0200 || m.Msg == 0x0201 || m.Msg == 0x0204 || m.Msg == 0x0207)
            {
                Program.TickCount = 0;
            }
            return false;
        }
    }
    #endregion


}