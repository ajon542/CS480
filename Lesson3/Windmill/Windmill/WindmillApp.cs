using System;
using System.Drawing;

namespace Windmill
{
    public class Vector2
    {
        public double x;
        public double y;

        public Vector2(double x, double y)
        {
            this.x = x;
            this.y = y;
        }
    }
    
    public class WindmillApp : GameApp
    {
        private Vector2[] vectors;
        private double elapsedTime;

        /// <summary>
        /// Initialize the game application.
        /// </summary>
        public override void Initialize()
        {
            vectors = new Vector2[4]
            {
                new Vector2(200, 200),
                new Vector2(200, 600),
                new Vector2(600, 600),
                new Vector2(600, 200)
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
                for (int i = 0; i < vectors.Length; ++i)
                {
                    vectors[i] = Rotate(vectors[i], new Vector2(400, 400), 1);
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
            Point[] points = new Point[4];
            for (int i = 0; i < vectors.Length; ++i)
            {
                points[i] = new Point((int)vectors[i].x, (int)vectors[i].y);
            }

            buffer.Graphics.DrawPolygon(Pens.Blue, points);
        }

        /// <summary>
        /// Rotate a point around an anchor.
        /// </summary>
        /// <param name="point">The point to rotate.</param>
        /// <param name="anchor">The anchor to rotate about.</param>
        /// <param name="angle">The angle to rotate in degrees.</param>
        /// <returns>The rotated point.</returns>
        private Vector2 Rotate(Vector2 point, Vector2 anchor, float angle)
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
    }
}
