using System.Drawing;

namespace Windmill
{
    /// <summary>
    /// Windmill application class.
    /// </summary>
    public class WindmillApp : GameApp
    {
        private WindmillGameObject windmill1 = new WindmillGameObject();
        private WindmillGameObject windmill2 = new WindmillGameObject();

        private Bitmap background;

        /// <summary>
        /// Initialize the scene.
        /// </summary>
        public override void Initialize()
        {
            // Load the background image.
            background = new Bitmap("Assets/Background.jpg");

            // Initialize the windmill game object.
            windmill1.Transform.Position = new Vector2(400, 200);
            windmill1.Initialize();

            windmill2.Transform.Position = new Vector2(500, 300);
            windmill2.Transform.Scale = new Vector2(0.5, 0.5);
            windmill2.Initialize();
        }

        /// <summary>
        /// Update the scene.
        /// </summary>
        public override void Update(double deltaTime)
        {
            windmill1.Update(deltaTime);
            windmill2.Update(deltaTime);
        }

        /// <summary>
        /// Render the scene.
        /// </summary>
        public override void Render(Graphics graphics)
        {
            graphics.DrawImage(background, 0, 0);

            windmill1.Render(graphics);
            windmill2.Render(graphics);
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
