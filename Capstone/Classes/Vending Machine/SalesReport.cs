//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using System.IO;

//namespace Capstone.Classes
//{
//    public static class SalesReport
//    {
//        public static void GenerateSalesReport(VendingMachine vm, string destinationPath, string nomNom)
//        {

//            var uniqueItemsSold = Math.Abs(vm.Stock[nomNom].Count - 5);
//            var grossVendingSales = 0M;
//            var path = Environment.CurrentDirectory;
//            destinationPath = Path.Combine(path, "SalesReport.txt");


//            //  loop through the items purchased
//            foreach (var product in vm.Stock)
//            {
//                if (vm.Stock[nomNom][0].Name != null)
//                {

//                }
//            }



//            var salesWriter = new StreamWriter(destinationPath, false);

//            salesWriter.WriteLine($" {vm.Stock[nomNom][0].Name} | {uniqueItemsSold}");
//            salesWriter.WriteLine($"**TOTAL SALES** {grossVendingSales:C2}");

//            //  We don't need to return anything because we're printing to a file
//            salesWriter.Close();
//        }
//    }
//}
