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

        /// <summary>
        /// Simple method of generating "n choose k".
        /// </summary>
        /// <remarks>
        /// This is used in order to generate the N degree polynomial of:
        ///     (a+b)^n
        /// In the expanded form:
        ///     (n choose 0)(a^n) + (n choose 1)(a^n-1)(b^1) + ... + (n choose k)(b^n)
        /// </remarks>
        /// <param name="n">The number of items to choose from.</param>
        /// <param name="k">The number of items to choose.</param>
        /// <returns>The number of possible way to choose the items.</returns>
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

        /// <summary>
        /// Determines the interpolation point given all the control points.
        /// </summary>
        /// <example>
        /// If the method is given 6 control points, the resulting polynomial with be of degree 5.
        /// 
        /// The following polynomial describes the x and y components, where "a=1-t" and "b=t".
        /// a^5 + 5(a^4)(b) + 10(a^3)(b^2) + 10(a^2)(b^3) + 5(a)(b^4) + b^5
        /// 
        /// </example>
        /// <param name="controls">The control points including the end points.</param>
        /// <param name="t">The percent of the interpolation.</param>
        /// <returns>The resulting point.</returns>
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
        /// <param name="controlPoints">The control points for the curve.</param>
        public BezierCurve(List<Vector2> controlPoints)
        {
            Points = new List<Vector2>();

            float t = 0;
            for (int i = 0; i <= 100; ++i)
            {
                float a = 1 - t;
                float b = t;

                Vector2 point = BezierDegreeN(controlPoints, t);

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
