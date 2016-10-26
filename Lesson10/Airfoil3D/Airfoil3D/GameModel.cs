using System.Collections.Generic;
using System.Windows.Media.Media3D;

namespace Airfoil3D
{
    /// <summary>
    /// Represent a 3D model.
    /// </summary>
    public class GameModel
    {
        /// <summary>
        /// The coordinates in model space.
        /// </summary>
        public List<Point3D> ModelCoordinates { get; set; }

        /// <summary>
        /// The game object position, scale and rotation.
        /// </summary>
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
            List<Point3D> worldCoordinates = new List<Point3D>();

            Matrix3D modelToWorldMatrix = new Matrix3D();
            modelToWorldMatrix.Scale(Transform.Scale);
            modelToWorldMatrix.Translate(Transform.Position);
            modelToWorldMatrix.Rotate(new Quaternion(new Vector3D(0, 0, 1), Transform.Rotation));
            foreach (Point3D modelCoord in ModelCoordinates)
            {
                Point3D worldCoord = modelCoord * modelToWorldMatrix;
                worldCoordinates.Add(worldCoord);
            }

            return worldCoordinates;
        }
    }
}
