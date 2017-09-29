using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Logic;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            MathExt.Matrix a = new MathExt.Matrix(new double[3, 3] { { -1,0 ,0 }, { 0,1,0 }, { 0,0,-1 } });
            double[,] edin = new double[3, 3] { { 0,1,1}, { 0,1,0 }, {0,0,0 } };
            var matr = a.MultiplyRight(edin);
            for (int i = 0; i < matr.data.GetLength(0); i++)
            {
                for (int j = 0; j < matr.data.GetLength(1); j++)
                {
                    Console.Write(" "+matr.data[i, j]); 
                }
                Console.WriteLine("");
            }
            Console.ReadKey();
        }
    }
}
