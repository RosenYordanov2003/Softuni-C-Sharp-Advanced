using _03BarracksFactory.Contracts;

namespace _03BarracksFactory.Data
{
    public class Report:Command
    {
        public Report(string[] data, IRepository repository, IUnitFactory factory) : base(data, repository, factory){}

        public override string Execute()
        {
            return  this.Repository.Statistics;
        }
    }
}
