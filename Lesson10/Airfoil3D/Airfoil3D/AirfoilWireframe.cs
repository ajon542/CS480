using System.Collections.Generic;
using System.Windows.Media.Media3D;

namespace Airfoil3D
{
    /// <summary>
    /// Defines the control points for the NACA 2412 airfoil.
    /// </summary>
    public class AirfoilWireframe : GameModel
    {
        public AirfoilWireframe()
        {
            ModelCoordinates.Add(new Point3D(1, 0, 0));
            ModelCoordinates.Add(new Point3D(0.2985, 0.07875, 0));
            ModelCoordinates.Add(new Point3D(0, 0, 0));
            ModelCoordinates.Add(new Point3D(0.3015, -0.0412, 0));
            ModelCoordinates.Add(new Point3D(1, 0, 0));

            Transform.Scale = new Vector3D(2, 2, 1);
        }
    }
}
