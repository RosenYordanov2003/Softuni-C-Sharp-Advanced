using System;

namespace Sum_of_Integers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(' ');
            int sum = 0;
            foreach (string item in input)
            {
                try
                {
                    long number = 0;
                    bool IsNumber = long.TryParse(item, out number);
                    if (!IsNumber)
                    {
                        throw new FormatException($"The element '{item}' is in wrong format!");
                    }
                    if (number > Int32.MaxValue || number < Int32.MinValue)
                    {
                        throw new OverflowException($"The element '{item}' is out of range!");
                    }
                    int numberAsInt = Convert.ToInt32(number);
                    sum += numberAsInt;
                }
                catch (FormatException exception)
                {
                    Console.WriteLine(exception.Message);
                }
                catch (OverflowException exception)
                {
                    Console.WriteLine(exception.Message);
                }
                finally
                {
                    Console.WriteLine($"Element '{item}' processed - current sum: {sum}");
                }
            }
            Console.WriteLine($"The total sum of all integers is: {sum}");
        }
    }
}
