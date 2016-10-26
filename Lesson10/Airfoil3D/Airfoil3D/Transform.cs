using System.Windows.Media.Media3D;

namespace Airfoil3D
{
    public class Transform
    {
        public Vector3D Position { get; set; }
        public Vector3D Scale { get; set; }
        public Vector3D Rotation { get; set; }

        public Transform()
        {
            Position = new Vector3D();
            Scale = new Vector3D(1, 1, 1);
            Rotation = new Vector3D();
        }
    }
}
