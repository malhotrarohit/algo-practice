using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ramanujan
{
    class Program
    {
        static void Main(string[] args)
        {
            int count = 0;
            int num = Convert.ToInt32(Console.ReadLine());

            Dictionary<long, int> cubeSums = new Dictionary<long, int>();

            for (int i = 1; i < num; i++)
            {
                for (int j = i + 1; j < num; j++)
                {
                    long cubeSum = i * i * i + j * j * j;

                    if (cubeSums.ContainsKey(cubeSum))
                    {
                        Console.WriteLine("{0} is a number the form a^3+b^3 = c^3 + d^3 such that a,b,c,d < num", i * i * i + j * j * j);
                    }
                    else
                    {
                        cubeSums.Add(cubeSum, 1);
                    }
                }
            }
            return;
        }
    }
}