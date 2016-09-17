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
        /// Initialize the scene.
        /// </summary>
        public override void Initialize()
        {
            for (int i = 0; i < 50; ++i)
            {
                Shape rectangle = new Shapes.Rectangle(
                    random.Next(200, 600),
                    random.Next(200, 600),
                    random.Next(10, 100),
                    random.Next(10, 100));
                shapes.Add(rectangle);
            }
        }

        /// <summary>
        /// Update the scene.
        /// </summary>
        public override void Update()
        {
            elapsedTime += DeltaTime;

            if (elapsedTime > 0.01)
            {
                foreach (Shape shape in shapes)
                {
                    shape.Rotate(new Vector2(400, 400), 1);
                }
                elapsedTime = 0;
            }
        }

        /// <summary>
        /// Render the scene.
        /// </summary>
        public override void Render(BufferedGraphics buffer)
        {
            foreach(Shape shape in shapes)
            {
                buffer.Graphics.DrawPolygon(Pens.Blue, shape.GetPoints());
            }
        }
    }
}
