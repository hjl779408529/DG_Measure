using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DG_Measure
{
    class PlaneData
    {
        public List<Vector3D> PlanePointList { get; set; }//平面坐标点集合
        public PlanePara Plane { get; set; }//平面
        public Vector3D PlaneCriterionPoint { get; set; }//平面基准坐标
        public Vector3D PlaneLastPoint { get; set; }//平面计算坐标
    }

    class PlaneResole
    {
        //Point7AList 7点模式A面点集合     
        public string[] Point7AList = new string[]
        {
            "Mp1a",
            "Mp2a",
            "Mp3a",
            "Mp4a",
            "Mp5a",
            "Mp6a",
            "Mp7a"
        };
        //Point7BList 7点模式B面点集合     
        public string[] Point7BList = new string[]
        {
            "Mp1b",
            "Mp2b",
            "Mp3b",
            "Mp4b",
            "Mp5b",
            "Mp6b",
            "Mp7b"
        };
        //Point9AList 9点模式A面点集合     
        public string[] Point9AList = new string[]
        {
            "Mp1a",
            "Mp2a",
            "Mp3a",
            "Mp4a",
            "Mp5a",
            "Mp6a",
            "MP38a",
            "MP39a",
            "Mp7a"
        };
        //Point9BList 9点模式B面点集合     
        public string[] Point9BList = new string[]
        {
            "Mp1b",
            "Mp2b",
            "Mp3b",
            "Mp4b",
            "Mp5b",
            "Mp6b",
            "MP38b",
            "MP39b",
            "Mp7b"
        };
        //Point13A1List 13点模式A1面点集合     
        public string[] Point13A1List = new string[]
        {
            "Mp1a",
            "Mp3a",
            "Mp4a",
            "Mp6a"
        };
        //Point13A2List 13点模式A2面点集合     
        public string[] Point13A2List = new string[]
        {
            "MP30a",
            "MP31a",
            "MP32a",
            "MP33a",
            "MP34a",
            "MP35a",
            "MP36a",
            "MP37a",
            "Mp7a"
        };
        //Point13B1List 13点模式B1面点集合     
        public string[] Point13B1List = new string[]
        {
            "Mp1b",
            "Mp3b",
            "Mp4b",
            "Mp6b"
        };
        //Point13B2List 13点模式B2面点集合     
        public string[] Point13B2List = new string[]
        {
            "MP30b",
            "MP31b",
            "MP32b",
            "MP33b",
            "MP34b",
            "MP35b",
            "MP36b",
            "MP37b",
            "Mp7b"
        };

        /// <summary>
        /// 七点或九点模式
        /// </summary>
        /// <returns></returns>
        public PlaneData Mode79Point(ReadValue data, string[] listName)
        {
            PlaneData Result = new PlaneData();
            List<Vector3D> tmpPointList = new List<Vector3D>();
            //生成该平面坐标点集合
            for (int i = 0;i < listName.Length;i++)
            {
                Result.PlanePointList.Add((Vector3D)data.GetType().GetField(listName[i]).GetValue(data));
            }
            tmpPointList = Result.PlanePointList.Take(Result.PlanePointList.Count - 1).ToList();
            Result.Plane = Algorithm.getPlanePara(tmpPointList.ToArray());//平面参数计算
            double x = (tmpPointList.Max(o => o.X) + tmpPointList.Min(o => o.X)) / 2;
            double y = (tmpPointList.Max(o => o.Y) + tmpPointList.Min(o => o.Y)) / 2;
            double z = Result.Plane.Kx * x + Result.Plane.Ky * y + Result.Plane.B;
            Result.PlaneCriterionPoint = new Vector3D(x,y,z);
            Result.PlaneLastPoint = Result.PlanePointList[Result.PlanePointList.Count - 1];//计算对比点
            double delta = Algorithm.getDotToPlaneDistance(Result.PlaneCriterionPoint, Result.Plane);
            return Result;
        }
        /// <summary>
        /// 13点模式
        /// </summary>
        /// <param name="data"></param>
        /// <param name="listName"></param>
        /// <returns></returns>
        public PlaneData Mode13Point(ReadValue data, string[] listName) 
        {
            PlaneData Result = new PlaneData();
            //生成该平面坐标点集合
            for (int i = 0; i < listName.Length; i++)
            {
                Result.PlanePointList.Add((Vector3D)data.GetType().GetField(listName[i]).GetValue(data));
            }
            Result.Plane = Algorithm.getPlanePara(Result.PlanePointList.ToArray());//平面参数计算
            double x = (Result.PlanePointList.Max(o => o.X) + Result.PlanePointList.Min(o => o.X)) / 2;
            double y = (Result.PlanePointList.Max(o => o.Y) + Result.PlanePointList.Min(o => o.Y)) / 2;
            double z = Result.Plane.Kx * x + Result.Plane.Ky * y + Result.Plane.B;
            Result.PlaneCriterionPoint = new Vector3D(x, y, z);
            Result.PlaneLastPoint = Result.PlanePointList[Result.PlanePointList.Count - 1];//计算最后点位
            double delta = Algorithm.getDotToPlaneDistance(Result.PlaneCriterionPoint, Result.Plane);
            return Result;
        }
    }
}
