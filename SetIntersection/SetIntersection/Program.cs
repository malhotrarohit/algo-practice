using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SetIntersection
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the sets");
            string input;
            List<HashSet<int>> l = new List<HashSet<int>>();

            while ((input = Console.ReadLine()) != "")
            {
                string[] ar = input.Split(' ');
                HashSet<int>h = new HashSet<int>();

                foreach (string s in ar)
                {
                    h.Add(Convert.ToInt32(s));
                }
                 
                l.Add(h);
            }

            HashSet<int>[] l2 = l.ToArray<HashSet<int>>();

            for (int i = 1; i < l2.Length; i++)
            {
                l2[i].RemoveWhere(x => l2[i-1].Contains(x) == false);
            }

            foreach (int i in l2[l2.Length - 1].AsEnumerable<int>())
            {
                Console.WriteLine(i);
            }

            return;
        }
    }
}
