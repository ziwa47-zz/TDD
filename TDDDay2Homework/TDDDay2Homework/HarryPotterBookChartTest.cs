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
            var target = new List<int>() { 1, 0, 0, 0, 0 };

            var expected = 100m;
            //act
            var actual = GetDiscountPrice();

            //assert
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void Buy_HarrtPotter_1_1_0_0_0_And_TotalPrice_Must_Be_190()
        {
            //arrange 
            var target = new List<int>() { 1, 1, 0, 0, 0 };

            var expected = 190m;
            //act
            var actual = GetDiscountPrice();

            //assert
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void Buy_HarrtPotter_1_1_1_0_0_And_TotalPrice_Must_Be_270()
        {
            //arrange 
            var target = new List<int>() { 1, 1, 1, 0, 0 };

            var expected = 270m;
            //act
            var actual = GetDiscountPrice();

            //assert
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void Buy_HarrtPotter_1_1_1_1_0_And_TotalPrice_Must_Be_375()
        {
            //arrange 
            var target = new List<int>() { 1, 1, 1, 1, 0 };

            var expected = 375m;
            //act
            var actual = GetDiscountPrice();

            //assert
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void Buy_HarrtPotter_1_1_2_0_0_And_TotalPrice_Must_Be_370()
        {
            //arrange 
            var target = new List<int>() { 1, 1, 2, 0, 0 };

            var expected = 370m;
            //act
            var actual = GetDiscountPrice();

            //assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Buy_HarrtPotter_1_2_2_0_0_And_TotalPrice_Must_Be_460()
        {
            //arrange 
            var target = new List<int>() { 1, 2, 2, 0, 0 };

            var expected = 460m;
            //act
            var actual = GetDiscountPrice();

            //assert
            Assert.AreEqual(expected, actual);
        }

        private decimal GetDiscountPrice()
        {
            throw new NotImplementedException();
        }
    }
}
