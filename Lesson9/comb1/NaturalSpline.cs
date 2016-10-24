using System.Collections.Generic;
using System.Drawing;
using System.Windows.Media.Media3D;

namespace comb1
{
    public class NaturalSpline : GameObject
    {
        private List<Vector3D> controlPoints;

        private TridiagonalMatrix m;

        public NaturalSpline(List<Vector3D> controlPoints)
        {
            this.controlPoints = controlPoints;

            // Create a tridiagonal matrix using 5 control points and invert.
            m = new TridiagonalMatrix(5);

            m.Data[0, 0] = 2; m.Data[0, 1] = 1; m.Data[0, 2] = 0; m.Data[0, 3] = 0; m.Data[0, 4] = 0;
            m.Data[1, 0] = 1; m.Data[1, 1] = 4; m.Data[1, 2] = 1; m.Data[1, 3] = 0; m.Data[1, 4] = 0;
            m.Data[2, 0] = 0; m.Data[2, 1] = 1; m.Data[2, 2] = 4; m.Data[2, 3] = 1; m.Data[2, 4] = 0;
            m.Data[3, 0] = 0; m.Data[3, 1] = 0; m.Data[3, 2] = 1; m.Data[3, 3] = 4; m.Data[3, 4] = 1;
            m.Data[4, 0] = 0; m.Data[4, 1] = 0; m.Data[4, 2] = 0; m.Data[4, 3] = 1; m.Data[4, 4] = 2;

            m.Invert();

            // Obtain the tangents for each of the control points.
            Vector3D t0;
            Vector3D t1;
            Vector3D t2;
            Vector3D t3;
            Vector3D t4;
            GetTangent(out t0, 0);
            GetTangent(out t1, 1);
            GetTangent(out t2, 2);
            GetTangent(out t3, 3);
            GetTangent(out t4, 4);

            // Generate a curve between each of the points using the Hermite basis functions.
            GameObject h0 = new HermiteCurve(controlPoints[0], controlPoints[1], t0, t1);
            GameObject h1 = new HermiteCurve(controlPoints[1], controlPoints[2], t1, t2);
            GameObject h2 = new HermiteCurve(controlPoints[2], controlPoints[3], t2, t3);
            GameObject h3 = new HermiteCurve(controlPoints[3], controlPoints[4], t3, t4);

            // Add the points to the overall curve.
            Points = new List<Vector3D>();
            Points.AddRange(h0.Points);
            Points.AddRange(h1.Points);
            Points.AddRange(h2.Points);
            Points.AddRange(h3.Points);
        }

        private void GetTangent(out Vector3D t, int i)
        {
            t = new Vector3D();
            t += m.Inverse[i, 0].Value * 3 * (controlPoints[1] - controlPoints[0]);
            t += m.Inverse[i, 1].Value * 3 * (controlPoints[2] - controlPoints[0]);
            t += m.Inverse[i, 2].Value * 3 * (controlPoints[3] - controlPoints[1]);
            t += m.Inverse[i, 3].Value * 3 * (controlPoints[4] - controlPoints[2]);
            t += m.Inverse[i, 4].Value * 3 * (controlPoints[4] - controlPoints[3]);
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
