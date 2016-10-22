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

        #region Addition Operator

        [TestMethod]
        public void TestAdditionOperator1()
        {
            Fraction f1 = new Fraction(4, 1);
            Fraction f2 = new Fraction(1, 2);
            Assert.AreEqual(new Fraction(9, 2), f1 + f2);
        }

        [TestMethod]
        public void TestAdditionOperator2()
        {
            Fraction f1 = new Fraction(5);
            Fraction f2 = new Fraction(5);
            Assert.AreEqual(new Fraction(10), f1 + f2);
        }

        [TestMethod]
        public void TestAdditionOperator3()
        {
            Fraction f1 = new Fraction(5);
            f1 += new Fraction(5);
            Assert.AreEqual(new Fraction(10), f1);
        }

        #endregion

        #region Subtraction Operator

        [TestMethod]
        public void TestSubtractionOperator1()
        {
            Fraction f1 = new Fraction(4, 1);
            Fraction f2 = new Fraction(1, 2);
            Assert.AreEqual(new Fraction(7, 2), f1 - f2);
        }

        [TestMethod]
        public void TestSubtractionOperator2()
        {
            Fraction f1 = new Fraction(5);
            Fraction f2 = new Fraction(5);
            Assert.AreEqual(new Fraction(0), f1 - f2);
        }

        [TestMethod]
        public void TestSubtractionOperator3()
        {
            Fraction f1 = new Fraction(5);
            f1 -= new Fraction(5);
            Assert.AreEqual(new Fraction(0), f1);
        }

        #endregion

        #region Multiplication Operator

        [TestMethod]
        public void TestMultiplicationOperator1()
        {
            Fraction f1 = new Fraction(1, 2);
            Fraction f2 = new Fraction(1, 2);
            Assert.AreEqual(new Fraction(1, 4), f1 * f2);
        }

        [TestMethod]
        public void TestMultiplicationOperator2()
        {
            Fraction f1 = new Fraction(5, 2);
            Fraction f2 = new Fraction(6, 2);
            Assert.AreEqual(new Fraction(30, 4), f1 * f2);
        }

        [TestMethod]
        public void TestMultiplicationOperator3()
        {
            Fraction f1 = new Fraction(5, 2);
            Fraction f2 = new Fraction(6, 2);
            Assert.AreNotEqual(new Fraction(29, 4), f1 * f2);
        }

        [TestMethod]
        public void TestMultiplicationOperator4()
        {
            Fraction f1 = new Fraction(1, 2);
            Fraction f2 = new Fraction(1, 2);

            f1 *= f2;

            Assert.AreEqual(new Fraction(1, 4), f1);
            Assert.AreEqual(new Fraction(1, 2), f2);
        }

        #endregion

        #region Division Operator

        [TestMethod]
        public void TestDivisionOperator1()
        {
            Fraction f1 = new Fraction(4, 1);
            Fraction f2 = new Fraction(2, 1);
            Assert.AreEqual(new Fraction(4, 2), f1 / f2);
        }

        [TestMethod]
        public void TestDivisionOperator2()
        {
            Fraction f1 = new Fraction(4, 1);
            Fraction f2 = new Fraction(1, 2);
            Assert.AreEqual(new Fraction(8, 1), f1 / f2);
        }

        #endregion

        #region Conversion

        [TestMethod]
        public void TestConversion1()
        {
            Fraction f1 = new Fraction(4, 1);
            Fraction f2 = new Fraction(1, 2);
            Assert.AreEqual(new Fraction(1, 8), Fraction.Convert(f1, f2));
        }

        [TestMethod]
        public void TestConversion2()
        {
            Fraction f1 = new Fraction(2, 3);
            Fraction f2 = new Fraction(5, 6);
            Assert.AreEqual(new Fraction(15, 12), Fraction.Convert(f1, f2));
        }

        [TestMethod]
        public void TestConversion3()
        {
            Fraction f1 = new Fraction(2, 3);
            Fraction f2 = new Fraction(5, 6);
            Assert.AreEqual(f2, f1 * new Fraction(15, 12));
        }

        #endregion
    }
}
