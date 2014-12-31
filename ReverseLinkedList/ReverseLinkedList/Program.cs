using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ReverseLinkedList
{
    class Program
    {
        static void Main(string[] args)
        {
            SinglyLinkedList list = new SinglyLinkedList();

            for (int i = 0; i < 100; i++)
            {
                list.Add(i);
            }

            list.Reverse();
        }
    }
}
