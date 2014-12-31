using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BinarySearchTree
{
    class BinarySearchTree
    {
        private Node root;
        public void Insert(int i)
        {
            if (root == null)
            {
                root = new Node();
                root.item = i;
                root.left = null;
                root.right = null;
                root.leftNum = 0;
                root.rightNum = 0;
            }
            Node n = root;
            Node temp;
            while (n != null)
            {
                temp = n;
                if (i > n.item)
                {
                    n = n.right;
                }
                else if (i < n.item)
                {
                    n = n.left;
                }
            }
        }
    }
}                                                               
