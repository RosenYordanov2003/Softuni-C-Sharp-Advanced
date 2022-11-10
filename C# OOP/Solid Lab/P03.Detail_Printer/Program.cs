using P03.Detail_Printer.Contracts;
using System;
using System.Collections.Generic;

namespace P03.DetailPrinter
{
    class Program
    {
        static void Main()
        {
            ICollection<string> documents = new List<string> { "Certificates","Diplomi"};
            IEmployee manager = new Manager("Vesko",documents);
            IEmployee employee =new Employee("Gosho");
            DetailsPrinter printer = new DetailsPrinter(new List<IEmployee> { manager,employee});
            printer.PrintDetails();
        }
    }
}
