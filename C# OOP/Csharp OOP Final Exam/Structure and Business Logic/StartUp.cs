namespace ChristmasPastryShop
{
    using ChristmasPastryShop.Core;
    using ChristmasPastryShop.Core.Contracts;
    using System.IO;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            IEngine engine = new Engine();
            engine.Run();
        }
    }
}
