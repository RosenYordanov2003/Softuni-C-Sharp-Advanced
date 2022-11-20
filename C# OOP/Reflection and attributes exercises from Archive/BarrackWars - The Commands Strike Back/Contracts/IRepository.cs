namespace _03BarracksFactory.Contracts
{
    public interface IRepository
    {
        void AddUnit(IUnit unit);
        string Statistics { get; }
        string RemoveUnit(string unitType);
    }
}
