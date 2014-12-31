using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NSquareSortingAlgorithms
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] A = { 1, 2, 10, 9, 8, 3, 4, 5, 7, 6 };
            Build_Heap(A);
            Heap_Sort(A);
        }

        static void PairSum(int[] A, int sum)
        {
            MergeSort(A, 0, A.Length-1);
            for (int i = 0; i < A.Length; i++)
            {
                if (BS(A, sum - A[i], 0, A.Length-1))
                {
                    Console.WriteLine(string.Format("The pair {0}, {1} has the sum {2}", sum-A[i], A[i]));
                }
            }
        }

        static bool BS(int[] A, int n, int low, int high)
        {
            if(high > low)
            {
                int i = 0;
                int mid = (low+high)/2;
                while(low < high){
                    if(A[i]<A[mid]){
                        high = mid;
                    }
                    else if(A[i]==A[mid]){
                        return true;
                    }
                    else{
                        low = mid+1;
                    }
                }
            }
            return false;
        }


        static void MergeSort(int[] A, int low, int high)
        {
            if (low == high)
            {
                return;
            }
            int mid = (low+high)/2;
            MergeSort(A, low, mid);
            MergeSort(A, mid + 1, high);
            Merge(A, low, mid, high);
        }

        static void Merge(int[] A, int low, int mid, int high)
        {
            int i = low, j = mid + 1;
            int[] B = new int[high - low + 1];
            int k = 0;
            while(i < mid+1 && j < high+1)
            {
                if (A[i] <= A[j])
                {
                    B[k] = A[i];
                    i++;
                }
                else
                {
                    B[k] = A[j];
                    j++;
                }
                k++;
            }
            if (i > mid)
            {
                while(j < high+1)
                {
                    B[k] = A[j];
                    j++;
                    k++;
                }
            }
            else
            {
                while(i < mid+1)
                {
                    B[k] = A[i];
                    i++;
                    k++;
                }
            }
            for (i = low,k=0; i < high + 1 && k < B.Length; i++,k++)
            {
                A[i] = B[k];
            }
        }

        static void Quicksort(int[] A, int low, int high)
        {
            if (low < high)
            {
                Random r = new Random();
                int pivot = r.Next(low, high);
                int index = Partition(A, low, high, pivot);
                Quicksort(A, low, index - 1);
                Quicksort(A, index + 1, high);
            }
        }

        static int Partition(int[] A, int low, int high, int pivot)
        {
            Swap(ref A[pivot], ref A[high]);
            int highIndex = 0;
            for (int i = 0; i < high; i++)
            {
                if (A[i] < A[high])
                {
                    Swap(ref A[i], ref A[highIndex]);
                    highIndex++;
                }
            }
            Swap(ref A[highIndex], ref A[high]);
            return highIndex;
        }

        static void Build_Heap(int[] A)
        {
            for (int i = 0; i < A.Length; i++) //build a max heap
            {
                Bubble_Up(A, i);
            }
        }

        static void Bubble_Up(int[] A, int index) //bubble up elements to create the heap
        {
            int parent;
            if (index > 0)
            {
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
                    Bubble_Up(A, parent);
                }
            }
        }

        static void Heap_Sort(int[] A) //swap front element of the list with rear & bubble the new element down to its proper place in the heap
        {
            for (int i = A.Length-1; i > 0; i--)
            {
                Swap(ref A[0], ref A[i]);
                Bubble_Down(A, 0);
            }
        }

        static void Bubble_Down(int[] A, int index)
        {
            int left = 2 * index + 1;
            int right = 2 * index + 2;
            int max = index;

            if (left < A.Length)
            {
                if (right < A.Length)
                {
                    if (A[left] > A[max])
                    {
                        max = left;
                    }
                    if (A[max] < A[right])
                    {
                        max = right;
                    }
                }
                else
                {
                    if (A[left] > A[index])
                    {
                        max = left;
                    }
                }
            }
            Swap(ref A[index], ref A[max]);
            if (max != index)
            {
                Bubble_Down(A, max);
            }
        }

        static void Swap(ref int a, ref int b)
        {
            int temp = a;
            a = b;
            b = temp;
        }

        static void Bubble_Sort(int[] A)
        {
            bool swap = true;
            int j = 0;
            while (swap)
            {
                swap = false;
                j++;
                for (int i = 0; i < A.Length - j; i++) //after every iteration of the for loop the largest element will be at the end
                {
                    if (A[i] > A[i + 1]) //keep swapping in pairs
                    {
                        Swap(ref A[i], ref A[i + 1]);
                        swap = true;
                    }
                }
            }
        }

        static void Insertion_Sort(int[] A)
        {
            for (int i=1; i<A.Length; i++)
            {
                int x = A[i];
                int j = i;
                while(j > 0 && x<A[j-1])
                {
                    A[j] = A[j-1];
                    j--;
                }
                A[j] = x;
            }
        }

        static void Selection_Sort(int[] A)
        {
            int i = 0;

            while (i < A.Length)
            {
                int index = i;
                for (int j = i + 1; j < A.Length; j++)
                {
                    if(A[index] > A[j])
                    {
                        index = j; 
                    }
                }
                Swap(ref A[i], ref A[index]);
                i++;
            }
        }
    }
}
