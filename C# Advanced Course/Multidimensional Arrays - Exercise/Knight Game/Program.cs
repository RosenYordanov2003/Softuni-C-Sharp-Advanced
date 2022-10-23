using System;
using System.Linq;

namespace Knight_Game
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int matrixSize = int.Parse(Console.ReadLine());
            char[,] matrix = new char[matrixSize, matrixSize];
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                string input = Console.ReadLine();
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = input[col];
                }
            }
            int knightCounter = 0;
            while (true)
            {
                int knightRow = 0;
                int knightCol = 0;
                int maxCounter = 0;
                for (int row = 0; row < matrix.GetLength(0); row++)
                {
                    for (int col = 0; col < matrix.GetLength(1); col++)
                    {
                        int counter = 0;
                        if (matrix[row, col] == 'K')
                        {
                            //right up
                            if (IsValid(row - 1, col + 2, matrix))
                            {
                                if (matrix[row - 1, col + 2] == 'K')
                                {
                                    counter++;
                                }
                            }
                            //left up
                            if (IsValid(row - 1, col - 2, matrix))
                            {
                                if (matrix[row - 1, col - 2] == 'K')
                                {
                                    counter++;
                                }
                            }
                            // right more up
                            if (IsValid(row - 2, col + 1, matrix))
                            {
                                if (matrix[row - 2, col + 1] == 'K')
                                {
                                    counter++;
                                }
                            }
                            if (IsValid(row - 2, col - 1, matrix))
                            {
                                if (matrix[row - 2, col - 1] == 'K')
                                {
                                    counter++;
                                }
                            }
                            if (IsValid(row + 1, col - 2, matrix))
                            {
                                if (matrix[row + 1, col - 2] == 'K')
                                {
                                    counter++;
                                }
                            }
                            if (IsValid(row + 1, col + 2, matrix))
                            {
                                if (matrix[row + 1, col + 2] == 'K')
                                {
                                    counter++;
                                }
                            }
                            if (IsValid(row + 2, col - 1, matrix))
                            {
                                if (matrix[row + 2, col - 1] == 'K')
                                {
                                    counter++;
                                }
                            }
                            if (IsValid(row + 2, col + 1, matrix))
                            {
                                if (matrix[row + 2, col + 1] == 'K')
                                {
                                    counter++;
                                }
                            }
                            if (counter>maxCounter)
                            {
                                maxCounter=counter;
                                 knightRow = row;
                                 knightCol = col;
                            }
                        }
                    }
                }
                if (maxCounter > 0)
                {
                    knightCounter++;
                    matrix[knightRow, knightCol] = '0';
                }
                else
                {
                    break;
                }
            }
            Console.WriteLine(knightCounter);
        }

        static bool IsValid(int row, int col, char[,] matrix)
        {
            if ((row >= 0 && row < matrix.GetLength(0)) && (col >= 0 && col < matrix.GetLength(1)))
            {
                return true;
            }
            return false;
        }
    }
}
