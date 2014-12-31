using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MultiplicationGame
{
    class Program
    {
        static bool?[] canWin;
        static void Main(string[] args)
        {
            int input = Convert.ToInt32(Console.ReadLine());
            canWin = new bool?[input * 9];
            for (int i = 0;  i < canWin.Length; i++)
            {
                canWin[i] = null;
            }
            bool who = whoIsTheWinner(input, 1, true);
            Console.WriteLine(who? "Stan Wins!": "Ollie Wins!");

            return;
        }

        static bool whoIsTheWinner(int n, int p, bool current)
        {
            for (int i = 2; i <= 9; i++)
            {
                if (p * i >= n) return current;

                if (canWin[p * i] != null)
                {
                    if (canWin[p * i] == true)
                    {
                        return current;
                    }
                }
                canWin[p * i] = whoIsTheWinner(n, p * i, !current) == current;
                if (canWin[p * i] == true) return current;
            }
            return !current;
        }
    }
}
