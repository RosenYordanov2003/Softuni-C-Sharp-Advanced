namespace ChristmasPastryShop.Core
{
    using System.Linq;
    using System.Text;
    using Contracts;
    using Models.Booths;
    using ChristmasPastryShop.Models.Booths.Contracts;
    using Models.Cocktails;
    using ChristmasPastryShop.Models.Cocktails.Contracts;
    using Models.Delicacies;
    using ChristmasPastryShop.Models.Delicacies.Contracts;
    using Repositories;
    using ChristmasPastryShop.Repositories.Contracts;
    using Utilities.Messages;
    public class Controller : IController
    {
        private IRepository<IBooth> booths;

        public Controller()
        {
            booths = new BoothRepository();
        }
        public string AddBooth(int capacity)
        {
            IBooth booth = new Booth(booths.Models.Count + 1, capacity);
            booths.AddModel(booth);
            return string.Format(OutputMessages.NewBoothAdded, booth.BoothId, capacity);
        }

        public string AddDelicacy(int boothId, string delicacyTypeName, string delicacyName)
        {
            if (delicacyTypeName != "Gingerbread" && delicacyTypeName != "Stolen")
            {
                return string.Format(OutputMessages.InvalidDelicacyType, delicacyTypeName);
            }

            IDelicacy delicacy;
            if (delicacyTypeName == "Gingerbread")
            {
                delicacy = new Gingerbread(delicacyName);
            }
            else
            {
                delicacy = new Stolen(delicacyName);
            }

            IBooth booth = booths.Models.First(b => b.BoothId == boothId);
            if (booth.DelicacyMenu.Models.Any(d => d.Name == delicacyName))
            {
                return string.Format(OutputMessages.DelicacyAlreadyAdded, delicacyName);
            }
            booth.DelicacyMenu.AddModel(delicacy);
            return string.Format(OutputMessages.NewDelicacyAdded, delicacy.GetType().Name, delicacyName);
        }

        public string AddCocktail(int boothId, string cocktailTypeName, string cocktailName, string size)
        {
            if (cocktailTypeName != "Hibernation" && cocktailTypeName != "MulledWine")
            {
                return string.Format(OutputMessages.InvalidCocktailType, cocktailTypeName);
            }

            if (size != "Large" && size != "Small" && size != "Middle")
            {
                return string.Format(OutputMessages.InvalidCocktailSize, size);
            }
            IBooth booth = booths.Models.First(b => b.BoothId == boothId);
            if (booth.CocktailMenu.Models.Any(c => c.Name == cocktailName && c.Size == size))
            {
                return string.Format(OutputMessages.CocktailAlreadyAdded, size, cocktailName);
            }

            ICocktail cocktail;
            if (cocktailTypeName == "MulledWine")
            {
                cocktail = new MulledWine(cocktailName, size);
            }
            else
            {
                cocktail = new Hibernation(cocktailName, size);
            }
            booth.CocktailMenu.AddModel(cocktail);
            return string.Format(OutputMessages.NewCocktailAdded, size, cocktailName, cocktailTypeName);
        }

        public string ReserveBooth(int countOfPeople)
        {
            IBooth booth = booths.Models.Where(b => b.IsReserved == false && b.Capacity >= countOfPeople)
                .OrderBy(b => b.Capacity).ThenByDescending(b => b.BoothId).FirstOrDefault();
            if (booth == null)
            {
                return string.Format(OutputMessages.NoAvailableBooth, countOfPeople);
            }
            booth.ChangeStatus();
            return string.Format(OutputMessages.BoothReservedSuccessfully, booth.BoothId, countOfPeople);
        }

        public string TryOrder(int boothId, string order)
        {
            IBooth booth = booths.Models.First(b => b.BoothId == boothId);
            string[] orders = order.Split('/');
            string type = orders[0];
            string itemName = orders[1];
            int count = int.Parse(orders[2]);
            if (type != nameof(MulledWine) && type != nameof(Hibernation) && type != nameof(Gingerbread) &&
                type != nameof(Stolen))
            {
                return string.Format(OutputMessages.NotRecognizedType, type);
            }

            if (!booth.DelicacyMenu.Models.Any(d => d.Name == itemName) && !booth.CocktailMenu.Models.Any(c => c.Name == itemName))
            {
                return string.Format(OutputMessages.NotRecognizedItemName, type, itemName);
            }

            if (type == nameof(MulledWine) || type == nameof(Hibernation))
            {
                ICocktail cocktail = booth.CocktailMenu.Models.FirstOrDefault(c =>
                    c.Name == itemName && c.Size == orders[3] && c.GetType().Name == type);
                if (cocktail == null)
                {
                    return string.Format(OutputMessages.NotRecognizedItemName, orders[3], itemName);
                }
                booth.UpdateCurrentBill(cocktail.Price * count);
                return string.Format(OutputMessages.SuccessfullyOrdered, booth.BoothId, count, itemName);
            }
            IDelicacy delicacy = booth.DelicacyMenu.Models.FirstOrDefault(d => d.Name == itemName && d.GetType().Name == type);
            if (delicacy == null)
            {
                return string.Format(OutputMessages.NotRecognizedItemName, type, itemName);
            }
            booth.UpdateCurrentBill(delicacy.Price * count);
            return string.Format(OutputMessages.SuccessfullyOrdered, booth.BoothId, count, itemName);
        }
        public string LeaveBooth(int boothId)
        {
            IBooth booth = booths.Models.First(b => b.BoothId == boothId);
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Bill {booth.CurrentBill:F2} lv");
            sb.AppendLine($"Booth {boothId} is now available!");
            booth.Charge();
            booth.ChangeStatus();
            return sb.ToString().TrimEnd();
        }

        public string BoothReport(int boothId)
        {
            IBooth booth = booths.Models.First(b => b.BoothId == boothId);
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(booth.ToString());
            return sb.ToString().TrimEnd();
        }
    }
}
