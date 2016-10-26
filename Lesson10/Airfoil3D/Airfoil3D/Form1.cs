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

            airfoils.Add(new AirfoilWireframe());
            airfoils.Add(new AirfoilWireframe());
            airfoils.Add(new AirfoilWireframe());
            airfoils.Add(new AirfoilWireframe());
            airfoils.Add(new AirfoilWireframe());
            airfoils.Add(new AirfoilWireframe());
            airfoils.Add(new AirfoilWireframe());
            airfoils.Add(new AirfoilWireframe());
            airfoils.Add(new AirfoilWireframe());
            airfoils.Add(new AirfoilWireframe());
            airfoils[0].Transform.Position = new Vector3D(0, 0, 0.1);
            airfoils[1].Transform.Position = new Vector3D(0, 0, 0.2);
            airfoils[2].Transform.Position = new Vector3D(0, 0, 0.3);
            airfoils[3].Transform.Position = new Vector3D(0, 0, 0.4);
            airfoils[4].Transform.Position = new Vector3D(0, 0, 0.5);
            airfoils[5].Transform.Position = new Vector3D(0, 0, 0.6);
            airfoils[6].Transform.Position = new Vector3D(0, 0, 0.7);
            airfoils[7].Transform.Position = new Vector3D(0, 0, 0.8);
            airfoils[8].Transform.Position = new Vector3D(0, 0, 0.9);
            airfoils[9].Transform.Position = new Vector3D(0, 0, 1.0);

            Paint += Form1_Paint;
        }

        private List<Point> GetRasterPoints(AirfoilWireframe wireframe)
        {
            // Setup camera position in the world.
            Matrix3D cameraToWorld = new Matrix3D();
            cameraToWorld.Translate(new Vector3D(0, 1, -0.3));

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
