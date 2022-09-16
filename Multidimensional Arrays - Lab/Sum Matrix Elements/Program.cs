using System;
using System.Linq;

namespace Multidimensional_Arrays___Lab
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] matrixSizes = Console.ReadLine().Split(", ").Select(num => int.Parse(num)).ToArray();
            int rows = matrixSizes[0];
            int cols = matrixSizes[1];
            int[,] matrix = new int[rows, cols];
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                int[] input = Console.ReadLine().Split(", ").Select(input => int.Parse(input)).ToArray();
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = input[col];
                }
            }
            int sum = 0;
            for (int row = 0; row <matrix.GetLength(0) ; row++)
            {
                for (int col = 0; col <matrix.GetLength(1) ; col++)
                {
                    sum+=matrix[row, col];
                }
            }
            Console.WriteLine(matrix.GetLength(0));
            Console.WriteLine(matrix.GetLength(1));
            Console.WriteLine(sum);
        }
    }
}
