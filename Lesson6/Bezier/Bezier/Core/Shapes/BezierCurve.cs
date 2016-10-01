using System;
using System.Collections.Generic;
using System.Drawing;

namespace GameEngine.Core.Shapes
{
    /// <summary>
    /// Class representing a Bezier curve.
    /// </summary>
    public class BezierCurve
    {
        /// <summary>
        /// The points representing the curve.
        /// </summary>
        public List<Vector2> Points { get; set; }

        private int Choose(int n, int k)
        {
            if (k > n) return 0;
            if (k * 2 > n) k = n - k;
            if (k == 0) return 1;

            int result = n;
            for (int i = 2; i <= k; ++i)
            {
                result *= (n - i + 1);
                result /= i;
            }
            return result;
        }

        private Vector2 BezierDegreeN(List<Vector2> controls, float t)
        {
            Vector2 result = new Vector2(0, 0);
            int n = controls.Count - 1;
            for (int k = 0; k < controls.Count; ++k)
            {
                int mult = Choose(n, k);
                int aExp = n - k;
                int bExp = k;
                double a = Math.Pow(1 - t, aExp);
                double b = Math.Pow(t, bExp);

                result.x += mult * a * b * controls[k].x;
                result.y += mult * a * b * controls[k].y;
            }
            return result;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BezierCurve"/> class.
        /// </summary>
        /// <param name="p0">The start point.</param>
        /// <param name="p1">The first control point.</param>
        /// <param name="p2">The second control point.</param>
        /// <param name="p3">The end point.</param>
        public BezierCurve(Vector2 p0, Vector2 p1, Vector2 p2, Vector2 p3)
        {
            Points = new List<Vector2>();

            List<Vector2> controls = new List<Vector2> { p0, p1, p2, p3 };

            float t = 0;
            for (int i = 0; i <= 100; ++i)
            {
                float a = 1 - t;
                float b = t;

                Vector2 point = BezierDegreeN(controls, t);

                Points.Add(point);

                t += 0.01f;
            }
        }

        /// <summary>
        /// Convert the list of vectors (double) to points on the screen (int).
        /// </summary>
        /// <returns>Array of screen points.</returns>
        public virtual Point[] GetPoints()
        {
            List<Point> points = new List<Point>();
            for (int i = 0; i < Points.Count - 1; ++i)
            {
                Vector2 a = new Vector2(Points[i].x, Points[i].y);
                Vector2 b = new Vector2(Points[i + 1].x, Points[i + 1].y);
                Line line = new Line(a, b);
                points.AddRange(line.GetPoints());
            }
            return points.ToArray();
        }
    }
}
