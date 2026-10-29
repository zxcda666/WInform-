using DevExpress.Utils.Extensions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using xbd.PressurizationStationPro;

namespace PressurizationStationPro
{
    public partial class FrmUserManage : Form
    {
        public FrmUserManage()
        {
            InitializeComponent();

            this.dgv_User.AutoGenerateColumns = false;
        }

        private SysAdminService adminService = new SysAdminService();

        private List<SysAdmin> sysAdmins = new List<SysAdmin> { };

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

        private void dgv_data_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            DataGridViewHelper.DgvRowPostPaint(this.dgv_User, e);
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void  RefreshUserList()
        {
            sysAdmins = adminService.QuerySysAdmin();
            if (sysAdmins.Count > 0)
            {
                this.dgv_User.DataSource = null;
                this.dgv_User.DataSource = this.sysAdmins;
            }
            else
            {
                this.dgv_User.DataSource = null;
            }

        }

        private void UpdataUserInfo(SysAdmin sysAdmin)
        {
            this.txt_LoginName.Text = sysAdmin.LoginName;
            this.txt_LoginPwd.Text  = StringSecurityHelper.DESDecrypt(sysAdmin.LoginPwd);
            this.cmb_RoleName.Text = sysAdmin.RoleName.ToString();
        }

        private void FrmUserManage_Load(object sender, EventArgs e)
        {
            //初始化用户角色下拉框
            this.cmb_RoleName.Items.AddRange(Enum.GetNames(typeof(RoleName)));

            //加载用户列表
            RefreshUserList();

            //默认选中第一行，把用户信息显示到编辑区
            if (this.dgv_User.Rows.Count > 0)
            {
                this.dgv_User.Rows[0].Selected = true;
                UpdataUserInfo(this.sysAdmins[0]);
            }
            else
            {
                this.cmb_RoleName.SelectedIndex = 0;
            }
        }

        private void btn_DelectUser_Click(object sender, EventArgs e)
        {
            if (this.dgv_User.SelectedRows.Count > 0)
            {               
                                        //获取指定行，并获取指定行的LoginId;
                //int loginId = sysAdmins[this.dgv_User.SelectedRows[0].Index].LoginId;

                int loginId = Convert.ToInt32(this.dgv_User.SelectedRows[0].Cells[3].Value);

                if(adminService.DeleteSysAdmin(loginId))
                {
                    //刷新用户列表
                    RefreshUserList();
                }
                else
                {
                    new FrmMsgNoAck("删除用户失败，请检查！", "删除用户").ShowDialog();
                    return;
                }
            }
        }

        private void btn_ModifyUser_Click(object sender, EventArgs e)
        {
            //【1】判断非空
            if (this.txt_LoginName.Text.Trim().Length == 0)
            {
                new FrmMsgNoAck("用户名不能为空", "修改用户").ShowDialog();
                return;
            }

            if (this.txt_LoginPwd.Text.Trim().Length == 0)
            {
                new FrmMsgNoAck("用户密码不能为空", "修改用户").ShowDialog();
                return;
            }

            //【2】封装对象
            SysAdmin sysAdmin = new SysAdmin()
            {
                LoginId = sysAdmins[this.dgv_User.SelectedRows[0].Index].LoginId,
                LoginName = this.txt_LoginName.Text.Trim(),
                LoginPwd = StringSecurityHelper.DESEncrypt(this.txt_LoginPwd.Text.Trim()),
                RoleName = (RoleName)Enum.Parse(typeof(RoleName), this.cmb_RoleName.Text),
            };
            //【3】修改用户
            if (adminService.ModifySysAdmin(sysAdmin))
            {
                //刷新用户列表
                RefreshUserList();
            }
            else
            {
                new FrmMsgNoAck("修改用户失败，请检查！", "修改用户").ShowDialog();
                return;
            }
        }

        private void btn_AddUser_Click(object sender, EventArgs e)
        {
            //【1】判断非空
            if(this.txt_LoginName.Text.Trim().Length==0)
            {
                new FrmMsgNoAck("用户名不能为空","增加用户").ShowDialog();
                return;
            }

            if (this.txt_LoginPwd.Text.Trim().Length == 0)
            {
                new FrmMsgNoAck("用户密码不能为空", "增加用户").ShowDialog();
                return;
            }
            //【2】判断是否存在
            if(sysAdmins.Where(c=>c.LoginName==this.txt_LoginName.Text.Trim()).Count()>0)
            {
                new FrmMsgNoAck("当前用户名已存在请更换！","增加用户").ShowDialog();
                return;
            }
            //【3】封装对象
            SysAdmin sysAdmin = new SysAdmin()
            {
                LoginName = this.txt_LoginName.Text,
                LoginPwd = StringSecurityHelper.DESEncrypt(this.txt_LoginPwd.Text.Trim()),
                RoleName = (RoleName)Enum.Parse(typeof(RoleName), this.cmb_RoleName.Text),
            };
            //【4】添加用户
            if(adminService.AddSysAdmin(sysAdmin))
            {
                //刷新用户列表
                RefreshUserList();
            }
            else
            {
                new FrmMsgNoAck("添加用户失败，请检查！","添加用户").ShowDialog();
                return;
            }

        }

        private void dgv_User_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex>=0)
            {
                UpdataUserInfo(sysAdmins[e.RowIndex]);
            }
        }

        private void lbl_Exit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void dgv_User_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                if(e.ColumnIndex==1&&e.Value!=null)
                {
                    e.Value=StringSecurityHelper.DESDecrypt(e.Value.ToString());
                }
            }
        }
    }
}
