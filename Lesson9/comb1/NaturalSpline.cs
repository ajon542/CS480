using System.Collections.Generic;
using System.Drawing;
using System.Windows.Media.Media3D;

namespace comb1
{
    public class NaturalSpline : GameObject
    {
        private List<Vector3D> controlPoints;
        private int numberOfPoints;

        private TridiagonalMatrix m;

        public NaturalSpline(List<Vector3D> controlPoints)
        {
            this.controlPoints = controlPoints;
            numberOfPoints = controlPoints.Count;

            // Create a tridiagonal matrix using 5 control points and invert.
            m = new TridiagonalMatrix(numberOfPoints);

            // The result of the matrix inversion can be used to calculate the tangents
            // at each of the control points.
            m.Invert();

            // Obtain the tangents for each of the control points.
            List<Vector3D> tangents = new List<Vector3D>();
            for (int i = 0; i < numberOfPoints; ++i)
            {
                Vector3D t;
                GetTangent(out t, i);
                tangents.Add(t);
            }

            // Generate a curve between each of the points using the Hermite basis functions.
            // Add the points to the overall curve.
            Points = new List<Vector3D>();
            for (int i = 0; i < numberOfPoints - 1; ++i)
            {
                GameObject h = new HermiteCurve(
                    controlPoints[i],
                    controlPoints[i + 1],
                    tangents[i],
                    tangents[i + 1]);
                Points.AddRange(h.Points);
            }
        }

        private void GetTangent(out Vector3D t, int i)
        {
            t = new Vector3D();

            for (int j = 0; j < numberOfPoints; ++j)
            {
                if (j == 0)
                {
                    t += m.Inverse[i, j].Value * 3 * (controlPoints[j + 1] - controlPoints[j]);
                }
                else if (j == numberOfPoints - 1)
                {
                    t += m.Inverse[i, j].Value * 3 * (controlPoints[j] - controlPoints[j - 1]);
                }
                else
                {
                    t += m.Inverse[i, j].Value * 3 * (controlPoints[j + 1] - controlPoints[j - 1]);
                }
            }
        }

        public override void Render(Graphics graphics)
        {
            Point[] points = GetPoints();
            for (int i = 0; i < points.Length - 1; ++i)
            {
                graphics.DrawLine(Pens.Green, points[i].X, points[i].Y, points[i + 1].X, points[i + 1].Y);
            }
        }
    }
}
