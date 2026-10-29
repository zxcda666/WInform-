using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using xbd.DataConvertLib;
using xbd.s7netplus;
using DataType = xbd.s7netplus.DataType;

namespace PressurizationStationPro
{
    /// <summary>
    /// 通信类
    /// </summary>
    public class S7NetLib
    {
        ///<summary>
        ///私有字段
        ///</summary>
        private Plc siemens;

        public CpuType CpuType { get; set; }
        public string IPAddress { get; set; }
        public short Rack { get; set; }
        public short Slot { get; set; }

        /// <summary>
        /// 无参构造函数
        /// </summary>
        public S7NetLib()
        {

        }
        /// <summary>
        /// 有参构造函数
        /// </summary>
        /// <param name="cpuType"></param>
        /// <param name="ip"></param>
        /// <param name="rack"></param>
        /// <param name="slot"></param>

        public S7NetLib(CpuType cpuType,string ip,short rack,short slot)
        {
            this.CpuType = cpuType;
            this.IPAddress = ip;
            this.Rack = rack;
            this.Slot = slot;
        }

        /// <summary>
        /// 锁标志位
        /// </summary>
        private static object objLock = new object();

        public OperateResult Connect()
        {
            try
            {
                //如果已经连接，先断开再重新连接
                if (this.siemens != null && this.siemens.IsConnected)
                {
                    this.siemens.Close();
                }
                //连接PLC
                siemens = new Plc(this.CpuType, this.IPAddress, this.Rack, this.Slot);
                siemens.Open();
                return OperateResult.CreateSuccessResult();
            }
            catch (Exception ex)
            {
                return OperateResult.CreateFailResult(ex.Message);
            }
        }
            
        public void DisConnect()
        {
            if (this.siemens != null && this.siemens.IsConnected)
            {
                this.siemens.Close();
            }
        }
        
        /// <summary>
        /// 读取字节数组
        /// </summary>
        /// <param name="dataType"></param>
        /// <param name="db"></param>
        /// <param name="start"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        public OperateResult<byte[]> ReadByteArray(DataType dataType,int db,int start,int count)
        {
            if (this.siemens != null && this.siemens.IsConnected)
            {
                try
                {
                    lock (objLock)
                    {
                        return OperateResult.CreateSuccessResult(siemens.ReadBytes(dataType, db, start, count));
                    }
                }
                catch (Exception ex)
                {
                    return OperateResult.CreateFailResult<byte[]>("读取失败: " + ex.Message);
                }
            }
            else
            {
                return OperateResult.CreateFailResult<byte[]>("请检查PLC连接是否正常");
            }
        }

        /// <summary>
        /// 读取单个变量
        /// </summary>
        /// <param name="varAddress"></param>
        /// <returns></returns>
        public OperateResult<object> ReadVariable(string varAddress)
        {
            if (this.siemens != null && this.siemens.IsConnected)
            {
                try
                {
                    lock (objLock)
                    {
                        return OperateResult.CreateSuccessResult(siemens.Read(varAddress));
                    }
                }
                catch (Exception ex)
                {
                    return OperateResult.CreateFailResult<object>("读取失败: " + ex.Message);
                }
            }
            else
            {
                return OperateResult.CreateFailResult<object>("请检查PLC连接是否正常");
            }
        }

        /// <summary>
        /// 读取类对象
        /// </summary>
        /// <param name="varAddress"></param>
        /// <returns></returns>
        public OperateResult<T> ReadClass<T>(int db,int start) where T : class
        {
            if (this.siemens != null && this.siemens.IsConnected)
            {
                try
                {
                    lock (objLock)
                    {
                        return OperateResult.CreateSuccessResult(siemens.ReadClass<T>(db,start));
                    }
                }
                catch (Exception ex)
                {
                    return OperateResult.CreateFailResult<T>("读取失败: " + ex.Message);
                }
            }
            else
            {
                return OperateResult.CreateFailResult<T>("请检查PLC连接是否正常");
            }
        }

        public OperateResult WriteVariable(string varAddress,object value)
        {
            if (this.siemens != null && this.siemens.IsConnected)
            {
                try
                {
                    lock (objLock)
                    {
                        siemens.Write(varAddress,value);
                        return OperateResult.CreateSuccessResult();
                    }
                }
                catch (Exception ex)
                {
                    return OperateResult.CreateFailResult("读取失败: " + ex.Message);
                }
            }
            else
            {
                return OperateResult.CreateFailResult("请检查PLC连接是否正常");
            }
        }
    }
}
