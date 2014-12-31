using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Trie
{
    class Node
    {
        public char c;
        public int count;
        public Node[] children;
        public bool isCompressed;
        public List<char> chars;

        public Node(char c1)
        {
            c = c1;
            children = new Node[26];
            count = 0;
            isCompressed = false;
            chars = new List<char>() { c };
        }
    }

}
