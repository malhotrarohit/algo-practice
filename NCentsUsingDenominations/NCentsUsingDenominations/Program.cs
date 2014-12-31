using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NCentsUsingDenominations
{
    class Program
    {
        static int ways = 0;
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the amount of cents");
            int n = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter the denominations, comma separated and in descending order!");
            string[] D = Console.ReadLine().Split(',');
            int[] N = new int[D.Length];
            for (int i = 0; i < D.Length; i++ )
            {
                N[i] = Convert.ToInt32(D[i]);
            }
            Console.WriteLine(Compute(n, N, 0));
        }
        static int Compute(int n, int[] N, int i){
            if (i == N.Length - 1)
            {
                return 1;
            }
            int j = 0;
            int numWays = 0;
            while (n > 0)
            {
                n = n - N[i] * j;
                numWays += Compute(n, N, i+1);
                j++;
            }
            return numWays;
        }
    }
}
