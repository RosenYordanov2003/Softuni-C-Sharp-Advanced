using System;
using System.Linq;

namespace Snake_Moves
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] matrixInformation = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int rows = matrixInformation[0];
            int columns = matrixInformation[1];
            char[,] matrix = new char[rows, columns];
            string input = Console.ReadLine();
            int counter = 0;
            int index = 0;
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                if (counter % 2 == 0)
                {
                    for (int col = 0; col <matrix.GetLength(1) ; col++)
                    {
                        if (index==input.Length)
                        {
                            index = 0;
                        }
                       matrix[row, col] = input[index++];
                    }
                }
                else
                {
                    for (int col = matrix.GetLength(1) - 1; col >= 0; col--)
                    {
                        if (index == input.Length)
                        {
                            index = 0;
                        }
                        matrix[row, col] = input[index++];
                    }
                }
                counter++;
            }
            PrintMatrix(matrix);
        }

        static void PrintMatrix(char[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write($"{matrix[row, col]}");
                }
                Console.WriteLine();
            }
        }
    }
}
