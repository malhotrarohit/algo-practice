using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Quicksort
{
    class Qsort
    {
        public void Sort(int[] list, int low,int high)
        {
            if (low < high)
            {
                int p = Partition(list, low, high);

                Sort(list, low, p - 1);
                Sort(list, p + 1, high);
            }
        }

        private int Partition(int[] list, int low, int high)
        {
            var rand = new Random();
            var pivot = rand.Next(low, high+1);
            var pivotValue = list[pivot];
            Swap(ref list[pivot], ref list[high]);
            int highIndex = low;
            for (int i = low; i < high; i++)
            {
                if (list[i] < pivotValue)
                {
                    Swap(ref list[i], ref list[highIndex]);
                    highIndex++;
                }
            }
            Swap(ref list[highIndex], ref list[high]);
            return highIndex;
        }

        private void Swap(ref int a, ref int b)
        {
            int temp;
            temp = a;
            a = b;
            b = temp;
        }
    }
}
