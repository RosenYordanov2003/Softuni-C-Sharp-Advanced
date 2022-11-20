using _03BarracksFactory.Contracts;

namespace _03BarracksFactory.Data
{
    public abstract class Command : IExecutable
    {
        private string[] data;
        private IRepository repository;
        private IUnitFactory factory;

        protected Command(string[] data, IRepository repository, IUnitFactory factory)
        {
            Data = data;
            Repository = repository;
            Factory = factory;
        }

        protected string[] Data
        {
            get => data;
            private set => this.data = value;
        }
        protected IRepository Repository
        {
            get => repository;
            private set => this.repository = value;
        }
        protected IUnitFactory Factory
        {
            get => factory;
            private set => this.factory = value;
        }
        public abstract string Execute();
    }
}
