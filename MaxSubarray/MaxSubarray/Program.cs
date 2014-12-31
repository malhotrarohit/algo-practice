using System;
using System.Collections.Generic;
using System.IO;
class Solution
{
    static void Main(String[] args)
    {
        /* Enter your code here. Read input from STDIN. Print output to STDOUT. Your class should be named Solution */
        int T = Convert.ToInt32(Console.ReadLine());
        while (T != 0)
        {
            string[] input = Console.ReadLine().Split(' ');
            int[] A = new int[input.Length];
            for (int i = 0; i < input.Length; i++)
            {
                A[i] = Convert.ToInt32(input[i]);
            }
            Console.WriteLine(string.Format("{0} {1}", ContigousSum(A), NonContigousSum(A)));
            T--;
        }
        /*
        Scanner in = System.in;
        int num = in.nextInt()
        String stringInput = in.nextString()
        */
    }

    static int ContigousSum(int[] A)
    {
        int maxSum = A[0];
        int maxElement = A[0];
        for (int i = 1; i < A.Length; i++)
        {
            maxSum = Math.Max(A[i], A[i] + maxSum);
            maxElement = Math.Max(maxSum, maxElement);
        }
        return maxElement;
    }

    static int NonContigousSum(int[] A)
    {
        int sum = 0, max = Int32.MinValue;
        for (int j = 0; j < A.Length; j++)
        {
            if (A[j] > max) { max = A[j]; }
        }
        if (max < 0) return max;
        else
        {
            for (int i = 0; i < A.Length; i++)
            {
                if (A[i] > 0)
                {
                    sum += A[i];
                }
            }
            return sum;
        }
    }
}