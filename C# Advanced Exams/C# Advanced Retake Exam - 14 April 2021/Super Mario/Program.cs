using System;

namespace Super_Mario
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int marioLives = int.Parse(Console.ReadLine());
            int rowSize = int.Parse(Console.ReadLine());
            char[][] jaggedArray = new char[rowSize][];
            int marioRow = 0;
            int marioCol = 0;
            for (int row = 0; row < rowSize; row++)
            {
                string input = Console.ReadLine();
                jaggedArray[row] = new char[input.Length];
                for (int col = 0; col < input.Length; col++)
                {
                    jaggedArray[row][col] = input[col];
                    if (input[col] == 'M')
                    {
                        marioRow = row;
                        marioCol = col;
                    }
                }
            }
            bool isWinning = false;
            while (marioLives > 0)
            {
                string[] tokens = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string direction = tokens[0];
                int spawnRow = int.Parse(tokens[1]);
                int spawnCol = int.Parse(tokens[2]);
                jaggedArray[spawnRow][spawnCol] = 'B';
                marioLives--;
                int currentRow = 0;
                int currentCol = 0;
                if (direction == "W")
                {
                    currentRow--;
                }
                else if (direction == "S")
                {
                    currentRow++;
                }
                else if (direction == "D")
                {
                    currentCol++;
                }
                else
                {
                    currentCol--;
                }
                if (isValid(marioRow + currentRow, marioCol + currentCol, jaggedArray))
                {
                    jaggedArray[marioRow][marioCol] = '-';
                    marioRow += currentRow;
                    marioCol += currentCol;
                }
                if (jaggedArray[marioRow][marioCol] == 'B')
                {
                    marioLives -= 2;
                    if (marioLives <= 0)
                    {
                        jaggedArray[marioRow][marioCol] = 'X';
                        Console.WriteLine($"Mario died at {marioRow};{marioCol}.");
                        break;
                    }
                    else
                    {
                        jaggedArray[marioRow][marioCol] = 'M';
                    }
                }
                else if (jaggedArray[marioRow][marioCol] == 'P')
                {
                    isWinning = true;
                    jaggedArray[marioRow][marioCol] = '-';
                    break;
                }
                else
                {
                    jaggedArray[marioRow][marioCol] = 'M';
                }
                if (marioLives <= 0)
                {
                    jaggedArray[marioRow][marioCol] = 'X';
                    Console.WriteLine($"Mario died at {marioRow};{marioCol}.");
                    break ;
                }
            }
            if (isWinning)
            {
                Console.WriteLine($"Mario has successfully saved the princess! Lives left: {marioLives}");
            }
            PrintMatrix(jaggedArray);
        }

        static void PrintMatrix(char[][] jaggedArray)
        {
            for (int row = 0; row < jaggedArray.Length; row++)
            {
                for (int col = 0; col < jaggedArray[row].Length; col++)
                {
                    Console.Write($"{jaggedArray[row][col]}");
                }
                Console.WriteLine();
            }
        }

        static bool isValid(int row, int col, char[][] jaggedArray)
        {
            if (row >= 0 && row < jaggedArray.Length && col >= 0 && col < jaggedArray[row].Length)
            {
                return true;
            }
            return false;
        }
    }
}
