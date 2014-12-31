using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MergeSort
{
    class MergeSort
    {
        public void Sort(int[] A, int low, int high)
        {
            SortInternal(A, low, high);
        }

        private void SortInternal(int[] A, int low, int high)
        {
            if(low == high)
            {
                return;
            }

            int mid = (low + high) / 2;

            SortInternal(A, low, mid);
            SortInternal(A, mid + 1, high);
            MergeInternal(A, low, mid, high);
        }

        private void MergeInternal(int[] A, int low, int mid, int high)
        {
            int[] temp = new int[high - low + 1];
            int i=low,j=mid+1,k=0;
            while (i <= mid && j <= high && k < temp.Length)
            {
                if (A[i] <= A[j]) // <= to ensure stable sort
                {
                    temp[k++] = A[i++];
                }
                else
                {
                    temp[k++] = A[j++];
                }
            }
            if (i <= mid)
            {
                while(i<=mid && k<temp.Length)
                {
                    temp[k++]=A[i++];
                }
            }
            if (j <= high)
            {
                while (j <= high && k<temp.Length)
                {
                    temp[k++] = A[j++];
                }
            }

            for (int l = 0, m=low; l < temp.Length && m <= high; l++,m++)
            {
                A[m] = temp[l];
            }
        }
    }
}
