using P01.Stream_Progress.Contracts;
using System;

namespace P01.Stream_Progress
{
    public class Program
    {
        static void Main()
        {
            IFile musicFile = new Music("Krisko","Ideal Petrov",10,2);
            StreamProgressInfo stram = new StreamProgressInfo(musicFile);
            Console.WriteLine($"{stram.CalculateCurrentPercent()}%");
        }
    }
}
