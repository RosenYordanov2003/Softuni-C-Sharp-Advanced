using _03BarracksFactory.Contracts;

namespace _03BarracksFactory.Data
{
    public class Add : Command
    {
        public Add(string[] data, IRepository repository, IUnitFactory factory) : base(data, repository, factory){}

        public override string Execute()
        {
            string unitType = Data[1];
            IUnit unitToAdd = this.Factory.CreateUnit(unitType);
            this.Repository.AddUnit(unitToAdd);
            string output = unitType + " added!";
            return output;
        }
    }
}
