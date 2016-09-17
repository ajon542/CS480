using System.Drawing;

namespace Windmill
{
    /// <summary>
    /// Abstract game application class.
    /// </summary>
    public class GameApp
    {
        /// <summary>
        /// The time since the last update.
        /// </summary>
        public double DeltaTime { get; set; }

        /// <summary>
        /// Initialize the game application.
        /// </summary>
        public virtual void Initialize() { }

        /// <summary>
        /// Update the game application.
        /// </summary>
        public virtual void Update() { }

        /// <summary>
        /// Render the game application.
        /// </summary>
        /// <remarks>
        /// Normally I wouldn't want the graphics buffer to pervade the system
        /// but for this small application, it should be fine.
        /// </remarks>
        /// <param name="graphics">THe graphics buffer.</param>
        public virtual void Render(BufferedGraphics graphics) { }

        /// <summary>
        /// Shutdown the game application.
        /// </summary>
        public virtual void Shutdown() { }
    }
}
