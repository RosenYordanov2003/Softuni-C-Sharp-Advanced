namespace Reflection_and_Attributes_Archive_exercise.Fsctories.Contracts
{
    using  System;
    public interface IFactory
    {
        void WriteResult(string command,Type type);
    }
}
