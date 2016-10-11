using System;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Media3D;

namespace Test3D
{
    /// <summary>
    /// Class to represent and generate a Bezier Patch from a set of control points.
    /// </summary>
    public class BezierPatch
    {
        public ModelVisual3D Model { get; private set; }

        /// <summary>
        /// Initialize a new instance of the <see cref="BezierPatch"/> class.
        /// </summary>
        /// <param name="controlPoints">A 4x4 array containing the control points.</param>
        public BezierPatch(Vector3D[,] controlPoints)
        {
            double[,] bezierMat = new double[4, 4];

            Point3D[,] latticeVerts = new Point3D[11, 11];

            double u = 0;
            double v = 0;

            double step = 0.1;

            for (int width = 0; width < 11; ++width)
            {
                v = 0;
                for (int height = 0; height < 11; ++height)
                {
                    // Calculate our matrix given our interpolation.
                    bezierMat[0, 0] = B0(u) * B0(v);
                    bezierMat[0, 1] = B0(u) * B1(v);
                    bezierMat[0, 2] = B0(u) * B2(v);
                    bezierMat[0, 3] = B0(u) * B3(v);

                    bezierMat[1, 0] = B1(u) * B0(v);
                    bezierMat[1, 1] = B1(u) * B1(v);
                    bezierMat[1, 2] = B1(u) * B2(v);
                    bezierMat[1, 3] = B1(u) * B3(v);

                    bezierMat[2, 0] = B2(u) * B0(v);
                    bezierMat[2, 1] = B2(u) * B1(v);
                    bezierMat[2, 2] = B2(u) * B2(v);
                    bezierMat[2, 3] = B2(u) * B3(v);

                    bezierMat[3, 0] = B3(u) * B0(v);
                    bezierMat[3, 1] = B3(u) * B1(v);
                    bezierMat[3, 2] = B3(u) * B2(v);
                    bezierMat[3, 3] = B3(u) * B3(v);

                    Point3D result = new Point3D();

                    // Generate the resulting point used in the final mesh.
                    for (int i = 0; i < 4; ++i)
                    {
                        for (int j = 0; j < 4; ++j)
                        {
                            result += bezierMat[i, j] * controlPoints[i, j];
                        }
                    }

                    latticeVerts[width, height] = result;

                    v += step;
                }

                u += step;
            }

            // Generate the actual mesh from the lattice structure.
            Model3DGroup bezierPatch = new Model3DGroup();
            Material material = ShapeGenerator.GetSimpleMaterial(Color.FromArgb(255, 255, 0, 0));
            for (int col = 0; col < 10; ++col)
            {
                for (int row = 0; row < 10; ++row)
                {
                    Model3DGroup quad = ShapeGenerator.CreateQuad(
                        latticeVerts[row, col],
                        latticeVerts[row + 1, col],
                        latticeVerts[row + 1, col + 1],
                        latticeVerts[row, col + 1],
                        material);

                    bezierPatch.Children.Add(quad);
                }
            }

            Model = new ModelVisual3D();
            Model.Content = bezierPatch;
        }

        private static double B0(double u)
        {
            return (1 - u) * (1 - u) * (1 - u);
        }

        private static double B1(double u)
        {
            return 3 * u * (1 - u) * (1 - u);
        }

        private static double B2(double u)
        {
            return 3 * u * u * (1 - u);
        }

        private static double B3(double u)
        {
            return u * u * u;
        }
    }
}
