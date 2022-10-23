using System;
using System.Linq;

namespace Selling
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int matrixSize = int.Parse(Console.ReadLine());
            char[,] matrix = new char[matrixSize, matrixSize];
            int money = 0;
            int bakeryRow = 0;
            int bakeryCol = 0;
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                char[] input = Console.ReadLine().Replace(" ", "").ToCharArray();
                for (int col = 0; col < matrix.GetLength(0); col++)
                {
                    matrix[row, col] = input[col];
                    if (matrix[row, col] == 'S')
                    {
                        bakeryRow = row;
                        bakeryCol = col;
                    }
                }
            }
            bool isOutOfBakery = false;
            while (money < 50)
            {
                string direction = Console.ReadLine();
                int currentRow = 0;
                int currentCol = 0;
                matrix[bakeryRow, bakeryCol] = '-';
                if (direction == "down")
                {
                    currentRow++;
                }
                else if (direction == "up")
                {
                    currentRow--;
                }
                else if (direction == "left")
                {
                    currentCol--;
                }
                else if (direction == "right")
                {
                    currentCol++;
                }
                if (isValid(bakeryRow + currentRow, bakeryCol + currentCol, matrix))
                {
                    bakeryRow += currentRow;
                    bakeryCol += currentCol;
                }
                else
                {
                    isOutOfBakery = true;
                    break;
                }
                if (char.IsDigit(matrix[bakeryRow, bakeryCol]))
                {
                    money += (int)(matrix[bakeryRow, bakeryCol] - 48);
                    matrix[bakeryRow, bakeryCol] = 'S';
                }
                else if (matrix[bakeryRow, bakeryCol] == 'O')
                {
                    matrix[bakeryRow, bakeryCol] = '-';
                    for (int row = 0; row < matrix.GetLength(0); row++)
                    {
                        for (int col = 0; col < matrix.GetLength(0); col++)
                        {
                            if (matrix[row, col] == 'O')
                            {
                                bakeryRow = row;
                                bakeryCol = col;
                            }
                        }
                    }
                    matrix[bakeryRow, bakeryCol] = 'S';
                }
                else
                {
                    matrix[bakeryRow, bakeryCol] = 'S';
                }
            }
            string result = isOutOfBakery == false ? "Good news! You succeeded in collecting enough money!" : "Bad news, you are out of the bakery.";
            Console.WriteLine($"{result}\nMoney: {money}");
            PrintMatrix(matrix);
        }

        static void PrintMatrix(char[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(0); col++)
                {
                    Console.Write($"{matrix[row,col]}");
                }
                Console.WriteLine();
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
    }
}
