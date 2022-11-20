using System.Linq;
using System.Reflection;
using _03BarracksFactory.Data;

namespace _03BarracksFactory.Core
{
    using System;
    using Contracts;

    class Engine : IRunnable
    {
        private IRepository repository;
        private IUnitFactory unitFactory;

        public Engine(IRepository repository, IUnitFactory unitFactory)
        {
            this.repository = repository;
            this.unitFactory = unitFactory;
        }

        public void Run()
        {
            while (true)
            {
                try
                {
                    string input = Console.ReadLine();
                    string[] data = input.Split();
                    string commandName = data[0];
                    string result = InterpredCommand(data, commandName);
                    Console.WriteLine(result);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }

        // TODO: refactor for Problem 4
        private string InterpredCommand(string[] data, string commandName)
        {
            IExecutable commandToExecute = null;
            Type[] types = Assembly.GetExecutingAssembly().GetTypes().Where(t => t.BaseType == typeof(Command)).ToArray();
            foreach (Type type in types)
            {
                if (data[0]==type.Name.ToLower())
                {
                    commandToExecute = (IExecutable)Activator.CreateInstance(type,new object[]{data,this.repository,this.unitFactory});
                    break;
                }
            }

            return commandToExecute.Execute();
        }
    }
}
