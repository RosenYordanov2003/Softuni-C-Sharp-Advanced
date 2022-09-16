using System;

namespace Pascal_Triangle
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            long[][] jaggedArray = new long[n][];
            jaggedArray[0] = new long[1] { 1 };
            for (int row = 1; row < n; row++)
            {
                jaggedArray[row] = new long[jaggedArray[row - 1].Length + 1];
                for (int col = 0; col < jaggedArray[row].Length; col++)
                {
                    if (jaggedArray[row - 1].Length > col)
                    {
                        jaggedArray[row][col] += jaggedArray[row - 1][col];
                    }
                    if (col>0)
                    {
                        jaggedArray[row][col] += jaggedArray[row - 1][col - 1];
                    }
                }
            }
            PrintPascalTriangle(jaggedArray);
        }

        static void PrintPascalTriangle(long[][] jaggedArray)
        {
            for (int row = 0; row <jaggedArray.Length; row++)
            {
                for (int col = 0; col <jaggedArray[row].Length; col++)
                {
                    Console.Write($"{jaggedArray[row][col]} ");
                }
                Console.WriteLine();
            }
        }
    }
}
