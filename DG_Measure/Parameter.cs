using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharpConfig;

namespace DG_Measure
{
    public class Parameter
    {
        public Int32 PortNo { get; set; }
        public short BaudrateNo { get; set; }
        public string PlcIp { get; set; }
        public UInt16 PlcPort { get; set; }
        public byte PlcSA1 { get; set; }
        public byte PlcDA1 { get; set; }
        public byte PlcDA2 { get; set; }
        public string UserDB { get; set; }
        public string UserTB { get; set; }
        public string UserPath { get; set; }
        public string WorkDB { get; set; }
        public string WorkTB { get; set; }
        public string WorkPath { get; set; }
        public bool Judge { get; set; }
        public int PageSize { get; set; }
    }
    class OperatePara
    {
        /// <summary>
        /// 读取配置参数
        /// </summary>
        /// <param name="filename"></param>
        public static Parameter LoadPara(string filename)
        {
            string filepath = @"./Config/" + filename;
            Configuration config = Configuration.LoadFromFile(filepath);
            Parameter Result = config["Parameter"].ToObject<Parameter>();
            return Result;
        }

        /// <summary>
        /// 保存配置参数
        /// </summary>
        /// <param name="filename"></param>
        public static bool SavePara(string filename, Parameter para)
        {
            string filepath = @"./Config/" + filename;
            var config = new Configuration
            {
                Section.FromObject("Parameter", para)
            };
            config.SaveToFile(filepath,Encoding.GetEncoding("gb2312"));
            return true;
        }
    }
}
