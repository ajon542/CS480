using System.Collections.Generic;
using System.Drawing;
using System.Windows.Media.Media3D;

namespace comb1
{
    public class NaturalSpline
    {
        private const int Rows = 5;
        private const int Cols = 5;
        private double[,] m;

        private Vector3D p0 = new Vector3D(100, 100, 0);
        private Vector3D p1 = new Vector3D(200, 200, 0);
        private Vector3D p2 = new Vector3D(300, 200, 0);
        private Vector3D p3 = new Vector3D(400, 200, 0);
        private Vector3D p4 = new Vector3D(500, 100, 0);

        /// <summary>
        /// The points representing the curve.
        /// </summary>
        public List<Vector3D> Points { get; set; }

        public NaturalSpline(List<Vector3D> controlPoints)
        {
            // Precalculated inverse matrix.
            // TODO: Calculate this ourselves.
            m = new double[,]
            {
                { 0.5773809523809523, -0.15476190476190466, 0.041666666666666075, -0.01190476190476275, 0.0059523809523724935 },
                { -0.15476190476190477, 0.30952380952380953, -0.08333333333333326, 0.023809523809523725, -0.011904761904760974 },
                { 0.041666666666666664, -0.08333333333333333, 0.29166666666666663, -0.08333333333333348, 0.041666666666666075 },
                { -0.011904761904761904, 0.023809523809523808, -0.08333333333333333, 0.30952380952380953, -0.15476190476190466 },
                { 0.005952380952380952, -0.011904761904761904, 0.041666666666666664, -0.15476190476190477, 0.5773809523809523 },
            };

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

            HermiteCurve h0 = new HermiteCurve(p0, p1, t0, t1);
            HermiteCurve h1 = new HermiteCurve(p1, p2, t1, t2);
            HermiteCurve h2 = new HermiteCurve(p2, p3, t2, t3);
            HermiteCurve h3 = new HermiteCurve(p3, p4, t3, t4);

            Points = new List<Vector3D>();
            Points.AddRange(h0.Points);
            Points.AddRange(h1.Points);
            Points.AddRange(h2.Points);
            Points.AddRange(h3.Points);
        }

        private void GetTangent(out Vector3D t, int i)
        {
            t = new Vector3D();
            t += m[i, 0] * 3 * (p1 - p0);
            t += m[i, 1] * 3 * (p2 - p0);
            t += m[i, 2] * 3 * (p3 - p1);
            t += m[i, 3] * 3 * (p4 - p2);
            t += m[i, 4] * 3 * (p4 - p3);
        }

        /// <summary>
        /// Convert the list of vectors to points on the screen.
        /// </summary>
        /// <returns>Array of screen points.</returns>
        public Point[] GetPoints()
        {
            List<Point> points = new List<Point>();
            foreach (Vector3D v in Points)
            {
                points.Add(new Point((int)v.X, (int)v.Y));
            }
            return points.ToArray();
        }
    }
}
