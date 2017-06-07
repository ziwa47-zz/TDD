using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace TDDDay2Homework
{
    [TestClass]
    public class HarryPotterBookChartTest
    {
        [TestMethod]
        public void Buy_HarrtPotter_1_0_0_0_0_And_TotalPrice_Must_Be_100()
        {
            //arrange
            var target = new ShoppingCart();
            var books = new List<Book>() { new Book { Id = 1, Qty = 1 } };

            decimal expected = 100;
            //act
            decimal actual = target.Buy(books);

            //assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Buy_HarrtPotter_1_1_0_0_0_And_TotalPrice_Must_Be_190()
        {
            //arrange 
            var target = new ShoppingCart();
            var books = new List<Book>() { new Book { Id = 1, Qty = 1 }, new Book { Id = 2, Qty = 1 } };

            decimal expected = 190;
            //act
            decimal actual = target.Buy(books);

            //assert
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void Buy_HarrtPotter_1_1_1_0_0_And_TotalPrice_Must_Be_270()
        {
            //arrange 
            var target = new ShoppingCart();
            var books = new List<Book>() {
                new Book { Id = 1, Qty = 1 },
                new Book { Id = 2, Qty = 1 },
                new Book { Id = 3, Qty = 1 }};

            decimal expected = 270;
            //act
            decimal actual = target.Buy(books);

            //assert
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void Buy_HarrtPotter_1_1_1_1_0_And_TotalPrice_Must_Be_320()
        {
            //arrange 
            var target = new ShoppingCart();
            var books = new List<Book>() {
                new Book { Id = 1, Qty = 1 },
                new Book { Id = 2, Qty = 1 },
                new Book { Id = 3, Qty = 1 },
                new Book { Id = 4, Qty = 1 }
            };

            decimal expected = 320;
            //act
            decimal actual = target.Buy(books);

            //assert
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void Buy_HarrtPotter_1_1_1_1_1_And_TotalPrice_Must_Be_375()
        {
            //arrange 
            var target = new ShoppingCart();
            var books = new List<Book>() {
                new Book { Id = 1, Qty = 1 },
                new Book { Id = 2, Qty = 1 },
                new Book { Id = 3, Qty = 1 },
                new Book { Id = 4, Qty = 1 },
                new Book { Id = 5, Qty = 1 },
            };

            decimal expected = 375;
            //act
            decimal actual = target.Buy(books);

            //assert
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void Buy_HarrtPotter_1_1_2_0_0_And_TotalPrice_Must_Be_370()
        {
            //arrange 
            var target = new ShoppingCart();
            var books = new List<Book>() {
                new Book { Id = 1, Qty = 1 },
                new Book { Id = 2, Qty = 1 },
                new Book { Id = 3, Qty = 2 },
                new Book { Id = 4, Qty = 0 },
                new Book { Id = 5, Qty = 0 },
            };

            decimal expected = 370;
            //act
            decimal actual = target.Buy(books);

            //assert
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void Buy_HarrtPotter_1_2_2_0_0_And_TotalPrice_Must_Be_460()
        {
            //arrange 
            var target = new ShoppingCart();
            var books = new List<Book>() {
                new Book { Id = 1, Qty = 1 },
                new Book { Id = 2, Qty = 2 },
                new Book { Id = 3, Qty = 2 },
                new Book { Id = 4, Qty = 0 },
                new Book { Id = 5, Qty = 0 },
            };

            decimal expected = 460;
            //act
            decimal actual = target.Buy(books);

            //assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Buy_HarrtPotter_1_2_3_2_1_And_TotalPrice_Must_Be_745()
        {
            //arrange 
            var target = new ShoppingCart();
            var books = new List<Book>() {
                new Book { Id = 1, Qty = 1 },
                new Book { Id = 2, Qty = 2 },
                new Book { Id = 3, Qty = 3 },
                new Book { Id = 4, Qty = 2 },
                new Book { Id = 5, Qty = 1 },
            };

            decimal expected = 745;
            //act
            decimal actual = target.Buy(books);

            //assert
            Assert.AreEqual(expected, actual);
        }


    }

    public class Book
    {
        public int Id { get; set; }

        public int Qty { get; set; }

    }

    public class ShoppingCart : IShoppingCart
    {
        private const decimal bookPrice = 100;
        private Dictionary<int, decimal> _discount;

        public ShoppingCart()
        {
            _discount = BuyBooksDiscount();
        }

        public Dictionary<int, decimal> BuyBooksDiscount()
        {
            return new Dictionary<int, decimal>()
                { {1,1m }, {2,0.95m }, {3,0.9m }, {4,0.8m }, { 5,0.75m} };

        }


        public decimal Buy(List<Book> books)
        {
            decimal totalAmount = 0;
            int bookIndex = 0;
            do
            {
                int bookAmount = 0;
                bookAmount += books.Where(r => r.Qty > bookIndex).Count();
                totalAmount += GetTotal(bookAmount);

            } while (books.Max(r => r.Qty) > ++bookIndex);
            return totalAmount;

        }

        private decimal GetTotal(int bookAmount)
        {
            return _discount[bookAmount] * bookAmount * bookPrice;
        }
    }

    public interface IShoppingCart
    {
        decimal Buy(List<Book> books);

        Dictionary<int, decimal> BuyBooksDiscount();
    }
}
