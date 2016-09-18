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
            // Create the propeller from two scaled circles.
            Vector2 position = new Vector2(400, 200);
            Shape leftBlade = new Circle(position, 50);
            Shape rightBlade = new Circle(position, 50);
            leftBlade.Scale(position, new Vector2(2, 0.3));
            rightBlade.Scale(position, new Vector2(2, 0.3));

            leftBlade.Translate(new Vector2(-100, 0));
            rightBlade.Translate(new Vector2(100, 0));

            shapes.Add(leftBlade);
            shapes.Add(rightBlade);
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
                    shape.Rotate(new Vector2(400, 200), 1);
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
