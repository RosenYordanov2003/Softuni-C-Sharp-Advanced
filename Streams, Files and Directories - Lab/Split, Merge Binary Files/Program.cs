using System;
using System.IO;

namespace SplitMergeBinaryFile
{
    public class SplitMergeBinaryFile
    {
        static void Main()
        {
            string sourceFilePath = @"..\..\..\Files\example.png";
            string joinedFilePath = @"..\..\..\Files\example-joined.png";
            string partOnePath = @"..\..\..\Files\part-1.bin";
            string partTwoPath = @"..\..\..\Files\part-2.bin";

            SplitBinaryFile(sourceFilePath, partOnePath, partTwoPath);
            MergeBinaryFiles(partOnePath, partTwoPath, joinedFilePath);
        }

        public static void SplitBinaryFile(string sourceFilePath, string partOneFilePath, string partTwoFilePath)
        {
            using (FileStream initialPng = new FileStream(sourceFilePath, FileMode.Open))
            {
                if (initialPng.Length % 2 == 0)
                {
                    // int startIndex = 0;
                    using (FileStream partOne = new FileStream(partOneFilePath, FileMode.Create))
                    {
                        byte[] partOneBuffer = new byte[initialPng.Length / 2];
                        initialPng.Read(partOneBuffer, 0, partOneBuffer.Length / 2);
                        partOne.Write(partOneBuffer);
                    }
                    using (FileStream partoTwo = new FileStream(partTwoFilePath, FileMode.Create))
                    {
                        byte[] partTwoBuffer = new byte[initialPng.Length % 2];
                        initialPng.Read(partTwoBuffer, (int)initialPng.Length / 2, partTwoBuffer.Length / 2);
                    }
                }
                else
                {
                    using (FileStream partOne = new FileStream(partOneFilePath, FileMode.Create))
                    {
                        byte[] partOneBuffer = new byte[initialPng.Length / 2 + 1];
                        initialPng.Read(partOneBuffer, 0, partOneBuffer.Length);
                        partOne.Write(partOneBuffer);
                    }
                    using (FileStream partoTwo = new FileStream(partTwoFilePath, FileMode.Create))
                    {
                       
                        byte[] partTwoBuffer = new byte[initialPng.Length / 2];
                       initialPng.Read(partTwoBuffer);
                        partoTwo.Write(partTwoBuffer);
                    }
                }
            }
        }

        public static void MergeBinaryFiles(string partOneFilePath, string partTwoFilePath, string joinedFilePath)
        {
            using (FileStream mergePart = new FileStream(joinedFilePath, FileMode.Create))
            {
                using (FileStream partOne = new FileStream(partOneFilePath, FileMode.Open))
                {
                    byte[] partOneBuffer = new byte[partOne.Length];
                    partOne.Read(partOneBuffer);
                    mergePart.Write(partOneBuffer);
                }
                using (FileStream secondPart = new FileStream(partOneFilePath, FileMode.Open))
                {
                    byte[] secondPartBuffer = new byte[secondPart.Length];
                    secondPart.Read(secondPartBuffer);
                    mergePart.Write(secondPartBuffer);
                }
            }
        }
    }
}
