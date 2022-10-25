using System;
namespace Zoo
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            Mammal mammal = new Mammal("Bear");
            Console.WriteLine(mammal.Name);
            Snake snake = new Snake("python");
            Console.WriteLine(snake.Name);
        }
    }
}
