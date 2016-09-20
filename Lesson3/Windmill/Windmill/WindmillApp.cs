﻿using System;
using System.Collections.Generic;
using System.Drawing;

using Windmill.Shapes;

namespace Windmill
{
    public class WindmillApp : GameApp
    {
        private List<Shape> shapes = new List<Shape>();
        private double elapsedTime;
        private Shape stand;

        /// <summary>
        /// Initialize the scene.
        /// </summary>
        public override void Initialize()
        {
            // Create the propeller blades from triangles.
            Shape lBlade = new Triangle(new Vector2(0, 0), new Vector2(150, 0), new Vector2(10, 10));
            Shape rBlade = new Triangle(new Vector2(0, 0), new Vector2(150, 0), new Vector2(10, 10));
            Shape tBlade = new Triangle(new Vector2(0, 0), new Vector2(150, 0), new Vector2(10, 10));

            stand = new Triangle(new Vector2(0, 0), new Vector2(-20, 300), new Vector2(20, 300));

            // Rotate the blades so they are 120 degrees apart.
            rBlade.Rotate(new Vector2(0, 0), 120);
            tBlade.Rotate(new Vector2(0, 0), 240);

            // Translate the blades to their location.
            lBlade.Translate(new Vector2(400, 200));
            rBlade.Translate(new Vector2(400, 200));
            tBlade.Translate(new Vector2(400, 200));
            stand.Translate(new Vector2(400, 200));

            // Add the blades to the list of shapes for rendering.
            shapes.Add(lBlade);
            shapes.Add(rBlade);
            shapes.Add(tBlade);
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
                    shape.Rotate(new Vector2(400, 200), -1);
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
            buffer.Graphics.DrawPolygon(Pens.Blue, stand.GetPoints());
        }
    }
}
