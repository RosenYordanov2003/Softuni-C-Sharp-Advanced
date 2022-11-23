namespace BookingApp
{
    using BookingApp.Core;
    using BookingApp.Core.Contracts;
    public class StartUp
    {
        public static void Main()
        {
            IEngine engine = new Engine();
            engine.Run();
        }
    }
}
