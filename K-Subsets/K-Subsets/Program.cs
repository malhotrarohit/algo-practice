using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace K_Subsets
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] A = { 1, 2, 3, 4, 5 };//all elements are unique
                                        //in case elements are non unique
                                        //eliminate the duplicates first
            Subsets(A, 0, A.Length , 3);
        }

        //Find k sized subsets of A
        static void Subsets(int[] A, int low, int high, int k)
        {
            if (k == 0)
            {
                return;
            }
            while(low <= high - k)
            {
                Console.Write(A[low] + " ");
                Subsets(A, low + 1, high, k - 1);
                low++;
                Console.WriteLine();
            }
        }
    }
}
