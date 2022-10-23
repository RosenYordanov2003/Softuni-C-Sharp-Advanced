using System;
using System.Linq;
namespace Symbol_in_Matrix
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int matrixSize = int.Parse(Console.ReadLine());
            char[,] matrix = new char[matrixSize, matrixSize];
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                string input = Console.ReadLine();
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col]= input[col];
                }
            }
            char symbolToFind = char.Parse(Console.ReadLine());
            FindSymbol(matrix, symbolToFind);
        }


        static void FindSymbol(char[,] matrix, char symbolToFind)
        {
            int rowIndex = 0;
            int columnIndex = 0;
            bool isFind = false;
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    char currentInput = matrix[row, col];
                    if (currentInput == symbolToFind)
                    {
                        columnIndex = col;
                        rowIndex = row;
                        isFind = true;
                        break;
                    }
                }
                if (isFind)
                {
                    break;
                }
            }
            if (isFind)
            {
                Console.WriteLine($"{(rowIndex, columnIndex)}");
            }
            else
            {
                Console.WriteLine($"{symbolToFind} does not occur in the matrix ");
            }
        }
    }
}
