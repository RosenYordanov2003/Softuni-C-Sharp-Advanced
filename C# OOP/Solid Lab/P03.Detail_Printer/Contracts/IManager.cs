using System.Collections.Generic;

namespace P03.Detail_Printer.Contracts
{
    public interface IManager:IEmployee
    {
       public IReadOnlyCollection<string> Documents { get; }
    }
}
