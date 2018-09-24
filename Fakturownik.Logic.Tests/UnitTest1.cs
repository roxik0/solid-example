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
            var item = new LocalInvoiceItem()
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
        [TestMethod]
        public void UserSupervisorTest()
        {
            var supervisor = new SuperUser()
            {
               
            };
            var item = new SuperUser()
            {
                Supervisor = supervisor,
            };
            if (!(item is SuperUser))
            {
                Assert.AreEqual(supervisor, item.GetSupervisor());
            }
        }

    }
    public class SuperUser:User
    {
        public override User GetSupervisor()
        {
            throw new ExecutionEngineException("Super user jest szefem");
        }
    }
    public class User
    {
        public string Login { get; set; }
        public string Password { get; set; }
        public int SecurityLevel { get; set; }
        public User Supervisor { private get; set; }

        public virtual User GetSupervisor()
        {
            return Supervisor;
        }
    }

}
