using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreeFromTraversal
{
    class Program 
    {
        class Node
        {
            public char item;
            public Node left;
            public Node right;
        }

        static Node root = null;

        static void Main(string[] args)
        {
            List<char> preorder = Console.ReadLine().ToList<char>();
            List<char> inorder = Console.ReadLine().ToList<char>();

            root = Build(preorder, inorder);
        }
        static Node Build(List<char> preorder, List<char> inorder)
        {
            if (preorder.Count < 1 || inorder.Count < 1)
            {
                return null;
            }
            char c = preorder.ElementAt(0);
            int index = inorder.FindIndex(x => x == c);

            Node node = null;

            if (index != -1)
            {
                node = new Node();
                node.item = inorder.ElementAt(0);
                List<char> left_subtree = inorder.GetRange(0, index);
                List<char> right_subtree = inorder.GetRange(index + 1, inorder.Count - index - 1);
                preorder.Remove(c);
                node.left = Build(preorder, left_subtree);
                node.right = Build(preorder, right_subtree);
            }

            return node;
        }
    }
}
