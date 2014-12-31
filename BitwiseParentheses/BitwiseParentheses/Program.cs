using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitwiseParentheses
{
    class Program
    {
        static int count = 0;
        static void Main(string[] args)
        {
            char[] input = Console.ReadLine().ToCharArray();
            string choice = Console.ReadLine();
            if (choice == "true") Console.WriteLine(f(input, 0, input.Length - 1, true));
            else {Console.WriteLine(f(input, 0, input.Length - 1, false));}
        }

        static int f(char[] input, int low, int high, bool choice)
        {
            if (low == high)
            {
                if (input[low]=='1' && choice)
                {
                    return 1;
                }
                else if (input[low] == '0' && !choice)
                {
                    return 1;
                }
                else
                {
                    return 0;
                }
            }

            int c = 0;
            for (int i = low + 1; i < high; i += 2)
            {
                if (choice)
                {
                    if (input[i] == '^')
                    {
                        c += f(input, low, i - 1, true) * f(input, i + 1, high, false);
                        c += f(input, low, i - 1, false) * f(input, i + 1, high, true);
                    }
                    else if (input[i] == '&')
                    {
                        c += f(input, low, i - 1, true) * f(input, i + 1, high, true);
                    }
                    else if(input[i] == '|')
                    {
                        c += f(input, low, i - 1, true) * f(input, i + 1, high, false);
                        c += f(input, low, i - 1, false) * f(input, i + 1, high, true);
                        c += f(input, low, i - 1, true) * f(input, i + 1, high, true);
                    }
                }
                else
                {
                    if(input[i] == '^')
                    {
                        c += f(input, low, i - 1, true) * f(input, i + 1, high, true);
                        c += f(input, low, i - 1, false) * f(input, i + 1, high, false);
                    }
                    else if(input[i] == '&')
                    {
                        c += f(input, low, i - 1, false) * f(input, i + 1, high, true);
                        c += f(input, low, i - 1, true) * f(input, i + 1, high, false);
                        c += f(input, low, i - 1, false) * f(input, i + 1, high, false);
                    }
                    else if(input[i] == '|')
                    {
                        c += f(input, low, i - 1, false) * f(input, i + 1, high, false);
                    }
                }
            }

            return c;
        }
    }
}
