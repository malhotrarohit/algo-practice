using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CartesianTree
{
    class CartesianTree
    {
        private Node[] _nodes;

        public void Create(int[] items)
        {
            _nodes = new Node[items.Length];

            for (int i = 0; i < items.Length; i++)
            {
                _nodes[i] = new Node();
                _nodes[i].item = items[i];
                _nodes[i].left = null;
                _nodes[i].right = null;
                _nodes[i].parent = null;
            }

            Stack<Node> lifo = new Stack<Node>();
            for (int i = 0; i < _nodes.Length; i++)
            {
                Node n = null;
                while (lifo.Count > 0 && lifo.Peek().item > _nodes[i].item)
                {
                    n = lifo.Pop();
                }

                if (n != null)
                {
                    _nodes[i].parent = n.parent;
                    if (n.parent != null) {
                        if (n.parent.left == n) { n.parent.left = _nodes[i]; } 
                        else {n.parent.right = _nodes[i];} 
                    }
                    n.parent = _nodes[i];
                    _nodes[i].left = n; 
                }
                else{
                    if(lifo.Count > 0){
                        Node o = lifo.Peek();
                        _nodes[i].parent = o;
                        if (o.right != null)
                        {
                            o.right.parent = _nodes[i];
                        }
                        o.right = _nodes[i];
                    }
                }

                lifo.Push(_nodes[i]);
            }
        }

        public int RangeMiniumum(int i, int j)
        {
            Dictionary<int, int> tree = new Dictionary<int, int>();
            if ((i > 0 && i < _nodes.Length) || (j > 0 && j < _nodes.Length))
            {
                Node n = _nodes[i];
                Node m = _nodes[j];
                Node commonAncestor = new Node();
                while (n != null)
                {
                    if (n != null) tree.Add(n.item, 0);
                    n = n.parent;
                }
                while (m != null)
                {
                    if (m != null && tree.ContainsKey(m.item))
                    {
                        commonAncestor = m;
                        break;
                    }
                    m = m.parent;
                }
               
                return commonAncestor.item;
            }
            else
            {
                return Int32.MinValue;
            }
        }
    }
}
