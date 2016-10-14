using System.Drawing;

namespace GameEngine.Core
{
    /// <summary>
    /// Abstract game application class.
    /// </summary>
    public class GameApp
    {
        /// <summary>
        /// Initialize the game application.
        /// </summary>
        public virtual void Initialize(int width, int height) { }

        /// <summary>
        /// Update the game application.
        /// </summary>
        public virtual void Update(double deltaTime) { }

        /// <summary>
        /// Render the game application.
        /// </summary>
        /// <param name="graphics">THe graphics buffer.</param>
        public virtual void Render(Graphics graphics) { }

        /// <summary>
        /// Shutdown the game application.
        /// </summary>
        public virtual void Shutdown() { }

        /// <summary>
        /// Handle the mouse down.
        /// </summary>
        public virtual void MouseDown(int x, int y) { }

        /// <summary>
        /// Handle the mouse up.
        /// </summary>
        public virtual void MouseUp(int x, int y) { }

        /// <summary>
        /// Handle button click for the given button id.
        /// </summary>
        public virtual void ButtonClick(string buttonId) { }
    }
}
