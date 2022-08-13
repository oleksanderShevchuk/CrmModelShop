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
    public class CartTests
    {
        [TestMethod()]
        public void CartTest()
        {
            // arrange - создание
            var customer = new Customer
            {
                CustomerId = 1,
                Name = "testUser"
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
                Price = 50,
                Count = 100
            };
            var cart = new Cart(customer);

            var expectedResult = new List<Product>()
            {
                p1, p1, p2
            };

            // act - добавление
            cart.Add(p1);
            cart.Add(p1);
            cart.Add(p2);
            
            var cartResult = cart.GetAll(); 

            //assert - сравнение
            Assert.AreEqual(expectedResult.Count, cartResult.Count);
            for (int i = 0; i < expectedResult.Count; i++)
            {
                Assert.AreEqual(expectedResult[i], cartResult[i]);
            }
        }

    }
}