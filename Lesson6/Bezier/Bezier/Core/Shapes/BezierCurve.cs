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
        /// Initializes a new instance of the <see cref="BezierCurve"/> class.
        /// </summary>
        /// <param name="a">The start point.</param>
        /// <param name="b">The end point.</param>
        /// <param name="c1">The first control point.</param>
        /// <param name="c2">The second control point.</param>
        public BezierCurve(Vector2 a, Vector2 b, Vector2 c1, Vector2 c2)
        {
            Points = new List<Vector2>();

            float t = 0;
            for (int i = 0; i < 100; ++i)
            {
                double x =
                    (1 - t) * (1 - t) * (1 - t) * a.x +
                    (3 * (1 - t) * t * t) * c1.x +
                    (3 * (1 - t) * (1 - t) * t) * c2.x +
                    (t * t * t) * b.x;

                double y =
                    (1 - t) * (1 - t) * (1 - t) * a.y +
                    (3 * (1 - t) * t * t) * c1.y +
                    (3 * (1 - t) * (1 - t) * t) * c2.y +
                    (t * t * t) * b.y;

                Points.Add(new Vector2(x, y));

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
