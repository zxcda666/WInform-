using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using xbd.PressurizationStationPro;

namespace PressurizationStationPro
{
    /// <summary>
    /// 业务层:核心是方法
    /// </summary>
    public class SysAdminService
    {
        /// <summary>
        /// 获取所有的用户对象
        /// </summary>
        /// <returns></returns>
        public List<SysAdmin> QuerySysAdmin()
        {
            string sql = "Select LoginId,LoginName,LoginPwd,RoleName from SysAdmin";
            //调用SQL语句
            SQLiteDataReader dataReader = SQLiteHelper.ExecuteReader(sql);

            List<SysAdmin> sysAdmins = new List<SysAdmin>();

            while (dataReader.Read())
            {
                sysAdmins.Add(new SysAdmin()
                {
                    LoginId = Convert.ToInt32(dataReader["LoginId"]),
                    LoginName = dataReader["LoginName"].ToString(),
                    LoginPwd = dataReader["LoginPwd"].ToString(),
                    RoleName = (RoleName)Enum.Parse(typeof(RoleName),dataReader["RoleName"].ToString(),true)
                });
            }
            //关闭dataReader
            dataReader.Close();
            return sysAdmins;
        }
        /// <summary>
        /// 用户登录验证
        /// </summary>
        /// <param name="sysAdmin"></param>
        /// <returns></returns>
        public SysAdmin AdminLogin(SysAdmin sysAdmin)
        {
            //[1]封装SQL语句
            string sql = "Select LoginId,RoleName from SysAdmin Where LoginName=@LoginName and LoginPwd=@LoginPwd";

            //把值给到占位符
            SQLiteParameter[] parameters = new SQLiteParameter[]
            {
                new SQLiteParameter("@LoginName",sysAdmin.LoginName),
                new SQLiteParameter("@LoginPwd",sysAdmin.LoginPwd),
            };

            //[2]提交查询
            SQLiteDataReader dataReader = SQLiteHelper.ExecuteReader(sql,parameters);

            //[3]判断是否成功
            if (dataReader.Read())
            {
                sysAdmin.LoginId = Convert.ToInt32(dataReader["LoginId"]);
                sysAdmin.RoleName = (RoleName)Enum.Parse(typeof(RoleName),dataReader
                    ["RoleName"].ToString());
            }
            else
            {
                sysAdmin = null;
            }

            //关闭dataReader
            dataReader.Close();
            return sysAdmin;
        }


        /// <summary>
        /// 增加用户
        /// </summary>
        /// <param name="sysAdmin"></param>
        /// <returns></returns>
        public bool AddSysAdmin(SysAdmin sysAdmin)
        {
            StringBuilder stringBuilder = new StringBuilder();

            stringBuilder.Append("Insert into SysAdmin(LoginName,LoginPwd,RoleName) ");
            stringBuilder.Append("values(@LoginName,@LoginPwd,@RoleName)");

            SQLiteParameter[] parameters = new SQLiteParameter[]
            {
                new SQLiteParameter("@LoginName",sysAdmin.LoginName),
                new SQLiteParameter("@LoginPwd",sysAdmin.LoginPwd),
                new SQLiteParameter("@RoleName",sysAdmin.RoleName)
            };

            return SQLiteHelper.ExecuteNonQuery(stringBuilder.ToString(), parameters) == 1;
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="sysAdmin"></param>
        /// <returns></returns>
        public bool ModifySysAdmin(SysAdmin sysAdmin)
        {
            StringBuilder stringBuilder = new StringBuilder();

            stringBuilder.Append("Update SysAdmin set" +
                " LoginName=@LoginName,LoginPwd=@LoginPwd,RoleName=@RoleName ");
            stringBuilder.Append("where LoginId = @LoginId");
            SQLiteParameter[] parameters = new SQLiteParameter[]
            {
                new SQLiteParameter("@LoginName",sysAdmin.LoginName),
                new SQLiteParameter("@LoginPwd",sysAdmin.LoginPwd),
                new SQLiteParameter("@RoleName",sysAdmin.RoleName),
                new SQLiteParameter("@LoginId",sysAdmin.LoginId)
            };
            return SQLiteHelper.ExecuteNonQuery(stringBuilder.ToString(), parameters) == 1;

        }

        public bool DeleteSysAdmin(int LoginId)
        {
            string sql = "Delete from SysAdmin where LoginId=@LoginId";
            SQLiteParameter[] parameters = new SQLiteParameter[]
            {
                new SQLiteParameter("@LoginId",LoginId),
            };

            return SQLiteHelper.ExecuteNonQuery(sql, parameters) == 1;
        }
       
    }
}
