using System;
using System.Linq;

namespace Square_With_Maximum_Sum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] matrixInformation = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();
            int rowSize = matrixInformation[0];
            int columnSize = matrixInformation[1];
            int[,] matrix = new int[rowSize, columnSize];
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                int[] input = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                for (int column = 0; column < matrix.GetLength(1); column++)
                {
                    matrix[row, column] = input[column];
                }
            }
            FindTheBiggestSquare(matrix,rowSize,columnSize);
        }

        static void FindTheBiggestSquare(int[,] matrix,int rowSize,int columnSize)
        {
            int sum = 0;
            int max = int.MinValue;
            int rowIndex = 0;
            int colIndex = 0;
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (row+1<rowSize&&col+1<columnSize&&row+1>0&&col+1>0)
                    {
                        sum += matrix[row,col] + matrix[row,col+1] + matrix[row+1,+col] + matrix[row+1, col+1];
                        if (sum>max)
                        {
                            max = sum;
                            rowIndex = row;
                            colIndex = col;
                        }
                    }
                    else
                    {
                        continue;
                    }
                    sum = 0;
                }
            }
            for (int row = rowIndex; row <=rowIndex+1 ; row++)
            {
                for (int col = colIndex; col <=colIndex+1 ; col++)
                {
                    Console.Write($"{matrix[row,col]} ");
                }
                Console.WriteLine();
            }
            Console.WriteLine(max);

        }
    }
}
