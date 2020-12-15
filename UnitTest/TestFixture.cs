using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FinalVersion.Controllers;
using NUnit.Framework;

namespace UnitTest
{
    public class TestFixture
    {
        [Test,
         TestCase("--budapest", false),
         TestCase("Buda4", false),
         TestCase("1234", false),
         TestCase("Budapest", true)]
        public void TestValidateTelepules(string telepules, bool expectedResult)
        {
            var orderController = new OrderController();

            // Act
            var actualResult = orderController.ValidateTelepules(telepules);

            // Assert
            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test,
         TestCase("", false),
         TestCase("jkjhzzdfcvbnbhjzgftfcvn nvhgfrdsegnjuztzfrgbjhghnjkhz", false),
         TestCase("Hotel C 56-os gárda", true)]
        public void TestValidateHotelnev(string hotelnev, bool expectedResult)
        {
            var orderController = new OrderController();

            // Act
            var actualResult = orderController.ValidateHotelnev(hotelnev);

            // Assert
            Assert.AreEqual(expectedResult, actualResult);
        }
    }
}
