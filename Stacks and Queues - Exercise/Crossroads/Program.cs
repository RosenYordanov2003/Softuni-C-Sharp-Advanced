using System;
using System.Linq;
using System.Collections.Generic;
namespace Crossroads
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int greenLightDuration = int.Parse(Console.ReadLine());
            int originalGreenLightDuration = greenLightDuration;
            int freeWindowDuration = int.Parse(Console.ReadLine());

            Queue<string> queue = new Queue<string>();
            string command = string.Empty;
            int countPassedCars = 0;
            bool isEveryOneSafe = true;
            while ((command = Console.ReadLine()) != "END")
            {
                if (command != "green")
                {
                    queue.Enqueue(command);
                    continue;
                }
                else
                {
                    greenLightDuration = originalGreenLightDuration;
                    while (greenLightDuration>0&&queue.Count!=0)
                    {
                        string currentCar = queue.Peek();
                        if (currentCar.Length <= greenLightDuration)
                        {
                            queue.Dequeue();
                            greenLightDuration -= currentCar.Length;
                            countPassedCars++;
                        }
                        else if (currentCar.Length - greenLightDuration <= freeWindowDuration)
                        {
                            queue.Dequeue();
                            greenLightDuration = 0;
                            countPassedCars++;
                        }
                        else
                        {
                            Console.WriteLine("A crash happened!");
                            char characterHit = currentCar[greenLightDuration+freeWindowDuration];
                            Console.WriteLine($"{currentCar} was hit at {characterHit}.");
                            isEveryOneSafe = false;
                            break;
                        }
                    }
                }
                if (!isEveryOneSafe)
                {
                    break;
                }
            }
            if (isEveryOneSafe)
            {
                Console.WriteLine($"Everyone is safe.");
                Console.WriteLine($"{countPassedCars} total cars passed the crossroads.");
            }
        }
    }
}
