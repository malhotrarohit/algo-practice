using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BalancedBinaryTree
{
    class Node
    {
        public int item;
        public Node(int i)
        {
            this.item = i;
        }
        public Node left;
        public Node right;
        public Node parent;
        public int leftNum;
        public int rightNum;
    }
}
