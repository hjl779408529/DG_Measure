using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MathNet.Numerics;
using MathNet.Numerics.LinearAlgebra;
using NetTopologySuite.Algorithm;


namespace DG_Measure
{
    class PlanePara
    {
        public double Kx { get; set; }
        public double Ky { get; set; }
        public double Kz { get; set; }
        public double B { get; set; }
        public double Flatness { get; set; }//平面度
        public PlanePara()
        {
            Kx = 0;
            Ky = 0;
            Kz = 0;
            B = 0;
            Flatness = 0;
        }
        public PlanePara(PlanePara Ini)
        {
            Kx = Ini.Kx;
            Ky = Ini.Ky;
            Kz = Ini.Kz;
            B = Ini.B;
            Flatness = Ini.Flatness;
        }
        public PlanePara(double kx, double ky, double kz, double b, double flatness)
        {
            Kx = kx;
            Ky = ky;
            Kz = kz;
            B = b;
            Flatness = flatness;
        }
        public double Norm
        {
            get => Math.Sqrt(Kx * Kx + Ky * Ky + Kz * Kz);
        }
    }
    class Vector
    {
        public double X { get; set; }
        public double Y { get; set; }

        public Vector(double x, double y)
        {
            this.X = x;
            this.Y = y;
        }
        public Vector(Vector Ini)
        {
            this.X = Ini.X;
            this.Y = Ini.Y;
        }
        public void Empty()
        {
            this.X = 0;
            this.Y = 0;
        }
        public double Length
        {
            get => Math.Sqrt(this.X * this.X + this.Y * this.Y);
        }
        public static Vector operator -(Vector a, Vector b)
        {
            return new Vector(a.X - b.X, a.Y - b.Y);
        }
        public static Vector operator +(Vector a, Vector b)
        {
            return new Vector(a.X + b.X, a.Y + b.Y);
        }
    }
    class Vector3D
    {
        public double X { get; set; }
        public double Y { get; set; }
        public double Z { get; set; }
        public Vector3D(object v)
        {
            X = 0;
            Y = 0;
            Z = 0;
        }
        public Vector3D(Vector3D Ini)
        {
            X = Ini.X;
            Y = Ini.Y;
            Z = Ini.Z;
        }
        public Vector3D(double x, double y, double z)
        {
            X = x;
            Y = y;
            Z = z;
        }
        public double Length
        {
            get => Math.Sqrt(this.X * this.X + this.Y * this.Y + this.Z * this.Z);
        }
        public static Vector3D operator +(Vector3D a, Vector3D b)
        {
            return new Vector3D(a.X + b.X, a.Y + b.Y, a.Z + b.Z);
        }
        public static Vector3D operator -(Vector3D a, Vector3D b)
        {
            return new Vector3D(a.X - b.X, a.Y - b.Y, a.Z - b.Z);
        }
        public static Vector3D operator *(Vector3D a, double b)
        {
            return new Vector3D(a.X * b, a.Y * b, a.Z * b);
        }
        public static Vector3D operator /(Vector3D a, double b)
        {
            if (b != 0)
            {
                return new Vector3D(a.X / b, a.Y / b, a.Z / b);
            }
            else
            {
                return new Vector3D(0, 0, 0);
            }
        }
    }
    class Algorithm
    {
        /// <summary>
        /// 给定一组数据计算拟合的平面
        /// </summary>
        /// <param name="points"></param>
        /// <returns></returns>
        public static PlanePara getPlanePara(Vector3D[] points)
        {
            
            PlanePara Result = new PlanePara();
            List<double> Delta = new List<double>();
            if (points.Length < 3) return Result;
            int nrows = points.Length;//行数
            int ncols = 3;//列数，坐标点数
            var mb = Matrix<double>.Build;
            //等号右矩阵
            var rightMatrix = mb.Dense(ncols, 1);
            for (int i = 0; i < nrows; i++) 
            {
                rightMatrix[0, 0] += points[i].X * points[i].Z;
                rightMatrix[1, 0] += points[i].Y * points[i].Z;
                rightMatrix[2, 0] += points[i].Z;
            }
            //等号左矩阵
            var leftMatrix = mb.Dense(ncols, ncols);
            for (int i = 0; i < nrows; i++)
            {
                leftMatrix[0, 0] += points[i].X * points[i].X;
                leftMatrix[1, 0] += points[i].X * points[i].Y;
                leftMatrix[2, 0] += points[i].X;
                leftMatrix[0, 1] += points[i].X * points[i].Y;
                leftMatrix[1, 1] += points[i].Y * points[i].Y;
                leftMatrix[2, 1] += points[i].Y;
                leftMatrix[0, 2] += points[i].X;
                leftMatrix[1, 2] += points[i].Y;
            }
            leftMatrix[2, 2] = nrows;
            //计算等号做矩阵的逆矩阵
            //var leftMatrixInverse = leftMatrix.Inverse();
            //计算系数矩阵
            var coefficientMatrix = leftMatrix.Svd().Solve(rightMatrix);            
            //计算平面度
            for (int i = 0;i< points.Length;i++)
            {
                Delta.Add(points[i].Z - (points[i].X * coefficientMatrix[0, 0] + points[i].Y * coefficientMatrix[1, 0] + coefficientMatrix[2, 0]));
            }
            //返回该平面参数
            Result.Kx = coefficientMatrix[0, 0];
            Result.Ky = coefficientMatrix[1, 0];
            Result.Kz = -1;
            Result.B = coefficientMatrix[2, 0];
            Result.Flatness =Math.Abs(Delta.Max()) + Math.Abs(Delta.Min());
            return Result;
        }
        /// <summary>
        /// 计算指定点到平面的距离
        /// </summary>
        /// <param name="dot"></param>
        /// <param name="plane"></param>
        /// <returns></returns>
        public static double getDotToPlaneDistance(Vector3D dot,PlanePara plane)
        {            
            return (plane.Kx * dot.X + plane.Ky * dot.Y + plane.Kz * dot.Z + plane.B)/plane.Norm;
        }
        /// <summary>
        /// 计算俩平面距离
        /// </summary>
        /// <param name="plane1"></param>
        /// <param name="plane2"></param>
        /// <returns></returns>
        public static double getPlaneToPlaneDistance(PlanePara plane1, PlanePara plane2)
        {
            Vector3D specifyPoint = new Vector3D(0,0, plane1.B);
            return getDotToPlaneDistance(specifyPoint, plane2);
        }
        /// <summary>
        /// 以指定点计算俩平面距离
        /// </summary>
        /// <param name="plane1"></param>
        /// <param name="plane2"></param>
        /// <returns></returns>
        public static double getPlaneToPlaneDistance(Vector Plane1point,PlanePara plane1, PlanePara plane2)
        {
            Vector3D specifyPoint = new Vector3D(Plane1point.X, Plane1point.Y, plane1.Kx * Plane1point.X + plane1.Ky * Plane1point.Y + plane1.B);
            return getDotToPlaneDistance(specifyPoint, plane2);
        }
        /// <summary>
        /// 计算两平面的夹角
        /// </summary>
        /// <param name="plane1"></param>
        /// <param name="plane2"></param>
        /// <returns></returns>
        public static double getPlaneToPlaneAngle(PlanePara plane1, PlanePara plane2)
        {
            Vector3D plane1NormalVector = new Vector3D(plane1.Kx, plane1.Ky, plane1.Kz);
            Vector3D plane2NormalVector = new Vector3D(plane2.Kx, plane2.Ky, plane2.Kz);
            double Cos_Theta = Dot(plane1NormalVector, plane2NormalVector) / (plane1NormalVector.Length * plane2NormalVector.Length);
            return Math.Acos(Cos_Theta) * 180 / Math.PI;
        }
        /// <summary>
        /// 计算两向量的 点积 Dot
        /// </summary>
        /// <param name="point1"></param>
        /// <param name="point2"></param>
        /// <returns></returns>
        public static double Dot(Vector3D point1, Vector3D point2)
        {
            return point1.X * point2.X + point1.Y * point2.Y + point1.Z * point2.Z;
        }
    }
}
