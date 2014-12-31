using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _3n_1
{
    class Program
    {
        static void Main(string[] args)
        {
            string input;
            while((input = Console.ReadLine())!= string.Empty){
            string[] nums = input.Split(' ');
            Console.WriteLine("{0} {1} {2}",nums[0], nums[1], cycleLength(nums));
           }
        }

        static int cycleLength(string[] nums)
        {
            int i = Convert.ToInt32(nums[0]);
            int j = Convert.ToInt32(nums[1]);
            int n = i;
            int maxLen = 1; 
            while (n <= j)
            {
                int temp = n;
                int cycleLen = 1;
                while (temp != 1)
                {
                    temp = temp % 2 != 0 ? 3 * temp + 1 : temp / 2;
                    cycleLen++;
                }
                maxLen = cycleLen > maxLen ? cycleLen : maxLen;
                n++;
            }
            return maxLen;
        }
    }
}
