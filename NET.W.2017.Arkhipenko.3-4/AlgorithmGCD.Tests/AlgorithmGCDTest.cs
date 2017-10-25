using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AlgorithmGCD;

namespace AlgorithmGCD.Tests
{
    [TestClass]
    public class AlgorithmGCDTest
    {
        [TestMethod]
        public void EuclideanMethod_DifParam_GCD()
        {
           // Assert.AreEqual(AlgorithmGCD.EuclideanMethod(40, 24).Item1, 8);
            //Assert.AreEqual(AlgorithmGCD.EuclideanMethod(40, -24).Item1, 8);
            //Assert.AreEqual(AlgorithmGCD.EuclideanMethod(40, 0).Item1, 40);
           // Assert.AreEqual(AlgorithmGCD.EuclideanMethod(40, 24, 32).Item1, 8);
            Assert.AreEqual(AlgorithmGCD.EuclideanMethod(50, 25, 10, 95, -100).Item1, 5);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Null_Exc()
        {
            AlgorithmGCD.EuclideanMethod();
            AlgorithmGCD.BinEuclideanMethod();
        }
        [TestMethod]
        public void BinEuclideanMethod_DifParam_GCD()
        {
            
            Assert.AreEqual(AlgorithmGCD.BinEuclideanMethod(40, 0).Item1, 40);
            Assert.AreEqual(AlgorithmGCD.BinEuclideanMethod(40, 24, 32).Item1, 8);
            Assert.AreEqual(AlgorithmGCD.BinEuclideanMethod(40, -24, 32).Item1, 8);
            Assert.AreEqual(AlgorithmGCD.BinEuclideanMethod(50, 25, 10, 95, 100).Item1, 5);
        }

        [TestMethod]
        public void TimeControler_EuclideanMethod()
        {
            Assert.IsFalse(AlgorithmGCD.EuclideanMethod(24, 48).Item2 < 0);
        }
        [TestMethod]
        public void TimeControler_BinEuclideanMethod()
        {
            Assert.IsFalse(AlgorithmGCD.BinEuclideanMethod(24,48).Item2 < 0);
        }








    }

}
