using System;
using System.Collections.Generic;
using System.Text;

namespace Food_Shortage.Contracts
{
    public interface IBuyer
    {
        public string Name { get; set; }
        public int Food { get; set; }

        void BuyFood();
    }
}
