using System;
using System.Collections.Generic;
using System.Text;

namespace Wild_Farm.Models
{
    public class Food
    {
        public Food(int quantity)
        {
            Quantity = quantity;
        }

        public int Quantity { get; private set; }
    }
}
