using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ParseStringToBinaryTree
{
    class Program
    {
        class Node
        {
            public char item;
            public Node left;
            public Node right;
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the pattern");
            Treeify(Console.ReadLine().ToCharArray());
        }
        static void Treeify(char[] s)
        {
            Node current = new Node();
            Node root = null;
            Node[] stack = new Node[s.Length];
            int j = 0;
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] == ',')
                {
                    current = stack[j-1].right; 
                }
                else if (s[i] == ')')
                {
                    stack[--j] = null;
                }
                else if (char.IsLetter(s[i]))
                {
                    if (i < s.Length && s[i + 1] == '(')
                    {
                        current.left = new Node();
                        current.right = new Node();
                        current.item = s[i];
                        if (root == null) root = current;
                        stack[j] = current;
                        current = current.left;
                        j++;
                    }
                    else
                    {
                        current.item = s[i];
                    }
                }
            }
        }
}
}
