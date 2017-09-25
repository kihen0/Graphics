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
            public double[,] data;
            public Matrix(double[,] inpMatrix)
            {
                data = inpMatrix;
            }
            public Matrix Multiply(double[,] matrixB)
            {
                if (matrixB.GetLength(0) != this.data.GetLength(1))
                    throw new Exception("!!!");
                double[,] result = new double[data.GetLength(0),matrixB.GetLength(1)];
                for (int i = 0; i <data.GetLength(0); i++)
                {
                    for (int j = 0; j <matrixB.GetLength(1); j++)
                    {
                        double sum=0;
                        for (int k = 0; k < this.data.GetLength(1); k++)
                        {
                            sum += data[i, k] * matrixB[k, j];
                        }
                        result[i,j] = sum;
                    }
                }
                return new Matrix(result);
            }
            public Matrix MultiplyByNumber(double number)
            {
                var res = new double[data.GetLength(0), data.GetLength(1)];
                for (int i = 0; i < data.GetLength(0); i++)
                {
                    for (int j = 0; j < data.GetLength(1); j++)
                    {
                        res[i,j]=data[i, j] * number;
                    }
                }
                return new Matrix(res);
            } 
            public static Matrix IdentityMatrix(int size)
            {
                double[,] result = new double[size, size];
                for (int i = 0; i < size; i++)                
                    for (int j = 0; j < size; j++)                    
                        if (i==j)                       
                            result[i, j] = 1;

                return new Matrix( result);                                      
            }
        }
    }
}
