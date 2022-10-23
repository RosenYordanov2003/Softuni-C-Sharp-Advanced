using System;
using System.Linq;
using System.Collections.Generic;
namespace Radioactive_Mutant_Vampire_Bunnies
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] matrixSize = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            char[,] matrix = new char[matrixSize[0], matrixSize[1]];

            int playerPosRow = 0;
            int playerPosCol = 0;
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                string input = Console.ReadLine();
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = input[col];
                    if (matrix[row,col]=='P')
                    {
                        playerPosRow = row;
                        playerPosCol = col;
                    }
                }
            }

            string actions = Console.ReadLine();
            List<string> buniesPositions = new List<string>();
            bool isDead = false;
            bool isWon = false;
            for (int i = 0; i < actions.Length; i++)
            {
                matrix[playerPosRow, playerPosCol] = '.';
                char currentAction = actions[i];
                if (currentAction == 'U')
                {
                    playerPosRow--;
                    if (isValid(playerPosRow, playerPosCol, matrix))
                    {
                        if (matrix[playerPosRow, playerPosCol] == 'B')
                        {
                            isDead = true;
                        }
                        else
                        {
                            matrix[playerPosRow, playerPosCol] = 'P';
                        }
                    }
                    else
                    {
                        isWon = true;
                        playerPosRow++;
                    }
                }
                else if (currentAction == 'D')
                {
                    playerPosRow++;
                    if (isValid(playerPosRow, playerPosCol, matrix))
                    {
                        if (matrix[playerPosRow, playerPosCol] == 'B')
                        {
                            isDead = true;
                        }
                        else
                        {
                            matrix[playerPosRow, playerPosCol] = 'P';
                        }
                    }
                    else
                    {
                        isWon = true;
                        playerPosRow--;
                    }
                }
                else if (currentAction == 'R')
                {
                    playerPosCol++;
                    if (isValid(playerPosRow, playerPosCol, matrix))
                    {
                        if (matrix[playerPosRow, playerPosCol] == 'B')
                        {
                            isDead = true;
                        }
                        else
                        {
                            matrix[playerPosRow, playerPosCol] = 'P';
                        }
                    }
                    else
                    {
                        isWon = true;
                        playerPosCol--;
                    }
                }
                else if (currentAction == 'L')
                {
                    playerPosCol--;
                    if (isValid(playerPosRow, playerPosCol, matrix))
                    {
                        if (matrix[playerPosRow, playerPosCol] == 'B')
                        {
                            isDead = true;
                        }
                        else
                        {
                            matrix[playerPosRow, playerPosCol] = 'P';
                        }
                    }
                    else
                    {
                        isWon = true;
                        playerPosCol++;
                    }
                }
                buniesPositions = MoveBunnies(matrix);
                for (int z = 0; z < buniesPositions.Count; z++)
                {
                    string[] currentPosition = buniesPositions[z].Split(",");
                    int row = int.Parse(currentPosition[0]);
                    int col = int.Parse(currentPosition[1]);
                    if (matrix[row, col] == 'P')
                    {
                        isDead = true;
                    }
                    matrix[row, col] = 'B';
                }
                buniesPositions.Clear();
                if (isDead || isWon)
                {
                    break;
                }
            }
            PrintMatrix(matrix);

            if (isDead)
            {
                Console.WriteLine($"dead: {playerPosRow} {playerPosCol}");
            }
            else
            {
                Console.WriteLine($"won: {playerPosRow} {playerPosCol}");
            }
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

        static bool isValid(int playerPosRow, int playerPosCol, char[,] matrix)
        {
            if ((playerPosRow >= 0 && playerPosRow < matrix.GetLength(0)) && (playerPosCol >= 0 && playerPosCol < matrix.GetLength(1)))
            {
                return true;
            }
            return false;
        }

        static List<string> MoveBunnies(char[,] matrix)
        {
            List<string> bunniesLocation = new List<string>();
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (matrix[row, col] == 'B')
                    {
                        //Up
                        if (isValid(row - 1, col, matrix))
                        {
                            string format = $"{row - 1},{col}";
                            bunniesLocation.Add(format);
                        }
                        //down
                        if (isValid(row + 1, col, matrix))
                        {
                            string format = $"{row + 1},{col}";
                            bunniesLocation.Add(format);
                        }
                        //right
                        if (isValid(row, col + 1, matrix))
                        {
                            string format = $"{row},{col + 1}";
                            bunniesLocation.Add(format);
                        }
                        //left
                        if (isValid(row, col - 1, matrix))
                        {
                            string format = $"{row},{col - 1}";
                            bunniesLocation.Add(format);
                        }
                    }
                }
            }
            return bunniesLocation;

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
}

