using System;
using System.Collections.Generic;
using System.Linq;

namespace Average_Student_Grades
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int countStudents = int.Parse(Console.ReadLine());
            Dictionary<string, List<decimal>> dic = new Dictionary<string, List<decimal>>();
            for (int i = 0; i < countStudents; i++)
            {
                string[] input = Console.ReadLine().Split();
                string studentName = input[0];
                decimal grade = decimal.Parse(input[1]);
                if (!dic.ContainsKey(studentName))
                {
                    dic[studentName] = new List<decimal>();
                }
                dic[studentName].Add(grade);
            }
            PrintResult(dic);
        }

        static void PrintResult(Dictionary<string, List<decimal>> dic)
        {
            foreach (KeyValuePair<string,List<decimal>> item in dic)
            {
                string student=item.Key;
                decimal average=item.Value.Average();
                Console.Write($"{student} -> ");
                foreach (var grade in item.Value)
                {
                    Console.Write($"{grade:f2} ");
                }
                Console.WriteLine($"(avg: {average:f2})");
            }
        }
    }
}
