using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Capstone.Classes;
using System.IO;

namespace Capstone.Tests
{
    [TestClass]
    public class PurchaseItemTests
    {
        [TestMethod]
        public void PurchaseItem_VendingMachineAcceptsTender_Test()
        {
            
            VendingMachine test = new VendingMachine();
            string path = Path.Combine(Environment.CurrentDirectory, "testLog.txt");

            // removed the convoluted calls to the vending machine's parts
            // insert tender now only needs two parameters
            test.InsertTender(path, 10);
            test.InsertTender(path, 5);
            test.InsertTender(path, 2);
            test.InsertTender(path, 1);

            test.InsertTender(path, 3);
            test.InsertTender(path, 7);
            test.InsertTender(path, 9);

            Assert.AreEqual(18, test.tenderAmount);
        }

        [TestMethod]
        public void PurchaseItem_MachineDispensesFood_Test()
        {
            VendingMachine test = new VendingMachine();
            string path = Path.Combine(Environment.CurrentDirectory, "testLog.txt");

            test.InsertTender(path, 10);
            test.DispenseItem(path, "A1");

            // no need to check for 0 if we can check for minus one
            Assert.IsTrue(test.CheckCurrentStock("A1") == 4);
        }

        [TestMethod]
        public void PurchaseItem_ItemIsOutOfStock_Test()
        {
            VendingMachine test = new VendingMachine();
            string path = Path.Combine(Environment.CurrentDirectory, "testLog.txt");
            var nomNom = "C2";

            test.InsertTender(path, 10);
            test.DispenseItem(path, nomNom);
            test.DispenseItem(path, nomNom);
            test.DispenseItem(path, nomNom);
            test.DispenseItem(path, nomNom);
            test.DispenseItem(path, nomNom);

            // sixth removal won't work anyway
            test.DispenseItem(path, nomNom);

            // check for proper amount remaining
            Assert.IsTrue(test.tenderAmount == 2.50M);
        }

        // Test answers this question:  "Do we have the proper amount in stock?  Can we buy with less money than needed?

        [TestMethod]
        public void PurchaseItem_AttemptPurchaseWithInsufficientFunds_Test()
        {
            var test = new VendingMachine();
            string path = Path.Combine(Environment.CurrentDirectory, "testLog.txt");
            var nomNom = "A1";

            test.InsertTender(path, 1);
            test.DispenseItem(path, nomNom);

            Assert.IsTrue(test.CheckCurrentStock("A1") == 5);
            Assert.IsTrue(test.tenderAmount == 1);
        }

        [TestMethod]
        public void PurchaseItem_UpdateTenderAmountOnPurchase_Test()
        {
            var test = new VendingMachine();
            string path = Path.Combine(Environment.CurrentDirectory, "testLog.txt");
            var nomNom = "A1";

            test.InsertTender(path, 5);
            test.DispenseItem(path, nomNom);

            Assert.IsTrue(test.tenderAmount == 1.95M);
        }

        [TestMethod]
        public void PurchaseItem_ReturnsCorrectChangeToCustomer_Test()
        {
            var test = new VendingMachine();
            var path = Path.Combine(Environment.CurrentDirectory, "testLog.txt");
            var nomNom = "D1";


            test.InsertTender(path, 2);
            test.DispenseItem(path, nomNom);

            test.DispenseChange(path);

            Assert.IsTrue(test.NumberOfQuarters == 4 && test.NumberOfDimes == 1 && test.NumberOfNickels == 1);
            
        }
    }
}
