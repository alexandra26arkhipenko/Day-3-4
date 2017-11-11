using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AlgorithmGCD;

namespace AlgorithmGCD.Tests
{
    [TestClass]
    public class AlgorithmGCDTest
    {
        [TestMethod]
        public void EuclideanMethod_DifParam_GCD_WithoutTime()
        {
            Assert.AreEqual(AlgorithmGCD.EuclideanMethod(40, 24), 8);
            Assert.AreEqual(AlgorithmGCD.EuclideanMethod(40, -24), 8);
            Assert.AreEqual(AlgorithmGCD.EuclideanMethod(40, 0), 40);
            Assert.AreEqual(AlgorithmGCD.EuclideanMethod(40, 24, 32), 8);
            Assert.AreEqual(AlgorithmGCD.EuclideanMethod(40, -24, 32), 8);
            Assert.AreEqual(AlgorithmGCD.EuclideanMethod(40, 24, 0), 8);
            Assert.AreEqual(AlgorithmGCD.EuclideanMethod(50, 25, 10, 95, -100), 5);
            Assert.AreEqual(AlgorithmGCD.EuclideanMethod(50, 25, 10, 95, 100), 5);
            Assert.AreEqual(AlgorithmGCD.EuclideanMethod(50, 25, 10, 0, -100), 5);
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
            
            Assert.AreEqual(AlgorithmGCD.BinEuclideanMethod(40, 0), 40);
            Assert.AreEqual(AlgorithmGCD.BinEuclideanMethod(40, 2), 2);
            Assert.AreEqual(AlgorithmGCD.BinEuclideanMethod(40, -2), 2);
            Assert.AreEqual(AlgorithmGCD.BinEuclideanMethod(40, 24, 32), 8);
            Assert.AreEqual(AlgorithmGCD.BinEuclideanMethod(40, 24, 0), 8);
            Assert.AreEqual(AlgorithmGCD.BinEuclideanMethod(40, 24, -8), 8);
            Assert.AreEqual(AlgorithmGCD.BinEuclideanMethod(40, 24, 32), 8);
            Assert.AreEqual(AlgorithmGCD.BinEuclideanMethod(50, 25, 10, 95, 100), 5);
            Assert.AreEqual(AlgorithmGCD.BinEuclideanMethod(50, 25, 10, 95, -100), 5);
            Assert.AreEqual(AlgorithmGCD.BinEuclideanMethod(50, 25, 10, 0, 100), 5);
        }

       








    }

}
