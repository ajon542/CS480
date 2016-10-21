using System.Collections.Generic;
using System.Drawing;
using System.Windows.Media.Media3D;

namespace comb1
{
    /// <summary>
    /// Class to generate a curve based on the Hermite functions.
    /// </summary>
    public class HermiteCurve : GameObject
    {
        /// <summary>
        /// Generate the points on the curve.
        /// </summary>
        /// <param name="p0">The start point.</param>
        /// <param name="p1">The end point.</param>
        /// <param name="t0">The tangent at the start point.</param>
        /// <param name="t1">The tangent at the end point.</param>
        public HermiteCurve(Vector3D p0, Vector3D p1, Vector3D t0, Vector3D t1)
        {
            Points = new List<Vector3D>();
            float t = 0;
            for (int i = 0; i <= 100; ++i, t += 0.01f)
            {
                //f0(t) = -t^3 + 3t^2 - 3t + 1
                //f1(t) =  3t^3 - 6t^2 + 3t
                //f2(t) = -3t^3 + 3t^2
                //f3(t) =  t^3
                float t2 = t * t;
                float t3 = t2 * t;
                float f0 = (2 * t3) - (3 * t2) + 1;
                float f1 = (-2 * t3) + (3 * t2);
                float f2 = (t3) - (2 * t2) + t;
                float f3 = t3 - t2;

                Vector3D result = (f0 * p0) + (f1 * p1) + (f2 * t0) + (f3 * t1);
                Points.Add(result);
            }
        }

        /// <summary>
        /// Draw the  curve defined by the Hermite functions.
        /// </summary>
        /// <param name="graphics">The drawing surface.</param>
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
