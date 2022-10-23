using System;
using System.Linq;

namespace Jagged_Array_Manipulator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());
            int[][] jaggedArray = new int[rows][];
            for (int row = 0; row < jaggedArray.Length; row++)
            {
                int[] input = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                jaggedArray[row] = new int[input.Length];
                for (int col = 0; col < jaggedArray[row].Length; col++)
                {
                    jaggedArray[row][col] = input[col];
                }
            }
            for (int row = 0; row < jaggedArray.Length; row++)
            {

                if (row + 1 < rows)
                {
                    if (jaggedArray[row].Length == jaggedArray[row + 1].Length)
                    {
                        int curretnRow = row;
                        int nextRow = row + 1;
                        for (int i = curretnRow; i <= nextRow; i++)
                        {
                            for (int z = 0; z < jaggedArray[i].Length; z++)
                            {
                                int currentElement = jaggedArray[i][z];
                                currentElement *= 2;
                                jaggedArray[i][z] = currentElement;
                            }
                        }
                    }
                    else
                    {
                        int curretnRow = row;
                        int nextRow = row + 1;
                        for (int i = curretnRow; i <= nextRow; i++)
                        {
                            for (int z = 0; z < jaggedArray[i].Length; z++)
                            {
                                int currentElement = jaggedArray[i][z];
                                currentElement /= 2;
                                jaggedArray[i][z] = currentElement;
                            }
                        }
                    }
                }
                else
                {
                    continue;
                }
            }
            string command;
            while ((command = Console.ReadLine()) != "End")
            {
                string[] tokens = command.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string action = tokens[0];
                if (action == "Add")
                {
                    int rowToCheck = int.Parse(tokens[1]);
                    int colomnToCheck = int.Parse(tokens[2]);
                    int valueToAdd = int.Parse(tokens[3]);
                    if ((rowToCheck < rows && rowToCheck >= 0) && (colomnToCheck < jaggedArray[rowToCheck].Length && colomnToCheck >= 0))
                    {
                        jaggedArray[rowToCheck][colomnToCheck] += valueToAdd;
                    }
                }
                else
                {
                    int rowToCheck = int.Parse(tokens[1]);
                    int colomnToCheck = int.Parse(tokens[2]);
                    int valueToSubtract = int.Parse(tokens[3]);
                    if ((rowToCheck < rows && rowToCheck >= 0) && (colomnToCheck < jaggedArray[rowToCheck].Length && colomnToCheck >= 0))
                    {
                        jaggedArray[rowToCheck][colomnToCheck] -= valueToSubtract;
                    }
                }
            }

            PrintJaggedArray(jaggedArray);
        }

        static void PrintJaggedArray(int[][] jaggedArray)
        {
            for (int row = 0; row < jaggedArray.Length; row++)
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
