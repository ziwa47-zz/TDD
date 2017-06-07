using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace TDDDay2Homework
{
    [TestClass]
    public class HarryPotterBookChartTest
    {

        [TestMethod]
        public void Buy_HarrtPotter_1_0_0_0_0_And_TotalPrice_Must_Be_100()
        {
            //arrange 

            var books = new List<Book>() { new Book {Id=1,Qty=1 } };
            IShoppingCart _shoppingCart = new ShoppingCart();

            decimal expected = 100;
            //act
            decimal actual = _shoppingCart.Buy(books);

            //assert
            Assert.AreEqual(expected, actual);
        }
       

        private Dictionary<int, decimal> BuyBooksDiscount()
        {
            return new Dictionary<int, decimal>()
                { {1,1m }, {2,0.95m }, {3,0.9m }, {4,0.8m }, { 5,0.75m} };

        }
    }

    public class Book
    {
        public int Id { get; set; }

        public int Qty { get; set; }
    }

    public class ShoppingCart : IShoppingCart
    {
        public ShoppingCart()
        {
        }

        public decimal Buy(List<Book> books)
        {
            throw new NotImplementedException();
        }
    }

    public interface IShoppingCart
    {
        decimal Buy(List<Book> books);
    }
}
