using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Windows.Media.Media3D;

namespace Airfoil3D
{
    public partial class Form1 : Form
    {
        private SolidBrush brownBrush = new SolidBrush(Color.Brown);
        private SolidBrush redBrush = new SolidBrush(Color.Red);

        List<AirfoilWireframe> airfoils = new List<AirfoilWireframe>();

        float canvasWidth = 10;
        float canvasHeight = 10;
        int imageWidth = 800;
        int imageHeight = 800;

        public Form1()
        {
            InitializeComponent();

            float offset = 0;
            for (int i = 0; i < 10; ++i, offset -= 0.1f)
            {
                airfoils.Add(new AirfoilWireframe());
                airfoils[i].Transform.Position = new Vector3D(0, 0, offset);
            }

            Paint += Form1_Paint;
        }

        private List<Point> GetRasterPoints(AirfoilWireframe wireframe)
        {
            // Setup camera position in the world.
            // The camera will look down the negative z axis.
            Matrix3D cameraToWorld = new Matrix3D();
            cameraToWorld.Rotate(new Quaternion(new Vector3D(0, 1, 0), 180));
            cameraToWorld.Translate(new Vector3D(0, 1, 0.5));

            // Create the world to camera coordinates matrix.
            cameraToWorld.Invert();
            Matrix3D worldToCamera = cameraToWorld;

            // Compute the world coordinates for the model.
            List<Point3D> quadWorldCoords = wireframe.ComputeWorldCoordinates();

            // Convert the Point3D to Vector3D so the spline can do vector operations.
            List<Vector3D> quadCoords = new List<Vector3D>();
            foreach (Point3D point in quadWorldCoords)
            {
                quadCoords.Add((Vector3D)point);
            }
            NaturalSpline airfoilSpline = new NaturalSpline(quadCoords);

            // Convert the Vector3D back to Point3D.
            quadWorldCoords.Clear();
            foreach (Vector3D point in airfoilSpline.Points)
            {
                quadWorldCoords.Add((Point3D)point);
            }

            // Compute the final pixel coordinates.
            List<Point> rasterCoords = new List<Point>();

            foreach (Point3D worldCoord in quadWorldCoords)
            {
                Point3D raster = worldToCamera.ComputePixelCoordinates(worldCoord, canvasWidth, canvasHeight, imageWidth, imageHeight);
                rasterCoords.Add(new Point((int)raster.X, (int)raster.Y));
            }

            return rasterCoords;
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            foreach(AirfoilWireframe wireframe in airfoils)
            {
                List<Point> rasterCoords = GetRasterPoints(wireframe);

                for (int i = 0; i < rasterCoords.Count - 1; ++i)
                {
                    e.Graphics.DrawLine(Pens.Red, rasterCoords[i], rasterCoords[i + 1]);
                }
            }
        }
    }
}
