using System;
using System.Collections.Generic;
using System.Linq;

namespace Filter_by_Age
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Student> students = new List<Student>();
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split(", ");
                string name = input[0];
                int ages = int.Parse(input[1]);
                Student currentStudent = new Student(name, ages);
                students.Add(currentStudent);
            }
            string yearCondition = Console.ReadLine();
            int ageCondiion = int.Parse(Console.ReadLine());
            string formtatToPrint = Console.ReadLine();
            Func<Student, int, bool> filter = FilterFunction(yearCondition);
            students = students.Where(s => filter(s, ageCondiion)).ToList();
            Action<Student> print = PrintResult(formtatToPrint);
            students.ForEach(s => print(s));
        }

        static Action<Student> PrintResult(string formtatToPrint)
        {
            if (formtatToPrint == "name")
            {
                return (s) => Console.WriteLine(s.Name);
            }
            else if (formtatToPrint == "age")
            {
                return (s) => Console.WriteLine(s.Ages);
            }
            else
            {
                return (s) => Console.WriteLine($"{s.Name} - {s.Ages}");
            }
        }

        static Func<Student, int, bool> FilterFunction(string yearCondition)
        {
            if (yearCondition == "older")
            {
                return (s, age) => s.Ages >= age;
            }
            else if (yearCondition == "younger")
            {
                return (s, age) => s.Ages <= age;
            }
            return null;
        }
    }
    class Student
    {
        public Student(string name, int age)
        {
            this.Name = name;
            this.Ages = age;
        }
        public string Name { get; set; }
        public int Ages { get; set; }
    }
}
