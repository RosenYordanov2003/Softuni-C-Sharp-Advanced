namespace Formula1
{
    using Core;
    using Core.Contracts;
    public class StartUp
    {
        public static void Main()
        {
            IEngine engine = new Engine();
            engine.Run();
        }
    }
    //CreatePilot Carlos_Sainz
    //CreateRace Monaco_GP 78
    //AddPilotToRace Monaco_GP Carlos_Sainz
}
