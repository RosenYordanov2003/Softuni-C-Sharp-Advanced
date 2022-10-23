using System;

namespace Rally_Racing
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int matrixSize = int.Parse(Console.ReadLine());
            int racingNumber = int.Parse(Console.ReadLine());
            string[,] matrix = new string[matrixSize, matrixSize];
            int carRow = 0;
            int carCol = 0;
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                string[] input = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = input[col];
                }
            }
            int traveledDistance = 0;
            string direction;
            bool isFinished = false;
            while ((direction = Console.ReadLine()) != "End")
            {
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
                else if (direction == "up")
                {
                    currentRow--;
                }
                else if (direction == "down")
                {
                    currentRow++;
                }
                carRow += currentRow;
                carCol += currentCol;
                if (matrix[carRow, carCol] == "T")
                {
                    matrix[carRow, carCol] = ".";
                    for (int row = 0; row < matrix.GetLength(0); row++)
                    {
                        for (int col = 0; col < matrix.GetLength(1); col++)
                        {
                            if (matrix[row, col] == "T")
                            {
                                matrix[row, col] = ".";
                                traveledDistance += 30;
                                carRow = row;
                                carCol = col;
                              
                            }
                        }
                    }
                }
                else if (matrix[carRow,carCol]=="F")
                {
                    traveledDistance += 10;
                    isFinished = true;
                    break;
                }
                else
                {
                    traveledDistance += 10;
                }
            }
            matrix[carRow, carCol] = "C";
            string result = isFinished == true ? $"Racing car {racingNumber} finished the stage!" : $"Racing car {racingNumber} DNF.";
            Console.WriteLine(result);
            Console.WriteLine($"Distance covered {traveledDistance} km.");
            PrintMatrix(matrix);
        }
        static void PrintMatrix(string[,] matrix)
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
