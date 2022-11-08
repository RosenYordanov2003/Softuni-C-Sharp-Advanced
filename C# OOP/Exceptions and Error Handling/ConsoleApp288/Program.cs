using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp288
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int countExceptions = 0;
            while (countExceptions < 3)
            {
                string[] tokens = Console.ReadLine().Split(' ');
                string action = tokens[0];
                if (action == "Show")
                {
                    try
                    {
                        int index = 0;
                        bool isNumber = int.TryParse(tokens[1], out index);
                        if (!isNumber)
                        {
                            throw new FormatException("The variable is not in the correct format!");
                        }
                        else if (index < 0 || index >= input.Length)
                        {
                            throw new InvalidOperationException("The index does not exist!");
                        }
                        Console.WriteLine(input[index]);
                    }
                    catch (InvalidOperationException exception)
                    {
                        countExceptions++;
                        Console.WriteLine(exception.Message);
                    }
                    catch (FormatException exception)
                    {
                        countExceptions++;
                        Console.WriteLine(exception.Message);
                    }
                }
                else if (action == "Print")
                {
                    int startIndex = 0;
                    int endIndex = 0;
                    bool isNumber = int.TryParse(tokens[1], out startIndex);
                    bool isNumber1 = int.TryParse(tokens[2], out endIndex);
                    try
                    {
                        if (!isNumber || !isNumber1)
                        {
                            throw new FormatException("The variable is not in the correct format!");
                        }
                        else if (startIndex < 0 || endIndex < 0 || startIndex >= input.Length || endIndex >= input.Length)
                        {
                            throw new InvalidOperationException("The index does not exist!");
                        }
                        Print(input, startIndex, endIndex);
                    }
                    catch (FormatException exception)
                    {
                        countExceptions++;
                        Console.WriteLine(exception.Message);
                    }
                    catch (InvalidOperationException exception)
                    {
                        countExceptions++;
                        Console.WriteLine(exception.Message);
                    }
                }
                else if (action == "Replace")
                {
                    try
                    {
                        int index = 0;
                        int element = 0;
                        bool isIndex = int.TryParse(tokens[1], out index);
                        bool isNumber = int.TryParse(tokens[2], out element);
                        if (!isNumber || !isIndex)
                        {
                            throw new FormatException("The variable is not in the correct format!");
                        }
                        else if (index < 0 || index >= input.Length)
                        {
                            throw new InvalidOperationException("The index does not exist!");
                        }

                        input[index] = element;
                    }
                    catch (InvalidOperationException exception)
                    {
                        countExceptions++;
                        Console.WriteLine(exception.Message);
                    }
                    catch (FormatException exception)
                    {
                        countExceptions++;
                        Console.WriteLine(exception.Message);
                    }
                }
            }
            Console.WriteLine(string.Join(", ", input));
        }

        static void Print(int[] input, int startIndex, int endIndex)
        {
            List<int> list = new List<int>();
            for (int i = startIndex; i <= endIndex; i++)
            {
                list.Add(input[i]);
            }
            Console.WriteLine(string.Join(", ", list));
        }
    }
}

