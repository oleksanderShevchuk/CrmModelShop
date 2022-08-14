using Microsoft.VisualStudio.TestTools.UnitTesting;
using CrmBl.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrmBl.Model.Tests
{
    [TestClass()]
    public class CashDeskTests
    {
        [TestMethod()]
        public void CashDeskTest()
        {
            // arrange - создание
            var customer1 = new Customer
            {
                CustomerId = 1,
                Name = "testUser1"
            };
            var customer2 = new Customer
            {
                CustomerId = 2,
                Name = "testUser2"
            };
            var seller = new Seller
            {
                SellerId = 1,
                Name = "sellerName"
            };
            var p1 = new Product
            {
                ProductId = 1,
                Name = "pr1",
                Price = 100,
                Count = 10
            };
            var p2 = new Product
            {
                ProductId = 2,
                Name = "pr2",
                Price = 200,
                Count = 20
            };
            var cart1 = new Cart(customer1);
            cart1.Add(p1);
            cart1.Add(p1);
            cart1.Add(p2);
            var cart2 = new Cart(customer2);
            cart2.Add(p1);
            cart2.Add(p2);
            cart2.Add(p2);

            var cashDesk = new CashDesk(1,seller);
            cashDesk.MaxQueueLenght = 10;
            cashDesk.Enqueue(cart1);
            cashDesk.Enqueue(cart2);

            var cart1ExpectedResult = 400;
            var cart2ExpectedResult = 500;

            // act - добавление
            var cart1ActualResult = cashDesk.Dequeue();
            var cart2ActualResult = cashDesk.Dequeue();

            //assert - сравнение
            Assert.AreEqual(cart1ExpectedResult, cart1ActualResult);
            Assert.AreEqual(cart2ExpectedResult, cart2ActualResult);

            Assert.AreEqual(7, p1.Count);
            Assert.AreEqual(17, p2.Count);
        }
    }
}