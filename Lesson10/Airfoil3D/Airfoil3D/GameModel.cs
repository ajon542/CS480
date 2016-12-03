using System.Collections.Generic;
using System.Windows.Media.Media3D;

namespace Airfoil3D
{
    public enum ScaleType
    {
        Leading,
        Trailing,
        Center
    }

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

        /// <summary>
        /// Specify the pivot point for the scale.
        /// Depending on the scale type, we translate the model coords toward the origin,
        /// then scale and translate back.
        /// </summary>
        public ScaleType ScaleType { get; set; }

        public GameModel()
        {
            ScaleType = ScaleType.Leading;
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

            if (ScaleType == ScaleType.Leading)
            {
                modelToWorldMatrix.Scale(Transform.Scale);
            }
            else if (ScaleType == ScaleType.Trailing)
            {
                modelToWorldMatrix.Translate(new Vector3D(-1, 0, 0));
                modelToWorldMatrix.Scale(Transform.Scale);
                modelToWorldMatrix.Translate(new Vector3D(2, 0, 0));
            }
            else
            {
                modelToWorldMatrix.Translate(new Vector3D(-0.5f, 0, 0));
                modelToWorldMatrix.Scale(Transform.Scale);
                modelToWorldMatrix.Translate(new Vector3D(1, 0, 0));
            }

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
