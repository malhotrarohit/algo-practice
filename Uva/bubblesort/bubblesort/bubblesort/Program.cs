using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace sorting
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = { 5, 2, -2, 7, 1, 0, -1 };
            print(array);

            Console.Write("\nSelection Sort\n");
            selection_sort(array);
            print(array);

            Console.Write("\nInsertion Sort\n");
            insertion_sort(array);
            print(array);
        }

        static void print(int[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                Console.Write(array[i] + "\t");
            }
            Console.WriteLine();
        }

        static void insertion_sort(int[] array)
        {
            for (int i = 1; i < array.Length; i++)
            {
                int x = array[i];
                int j = i;
                while (j > 0 && array[j - 1] > x)
                {
                    array[j] = array[j - 1];
                    j--;
                }
                array[j] = x;
            }
        }

        static void selection_sort(int[] array)
        {
            for (int i = 0; i < array.Length-1; i++)
            {
                int iMin = i;
                int j = i+1;
                while (j < array.Length)
                {
                    if (array[iMin] > array[j])
                        iMin = j;
                    j++;
                }
                if(iMin != i)
                    swap(ref array[i], ref array[iMin]);
            }
        }

        static void swap(ref int i, ref int j)
        {
            int temp = i;
            i = j;
            j = temp;
        }
    }
}
