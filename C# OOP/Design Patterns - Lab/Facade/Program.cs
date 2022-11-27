using System;
using Facade.Models;

namespace Facade
{
    public class Program
    {
        static void Main(string[] args)
        {
            Car car = new CarBuilderFacade().CarInfo.WithType("BMW")
                .WithColor("Red").WithNumberOfDoors(4).CarAddress.InCity("Sofia").AtAddress("Address 2022").Build();
            Console.WriteLine(car);
        }
    }
}
