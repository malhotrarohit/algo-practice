using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ReservoirSampling
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] A = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            int i, k = 1 ;
            int[] res = new int[k];
            for (i = 0; i < k; i++)
            {
                res[i] = A[i];
            }

            Random r=new Random(DateTime.Now.Second);

            for (; i < A.Length; i++)
            {
                int j = r.Next(i);
                if (j < k)
                {
                    res[j] = A[i];
                }
            }

            foreach (int n in res) { Console.WriteLine(n); }
        }
    }
}
