namespace P01_HarvestingFields
{
    using Reflection_and_Attributes_Archive_exercise.Fsctories.Contracts;
    using Reflection_and_Attributes_Archive_exercise.Fsctories.Models;
    using Reflection_and_Attributes_Archive_exercise.Core.Contracts;
    using Reflection_and_Attributes_Archive_exercise.Core.Models;
    public class HarvestingFieldsTest
    {
        public static void Main()
        {
            IFactory factory = new Factory();
            IEngine engine = new Engine(factory);
            engine.Run();
        }
    }
}