using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using comb1;

namespace FractionTest
{
    [TestClass]
    public class FractionTests
    {
        #region Test Construction and Value

        [TestMethod]
        public void TestMethod1()
        {
            Fraction f = new Fraction(1, 2);
            Assert.AreEqual(0.5, f.Value);
        }

        [TestMethod]
        public void TestMethod2()
        {
            Fraction f = new Fraction(2, 1);
            Assert.AreEqual(2, f.Value);
        }

        #endregion

        #region Test Equality

        [TestMethod]
        public void TestMethod3()
        {
            Assert.AreEqual(new Fraction(2, 1), new Fraction(4, 2));
        }

        [TestMethod]
        public void TestMethod4()
        {
            Assert.AreEqual(new Fraction(1, 3), new Fraction(1, 3));
        }

        [TestMethod]
        public void TestMethod5()
        {
            Assert.AreNotEqual(new Fraction(2, 3), new Fraction(4, 2));
        }

        #endregion
    }
}
