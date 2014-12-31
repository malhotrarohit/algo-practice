using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MergeNCompanies
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("The number of ways of mergin {0} companies is : {1}", num, Merge(num));
            return;
        }

        static int Merge(int n)
        {
            int count = 0;

            if (n == 2)
            {
                return 1;
            }

            count += n;
            count *= Merge(n - 1);

            return count;
        }
    }
}
