using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Converter;

namespace Converter.Tests
{
    [TestClass]
    public class ConverterTest
    {
        [TestMethod]
        public void DoubleHelperTest()
        {
            double x = -255.255;
            Assert.AreEqual(x.DoubleHelper(), "1100000001101111111010000010100011110101110000101000111101011100");

            x = 255.255;
            Assert.AreEqual(x.DoubleHelper(), "0100000001101111111010000010100011110101110000101000111101011100");
            x = 4294967295.0;
            Assert.AreEqual(x.DoubleHelper(), "0100000111101111111111111111111111111111111000000000000000000000");
            x = double.MinValue;
            Assert.AreEqual(x.DoubleHelper(), "1111111111101111111111111111111111111111111111111111111111111111");
            x = double.MaxValue;
            Assert.AreEqual(x.DoubleHelper(), "0111111111101111111111111111111111111111111111111111111111111111");
            x = double.Epsilon;
            Assert.AreEqual(x.DoubleHelper(), "0000000000000000000000000000000000000000000000000000000000000001");
            x = double.NaN;
            Assert.AreEqual(x.DoubleHelper(), "1111111111111000000000000000000000000000000000000000000000000000");


        }
    }
}
