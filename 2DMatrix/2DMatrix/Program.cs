using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2DMatrix
{
    class Program
    {
        static void Main(string[] args)
        {
            int[,] A = new int[10, 10];
            for(int i = 0 ; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    if ((i+j) % 15 == 0)
                    {
                        A[i,j] = 0;
                    }
                    else
                    {
                        A[i, j] = i + j;
                    }
                }
            }

            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    if(A[i,j] == 0)
                    {
                        if(!isColFilled(A,i,j))
                        {
                            colFill(A, i, j);
                        }
                        if (!isRowFilled(A,i,j))
                        {
                            rowFill(A, i, j);
                        }
                    }
                }
            }
        }
    }
}
