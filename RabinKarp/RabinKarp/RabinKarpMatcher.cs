using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RabinKarp
{
    class RabinKarpMatcher
    {
        public int Find(string pattern, string text) 
        {
            long hash = 0;
            long patternHash = Hash(pattern);
            for (int i = 0; i < text.Length - pattern.Length + 1; i++)
            {
                if (i == 0) { hash = Hash(text.Substring(i, pattern.Length)); }
                else{hash = (hash - (long)(Convert.ToInt16(text.ElementAt(i-1))*Math.Pow(10.0, pattern.Length - 1)))*10 + Convert.ToInt16(text.ElementAt(i+pattern.Length - 1));}
                if (hash == patternHash) { return i; }
            }
            return -1;
        }

        public long Hash(string input)
        {
            short[] ints = new short[input.Length];

            for(int i=0; i<ints.Length; i++)
            {
                ints[i] = Convert.ToInt16(input.ElementAt(i));
            }

            double hash = 0;
            double pow = 0.0;
            for (int i = ints.Length - 1; i >= 0; i--)
            {
                hash += Math.Pow(10.0, pow) * ints[i];
                pow++;
            }

            return Convert.ToInt64(hash);
        }
    }
}
