using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using comb1;

namespace MatrixTest
{
    [TestClass]
    public class MatrixTests
    {
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
    }
}
