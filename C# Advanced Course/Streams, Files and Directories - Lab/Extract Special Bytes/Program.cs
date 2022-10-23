using System;
using System.IO;
using System.Text;

namespace ExtractBytes
{
    public class ExtractBytes
    {
        static void Main()
        {
            string binaryFilePath = @"..\..\..\Files\example.png";
            string bytesFilePath = @"..\..\..\Files\bytes.txt";
            string outputPath = @"..\..\..\Files\output.bin";

            ExtractBytesFromBinaryFile(binaryFilePath, bytesFilePath, outputPath);
        }

        public static void ExtractBytesFromBinaryFile(string binaryFilePath, string bytesFilePath, string outputPath)
        {
            using (FileStream imageBinary = new FileStream(binaryFilePath, FileMode.Open))
            {
                using (FileStream bytes = new FileStream(bytesFilePath, FileMode.Open))
                {
                    byte[] bytesBuffer = new byte[bytes.Length];
                    bytes.Read(bytesBuffer, 0, (int)bytes.Length);
                    byte[] imageBuffer = new byte[imageBinary.Length];
                    imageBinary.Read(imageBuffer, 0, (int)imageBinary.Length);
                    using (FileStream output = new FileStream(outputPath, FileMode.Create))
                    {
                        for (int i = 0; i < imageBuffer.Length; i++)
                        {
                            for (int z = 0; z < bytesBuffer.Length; z++)
                            {
                                if (imageBuffer[i] == bytesBuffer[z])
                                {
                                    output.Write(new byte[] { imageBuffer[i] });
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}

