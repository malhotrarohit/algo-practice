using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Trie
{
    class Trie
    {
        private Node root;
        private int count;
        private bool isCompressed;

        public Trie()
        {
            root = new Node('\0');
            count = 0;
            isCompressed = false;
        }

        public int Count
        {
            get
            {
                return count;
            }
        }

        private short charToInt(char c)
        {
            return (short) (Convert.ToInt16(c) - Convert.ToInt16('a'));
        }

        public void Insert(char[] str)
        {
            if (isCompressed)
            {
                throw new Exception("Can't insert strings in a compressed trie");
            }
            Node n = root;
            bool isNew = false;
            foreach(char c in str)
            {
                short i = charToInt(c);
                if(n.children[i] == null)
                {
                    n.children[i] = new Node(c);
                    n.count++;
                    isNew = true;
                }
                n = n.children[i];
            }
            if(isNew) count++;
        }

        public bool Search(char[] str)
        {
            if (str.Length == 0) return true;
            Node n = root;
            for (int j = 0; j < str.Length; j++)
            {
                if (n.isCompressed)
                {
                    string s = "";
                    for (int k = j; k < str.Length; k++)
                    {
                        s = s + str[k];
                    }
                    if (new string(n.chars.ToArray<char>()).IndexOf(s, StringComparison.CurrentCultureIgnoreCase) != -1)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    short i = charToInt(str[j]);
                    if (n.children[i] == null)
                    {
                        return false;
                    }
                    n = n.children[i];
                }
            }

            return true;
        }

        public void Compress()
        {
            if (count > 0)
            {
                CompressInternal(root);
            }
        }

        private List<char> CompressInternal(Node root)
        
        {
            if (root.count == 0)
            {
                return root.chars;
            }
            foreach (Node n in root.children)
            {
                if (n != null)
                {
                    List<char> chars = CompressInternal(n);
                    if (root.c !='\0' && root.count == 1)
                    {
                        if (chars != null)
                        {
                            root.chars.AddRange(chars);
                            root.children = null;
                            root.isCompressed = true;
                            return root.chars;
                        }
                    }
                }
            }

            return null;
        }
    }
}
