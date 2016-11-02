using System.Collections.Generic;
using System.Windows.Media.Media3D;

namespace AirfoilSurface
{
    /// <summary>
    /// Abstract base class for a drawable object in the scene.
    /// </summary>
    public abstract class GameObject
    {
        /// <summary>
        /// The points representing the curve.
        /// </summary>
        public List<Vector3D> Points { get; set; }

        /// <summary>
        /// Convert the list of vectors to points on the screen.
        /// </summary>
        /// <returns>Array of screen points.</returns>
        public Point3D[] GetPoints()
        {
            List<Point3D> points = new List<Point3D>();
            foreach (Vector3D v in Points)
            {
                points.Add((Point3D)v);
            }
            return points.ToArray();
        }
    }
}
