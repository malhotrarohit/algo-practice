using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SortNegativesAndPositives
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] A = { 0, 10, -9, -8, 7, 6, -5, 4, -3, -2, -1 };

            int index = 0;
            for (int i = 0; i < A.Length; i++)
            {
                if (A[i] < 0)
                {
                    Swap(ref A[index], ref A[i]);
                    index++;
                }
            }
        }

        static void Swap(ref int a, ref int b)
        {
            int temp = a;
            a = b;
            b = temp;
        }
    }
}
