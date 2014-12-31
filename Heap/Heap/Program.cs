using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Heap
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] A = { 3, 6, 1, 2, 10, 7, 8, 11, 9, 0 };
            Heap h = new Heap(20);
            h.BuildHeap(A);

            for (int i = 0; i < A.Length; i++)
            {
                A[i] = h.ExtractMin();
            }
        }
    }
}
