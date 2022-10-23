using System;

namespace Armory
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int matrixSize = int.Parse(Console.ReadLine());
            char[,] matrix = new char[matrixSize, matrixSize];
            int armyOfficerRow = 0;
            int armyOfficerCol = 0;
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                char[] input = Console.ReadLine().Replace(" ", "").ToCharArray();
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = input[col];
                    if (matrix[row, col] == 'A')
                    {
                        armyOfficerRow = row;
                        armyOfficerCol = col;
                    }
                }
            }
            int totalGoldCoins = 0;
            string direction = string.Empty;
            bool isEscaped = false;
            while (totalGoldCoins < 65)
            {
                direction = Console.ReadLine();
                matrix[armyOfficerRow, armyOfficerCol] = '-';
                if (direction == "right")
                {
                    armyOfficerCol++;
                    if (isValid(armyOfficerRow, armyOfficerCol, matrix))
                    {
                        if (char.IsDigit(matrix[armyOfficerRow, armyOfficerCol]))
                        {
                            totalGoldCoins += (int)(matrix[armyOfficerRow, armyOfficerCol] - 48);
                            matrix[armyOfficerRow, armyOfficerCol] = 'A';
                        }
                        else if (matrix[armyOfficerRow, armyOfficerCol] == 'M')
                        {
                            matrix[armyOfficerRow, armyOfficerCol] = '-';
                            TelepeportArmyOfficer(matrix, ref armyOfficerRow, ref armyOfficerCol);
                        }
                        else
                        {
                            matrix[armyOfficerRow, armyOfficerCol] = 'A';
                        }
                    }
                    else
                    {
                        isEscaped = true;
                        break;
                    }
                }
                else if (direction == "left")
                {
                    armyOfficerCol--;
                    if (isValid(armyOfficerRow, armyOfficerCol, matrix))
                    {
                        if (char.IsDigit(matrix[armyOfficerRow, armyOfficerCol]))
                        {
                            totalGoldCoins += (int)(matrix[armyOfficerRow, armyOfficerCol] - 48);
                            matrix[armyOfficerRow, armyOfficerCol] = 'A';
                        }
                        else if (matrix[armyOfficerRow, armyOfficerCol] == 'M')
                        {
                            matrix[armyOfficerRow, armyOfficerCol] = '-';
                            TelepeportArmyOfficer(matrix, ref armyOfficerRow, ref armyOfficerCol);
                        }
                        else
                        {
                            matrix[armyOfficerRow, armyOfficerCol] = 'A';
                        }
                    }
                    else
                    {
                        isEscaped = true;
                        break;
                    }
                }
                else if (direction == "down")
                {
                    armyOfficerRow++;
                    if (isValid(armyOfficerRow, armyOfficerCol, matrix))
                    {
                        if (char.IsDigit(matrix[armyOfficerRow, armyOfficerCol]))
                        {
                            totalGoldCoins += (int)(matrix[armyOfficerRow, armyOfficerCol] - 48);
                            matrix[armyOfficerRow, armyOfficerCol] = 'A';
                        }
                        else if (matrix[armyOfficerRow, armyOfficerCol] == 'M')
                        {
                            matrix[armyOfficerRow, armyOfficerCol] = '-';
                            TelepeportArmyOfficer(matrix, ref armyOfficerRow, ref armyOfficerCol);
                        }
                        else
                        {
                            matrix[armyOfficerRow, armyOfficerCol] = 'A';
                        }
                    }
                    else
                    {
                        isEscaped = true;
                        break;
                    }
                }
                else if (direction == "up")
                {
                    armyOfficerRow--;
                    if (isValid(armyOfficerRow, armyOfficerCol, matrix))
                    {
                        if (char.IsDigit(matrix[armyOfficerRow, armyOfficerCol]))
                        {
                            totalGoldCoins += (int)(matrix[armyOfficerRow, armyOfficerCol] - 48);
                            matrix[armyOfficerRow, armyOfficerCol] = 'A';
                        }
                        else if (matrix[armyOfficerRow, armyOfficerCol] == 'M')
                        {
                            matrix[armyOfficerRow, armyOfficerCol] = '-';
                            TelepeportArmyOfficer(matrix, ref armyOfficerRow, ref armyOfficerCol);
                        }
                        else
                        {
                            matrix[armyOfficerRow, armyOfficerCol] = 'A';
                        }
                    }
                    else
                    {
                        isEscaped = true;
                        break;
                    }
                }
            }
            if (isEscaped)
            {
                Console.WriteLine("I do not need more swords!");
            }
            else
            {
                Console.WriteLine("Very nice swords, I will come back for more!");
            }
            Console.WriteLine($"The king paid {totalGoldCoins} gold coins.");
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

        static void TelepeportArmyOfficer(char[,] matrix, ref int armyOfficerRow, ref int armyOfficerCol)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (matrix[row, col] == 'M')
                    {
                        matrix[row, col] = 'A';
                        armyOfficerRow = row;
                        armyOfficerCol = col;
                    }
                }
            }
        }

        static bool isValid(int armyOfficerRow, int armyOfficerCol, char[,] matrix)
        {
            if (armyOfficerRow >= 0 && armyOfficerRow < matrix.GetLength(0) && armyOfficerCol >= 0 && armyOfficerCol < matrix.GetLength(1))
            {
                return true;
            }
            return false;
        }
    }
}
