using InfernoInfinity.Core.Contracts;
using InfernoInfinity.Core.Models;
using InfernoInfinity.Repositories.Contracts;
using InfernoInfinity.Repositories.Models;

namespace InfernoInfinity
{
    public class Program
    {
        static void Main(string[] args)
        {
            IRepository weaponRepository = new WeaponRepository();
            IEngine engine = new Engine(weaponRepository);
            engine.Run();
        }
    }
}
