using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;


namespace Capstone.Classes
{
    public class UI
    {
        public void VendingMachineMenu(VendingMachine vm)
        {
            while (true)
            {
                Console.WriteLine("Choose one of the following:  ");
                Console.WriteLine("1.  Display available items");
                Console.WriteLine("2.  Purchase item");
                Console.WriteLine("Q.  Quit");
                string input = Console.ReadLine();


                if (input == "1")
                {
                    vm.DisplayStock(vm);
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                    Console.Clear();
                }
                else if (input == "2")
                {

                    PurchaseItem(vm);

                }
                else if (input.ToUpper() == "Q")
                {
                    Console.WriteLine("Quitting...");
                    return;
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Invalid input.  Please enter 1, 2, or Q.");
                    Console.WriteLine();
                }
            }

        }



        public void PurchaseItem(VendingMachine vm)
        {
            string folder = "Logs";
            string path = Environment.CurrentDirectory;
            Directory.CreateDirectory(folder);
            path = Path.Combine(path, folder, "Logs.txt");

            while (true)
            {
                string[] validInputs = new string[3] { "1", "2", "3" };
                string input = "";
                while (!validInputs.Contains(input))
                {
                    Console.Clear();
                    Console.WriteLine("Choose one of the following:  ");
                    Console.WriteLine("1. Feed Money");
                    Console.WriteLine("2. Select Product");
                    Console.WriteLine("3. Finish Transaction");


                    if (vm.tenderAmount != 0)
                    {
                        Console.WriteLine($"Current Tender: {vm.tenderAmount:C2}");
                    }

                    input = Console.ReadLine();
                }

                if (input == "1")
                {

                    try
                    {
                        Console.Clear();
                        Console.WriteLine("Please insert tender (accepts $1, $2, $5, and $10) :");
                        decimal tender = decimal.Parse(Console.ReadLine());

                        if (!vm.ValidateTender(tender))
                        {
                            throw new ArgumentOutOfRangeException();
                        }
                        vm.InsertTender(path, tender);
                        input = "";


                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Invalid tender amount, returning to menu.");
                        input = "";
                        Thread.Sleep(2000);
                    }
                    



                }
                else if (input == "2")
                {
                    while (true)
                    {
                        vm.DisplayStock(vm);
                        Console.WriteLine("What would you like to purchase? ");
                        string nomNom = Console.ReadLine().ToUpper();
                        vm.DispenseItem(path, nomNom);

                        Console.WriteLine();

                        Console.Write("Press any key to return to the purchase menu:");
                        Console.ReadKey();
                        break;

                    }
                }
                else if (input == "3")
                {

                    Console.WriteLine(vm.DispenseChange(path));
                    Console.WriteLine("Press any key to return to the main menu.");
                    Console.ReadKey();
                    Console.Clear();
                    return;

                }
            }


        }
    }
}
