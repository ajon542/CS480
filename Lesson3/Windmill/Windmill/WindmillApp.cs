using System;
using System.Drawing;

namespace Windmill
{
    public class WindmillApp : GameApp
    {
        private Point[] points;
        private double elapsedTime;

        /// <summary>
        /// Initialize the game application.
        /// </summary>
        public override void Initialize()
        {
            points = new Point[4]
            {
                new Point(200, 200),
                new Point(200, 600),
                new Point(600, 600),
                new Point(600, 200)
            };
        }

        /// <summary>
        /// Update the game application.
        /// </summary>
        public override void Update()
        {
            elapsedTime += DeltaTime;
            if (elapsedTime > 0.01)
            {
                for (int i = 0; i < points.Length; ++i)
                {
                    points[i] = Rotate(points[i], new Point(400, 400), 1);
                }
                elapsedTime = 0;
            }
        }

        /// <summary>
        /// Render the game application.
        /// </summary>
        /// <remarks>
        /// Normally I wouldn't want the graphics buffer to pervade the system
        /// but for this small application, it should be fine.
        /// </remarks>
        /// <param name="buffer">THe graphics buffer.</param>
        public override void Render(BufferedGraphics buffer)
        {
            buffer.Graphics.DrawPolygon(Pens.Blue, points);
        }

        /// <summary>
        /// Rotate a point around an anchor.
        /// </summary>
        /// <param name="point">The point to rotate.</param>
        /// <param name="anchor">The anchor to rotate about.</param>
        /// <param name="angle">The angle to rotate in degrees.</param>
        /// <returns>The rotated point.</returns>
        private Point Rotate(Point point, Point anchor, float angle)
        {
            float x = point.X;
            float y = point.Y;

            float x1 = anchor.X;
            float y1 = anchor.Y;

            double rad = angle * Math.PI / 180;
            float x2 = (float)Math.Cos(rad) * (x - x1) + (float)Math.Sin(rad) * (y1 - y) + x1;
            float y2 = (float)Math.Sin(rad) * (x - x1) + (float)Math.Cos(rad) * (y - y1) + y1;

            Point result = new Point((int)x2, (int)y2);
            return result;
        }
    }
}
