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
        public void TestValue1()
        {
            Fraction f = new Fraction(1, 2);
            Assert.AreEqual(0.5, f.Value);
        }

        [TestMethod]
        public void TestValue2()
        {
            Fraction f = new Fraction(2, 1);
            Assert.AreEqual(2, f.Value);
        }

        #endregion

        #region Test Equality

        [TestMethod]
        public void TestEquality1()
        {
            Assert.AreEqual(new Fraction(2, 1), new Fraction(4, 2));
        }

        [TestMethod]
        public void TestEquality2()
        {
            Assert.AreEqual(new Fraction(1, 3), new Fraction(1, 3));
        }

        [TestMethod]
        public void TestEquality3()
        {
            Assert.AreNotEqual(new Fraction(2, 3), new Fraction(4, 2));
        }

        #endregion

        #region Invert

        [TestMethod]
        public void TestInvert1()
        {
            Fraction f = new Fraction(2, 3);
            f.Invert();
            Assert.AreEqual(new Fraction(3, 2), f);
        }

        #endregion

    }
}
