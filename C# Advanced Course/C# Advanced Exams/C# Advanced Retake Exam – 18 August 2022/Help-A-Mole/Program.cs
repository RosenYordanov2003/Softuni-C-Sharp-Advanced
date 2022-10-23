using System;
using System.Linq;

namespace Help_A_Mole
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int matrixSize = int.Parse(Console.ReadLine());
            char[,] matrix = new char[matrixSize, matrixSize];
            int moleRow = 0;
            int moleCol = 0;
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                char[] input = Console.ReadLine().Replace(" ", "").ToCharArray();
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = input[col];
                    if (matrix[row, col] == 'M')
                    {
                        moleRow = row;
                        moleCol = col;
                    }
                }
            }
            int totalPints = 0;
            string command = string.Empty;
            while ((command = Console.ReadLine()) != "End" && totalPints < 25)
            {
                matrix[moleRow, moleCol] = '-';
                if (command == "right")
                {
                    moleCol++;
                    if (IsValid(moleRow, moleCol, matrix))
                    {
                        if (char.IsDigit(matrix[moleRow, moleCol]))
                        {
                            totalPints += (int)(matrix[moleRow, moleCol] - 48);
                            matrix[moleRow, moleCol] = 'M';
                        }
                        else if (matrix[moleRow, moleCol] == 'S')
                        {
                            matrix[moleRow, moleCol] = '-';
                            int currentTeleportRow = 0;
                            int currentTeleportCol = 0;
                            FindTeleportIndex(matrix, ref currentTeleportRow, ref currentTeleportCol);
                            matrix[currentTeleportRow, currentTeleportCol] = 'M';
                            moleRow = currentTeleportRow;
                            moleCol = currentTeleportCol;
                            totalPints -= 3;
                        }
                        else
                        {
                            matrix[moleRow, moleCol] = 'M';
                        }
                    }
                    else
                    {
                        moleCol--;
                        Console.WriteLine("Don't try to escape the playing field!");
                    }
                }
                else if (command == "left")
                {
                    moleCol--;
                    if (IsValid(moleRow, moleCol, matrix))
                    {
                        if (char.IsDigit(matrix[moleRow, moleCol]))
                        {
                            totalPints += (int)(matrix[moleRow, moleCol]-48);
                            matrix[moleRow, moleCol] = 'M';
                        }
                        else if (matrix[moleRow, moleCol] == 'S')
                        {
                            matrix[moleRow, moleCol] = '-';
                            int currentTeleportRow = 0;
                            int currentTeleportCol = 0;
                            FindTeleportIndex(matrix, ref currentTeleportRow, ref currentTeleportCol);
                            matrix[currentTeleportRow, currentTeleportCol] = 'M';
                            moleRow = currentTeleportRow;
                            moleCol = currentTeleportCol;
                            totalPints -= 3;
                        }
                        else
                        {
                            matrix[moleRow, moleCol] = 'M';
                        }
                    }
                    else
                    {
                        moleCol++;
                        Console.WriteLine("Don't try to escape the playing field!");
                    }
                }
                else if (command == "down")
                {
                    moleRow++;
                    if (IsValid(moleRow, moleCol, matrix))
                    {
                        if (char.IsDigit(matrix[moleRow, moleCol]))
                        {
                            totalPints += (int)(matrix[moleRow, moleCol] - 48);
                            matrix[moleRow, moleCol] = 'M';
                        }
                        else if (matrix[moleRow, moleCol] == 'S')
                        {
                            matrix[moleRow, moleCol] = '-';
                            int currentTeleportRow = 0;
                            int currentTeleportCol = 0;
                            FindTeleportIndex(matrix, ref currentTeleportRow, ref currentTeleportCol);
                            matrix[currentTeleportRow, currentTeleportCol] = 'M';
                            moleRow = currentTeleportRow;
                            moleCol = currentTeleportCol;
                            totalPints -= 3;
                        }
                        else
                        {
                            matrix[moleRow, moleCol] = 'M';
                        }
                    }
                    else
                    {
                        moleRow--;
                        Console.WriteLine("Don't try to escape the playing field!");
                    }
                }
                else if (command == "up")
                {
                    moleRow--;
                    if (IsValid(moleRow, moleCol, matrix))
                    {
                        if (char.IsDigit(matrix[moleRow, moleCol]))
                        {
                            totalPints += (int)(matrix[moleRow, moleCol] - 48);
                            matrix[moleRow, moleCol] = 'M';
                        }
                        else if (matrix[moleRow, moleCol] == 'S')
                        {
                            matrix[moleRow, moleCol] = '-';
                            int currentTeleportRow = 0;
                            int currentTeleportCol = 0;
                            FindTeleportIndex(matrix, ref currentTeleportRow, ref currentTeleportCol);
                            matrix[currentTeleportRow, currentTeleportCol] = 'M';
                            moleRow = currentTeleportRow;
                            moleCol = currentTeleportCol;
                            totalPints -= 3;
                        }
                        else
                        {
                            matrix[moleRow, moleCol] = 'M';
                        }
                    }
                    else
                    {
                        moleRow++;
                        Console.WriteLine("Don't try to escape the playing field!");
                    }
                }
             //   PrintMatrix(matrix);
            }
            PrintResult(totalPints, matrix);
            PrintMatrix(matrix);
        }

        static void PrintResult(int totalPints, char[,] matrix)
        {
            if (totalPints >= 25)
            {
                Console.WriteLine("Yay! The Mole survived another game!");
            }
            else
            {
                Console.WriteLine("Too bad! The Mole lost this battle!");
            }
            if (totalPints >= 25)
            {
                Console.WriteLine($"The Mole managed to survive with a total of {totalPints} points.");
            }
            else
            {
                Console.WriteLine($"The Mole lost the game with a total of {totalPints} points.");
            }
        }

        private static void FindTeleportIndex(char[,] matrix, ref int currentTeleportRow, ref int currentTeleportCol)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (matrix[row, col] == 'S')
                    {
                        currentTeleportRow = row;
                        currentTeleportCol = col;
                    }
                }
            }
        }

        static bool IsValid(int moleRow, int moleCol, char[,] matrix)
        {
            if (moleRow >= 0 && moleRow < matrix.GetLength(0) && moleCol >= 0 && moleCol < matrix.GetLength(1))
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
