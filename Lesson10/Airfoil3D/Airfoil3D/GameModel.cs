using System.Collections.Generic;
using System.Windows.Media.Media3D;

namespace Airfoil3D
{
    /// <summary>
    /// Represent a 3D model.
    /// </summary>
    public class GameModel
    {
        public List<Point3D> ModelCoordinates { get; set; }
        public Transform Transform { get; set; }

        public GameModel()
        {
            Transform = new Transform();
            ModelCoordinates = new List<Point3D>();
        }

        /// <summary>
        /// Obtain the points of the model in world coordinates.
        /// </summary>
        /// <returns>The points of the model in world coordinates.</returns>
        public List<Point3D> ComputeWorldCoordinates()
        {
            return new List<Point3D>();
        }
    }
}
