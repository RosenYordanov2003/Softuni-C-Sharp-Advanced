using System;
using System.Linq;

namespace Primary_Diagonal
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            int[,] matrix = new int[size, size];
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                int[] input = Console.ReadLine().Split(' ').Select(input => int.Parse(input)).ToArray();
                for (int colums = 0; colums < matrix.GetLength(1); colums++)
                {
                    matrix[row, colums] = input[colums];
                }
            }
            FindDiagonalSum(matrix);
        }

        static void FindDiagonalSum(int[,] matrix)
        {
            int sum = 0;
            int index = 0;
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (col==index)
                    {
                        int number = matrix[row, col];
                        sum+=number;
                        index++;
                        break;
                    }
                }
            }
            Console.WriteLine(sum);
        }
    }
}
