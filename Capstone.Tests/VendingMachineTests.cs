using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Capstone.Classes;
namespace Capstone.Tests
{
    [TestClass]
    public class VendingMachineStockTest
    {
        [TestMethod]
        public void VendingMachine_CorrectlyStocksItems_Test()
        {
            StockProducts stock = new StockProducts();
            VendingMachine test = new VendingMachine();

            // go through the intermediary method to check stock
            Assert.IsTrue(test.CheckCurrentStock("A1") == 5);
            Assert.IsTrue(test.CheckCurrentStock("B2") == 5);
            Assert.IsTrue(test.CheckCurrentStock("C3") == 5);
            Assert.IsTrue(test.CheckCurrentStock("D4") == 5);
        }
    }
}
