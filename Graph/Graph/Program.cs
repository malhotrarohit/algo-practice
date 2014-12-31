using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Graph
{
    class Program
    {
        static void Main(string[] args)
        {
            Graph g = new Graph(true, 1000);
            for (int i = 0; i < 5; i++)
            {
                g.InsertVertex();
            }
            g.InsertEdge(1, 0, 1);
            g.InsertEdge(0, 2, 1);
            g.InsertEdge(2, 1, 1);
            g.InsertEdge(0, 3, 1);
            g.InsertEdge(3, 4, 1);

            g.Print();

            Console.WriteLine("The BFS of above graph is - ");
            g.Bfs();

            Console.WriteLine("Depth first search - ");
            g.Dfs();

            Console.WriteLine("The strongly connected components of this graph are - ");
            g.Scc();
        }
    }
}
