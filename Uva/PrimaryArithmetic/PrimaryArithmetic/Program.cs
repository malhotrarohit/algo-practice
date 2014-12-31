using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PrimaryArithmetic
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(' ');
            uint a = Convert.ToUInt32(input[0]);
            uint b = Convert.ToUInt32(input[1]);

            Console.WriteLine(CalculateCarry(a, b) + " carry operations!");
        }

        static uint CalculateCarry(uint a, uint b)
        {
            uint num1 = a > b ? a : b;
            uint num2 = a > b ? b : a;

            uint carry = 0, count = 0;

            while (num2 > 0 || carry != 0)
            {
                uint digitFirst = num1 % 10;
                uint digitSecond = num2 % 10;
                carry = (digitFirst + digitSecond + carry)/10;

                count =  carry > 0? count + 1 : count;

                num1 /= 10;
                num2 /= 10;
            }

            return count;
        }
    }
}
