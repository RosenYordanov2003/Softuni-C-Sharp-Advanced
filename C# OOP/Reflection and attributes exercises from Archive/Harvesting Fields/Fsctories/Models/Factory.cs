using System.Linq;

namespace Reflection_and_Attributes_Archive_exercise.Fsctories.Models
{
    using System;
    using System.Reflection;
    using Contracts;
    public class Factory : IFactory
    {
        public void WriteResult(string command, Type type)
        {
            if (command == "private")
            {
                GetPrivateFieldsMethod(type);
            }
            else if (command == "public")
            {
                GetPublicFields(type);
            }
            else if (command == "protected")
            {
                GetProtectedFields(type);
            }
            else
            {
                GetAllFields(type);
            }
        }
        static void GetPrivateFieldsMethod(Type type)
        {
            FieldInfo[] privateFields = type.GetFields(BindingFlags.NonPublic | BindingFlags.Instance);
            foreach (FieldInfo privateField in privateFields.Where(f => f.IsPrivate))
            {
                Console.WriteLine($"private {privateField.FieldType.Name} {privateField.Name}");
            }
        }
        static void GetPublicFields(Type type)
        {
            FieldInfo[] publicFields = type.GetFields(BindingFlags.Public | BindingFlags.Instance);
            foreach (FieldInfo publicField in publicFields)
            {
                Console.WriteLine($"public {publicField.FieldType.Name} {publicField.Name}");
            }
        }
        static void GetProtectedFields(Type type)
        {
            FieldInfo[] protectedFields = type.GetFields(BindingFlags.NonPublic | BindingFlags.Instance);
            foreach (FieldInfo protectedField in protectedFields.Where(f => f.IsPrivate == false))
            {
                Console.WriteLine($"protected {protectedField.FieldType.Name} {protectedField.Name}");
            }
        }
        static void GetAllFields(Type type)
        {
            FieldInfo[] allFields = type.GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
            foreach (FieldInfo field in allFields)
            {
                if (field.IsPrivate)
                {
                    Console.WriteLine($"private {field.FieldType.Name} {field.Name}");
                }
                else if (field.IsPublic)
                {
                    Console.WriteLine($"public {field.FieldType.Name} {field.Name}");
                }
                else
                {
                    Console.WriteLine($"protected {field.FieldType.Name} {field.Name}");
                }
            }
        }
    }
}
