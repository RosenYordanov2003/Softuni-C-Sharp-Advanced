namespace Military_Elite
{
    public class EngineStart
    {
        static void Main(string[] args)
        {
            IEngine engine = new Engine();
            engine.Run();
        }
    }
}
