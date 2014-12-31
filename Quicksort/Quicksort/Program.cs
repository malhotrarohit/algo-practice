using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace Quicksort
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] nums ={10,8,9,6,7,11};
            Qsort q = new Qsort();
            q.Sort(nums, 0, nums.Length - 1);
        }
    }
}
