using System;

namespace Telephony
{
    public class Program
    {
        static void Main(string[] args)
        {
            string[] phoneNumbers = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            string[]browsers = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i <phoneNumbers.Length; i++)
            {
                string currentPhoneNumber = phoneNumbers[i];
                if (currentPhoneNumber.Length==10)
                {
                    Smartphone smartPhone = new Smartphone();
                    Console.WriteLine(smartPhone.Call(currentPhoneNumber));
                }
                else if(currentPhoneNumber.Length==7)
                {
                    StationaryPhone stationaryPhone = new StationaryPhone();
                    Console.WriteLine(stationaryPhone.Call(currentPhoneNumber));
                }
            }
            for (int i = 0; i < browsers.Length; i++)
            {
                string currentBrowser = browsers[i];
                Smartphone smartPhone = new Smartphone();
                Console.WriteLine(smartPhone.Browse(currentBrowser));
            }
        }
    }
}
