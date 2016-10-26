using System.Windows.Media.Media3D;

namespace Airfoil3D
{
    /// <summary>
    /// Matrix3D extension class.
    /// </summary>
    public static class Matrix3DExt
    {
        /// <summary>
        /// Convert world coordinates to pixel coordinates.
        /// </summary>
        /// <param name="worldToCamera">The world to camera matrix.</param>
        /// <param name="pWorld">The world coordinate.</param>
        /// <param name="canvasWidth">The width of the canvas.</param>
        /// <param name="canvasHeight">The height of the canvas.</param>
        /// <param name="imageWidth">The width of the final image.</param>
        /// <param name="imageHeight">The height of the final image.</param>
        /// <returns>The final pixel coordinate of the point.</returns>
        public static Point3D ComputePixelCoordinates(
            this Matrix3D worldToCamera,
            Point3D pWorld,
            float canvasWidth,
            float canvasHeight,
            int imageWidth,
            int imageHeight)
        {
            Point3D pCamera = pWorld * worldToCamera;

            Point3D pScreen = new Point3D(
                pCamera.X / -pCamera.Z,
                pCamera.Y / -pCamera.Z,
                0);

            Point3D pNDC = new Point3D(
                (pScreen.X + canvasWidth * 0.5) / canvasWidth,
                (pScreen.Y + canvasHeight * 0.5) / canvasHeight,
                0);

            Point3D pRaster = new Point3D(
                (pNDC.X * imageWidth),
                (pNDC.Y * imageHeight),
                0);

            return pRaster;
        }
    }
}
