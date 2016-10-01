using System;
using System.Collections.Generic;
using System.Drawing;

namespace GameEngine.Core.Shapes
{
    public class Shape
    {
        public List<Vector2> Points { get; set; }

        public Shape()
        {
            Points = new List<Vector2>();
        }

        public virtual void Rotate(Vector2 anchor, float angle)
        {
            for (int i = 0; i < Points.Count; ++i)
            {
                Points[i] = Shape.Rotate(Points[i], anchor, angle);
            }
        }

        public virtual void Scale(Vector2 anchor, Vector2 scale)
        {
            for (int i = 0; i < Points.Count; ++i)
            {
                Points[i] = Shape.Scale(Points[i], anchor, scale);
            }
        }

        public virtual void Translate(Vector2 translate)
        {
            foreach (Vector2 point in Points)
            {
                point.x += translate.x;
                point.y += translate.y;
            }
        }

        public virtual Point[] GetPoints()
        {
            List<Point> points = new List<Point>();
            for (int i = 0; i < Points.Count; ++i)
            {
                points.Add(new Point((int)Points[i].x, (int)Points[i].y));
            }
            return points.ToArray();
        }

        /// <summary>
        /// Rotate a point around an anchor.
        /// </summary>
        /// <param name="point">The point to rotate.</param>
        /// <param name="anchor">The anchor to rotate about.</param>
        /// <param name="angle">The angle to rotate in degrees.</param>
        /// <returns>The rotated point.</returns>
        public static Vector2 Rotate(Vector2 point, Vector2 anchor, float angle)
        {
            double x = point.x;
            double y = point.y;

            double x1 = anchor.x;
            double y1 = anchor.y;

            double rad = angle * Math.PI / 180;
            double x2 = Math.Cos(rad) * (x - x1) + Math.Sin(rad) * (y1 - y) + x1;
            double y2 = Math.Sin(rad) * (x - x1) + Math.Cos(rad) * (y - y1) + y1;

            Vector2 result = new Vector2(x2, y2);
            return result;
        }

        /// <summary>
        /// Scale a point about an anchor.
        /// </summary>
        /// <param name="point">The point to scale.</param>
        /// <param name="anchor">The anchor to scale about.</param>
        /// <param name="scale">The scale factor.</param>
        /// <returns>A vector representing the position of the scale point.</returns>
        public static Vector2 Scale(Vector2 point, Vector2 anchor, Vector2 scale)
        {
            double x = point.x;
            double y = point.y;

            double x1 = anchor.x;
            double y1 = anchor.y;

            double x2 = scale.x * (x - x1) + x1;
            double y2 = scale.y * (y - y1) + y1;

            Vector2 result = new Vector2(x2, y2);
            return result;
        }
    }
}
