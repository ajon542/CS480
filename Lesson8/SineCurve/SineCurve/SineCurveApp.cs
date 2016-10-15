using System;
using System.Collections.Generic;
using System.Drawing;

using GameEngine.Core;
using GameEngine.Core.Shapes;


namespace SineCurve
{
    class SineCurveApp : GameApp
    {
        private Pen pen = new Pen(Color.LightBlue, 1);
        private Brush brush = new SolidBrush(Color.DarkGray);

        private Point[] xPoints;
        private Point[] yPoints;
        private Point[] linePoints;

        private int mouseX;

        private int halfWidth;
        private int halfHeight;

        /// <summary>
        /// Setup a basic Bezier curve.
        /// </summary>
        public override void Initialize(int width, int height)
        {
            halfWidth = width / 2;
            halfHeight = height / 2;

            // Add the control points.
            List<Vector2> controlPoints = new List<Vector2>();
            for (double x = -20; x <= 20; x += 0.1)
            {
                if (x != 0)
                {
                    controlPoints.Add(new Vector2(x, -(Math.Sin(x) / x)));
                }
            }

            // Generate the line segments.
            List<Point> points = new List<Point>();
            for (int i = 0; i < controlPoints.Count - 1; ++i)
            {
                Line line = new Line(GetScreenVector(controlPoints[i]), GetScreenVector(controlPoints[i + 1]));
                points.AddRange(line.GetPoints());
            }

            linePoints = points.ToArray();

            // Create the x axis and y axis.
            Line xAxis = new Line(new Vector2(-30 * 15 + halfWidth, halfHeight), new Vector2(30 * 15 + halfWidth, halfHeight));
            Line yAxis = new Line(new Vector2(halfWidth, halfHeight - 2 * 120), new Vector2(halfWidth, halfHeight + 2 * 120));

            xPoints = xAxis.GetPoints();
            yPoints = yAxis.GetPoints();
        }

        private Vector2 GetScreenVector(Vector2 v)
        {
            Vector2 screenPoint = new Vector2(v.x * 15 + halfWidth, v.y * 150 + halfHeight);
            return screenPoint;
        }

        /// <summary>
        /// Keep track of the mouse movement to draw a circle on the graph.
        /// </summary>
        public override void MouseMove(int x, int y)
        {
            mouseX = x;
        }

        /// <summary>
        /// Render the lines.
        /// </summary>
        public override void Render(Graphics graphics)
        {
            // Draw the x axis and y axis.
            foreach (Point point in xPoints)
            {
                // FillRectangle gives you a thinner line which is better for the axes.
                graphics.FillRectangle(brush, point.X, point.Y, 1, 1);
            }

            // Draw the x axis and y axis.
            foreach (Point point in yPoints)
            {
                // FillRectangle gives you a thinner line which is better for the axes.
                graphics.FillRectangle(brush, point.X, point.Y, 1, 1);
            }

            // Draw the line segments.
            foreach (Point point in linePoints)
            {
                graphics.DrawRectangle(pen, point.X, point.Y, 1, 1);
            }

            //graphics.FillEllipse(brush, mouseX, -((float)Math.Sin((mouseX - halfWidth) / 15) / (mouseX - halfWidth / 15) * 200 + halfHeight, 10, 10);
        }
    }
}
