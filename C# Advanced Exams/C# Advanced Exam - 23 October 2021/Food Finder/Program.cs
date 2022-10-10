using System;
using System.Collections.Generic;
using System.Linq;

namespace Csharp_Advanced_Exam__23_October_2021
{
    internal class Program
    {
        static void Main(string[] args)
        {
            char[] vowelsArray = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(x => char.Parse(x)).ToArray();
            char[] consonantsArray = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(x => char.Parse(x)).ToArray();
            Queue<char> vowelsLetters = new Queue<char>(vowelsArray);
            Stack<char> consonantsLetters = new Stack<char>(consonantsArray);
            Dictionary<string, HashSet<char>> dictionary = new Dictionary<string, HashSet<char>>();
            dictionary["pear"] = new HashSet<char>();
            dictionary["flour"] = new HashSet<char>();
            dictionary["pork"] = new HashSet<char>();
            dictionary["olive"] = new HashSet<char>();
            while (consonantsLetters.Any())
            {
                char currentVolew = vowelsLetters.Dequeue();
                char currentConsonant = consonantsLetters.Pop();
                foreach (KeyValuePair<string, HashSet<char>> item in dictionary)
                {
                    string currentKey = item.Key;
                    if (currentKey.Contains(currentVolew))
                    {
                        item.Value.Add(currentVolew);
                    }
                    if (currentKey.Contains(currentConsonant))
                    {
                        item.Value.Add(currentConsonant);
                    }
                }
                vowelsLetters.Enqueue(currentVolew);
            }
            PrintResult(dictionary);
        }

        static void PrintResult(Dictionary<string, HashSet<char>> dictionary)
        {

            var matchedWords = dictionary.Where(x => x.Value.Count == x.Key.Length).ToDictionary(x => x.Key, x => x.Value);

            Console.WriteLine($"Words found: {matchedWords.Count}");
            foreach (var item in matchedWords)
            {
                Console.WriteLine(item.Key);
            }
        }
    }
}
