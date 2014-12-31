using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LongestPalindromeLength
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            char[] c = input.ToCharArray();
            int lenSimilar = 1, temp = 1;
            for (int i = 0; i < c.Length-1; i++)
            {
                if (c[i] == c[i + 1])
                {
                    temp++;
                }
                else
                {
                    if (temp > lenSimilar)
                    {
                        lenSimilar = temp;
                    }
                }
            }

            int[,] l = new int[c.Length+1, c.Length];
            for (int i = 0; i < c.Length; i++)
            {
                l[1, i] = 1;
            }
            for(int len = 3; len <= c.Length; len++)
            {
                int j = 0;
                while(j+len <= c.Length){
                    if (j - 1 >= 0 && j + 1 <= c.Length && c[j-1] == c[j+len-1])
                    {
                        l[len, j] = l[len - 2, j] + 2;
                    }
                    j++;
                }
            }
        }
    }
}
