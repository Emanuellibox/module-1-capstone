using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Capstone.Classes
{
    public static class Logger
    {

        private static void PrintMessage(string message, string path)
        {
            try
            {
                using (var sw = new StreamWriter(path, true))
                {
                    sw.WriteLine(DateTime.Now.ToString() + message);
                }
            }
            catch (IOException ex)
            {

                Console.WriteLine("Sorry, an error occurred: " + ex.Message);
            }
        }

        public static void LogInsertedTender(string path, decimal tender, decimal tenderAmount)
        {
            string message = $" FEED MONEY:  " + $"{tender:C2}  {tenderAmount:C2}";
            PrintMessage(message, path);
        }

        public static void LogDispense(string name, string path, decimal tender, decimal price, string nomNom)
        {
            string message = $" {name}  {nomNom}    {tender:C2}  {price:C2}";
            PrintMessage(message, path);

        }

        public static void LogChange(string path, decimal tender, decimal change)
        {
            string message = $" GIVE CHANGE:    " + $"{change:C2}  {tender:C2}";

            PrintMessage(message, path);
        }


    }
}
