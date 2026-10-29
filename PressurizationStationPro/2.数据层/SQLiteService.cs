using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using xbd.PressurizationStationPro;

namespace PressurizationStationPro
{
    public class SQLiteService
    {
        //设置指定数据库
        public void SetConnectStr(string connStr)
        {
            SQLiteHelper.ConnString = connStr;
        }
    }
}
