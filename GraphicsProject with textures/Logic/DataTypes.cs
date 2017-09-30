
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Logic
{
    public struct DataArrays
    {
        public Tuple<double, double, double>[] Vertices;
        public PointF[] VT;
        public Tuple<double, double, double>[] VN;
        public Tuple<int, int, int>[][][] Groups;
        public DataArrays(Tuple<double, double, double>[] vertices, PointF[] vt,
            Tuple<double, double, double>[]vn, Tuple<int, int, int>[][][] groups)
        {
            Vertices = vertices;
            VT = vt;
            VN = vn;
            Groups = groups;             
        }
    }
    struct Vector3D
    {
        public float x, y, z;
        public float this[int index]
        {
            get
            {
                switch (index)
                {
                    case 0:
                        return x;
                    case 1:
                        return y;
                    case 2:
                        return z;
                    default:
                        throw new Exception("!!! !! !!! ! !!! !! !!!!");
                }
            }
        }
        public Vector3D(float x, float y, float z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }
        public Vector3D(double x, double y, double z)
        {
            this.x = (float)x;
            this.y = (float)y;
            this.z = (float)z;
        }
        public Vector3D(float[] coordArray)
        {
            x = coordArray[0];
            y = coordArray[1];
            z = coordArray[2];
        }
        public static Vector3D operator +(Vector3D v1,Vector3D v2)
        {
            return new Vector3D(v1.x + v2.x, v1.y + v2.y, v1.z + v2.z);
        }
        public static Vector3D operator -(Vector3D v1, Vector3D v2)
        {
            return new Vector3D(v1.x - v2.x, v1.y - v2.y, v1.z - v2.z);
        }
        public static float operator *(Vector3D v1,Vector3D v2)
        {
           return v1.x * v2.x + v1.y * v2.y + v1.z * v2.z;
        }
        public static Vector3D operator *(float k,Vector3D v)
        {
            return new Vector3D(k * v.x, k * v.y, k * v.z);
        }
        public static Vector3D operator *( Vector3D v,float k)
        {
            return new Vector3D(k * v.x, k * v.y, k * v.z);
        }
        public float Abs()
        {
            return (float)Math.Sqrt(x * x + y * y + z * z);
        }
        public Vector3D Normalize()
        {
            return this * (1/ this.Abs());
        }
    }
}
