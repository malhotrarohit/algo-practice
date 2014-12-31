using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PrimeFactorization
{
    class Program
    {
        static int[] powers;
        static List<ulong> indices = new List<ulong>();

        static void Main(string[] args)
        {
            ulong num = Convert.ToUInt64(Console.ReadLine());
            powers = new int[num / 2 + 1];

            factorize(num);
            if (indices.Count == 0)
            {
                Console.WriteLine("The number is prime!");
                return;
            }
            string factorization = "";
            foreach(int i in indices)
            {
                factorization += string.Format("{0}^{1} * ", i, powers[i]);
            }
            Console.WriteLine(factorization.Substring(0, factorization.Length - 2));
            return;
        }

        static void factorize(ulong num)
        {
            ulong temp = num;
            for (ulong i = 2; i < num / 2 + 1; i++)
            {
                if (temp % i == 0)
                {
                    indices.Add(i);

                    while (temp % i == 0)
                    {
                        powers[i]++;
                        temp /= i;
                    }
                }
            }
        }
    }
}
