using System;

namespace The_Battle_of_The_Five_Armies
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int armyArmor = int.Parse(Console.ReadLine());
            int size = int.Parse(Console.ReadLine());
            char[][] matrix = new char[size][];
            int armyRow = 0;
            int armyCol = 0;
            for (int row = 0; row < matrix.Length; row++)
            {
                matrix[row] = Console.ReadLine().ToCharArray();
            }
            for (int row = 0; row < matrix.Length; row++)
            {
                for (int col = 0; col < matrix[row].Length; col++)
                {
                    if (matrix[row][col] == 'A')
                    {
                        armyRow = row;
                        armyCol = col;
                    }
                }
            }

            while (true)
            {
                string[] tokens = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string direction = tokens[0];
                int enemyRow = int.Parse(tokens[1]);
                int enemyCol = int.Parse(tokens[2]);
                if (isValid(enemyRow, enemyCol, matrix))
                {
                    matrix[enemyRow][enemyCol] = 'O';
                }
                int currentMoveRow = 0;
                int currentMoveCol = 0;
                if (direction == "right")
                {
                    currentMoveCol++;
                }
                else if (direction == "left")
                {
                    currentMoveCol--;
                }
                else if (direction == "up")
                {
                    currentMoveRow--;
                }
                else if (direction == "down")
                {
                    currentMoveRow++;
                }
                if (isValid(armyRow + currentMoveRow, armyCol + currentMoveCol, matrix))
                {
                    matrix[armyRow][armyCol] = '-';
                    armyRow += currentMoveRow;
                    armyCol += currentMoveCol;
                }
                armyArmor--;
                if (matrix[armyRow][armyCol] == 'M')
                {
                    Console.WriteLine($"The army managed to free the Middle World! Armor left: {armyArmor}");
                    matrix[armyRow][armyCol] = '-';
                    break;
                }
                else if (matrix[armyRow][armyCol]=='O')
                {
                    armyArmor -= 2;
                    matrix[armyRow][armyCol] = 'A';
                }
                else
                {
                    matrix[armyRow][armyCol] = 'A';
                }
                if (armyArmor<=0)
                {
                    Console.WriteLine($"The army was defeated at {armyRow};{armyCol}.");
                    matrix[armyRow][armyCol] = 'X';
                    break;
                }
            }

            PrintMatrix(matrix);
        }

        static void PrintMatrix(char[][] matrix)
        {
            for (int row = 0; row < matrix.Length; row++)
            {
                for (int col = 0; col < matrix[row].Length; col++)
                {
                    Console.Write($"{matrix[row][col]}");
                }
                Console.WriteLine();
            }
        }

        static bool isValid(int armyRow, int armyCol, char[][] matrix)
        {
            if (armyRow < 0 || armyCol < 0 || armyRow >= matrix.Length || armyCol >= matrix[armyRow].Length)
            {
                return false;
            }
            return true;
        }
    }
}
