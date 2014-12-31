using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RedBlackTree
{
    class Node
    {
        public int item;
        public bool color;
        public Node parent;
        public Node left;
        public Node right;

        public Node(int n)
        {
            item = n;
            color = true;
            parent = null;
            left = null;
            right = null;
        }
    }
    class RedBlackTree
    {
        private Node root;
        private int count;
        private Node sentinel;

        public RedBlackTree()
        {
            count = 0;
            sentinel = new Node(Int32.MinValue);
            sentinel.left = null;
            sentinel.right = null;
            sentinel.parent = null;
            sentinel.color = false;
            root = sentinel;
        }

        public int Count
        {
            get
            {
                return count;
            }
        }

        public void Insert(int value)
        {
            if (root == sentinel)
            {
                root = new Node(value);
                root.left = sentinel;
                root.right = sentinel;
                root.color = false;
                return;
            }

            Node n = root;
            Node parent = n;   
            while (n != sentinel)
            {
                parent = n;
                if (value < n.item)
                {
                    n = n.left;
                }
                else if (value > n.item)
                {
                    n = n.right;
                }
                else
                {
                    throw new Exception(string.Format("The item {0} is already there in this binary search tree", value));
                }
            }

            Node toBeInserted = new Node(value);
            if (value < parent.item) { parent.left = toBeInserted; }
            else { parent.right = toBeInserted; }
            toBeInserted.parent = parent;

            Insert_Case2(toBeInserted);
        }

        public bool Search(int value)
        {
            Node n = root;
            while (n!=null && n.item != value)
            {
                if(value < n.item)
                {
                    n = n.left;
                }
                else{
                    n = n.right;
                }
            }
            if(n == null)
            {
                return false;
            }
            else{
                return true;
            }
        }

        private void Insert_Case2(Node n)
        {
            if(n.parent.color == false)
            {
                return;
            }
            else{
                Insert_Case3(n);
            }
        }

        private Node Uncle(Node n)
        {
            if (n.parent.parent != null)
            {
                return (n.parent.parent.left == n.parent) ? n.parent.parent.right : n.parent.parent.left;
            }
            return null;
        }

        private void Insert_Case3(Node n)
        {
            Node u = Uncle(n);
            if(u != null) {
                if (u != sentinel && u.color == true)
                {
                    n.parent.color = false;
                    u.color = false;
                    n.parent.parent.color = true;
                    if (n.parent.parent == root)
                    {
                        n.parent.parent.color = false;
                        return;
                    }
                    else
                    {
                        Insert_Case2(n.parent.parent);
                    }
                }
                else
                {
                    Insert_Case4(n); //the rotations!
                }
            }
        }

        private void left_rotate(Node n)
        {
            if (n.parent == null) return;
            Node g = n.parent.parent;
            if(g!= null) 
            {
                if(g.left == n.parent){
                    g.left = n;
                }
                else{
                    g.right = n;
                }
            }
            
            n.parent.right = n.left;
            n.left.parent = n.parent;
            n.left = n.parent;
            n.parent.parent = n;
            n.parent = g;
        }

        private void right_rotate(Node n)
        {
            if (n.parent == null) return;
            Node g = n.parent.parent;
            if (g != null)
            {
                if (g.left == n.parent)
                {
                    g.left = n;
                }
                else
                {
                    g.right = n;
                }
            }

            n.parent.left = n.right;
            n.right.parent = n.parent;
            n.right = n.parent;
            n.parent.parent = n;
            n.parent = g;
        }

        private void Insert_Case4(Node n)
        {
            Node g = n.parent.parent.parent;
            if (n.parent.right == n && g.left == n.parent)
            {
                n = n.left;
            }
            else if (n.parent.left == n && g.right == n.parent)
            {
                n = n.right;
            }
            Insert_Case5(n);
        }

        private void Insert_Case5(Node n)
        {
            Node g = n.parent.parent;
            g.color = true;
            n.parent.color = false;
            if (g.left == n.parent)
            {
                right_rotate(n.parent);
            }
            else
            {
                left_rotate(n.parent);
            } 
        }

    }
}
