using System.Collections.Generic;
using System.Windows.Media.Media3D;

namespace Airfoil3D
{
    class AirfoilWireframe : GameModel
    {
        public AirfoilWireframe()
        {
            ModelCoordinates.Add(new Point3D(1, 0, 0));
            ModelCoordinates.Add(new Point3D(0.2985, 0.07875, 0));
            ModelCoordinates.Add(new Point3D(0, 0, 0));
            ModelCoordinates.Add(new Point3D(0.3015, -0.0412, 0));
            ModelCoordinates.Add(new Point3D(1, 0, 0));
        }
    }
}
