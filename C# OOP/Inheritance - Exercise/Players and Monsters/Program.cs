using System;
namespace PlayersAndMonsters
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            Elf elf = new Elf("Vesko10", 10);
            Console.WriteLine(elf);
            SoulMaster soulMaster = new SoulMaster("Gosho", 1);
            Console.WriteLine(soulMaster);
        }
    }
}