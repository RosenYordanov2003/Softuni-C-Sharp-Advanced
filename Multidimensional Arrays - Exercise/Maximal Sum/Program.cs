using System;
using System.Linq;

namespace Maximal_Sum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] matrinxInformation = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int rows = matrinxInformation[0];
            int cols = matrinxInformation[1];
            int[,] matrix = new int[rows, cols];
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                int[] input = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = input[col];
                }
            }
            FindMaximalSum(matrix, rows, cols);
        }

        static void FindMaximalSum(int[,] matrix, int rowsSize, int colsSize)
        {
            int max = int.MinValue;
            int rowIndex = 0;
            int colIndex = 0;
            int sum = 0;
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if ((row + 2 < rowsSize && col + 2 < colsSize))
                    {
                        sum += matrix[row, col] + matrix[row, col + 1] + matrix[row, col + 2] + matrix[row + 1, col] + matrix[row + 1, col + 1] + matrix[row + 1, col + 2]
                            + matrix[row + 2, col] + matrix[row + 2, col + 1] + matrix[row + 2, col + 2];
                        if (sum > max)
                        {
                            max = sum;
                            rowIndex = row;
                            colIndex = col;
                        }
                        sum = 0;
                    }
                    else
                    {
                        continue;
                    }
                }
            }
            Console.WriteLine($"Sum = {max}");

            PrintWinningMatrix(matrix, rowIndex, colIndex);
        }

        static void PrintWinningMatrix(int[,] matrix, int rowIndex, int colIndex)
        {
            for (int row = rowIndex; row <=rowIndex+2 ; row++)
            {
                for (int col = colIndex; col <=colIndex+2 ; col++)
                {
                    Console.Write($"{matrix[row,col]} ");
                }
                Console.WriteLine();
            }
        }
    }
}
