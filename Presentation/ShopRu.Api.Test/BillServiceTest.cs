using NUnit.Framework;
using System;
using System.Collections.Generic;
using ShopRu.EntityLayer.Entity;
using ShopRu.EntityLayer.Enums;
using ShopRu.BusinessLayer;

namespace ShopRu.Api.Test
{
    [TestFixture]
    public class BillServiceTests
    {
        [Test]
        public async Task CalculateTotalAmount_EmployeeDiscount()
        {
            // Arrange
            var mockUser = new User { UserType = UserType.Employee };

            var bill = new Bill
            {
                User = mockUser,
                Products = new List<Product>
                {
                    new Product { IsGrocery = false, Price = 100 }
                }
            };

            var billService = new BillService();

            // Act
            decimal totalAmount = await billService.CalculateTotalAmount(bill);

            // Assert
            Assert.AreEqual(70, totalAmount); // Employee gets a 30% discount
        }

        [Test]
        public async Task CalculateTotalAmount_AffiliateDiscount()
        {
            // Arrange
            var mockUser = new User { UserType = UserType.Affiliate };

            var bill = new Bill
            {
                User = mockUser,
                Products = new List<Product>
                {
                    new Product { IsGrocery = false, Price = 100 }
                }
            };

            var billService = new BillService();

            // Act
            decimal totalAmount = await billService.CalculateTotalAmount(bill);

            // Assert
            Assert.AreEqual(90, totalAmount); // Affiliate gets a 10% discount
        }

        [Test]
        public async Task CalculateTotalAmount_LoyalCustomerDiscount()
        {
            // Arrange
            var mockUser = new User { UserType = UserType.Customer, InsertDate = DateTime.Now.AddYears(-3) };

            var bill = new Bill
            {
                User = mockUser,
                Products = new List<Product>
                {
                    new Product { IsGrocery = false, Price = 100 }
                }
            };

            var billService = new BillService();

            // Act
            decimal totalAmount = await billService.CalculateTotalAmount(bill);

            // Assert
            Assert.AreEqual(95, totalAmount); // Loyal customer gets a 5% discount
        }

        [Test]
        public async Task CalculateTotalAmount_NoDiscount()
        {
            // Arrange
            var mockUser = new User { UserType = UserType.Customer, InsertDate = DateTime.Now.AddYears(-1) };

            var bill = new Bill
            {
                User = mockUser,
                Products = new List<Product>
                {
                    new Product { IsGrocery = false, Price = 100 }
                }
            };

            var billService = new BillService();

            // Act
            decimal totalAmount = await billService.CalculateTotalAmount(bill);

            // Assert
            Assert.AreEqual(95, totalAmount); // No discount for this customer
        }

        [Test]
        public async Task CalculateTotalAmount_GroceriesNotEligibleForDiscount()
        {
            // Arrange
            var mockUser = new User { UserType = UserType.Employee };

            var bill = new Bill
            {
                User = mockUser,
                Products = new List<Product>
                {
                    new Product { IsGrocery = true, Price = 100 }
                }
            };

            var billService = new BillService();

            // Act
            decimal totalAmount = await billService.CalculateTotalAmount(bill);

            // Assert
            Assert.AreEqual(95, totalAmount); // Groceries are not eligible for discounts
        }

        [Test]
        public async Task CalculateTotalAmount_DiscountForEvery100Dollars()
        {
            // Arrange
            var mockUser = new User { UserType = UserType.Customer, InsertDate = DateTime.Now.AddYears(-3) };

            var bill = new Bill
            {
                User = mockUser,
                Products = new List<Product>
                {
                    new Product { IsGrocery = false, Price = 200 }
                }
            };

            var billService = new BillService();

            // Act
            decimal totalAmount = await billService.CalculateTotalAmount(bill);

            // Assert
            Assert.AreEqual(185, totalAmount); // $15 discount for every $100
        }
    }
}