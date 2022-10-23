using System;
using System.Collections.Generic;
using System.Linq;

namespace Beaver_at_Work
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int totalWoodBranches = 0;
            int beaverRow = 0;
            int beaverCol = 0;
            int matrixSize = int.Parse(Console.ReadLine());
            char[,] matrix = new char[matrixSize, matrixSize];
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                char[] input = Console.ReadLine().Replace(" ", "").ToCharArray();
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = input[col];
                    if (matrix[row, col] == 'B')
                    {
                        beaverRow = row;
                        beaverCol = col;
                    }
                    if (char.IsLetter(matrix[row, col]))
                    {
                        if (char.IsLower(matrix[row, col]))
                        {
                            totalWoodBranches++;
                        }
                    }
                }
            }
            Stack<char> branches = new Stack<char>();
            string direction;
            while ((direction = Console.ReadLine()) != "end" && totalWoodBranches > 0)
            {
                int currentRow = 0;
                int currentCol = 0;
                matrix[beaverRow, beaverCol] = '-';
                if (direction == "right")
                {
                    currentCol++;
                }
                else if (direction == "left")
                {
                    currentCol--;
                }
                else if (direction == "up")
                {
                    currentRow--;
                }
                else if (direction == "down")
                {
                    currentRow++;
                }
                if (IsValid(currentRow + beaverRow, currentCol + beaverCol, matrix))
                {
                    beaverRow += currentRow;
                    beaverCol += currentCol;
                }
                else
                {
                    if (branches.Any())
                    {
                        branches.Pop();
                    }
                  //  matrix[beaverRow, beaverCol] = 'B';
                    continue;
                }
                if (char.IsLetter(matrix[beaverRow, beaverCol]))
                {
                    if (char.IsLower(matrix[beaverRow, beaverCol]))
                    {
                        branches.Push(matrix[beaverRow, beaverCol]);
                        matrix[beaverRow, beaverCol] = 'B';
                        totalWoodBranches--;
                    }
                    else if (matrix[beaverRow, beaverCol] == 'F')
                    {
                        matrix[beaverRow, beaverCol] = '-';
                        if (direction == "right")
                        {
                            if (beaverCol < matrix.GetLength(0) - 1)
                            {
                                beaverCol = matrix.GetLength(0) - 1;
                                if (char.IsLetter(matrix[beaverRow, beaverCol]))
                                {
                                    if (char.IsLower(matrix[beaverRow, beaverCol]))
                                    {
                                        totalWoodBranches--;
                                        branches.Push(matrix[beaverRow, beaverCol]);
                                    }
                                }
                                matrix[beaverRow, beaverCol] = 'B';
                            }
                            else
                            {
                                beaverCol = 0;
                                if (char.IsLetter(matrix[beaverRow, beaverCol]))
                                {
                                    if (char.IsLower(matrix[beaverRow, beaverCol]))
                                    {
                                        totalWoodBranches--;
                                        branches.Push(matrix[beaverRow, beaverCol]);
                                    }
                                }
                                matrix[beaverRow, beaverCol] = 'B';
                            }
                        }
                        else if (direction == "left")
                        {
                            if (beaverCol > 0)
                            {
                                beaverCol = 0;
                                if (char.IsLetter(matrix[beaverRow, beaverCol]))
                                {
                                    if (char.IsLower(matrix[beaverRow, beaverCol]))
                                    {
                                        totalWoodBranches--;
                                        branches.Push(matrix[beaverRow, beaverCol]);
                                    }
                                }
                                matrix[beaverRow, beaverCol] = 'B';
                            }
                            else
                            {
                                beaverCol = matrix.GetLength(1) - 1;
                                if (char.IsLetter(matrix[beaverRow, beaverCol]))
                                {
                                    if (char.IsLower(matrix[beaverRow, beaverCol]))
                                    {
                                        totalWoodBranches--;
                                        branches.Push(matrix[beaverRow, beaverCol]);
                                    }
                                }
                                matrix[beaverRow, beaverCol] = 'B';
                            }
                        }
                        else if (direction == "down")
                        {
                            if (beaverRow < matrix.GetLength(0) - 1)
                            {
                                beaverRow = matrix.GetLength(0) - 1;
                                if (char.IsLetter(matrix[beaverRow, beaverCol]))
                                {
                                    if (char.IsLower(matrix[beaverRow, beaverCol]))
                                    {
                                        totalWoodBranches--;
                                        branches.Push(matrix[beaverRow, beaverCol]);
                                    }
                                }
                                matrix[beaverRow, beaverCol] = 'B';
                            }
                            else
                            {
                                beaverRow = 0;
                                if (char.IsLetter(matrix[beaverRow, beaverCol]))
                                {
                                    if (char.IsLower(matrix[beaverRow, beaverCol]))
                                    {
                                        totalWoodBranches--;
                                        branches.Push(matrix[beaverRow, beaverCol]);
                                    }
                                }
                                matrix[beaverRow, beaverCol] = 'B';
                            }
                        }
                        else
                        {
                            if (beaverRow > 0)
                            {
                                beaverRow = 0;
                                if (char.IsLetter(matrix[beaverRow, beaverCol]))
                                {
                                    if (char.IsLower(matrix[beaverRow, beaverCol]))
                                    {
                                        totalWoodBranches--;
                                        branches.Push(matrix[beaverRow, beaverCol]);
                                    }
                                }
                                matrix[beaverRow, beaverCol] = 'B';
                            }
                            else
                            {
                                beaverRow = matrix.GetLength(0) - 1;
                                if (char.IsLetter(matrix[beaverRow, beaverCol]))
                                {
                                    if (char.IsLower(matrix[beaverRow, beaverCol]))
                                    {
                                        totalWoodBranches--;
                                        branches.Push(matrix[beaverRow, beaverCol]);
                                    }
                                }
                                matrix[beaverRow, beaverCol] = 'B';
                            }
                        }
                    }
                }
                else
                {
                    matrix[beaverRow, beaverCol] = 'B';
                }
                Console.WriteLine($"total branches left {totalWoodBranches}");
                PrintMatrix(matrix);
                Console.WriteLine(new string('-', 30));
            }
            //string result = totalWoodBranches == 0 ? $"The Beaver successfully collect {branches.Count} wood branches: {string.Join(", ", branches.Reverse())}." : $"The Beaver failed to collect every wood branch. There are {totalWoodBranches} branches left.";
            //Console.WriteLine(result);
            //PrintMatrix(matrix);
        }
        static bool IsValid(int row, int col, char[,] matrix)
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
                    Console.Write($"{matrix[row, col]} ");
                }
                Console.WriteLine();
            }
        }
    }
}
