using System;

namespace Snake
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int snakeEatenFood = 0;
            int matrixSize = int.Parse(Console.ReadLine());
            int snakeRow = 0;
            int snakeCol = 0;
            char[,] matrix = new char[matrixSize, matrixSize];
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                char[] input = Console.ReadLine().Replace(" ", "").ToCharArray();
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = input[col];
                    if (matrix[row,col]=='S')
                    {
                        snakeRow = row;
                        snakeCol = col;
                    }
                }
            }
            bool isOutside = false;
            while (snakeEatenFood < 10)
            {
                matrix[snakeRow, snakeCol] = '.';
                string direction = Console.ReadLine();
                int currentRow = 0;
                int currentCol = 0;
                if (direction == "right")
                {
                    currentCol++;
                }
                else if (direction == "left")
                {
                    currentCol--;
                }
                else if (direction == "down")
                {
                    currentRow++;
                }
                else if (direction == "up")
                {
                    currentRow--;
                }
                if (isValid(snakeRow + currentRow, snakeCol + currentCol, matrix))
                {
                    snakeRow += currentRow;
                    snakeCol += currentCol;
                }
                else
                {
                    isOutside = true;
                    break;
                }
                if (matrix[snakeRow, snakeCol] == '*')
                {
                    matrix[snakeRow, snakeCol] = 'S';
                    snakeEatenFood++;
                }
                else if (matrix[snakeRow, snakeCol] == 'B')
                {
                    matrix[snakeRow, snakeCol] = '.';
                    bool isFind = false;
                    for (int row = 0; row < matrix.GetLength(0); row++)
                    {
                        for (int col = 0; col < matrix.GetLength(1); col++)
                        {
                            if (matrix[row, col] == 'B')
                            {
                                matrix[row, col] = 'S';
                                snakeRow = row;
                                snakeCol = col;
                                isFind = true;
                                break;
                            }
                        }
                        if (isFind)
                        {
                            break;
                        }
                    }
                }
                else
                {
                    matrix[snakeRow, snakeCol] = 'S';
                }
                //Console.WriteLine(new string('-',30));
                //PrintMatrix(matrix);
                //Console.WriteLine(new string('-', 30));
            }
            string result = isOutside == true ? "Game over!" : "You won! You fed the snake.";
            Console.WriteLine(result);
            Console.WriteLine($"Food eaten: {snakeEatenFood}");
            PrintMatrix(matrix);
        }

        static void PrintMatrix(char[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
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
