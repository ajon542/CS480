using System.Drawing;

namespace GameEngine.Core
{
    /// <summary>
    /// Base class for all game objects in the scene.
    /// </summary>
    public class GameObject
    {
        /// <summary>
        /// The position, scale and rotation of the game object.
        /// </summary>
        public Transform Transform { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="GameObject"/> class.
        /// </summary>
        public GameObject()
        {
            Transform = new Transform();
        }

        /// <summary>
        /// Initialize the game object.
        /// </summary>
        public virtual void Initialize()
        {
        }

        /// <summary>
        /// Update the game object.
        /// </summary>
        public virtual void Update(double deltaTime)
        {
        }

        /// <summary>
        /// Render the game object.
        /// </summary>
        public virtual void Render(Graphics graphics)
        {
        }
    }
}
