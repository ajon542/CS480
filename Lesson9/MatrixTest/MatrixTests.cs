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
            Assert.AreEqual(0, m.Data[0, 1]);
            Assert.AreEqual(0, m.Data[1, 0]);
            Assert.AreEqual(1, m.Data[1, 1]);

            // Check inverse.
            Assert.AreEqual(new Fraction(256, 448), m.Inverse[0, 0]);
            Assert.AreEqual(new Fraction(-64, 448), m.Inverse[0, 1]);
            Assert.AreEqual(new Fraction(-2, 14), m.Inverse[1, 0]);
            Assert.AreEqual(new Fraction(4, 14), m.Inverse[1, 1]);
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
            Assert.AreEqual(1, m.Data[0, 0]);
            Assert.AreEqual(0, m.Data[0, 1]);
            Assert.AreEqual(0, m.Data[0, 2]);

            Assert.AreEqual(0, m.Data[1, 0]);
            Assert.AreEqual(1, m.Data[1, 1]);
            Assert.AreEqual(0, m.Data[1, 2]);

            Assert.AreEqual(0, m.Data[2, 0]);
            Assert.AreEqual(0, m.Data[2, 1]);
            Assert.AreEqual(1, m.Data[2, 2]);

            // Check inverse.
            Assert.AreEqual(new Fraction(7, 12), m.Inverse[0, 0]);
            Assert.AreEqual(new Fraction(-1, 6), m.Inverse[0, 1]);
            Assert.AreEqual(new Fraction(1, 12), m.Inverse[0, 2]);

            Assert.AreEqual(new Fraction(-1, 6), m.Inverse[1, 0]);
            Assert.AreEqual(new Fraction(1, 3), m.Inverse[1, 1]);
            Assert.AreEqual(new Fraction(-1, 6), m.Inverse[1, 2]);

            Assert.AreEqual(new Fraction(1, 12), m.Inverse[2, 0]);
            Assert.AreEqual(new Fraction(-1, 6), m.Inverse[2, 1]);
            Assert.AreEqual(new Fraction(7, 12), m.Inverse[2, 2]);
        }

        [TestMethod]
        public void TestInvert3()
        {
            TridiagonalMatrix m = new TridiagonalMatrix(4);

            m.Data[0, 0] = 3; m.Data[0, 1] = 2; m.Data[0, 2] = 0; m.Data[0, 3] = 0;
            m.Data[1, 0] = 2; m.Data[1, 1] = 5; m.Data[1, 2] = 2; m.Data[1, 3] = 0;
            m.Data[2, 0] = 0; m.Data[2, 1] = 2; m.Data[2, 2] = 1; m.Data[2, 3] = 2;
            m.Data[3, 0] = 0; m.Data[3, 1] = 0; m.Data[3, 2] = 2; m.Data[3, 3] = 7;

            m.Invert();

            // Check data.
            Assert.AreEqual(1, m.Data[0, 0]);
            Assert.AreEqual(0, m.Data[0, 1]);
            Assert.AreEqual(0, m.Data[0, 2]);
            Assert.AreEqual(0, m.Data[0, 3]);

            Assert.AreEqual(0, m.Data[1, 0]);
            Assert.AreEqual(1, m.Data[1, 1]);
            Assert.AreEqual(0, m.Data[1, 2]);
            Assert.AreEqual(0, m.Data[1, 3]);

            Assert.AreEqual(0, m.Data[2, 0]);
            Assert.AreEqual(0, m.Data[2, 1]);
            Assert.AreEqual(1, m.Data[2, 2]);
            Assert.AreEqual(0, m.Data[2, 3]);

            Assert.AreEqual(0, m.Data[3, 0]);
            Assert.AreEqual(0, m.Data[3, 1]);
            Assert.AreEqual(0, m.Data[3, 2]);
            Assert.AreEqual(1, m.Data[3, 3]);

            // Check inverse.
            Assert.AreEqual(new Fraction( 13, 51), m.Inverse[0, 0]);
            Assert.AreEqual(new Fraction(  2, 17),  m.Inverse[0, 1]);
            Assert.AreEqual(new Fraction(-28, 51), m.Inverse[0, 2]);
            Assert.AreEqual(new Fraction(  8, 51), m.Inverse[0, 3]);

            Assert.AreEqual(new Fraction( 2, 17), m.Inverse[1, 0]);
            Assert.AreEqual(new Fraction(-3, 17), m.Inverse[1, 1]);
            Assert.AreEqual(new Fraction(14, 17), m.Inverse[1, 2]);
            Assert.AreEqual(new Fraction(-4, 17), m.Inverse[1, 3]);

            Assert.AreEqual(new Fraction(-28, 51), m.Inverse[2, 0]);
            Assert.AreEqual(new Fraction( 14, 17),  m.Inverse[2, 1]);
            Assert.AreEqual(new Fraction(-77, 51), m.Inverse[2, 2]);
            Assert.AreEqual(new Fraction( 22, 51), m.Inverse[2, 3]);

            Assert.AreEqual(new Fraction( 8, 51), m.Inverse[3, 0]);
            Assert.AreEqual(new Fraction(-4, 17),  m.Inverse[3, 1]);
            Assert.AreEqual(new Fraction(22, 51), m.Inverse[3, 2]);
            Assert.AreEqual(new Fraction( 1, 51), m.Inverse[3, 3]);
        }

        [TestMethod]
        public void TestInvert4()
        {
            TridiagonalMatrix m = new TridiagonalMatrix(4);

            m.Data[0, 0] = 2; m.Data[0, 1] = 1; m.Data[0, 2] = 0; m.Data[0, 3] = 0;
            m.Data[1, 0] = 1; m.Data[1, 1] = 4; m.Data[1, 2] = 1; m.Data[1, 3] = 0;
            m.Data[2, 0] = 0; m.Data[2, 1] = 1; m.Data[2, 2] = 4; m.Data[2, 3] = 1;
            m.Data[3, 0] = 0; m.Data[3, 1] = 0; m.Data[3, 2] = 1; m.Data[3, 3] = 2;

            m.Invert();

            // Check data.
            Assert.AreEqual(1, m.Data[0, 0]);
            Assert.AreEqual(0, m.Data[0, 1]);
            Assert.AreEqual(0, m.Data[0, 2]);
            Assert.AreEqual(0, m.Data[0, 3]);

            Assert.AreEqual(0, m.Data[1, 0]);
            Assert.AreEqual(1, m.Data[1, 1]);
            Assert.AreEqual(0, m.Data[1, 2]);
            Assert.AreEqual(0, m.Data[1, 3]);

            Assert.AreEqual(0, m.Data[2, 0]);
            Assert.AreEqual(0, m.Data[2, 1]);
            Assert.AreEqual(1, m.Data[2, 2]);
            Assert.AreEqual(0, m.Data[2, 3]);

            Assert.AreEqual(0, m.Data[3, 0]);
            Assert.AreEqual(0, m.Data[3, 1]);
            Assert.AreEqual(0, m.Data[3, 2]);
            Assert.AreEqual(1, m.Data[3, 3]);

            // Check inverse.
            Assert.AreEqual(new Fraction(26, 45), m.Inverse[0, 0]);
            Assert.AreEqual(new Fraction(-7, 45), m.Inverse[0, 1]);
            Assert.AreEqual(new Fraction(2, 45), m.Inverse[0, 2]);
            Assert.AreEqual(new Fraction(-1, 45), m.Inverse[0, 3]);

            Assert.AreEqual(new Fraction(-7, 45), m.Inverse[1, 0]);
            Assert.AreEqual(new Fraction(14, 45), m.Inverse[1, 1]);
            Assert.AreEqual(new Fraction(-4, 45), m.Inverse[1, 2]);
            Assert.AreEqual(new Fraction(2, 45), m.Inverse[1, 3]);

            Assert.AreEqual(new Fraction(2, 45), m.Inverse[2, 0]);
            Assert.AreEqual(new Fraction(-4, 45), m.Inverse[2, 1]);
            Assert.AreEqual(new Fraction(14, 45), m.Inverse[2, 2]);
            Assert.AreEqual(new Fraction(-7, 45), m.Inverse[2, 3]);

            Assert.AreEqual(new Fraction(-1, 45), m.Inverse[3, 0]);
            Assert.AreEqual(new Fraction(2, 45), m.Inverse[3, 1]);
            Assert.AreEqual(new Fraction(-7, 45), m.Inverse[3, 2]);
            Assert.AreEqual(new Fraction(26, 45), m.Inverse[3, 3]);
        }

        #endregion
    }
}
