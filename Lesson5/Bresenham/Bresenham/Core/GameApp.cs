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
        public virtual void Initialize() { }

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
    }
}
