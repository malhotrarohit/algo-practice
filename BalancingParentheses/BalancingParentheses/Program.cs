using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BalancingParentheses
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            bool balanced = isBalanced(input);
            if (balanced)
            {
                Console.WriteLine("The given string is balanced");
            }
            else
            {
                Console.WriteLine("The given string is not balanced");
            }

            int index = earliestUnBalancedCulprit(input);
            if (index != -1) { Console.WriteLine("The given string is unbalanced at {0}", index); }
        }

        static bool isBalanced(string input)
        {
            int left = 0, right = 0;
            if (input == string.Empty) return true;

            for (int i = 0; i < input.Length; i++)
            {
                if (input.ElementAt(i) == '(') { left++; }
                else { right++; }
                if ((right > left) || ((left - right) - (input.Length - 1 - i) > 0)) { return false; }
            }

            return true;
        }

        static int earliestUnBalancedCulprit(string input)
        {
            Stack stack = new Stack();
            int n = -1;

            for (int i = 0; i < input.Length; i++)
            {
                if (input.ElementAt(i) == '(') { stack.Push(i); }
                else { stack.Pop(); }
            }
            if (!stack.Empty)
            {
                n = stack.Pop();
            }
            return n;
        }
    }
}
