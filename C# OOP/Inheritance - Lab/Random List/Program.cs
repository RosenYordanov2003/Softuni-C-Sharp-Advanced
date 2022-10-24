using System;

namespace CustomRandomList
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            RandomList list = new RandomList();
            list.Add("Gosho");
            list.Add("Pesho");
            list.Add("Ivo");
            Console.WriteLine(list.RandomString());
            Console.WriteLine(String.Join(", ", list));
        }
    }
}
