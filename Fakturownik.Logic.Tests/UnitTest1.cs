using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Fakturownik.Logic.Tests
{
    [TestClass]
    public class PriceDependsOnCountryTests
    {
        [TestMethod]
        public void WhenChangeCurrencyPriceShouldChange()
        {
            var item = new InvoiceItem()
            {
                SinglePrice = 1,
                Quantity = 1,
                Currency = Currency.PLN
            };
            var previousPrice = item.Price;
            item.Currency = Currency.EUR;
            var newPrice = item.Price;
            Assert.AreNotEqual(previousPrice, newPrice);
        }
    }
}
