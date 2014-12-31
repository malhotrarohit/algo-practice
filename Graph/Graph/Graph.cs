using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Graph
{
    class Edge
    {
        private int _id; //adjacency info
        private Edge _next; //next edge in the list
        private int _weight; //edge weight, if any

        public int Id
        {
            get
            {
                return _id;
            }
            set
            {
                _id = value;
            }
        }

        public Edge Next
        {
            get
            {
                return _next;
            }
            set
            {
                _next = value;
            }
        }

        public int Weight
        {
            get
            {
                return _weight;
            }
            set
            {
                _weight = value;
            }
        }
    }

    enum State{
        Undiscovered,
        Discovered,
        Processed
    }

    class Graph
    {
        private Edge[] _edges;
        private int[] _degree;
        private int _numEdges;
        private int _numVertices;
        private int _counter;
        private bool _directed;
        private int _maxCount;
        private int _time;

        public Graph(bool directed, int maxCount)
        {
            _edges = new Edge[maxCount];
            _degree = new int[maxCount];
            _numEdges = 0;
            _numVertices = 0;
            _counter = -1;
            _directed = directed;
            _maxCount = maxCount;
            _time = 0;
        }

        public void InsertEdge(int x, int y, int weight)
        {
            if(x <= _counter && y <= _counter)
            {
                Edge e1 = new Edge();
                e1.Id = y;
                e1.Next = _edges[x];
                e1.Weight = weight;
                _edges[x] = e1;

                if(!_directed)
                {
                    Edge e2 = new Edge();
                    e2.Id = x;
                    e2.Next = _edges[y];
                    e2.Weight = weight;
                    _edges[y] = e2;
                }

                _numEdges++;
            }
            else{
                throw new Exception("The node(s) specified don't exist");
            }
        }

        public void InsertVertex()
        {
            if (_numVertices < _maxCount)
            {
                _numVertices++;
                _counter = _numVertices - 1;
            }
            else
            {
                throw new Exception("The graph is out of storage!");
            }
        }

        public void Print()
        {
            if (_directed) { Console.WriteLine("The graph is directed."); }
            else { Console.WriteLine("The graph is undirected."); }

            for (int i = 0; i < _numVertices; i++)
            {
                Console.Write("The vertices adjacent to {0} are - ", i);
                Edge list = _edges[i];
                while (list != null)
                {
                    Console.Write(list.Id);
                    Console.Write(" ");
                    list = list.Next;
                }
                Console.WriteLine();
            }
        }

        private void InitializeStates(State[] state)
        {
            for (int i = 0; i < state.Length; i++)
            {
                state[i] = State.Undiscovered;
            }
        }

        private void InitializeParents(int[] parent)
        {
            for (int i = 0; i < parent.Length; i++)
            {
                parent[i] = -1;
            }
        }

        public void Bfs()
        {
            if (_maxCount < 1) throw new Exception("Can't traverse an empty graph!");

            State[] state = new State[_numVertices];
            InitializeStates(state);

            int[] parent = new int[_numVertices];
            InitializeParents(parent);

            Queue<int> nodes = new Queue<int>();

            for (int i = 0; i < _numVertices; i++)
            {
                if (state[i] == State.Undiscovered)
                {
                    nodes.Enqueue(i);
                    while (nodes.Count > 0)
                    {
                        int node = nodes.Dequeue();
                        state[node] = State.Discovered;
                        Edge edge = _edges[node];
                        Console.WriteLine(node);

                        while (edge != null)
                        {
                            if (state[edge.Id] == State.Undiscovered)
                            {
                                state[edge.Id] = State.Discovered;
                                parent[edge.Id] = node;
                                nodes.Enqueue(edge.Id);
                            }
                            edge = edge.Next;
                        }
                        state[node] = State.Processed;
                    }
                }
            }
        }

        public void Dfs()
        {
            int[] start = new int[_numVertices];
            int[] end = new int[_numVertices];
            int[] parent = new int[_numVertices];
            State[] state = new State[_numVertices];
            _time = 0;

            for (int i = 0; i < _numVertices; i++)
            {
                if (state[i] == State.Undiscovered)
                {
                    DfsInternal(i, start, end, parent, state);
                }
            }
        }

        private void DfsInternal(int node, int[] start, int[] end, int[] parent, State[] state)
        {
            start[node] = _time;
            state[node] = State.Discovered;
            Edge e =_edges[node];
            Console.WriteLine(node);

            while (e != null) {
                if (state[e.Id] == State.Undiscovered)
                {
                    ++_time;
                    parent[e.Id] = node;
                    DfsInternal(e.Id, start, end, parent, state);
                }
                e = e.Next;
            }
            ++_time;
            state[node] = State.Processed;
            end[node] = _time;
        }

        public void Scc()
        {
            int[] earliestAncestor = new int[_numVertices];
            State[] state = new State[_numVertices];
            int[] start = new int[_numVertices];
            Stack<int> s = new Stack<int>();
            InitializeStates(state);
            _time = 0;

            for(int i =0; i< _numVertices; i++)
            {
                if (state[i] == State.Undiscovered)
                {
                    SccInternal(i, earliestAncestor, state, start, s);
                }
            }
        }

        private void SccInternal(int node, int[] ea, State[] state, int[] start, Stack<int> s)
        {
            start[node] = ea[node] = _time;
            s.Push(node);
            state[node] = State.Discovered;
            ++_time;

            Edge e = _edges[node];
            while (e != null)
            {
                if (state[e.Id] == State.Undiscovered)
                {
                    SccInternal(e.Id, ea, state, start, s);
                    ea[node] = Math.Min(ea[node], ea[e.Id]);
                }
                else if (s.Contains<int>(e.Id))
                {
                    ea[node] = Math.Min(ea[node], start[e.Id]);
                }
            }

            state[node] = State.Processed;
            if (ea[node] == start[node])
            {
                while (true)
                {
                    int n = s.Pop();
                    Console.WriteLine(n);
                    if (n == node) break;
                }
                Console.WriteLine();
            }
        }
    }
}
