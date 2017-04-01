using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UtilityDelta.Domain.Test
{
    [TestClass]
    public class TestCalculateEngine
    {
        [TestMethod]
        public void TestOnePlusAnother()
        {
            var service = new CalculateEngine();
            var result = service.OnePlusAnother(.8, 5.1).Result;

            //Aren't compuers amazing?
            Assert.AreEqual(result, 5.8999999999999995);
        }

        [TestMethod]
        public void TestOneMinusAnother()
        {
            var service = new CalculateEngine();
            var result = service.OneMinusAnother(.8, 5.1).Result;
            
            Assert.AreEqual(result, -4.3);
        }
    }
}
