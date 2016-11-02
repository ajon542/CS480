using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Media3D;

namespace AirfoilSurface
{
    // Shape generator class from the test bed at: http://cgpp.net/csharp.xml
    public static class ShapeGenerator
    {
        /// <summary>
        /// Creates a simple solid material from the given color
        /// </summary>
        public static Material GetSimpleMaterial(Color c)
        {
            return new DiffuseMaterial(new SolidColorBrush(c));
        }

        /// <summary>
        /// Helper method that creates and textures a quad from the given points.
        /// </summary>
        public static Model3DGroup CreateQuad(
            Point3D topLeft,
            Point3D topRight,
            Point3D botRight,
            Point3D botLeft,
            Material material)
        {
            MeshGeometry3D mesh = new MeshGeometry3D();

            // Add the vertices.
            mesh.Positions.Add(topLeft);
            mesh.Positions.Add(topRight);
            mesh.Positions.Add(botRight);
            mesh.Positions.Add(botLeft);

            // Add the triangle indices.
            mesh.TriangleIndices.Add(0);
            mesh.TriangleIndices.Add(1);
            mesh.TriangleIndices.Add(2);

            mesh.TriangleIndices.Add(0);
            mesh.TriangleIndices.Add(2);
            mesh.TriangleIndices.Add(3);

            // Add the texture coordinates.
            mesh.TextureCoordinates.Add(new Point(0, 1));
            mesh.TextureCoordinates.Add(new Point(1, 1));
            mesh.TextureCoordinates.Add(new Point(1, 0));
            mesh.TextureCoordinates.Add(new Point(0, 0));

            // Calculate and add the normals.
            Vector3D normal = CalculateNormal(topLeft, topRight, botRight);
            mesh.Normals.Add(normal);
            mesh.Normals.Add(normal);
            mesh.Normals.Add(normal);
            mesh.Normals.Add(normal);
            mesh.Normals.Add(normal);
            mesh.Normals.Add(normal);

            // Create the model.
            GeometryModel3D model = new GeometryModel3D(mesh, material);
            Model3DGroup quad = new Model3DGroup();
            quad.Children.Add(model);
            return quad;
        }

        /// <summary>
        /// Finds the normal for the triangle defined by the three points.
        /// </summary>
        private static Vector3D CalculateNormal(Point3D p0, Point3D p1, Point3D p2)
        {
            var v0 = new Vector3D(p1.X - p0.X, p1.Y - p0.Y, p1.Z - p0.Z);
            var v1 = new Vector3D(p2.X - p1.X, p2.Y - p1.Y, p2.Z - p1.Z);
            return Vector3D.CrossProduct(v0, v1);
        }
    }
}
