using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public class MathExt
    {
        public class Matrix
        {
            double[,] data;
            public Matrix(double[,] inpMatrix)
            {
                data = inpMatrix;
            }
            /*double Det()
            {
                if (data.GetLength(1) != data.GetLength(0))
                    throw new Exception("!!!!");
                for (int i = 0; i < data.GetLength(1); i++)
                {

                }
            }*/
        }
    }
}
