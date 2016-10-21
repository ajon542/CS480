using System.Collections.Generic;
using System.Drawing;
using System.Windows.Media.Media3D;

namespace comb1
{
    public class NaturalSpline : GameObject
    {
        private const int Rows = 5;
        private const int Cols = 5;
        private double[,] m;

        private List<Vector3D> controlPoints;

        public NaturalSpline(List<Vector3D> controlPoints)
        {
            this.controlPoints = controlPoints;

            // Precalculated inverse matrix.
            // TODO: Calculate this ourselves.
            m = new double[,]
            {
                {  0.5773809523809523,   -0.15476190476190466,   0.041666666666666075, -0.01190476190476275,   0.0059523809523724935 },
                { -0.15476190476190477,   0.30952380952380953,  -0.08333333333333326,   0.023809523809523725, -0.011904761904760974  },
                {  0.041666666666666664, -0.08333333333333333,   0.29166666666666663,  -0.08333333333333348,   0.041666666666666075  },
                { -0.011904761904761904,  0.023809523809523808, -0.08333333333333333,   0.30952380952380953,  -0.15476190476190466   },
                {  0.005952380952380952, -0.011904761904761904,  0.041666666666666664, -0.15476190476190477,   0.5773809523809523    },
            };

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
            t += m[i, 0] * 3 * (controlPoints[1] - controlPoints[0]);
            t += m[i, 1] * 3 * (controlPoints[2] - controlPoints[0]);
            t += m[i, 2] * 3 * (controlPoints[3] - controlPoints[1]);
            t += m[i, 3] * 3 * (controlPoints[4] - controlPoints[2]);
            t += m[i, 4] * 3 * (controlPoints[4] - controlPoints[3]);
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
