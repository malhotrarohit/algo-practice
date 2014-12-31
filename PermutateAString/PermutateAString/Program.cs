using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PermutateAString
{
    class Program
    {
        static int count = 0;
        static void Main(string[] args)
        {
            char[] c = Console.ReadLine().ToCharArray();
            Permutate(c, 0 , c.Length-1);
        }

        static void Permutate(char[] c, int start, int end)
        {
            if (start == end)
            {
                Console.WriteLine(c);
                count++;
                return;
            }
            for (int i = start; i <= end; i++)
            {
                if (c[start] == c[i] && i != start)
                {
                    continue;
                }
                else
                {
                    Swap(ref c[start], ref c[i]);
                    Permutate(c, start + 1, end);
                    Swap(ref c[start], ref c[i]);
                }
            }
        }

        static void Swap(ref char a, ref char b)
        {
            char temp = a;
            a = b;
            b = temp;
        }
    }
}
