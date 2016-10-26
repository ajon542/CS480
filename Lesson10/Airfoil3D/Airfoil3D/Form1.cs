using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Media.Media3D;

namespace Airfoil3D
{
    public partial class Form1 : Form
    {
        private SolidBrush brownBrush = new SolidBrush(Color.Brown);
        private SolidBrush redBrush = new SolidBrush(Color.Red);

        private List<AirfoilWireframe> airfoils = new List<AirfoilWireframe>();

        private const int MaxAirfoils = 10;

        private float canvasWidth = 10;
        private float canvasHeight = 10;
        private int imageWidth = 800;
        private int imageHeight = 800;

        private int currentAirfoilIndex = 0;

        public Form1()
        {
            InitializeComponent();

            float offset = 0;
            for (int i = 0; i < MaxAirfoils; ++i, offset -= 0.2f)
            {
                airfoils.Add(new AirfoilWireframe());
                airfoils[i].Transform.Position = new Vector3D(-1, 0, offset);
            }

            DrawRegion.Paint += Form1_Paint;

            // Setup the index up/down control.
            IndexUpDown.DecimalPlaces = 0;
            IndexUpDown.Increment = 1M;
            IndexUpDown.Maximum = MaxAirfoils - 1;
            IndexUpDown.Minimum = 0;
            IndexUpDown.ValueChanged += IndexUpDown_ValueChanged;

            // Setup the rotation up/down control.
            RotationUpDown.DecimalPlaces = 1;
            RotationUpDown.Increment = 1M;
            RotationUpDown.Maximum = 90;
            RotationUpDown.Minimum = -90;
            RotationUpDown.ValueChanged += RotationUpDown_ValueChanged;

            // Setup the scale up/down control.
            ScaleUpDown.DecimalPlaces = 1;
            ScaleUpDown.Increment = 0.1M;
            ScaleUpDown.Maximum = 3;
            ScaleUpDown.Minimum = 0.3M;
            ScaleUpDown.Value = 2.0M;
            ScaleUpDown.ValueChanged += ScaleUpDown_ValueChanged;

            // Setup the offset up/down control.
            OffsetUpDown.DecimalPlaces = 1;
            OffsetUpDown.Increment = 0.5M;
            OffsetUpDown.Maximum = 20;
            OffsetUpDown.Minimum = 0;
            OffsetUpDown.ValueChanged += OffsetUpDown_ValueChanged;
        }

        private void IndexUpDown_ValueChanged(object sender, EventArgs e)
        {
            // TODO: Reset to defaults properly
            double offset = (-airfoils[(int)IndexUpDown.Value].Transform.Position.Z * 10);
            OffsetUpDown.Value = (Decimal)offset;

            RotationUpDown.Value = 0;
            ScaleUpDown.Value = 2;
        }

        private void RotationUpDown_ValueChanged(object sender, EventArgs e)
        {
            airfoils[(int)IndexUpDown.Value].Transform.Rotation = (float)RotationUpDown.Value;

            DrawRegion.Invalidate();
        }

        private void ScaleUpDown_ValueChanged(object sender, EventArgs e)
        {
            airfoils[(int)IndexUpDown.Value].Transform.Scale = 
                new Vector3D((double)ScaleUpDown.Value, (double)ScaleUpDown.Value, 1);

            DrawRegion.Invalidate();
        }

        private void OffsetUpDown_ValueChanged(object sender, EventArgs e)
        {
            airfoils[(int)IndexUpDown.Value].Transform.Position =
                new Vector3D(-1, 0, (double)-OffsetUpDown.Value / 10);

            DrawRegion.Invalidate();
        }

        private List<Point> GetRasterPoints(List<Point3D> worldCoords)
        {
            // Setup camera position in the world.
            // The camera will look down the negative z axis.
            Matrix3D cameraToWorld = new Matrix3D();
            cameraToWorld.Rotate(new Quaternion(new Vector3D(0, 1, 0), 180));
            cameraToWorld.Translate(new Vector3D(0, 1, 0.5));

            // Create the world to camera coordinates matrix.
            cameraToWorld.Invert();
            Matrix3D worldToCamera = cameraToWorld;

            // Convert the Point3D to Vector3D so the spline can do vector operations.
            List<Vector3D> quadCoords = new List<Vector3D>();
            foreach (Point3D point in worldCoords)
            {
                quadCoords.Add((Vector3D)point);
            }
            NaturalSpline airfoilSpline = new NaturalSpline(quadCoords);

            // Convert the Vector3D back to Point3D.
            worldCoords.Clear();
            foreach (Vector3D point in airfoilSpline.Points)
            {
                worldCoords.Add((Point3D)point);
            }

            // Compute the final pixel coordinates.
            List<Point> rasterCoords = new List<Point>();

            foreach (Point3D worldCoord in worldCoords)
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
                List<Point> rasterCoords = GetRasterPoints(wireframe.ComputeWorldCoordinates());

                for (int i = 0; i < rasterCoords.Count - 1; ++i)
                {
                    e.Graphics.DrawLine(Pens.Red, rasterCoords[i], rasterCoords[i + 1]);
                }
            }
        }
    }
}
