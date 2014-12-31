using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CryptKicker
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = Convert.ToInt32(Console.ReadLine());
            string[] dict = new string[n];
            int maxLen=0;
            while (n != 0)
            {
                if((dict[dict.Length - n] = Console.ReadLine()).Length > maxLen){
                    maxLen = dict[dict.Length - n].Length;
                }
                n--;
            }
            
            IList<string> encryptedLines = new List<string>();
            string input;
            while((input = Console.ReadLine()) != " ")
            {
                encryptedLines.Add(input);
            }

            Decrypter dc = new Decrypter(dict, maxLen);
            dc.Decrypt(encryptedLines);
        }
    }
}
