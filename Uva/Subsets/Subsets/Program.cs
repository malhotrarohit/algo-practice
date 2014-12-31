using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Subsets
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] A = { "rohit", "harshit", "mahesh", "madhu" };
            Subsets(A);
        }

        static void Subsets(string[] A)
        {
            List<List<string>> dict = new List<List<string>>();

            int len = A.Length;

            for (int i = 1; i < Math.Pow(2, len); i++)
            {
                List<string> subset = new List<string>();
                for (int j = 1; j < Math.Pow(2, len); j = j << 1)
                {
                    if ((i & j) != 0)
                    {
                        subset.Add(A[len - Convert.ToInt32(Math.Log(j, 2.0)) - 1]);
                    }
                }
                dict.Add(subset);
            }
        }
    }
}
