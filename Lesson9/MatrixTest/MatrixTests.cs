using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using comb1;

namespace MatrixTest
{
    [TestClass]
    public class MatrixTests
    {
        #region Row Multiply

        [TestMethod]
        public void TestRowMulitply1()
        {
            TridiagonalMatrix m = new TridiagonalMatrix(2);

            m.Data[0, 0] = 1;
            m.Data[0, 1] = 2;
            m.Data[1, 0] = 3;
            m.Data[1, 1] = 4;

            m.RowMultiply(0, 2);

            Assert.AreEqual(2, m.Data[0, 0]);
            Assert.AreEqual(4, m.Data[0, 1]);
            Assert.AreEqual(3, m.Data[1, 0]);
            Assert.AreEqual(4, m.Data[1, 1]);
        }

        [TestMethod]
        public void TestRowMulitply2()
        {
            TridiagonalMatrix m = new TridiagonalMatrix(2);

            m.Data[0, 0] = 1;
            m.Data[0, 1] = 2;
            m.Data[1, 0] = 3;
            m.Data[1, 1] = 4;

            m.RowMultiply(1, -2);

            Assert.AreEqual(1, m.Data[0, 0]);
            Assert.AreEqual(2, m.Data[0, 1]);
            Assert.AreEqual(-6, m.Data[1, 0]);
            Assert.AreEqual(-8, m.Data[1, 1]);
        }

        #endregion

        #region Row Subtract

        [TestMethod]
        public void TestRowSubtract1()
        {
            TridiagonalMatrix m = new TridiagonalMatrix(2);

            m.Data[0, 0] = 1;
            m.Data[0, 1] = 2;
            m.Data[1, 0] = 3;
            m.Data[1, 1] = 4;

            m.RowSubtract(0, 1);

            Assert.AreEqual(-2, m.Data[0, 0]);
            Assert.AreEqual(-2, m.Data[0, 1]);
            Assert.AreEqual(3, m.Data[1, 0]);
            Assert.AreEqual(4, m.Data[1, 1]);
        }

        [TestMethod]
        public void TestRowSubtract2()
        {
            TridiagonalMatrix m = new TridiagonalMatrix(2);

            m.Data[0, 0] = 1;
            m.Data[0, 1] = 2;
            m.Data[1, 0] = 3;
            m.Data[1, 1] = 4;

            m.RowSubtract(1, 0);

            Assert.AreEqual(1, m.Data[0, 0]);
            Assert.AreEqual(2, m.Data[0, 1]);
            Assert.AreEqual(2, m.Data[1, 0]);
            Assert.AreEqual(2, m.Data[1, 1]);
        }

        #endregion

        #region Invert

        [TestMethod]
        public void TestInvert1()
        {
            TridiagonalMatrix m = new TridiagonalMatrix(2);

            m.Data[0, 0] = 2;
            m.Data[0, 1] = 1;
            m.Data[1, 0] = 1;
            m.Data[1, 1] = 4;

            m.Invert();

            // Check data.
            Assert.AreEqual(1, m.Data[0, 0]);
            Assert.AreEqual(new Fraction(1, 2), m.Data[0, 1]);
            Assert.AreEqual(0, m.Data[1, 0]);
            Assert.AreEqual(new Fraction(7, 2), m.Data[1, 1]);

            // Check inverse.
            Assert.AreEqual(new Fraction(1, 2), m.Inverse[0, 0]);
            Assert.AreEqual(0, m.Inverse[0, 1]);
            Assert.AreEqual(new Fraction(-1, 2), m.Inverse[1, 0]);
            Assert.AreEqual(1, m.Inverse[1, 1]);
        }


        [TestMethod]
        public void TestInvert2()
        {
            TridiagonalMatrix m = new TridiagonalMatrix(3);

            m.Data[0, 0] = 2; m.Data[0, 1] = 1; m.Data[0, 2] = 0;
            m.Data[1, 0] = 1; m.Data[1, 1] = 4; m.Data[1, 2] = 1;
            m.Data[2, 0] = 0; m.Data[2, 1] = 1; m.Data[2, 2] = 2;

            m.Invert();

            // Check data.
            Assert.AreEqual(new Fraction(1, 1), m.Data[0, 0]);
            Assert.AreEqual(new Fraction(1, 2), m.Data[0, 1]);
            Assert.AreEqual(new Fraction(0, 2), m.Data[0, 2]);

            Assert.AreEqual(new Fraction(0, 1), m.Data[1, 0]);
            Assert.AreEqual(new Fraction(1, 1), m.Data[1, 1]);
            Assert.AreEqual(new Fraction(2, 7), m.Data[1, 2]);

            Assert.AreEqual(new Fraction(0, 1), m.Data[2, 0]);
            Assert.AreEqual(new Fraction(0, 1), m.Data[2, 1]);
            Assert.AreEqual(new Fraction(12, 7), m.Data[2, 2]);

            // Check inverse.
            Assert.AreEqual(new Fraction(1, 2), m.Inverse[0, 0]);
            Assert.AreEqual(new Fraction(0, 1), m.Inverse[0, 1]);
            Assert.AreEqual(new Fraction(0, 1), m.Inverse[0, 2]);

            Assert.AreEqual(new Fraction(-2, 14), m.Inverse[1, 0]);
            Assert.AreEqual(new Fraction(2, 7), m.Inverse[1, 1]);
            Assert.AreEqual(new Fraction(0, 1), m.Inverse[1, 2]);

            Assert.AreEqual(new Fraction(2, 14), m.Inverse[2, 0]);
            Assert.AreEqual(new Fraction(-2, 7), m.Inverse[2, 1]);
            Assert.AreEqual(new Fraction(1, 1), m.Inverse[2, 2]);
        }

        #endregion
    }
}
