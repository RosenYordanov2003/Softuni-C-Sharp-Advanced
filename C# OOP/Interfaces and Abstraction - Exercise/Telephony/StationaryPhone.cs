using System;
using System.Collections.Generic;
using System.Text;

namespace Telephony
{
    public class StationaryPhone : ICallable
    {
        public string Call(string number)
        {
            bool isValid = true;
            foreach (char item in number)
            {
                if (!char.IsDigit(item))
                {
                    isValid = false;
                    break;
                }
            }
            string result = isValid == true ? $"Dialing... {number}" : "Invalid number!";
            return result;
        }
    }
}
