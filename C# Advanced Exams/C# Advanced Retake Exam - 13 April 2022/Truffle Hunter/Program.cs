using System;
using System.ComponentModel;

namespace Truffle_Hunter
{
    internal class Program
    {
        //•	Black truffle - 'B'
        //•	Summer truffle - 'S'
        //•	White truffle - 'W'

        static void Main(string[] args)
        {
            int forestSize = int.Parse(Console.ReadLine());
            char[,] matrix = new char[forestSize, forestSize];
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                char[] input = Console.ReadLine().Replace(" ", "").ToCharArray();
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = input[col];
                }
            }
            string directions = string.Empty;
            int countBlackTruffles = 0;
            int countSummerTruffles = 0;
            int coundWhiteTruffles = 0;
            int countWildBoarEatenTruffles = 0;
            while ((directions = Console.ReadLine()) != "Stop the hunt")
            {
                string[] tokens = directions.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string action = tokens[0];
                if (action == "Collect")
                {
                    int row = int.Parse(tokens[1]);
                    int col = int.Parse(tokens[2]);
                    if (IsValid(row, col, matrix))
                    {
                        if (matrix[row, col] == 'B')
                        {
                            countBlackTruffles++;
                            matrix[row, col] = '-';
                        }
                        else if (matrix[row, col] == 'W')
                        {
                            coundWhiteTruffles++;
                            matrix[row, col] = '-';
                        }
                        else if (matrix[row, col] == 'S')
                        {
                            countSummerTruffles++;
                            matrix[row, col] = '-';
                        }
                    }
                    else
                    {
                        continue;
                    }
                }
                else
                {
                    int wildBoarRow = int.Parse(tokens[1]);
                    int wildBoarCol = int.Parse(tokens[2]);
                    string direction = tokens[3];
                    if (direction == "right")
                    {
                        countWildBoarEatenTruffles += MoveWildBoarOnRight(wildBoarRow, wildBoarCol, matrix);
                    }
                    else if (direction == "left")
                    {
                        countWildBoarEatenTruffles += MoveWildBoarOnLeft(wildBoarRow, wildBoarCol, matrix);
                    }
                    else if (direction == "up")
                    {
                        countWildBoarEatenTruffles += MoveWildBoarUp(wildBoarRow, wildBoarCol, matrix);
                    }
                    else if (direction == "down")
                    {
                        countWildBoarEatenTruffles += MoveWildBoarDown(wildBoarRow, wildBoarCol, matrix);
                    }
                }
            }
            Console.WriteLine($"Peter manages to harvest {countBlackTruffles} black, {countSummerTruffles} summer, and {coundWhiteTruffles} white truffles.");
            Console.WriteLine($"The wild boar has eaten {countWildBoarEatenTruffles} truffles.");
            PrintMatrix(matrix);
        }

        static int MoveWildBoarDown(int wildBoarRow, int wildBoarCol, char[,] matrix)
        {
            int countEatenTruffles = 0;
            int wildBoarMovemnet = 0;
            for (int col = wildBoarCol; col <=wildBoarCol ; col++)
            {
                for (int row = wildBoarRow; row <matrix.GetLength(0) ; row++)
                {
                    char currentElement = matrix[row, col];
                    if (wildBoarMovemnet%2==0)
                    {
                        if (currentElement == 'W' || currentElement == 'S' || currentElement == 'B')
                        {
                            countEatenTruffles++;
                            matrix[row, col] = '-';
                        }
                    }
                    wildBoarMovemnet++;
                }
            }
            return countEatenTruffles;
        }

        static int MoveWildBoarUp(int wildBoarRow, int wildBoarCol, char[,] matrix)
        {
            int countEatenTruffles = 0;
            int wildBoarMovemnet = 0;
            for (int col = wildBoarCol; col <= wildBoarCol; col++)
            {
                for (int row = wildBoarRow; row >= 0; row--)
                {
                    char currentElement = matrix[row, col];
                    if (wildBoarMovemnet % 2 == 0)
                    {
                        if (currentElement == 'W' || currentElement == 'S' || currentElement == 'B')
                        {
                            countEatenTruffles++;
                            matrix[row, col] = '-';
                        }
                    }
                    wildBoarMovemnet++;
                }
            }
            return countEatenTruffles;
        }

        static int MoveWildBoarOnLeft(int wildBoarRow, int wildBoarCol, char[,] matrix)
        {
            int countEatenTruffles = 0;
            int wildBoarMovemnet = 0;
            for (int row = wildBoarRow; row <= wildBoarRow; row++)
            {
                for (int col = wildBoarCol; col >= 0; col--)
                {
                    char currentElement = matrix[row, col];
                    if (wildBoarMovemnet % 2 == 0)
                    {
                        if (currentElement == 'W' || currentElement == 'S' || currentElement == 'B')
                        {
                            countEatenTruffles++;
                            matrix[row, col] = '-';
                        }
                    }
                    wildBoarMovemnet++;
                }
            }
            return countEatenTruffles;
        }

        static int MoveWildBoarOnRight(int wildBoarRow, int wildBoarCol, char[,] matrix)
        {
            int countEatenTruffles = 0;
            int wildBoarMovemnet = 0;
            for (int row = wildBoarRow; row <= wildBoarRow; row++)
            {
                for (int col = wildBoarCol; col < matrix.GetLength(1); col++)
                {
                    char currentElement = matrix[row, col];
                    if (wildBoarMovemnet % 2 == 0)
                    {
                        if (currentElement == 'W' || currentElement == 'S' || currentElement == 'B')
                        {
                            countEatenTruffles++;
                            matrix[row, col] = '-';
                        }
                    }
                    wildBoarMovemnet++;
                }
            }
            return countEatenTruffles;
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
