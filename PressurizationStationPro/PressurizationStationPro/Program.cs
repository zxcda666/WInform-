using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using xbd.DataConvertLib;
using xbd.s7netplus;

namespace PressurizationStationPro
{
    internal static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //var result = GetInfoFromFile("123.txt");

            //if(result.IsSuccess)
            //{
            //    MessageBox.Show("读取文件信息为： " + result.Content);
            //}
            //else
            //{
            //    MessageBox.Show("读取文件失败：" + result.Message);
            //}

            Application.Run(new FrmMain());
        }

        public static OperateResult<string> GetInfoFromFile(string path)
        {
            if(File.Exists(path))
            {
                return OperateResult.CreateSuccessResult("测试数据");
            }
            else
            {
                return OperateResult.CreateFailResult<string>("文件不存在");
            }

        }
    }
}
