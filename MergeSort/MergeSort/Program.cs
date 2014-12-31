using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MergeSort
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] A = { 10, 9, 8, 7, 6, 5, 4, 3, 2, 1 };
            MergeSort ms = new MergeSort();
            ms.Sort(A, 0, A.Length - 1);
        }
    }
}
