using System;
using System.Linq;

namespace Bombs
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int matrixSize = int.Parse(Console.ReadLine());
            int[,] matrix = new int[matrixSize, matrixSize];
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                int[] input = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = input[col];
                }
            }
            string[] bombIndexes = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < bombIndexes.Length; i++)
            {
                string[] currentBombIndex = bombIndexes[i].Split(",",StringSplitOptions.RemoveEmptyEntries);
                int row = int.Parse(currentBombIndex[0]);
                int col = int.Parse(currentBombIndex[1]);
                int currentBomb = matrix[row, col];
                if (currentBomb > 0)
                {
                    if (col + 1 < matrixSize && col + 1 >= 0)
                    {
                        if (matrix[row, col + 1] > 0)
                        {
                            matrix[row, col + 1] -= currentBomb;
                        }
                    }
                    if (col - 1 >= 0 && col - 1 < matrixSize)
                    {
                        if (matrix[row, col - 1] > 0)
                        {
                            matrix[row, col - 1] -= currentBomb;
                        }
                    }
                    if (row - 1 >= 0 && row - 1 < matrixSize)
                    {
                        if (matrix[row - 1, col] > 0)
                        {
                            matrix[row - 1, col] -= currentBomb;
                        }
                    }
                    if (row + 1 < matrixSize && row + 1 >= 0)
                    {
                        if (matrix[row + 1, col] > 0)
                        {
                            matrix[row + 1, col] -= currentBomb;
                        }
                    }
                    if (IsInRange(row - 1, col + 1, matrixSize))
                    {
                        if (matrix[row - 1, col + 1] > 0)
                        {
                            matrix[row - 1, col + 1] -= currentBomb;
                        }
                    }
                    if (IsInRange(row - 1, col - 1, matrixSize))
                    {
                        if (matrix[row - 1, col - 1] > 0)
                        {
                            matrix[row - 1, col - 1] -= currentBomb;
                        }
                    }
                    if (IsInRange(row + 1, col + 1, matrixSize))
                    {
                        if (matrix[row + 1, col + 1] > 0)
                        {
                            matrix[row + 1, col + 1] -= currentBomb;
                        }
                    }
                    if (IsInRange(row + 1, col - 1, matrixSize))
                    {
                        if (matrix[row + 1, col - 1] > 0)
                        {
                            matrix[row + 1, col - 1] -= currentBomb;
                        }
                    }
                    matrix[row, col] = 0;

                }
            }
            PrintAliveCellsAndTheirSum(matrix);

            PrintMatrix(matrix);


        }

        static void PrintAliveCellsAndTheirSum(int[,] matrix)
        {
            int countAliveCells = 0;
            int sum = 0;
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (matrix[row, col] > 0)
                    {
                        countAliveCells++;
                        sum += matrix[row, col];
                    }
                }
            }
            Console.WriteLine($"Alive cells: {countAliveCells}");
            Console.WriteLine($"Sum: {sum}");
        }

        static bool IsInRange(int row, int col, int matrixSize)
        {
            if ((row >= 0 && row < matrixSize) && (col >= 0 && col < matrixSize))
            {
                return true;
            }
            return false;
        }

        static void PrintMatrix(int[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write($"{matrix[row, col]} ");
                }
                Console.WriteLine();
            }
        }
    }
}
