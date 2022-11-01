using Birthday_Celebrations.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Birthday_Celebrations
{
    public class Pet : IBirthdable
    {
        private string name;
        private string birthday;
        public Pet(string name, string birthday)
        {
            Name = name;
            Birthday = birthday;
        }

        public string Birthday
        {
            get { return birthday; }
            set { birthday = value; }
        }
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
    }
}
