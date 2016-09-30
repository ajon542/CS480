
namespace GameEngine.Core
{
    /// <summary>
    /// Defines the position, scale and rotation.
    /// </summary>
    public class Transform
    {
        public Vector2 Position { get; set; }
        public Vector2 Scale { get; set; }
        public float Rotation { get; set; }

        public Transform()
        {
            Position = new Vector2(0, 0);
            Scale = new Vector2(1, 1);
        }
    }
}
