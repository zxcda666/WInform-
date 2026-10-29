using MiniExcelLibs.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PressurizationStationPro
{
    public class HistoryData
    {
        [ExcelColumnName("日期时间")]
        [ExcelFormat("yyyy-MM-dd HH:mm:ss")]
        [ExcelColumnWidth(20)]
        public DateTime InsertTime {  get; set; }
        [ExcelColumnWidth(12)]
        [ExcelColumnName("进口压力")]
        public string PressureIn {  get; set; }
        [ExcelColumnWidth(12)]
        [ExcelColumnName("出口压力")]
        public string PressureOut { get; set; }
        [ExcelColumnWidth(14)]
        [ExcelColumnName("进口温度1")]
        public string TempIn1 { get; set; }
        [ExcelColumnWidth(14)]
        [ExcelColumnName("进口温度2")]
        public string TempIn2 { get; set; }
        [ExcelColumnWidth(12)]
        [ExcelColumnName("出口温度")]
        public string TempOut { get; set; }
        [ExcelColumnWidth(14)]
        [ExcelColumnName("水箱压力1")]
        public string PressureTank1 { get; set; }
        [ExcelColumnWidth(14)]
        [ExcelColumnName("水箱压力2")]
        public string PressureTank2 {  get; set; }
        [ExcelColumnWidth(14)]
        [ExcelColumnName("水箱液位1")]
        public string LevelTank1 { get; set; }
        [ExcelColumnWidth(14)]
        [ExcelColumnName("水箱液位2")]
        public string LevelTank2 { get; set; }
        [ExcelColumnWidth(18)]
        [ExcelColumnName("水箱出口压力")]
        public string PressureTankOut { get; set; }

    }
}
