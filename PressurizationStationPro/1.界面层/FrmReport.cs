using DevExpress.Utils.Extensions;
using MiniExcelLibs;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using xbd.DataConvertLib;
using xbd.PressurizationStationPro;

namespace PressurizationStationPro
{
    public partial class FrmReport : Form
    {
        public FrmReport()
        {
            InitializeComponent();

            this.cmb_ReportType.Items.Add("小时报表");
            this.cmb_ReportType.Items.Add("日报表");
            this.cmb_ReportType.SelectedIndex = 0;

            //初始化条件
            InitalColumnList();
        }

        //小时报表:每分钟之间的数据 12:00 12：00-12.01： 。。。12.59-13.00 60个时间段  条件: 最大值 最小值 平均值
        //日报表: 24条记录  每小时之间的数据      max(字段名1) min(字段2) avg(字段3).....

        //时间 条件 
        private List<string> maxCondition = new List<string>();
        private List<string> minCondition = new List<string>();
        private List<string> avgCondition = new List<string>();

        //创建服务类
        private HistoryDataService historyService = new HistoryDataService();

        private void InitalColumnList()
        {
            List<string> columnList = new List<string>();

            columnList.Add("PressureIn");
            columnList.Add("PressureOut");
            columnList.Add("TempIn1");
            columnList.Add("TempIn2");
            columnList.Add("TempOut");
            columnList.Add("PressureTank1");
            columnList.Add("PressureTank2");
            columnList.Add("LevelTank1");
            columnList.Add("LevelTank2");
            columnList.Add("PressureTankOut"); 

            foreach(var item in columnList)
            {
                maxCondition.Add($"Max({item})");
                minCondition.Add($"Min({item})");
                avgCondition.Add($"Avg({item})");
            }
        }


        private void lbl_Exit_Click(object sender, EventArgs e)
        {
            this.Close();
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

        private void cmb_ReportType_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (this.cmb_ReportType.SelectedIndex)
            {
                case 0:
                    this.dtp_ReportTime.CustomFormat = "yyyy-MM-dd HH:00:00";
                    break;
                case 1:
                    this.dtp_ReportTime.CustomFormat = "yyyy-MM-dd 00:00:00";
                    break;
                default:
                    this.dtp_ReportTime.CustomFormat = "yyyy-MM-dd HH:00:00";
                    break;
            }
        }

        private void btn_Query_Click(object sender, EventArgs e)
        {
            //时间段
            List<string> startList = new List<string>();
            List<string> endList = new List<string>();

            DateTime dateTime = this.dtp_ReportTime.Value;

            switch (this.cmb_ReportType.SelectedIndex)
            {
                //小时报表
                case 0:
                    dateTime = new DateTime(dateTime.Year, dateTime.Month, dateTime.Day, dateTime.Hour, 0, 0);
                    for (int i = 0; i < 60; i++)
                    {
                        startList.Add(dateTime.AddMinutes(i).ToString("yyyy-MM-dd HH:mm:ss"));
                        endList.Add(dateTime.AddMinutes(i+1).ToString("yyyy-MM-dd HH:mm:ss"));
                    }
                    break;
                //日报表
                case 1:
                    dateTime = new DateTime(dateTime.Year, dateTime.Month, dateTime.Day, 0, 0, 0);
                    for(int i = 0;i<24;i++)
                    {
                        startList.Add(dateTime.AddHours(i).ToString("yyyy-MM-dd HH:mm:ss"));
                        endList.Add(dateTime.AddHours(i + 1).ToString("yyyy-MM-dd HH:mm:ss"));
                    }
                    break;
                default:
                    break;
            }

            //条件
            List<string> conditionList = this.rdb_Max.Checked ? maxCondition : (this.rdb_Min.Checked ? minCondition : avgCondition);

            Task.Run(() =>
            {
                Task<OperateResult<DataTable>>[] taskList = new Task<OperateResult<DataTable>>[startList.Count];

                
                for(int i = 0;i<taskList.Length;i++)
                {
                    //每个时间段开启一个任务
                    int index = i;
                    taskList[index] = Task.Factory.StartNew(() =>
                    {
                        return historyService.GetReportDataByCondition(startList[index], endList[index],conditionList,index.ToString());
                    });
                }

                //Task.WhenAll 把 60 个任务合成一个，等全部完成才继续
                Task<OperateResult<DataTable>[]> task = Task.WhenAll(taskList);

                //至少读到了一条记录
                if (task.Result.Length > 0&&task.Result.First().IsSuccess)
                {
                    //希望得到一个DataTable

                    DataTable dataTable=GetAllDataTable(task.Result);

                    //再把这个DataTable显示到DGV中
                    if(dataTable!=null)
                    {
                        UpdateDataTable(dataTable,startList);
                    }
                    else
                    {
                        this.Invoke(new Action(() =>
                        {
                            new FrmMsgNoAck("查询数据表为空", "数据查询").ShowDialog();
                        }));
                        
                    }
                }
                else
                {
                    new FrmMsgNoAck("此时间段未查询到数据！","数据查询").ShowDialog();
                }
            });
        }

        private void UpdateDataTable(DataTable dataTable, List<string> startList)
        {
            if (this.dgv_data.InvokeRequired)
            {
                this.dgv_data.Invoke(new Action<DataTable,List<string>>(UpdateDataTable),dataTable,startList);
            }
            else
            {
                this.dgv_data.Rows.Clear();

                for(int i = 0; i<dataTable.Rows.Count; i++)
                {
                    int rowIndex = this.dgv_data.Rows.Add();
                    this.dgv_data.Rows[rowIndex].Cells[0].Value = startList[i];

                    for (int j = 0; j < dataTable.Columns.Count;j++)
                    {
                        this.dgv_data.Rows[rowIndex].Cells[j + 1].Value = dataTable.Rows[rowIndex][j];
                    }

                }
            }
        }

        private DataTable GetAllDataTable(OperateResult<DataTable>[] dataResult)
        {
            //获取所有成功的DataTable集合
            List<DataTable> dataTables = new List<DataTable>();

            foreach(var item in dataResult)
            {
                if(item.IsSuccess)
                {
                    dataTables.Add(item.Content);
                }
            }

            if (dataTables.Count > 0)
            {
                //排序
                dataTables = dataTables.OrderBy(c => Convert.ToInt16(c.TableName)).ToList();

                //再把这些DataTable合并成一个
                //复制已有的表的结构
                DataTable resultTable = dataTables.First().Clone();

                object[] rowData = new object[resultTable.Columns.Count]; 

                for(int i = 0;i < dataTables.Count;i++)
                { 
                    for(int j = 0;j < dataTables[i].Rows.Count;j++)
                    {
                        dataTables[i].Rows[j].ItemArray.CopyTo(rowData, 0);
                        resultTable.Rows.Add(rowData);
                    }
                }
                return resultTable;
            }
            else
            {
                return null; 
            }
            

        }

        private void btn_Export_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            //标题
            saveFileDialog.Title = "请选择文件";
            saveFileDialog.Filter = "Excel文件(.xlsx)|*.xlsx|CSV文件(*.csv)|*.csv";
            saveFileDialog.RestoreDirectory = true;
            saveFileDialog.FileName = "数据记录" + this.cmb_ReportType.Text+ Convert.ToDateTime(this.dtp_ReportTime.Text).ToString("yyyyMMddHHmmss");

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {

                    MiniExcel.SaveAs(saveFileDialog.FileName, GetHistoryDataFromDgv());
                    Process.Start(saveFileDialog.FileName);
                }
                catch (Exception ex)
                {
                    new FrmMsgNoAck("导出文件失败:" + ex.Message, "数据查询").ShowDialog();
                }

            }
        }

        private List<HistoryData> GetHistoryDataFromDgv()
        {
            if(this.dgv_data.Rows.Count>0)
            {
                List<HistoryData> historyDatas = new List<HistoryData>();
                foreach(DataGridViewRow item in this.dgv_data.Rows)
                {
                    historyDatas.Add(new HistoryData()
                    {
                        InsertTime = Convert.ToDateTime(item.Cells[0]),
                        PressureIn = item.Cells[1].Value.ToString(),
                        PressureOut = item.Cells[2].Value.ToString(),
                        TempIn1 = item.Cells[3].Value.ToString(),
                        TempIn2 = item.Cells[4].Value.ToString(),
                        TempOut = item.Cells[5].Value.ToString(),
                        PressureTank1 = item.Cells[6].Value.ToString(),
                        PressureTank2 = item.Cells[7].Value.ToString(),
                        LevelTank1 = item.Cells[8].Value.ToString(),
                        LevelTank2 = item.Cells[9].Value.ToString(),
                        PressureTankOut = item.Cells[10].Value.ToString(),
                    });

                }
                return historyDatas;
            }
            else
            {
                return new List<HistoryData>();
            }

        }
            
        
        private void dgv_data_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            DataGridViewHelper.DgvRowPostPaint(this.dgv_data,e);
        }

        private void btn_Print_Click(object sender, EventArgs e)
        {
            DataGridViewHelper.Print_DataGridView(this.dgv_data);
        }
    }







}