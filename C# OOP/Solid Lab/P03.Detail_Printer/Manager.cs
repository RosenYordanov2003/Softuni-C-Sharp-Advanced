using P03.Detail_Printer.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace P03.DetailPrinter
{
    public class Manager : Employee, IManager
    {
        public Manager(string name, ICollection<string> documents) : base(name)
        {
            this.Documents = new List<string>(documents);
        }
        public IReadOnlyCollection<string> Documents { get; set; }
        public override string PrintEmployee()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(base.PrintEmployee());
            foreach (string document in Documents)
            {
                sb.AppendLine(document);
            }
            return sb.ToString().Trim();
        }
    }
}
