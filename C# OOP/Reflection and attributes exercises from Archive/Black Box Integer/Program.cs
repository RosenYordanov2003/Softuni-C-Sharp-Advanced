using System.Reflection;

namespace P02_BlackBoxInteger
{
    using System;
    using System.Linq;

    public class BlackBoxIntegerTests
    {
        public static void Main()
        {
            string command = Console.ReadLine();
            Type type = typeof(BlackBoxInteger);

            object instance = Activator.CreateInstance(type);
            while (true)
            {
                if (command == "END")
                {
                    break;
                }
                string[] tokens = command.Split('_', StringSplitOptions.RemoveEmptyEntries);
                string action = tokens[0];
                int value = int.Parse(tokens[1]);
                MethodInfo[] methods = type.GetMethods(BindingFlags.Instance | BindingFlags.NonPublic);
                foreach (MethodInfo method in methods)
                {
                    if (method.Name==action)
                    {
                        method.Invoke(instance, new object[] { value });
                        break;
                    }
                }

                FieldInfo[] fields = type.GetFields(BindingFlags.Instance|BindingFlags.NonPublic);
                foreach (FieldInfo field in fields)
                {
                    Console.WriteLine(field.GetValue(instance));
                }
                command = Console.ReadLine();
            }
        }
    }
}