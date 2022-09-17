using System;
using System.Linq;

namespace Miner
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int fieldSize = int.Parse(Console.ReadLine());
            string[] actions = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            char[,] matrix = new char[fieldSize, fieldSize];
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                char[] input = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(input => char.Parse(input)).ToArray();
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = input[col];
                }
            }
            int minerRow = 0;
            int minerCol = 0;
            bool isFind = false;
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (matrix[row, col] == 's')
                    {
                        minerRow = row;
                        minerCol = col;
                        isFind = true;
                        break;
                    }
                }
                if (isFind)
                {
                    break;
                }
            }
            int totalCoal = FindToTalCoal(matrix);
            int countCollectedCoal = 0;
            bool isGameOver = false;
            for (int i = 0; i < actions.Length; i++)
            {
                string currentAction = actions[i];
                if (currentAction == "up")
                {
                    minerRow--;
                    if (IsInRange(minerRow, minerCol, matrix))
                    {
                        if (matrix[minerRow, minerCol] == 'c')
                        {
                            countCollectedCoal++;
                            matrix[minerRow, minerCol] = '*';
                        }
                        else if (matrix[minerRow, minerCol] == 'e')
                        {
                            isGameOver = true;
                            break;
                        }
                    }
                    else
                    {
                        minerRow++;
                        continue;
                    }
                }
                else if (currentAction == "down")
                {
                    minerRow++;
                    if (IsInRange(minerRow, minerCol, matrix))
                    {
                        if (matrix[minerRow, minerCol] == 'c')
                        {
                            countCollectedCoal++;
                            matrix[minerRow, minerCol] = '*';
                        }
                        else if (matrix[minerRow, minerCol] == 'e')
                        {
                            isGameOver = true;
                            break;
                        }
                    }
                    else
                    {
                        minerRow--;
                        continue;
                    }
                }
                else if (currentAction == "right")
                {
                    minerCol++;
                    if (IsInRange(minerRow, minerCol, matrix))
                    {
                        if (matrix[minerRow, minerCol] == 'c')
                        {
                            countCollectedCoal++;
                            matrix[minerRow, minerCol] = '*';
                        }
                        else if (matrix[minerRow, minerCol] == 'e')
                        {
                            isGameOver = true;
                            break;
                        }
                    }
                    else
                    {
                        minerCol--;
                        continue;
                    }
                }
                else if (currentAction == "left")
                {
                    minerCol--;
                    if (IsInRange(minerRow, minerCol, matrix))
                    {
                        if (matrix[minerRow, minerCol] == 'c')
                        {
                            countCollectedCoal++;
                            matrix[minerRow, minerCol] = '*';
                        }
                        else if (matrix[minerRow, minerCol] == 'e')
                        {
                            isGameOver = true;
                            break;
                        }
                    }
                    else
                    {
                        minerCol++;
                        continue;
                    }
                }
                if (countCollectedCoal==totalCoal)
                {
                    Console.WriteLine($"You collected all coals! ({minerRow}, {minerCol})");
                    return;
                }
            }
            if (isGameOver)
            {
                Console.WriteLine($"Game over! ({minerRow}, {minerCol})");
            }
            else 
            {
                Console.WriteLine($"{totalCoal-countCollectedCoal} coals left. ({minerRow}, {minerCol})");
            }
        }

        static int FindToTalCoal(char[,] matrix)
        {
            int count = 0;
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (matrix[row, col] == 'c')
                    {
                        count++;
                    }
                }
            }
            return count;
        }

        private static bool IsInRange(int minerRow, int minerCol, char[,] matrix)
        {
            if ((minerRow >= 0 && minerRow < matrix.GetLength(0)) && (minerCol >= 0 && minerCol < matrix.GetLength(1)))
            {
                return true;
            }
            return false;
        }
    }
}
