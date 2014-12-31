using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AVLTree
{
    class AVL
    {
        class Node
        {
            public int item;
            public Node parent;
            public Node left;
            public Node right;

            public Node(int value)
            {
                item = value;
                parent = left = right = null;
            }
        }

        private Node root;
        private int count;

        public int Count
        {
            get
            {
                return count;
            }
        }

        public void Insert(int value)
        {
            if (root == null)
            {
                root = new Node(value);
                count = 0;
                return;
            }

            InsertInternal(root, value);
            count++;
        }

        private void InsertInternal(Node n, int value)
        {
            if (value < n.item)
            {
                if (n.left == null)
                {
                    n.left = new Node(value);
                    n.left.parent = n;
                    BalanceTreeOnInsertion(n.left, value);
                    return;
                }
                n = n.left;
            }
            else if (value > n.item)
            {
                if (n.right == null)
                {
                    n.right = new Node(value);
                    n.right.parent = n;
                    BalanceTreeOnInsertion(n.right, value);
                    return;
                }
                n = n.right;
            }
            else
            {
                throw new Exception(string.Format("The value {0} is already there in the tree", value));
            }

            InsertInternal(n, value);
        }

        public void Delete(int value)
        {
            if(root == null)
            {
                throw new Exception(string.Format("The tree is empty!"));
            }
            DeleteInternal(root, value);
            count--;
        }

        private void DeleteInternal(Node n, int value)
        {
            if (n == null)
            {
                throw new Exception("Value not found");
            }
            if (value == n.item)
            {
                ReplaceAndDelete(n);
                return;
            }
            else if (value < n.item)
            {
                n = n.left;
            }
            else
            {
                n = n.right;
            }

            DeleteInternal(n, value);
        }

        private void ReplaceAndDelete(Node n)
        {
            if (n.left == null && n.right == null)
            {
                if (n == root)
                {
                    root = null;
                    return;
                }
                if (n.item < n.parent.item)
                {
                    n.parent.left = null;
                }
                else
                { 
                    n.parent.right = null;
                }
                return;
            }

            Node s;
            if (n.right != null)
            {
                s = FindSuccessorRight(n);
                if (s.parent == n)
                {
                    if (n.left != null)
                    {
                        n.left.parent = s;
                    }
                    s.left = n.left;
                }
                else
                {
                    if (s.right != null)
                    {
                        s.right.parent = s.parent;
                    }
                    s.parent.left = s.right;
                    n.right.parent = s;
                    s.right = n.right;
                }
            }
            else
            {
                s = FindSuccessorLeft(n);
                if (s.parent == n)
                {
                    if (n.right != null)
                    {
                        n.right.parent = s;
                    }
                    s.right = n.right;
                }
                else
                {
                    if (s.left != null)
                    {
                        s.left.parent = s.parent;
                    }
                    s.parent.right = s.left;
                    n.left.parent = s;
                    s.left = n.left;
                }
            }
            BalanceTreeOnDeletion(s.parent);
            s.parent = n.parent;
            if (n == root)
            {
                root = s;
            }
            else
            {
                if (n == n.parent.left)
                {
                    n.parent.left = s;
                }
                else
                {
                    n.parent.right = s;
                }
            }
        }

        private Node FindSuccessorRight(Node n)
        {
            n = n.right;
            while (n.left != null)
            {
                n = n.left;
            }
            return n;
        }

        private Node FindSuccessorLeft(Node n)
        {
            n = n.left;
            while (n.right != null)
            {
                n = n.right;
            }
            return n;
        }

        private void BalanceTreeOnInsertion(Node n, int value)
        {
            int height = 0;
            while (n!= null && n.parent != null)
            {
                height++;
                if (n == n.parent.left) //climbing up via left branch
                {
                    if (Math.Abs(height - Height(n.parent.right) - 1) > 1) //check for imbalance in the parent
                    {
                        if (value < n.item) //left-left imbalance
                        {
                            right_rotate(n.parent);
                        }
                        else //left-right imbalance
                        {
                            left_rotate(n);
                            n = n.parent;
                            right_rotate(n.parent);
                        }
                    }
                }
                else //climbing up via right branch
                {
                    if (Math.Abs(height - Height(n.parent.left) - 1) > 1) //check for imbalance in the parent
                    {
                        if (value < n.item) //right-left imbalance
                        {
                            right_rotate(n);
                            n = n.parent;
                            left_rotate(n.parent);
                        }
                        else //right-right imbalance
                        {
                            left_rotate(n.parent);
                        }
                    }
                }

                n = n.parent;
            }
        }

        private void BalanceTreeOnDeletion(Node n)
        {
            while (n != null && n.parent != null)
            {
                int left = Height(n.left);
                int right = Height(n.right);

                if(left - right == 2)
                {
                    right_rotate(n);
                }
                else if (left - right == -2)
                {
                    left_rotate(n);
                }
                n = n.parent;
            }
        }

        private void left_rotate(Node n)
        {
            Node rightChild = n.right;

            if (rightChild.left != null) { rightChild.left.parent = n; }
            n.right = rightChild.left;
            rightChild.parent = n.parent;
            if (n.parent != null)
            {
                if (n == n.parent.left)
                {
                    n.parent.left = rightChild;
                }
                else
                {
                    n.parent.right = rightChild;
                }
            }
            rightChild.left = n;
            n.parent = rightChild;
            if (n == root)
            {
                root = rightChild; 
            }
        }

        private void right_rotate(Node n)
        {
            Node leftChild = n.left;

            if (leftChild.right != null) { leftChild.right.parent = n; }
            n.left = leftChild.right;
            leftChild.parent = n.parent;
            if (n.parent != null)
            {
                if (n == n.parent.left)
                {
                    n.parent.left = leftChild;
                }
                else
                {
                    n.parent.right = leftChild;
                }
            }
            leftChild.right = n;
            n.parent = leftChild;
            if (n == root)
            {
                root = leftChild;
            }
        }

        private int Height(Node n)
        {
            if (n == null)
            {
                return -1;
            }
            return Math.Max(Height(n.left), Height(n.right)) + 1;
        }

        public void Preorder()
        {
            PreorderInternal(root);
        }
        private void PreorderInternal(Node n)
        {
            if (n != null)
            {
                Console.WriteLine(n.item);
                PreorderInternal(n.left);
                PreorderInternal(n.right);
            }
        }

        public void Inorder()
        {
            InorderInternal(root);
        }
        private void InorderInternal(Node n)
        {
            if (n != null)
            {
                InorderInternal(n.left);
                Console.WriteLine(n.item);
                InorderInternal(n.right);
            }
        }

        public void Postorder()
        {
            PostorderInternal(root);
        }
        private void PostorderInternal(Node n)
        {
            if (n != null)
            {
                PostorderInternal(n.left);
                PostorderInternal(n.right);
                Console.WriteLine(n.item);
            }
        }
    }
}
