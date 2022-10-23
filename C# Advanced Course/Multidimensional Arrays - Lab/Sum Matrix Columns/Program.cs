using System;
using System.Linq;
namespace Sum_Matrix_Columns
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] matrixSize = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();
            int rows = matrixSize[0];
            int cols = matrixSize[1];
            int[,] matrix = new int[rows, cols];
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                int[] input = Console.ReadLine().Split(' ').Select(input => int.Parse(input)).ToArray();
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = input[col];
                }
            }
            PrintMatrixColumsSums(matrix);
        }

        private static void PrintMatrixColumsSums(int[,] matrix)
        {
            for (int colums = 0; colums <matrix.GetLength(1); colums++)
            {
                int sum = 0;
                for (int rows = 0; rows <matrix.GetLength(0); rows++)
                {
                    int currentNumber=matrix[rows, colums];
                    sum+=currentNumber;
                }
                Console.WriteLine(sum);
            }
        }
    }
}
