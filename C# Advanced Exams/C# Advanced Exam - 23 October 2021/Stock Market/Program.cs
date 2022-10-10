using System;

namespace StockMarket
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Investor investor = new Investor("Peter Lynch", "p.lynch@gmail.com", 2000m, "Fidelity");
            Stock ibmStock = new Stock("IBM", "Arvind Krishna", 138.50m, 5000);
            Console.WriteLine(ibmStock.ToString());
            investor.BuyStock(ibmStock);
            Console.WriteLine(investor.SellStock("IBM", 150.00m)); // "IBM was sold."
            Stock teslaStock = new Stock("Tesla", "Elon Musk", 743.17m, 6520);
            Stock amazonStock = new Stock("Amazon", "Jeff Bezos", 3457.17m, 8500);
            Stock twitterStock = new Stock("Twitter", "Jack Dorsey", 59.66m, 11200);
            Stock blizzardStock = new Stock("Activision Blizzard", "Bobby Kotick", 78.53m, 5520);
            investor.BuyStock(teslaStock);
            investor.BuyStock(amazonStock);
            investor.BuyStock(twitterStock);
            investor.BuyStock(blizzardStock);
            Console.WriteLine(investor.FindBiggestCompany());
            Console.WriteLine("----");
            Console.WriteLine(investor.InvestorInformation());
        }
    }
}
