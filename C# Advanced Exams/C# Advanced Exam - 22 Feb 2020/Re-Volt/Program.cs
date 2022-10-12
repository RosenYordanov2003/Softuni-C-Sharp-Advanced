using System;
using System.Runtime.CompilerServices;

namespace Re_Volt
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            int countCommands = int.Parse(Console.ReadLine());
            char[,] matrix = new char[size, size];
            int playerRow = 0;
            int playerCol = 0;
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                char[] input = Console.ReadLine().Replace(" ", "").ToCharArray();
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = input[col];
                    if (matrix[row, col] == 'f')
                    {
                        playerRow = row;
                        playerCol = col;
                    }
                }
            }
            bool isWon = false;
            string direction = Console.ReadLine();
            for (int i = 0; i <= countCommands; i++)
            {
                if (matrix[playerRow,playerCol]=='f')
                {
                    matrix[playerRow, playerCol] = '-';
                }
                int previousPlayerRow = playerRow;
                int previousPlayerCol = playerCol;
                int currentMoveRow = 0;
                int currentMoveCol = 0;
                if (direction == "up")
                {
                    currentMoveRow--;
                }
                else if (direction == "down")
                {
                    currentMoveRow++;
                }
                else if (direction == "left")
                {
                    currentMoveCol--;
                }
                else if (direction == "right")
                {
                    currentMoveCol++;
                }
                if (isValid(playerRow + currentMoveRow, playerCol + currentMoveCol, matrix))
                {
                    playerRow += currentMoveRow;
                    playerCol += currentMoveCol;
                }
                else
                {
                    InvalidCordinatesMethod(matrix, ref playerRow, ref playerCol,direction);
                }
                if (matrix[playerRow,playerCol]=='T')
                {
                    playerRow=previousPlayerRow;
                    playerCol=previousPlayerCol;
                    matrix[playerRow, playerCol] = 'f';
                }
                else if (matrix[playerRow,playerCol]=='B')
                {
                    i--;
                    continue;
                }
                else if (matrix[playerRow,playerCol]=='F')
                {
                    matrix[playerRow, playerCol] = 'f';
                    isWon = true;
                    Console.WriteLine("Player won!");
                    break;
                }
                else
                {
                    matrix[playerRow, playerCol] = 'f';
                }

                direction = Console.ReadLine();
            }
            if (!isWon)
            {
                Console.WriteLine("Player lost!");
            }
            PrintMatrix(matrix);
        }



        private static void InvalidCordinatesMethod(char[,] matrix, ref int playerRow, ref int playerCol, string direction)
        {
            if (direction == "right")
            {
                playerCol = 0;
            }
            else if (direction == "left")
            {
                playerCol = matrix.GetLength(1) - 1;
            }
            else if (direction == "down")
            {
                playerRow = 0;
            }
            else
            {
                playerRow = matrix.GetLength(0) - 1;
            }
        }

        static bool isValid(int row, int col, char[,] matrix)
        {
            if (row >= 0 && row < matrix.GetLength(0) && col >= 0 && col < matrix.GetLength(1))
            {
                return true;
            }
            return false;
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
