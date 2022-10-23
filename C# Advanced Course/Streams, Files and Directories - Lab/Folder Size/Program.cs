using System;
using System.IO;

namespace FolderSize
{
    public class FolderSize
    {
        static void Main()
        {
            string folderPath = @"C:\";
            string outputPath = @"..\..\..\Files\output.txt";

            GetFolderSize(folderPath, outputPath);
        }

        public static void GetFolderSize(string folderPath, string outputFilePath)
        {
            DirectoryInfo directoryInfo = new DirectoryInfo(folderPath);
            FileInfo[] files = directoryInfo.GetFiles();
            long sum = 0;
            foreach (FileInfo file in files)
            {
                sum += file.Length;
            }
            sum = sum / 1024 / 1024;
          File.WriteAllText(outputFilePath, sum.ToString());
        }
    }
}

