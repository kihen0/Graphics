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
            MathExt.Matrix a = new MathExt.Matrix(new double[3, 3] { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 } });
            double[,] edin = new double[3, 3] { { 2,1,3 }, { 5,4,6 }, { 8,7,9 } };
            var matr = a.Multiply(edin);
            for (int i = 0; i < matr.GetLength(0); i++)
            {
                for (int j = 0; j < matr.GetLength(1); j++)
                {
                    Console.Write(" "+matr[i, j]); 
                }
                Console.WriteLine("");
            }
            Console.ReadKey();
        }
    }
}
