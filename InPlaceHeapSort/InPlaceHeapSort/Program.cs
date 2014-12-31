using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InPlaceHeapSort
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] A = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            Heapify(A); // create a max heap
            Sort(A); // remove max element and place it at the end (repeat for all elements)
            return;
        }

        static void Sort(int[] A)
        {
            for (int i = A.Length - 1; i > 0; i--)
            {
                Swap(ref A[0], ref A[i]);
                Bubble_Down(0,A, i-1);
            }
        }

        static void Bubble_Down(int index, int[] A, int high)
        {
            if (2 * index + 1 > high) return;
            if (2 * index + 2 > high)
            {
                if (A[index] < A[2 * index + 1]) { Swap(ref A[index], ref A[2 * index + 1]); index = 2 * index + 1; Bubble_Down(index, A, high); }
            }
            else
            {
                int i = (A[2 * index + 1] > A[2*index +2])?2*index+1:2*index+2;
                if (A[index] < A[i])
                {
                    Swap(ref A[index], ref A[i]);
                    index = i;
                    Bubble_Down(index, A, high);
                }
            }
        }

        static void Heapify(int[] A)
        {
            for (int i = 0; i < A.Length; i++)
            {
                Bubble_Up(i, A);
            }
        }

        static void Bubble_Up(int index, int[] A)
        {
            if (index == 0) return;
            int parent;
            if (index % 2 == 0)
            {
                parent = (index - 2) / 2;
            }
            else
            {
                parent = (index - 1) / 2;
            }
            if (A[parent] < A[index])
            {
                Swap(ref A[parent], ref A[index]);
                index = parent;
                Bubble_Up(index, A);
            }
        }

        static void Swap(ref int a, ref int b)
        {
            int temp;
            temp = a;
            a = b;
            b = temp;
        }

    }
}
