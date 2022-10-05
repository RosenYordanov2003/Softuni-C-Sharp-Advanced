using System;
using System.Collections.Generic;
using System.Linq;

namespace Wall_Destroyer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int matrixSize = int.Parse(Console.ReadLine());
            char[,] matrix = new char[matrixSize, matrixSize];
            int vankoRow = 0;
            int vankoCol = 0;
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                char[] input = Console.ReadLine().Replace(" ", "").ToCharArray();
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = input[col];
                    if (matrix[row, col] == 'V')
                    {
                        vankoRow = row;
                        vankoCol = col;
                    }
                }
            }
            bool isElectrocuted = false;
            string direction = string.Empty;
            int countHitedRods = 0;
            int countCreatedHoles = 0;
            while ((direction = Console.ReadLine()) != "End")
            {
                matrix[vankoRow, vankoCol] = '*';
                countCreatedHoles++;
                if (direction == "right")
                {
                    vankoCol++;
                    if (isValid(vankoRow, vankoCol, matrix))
                    {
                        if (matrix[vankoRow, vankoCol] == 'R')
                        {
                            Console.WriteLine("Vanko hit a rod!");
                            vankoCol--;
                            countHitedRods++;
                            countCreatedHoles--;
                            matrix[vankoRow, vankoCol] = 'V';
                        }
                        else if (matrix[vankoRow, vankoCol] == 'C')
                        {
                            isElectrocuted = true;
                            matrix[vankoRow, vankoCol] = 'E';
                            countCreatedHoles++;
                            break;
                        }
                        else if (matrix[vankoRow, vankoCol] == '*')
                        {
                            Console.WriteLine($"The wall is already destroyed at position [{vankoRow}, {vankoCol}]!");
                            countCreatedHoles--;
                            matrix[vankoRow, vankoCol] = 'V';

                        }
                        else
                        {
                            matrix[vankoRow, vankoCol] = 'V';
                        }
                    }
                    else
                    {
                        vankoCol--;
                        countCreatedHoles--;
                        matrix[vankoRow, vankoCol] = 'V';
                    }
                }
                else if (direction == "left")
                {
                    vankoCol--;
                    if (isValid(vankoRow, vankoCol, matrix))
                    {
                        if (matrix[vankoRow, vankoCol] == 'R')
                        {
                            vankoCol++;
                            Console.WriteLine("Vanko hit a rod!");
                            countHitedRods++;
                            countCreatedHoles--;
                            matrix[vankoRow, vankoCol] = 'V';
                        }
                        else if (matrix[vankoRow, vankoCol] == 'C')
                        {
                            matrix[vankoRow, vankoCol] = 'E';
                            isElectrocuted = true;
                            countCreatedHoles++;
                            break;
                        }
                        else if (matrix[vankoRow, vankoCol] == '*')
                        {
                            Console.WriteLine($"The wall is already destroyed at position [{vankoRow}, {vankoCol}]!");
                            matrix[vankoRow, vankoCol] = 'V';
                            countCreatedHoles--;
                        }
                        else
                        {
                            matrix[vankoRow, vankoCol] = 'V';
                        }
                    }
                    else
                    {
                        vankoCol++;
                        countCreatedHoles--;
                        matrix[vankoRow, vankoCol] = 'V';
                    }
                }
                else if (direction == "up")
                {
                    vankoRow--;
                    if (isValid(vankoRow, vankoCol, matrix))
                    {
                        if (matrix[vankoRow, vankoCol] == 'R')
                        {
                            Console.WriteLine("Vanko hit a rod!");
                            vankoRow++;
                            countCreatedHoles--;
                            countHitedRods++;
                            matrix[vankoRow, vankoCol] = 'V';
                        }
                        else if (matrix[vankoRow, vankoCol] == 'C')
                        {
                            matrix[vankoRow, vankoCol] = 'E';
                            countCreatedHoles++;
                            isElectrocuted = true;
                            break;
                        }
                        else if (matrix[vankoRow, vankoCol] == '*')
                        {
                            Console.WriteLine($"The wall is already destroyed at position [{vankoRow}, {vankoCol}]!");
                            countCreatedHoles--;
                            matrix[vankoRow, vankoCol] = 'V';

                        }
                        else
                        {
                            matrix[vankoRow, vankoCol] = 'V';
                        }
                    }
                    else
                    {
                        countCreatedHoles--;
                        vankoRow++;
                        matrix[vankoRow, vankoCol] = 'V';
                    }
                }
                else if (direction == "down")
                {
                    vankoRow++;
                    if (isValid(vankoRow, vankoCol, matrix))
                    {
                        if (matrix[vankoRow, vankoCol] == 'R')
                        {
                            Console.WriteLine("Vanko hit a rod!");
                            vankoRow--;
                            countCreatedHoles--;
                            countHitedRods++;
                            matrix[vankoRow, vankoCol] = 'V';
                        }
                        else if (matrix[vankoRow, vankoCol] == 'C')
                        {
                            matrix[vankoRow, vankoCol] = 'E';
                            countCreatedHoles++;
                            isElectrocuted = true;
                            break;
                        }
                        else if (matrix[vankoRow, vankoCol] == '*')
                        {
                            Console.WriteLine($"The wall is already destroyed at position [{vankoRow}, {vankoCol}]!");
                            countCreatedHoles--;
                            matrix[vankoRow, vankoCol] = 'V';
                        }
                        else
                        {
                            matrix[vankoRow, vankoCol] = 'V';
                        }
                    }
                    else
                    {
                        vankoRow--;
                        countCreatedHoles--;
                        matrix[vankoRow, vankoCol] = 'V';
                    }
                }
              // PrintMatrix(matrix);
            }

            PrintResult(isElectrocuted, countHitedRods, countCreatedHoles);
            PrintMatrix(matrix);
        }

        static void PrintResult(bool isElectrocuted, int countHitedRods, int countCreatedHoles)
        {
            if (isElectrocuted)
            {
                Console.WriteLine($"Vanko got electrocuted, but he managed to make {countCreatedHoles} hole(s).");
            }
            else
            {
                Console.WriteLine($"Vanko managed to make {countCreatedHoles} hole(s) and he hit only {countHitedRods} rod(s).");
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

        static bool isValid(int vankoRow, int vankoCol, char[,] matrix)
        {
            if (vankoRow >= 0 && vankoRow < matrix.GetLength(0) && vankoCol >= 0 && vankoCol < matrix.GetLength(1))
            {
                return true;
            }
            return false;
        }
    }
}
