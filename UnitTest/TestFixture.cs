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

        [Test,
         TestCase("", false),
         TestCase("asbhkas", false),
         TestCase("111111111111111111111111111111", false),
         TestCase("24199998", true)]
        public void TestValidateSorszam(string sorszam, bool expectedResult)
        {
            var orderController = new OrderController();

            // Act
            var actualResult = orderController.ValidateSorszam(sorszam);

            // Assert
            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test,
         TestCase("543", false),
         TestCase("0", false),
        
         TestCase("22", true)]
        public void TestValidateEjszaka(int ejszaka, bool expectedResult)
        {
            var orderController = new OrderController();

            // Act
            var actualResult = orderController.ValidateEjszaka(ejszaka);

            // Assert
            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test,
         TestCase("0", false),
         TestCase("1", false),
         
         TestCase("6000", true)]
        public void TestValidateForint(int forint, bool expectedResult)
        {
            var orderController = new OrderController();

            // Act
            var actualResult = orderController.ValidateForint(forint);

            // Assert
            Assert.AreEqual(expectedResult, actualResult);
        }
    }
}
