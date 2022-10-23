using System;
using System.Linq;

namespace Warships
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int secondPlayerShips = 0;
            int firstPlayerShips = 0;
            int totalShipsDestroyed = 0;
            int matrixSize = int.Parse(Console.ReadLine());
            string[] cordinates = Console.ReadLine().Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);
            char[,] matrix = new char[matrixSize, matrixSize];
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                char[] input = Console.ReadLine()
                   .Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(char.Parse).ToArray();
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = input[col];
                    if (matrix[row, col] == '>')
                    {
                        secondPlayerShips++;
                    }
                    else if (matrix[row, col] == '<')
                    {
                        firstPlayerShips++;
                    }
                }
            }
            bool isSomeoneWon = false;
            for (int i = 0; i < cordinates.Length - 1; i += 2)
            {

                int row = int.Parse(cordinates[i]);
                int col = int.Parse(cordinates[i + 1]);
                if (isValid(row, col, matrix))
                {
                    if (matrix[row, col] == '>')
                    {
                        matrix[row, col] = 'X';
                        secondPlayerShips--;
                        totalShipsDestroyed++;
                    }
                    else if (matrix[row, col] == '<')
                    {
                        matrix[row, col] = 'X';
                        firstPlayerShips--;
                        totalShipsDestroyed++;
                    }
                    else if (matrix[row,col]=='#')
                    {
                        matrix[row, col] = 'X';
                        MineExplode(matrix, ref firstPlayerShips, ref secondPlayerShips, row, col, ref totalShipsDestroyed);
                    }
                }
                if (firstPlayerShips <= 0)
                {
                    Console.WriteLine($"Player Two has won the game! {totalShipsDestroyed} ships have been sunk in the battle.");
                    isSomeoneWon = true;
                    break;
                }
                else if (secondPlayerShips <= 0)
                {
                    Console.WriteLine($"Player One has won the game! {totalShipsDestroyed} ships have been sunk in the battle.");
                    isSomeoneWon = true;
                    break;
                }
            }
            if (!isSomeoneWon)
            {
                Console.WriteLine($"It's a draw! Player One has {firstPlayerShips} ships left. Player Two has {secondPlayerShips} ships left.");
            }

        }

        static void MineExplode(char[,] matrix, ref int firstPlayerShips, ref int secondPlayerShips, int row, int col, ref int totalShipsDestroyed)
        {
            if (isValid(row - 1, col, matrix) && matrix[row - 1, col] == '>')
            {
                secondPlayerShips--;
                matrix[row - 1, col] = 'X';
                totalShipsDestroyed++;
            }
            else if (isValid(row - 1, col, matrix) && matrix[row - 1, col] == '<')
            {
                firstPlayerShips--;
                matrix[row - 1, col] = 'X';
                totalShipsDestroyed++;
            }
            if (isValid(row + 1, col, matrix) && matrix[row + 1, col] == '>')
            {
                secondPlayerShips--;
                matrix[row + 1, col] = 'X';
                totalShipsDestroyed++;
            }
            else if (isValid(row + 1, col, matrix) && matrix[row + 1, col] == '<')
            {
                firstPlayerShips--;
                matrix[row + 1, col] = 'X';
                totalShipsDestroyed++;
            }
            if (isValid(row, col + 1, matrix) && matrix[row, col + 1] == '<')
            {
                firstPlayerShips--;
                matrix[row, col + 1] = 'X';
                totalShipsDestroyed++;
            }
            else if (isValid(row, col + 1, matrix) && matrix[row, col + 1] == '>')
            {
                secondPlayerShips--;
                matrix[row, col + 1] = 'X';
                totalShipsDestroyed++;
            }
            if (isValid(row, col - 1, matrix) && matrix[row, col - 1] == '>')
            {
                secondPlayerShips--;
                matrix[row, col - 1] = 'X';
                totalShipsDestroyed++;
            }
            else if (isValid(row, col - 1, matrix) && matrix[row, col - 1] == '<')
            {
                firstPlayerShips--;
                matrix[row, col - 1] = 'X';
                totalShipsDestroyed++;
            }
            if (isValid(row + 1, col + 1, matrix) && matrix[row + 1, col + 1] == '>')
            {
                secondPlayerShips--;
                matrix[row + 1, col + 1] = 'X';
                totalShipsDestroyed++;
            }
            else if (isValid(row + 1, col + 1, matrix) && matrix[row + 1, col + 1] == '<')
            {
                firstPlayerShips--;
                matrix[row + 1, col + 1] = 'X';
                totalShipsDestroyed++;
            }
            if (isValid(row + 1, col - 1, matrix) && matrix[row + 1, col - 1] == '>')
            {
                secondPlayerShips--;
                matrix[row + 1, col - 1] = 'X';
                totalShipsDestroyed++;
            }
            else if (isValid(row + 1, col - 1, matrix) && matrix[row + 1, col - 1] == '<')
            {
                firstPlayerShips--;
                matrix[row + 1, col - 1] = 'X';
                totalShipsDestroyed++;
            }
            if (isValid(row - 1, col - 1, matrix) && matrix[row - 1, col - 1] == '>')
            {
                secondPlayerShips--;
                matrix[row - 1, col - 1] = 'X';
                totalShipsDestroyed++;
            }
            else if (isValid(row - 1, col - 1, matrix) && matrix[row - 1, col - 1] == '<')
            {
                firstPlayerShips--;
                matrix[row - 1, col - 1] = 'X';
                totalShipsDestroyed++;
            }
            if (isValid(row - 1, col + 1, matrix) && matrix[row - 1, col + 1] == '>')
            {
                secondPlayerShips--;
                matrix[row - 1, col + 1] = 'X';
                totalShipsDestroyed++;
            }
            else if (isValid(row - 1, col + 1, matrix) && matrix[row - 1, col + 1] == '<')
            {
                firstPlayerShips--;
                matrix[row - 1, col + 1] = 'X';
                totalShipsDestroyed++;
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
