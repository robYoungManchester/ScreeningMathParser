using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ScreeningMathParser;
namespace ScreeningMathParser.Tests
{
    [TestClass()]
    public class ParserTests
    {
        [TestMethod()]
        public void evaluateNumericOperatorsTest()
        {
            var parser = new MathParser();

            var result = parser.evaluateNumericOperators("34a98");
            Assert.AreEqual(result,"132");
        }

        //Input: 3a2c4
        //Result: 20
        [TestMethod()]
        public void Test1()
        {
            var parser = new MathParser();

            var result = parser.parseString("3a2c4");
            Assert.AreEqual(result, 20.0f);
        }

        //Input: 32a2d2
        //Result: 17
        [TestMethod()]
        public void Test2()
        {
            var parser = new MathParser();

            var result = parser.parseString("32a2d2");
            Assert.AreEqual(result, 17.0f);
        }

        //Input: 500a10b66c32
        //Result: 14208
        [TestMethod()]
        public void Test3()
        {
            var parser = new MathParser();

            var result = parser.parseString("500a10b66c32");
            Assert.AreEqual(result, 14208.0f);
        }

        //Input: 3ae4c66fb32
        //Result: 235
        [TestMethod()]
        public void Test4()
        {
            var parser = new MathParser();

            var result = parser.parseString("3ae4c66fb32");
            Assert.AreEqual(result, 235.0f);
        }

        //Input: 3c4d2aee2a4c41fc4f
        //Result: 990
        [TestMethod()]
        public void Test5()
        {
            var parser = new MathParser();

            var result = parser.parseString("3c4d2aee2a4c41fc4f");
            Assert.AreEqual(result, 990.0f);
        }
    }
}
