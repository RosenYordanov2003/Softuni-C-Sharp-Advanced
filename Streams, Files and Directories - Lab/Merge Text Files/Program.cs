using System;
using System.Linq;
using System.IO;
using System.Collections.Generic;

namespace MergeFiles
{
    public class MergeFiles
    {
        static void Main()
        {
            var firstInputFilePath = @"..\..\..\Files\input1.txt";
            var secondInputFilePath = @"..\..\..\Files\input2.txt";
            var outputFilePath = @"..\..\..\Files\output.txt";

            MergeTextFiles(firstInputFilePath, secondInputFilePath, outputFilePath);
        }
        public static void MergeTextFiles(string firstInputFilePath, string secondInputFilePath, string outputFilePath)
        {
            List<string> merged = new List<string>();
            using (StreamReader reader = new StreamReader(firstInputFilePath))
            {
                while (!reader.EndOfStream)
                {
                    merged.Add(reader.ReadLine());
                }
            }
            using (StreamReader secondReader = new StreamReader(secondInputFilePath))
            {
                while (!secondReader.EndOfStream)
                {
                    merged.Add(secondReader.ReadLine());
                }
            }
            using (StreamWriter writer = new StreamWriter(outputFilePath))
            {
                for (int i = 0; i < merged.Count; i++)
                {
                    string currentLine = merged[i];
                    writer.WriteLine(currentLine);
                }
            }
        }
    }

}




