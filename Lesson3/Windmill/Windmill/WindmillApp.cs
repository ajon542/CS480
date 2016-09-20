using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;

using Windmill.Shapes;

namespace Windmill
{
    /// <summary>
    /// Windmill application class.
    /// </summary>
    public class WindmillApp : GameApp
    {
        private List<Shape> blades = new List<Shape>();
        private double elapsedTime;
        private Shape stand;
        private Shape grass;
        private Shape sky;
        private List<Shape> cloud;

        private SolidBrush silverBrush = new SolidBrush(Color.Silver);
        private SolidBrush brownBrush = new SolidBrush(Color.Brown);
        private SolidBrush greenBrush = new SolidBrush(Color.DarkGreen);
        private SolidBrush blueBrush = new SolidBrush(Color.LightBlue);
        private SolidBrush whiteBrush = new SolidBrush(Color.WhiteSmoke);

        /// <summary>
        /// Initialize the scene.
        /// </summary>
        public override void Initialize()
        {
            // Create the propeller blades from triangles.
            Shape lBlade = new Shapes.Triangle(new Vector2(0, 0), new Vector2(150, 0), new Vector2(10, 20));
            Shape rBlade = new Shapes.Triangle(new Vector2(0, 0), new Vector2(150, 0), new Vector2(10, 20));
            Shape tBlade = new Shapes.Triangle(new Vector2(0, 0), new Vector2(150, 0), new Vector2(10, 20));

            // Create the base of the windmill.
            stand = new Shapes.Triangle(new Vector2(0, 0), new Vector2(-20, 300), new Vector2(20, 300));

            // Create the grass.
            grass = new Shapes.Rectangle(0, 500, 800, 300);

            // Create the sky.
            sky = new Shapes.Rectangle(0, 0, 800, 500);

            // Create the clouds. (Probably a little inefficient to use circles).
            cloud = new List<Shape>();
            cloud.Add(new Circle(new Vector2(0, 0), 50));
            cloud.Add(new Circle(new Vector2(60, 10), 35));
            cloud.Add(new Circle(new Vector2(100, 10), 25));
            cloud.Add(new Circle(new Vector2(0, 0), 50));
            cloud.Add(new Circle(new Vector2(-60, 10), 40));
            cloud.Add(new Circle(new Vector2(-100, 15), 20));
            foreach (Shape shape in cloud)
            {
                shape.Translate(new Vector2(100, 100));
            }

            // Rotate the blades so they are 120 degrees apart.
            rBlade.Rotate(new Vector2(0, 0), 120);
            tBlade.Rotate(new Vector2(0, 0), 240);

            // Translate the blades to their location.
            lBlade.Translate(new Vector2(400, 200));
            rBlade.Translate(new Vector2(400, 200));
            tBlade.Translate(new Vector2(400, 200));
            stand.Translate(new Vector2(400, 200));

            // Add the blades to the list of shapes for rendering.
            blades.Add(lBlade);
            blades.Add(rBlade);
            blades.Add(tBlade);
        }

        /// <summary>
        /// Update the scene.
        /// </summary>
        public override void Update()
        {
            elapsedTime += DeltaTime;

            // Rotate the blades.
            if (elapsedTime > 10)
            {
                foreach (Shape shape in cloud)
                {
                    shape.Translate(new Vector2(0.2, 0));
                }

                foreach (Shape shape in blades)
                {
                    shape.Rotate(new Vector2(400, 200), -1);
                }
                elapsedTime = 0;
            }
        }

        /// <summary>
        /// Render the scene.
        /// </summary>
        public override void Render(Graphics graphics)
        {
            // Draw the grass, sky, windmill stand and blades.
            graphics.FillPolygon(blueBrush, sky.GetPoints(), FillMode.Winding);
            graphics.FillPolygon(greenBrush, grass.GetPoints(), FillMode.Winding);
            graphics.FillPolygon(brownBrush, stand.GetPoints(), FillMode.Winding);

            foreach (Shape shape in cloud)
            {
                graphics.FillPolygon(whiteBrush, shape.GetPoints(), FillMode.Winding);
            }

            foreach(Shape blade in blades)
            {
                graphics.FillPolygon(silverBrush, blade.GetPoints(), FillMode.Winding);
            }
        }
    }
}
