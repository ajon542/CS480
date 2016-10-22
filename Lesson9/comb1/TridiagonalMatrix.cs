using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace comb1
{
    /// <summary>
    /// Class to represent a tridiagonal matrix for the usage in natural splines.
    /// TODO: We could probably make this more generic and turn into a matrix class.
    /// </summary>
    public class TridiagonalMatrix
    {
        /// <summary>
        /// Matrix data.
        /// </summary>
        public Fraction[,] Data { get; private set; }

        private int dimension;

        /// <summary>
        /// Initializes a new instance of the <see cref="TridiagonalMatrix"/> class.
        /// </summary>
        /// <param name="dimension">The dimension of the matrix.</param>
        public TridiagonalMatrix(int dimension)
        {
            this.dimension = dimension;
            Data = new Fraction[dimension, dimension];
        }

        /// <summary>
        /// Invert the matrix.
        /// TODO: We might be able to make this more generic.
        /// </summary>
        public void Invert()
        {
        }

        /// <summary>
        /// Subtract one row from another row in the matrix.
        /// </summary>
        /// <param name="r1">The row to subtract from.</param>
        /// <param name="r2">The row to use in the subtraction.</param>
        public void RowSubtract(int r1, int r2)
        {
            // Index bounds check.
            if (r1 >= dimension || r2 > dimension || r1 < 0 || r2 < 0)
            {
                throw new ArgumentOutOfRangeException("row index is out of range");
            }

            // Subtract row 2 from row 1.
            for (int col = 0; col < dimension; ++col)
            {
                Data[r1, col] -= Data[r2, col];
            }
        }

        /// <summary>
        /// Multiply a row in the matrix.
        /// </summary>
        /// <param name="row">The row to multiply.</param>
        /// <param name="multiplier">The multiplier.</param>
        public void RowMultiply(int row, Fraction multiplier)
        {
            // Index bounds check.
            if (row >= dimension || row < 0)
            {
                throw new ArgumentOutOfRangeException("row index is out of range");
            }

            // Subtract row 2 from row 1.
            for (int col = 0; col < dimension; ++col)
            {
                Data[row, col] *= multiplier;
            }
        }
    }
}
