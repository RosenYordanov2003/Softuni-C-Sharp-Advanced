namespace Vehicles.IO.Contracts
{
    public interface IWriter
    {
        void Write(object obj);
        void WriteLine(object obj);
    }
}
