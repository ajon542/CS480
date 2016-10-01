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
        /// <param name="p0">The start point.</param>
        /// <param name="p1">The first control point.</param>
        /// <param name="p2">The second control point.</param>
        /// <param name="p3">The end point.</param>
        public BezierCurve(Vector2 p0, Vector2 p1, Vector2 p2, Vector2 p3)
        {
            Points = new List<Vector2>();

            float t = 0;
            for (int i = 0; i <= 100; ++i)
            {
                double x =
                    (1 - t) * (1 - t) * (1 - t) * p0.x +
                    (3 * (1 - t) * t * t) * p1.x +
                    (3 * (1 - t) * (1 - t) * t) * p2.x +
                    (t * t * t) * p3.x;

                double y =
                    (1 - t) * (1 - t) * (1 - t) * p0.y +
                    (3 * (1 - t) * t * t) * p1.y +
                    (3 * (1 - t) * (1 - t) * t) * p2.y +
                    (t * t * t) * p3.y;

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
