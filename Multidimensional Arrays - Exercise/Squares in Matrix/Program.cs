using System;
using System.Linq;

namespace Squares_in_Matrix
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] matrixInformation = Console.ReadLine().Split(' ',StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int rows = matrixInformation[0];
            int columns = matrixInformation[1];
            char[,] matrix = new char[rows, columns];
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                char[] input = Console.ReadLine().Split(' ',StringSplitOptions.RemoveEmptyEntries).Select(char.Parse).ToArray();
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = input[col];
                }
            }
            FindEqualSquares(matrix, rows, columns);
        }

        static void FindEqualSquares(char[,] matrix, int rowSize, int columnSize)
        {
            int countEqualSquares = 0;
            for (int row = 0; row < matrix.GetLength(0); row++)
            {

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (row + 1 < rowSize && col + 1 < columnSize)
                    {
                        char result = '0';
                        if (matrix[row,col]==matrix[row,col+1])
                        {
                            result=matrix[row,col];
                            if (matrix[row + 1, col] == matrix[row + 1, col + 1])
                            {
                                if (matrix[row + 1, col] == result)
                                {
                                    countEqualSquares++;
                                }
                            }
                        }
                      
                        else
                        {
                            continue;
                        }
                    }
                    else
                    {
                        continue;
                    }
                }
            }
            Console.WriteLine(countEqualSquares);
        }
    }
}
