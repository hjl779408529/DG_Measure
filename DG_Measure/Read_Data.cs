using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HslCommunication.LogNet;
using HslCommunication.Enthernet;
using HslCommunication.Profinet.Omron;
using HslCommunication;
using System.Windows.Forms;

namespace DG_Measure
{
    class ReadValue 
    {
        //电池侧面 正 X Y Z 
        public Vector3D Mp8a = new Vector3D(0, 30, 94);//(X,Y,Z)->(D1002,D1004,D102)
        public Vector3D Mp9a = new Vector3D(20, 70, 254);//(X,Y,Z)->(D1002,D1006,D104) 
        public Vector3D Mp10a = new Vector3D(40, 100, 384);//(X,Y,Z)->(D1002,D1008,D106) 
        public Vector3D Mp11a = new Vector3D(60, 60, 304);//(X,Y,Z)->(D1002,D1010,D108)
                                                          //电池侧面 背   
        public Vector3D Mp8b = new Vector3D(80, 70, 374);//(X,Y,Z)->(D1022,D1024,D160)
        public Vector3D Mp9b = new Vector3D(100, 100, 504);//(X,Y,Z)->(D1022,D1026,D162)
        public Vector3D Mp10b = new Vector3D(120, 150, 694);//(X,Y,Z)->(D1022,D1028,D164)
        public Vector3D Mp11b = new Vector3D(140, 220, 944);//(X,Y,Z)->(D1022,D1030,D166)
                                                            //电池正面大框 正   
        public Vector3D Mp1a = new Vector3D(160, 70, 534);//(X,Y,Z)->(D1046,D1048,D152)
        public Vector3D Mp2a = new Vector3D(180, 100, 664);//(X,Y,Z)->(D1044,D1048,D144)
        public Vector3D Mp3a = new Vector3D(200, 150, 854);//(X,Y,Z)->(D1042,D1048,D142)
        public Vector3D Mp4a = new Vector3D(220, 220, 1104);//(X,Y,Z)->(D1042,D1052,D140)
        public Vector3D Mp5a = new Vector3D(240, 260, 1264);//(X,Y,Z)->(D1044,D1052,D148)
        public Vector3D Mp6a = new Vector3D(260, 310, 1454);//(X,Y,Z)->(D1046,D1052,D150)
        public Vector3D Mp7a = new Vector3D(280, 360, 1644);//(X,Y,Z)->(D1044,D1050,D146)
                                                            //电池正面大框 背   
        public Vector3D Mp1b = new Vector3D(300, 70, 814);//(X,Y,Z)->(D1046,D1048,D132)
        public Vector3D Mp2b = new Vector3D(320, 100, 944);//(X,Y,Z)->(D1044,D1048,D124)
        public Vector3D Mp3b = new Vector3D(340, 150, 1134);//(X,Y,Z)->(D1042,D1048,D122)
        public Vector3D Mp4b = new Vector3D(360, 220, 1384);//(X,Y,Z)->(D1042,D1052,D120)
        public Vector3D Mp5b = new Vector3D(380, 260, 1544);//(X,Y,Z)->(D1044,D1052,D128)
        public Vector3D Mp6b = new Vector3D(400, 310, 1734);//(X,Y,Z)->(D1046,D1052,D130)
        public Vector3D Mp7b = new Vector3D(420, 360, 1924);//(X,Y,Z)->(D1044,D1050,D126)
                                                            //电池正面中间 正   
        public Vector3D MP30a = new Vector3D(440, 70, 1094);//(X,Y,Z)->(D1122,D1126,D240)
        public Vector3D MP31a = new Vector3D(460, 100, 1224);//(X,Y,Z)->(D1044,D1126,D242)
        public Vector3D MP32a = new Vector3D(480, 150, 1414);//(X,Y,Z)->(D1124,D1126,D244)
        public Vector3D MP33a = new Vector3D(500, 220, 1664);//(X,Y,Z)->(D1122,D1050,D246)
        public Vector3D MP34a = new Vector3D(520, 260, 1824);//(X,Y,Z)->(D1124,D1050,D248)
        public Vector3D MP35a = new Vector3D(540, 310, 2014);//(X,Y,Z)->(D1122,D1128,D250)
        public Vector3D MP36a = new Vector3D(560, 360, 2204);//(X,Y,Z)->(D1044,D1128,D252)
        public Vector3D MP37a = new Vector3D(580, 410, 2394);//(X,Y,Z)->(D1124,D1128,D254)
        public Vector3D MP38a = new Vector3D(600, 460, 2584);//(X,Y,Z)->(D1042,D1050,D134)
        public Vector3D MP39a = new Vector3D(620, 510, 2774);//(X,Y,Z)->(D1046,D1050,D136)
                                                             //电池正面中间 背   
        public Vector3D MP30b = new Vector3D(640, 70, 1494);//(X,Y,Z)->(D1122,D1126,D260)
        public Vector3D MP31b = new Vector3D(660, 100, 1624);//(X,Y,Z)->(D1044,D1126,D262)
        public Vector3D MP32b = new Vector3D(680, 150, 1814);//(X,Y,Z)->(D1124,D1126,D264)
        public Vector3D MP33b = new Vector3D(700, 220, 2064);//(X,Y,Z)->(D1122,D1050,D266)
        public Vector3D MP34b = new Vector3D(720, 260, 2224);//(X,Y,Z)->(D1124,D1050,D268)
        public Vector3D MP35b = new Vector3D(740, 310, 2414);//(X,Y,Z)->(D1122,D1128,D270)
        public Vector3D MP36b = new Vector3D(760, 360, 2604);//(X,Y,Z)->(D1044,D1128,D272)
        public Vector3D MP37b = new Vector3D(780, 410, 2794);//(X,Y,Z)->(D1124,D1128,D274)
        public Vector3D MP38b = new Vector3D(800, 460, 2984);//(X,Y,Z)->(D1042,D1050,D154)
        public Vector3D MP39b = new Vector3D(820, 510, 3174);//(X,Y,Z)->(D1046,D1050,D156)
                                                             //电池壳顶部   
        public Vector3D Mp24a = new Vector3D(840, 70, 1894);//(X,Y,Z)->(D1062,D1068,D180)
        public Vector3D Mp25a = new Vector3D(860, 100, 2024);//(X,Y,Z)->(D1062,D1070,D182)
        public Vector3D Mp26a = new Vector3D(880, 150, 2214);//(X,Y,Z)->(D1064,D1070,D184)
        public Vector3D Mp27a = new Vector3D(900, 220, 2464);//(X,Y,Z)->(D1064,D1068,D186)
        public Vector3D Mp28a = new Vector3D(920, 260, 2624);//(X,Y,Z)->(D1066,D1068,D188)
        public Vector3D Mp29a = new Vector3D(940, 310, 2814);//(X,Y,Z)->(D1066,D1070,D190)
                                                             //电池A极柱   
        public Vector3D Mp12a = new Vector3D(960, 70, 2134);//(X,Y,Z)->(D1082,D1088,D200)
        public Vector3D Mp13a = new Vector3D(980, 100, 2264);//(X,Y,Z)->(D1084,D1088,D202)
        public Vector3D Mp14a = new Vector3D(1000, 150, 2454);//(X,Y,Z)->(D1066,D1088,D204)
        public Vector3D Mp15a = new Vector3D(1020, 220, 2704);//(X,Y,Z)->(D1082,D1090,D206)
        public Vector3D Mp16a = new Vector3D(1040, 260, 2864);//(X,Y,Z)->(D1084,D1090,D208)
        public Vector3D Mp17a = new Vector3D(1060, 310, 3054);//(X,Y,Z)->(D1086,D1090,D210)
                                                              //电池B极柱   
        public Vector3D Mp18a = new Vector3D(1080, 70, 2374);//(X,Y,Z)->(D1102,D1108,D220)
        public Vector3D Mp19a = new Vector3D(1100, 100, 2504);//(X,Y,Z)->(D1104,D1108,D222)
        public Vector3D Mp20a = new Vector3D(1120, 150, 2694);//(X,Y,Z)->(D1106,D1108,D224)
        public Vector3D Mp21a = new Vector3D(1140, 220, 2944);//(X,Y,Z)->(D1102,D1110,D226)
        public Vector3D Mp22a = new Vector3D(1160, 260, 3104);//(X,Y,Z)->(D1104,D1110,D228)
        public Vector3D Mp23a = new Vector3D(1180, 310, 3294);//(X,Y,Z)->(D1106,D1110,D230)
        //变量索引
        private Dictionary<string, string> valueList = new Dictionary<string, string>
        {
            {"Mp8a","D1002,D1004,D102"},
            {"Mp9a","D1002,D1006,D104"},
            {"Mp10a","D1002,D1008,D106"},
            {"Mp11a","D1002,D1010,D108"},
            {"Mp8b","D1022,D1024,D160"},
            {"Mp9b","D1022,D1026,D162"},
            {"Mp10b","D1022,D1028,D164"},
            {"Mp11b","D1022,D1030,D166"},
            {"Mp1a","D1046,D1048,D152"},
            {"Mp2a","D1044,D1048,D144"},
            {"Mp3a","D1042,D1048,D142"},
            {"Mp4a","D1042,D1052,D140"},
            {"Mp5a","D1044,D1052,D148"},
            {"Mp6a","D1046,D1052,D150"},
            {"Mp7a","D1044,D1050,D146"},
            {"Mp1b","D1046,D1048,D132"},
            {"Mp2b","D1044,D1048,D124"},
            {"Mp3b","D1042,D1048,D122"},
            {"Mp4b","D1042,D1052,D120"},
            {"Mp5b","D1044,D1052,D128"},
            {"Mp6b","D1046,D1052,D130"},
            {"Mp7b","D1044,D1050,D126"},
            {"MP30a","D1122,D1126,D240"},
            {"MP31a","D1044,D1126,D242"},
            {"MP32a","D1124,D1126,D244"},
            {"MP33a","D1122,D1050,D246"},
            {"MP34a","D1124,D1050,D248"},
            {"MP35a","D1122,D1128,D250"},
            {"MP36a","D1044,D1128,D252"},
            {"MP37a","D1124,D1128,D254"},
            {"MP38a","D1042,D1050,D134"},
            {"MP39a","D1046,D1050,D136"},
            {"MP30b","D1122,D1126,D260"},
            {"MP31b","D1044,D1126,D262"},
            {"MP32b","D1124,D1126,D264"},
            {"MP33b","D1122,D1050,D266"},
            {"MP34b","D1124,D1050,D268"},
            {"MP35b","D1122,D1128,D270"},
            {"MP36b","D1044,D1128,D272"},
            {"MP37b","D1124,D1128,D274"},
            {"MP38b","D1042,D1050,D154"},
            {"MP39b","D1046,D1050,D156"},
            {"Mp24a","D1062,D1068,D180"},
            {"Mp25a","D1062,D1070,D182"},
            {"Mp26a","D1064,D1070,D184"},
            {"Mp27a","D1064,D1068,D186"},
            {"Mp28a","D1066,D1068,D188"},
            {"Mp29a","D1066,D1070,D190"},
            {"Mp12a","D1082,D1088,D200"},
            {"Mp13a","D1084,D1088,D202"},
            {"Mp14a","D1066,D1088,D204"},
            {"Mp15a","D1082,D1090,D206"},
            {"Mp16a","D1084,D1090,D208"},
            {"Mp17a","D1086,D1090,D210"},
            {"Mp18a","D1102,D1108,D220"},
            {"Mp19a","D1104,D1108,D222"},
            {"Mp20a","D1106,D1108,D224"},
            {"Mp21a","D1102,D1110,D226"},
            {"Mp22a","D1104,D1110,D228"},
            {"Mp23a","D1106,D1110,D230"}
        };
        //Point7AList 7点模式A面点集合 
        private Dictionary<string, string> Point7AList = new Dictionary<string, string>
        {
            {"Mp1a","D1046,D1048,D152"},
            {"Mp2a","D1044,D1048,D144"},
            {"Mp3a","D1042,D1048,D142"},
            {"Mp4a","D1042,D1052,D140"},
            {"Mp5a","D1044,D1052,D148"},
            {"Mp6a","D1046,D1052,D150"},
            {"Mp7a","D1044,D1050,D146"}
        };
        //Point7BList 7点模式B面点集合 
        private Dictionary<string, string> Point7BList = new Dictionary<string, string>
        {
            {"Mp1b","D1046,D1048,D132"},
            {"Mp2b","D1044,D1048,D124"},
            {"Mp3b","D1042,D1048,D122"},
            {"Mp4b","D1042,D1052,D120"},
            {"Mp5b","D1044,D1052,D128"},
            {"Mp6b","D1046,D1052,D130"},
            {"Mp7b","D1044,D1050,D126"}
        };
        //Point9AList 9点模式A面点集合 
        private Dictionary<string, string> Point9AList = new Dictionary<string, string>
        {
            {"Mp1a","D1046,D1048,D152"},
            {"Mp2a","D1044,D1048,D144"},
            {"Mp3a","D1042,D1048,D142"},
            {"Mp4a","D1042,D1052,D140"},
            {"Mp5a","D1044,D1052,D148"},
            {"Mp6a","D1046,D1052,D150"},
            {"MP38a","D1042,D1050,D134"},
            {"MP39a","D1046,D1050,D136"},
            {"Mp7a","D1044,D1050,D146"}
        };
        //Point9BList 9点模式B面点集合 
        private Dictionary<string, string> Point9BList = new Dictionary<string, string>
        {
            {"Mp1b","D1046,D1048,D132"},
            {"Mp2b","D1044,D1048,D124"},
            {"Mp3b","D1042,D1048,D122"},
            {"Mp4b","D1042,D1052,D120"},
            {"Mp5b","D1044,D1052,D128"},
            {"Mp6b","D1046,D1052,D130"},
            {"MP38b","D1042,D1050,D154"},
            {"MP39b","D1046,D1050,D156"},
            {"Mp7b","D1044,D1050,D126"}
        };
        //Point13A1List 13点模式A1面点集合 
        private Dictionary<string, string> Point13A1List = new Dictionary<string, string>
        {
            {"Mp1a","D1046,D1048,D152"},
            {"Mp3a","D1042,D1048,D142"},
            {"Mp4a","D1042,D1052,D140"},
            {"Mp6a","D1046,D1052,D150"}
        };
        //Point13A2List 13点模式A2面点集合 
        private Dictionary<string, string> Point13A2List = new Dictionary<string, string>
        {
            {"MP30a","D1122,D1126,D240"},
            {"MP31a","D1044,D1126,D242"},
            {"MP32a","D1124,D1126,D244"},
            {"MP33a","D1122,D1050,D246"},
            {"MP34a","D1124,D1050,D248"},
            {"MP35a","D1122,D1128,D250"},
            {"MP36a","D1044,D1128,D252"},
            {"MP37a","D1124,D1128,D254"},
            {"Mp7a","D1044,D1050,D146"}
        };
        //Point13B1List 13点模式B1面点集合 
        private Dictionary<string, string> Point13B1List = new Dictionary<string, string>
        {
            {"Mp1b","D1046,D1048,D132"},
            {"Mp3b","D1042,D1048,D122"},
            {"Mp4b","D1042,D1052,D120"},
            {"Mp6b","D1046,D1052,D130"}
        };
        //Point13B2List 13点模式B2面点集合 
        private Dictionary<string, string> Point13B2List = new Dictionary<string, string>
        {
            {"MP30b","D1122,D1126,D260"},
            {"MP31b","D1044,D1126,D262"},
            {"MP32b","D1124,D1126,D264"},
            {"MP33b","D1122,D1050,D266"},
            {"MP34b","D1124,D1050,D268"},
            {"MP35b","D1122,D1128,D270"},
            {"MP36b","D1044,D1128,D272"},
            {"MP37b","D1124,D1128,D274"},
            {"Mp7b","D1044,D1050,D126"}
        };
        //Omron连接
        private OmronFinsNet omronFinsNet;

        /// <summary>
        /// 初始化连接参数
        /// </summary>
        /// <param name="ip"></param>
        /// <param name="port"></param>
        /// <param name="sa1"></param>
        /// <param name="da1"></param>
        /// <param name="da2"></param>
        public ReadValue(string ip,UInt16 port,byte sa1,byte da1,byte da2)
        {
            omronFinsNet = new OmronFinsNet(ip,port);
            omronFinsNet.SA1 = sa1; // PC网络号，PC的IP地址的最后一个数
            omronFinsNet.DA1 = da1; // PLC网络号，PLC的IP地址的最后一个数
            omronFinsNet.DA2 = da2; // PLC单元号，通常为0
        }
        /// <summary>
        /// 无参数初始化
        /// </summary>
        public ReadValue()
        {

        }
        /// <summary>
        /// 连接PLC
        /// </summary>
        public bool openConnectPLC() 
        {
            OperateResult connect = omronFinsNet.ConnectServer();
            if (connect.IsSuccess)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// 关闭连接
        /// </summary> 
        public void closeConnectPLC()
        {
            omronFinsNet.ConnectClose();
        }
        /// <summary>
        /// 对变量进行赋值
        /// </summary>
        public void readValue()
        {
            foreach (var o in valueList)
            {
                string[] tmp = o.Value.Split(',');
                double x = omronFinsNet.ReadFloat(tmp[0]).Content;
                double y = omronFinsNet.ReadFloat(tmp[1]).Content;
                double z = omronFinsNet.ReadFloat(tmp[2]).Content;
                this.GetType().GetField(o.Key).SetValue(this, new Vector3D(0, 0, 1));
            }
        }
        /// <summary>
        /// 程序流程状态
        /// </summary>
        public Int32 Process
        {
            get
            {
                return omronFinsNet.ReadInt32("D500").Content;
            }
            set
            {
                omronFinsNet.Write("D500",(Int32)value);
            }
        } 
        /// <summary>
        /// 程序模式判断
        /// </summary>
        public UInt16 Mode
        {
            get { return omronFinsNet.ReadUInt16("D918").Content; }
        }
    }
    
}
