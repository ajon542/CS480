using System;
using System.Collections.Generic;
using System.Drawing;

using Windmill.Shapes;

namespace Windmill
{
    public class WindmillApp : GameApp
    {
        private Random random = new Random();
        private List<Shape> shapes = new List<Shape>();
        private double elapsedTime;

        /// <summary>
        /// Initialize the game application.
        /// </summary>
        public override void Initialize()
        {
            for (int i = 0; i < 50; ++i)
            {
                Vector2 center = new Vector2(random.Next(100, 700), random.Next(100, 700));
                shapes.Add(new Shapes.Circle(center, random.Next(10, 100)));
            }
        }

        /// <summary>
        /// Update the game application.
        /// </summary>
        public override void Update()
        {
            elapsedTime += DeltaTime;

            if (elapsedTime > 0.01)
            {
                //rectangle.Rotate(new Vector2(400, 400), 1);
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
            foreach(Shape shape in shapes)
            {
                buffer.Graphics.DrawPolygon(Pens.Blue, shape.GetPoints());
            }
        }
    }
}
