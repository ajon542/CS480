using System;
using System.Collections.Generic;
using System.Drawing;

namespace Windmill
{
    /// <summary>
    /// Windmill application class.
    /// </summary>
    public class WindmillApp : GameApp
    {
        private List<WindmillGameObject> windmills = new List<WindmillGameObject>();

        private Bitmap background;

        /// <summary>
        /// Initialize the scene.
        /// </summary>
        public override void Initialize()
        {
            // Load the background image.
            background = new Bitmap("Assets/Background.jpg");

            // Create the game objects.
            for (int i = 0; i < 10; ++i)
            {
                windmills.Add(new WindmillGameObject());
            }

            // Set their position and scale.
            Random random = new Random();
            foreach (var gameobject in windmills)
            {
                float x = random.Next(50, 750);
                float y = random.Next(400, 500);
                gameobject.Transform.Position = new Vector2(x, y);
                gameobject.Transform.Scale = new Vector2(0.2, 0.2);

                float scale = random.Next(1, 3);
                gameobject.Transform.Scale = new Vector2(scale / 10, scale/10);
            }

            // Initialize the game objects.
            foreach (var gameobject in windmills)
            {
                gameobject.Initialize();
            }
        }

        /// <summary>
        /// Update the scene.
        /// </summary>
        public override void Update(double deltaTime)
        {
            foreach (var gameobject in windmills)
            {
                gameobject.Update(deltaTime);
            }
        }

        /// <summary>
        /// Render the scene.
        /// </summary>
        public override void Render(Graphics graphics)
        {
            graphics.DrawImage(background, 0, 0);

                        foreach (var gameobject in windmills)
            {
                gameobject.Render(graphics);
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
