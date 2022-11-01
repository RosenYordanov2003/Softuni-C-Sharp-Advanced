using System;
using System.Collections.Generic;
using System.Text;

namespace Telephony
{
    public class Smartphone : ICallable, IBrowsable
    {
        public string Browse(string urlAddressName)
        {
            bool isValid = true;
            foreach (char symbol in urlAddressName)
            {
                if (char.IsDigit(symbol))
                {
                    isValid = false;
                    break;
                }
            }
            string result = isValid == true ? $"Browsing: {urlAddressName}!" : "Invalid URL!";
            return result;
        }

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
            string result = isValid == true ? $"Calling... {number}" : "Invalid number!";
            return result;
        }
    }
}
