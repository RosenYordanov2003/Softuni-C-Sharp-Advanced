using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StockMarket
{
    public class Investor
    {
        private List<Stock> Portfolio;
        public Investor(string fullName, string emailAddress, decimal moneyToInvest, string brokerName)
        {
            this.Portfolio = new List<Stock>();
            this.FullName = fullName;
            this.EmailAddress = emailAddress;
            this.MoneyToInvest = moneyToInvest;
            this.BrokerName = brokerName;
        }
        public string FullName { get; set; }
        public string EmailAddress { get; set; }
        public decimal MoneyToInvest { get; set; }
        public string BrokerName { get; set; }
        public int Count { get { return this.Portfolio.Count; } }
        public void BuyStock(Stock stock)
        {
            if (stock.MarketCapitalization > 10000 && this.MoneyToInvest >= stock.PricePerShare)
            {
                this.Portfolio.Add(stock);
                this.MoneyToInvest -= stock.PricePerShare;
            }
        }
        public string SellStock(string companyName, decimal sellPrice)
        {
            string message = string.Empty;
            Stock companyToFind = this.Portfolio.FirstOrDefault(x => x.CompanyName == companyName);
            if (companyToFind != null)
            {
                if (sellPrice < companyToFind.PricePerShare)
                {
                    message = $"Cannot sell {companyName}.";
                }
                else
                {
                    this.Portfolio.Remove(companyToFind);
                    this.MoneyToInvest += sellPrice;
                    message = $"{companyName} was sold.";
                }
            }
            else
            {
                message = $"{companyName} does not exist.";
            }
            return message;
        }
        public Stock FindStock(string companyName)
        {
            Stock companyToFind = this.Portfolio.FirstOrDefault(x => x.CompanyName == companyName);
            if (companyToFind != null)
            {
                return companyToFind;
            }
            return null;
        }
        public Stock FindBiggestCompany()
        {
            if (!this.Portfolio.Any())
            {
                return null;
            }
            else
            {
                Stock biggestCompany = this.Portfolio.OrderByDescending(x => x.MarketCapitalization).First();
                return biggestCompany;
            }
        }
        public string InvestorInformation()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"The investor {this.FullName} with a broker {this.BrokerName} has stocks:");
            foreach (Stock stock in Portfolio)
            {
                sb.AppendLine(stock.ToString());
            }
            return sb.ToString().Trim();
        }
    }
}
