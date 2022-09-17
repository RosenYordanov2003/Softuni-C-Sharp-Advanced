using System;
using System.Linq;

namespace Diagonal_Difference
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int matrixSize = int.Parse(Console.ReadLine());
            int[,] matrix = new int[matrixSize, matrixSize];
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                int[] input = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = input[col];
                }
            }
            FindDiagonalDifference(matrix);
        }

        static void FindDiagonalDifference(int[,] matrix)
        {
            int firstDiagonalSum = FindFirstDiagonalSum(matrix);

            int secondDiagonalSum = FindSecondDigalonalSum(matrix);

            int diff=Math.Abs(firstDiagonalSum - secondDiagonalSum);
            Console.WriteLine(diff);
        }

        static int FindSecondDigalonalSum(int[,] matrix)
        {
            int matrixRowsSize = matrix.GetLength(0);
            int startIndex = matrixRowsSize-1;
            int secondDiagonalSum = 0;
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (col==startIndex)
                    {
                        secondDiagonalSum += matrix[row, col];
                        startIndex--;
                        break;
                    }
                }
            }
            return secondDiagonalSum;
        }

        static int FindFirstDiagonalSum(int[,] matrix)
        {
            int firstDiagonalIndex = 0;
            int firstDiagonalSum = 0;
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (row == firstDiagonalIndex && col == firstDiagonalIndex)
                    {
                        firstDiagonalSum += matrix[row, col];
                        firstDiagonalIndex++;
                        break;
                    }
                }
            }
            return firstDiagonalSum;
        }
    }
}
