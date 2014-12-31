using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotNavigation
{
    class Program
    {
        static void Main(string[] args)
        {
            int m, n;
            Console.WriteLine("Enter the dimensions of the maze; Rows and Columns");
            m = Convert.ToInt32(Console.ReadLine());
            n = Convert.ToInt32(Console.ReadLine());
            int[,] C = new int[m + 1, n + 1];

            for (int i = 1; i < m + 1 ; i++)
            {
                C[i, 1] = 1;
            }
            for (int j = 1; j < n + 1; j++)
            {
                C[1, j] = 1;
            }
            
            Console.WriteLine(Compute(C, m, n));
        }

        static int Compute(int[,] C, int m, int n)
        {
            if (m == 1 || n == 1 || C[m, n] != 0)
            {
                return C[m, n];
            }
            C[m, n] = Compute(C, m, n - 1) + Compute(C, m - 1, n);
            return C[m, n];
        }

    }
}
