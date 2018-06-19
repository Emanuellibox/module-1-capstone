using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Capstone.Classes
{
    public class StockProducts
    {
        public Dictionary<string, List<Product>> StockVendingMachine()
        {
            var path = Path.Combine(Environment.CurrentDirectory, "VendingMachine.csv");
            var defaultDictionary = new Dictionary<string, List<Product>>();


            using (var sr = new StreamReader(path))
            {

                while (!sr.EndOfStream)
                {
                    var defaultList = new List<Product>();
                    string[] tempProduct = sr.ReadLine().Split('|');
                    decimal cost = Decimal.Parse(tempProduct[2]);
                    for (int i = 0; i < 5; i++)
                    {
                        // Name, Cost, and Category created in each new product
                        defaultList.Add(new Product(tempProduct[1], cost, tempProduct[3]));
                    }
                    //  Set the Key equal to the products
                    defaultDictionary[tempProduct[0]] = defaultList;
                    
                }

                
            }

            return defaultDictionary;
        }
    }
}
