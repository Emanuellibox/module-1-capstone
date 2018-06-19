using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.IO;

namespace Capstone.Classes
{
    public class VendingMachine
    {

        StockProducts stock = new StockProducts();

        public int NumberOfQuarters { get; private set; }
        public int NumberOfDimes { get; private set; }
        public int NumberOfNickels { get; private set; }

        // not today, Hacker Josh!
        private Dictionary<string, List<Product>> Stock { get; set; }
        public decimal tenderAmount { get; private set; }

        bool isProductSold = false;

        int numberOfChips = 0;
        int numberOfCandy = 0;
        int numberOfDrinks = 0;
        int numberOfGumSticks = 0;

        /// <summary>
        /// Displays available stock of items.
        /// </summary>
        /// <param name="products">Separate product objects put into a list</param>
        public void DisplayStock(VendingMachine vm)
        {
            Console.Clear();
            // Dictionary is <Slot ID, Products>
            foreach (KeyValuePair<string, List<Product>> kvp in Stock)
            {
                // if the list isn't empty
                if (kvp.Value.Count > 0)
                {
                    Console.WriteLine($"{kvp.Key} | {kvp.Value[0].Name}");  // Slot ID and Name
                    Console.WriteLine($"Cost: {kvp.Value[0].Price:c2} | Stock: { kvp.Value.Count}");  // Price formatted to dollars.cents and how many products are left
                    Console.WriteLine("----------------------------");
                }
                // if the item is out of stock
                else
                {
                    Console.WriteLine($"Item at {kvp.Key} is out of stock.");
                }


            }

        }

        

 

        public void DispenseItem(string path, string nomNom)
        {
            if (IsInStockAndHaveTender(nomNom))
            {
                Console.WriteLine($"Dispensed one: {Stock[nomNom][0].Name}");
                Console.WriteLine($"Your remaining balance is: {tenderAmount - Stock[nomNom][0].Price}");

                Logger.LogDispense(Stock[nomNom][0].Name, path, tenderAmount, Stock[nomNom][0].Price, nomNom);
                tenderAmount -= Stock[nomNom][0].Price;

                IncreaseProductCount(Stock[nomNom][0].Category);

                
                Stock[nomNom].RemoveAt(0);
            }
            else if (IsOutOfStockItem(nomNom))
            {
                Console.WriteLine("Sorry, this item is currently out of stock.");
                Thread.Sleep(2000);
            }
            else if (IsInStockWithInsufficientTender(nomNom))
            {
                Console.WriteLine("Current tender is below the cost of this item, please insert more money.");
                Thread.Sleep(2000);

            }
            else
            {
                Console.WriteLine("Item ID was not found. Please try again.");
                Thread.Sleep(2000);
            }
        }

        private bool IsInStockWithInsufficientTender(string nomNom)
        {
            return Stock.ContainsKey(nomNom) && Stock[nomNom].Count != 0 && Stock[nomNom][0].Price > tenderAmount;
        }

        private bool IsOutOfStockItem( string nomNom)
        {
            return Stock.ContainsKey(nomNom) && Stock[nomNom].Count == 0;
        }

        private bool IsInStockAndHaveTender( string nomNom)
        {
            return Stock.ContainsKey(nomNom) && Stock[nomNom].Count != 0 && tenderAmount >= Stock[nomNom][0].Price;
        }

        // change signature to reflect proper logic
        private void IncreaseProductCount(string category)
        {
            
            // all products will naturally be in stock; no need to check
            // simply compare the category of the item against the pre-defined categories
            if (category == "Chip")
            {
                numberOfChips += 1;
            }
            else if (category == "Candy")
            {
                numberOfCandy += 1;
            }
            else if (category == "Drink")
            {
                numberOfDrinks += 1;
            }
            else if (category == "Gum")
            {
                numberOfGumSticks += 1;
            }
        }

        public int CheckCurrentStock(string nomNom)
        {
            return (Stock[nomNom].Count);
        }

        public bool IsProductInStock(string category, string nomNom)
        {

            if (Stock[nomNom][0].Category == "Gum")
            {
                return Stock[nomNom].Count != 0;
            }

            if (Stock[nomNom][0].Category == "Drink")
            {
                return Stock[nomNom].Count != 0;
            }

            if (Stock[nomNom][0].Category == "Candy")
            {
                return Stock[nomNom].Count != 0;
            }

            if (Stock[nomNom][0].Category == "Chip")
            {
                return Stock[nomNom].Count != 0;
            }

            return false;
        }

        public void InsertTender(string path, decimal tender)
        {
            while (true)
            {
                try
                {

                    bool validTender = ValidateTender(tender);

                    if (validTender)
                    {
                        tenderAmount += tender;
                        Logger.LogInsertedTender(path, tender, tenderAmount);
                        break;
                    }
                    else
                    {
                        throw new ArgumentOutOfRangeException();
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Sorry, an error occurred: " + ex.Message);
                    break;

                }

            }
        }

        public bool ValidateTender(decimal tender)
        {
            return (tender == 1 || tender == 2 || tender == 5 || tender == 10);
        }

        public string DispenseChange( string path)
        {
            decimal temporaryTender = tenderAmount;

            // this value is being re-assigned to 0 because it's converted to quarters, dimes, and nickels
            tenderAmount = GiveChange();

            var change = ((NumberOfQuarters * .25M) + (NumberOfDimes * .10M) + (NumberOfNickels * .05M));

            // this needs to be tenderAmount; the temporary tender is not being updated
            Logger.LogChange(path, tenderAmount, change);

            string message = $"Your change is {change:C2} in {NumberOfQuarters} quarters, {NumberOfDimes} dimes, and {NumberOfNickels} nickel(s).";
            Consume.ConsumeSnacks(numberOfChips, numberOfCandy, numberOfDrinks, numberOfGumSticks);

            return message;
        }

        private decimal GiveChange()
        {
            while (tenderAmount >= .25M)
            {
                tenderAmount -= .25M;
                NumberOfQuarters++;
            }

            while (tenderAmount >= .10M)
            {
                tenderAmount -= .10M;
                NumberOfDimes++;

                if (tenderAmount == .05M)
                {
                    tenderAmount -= .05M;
                    NumberOfNickels = 1;
                }
            }

            return tenderAmount;
        }

        public VendingMachine()
        {
            Stock = stock.StockVendingMachine();
            tenderAmount = 0M;
        }
    }
}

