namespace Reflection_and_Attributes_Archive_exercise.Core.Models
{
    using System;
    using Contracts;
    using P01_HarvestingFields;
    using Reflection_and_Attributes_Archive_exercise.Fsctories.Contracts;
    using Reflection_and_Attributes_Archive_exercise.Fsctories.Models;

    public class Engine:IEngine
    {
        private readonly IFactory factory;
        public Engine(IFactory factory)
        {
            this.factory = factory; 
        }
        public void Run()
        {
            Type type = typeof(HarvestingFields);
            IFactory factory = new Factory();
            string command = Console.ReadLine();
            while (true)
            {
                if (command == "HARVEST")
                {
                    break;
                }
                factory.WriteResult(command, type);
                command = Console.ReadLine();
            }
        }
    }
}
