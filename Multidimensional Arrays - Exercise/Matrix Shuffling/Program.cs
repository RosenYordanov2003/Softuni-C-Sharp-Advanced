using System;
using System.Linq;

namespace Matrix_Shuffling
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] matrixInformation = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int rows = matrixInformation[0];
            int cols = matrixInformation[1];
            string[,] matrix = new string[rows, cols];
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                string[] input = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = input[col];
                }
            }
            string command;
            while ((command = Console.ReadLine()) != "END")
            {
                string[] tokens = command.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string action = tokens[0];

                if (tokens.Length < 5 || action != "swap"||tokens.Length>5)
                {
                    Console.WriteLine("Invalid input!");
                    continue;
                }
                else
                {
                    int row1 = int.Parse(tokens[1]);
                    int col1 = int.Parse(tokens[2]);
                    int row2 = int.Parse(tokens[3]);
                    int col2 = int.Parse(tokens[4]);
                    if ((row1 >=0 && col1 >= 0) && (row2 >= 0 && col2 >=0)&&(row1<rows && col1<cols) && (row2< rows &&col2<cols))
                    {
                        string firstRowAndColResult = matrix[row1, col1];
                        matrix[row1, col1] = matrix[row2, col2];
                        matrix[row2, col2] = firstRowAndColResult;
                        PrintMatrix(matrix);
                    }
                    else
                    {
                        Console.WriteLine("Invalid input!");
                        continue;
                    }
                }
            }
        }

        static void PrintMatrix(string[,] matrix)
        {
            for (int row = 0; row <matrix.GetLength(0) ; row++)
            {
                for (int col = 0; col <matrix.GetLength(1) ; col++)
                {
                    Console.Write($"{matrix[row,col]} ");
                }
                Console.WriteLine();
            }
        }
    }
}
