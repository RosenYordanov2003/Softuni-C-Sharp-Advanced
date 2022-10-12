using System;
using System.Collections.Generic;
using System.Linq;

namespace Csharp_Advanced_Retake_Exam__13_April_2022
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] meals = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            int[] dayliCalories = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(x => int.Parse(x)).ToArray();
            Dictionary<string, int> mealsCalories = new Dictionary<string, int>();
            mealsCalories.Add("salad", 350);
            mealsCalories.Add("soup", 490);
            mealsCalories.Add("pasta", 680);
            mealsCalories.Add("steak", 790);
            Queue<string> queuMeals = new Queue<string>(meals);
            Stack<int> caloriesPerDay = new Stack<int>(dayliCalories);
            int countEatenMeals = 0;
            int mealRemainingCalories = 0;
            while (caloriesPerDay.Any() && queuMeals.Any())
            {
                int currenDayCalories = caloriesPerDay.Pop();
                string currentMeal = queuMeals.Peek();
                if (mealRemainingCalories > 0)
                {
                    currenDayCalories-=mealRemainingCalories;
                    if (currenDayCalories>0)
                    {
                        caloriesPerDay.Push(currenDayCalories);
                    }
                    mealRemainingCalories = 0;
                }
                else if (currenDayCalories - mealsCalories[currentMeal] > 0)
                {
                    currenDayCalories -= mealsCalories[currentMeal];
                    countEatenMeals++;
                    queuMeals.Dequeue();
                    caloriesPerDay.Push(currenDayCalories);
                }
                else if (currenDayCalories - mealsCalories[currentMeal] < 0)
                {
                    mealRemainingCalories = Math.Abs(currenDayCalories - mealsCalories[currentMeal]);
                    countEatenMeals++;
                    queuMeals.Dequeue();
                }
                else if (currenDayCalories - mealsCalories[currentMeal] == 0)
                {
                    queuMeals.Dequeue();
                    countEatenMeals++;
                }

            }
            PrintResult(queuMeals, caloriesPerDay, countEatenMeals);
        }

        static void PrintResult(Queue<string> queuMeals, Stack<int> caloriesPerDay, int countEatenMeals)
        {
            if (!queuMeals.Any())
            {
                Console.WriteLine($"John had {countEatenMeals} meals.");
                Console.WriteLine($"For the next few days, he can eat {string.Join(", ", caloriesPerDay)} calories.");
            }
            else
            {
                Console.WriteLine($"John ate enough, he had {countEatenMeals} meals.");
                Console.WriteLine($"Meals left: {string.Join(", ", queuMeals)}.");
            }
        }
    }
}
