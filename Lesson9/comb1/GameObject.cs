using System.Collections.Generic;
using System.Drawing;
using System.Windows.Media.Media3D;

namespace comb1
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
        public Point[] GetPoints()
        {
            List<Point> points = new List<Point>();
            foreach (Vector3D v in Points)
            {
                points.Add(new Point((int)v.X, (int)v.Y));
            }
            return points.ToArray();
        }

        /// <summary>
        /// Draw the object in the scene.
        /// </summary>
        /// <param name="graphics">The drawing surface.</param>
        public abstract void Render(Graphics graphics);
    }
}
