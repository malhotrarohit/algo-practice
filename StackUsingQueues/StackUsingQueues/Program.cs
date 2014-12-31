using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackUsingQueues
{
    class Program
    {
        static Queue<int> Q1 = new Queue<int>();
        static Queue<int> Q2 = new Queue<int>();

        static void Main(string[] args)
        {

        }
        static void Push(int a)
        {
            if(Q1.Count > 0)
            {
                Q1.Enqueue(a);
            }
            else if(Q2.Count > 0)
            {
                Q2.Enqueue(a);
            }
        }

        static int Pop()
        {
            Queue<int> Q3 = new Queue<int>();
            if(Q1.Count > 0)
            {
                while(Q1.Count > 1)
                {
                    Q2.Enqueue(Q1.Dequeue());
                }
                Q3 = Q1;
            }
            if (Q2.Count > 0)
            {
                while (Q2.Count > 1)
                {
                    Q1.Enqueue(Q2.Dequeue());
                }
                Q3 = Q1;
            }

            return Q3.Dequeue();
        }
    }
}
