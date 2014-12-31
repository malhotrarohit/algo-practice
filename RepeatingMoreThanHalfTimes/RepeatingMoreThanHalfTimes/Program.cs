using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RepeatingMoreThanHalfTimes
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] A = { 2, 9, 7, 8, 9, 9, 9 };
            Stack<int> s = new Stack<int>();

            for (int i = 0; i < A.Length; i++)
            {
                if (s.Count == 0)
                {
                    s.Push(A[i]);
                }
                else
                {
                    if (A[i] == s.Peek())
                    {
                        s.Push(A[i]);
                    }
                    else
                    {
                        s.Pop();
                    }
                }
            }
            Console.WriteLine("The number is " + s.Pop()); 
            return;
        }
    }
}
