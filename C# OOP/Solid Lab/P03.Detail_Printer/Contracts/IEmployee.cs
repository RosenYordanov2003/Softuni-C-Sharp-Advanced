using System;
using System.Collections.Generic;
using System.Text;

namespace P03.Detail_Printer.Contracts
{
    public interface IEmployee
    {
        public string Name { get; }
        string PrintEmployee();
    }
}
