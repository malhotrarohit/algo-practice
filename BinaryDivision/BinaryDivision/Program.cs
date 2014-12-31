using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BinaryDivision
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(' ');
            Console.WriteLine(string.Format("{0}", longDivision(Convert.ToUInt32(input[0]), Convert.ToUInt32(input[1]))));
            Console.WriteLine(string.Format("{0}", longDiv(Convert.ToUInt32(input[0]), Convert.ToUInt32(input[1]))));
        }

        static uint longDivision(uint a, uint b)
        {
            int diff = 1;

            while (b < a)
            {
                b <<= 1;
                ++diff;
            }

            uint result = 0;
            while (diff-- != 0) //until all the bits have been dealt with
            {
                result <<= 1; //prepare the slot for next bit
                if (a >= b) //if a >= b there is scope for subtracting b from a (typical long division)
                {
                    a -= b; //subtract b from a
                    result |= 1; //since a >= b put a 1 on rightmost side of the growing quotient
                }
                b >>= 1; //rightshift b to prepare for next subtraction
            }

            return result;
        }

        static uint longDiv(uint a, uint b)
        {
            uint low = b, high = a, mid = (low+high)/2;

            while (mid!= low && mid!= high && low < high)
            {
                if (mid * b > a)
                {
                    high = mid;
                }
                else
                {
                    low = mid;
                }
                mid = (low + high) / 2;
            }

            return high;
        }
    }
}
