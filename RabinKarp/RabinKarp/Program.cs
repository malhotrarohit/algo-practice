using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RabinKarp
{
    class Program
    {
        static void Main(string[] args)
        {
            RabinKarpMatcher rbk = new RabinKarpMatcher();
            Console.WriteLine("Enter the text ");
            string text = Console.ReadLine();
            Console.WriteLine("Enter the pattern ");
            string pattern = Console.ReadLine();

            int index = rbk.Find(pattern, text);
        }
    }
}
