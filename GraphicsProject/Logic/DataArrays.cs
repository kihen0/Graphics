
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public struct DataArrays
    {
        public Tuple<double, double, double>[] Vertices;
        public Tuple<double, double, double>[] VT;
        public Tuple<double, double, double>[] VN;
        public Tuple<int, int, int>[][] Faces;
        public DataArrays(Tuple<double, double, double>[] vertices, Tuple<double, double, double>[] vt,
            Tuple<double, double, double>[]vn, Tuple<int, int, int>[][] faces)
        {
            Vertices = vertices;
            VT = vt;
            VN = vn;
            Faces = faces;             
        }
    }
}
