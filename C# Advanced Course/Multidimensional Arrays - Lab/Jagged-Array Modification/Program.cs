using System;
using System.Linq;

namespace Jagged_Array_Modification
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());
            int[][] jaggedArray = new int[rows][];
            for (int row = 0; row < jaggedArray.Length; row++)
            {
                int[] input = Console.ReadLine().Split(' ').Select(input => int.Parse(input)).ToArray();
                jaggedArray[row] = new int[input.Length];
                for (int col = 0; col < input.Length; col++)
                {
                    jaggedArray[row][col] = input[col];
                }
            }
            string command;
            while ((command=Console.ReadLine())!="END")
            {
                string[] tokens = command.Split(" ");
                string action=tokens[0];
                if (action=="Add")
                {
                    int row = int.Parse(tokens[1]);
                    int col = int.Parse(tokens[2]);
                    int value=int.Parse(tokens[3]);
                    if (row<0||col<0||row>=jaggedArray.Length||col>=jaggedArray[row].Length)
                    {
                        Console.WriteLine("Invalid coordinates");
                    }
                    else
                    {
                        jaggedArray[row][col] += value;
                    }
                   
                }
                else if (action == "Subtract")
                {
                    int row = int.Parse(tokens[1]);
                    int col = int.Parse(tokens[2]);
                    int value = int.Parse(tokens[3]);
                    if (row < 0 || col < 0 || row >= jaggedArray.Length || col >= jaggedArray[row].Length)
                    {
                        Console.WriteLine("Invalid coordinates");
                    }
                    else
                    {
                        jaggedArray[row][col] -= value;
                    }
                }
            }
            PrintArray(jaggedArray);
        }
        static void PrintArray(int[][] jaggedArray)
        {
            for (int row = 0; row <jaggedArray.Length ; row++)
            {
                for (int col = 0; col < jaggedArray[row].Length; col++)
                {
                    Console.Write($"{jaggedArray[row][col]} ");
                }
                Console.WriteLine();
            }
        }
    }
}
