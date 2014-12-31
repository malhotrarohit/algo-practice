using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BalancedBinaryTree
{
    class BinarySearchTree
    {
        private Node root = null;
        private List<Node> traversal = new List<Node>();
        private int count = 0;

        public void Print()
        {
            Console.WriteLine("Root : {0}", this.Root);
            if (traversal == null || traversal.Count == 0)
            {
                Inorder();
            }
            foreach (Node n in traversal)
            {
                Console.Write("{0} ", n.item);
            }
        }

        public bool IsEqual(BinarySearchTree tree)
        {
            return CompareInternal(tree.root, this.root);
        }

        private bool CompareInternal(Node a, Node b)
        {
            if (a == null && b == null)
            {
                return true;
            }

            return (a.item == b.item) && CompareInternal(a.left, b.left) && CompareInternal(a.right, b.right);
        }

        public Node KthSmallest(int k)
        {
            Node n = root;
            if (k > count || k < 1)
            {
                return null;
            }
            while (n != null)
            {
                if (n.leftNum >= k)
                {
                    n = n.left;
                }
                else if (n.leftNum + 1 == k)
                {
                    return n;
                }
                else
                {
                    k = k - n.leftNum - 1;
                    n = n.right;
                }
            }
            return null;
        }

        public int Root
        {
            get
            {
                return root!= null ? root.item : Int32.MinValue;
            }
        }

        public void Insert(int i)
        {
            Node n = SearchInternally(i, root, root);
            if (n!= null && n.item == i)
            {
                throw new Exception("Duplicate key inserted");
            }
            else
            {
                Node latest = new Node(i);
                latest.left = null;
                latest.right = null;
                latest.parent = n;
                if (n == null)
                {
                    root = new Node(i);
                    root.left = null;
                    root.right = null;
                    count++;
                    return;
                }
                else if (n.item < i)
                {
                    n.right = latest;
                }
                else
                {
                    n.left = latest;
                }
                count++;
            }

            UpdateLeftRightCount(i);
        }

        private void UpdateLeftRightCount(int i)
        {
            Node n = root;
            while (n != null && n.item != i)
            {
                if (i < n.item)
                {
                    n.leftNum++;
                    n = n.left;
                }
                else 
                {
                    n.rightNum++;
                    n = n.right;
                }
            }
        }

        public void Clear()
        {
            root = null;
            count = 0;
        }

        public Node BalanceTree()
        {
            Inorder();
            Node[] arrayOfNodes = traversal.ToArray();
            BalanceTreeInternal(arrayOfNodes);
            root = arrayOfNodes[arrayOfNodes.Length / 2];
            return root;
        }

        private Node BalanceTreeInternal(Node[] nodes)
        {
            if (nodes.Length == 0)
            {
                return null;
            }
            else if (nodes.Length == 1)
            {
                return nodes[0];
            }
            int mid = nodes.Length / 2 ;
            Node[] leftSubtree = new Node[mid];
            Node[] rightSubtree = new Node[nodes.Length - mid-1];

            for(int i=0;i<mid; i++)
            {
                leftSubtree[i] = nodes[i];
            }
            for(int i=mid+1; i<nodes.Length;i++)
            {
                rightSubtree[i-mid-1] = nodes[i];
            }
            nodes[mid].left = BalanceTreeInternal(leftSubtree);
            if (nodes[mid].left != null) { nodes[mid].left.parent = nodes[mid]; }
            nodes[mid].right = BalanceTreeInternal(rightSubtree);
            if (nodes[mid].right != null) { nodes[mid].right.parent = nodes[mid]; } 
            return nodes[mid];
        }

        public void Delete(int i)
        {
            if (root == null)
            {
                throw new Exception("The tree is empty!");
            }
            Node n = SearchInternally(i, root, root);
            if (n == null || n.item != i)
            {
                throw new Exception("The element to be deleted was not found!");
            }

            Node child = n;
            while(child != root)
            {
                Node parent = child.parent;
                if(parent.left != null && parent.left.item == child.item)
                {
                    parent.leftNum --;
                }
                else{
                    parent.rightNum --;
                }
                child = parent;
            }

            Node successor = FindSuccessor(n);

            //House keeping for the successor (children and parent)
            if (successor != null)
            {
                if (successor.item == n.right.item)
                {
                    successor.left = n.left;
                    successor.leftNum = n.leftNum;
                    successor.rightNum = n.rightNum--;
                    if (n.left != null)
                    {
                        n.left.parent = successor;
                    }
                }
                else if (successor.item == n.left.item)
                {
                    ;
                }
                else
                {
                    successor.parent.left = successor.right;
                    successor.parent.leftNum = 0;
                    if (successor.right != null)
                    {
                        successor.parent.leftNum = successor.right.leftNum + successor.right.rightNum;
                        successor.right.parent = successor.parent;
                    }
                    successor.leftNum = n.leftNum;
                    successor.rightNum = n.rightNum--;
                }
                successor.parent = n.parent;
            }

            //Assign the successor to deleted node's parent
            if (n.parent != null)
            {
                if (n.parent.left != null && n.parent.left.item == n.item)
                {
                    n.parent.left = successor;
                }
                else
                {
                    n.parent.right = successor;
                }
            }
            else
            {
                root = successor;
            }
            count--;
            
        }

        public Node FindSuccessor(Node n)
        {
            if (n.left == null && n.right == null)
            {
                return null;
            }
            else if (n.left == null || n.right == null)
            {
                return n.left == null ? n.right : n.left;
            }
            else
            {
                Node temp = n.right;
                while (temp.left != null)
                {
                    temp = temp.left;
                }
                return temp;
            }
        }

        public Node Search(int i)
        {
            Node n = SearchInternally(i, root, root);
            if (n != null && n.item == i)
            {
                return n;
            }
            else
            {
                return null;
            }
        }

        private Node SearchInternally(int i, Node root, Node parent)
        {
            if (root == null)
            {
                return parent;
            }
            else if (root.item == i)
            {
                return root;
            }
            else if (root.item > i)
            {
                return SearchInternally(i, root.left, root);
            }
            else if (root.item < i)
            {
                return SearchInternally(i, root.right, root);
            }
            return null;
        }

        public void Inorder()
        {
            traversal.Clear();
            if (root == null)
            {
                throw new Exception("The tree is empty!");
            }
            InorderInternal(root);
        }

        private void InorderInternal(Node n)
        {
            if (n == null)
            {
                return;
            }
            InorderInternal(n.left);
            traversal.Add(n);
            InorderInternal(n.right);
        }

        public void Preorder()
        {
            traversal.Clear();
            if (root == null)
            {
                throw new Exception("The tree is empty!");
            }
            PreorderInternal(root);
        }

        private void PreorderInternal(Node n)
        {
            if (n == null)
            {
                return;
            }
            traversal.Add(n);
            PreorderInternal(n.left);
            PreorderInternal(n.right);
        }

        public void Postorder()
        {
            traversal.Clear();
            if (root == null)
            {
                throw new Exception("The tree is empty!");
            }
            PostorderInternal(root);
        }

        public void PostorderInternal(Node n)
        {
            if (n == null)
            {
                return;
            }
            PostorderInternal(n.left);
            PostorderInternal(n.right);
            traversal.Add(n);
        }
    }
}
