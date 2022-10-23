using System;
using System.Collections.Generic;
using System.Linq;

namespace Pawn_Wars
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int matrixSize = 8;
            char[,] matrix = new char[matrixSize, matrixSize];
            int whitePawnRow = 0;
            int whitePawCol = 0;
            int blackPawnRow = 0;
            int blackPawnCol = 0;
            Dictionary<int, char> ranks = new Dictionary<int, char>();
            ranks.Add(1, 'a');
            ranks.Add(2, 'b');
            ranks.Add(3, 'c');
            ranks.Add(4, 'd');
            ranks.Add(5, 'e');
            ranks.Add(6, 'f');
            ranks.Add(7, 'g');
            ranks.Add(8, 'h');
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                char[] input = Console.ReadLine().Replace(" ", "").ToCharArray();
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = input[col];
                    if (matrix[row, col] == 'w')
                    {
                        whitePawnRow = row;
                        whitePawCol = col;
                    }
                    else if (matrix[row, col] == 'b')
                    {
                        blackPawnRow = row;
                        blackPawnCol = col;
                    }
                }
            }
            // white down
            //black up
            bool isWhiteQueen = false;
            while (whitePawnRow != 0 && blackPawnRow != 7)
            {
                // check white Pawn diagonals
                int leftDiagonalRow = whitePawnRow - 1;
                int leftDiagonalCol = whitePawCol - 1;
                int rightDiagonalRow = whitePawnRow - 1;
                int rightDiagonalCol = whitePawCol + 1;
                if (isValid(leftDiagonalRow, leftDiagonalCol, matrix))
                {
                    if (matrix[leftDiagonalRow, leftDiagonalCol] == 'b')
                    {

                        Console.WriteLine($"Game over! White capture on {ranks[leftDiagonalCol + 1]}{matrix.GetLength(0) - leftDiagonalRow}.");
                        return;
                    }
                }
                if (isValid(rightDiagonalRow, rightDiagonalCol, matrix))
                {
                    if (matrix[rightDiagonalRow, rightDiagonalCol] == 'b')
                    {
                        Console.WriteLine($"Game over! White capture on {ranks[rightDiagonalCol + 1]}{matrix.GetLength(0) - rightDiagonalRow}.");
                        return;
                    }
                }
                matrix[whitePawnRow, whitePawCol] = '-';
                whitePawnRow--;
                matrix[whitePawnRow, whitePawCol] = 'w';
                if (whitePawnRow == 0)
                {
                    isWhiteQueen = true;
                }
                int blackLeftDiagonalRow = blackPawnRow + 1;
                int blackLeftDiagonalCol = blackPawnCol - 1;
                if (isValid(blackLeftDiagonalRow, blackLeftDiagonalCol, matrix))
                {
                    if (matrix[blackLeftDiagonalRow, blackLeftDiagonalCol] == 'w')
                    {
                        Console.WriteLine($"Game over! Black capture on {ranks[blackLeftDiagonalCol + 1]}{matrix.GetLength(0) - blackLeftDiagonalRow}.");
                        return;
                    }
                }
                int blackRightDiagonalRow = blackPawnRow + 1;
                int blackRightDiagonaCol = blackPawnCol + 1;
                if (isValid(blackRightDiagonalRow, blackRightDiagonaCol, matrix))
                {
                    if (matrix[blackRightDiagonalRow, blackRightDiagonaCol] == 'w')
                    {
                        Console.WriteLine($"Game over! Black capture on {ranks[blackRightDiagonaCol + 1]}{matrix.GetLength(0) - blackLeftDiagonalRow}.");
                        return;
                    }
                }
                matrix[blackPawnRow, blackPawnCol] = '-';
                blackPawnRow++;
                matrix[blackPawnRow, blackPawnCol] = 'b';

            }
            if (isWhiteQueen)
            {
                Console.WriteLine($"Game over! White pawn is promoted to a queen at {ranks[whitePawCol + 1]}8.");
            }
            else
            {
                Console.WriteLine($"Game over! Black pawn is promoted to a queen at {ranks[blackPawnCol + 1]}1.");
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

        static bool isValid(int leftDiagonalRow, int leftDiagonalCol, char[,] matrix)
        {
            if (leftDiagonalRow >= 0 && leftDiagonalRow < matrix.GetLength(0) && leftDiagonalCol >= 0 && leftDiagonalCol < matrix.GetLength(1))
            {
                return true;
            }
            return false;
        }
    }
}
