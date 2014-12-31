using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SetIntersections
{
    class Program
    {
        struct Node
        {
            public int value;
            public bool type;
            public int index;
            public int counterpart;

            public static bool operator <(Node n1, Node n2){
                if (n1.value < n2.value)
                {
                    return true;
                }
                else if (n1.value == n2.value)
                {
                    if (n1.type == false && n2.type == true)
                    {
                        return true;
                    }
                    if (n1.type == true && n2.type == false)
                    {
                        return false;
                    }
                    if (n1.type == n2.type)
                    {
                        return n1.counterpart < n2.counterpart;
                    }
                }
                return false;
            }
            public static bool operator >(Node n1, Node n2)
            {
                if (n1.value > n2.value)
                {
                    return true;
                }
                else if (n1.value == n2.value)
                {
                    if (n1.type == true && n2.type == false)
                    {
                        return true;
                    }
                    if (n1.type == false && n2.type == true)
                    {
                        return false;
                    }
                    if (n1.type == n2.type)
                    {
                        return n1.counterpart > n2.counterpart;
                    }
                }
                return false;
            }
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the intervals - {start time} {end time}");
            string input;
            List<Tuple<int, int>> intervals = new List<Tuple<int, int>>();
            while ((input = Console.ReadLine()) != "")
            {
                string[] splitInput = input.Split(' ');
                intervals.Add(new Tuple<int,int>(Convert.ToInt32(splitInput[0]), Convert.ToInt32(splitInput[1])));
            }

            Node[] times = new Node[intervals.Count * 2];
            int i = 0, j = 0;
            foreach (Tuple<int, int> t in intervals)
            {
                times[i].value = t.Item1;
                times[i].counterpart = t.Item2;
                times[i].index = j;
                times[i].type = false;
                i++;

                times[i].value = t.Item2;
                times[i].counterpart = t.Item1;
                times[i].index = j;
                times[i].type = true;
                i++;

                j++;
            }

            MergeSort(times);

            int[] C = new int[intervals.Count];
            int start = 0, end = 0;
            for (int k = 0; k < times.Length; k++)
            {
                if (!times[k].type)
                {
                    start++;
                    C[times[k].index] = end;
                }
                else
                {
                    end++;
                    C[times[k].index] = start - C[times[k].index] - 1;
                }
            }

            Console.WriteLine("The number of intervals with which the above given intervals intersect respectively are - ");
            foreach (int n in C)
            {
                Console.WriteLine(n);
            }

            return;
        }

        static void MergeSort(Node[] items)
        {
            Sort(items, 0, items.Length - 1);
        }

        static void Sort(Node[] items, int low, int high)
        {
            int mid = (low + high) / 2;
            if (low < high)
            {
                Sort(items, low, mid);
                Sort(items, mid + 1, high);
            }

            Merge(items, low, mid, high);
        }

        static void Merge(Node[] items, int low, int mid, int high)
        {
            List<Node> temp = new List<Node>();
            int i = low, j = mid+1;
           
            while(i < mid + 1 && j < high + 1)
            {
                if ( items[i] < items[j])
                {
                    temp.Add(items[i++]);
                }
                else
                {
                    temp.Add(items[j++]);
                }
            }

            while (i < mid + 1)
            {
                temp.Add(items[i++]);
            }

            while (j < high + 1)
            {
                temp.Add(items[j++]);
            }

            int k = low;
            foreach (Node n in temp)
            {
                items[k++] = n;
            }
        }
    }
}
