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

        public Fraction[,] Inverse { get; private set; }

        private int dimension;

        /// <summary>
        /// Initializes a new instance of the <see cref="TridiagonalMatrix"/> class.
        /// </summary>
        /// <param name="dimension">The dimension of the matrix.</param>
        public TridiagonalMatrix(int dimension)
        {
            this.dimension = dimension;
            Data = new Fraction[dimension, dimension];
            Inverse = new Fraction[dimension, dimension];

            // Initialize the inverse matrix to be the identity.
            for (int row = 0; row < dimension; ++row)
            {
                for (int col = 0; col < dimension; ++col)
                {
                    if (row == col)
                    {
                        Inverse[row, col] = 1;
                    }
                    else
                    {
                        Inverse[row, col] = 0;
                    }
                }
            }
        }

        /// <summary>
        /// Invert the matrix.
        /// TODO: We might be able to make this more generic.
        /// </summary>
        public void Invert()
        {
            // Zero out the lower diagonal.
            int col = 0;
            for (int row = 1; row < dimension; ++row)
            {
                // Find fraction that will convert first arg into second.
                Fraction f = Fraction.Convert(Data[row - 1, col], Data[row, col]);

                // Multiply that row by the fraction amount.
                RowMultiply(row - 1, f);

                // Subtract that row from the current row.
                RowSubtract(row, row - 1);

                ++col;
            }

            // Zero out the upper diagonal.
            col = dimension - 1;
            for (int row = dimension - 1; row > 0; --row)
            {
                // Find fraction that will convert first arg into second.
                Fraction f = Fraction.Convert(Data[row - 1, col], Data[row, col]);

                // Multiply that row by the fraction amount.
                RowMultiply(row - 1, f);

                // Subtract that row from the current row.
                RowSubtract(row - 1, row);

                --col;
            }

            // Convert to identity.
            col = 0;
            for (int row = 0; row < dimension; ++row)
            {
                RowDivide(row, Data[row, col]);

                ++col;
            }
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

            // Do the same for the inverse matrix.
            for (int col = 0; col < dimension; ++col)
            {
                Inverse[r1, col] -= Inverse[r2, col];
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

            // Do the same for the inverse matrix.
            for (int col = 0; col < dimension; ++col)
            {
                Inverse[row, col] *= multiplier;
            }
        }

        /// <summary>
        /// Divide a row in the matrix.
        /// </summary>
        /// <param name="row">The row to divide.</param>
        /// <param name="divisor">The divisor.</param>
        public void RowDivide(int row, Fraction divisor)
        {
            // Index bounds check.
            if (row >= dimension || row < 0)
            {
                throw new ArgumentOutOfRangeException("row index is out of range");
            }

            // Subtract row 2 from row 1.
            for (int col = 0; col < dimension; ++col)
            {
                Data[row, col] /= divisor;
            }

            // Do the same for the inverse matrix.
            for (int col = 0; col < dimension; ++col)
            {
                Inverse[row, col] /= divisor;
            }
        }
    }
}
