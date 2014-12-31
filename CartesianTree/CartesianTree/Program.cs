using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CartesianTree
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = new int[] { 9, 3, 7, 1, 8, 12, 10, 20, 15, 18, 5 };
            CartesianTree ctree = new CartesianTree();
            ctree.Create(numbers);
            int n = ctree.RangeMiniumum(4, 10);
            return;,hnm
        }
    }
}
