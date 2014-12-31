using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace The_Trip
{
    class Program
    {
        static void Main(string[] args)
        {
            string input;
            while ((input = Console.ReadLine()) != "0")
            {
                int num = Convert.ToInt32(input);
                double[] costs = new double[num];
                int i = 0;
                while (num != 0)
                {
                    costs[i++] = Convert.ToDouble(Console.ReadLine());
                    num--;
                }

                Console.WriteLine(minAmtToBeShared(costs));    
            }
        }

        static double minAmtToBeShared(double[] costs)
        {
            double avg = costs.Average();
            avg = avg - (int)avg < 0.01 ? (int)avg : avg;

            double diff = 0.0;

            for (int i = 0; i < costs.Length; i++)
            {
                if (costs[i] < avg)
                {
                    diff += avg - costs[i];
                }
            }
            return diff;
        }
    }
}
