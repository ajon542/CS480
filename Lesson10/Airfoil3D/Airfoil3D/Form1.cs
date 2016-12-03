using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Media.Media3D;

namespace Airfoil3D
{
    public partial class Form1 : Form
    {
        private List<AirfoilWireframe> airfoils = new List<AirfoilWireframe>();

        private const int MaxAirfoils = 10;

        private float canvasWidth = 10;
        private float canvasHeight = 10;

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

            // Set the combo box data source for the color scheme.
            ScaleTypeCombo.DataSource = Enum.GetValues(typeof(ScaleType));
        }

        #region Control Value Changed Handlers

        private void IndexUpDown_ValueChanged(object sender, EventArgs e)
        {
            // Reset defaults.
            double offset = (-airfoils[(int)IndexUpDown.Value].Transform.Position.Z * 10);
            OffsetUpDown.Value = (Decimal)offset;

            double rotation = (airfoils[(int)IndexUpDown.Value].Transform.Rotation);
            RotationUpDown.Value = (Decimal)rotation;

            double scale = (airfoils[(int)IndexUpDown.Value].Transform.Scale.X);
            ScaleUpDown.Value = (Decimal)scale;
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

        private void ScaleTypeCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Set the scale type based on the combo box selection.
            ScaleType scaleType = (ScaleType)ScaleTypeCombo.SelectedItem;

            foreach (GameModel model in airfoils)
            {
                model.ScaleType = scaleType;
            }

            DrawRegion.Invalidate();
        }

        #endregion

        /// <summary>
        /// Convert the world coordinates to pixel coordinates.
        /// </summary>
        /// <remarks>
        /// TODO: There is conversion between Point3D and Vector3D because
        /// matrix multiplication doesn't work nicely with the Vector3D class.
        /// http://stackoverflow.com/questions/34097628/use-of-offsets-for-translation-in-matrix3d
        /// </remarks>
        /// <param name="worldCoords">The world coordinates.</param>
        /// <returns>A list of pixel coords.</returns>
        private List<Point> GetRasterPoints(List<Point3D> worldCoords)
        {
            // Setup camera position in the world.
            // The camera will look down the negative z axis.
            Matrix3D cameraToWorld = new Matrix3D();
            cameraToWorld.Rotate(new Quaternion(new Vector3D(0, 1, 0), 180));
            cameraToWorld.Translate(new Vector3D(0, 2, 0.5));

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
                Point3D raster = worldToCamera.ComputePixelCoordinates(
                    worldCoord,
                    canvasWidth,
                    canvasHeight,
                    DrawRegion.Width,
                    DrawRegion.Height);
                rasterCoords.Add(new Point((int)raster.X, (int)raster.Y));
            }

            return rasterCoords;
        }

        /// <summary>
        /// Draw the scene.
        /// </summary>
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.Clear(Color.SkyBlue);

            // Obtain all the points to draw to screen.
            List<List<Point>> rasterCoords = new List<List<Point>>();
            for (int i = 0; i < MaxAirfoils; ++i)
            {
                List<Point> coords = GetRasterPoints(airfoils[i].ComputeWorldCoordinates());
                rasterCoords.Add(coords);
            }

            for (int i = 0; i < MaxAirfoils; ++i)
            {
                // Choose a different color for the currently selected airfoil section.
                Pen pen = Pens.DarkGray;
                if (i == (int)IndexUpDown.Value)
                {
                    pen = Pens.Red;
                }

                // Draw the airfoil section.
                for (int j = 0; j < rasterCoords[i].Count - 1; ++j)
                {
                    e.Graphics.DrawLine(pen, rasterCoords[i][j], rasterCoords[i][j + 1]);
                }
            }

            for (int j = 0; j < rasterCoords[0].Count / 2; j += 3)
            {
                for (int i = 0; i < MaxAirfoils - 1; ++i)
                {
                    e.Graphics.DrawLine(Pens.DarkGray, rasterCoords[i][j], rasterCoords[i + 1][j]);
                }
            }
        }
    }
}
