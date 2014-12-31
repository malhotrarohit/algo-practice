using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WheresWaldorf
{
    class Program
    {
        static IDictionary<char, List<Tuple<int, int>>> loc = new Dictionary<char, List<Tuple<int, int>>>();

        static void Main(string[] args)
        {
            string[] matrixDims = Console.ReadLine().Split(' ');
            int rows = Convert.ToInt32(matrixDims[0]);
            int cols = Convert.ToInt32(matrixDims[1]);
            char[,] matrix = new char[rows, cols];

            for (int i = 0; i < rows; i++)
            {
                char[] arr = Console.ReadLine().ToCharArray();
                for (int j = 0; j < cols; j++)
                {
                    matrix[i,j] = arr[j];
                }
            }

            Preprocess(matrix);

            int numStrings = Convert.ToInt32(Console.ReadLine());
            string[] inputStr = new string[numStrings];
            for (int i = 0; i < numStrings; i++)
            {
                inputStr[i] = Console.ReadLine();
            }

            foreach (string str in inputStr)
            {
                List<Tuple<int,int>> coordinates = FindWaldorf(str, matrix);
                foreach (Tuple<int,int> t in coordinates)
                {
                    Console.WriteLine("{0} {1}", t.Item1, t.Item2);
                }
            }
        }

        static void Preprocess(char[,] matrix)
        {
            int row = matrix.GetLength(0), col = matrix.GetLength(1);
            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < col; j++)
                {
                    char c = Char.ToLower(matrix[i, j]);
                    if (!loc.ContainsKey(c))
                    {
                        loc.Add(c, new List<Tuple<int, int>>() { new Tuple<int, int>(i, j) });
                    }
                    else
                    {
                        loc[c].Add(new Tuple<int, int>(i, j));
                    }
                }
            }
        }

        static List<Tuple<int,int>> FindWaldorf(string str, char[,] matrix)
        {
            List<Tuple<int, int>> coordinates = new List<Tuple<int, int>>();
            foreach (Tuple<int, int> t in loc[Char.ToLower(str.ElementAt(0))])
            {
                if (isWaldorfThere(t, str.ToCharArray(), matrix))
                {
                    coordinates.Add(t);
                }
            }
            return coordinates;
        }

        static bool isWaldorfThere(Tuple<int, int> t, char[] chars, char[,] matrix)
        {
            int row = matrix.GetLength(0);
            int col = matrix.GetLength(1);
            bool isthere = true;

            //north
            if (t.Item1 + 1 >= chars.Length)
            {
                for (int i = t.Item1; i >= t.Item1 + 1 - chars.Length; i--)
                {
                    if (Char.ToLower(chars[t.Item1 - i]) != Char.ToLower(matrix[i, t.Item2])) { isthere = false; break; }
                }
                if (isthere) return true;
            }
            isthere = true;

            //south
            if (row - t.Item1 >= chars.Length)
            {
                for (int i = t.Item1; i < t.Item1 + chars.Length; i++)
                {
                    if (Char.ToLower(chars[i - t.Item1]) != Char.ToLower(matrix[i, t.Item2])) { isthere = false; break; }
                }
                if (isthere) return true;
            }
            isthere = true;

            //west
            if (t.Item2 + 1 >= chars.Length)
            {
                for (int j = t.Item2; j >= t.Item2 + 1- chars.Length; j--)
                {
                    if (Char.ToLower(chars[t.Item2 - j]) != Char.ToLower(matrix[t.Item1, j])) { isthere = false; break; }
                }
                if (isthere) return true;
            }
            isthere = true;

            //east
            if (col - t.Item2 >= chars.Length)
            {
                for (int j = t.Item2; j < t.Item2 + chars.Length; j++)
                {
                    if (Char.ToLower(chars[j - t.Item2]) != Char.ToLower(matrix[t.Item1, j])) { isthere = false; break; }
                }
                if (isthere) return true;
            }
            isthere = true;

            //northeast
            if (t.Item1 + 1 >= chars.Length && col - t.Item2 >= chars.Length)
            {
                for (int i = t.Item1, j = t.Item2, k = 0; i > t.Item1 + 1 - chars.Length && j < t.Item2 + chars.Length && k < chars.Length; i--, j++, k++)
                {
                    if (Char.ToLower(chars[k]) != Char.ToLower(matrix[i, j])) { isthere = false; break; }
                }
                if (isthere) return true;
            }
            isthere = true;

            //southwest
            if (row - t.Item1 >= chars.Length && t.Item2 + 1 >= chars.Length)
            {
                for (int i = t.Item1, j = t.Item2, k = 0; i < t.Item1 + chars.Length && j >= t.Item2 + 1 - chars.Length && k < chars.Length; i++, j--, k++)
                {
                    if (Char.ToLower(chars[k]) != Char.ToLower(matrix[i, j])) { isthere = false; break; }
                }
                if (isthere) return true;
            }
            isthere = true;

            //northwest
            if (t.Item1 + 1 >= chars.Length && t.Item2 + 1 >= chars.Length)
            {
                for (int i = t.Item1, j = t.Item2, k = 0; i >= t.Item1 + 1 - chars.Length && j >= t.Item2 + 1 - chars.Length && k < chars.Length; i--, j--, k++)
                {
                    if (Char.ToLower(chars[k]) != Char.ToLower(matrix[i, j])) { isthere = false; break; }
                }
                if (isthere) return true;
            }
            isthere = true;

            //southeast
            if (row - t.Item1 >= chars.Length && col - t.Item2 >= chars.Length)
            {
                for (int i = t.Item1, j = t.Item2, k = 0; i < t.Item1 + chars.Length && j < t.Item2 + chars.Length && k < chars.Length; i++, j++, k++)
                {
                    if (Char.ToLower(chars[k]) != Char.ToLower(matrix[i, j])) { isthere = false; break; }
                }
                if (isthere) return true;
            }

            return false;
        }
    }
}
