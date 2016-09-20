using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;

using Windmill.Shapes;

namespace Windmill
{
    public class WindmillGameObject : GameObject
    {
        private double elapsedTime;
        private List<Shape> blades = new List<Shape>();
        private Shape stand;

        private SolidBrush silverBrush = new SolidBrush(Color.Silver);
        private SolidBrush brownBrush = new SolidBrush(Color.Brown);

        public override void Initialize()
        {
            // Create the propeller blades from triangles.
            Shape lBlade = new Shapes.Triangle(new Vector2(0, 0), new Vector2(150, 0), new Vector2(10, 20));
            Shape rBlade = new Shapes.Triangle(new Vector2(0, 0), new Vector2(150, 0), new Vector2(10, 20));
            Shape tBlade = new Shapes.Triangle(new Vector2(0, 0), new Vector2(150, 0), new Vector2(10, 20));

            // Rotate the blades so they are 120 degrees apart.
            rBlade.Rotate(new Vector2(0, 0), 120);
            tBlade.Rotate(new Vector2(0, 0), 240);

            // Add the blades to the list of shapes for rendering.
            blades.Add(lBlade);
            blades.Add(rBlade);
            blades.Add(tBlade);

            // Create the base of the windmill.
            stand = new Shapes.Triangle(new Vector2(0, 0), new Vector2(-20, 300), new Vector2(20, 300));

            // Setup initial position, scale and rotation based on the transform.
            foreach (Shape blade in blades)
            {
                blade.Rotate(new Vector2(0, 0), Transform.Rotation);
                blade.Scale(new Vector2(0, 0), Transform.Scale);
                blade.Translate(Transform.Position);
            }

            stand.Rotate(new Vector2(0, 0), Transform.Rotation);
            stand.Scale(new Vector2(0, 0), Transform.Scale);
            stand.Translate(Transform.Position);
        }

        public override void Update(double deltaTime)
        {
            elapsedTime += deltaTime;

            // Rotate the blades.
            if (elapsedTime > 10)
            {
                // The position of the windmill is the center point of the blades.
                foreach (Shape shape in blades)
                {
                    shape.Rotate(Transform.Position, -1);
                }
                elapsedTime = 0;
            }
        }

        public override void Render(Graphics graphics)
        {
            graphics.FillPolygon(brownBrush, stand.GetPoints(), FillMode.Winding);
            foreach (Shape blade in blades)
            {
                graphics.FillPolygon(silverBrush, blade.GetPoints(), FillMode.Winding);
            }
        }
    }
}
