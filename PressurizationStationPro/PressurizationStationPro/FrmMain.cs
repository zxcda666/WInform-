using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using xbd.s7netplus;

namespace PressurizationStationPro
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();

            //第一种
            //siemens = new S7NetLib();
            //siemens.CpuType = CpuType.S71500;
            //siemens.IPAddress = "192.168.10.100";
            //siemens.Rack = 0;
            //siemens.Slot = 0;

            //第二种
            siemens = new S7NetLib(CpuType.S71500,"192.168.10.100",0,1);
            var result = siemens.Connect();
            if(result.IsSuccess)
            {
                //[i] 读取单个变量
                var data = siemens.ReadVariable("DB1.DBD4");
                if(data.IsSuccess)
                {
                    MessageBox.Show(Convert.ToUInt32(data.Content).ConvertToFloat().ToString());
                }
            }
        }

        private S7NetLib siemens = null;

        private void MainPanel_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}