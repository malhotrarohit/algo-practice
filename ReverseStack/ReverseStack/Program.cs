using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReverseStack
{
    class Program
    {
        static void Main(string[] args)
        {
            Stack<int> S = new Stack<int>();
            int i = 0;
            while (i != 100)
            {
                S.Push(i++);
            }
            Stack<int> Q = new Stack<int>();
            int a = 0;
            Reverse(S, Q, a);
        }

        static Stack<int> Reverse(Stack<int> S, Stack<int> Q, int a)
        {
            int count = S.Count;
            int i = 0;
            while (i < count - 1)
            {
                while (S.Count > 1)
                {
                    Q.Push(S.Pop());
                }
                a = S.Pop();
                while (Q.Count > i)
                {
                    S.Push(Q.Pop());
                }
                S.Push(a);
                int j = i;
                while (j > 0)
                {
                    S.Push(Q.Pop());
                    j--;
                }
                i++;
            }

            return S;
        }
    }
}
