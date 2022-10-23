using System;
using System.Linq;
using System.Collections.Generic;
using System.IO;

namespace WordCount
{
    public class WordCount
    {
        static void Main()
        {
            string wordPath = @"..\..\..\Files\words.txt";
            string textPath = @"..\..\..\Files\text.txt";
            string outputPath = @"..\..\..\Files\output.txt";

            CalculateWordCounts(wordPath, textPath, outputPath);
        }

        public static void CalculateWordCounts(string wordsFilePath, string textFilePath, string outputFilePath)
        {

            using (StreamReader reader = new StreamReader(wordsFilePath))
            {
                Dictionary<string, int> commonWords = new Dictionary<string, int>();
                using (StreamReader secondReader = new StreamReader(textFilePath))
                {
                    while (!reader.EndOfStream)
                    {
                        string[] currentLine = reader.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                        currentLine = currentLine.Select(x => x.ToLower()).ToArray();
                        string[] secondLine = secondReader.ReadToEnd().Split(' ',StringSplitOptions.RemoveEmptyEntries);
                        secondLine = secondLine.Select(x => x.ToLower()).ToArray();


                        GetCommonWords(currentLine, secondLine, commonWords);

                    }
                    commonWords = commonWords.OrderByDescending(x => x.Value).ToDictionary(x => x.Key, x => x.Value);
                    using (StreamWriter writer=new StreamWriter(outputFilePath))
                    {
                        foreach (KeyValuePair<string, int> item in commonWords)
                        {
                            writer.WriteLine($"{item.Key} - {item.Value}");
                        }
                    }
                }
            }

        }

        private static void GetCommonWords(string[] currentLine, string[] secondLine, Dictionary<string, int> commonWords)
        {
            for (int i = 0; i < currentLine.Length; i++)
            {
                string currentWord = currentLine[i].Trim(new char[] { ' ', '.', '-', '?', ',' });
                for (int z = 0; z < secondLine.Length; z++)
                {
                    string secondWord = secondLine[z].Trim(new char[] { ' ', '.', '-', '?', ',' });
                    if (currentWord == secondWord)
                    {
                        if (!commonWords.ContainsKey(currentWord))
                        {
                            commonWords[currentWord] = 0;
                        }
                        commonWords[currentWord]++;
                    }
                }
            }
        }
    }
}

