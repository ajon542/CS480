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

        private SolidBrush silverBrush = new SolidBrush(Color.Silver);
        private SolidBrush brownBrush = new SolidBrush(Color.Brown);
        private SolidBrush greenBrush = new SolidBrush(Color.DarkGreen);
        private SolidBrush blueBrush = new SolidBrush(Color.LightBlue);
        private SolidBrush whiteBrush = new SolidBrush(Color.WhiteSmoke);

        private Bitmap background;

        /// <summary>
        /// Initialize the scene.
        /// </summary>
        public override void Initialize()
        {
            // Load the background image.
            background = new Bitmap("Assets/Background.jpg");

            // Create the propeller blades from triangles.
            Shape lBlade = new Shapes.Triangle(new Vector2(0, 0), new Vector2(150, 0), new Vector2(10, 20));
            Shape rBlade = new Shapes.Triangle(new Vector2(0, 0), new Vector2(150, 0), new Vector2(10, 20));
            Shape tBlade = new Shapes.Triangle(new Vector2(0, 0), new Vector2(150, 0), new Vector2(10, 20));

            // Create the base of the windmill.
            stand = new Shapes.Triangle(new Vector2(0, 0), new Vector2(-20, 300), new Vector2(20, 300));

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
            graphics.DrawImage(background, 0, 0);
            graphics.FillPolygon(brownBrush, stand.GetPoints(), FillMode.Winding);
            foreach(Shape blade in blades)
            {
                graphics.FillPolygon(silverBrush, blade.GetPoints(), FillMode.Winding);
            }
        }

        /// <summary>
        /// Dispose asets.
        /// </summary>
        public override void Shutdown()
        {
            background.Dispose();
        }
    }
}
