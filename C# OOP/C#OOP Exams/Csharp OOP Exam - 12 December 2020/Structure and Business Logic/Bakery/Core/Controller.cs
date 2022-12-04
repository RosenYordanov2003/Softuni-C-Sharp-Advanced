using System;
namespace Bakery.Core
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Contracts;
    using Models.BakedFoods;
    using Bakery.Models.BakedFoods.Contracts;
    using Models.Drinks;
    using Bakery.Models.Drinks.Contracts;
    using Models.Tables;
    using Bakery.Models.Tables.Contracts;
    using Utilities.Messages;
    public class Controller : IController
    {
        private List<IBakedFood> bakedFoods;
        private List<IDrink> drinks;
        private List<ITable> tables;
        private decimal totalIncome = 0;
        public Controller()
        {
            bakedFoods = new List<IBakedFood>();
            drinks = new List<IDrink>();
            tables = new List<ITable>();
        }
        public string AddFood(string type, string name, decimal price)
        {
            IBakedFood food = null;
            switch (type)
            {
                case "Bread": food = new Bread(name, price); break;
                case "Cake": food = new Cake(name, price); break;
            }
            bakedFoods.Add(food);
            return String.Format(OutputMessages.FoodAdded, name, type);
        }


        public string AddDrink(string type, string name, int portion, string brand)
        {
            IDrink drink = null;
            switch (type)
            {
                case "Tea": drink = new Tea(name, portion, brand); break;
                case "Water": drink = new Water(name, portion, brand); break;
            }
            drinks.Add(drink);
            return String.Format(OutputMessages.DrinkAdded, name, brand);
        }

        public string AddTable(string type, int tableNumber, int capacity)
        {
            ITable table = null;
            switch (type)
            {
                case "InsideTable": table = new InsideTable(tableNumber, capacity); break;
                case "OutsideTable": table = new OutsideTable(tableNumber, capacity); break;
            }
            tables.Add(table);
            return String.Format(OutputMessages.TableAdded, tableNumber);
        }

        public string ReserveTable(int numberOfPeople)
        {
            ITable tableToFind = tables.FirstOrDefault(t => t.IsReserved == false && t.Capacity >= numberOfPeople);
            if (tableToFind == null)
            {
                return string.Format(OutputMessages.ReservationNotPossible, numberOfPeople);
            }
            tableToFind.Reserve(numberOfPeople);
            return string.Format(OutputMessages.TableReserved, tableToFind.TableNumber, numberOfPeople);
        }

        public string OrderFood(int tableNumber, string foodName)
        {
            ITable table = tables.FirstOrDefault(t => t.TableNumber == tableNumber);
            if (table == null)
            {
                return string.Format(OutputMessages.WrongTableNumber, tableNumber);
            }

            IBakedFood food = bakedFoods.FirstOrDefault(f => f.Name == foodName);
            if (food == null)
            {
                return string.Format(OutputMessages.NonExistentFood, foodName);
            }
            table.OrderFood(food);
            return string.Format(OutputMessages.FoodOrderSuccessful, tableNumber, foodName);
        }

        public string OrderDrink(int tableNumber, string drinkName, string drinkBrand)
        {
            ITable table = tables.FirstOrDefault(t => t.TableNumber == tableNumber);
            if (table == null)
            {
                return string.Format(OutputMessages.WrongTableNumber, tableNumber);
            }

            IDrink drink = drinks.FirstOrDefault(d => d.Name == drinkName && d.Brand == drinkBrand);
            if (drink == null)
            {
                return string.Format(OutputMessages.NonExistentDrink, drinkName, drinkBrand);
            }
            table.OrderDrink(drink);
            return $"Table {tableNumber} ordered {drinkName} {drinkBrand}";
        }

        public string LeaveTable(int tableNumber)
        {
            ITable table = tables.First(t => t.TableNumber == tableNumber);
            decimal bill = table.GetBill();
            totalIncome += bill;
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Table: {tableNumber}");
            sb.AppendLine($"Bill: {bill:F2}");
            table.Clear();
            return sb.ToString().Trim();
        }

        public string GetFreeTablesInfo()
        {
            List<ITable> availableTables = tables.Where(t => t.IsReserved == false).ToList();
            StringBuilder sb = new StringBuilder();
            foreach (ITable table in availableTables)
            {
                sb.AppendLine(table.GetFreeTableInfo());
            }
            return sb.ToString().Trim();
        }

        public string GetTotalIncome()
        {
            return string.Format(OutputMessages.TotalIncome, totalIncome);
        }
    }
}
