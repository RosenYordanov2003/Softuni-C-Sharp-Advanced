using System;

namespace Survivor
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());
            string[][] jaggedArray = new string[rows][];
            for (int row = 0; row < jaggedArray.Length; row++)
            {
                string[] tokens = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                jaggedArray[row] = new string[tokens.Length];
                for (int col = 0; col < jaggedArray[row].Length; col++)
                {
                    jaggedArray[row][col] = tokens[col];
                }
            }
            string command = string.Empty;
            int collectTokens = 0;
            int oponentTokens = 0;
            while ((command = Console.ReadLine()) != "Gong")
            {
                string[] tokens = command.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string action = tokens[0];
                if (action == "Find")
                {
                    int rowIndex = int.Parse(tokens[1]);
                    int colIndex = int.Parse(tokens[2]);
                    if (isValid(rowIndex, colIndex, jaggedArray))
                    {
                        if (jaggedArray[rowIndex][colIndex] == "T")
                        {
                            jaggedArray[rowIndex][colIndex] = "-";
                            collectTokens++;
                        }
                    }
                }
                else
                {
                    int rowIndex = int.Parse(tokens[1]);
                    int colIndex = int.Parse(tokens[2]);
                    string direction = tokens[3];
                    if (isValid(rowIndex, colIndex, jaggedArray))
                    {
                        if (jaggedArray[rowIndex][colIndex] == "T")
                        {
                            oponentTokens++;
                            jaggedArray[rowIndex][colIndex] = "-";
                        }
                        oponentTokens += MoveOponent(rowIndex, colIndex, direction, jaggedArray)
;
                    }
                }
            }
            PrintMatrix(jaggedArray);
            Console.WriteLine($"Collected tokens: {collectTokens}");
            Console.WriteLine($"Opponent's tokens: {oponentTokens}");
        }

        static int MoveOponent(int rowIndex, int colIndex, string direction, string[][] jaggedArray)
        {
            int oponentTokens = 0;
            if (direction == "up")
            {
                int count = 0;
                while (count < 3)
                {
                    rowIndex--;
                    if (isValid(rowIndex, colIndex, jaggedArray))
                    {
                        if (jaggedArray[rowIndex][colIndex] == "T")
                        {
                            oponentTokens++;
                            jaggedArray[rowIndex][colIndex] = "-";
                        }
                    }
                    else
                    {
                        break;
                    }
                    count++;
                }
            }
            else if (direction == "down")
            {
                int count = 0;
                while (count < 3)
                {
                    rowIndex++;
                    if (isValid(rowIndex, colIndex, jaggedArray))
                    {
                        if (jaggedArray[rowIndex][colIndex] == "T")
                        {
                            oponentTokens++;
                            jaggedArray[rowIndex][colIndex] = "-";
                        }
                    }
                    else
                    {
                        break;
                    }
                    count++;
                }
            }
            else if (direction == "left")
            {
                int count = 0;
                while (count < 3)
                {
                    colIndex--;
                    if (isValid(rowIndex, colIndex, jaggedArray))
                    {
                        if (jaggedArray[rowIndex][colIndex] == "T")
                        {
                            oponentTokens++;
                            jaggedArray[rowIndex][colIndex] = "-";
                        }
                    }
                    else
                    {
                        break;
                    }
                    count++;
                }
            }
            else if (direction == "right")
            {
                int count = 0;
                while (count < 3)
                {
                    colIndex++;
                    if (isValid(rowIndex, colIndex, jaggedArray))
                    {
                        if (jaggedArray[rowIndex][colIndex] == "T")
                        {
                            oponentTokens++;
                            jaggedArray[rowIndex][colIndex] = "-";
                        }
                    }
                    else
                    {
                        break;
                    }
                    count++;
                }
            }
            return oponentTokens;
        }

        static bool isValid(int rowIndex, int colIndex, string[][] jaggedArray)
        {
            if (rowIndex < 0 || colIndex < 0 || rowIndex >= jaggedArray.Length || colIndex >= jaggedArray[rowIndex].Length)
            {
                return false;
            }
            return true;
        }

        static void PrintMatrix(string[][] jaggedArray)
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
