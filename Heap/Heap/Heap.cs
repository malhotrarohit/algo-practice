using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Heap
{
    class Heap
    {
        private int[] A;
        private int index;

        public Heap(int size)
        {
            A = new int[size];
            index = 0;
            for (int i = 0; i < A.Length; i++)
            {
                A[i] = int.MaxValue;
            }
        }

        public void BuildHeap(int[] s)
        {
            if (s.Length > A.Length)
            {
                throw new Exception("Array too large for the heap!");
            }
            index=0;
            for (int i = 0; i < s.Length; i++)
            {
                Insert(s[i]);
            }
        }

        public void Insert(int n)
        {
            if (index != A.Length - 1)
            {
                A[index] = n;
                BubbleUp(index);
                index++;
            }
        }

        private void BubbleUp(int ind)
        {
            if (ind == 0) return;
            if (ind % 2 != 0)
            {
                if (A[ind / 2] > A[ind])
                {
                    Swap(ref A[ind / 2], ref A[ind]);
                    BubbleUp(ind / 2);
                }
            }
            else
            {
                if (A[ind / 2 - 1] > A[ind])
                {
                    Swap(ref A[ind / 2 - 1], ref A[ind]);
                    BubbleUp(ind / 2 - 1);
                }
            }
        }

        private void Swap(ref int a, ref int b)
        {
            int temp = a;
            a = b;
            b = temp;
        }

        public int ExtractMin()
        {
            int a = A[0];
            Swap(ref A[0], ref A[index]);
            index--;
            BubbleDown(0);
            return a;
        }

        private void BubbleDown(int ind)
        {
            if(2*ind + 1 > index){
                return;
            }
            int minChild;
            if (2 * ind + 2 < index)
            {
                minChild = A[2 * ind + 1] > A[2 * ind + 2] ? 2 * ind + 2 : 2 * ind + 1;
            }
            else
            {
                minChild = 2 * ind + 1;
            }

            if(A[ind]>A[minChild])
            {
                Swap(ref A[ind], ref A[minChild]);
                BubbleDown(minChild);
            }
        }

        public int Peek()
        {
            return A[0];
        }
    }
}
