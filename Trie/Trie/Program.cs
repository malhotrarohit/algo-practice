using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Trie
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter strings to store in the trie");
            IList<string> input = new List<string>(); 
            string s;
            while (!string.IsNullOrWhiteSpace(s = Console.ReadLine()))
            {
                input.Add(s);
            }

            Trie t = new Trie();
            foreach (string str in input)
            {
                if (str.Contains(' '))
                {
                    string[] del = str.Split(' ');
                    foreach (string d in del)
                    {
                        t.Insert(d.ToCharArray());
                    }
                }
                else
                {
                    t.Insert(str.ToCharArray());
                }
            }

            t.Compress();

            Console.WriteLine("Enter strings to search in the trie");
            while (!string.IsNullOrWhiteSpace(s = Console.ReadLine()))
            {
                if (t.Search(s.ToCharArray()))
                {
                    Console.WriteLine("The string {0} is present in the trie", s);
                }
                else
                {
                    Console.WriteLine("The string is not present in the trie");
                }
            }
        }
    }
}
