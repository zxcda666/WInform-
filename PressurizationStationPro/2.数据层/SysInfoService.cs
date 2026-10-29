using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using xbd.PressurizationStationPro;
using xbd.s7netplus;

namespace PressurizationStationPro
{
    /// <summary>
    /// 系统信息服务类
    /// </summary>
    public class SysInfoService
    {
        //读取ini文件
        public SysInfo GetSysInfoFromPath(string path)
        {
            SysInfo sysInfo = new SysInfo();

            try
            {
                sysInfo.IPAddress = IniConfigHelper.ReadIniData("通信参数", "IP地址", "127.0.0.1", path);
                sysInfo.CpuType = (CpuType)Enum.Parse(typeof(CpuType),                      //第三个参数true忽略大小写
                    IniConfigHelper.ReadIniData("通信参数", "CPU类型", "127.0.0.1", path)
                    , true
                    ); //string转枚举
                sysInfo.Rack = Convert.ToInt16(IniConfigHelper.ReadIniData("通信参数", "机架号", "0", path));
                sysInfo.Slot = Convert.ToInt16(IniConfigHelper.ReadIniData("通信参数", "插槽号", "0", path));

                sysInfo.AutoStart = IniConfigHelper.ReadIniData("系统参数", "开机启动", "1", path) == "1";
                sysInfo.ScreenTime = Convert.ToInt16(IniConfigHelper.ReadIniData("系统参数", "熄屏时间", "0", path));
                sysInfo.LogoffTime = Convert.ToInt16(IniConfigHelper.ReadIniData("系统参数", "注销时间", "0", path));
                sysInfo.CameraIndex = Convert.ToInt16(IniConfigHelper.ReadIniData("系统参数", "摄像头序号", "0", path));
            }
            catch
            {
                return null;
            }
            return sysInfo;
        }
        /// <summary>
        /// 将sysInfo对象写入到配置文件当中
        /// </summary>
        /// <param name="sysInfo"></param>
        /// <param name="path"></param>
        /// <returns></returns>
        public bool SetSysInfoToPath(SysInfo sysInfo, string path)
        {
            bool result = true;

            result &= IniConfigHelper.WriteIniData ("通信参数","IP地址",sysInfo.IPAddress,path);
            result &= IniConfigHelper.WriteIniData("通信参数", "CPU类型", sysInfo.CpuType.ToString(), path);
            result &= IniConfigHelper.WriteIniData("通信参数", "机架号", sysInfo.Rack.ToString(), path);
            result &= IniConfigHelper.WriteIniData("通信参数", "插槽号", sysInfo.Slot.ToString(), path);

            result &= IniConfigHelper.WriteIniData("系统参数", "开机启动", sysInfo.AutoStart?"1":"0", path);
            result &= IniConfigHelper.WriteIniData("系统参数", "熄屏时间", sysInfo.ScreenTime.ToString(), path);
            result &= IniConfigHelper.WriteIniData("系统参数", "注销时间", sysInfo.LogoffTime.ToString(), path);
            result &= IniConfigHelper.WriteIniData("系统参数", "摄像头序号", sysInfo.CameraIndex.ToString(), path);

            return result;
        }
    }
}
