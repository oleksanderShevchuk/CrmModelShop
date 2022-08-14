﻿using System;
using System.Collections.Generic;
using System.Data.Entity;

namespace CrmBl.Model
{
    public class CashDesk
    {
        CrmContext db = new CrmContext();
        public int Number { get; set; }
        public Seller Seller { get; set; }
        public Queue<Cart> Queue { get; set; }
        public int MaxQueueLenght { get; set; }
        public int ExitCustomer { get; set; }
        public bool IsModel { get; set; }
        public CashDesk(int number, Seller seller)
        {
            Number = number;
            Seller = seller;
            Queue = new Queue<Cart>();
            IsModel = true;
        }
        public void Enqueue(Cart cart)
        {
            if (Queue.Count <= MaxQueueLenght)
            {
                Queue.Enqueue(cart);
            }
            else
            {
                ExitCustomer++;
            }
        }
        public decimal Dequeue()
        {
            decimal sum = 0;
            var cart = Queue.Dequeue();

            if (cart != null)
            {
                var check = new Check
                {
                    SellerId = Seller.SellerId,
                    Seller = Seller,
                    CustomerId = cart.Customer.CustomerId,
                    Customer = cart.Customer,
                    Created = DateTime.Now
                };
                if (!IsModel)
                {
                    db.Checks.Add(check);
                    db.SaveChanges();
                }
                else
                {
                    check.CheckId = 0;
                }
                var sells = new List<Sell>();
                foreach (Product product in cart)
                {
                    var sell = new Sell()
                    {
                        CheckId = check.CheckId,
                        Check = check,
                        ProductId = product.ProductId,
                        Product = product
                    };
                    sells.Add(sell);

                    if (!IsModel)
                    {
                        db.Sells.Add(sell);
                    }
                    product.Count--;
                    sum += product.Price;
                }
                if (!IsModel)
                {
                    db.SaveChanges();
                }
            }
            return sum;
        }
    }
}
