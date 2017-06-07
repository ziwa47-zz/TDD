using Microsoft.VisualStudio.TestTools.UnitTesting;
using Day1HomeWork;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day1HomeWork.Tests
{
    [TestClass()]
    public class ProgramTests
    {

        [TestMethod()]
        public void 驗證_Cost_3筆一組()
        {
            //arrange
            var orderList = new Order().GetList();
            var expected = new List<int>() { 6, 15, 24, 21 };
            //act
            var actual = new Calculator().SumByCost(orderList, 3).ToList();

            //assert
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void 驗證_Revenue_4筆一組()
        {
            //arrange
            var orderList = new Order().GetList();
            var expected = new List<int>() { 50, 66, 60 };
            //act
            var actual = new Calculator().SumByRevenue(orderList, 4).ToList();

            //assert
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void 驗證_SelePrice_5筆一組()
        {
            //arrange
            var orderList = new Order().GetList();
            var expected = new List<int>() { 115, 140, 31 };
            //act
            var actual = new Calculator().SumBySellPrice(orderList, 5).ToList();

            //assert
            CollectionAssert.AreEqual(expected, actual);
        }


    }
    public interface IOrder
    {
        int Id { get; set; }
        int Cost { get; set; }
        int Revenue { get; set; }
        int SellPrice { get; set; }

        List<IOrder> GetList();
    }
    public class Order : IOrder
    {
        public int Id { get; set; }
        public int Cost { get; set; }
        public int Revenue { get; set; }
        public int SellPrice { get; set; }

        public List<IOrder> GetList()
        {
            return new List<IOrder>() {
                new Order { Id = 1, Cost = 1, Revenue = 11, SellPrice = 21 },
                new Order { Id = 2, Cost = 2, Revenue = 12, SellPrice = 22 },
                new Order { Id = 3, Cost = 3, Revenue = 13, SellPrice = 23 },
                new Order { Id = 4, Cost = 4, Revenue = 14, SellPrice = 24 },
                new Order { Id = 5, Cost = 5, Revenue = 15, SellPrice = 25 },
                new Order { Id = 6, Cost = 6, Revenue = 16, SellPrice = 26 },
                new Order { Id = 7, Cost = 7, Revenue = 17, SellPrice = 27 },
                new Order { Id = 8, Cost = 8, Revenue = 18, SellPrice = 28 },
                new Order { Id = 9, Cost = 9, Revenue = 19, SellPrice = 29 },
                new Order { Id = 10, Cost = 10, Revenue = 20, SellPrice = 30 },
                new Order { Id = 11, Cost = 11, Revenue = 21, SellPrice = 31 }
                };
        }


    }

    public interface ICalculator
    {

        IEnumerable<int> SumByCost(IEnumerable<IOrder> orders, int count);
        IEnumerable<int> SumByRevenue(IEnumerable<IOrder> orders, int count);
        IEnumerable<int> SumBySellPrice(IEnumerable<IOrder> orders, int count);
    }
    public class Calculator : ICalculator
    {

        public IEnumerable<int> SumByCost(IEnumerable<IOrder> orders, int count)
        {
            var list = orders.Select(r => r.Cost);
            return CalIt(list, count);
        }

        public IEnumerable<int> SumByRevenue(IEnumerable<IOrder> orders, int count)
        {
            var list = orders.Select(r => r.Revenue);
            return CalIt(list, count);
        }

        public IEnumerable<int> SumBySellPrice(IEnumerable<IOrder> orders, int count)
        {
            var list = orders.Select(r => r.SellPrice);
            return CalIt(list, count);
        }

        private IEnumerable<int> CalIt(IEnumerable<int> list, int count)
        {
            var result = new List<int>();
            for (int i = 0; i <= list.Count() / count; i++)
            {
                result.Add(list.Skip(i * count).Take(count).Sum());
            }
            return result;
        }
    }
}