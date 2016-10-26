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

        Point3D[] vWorld = new Point3D[4];

        public Form1()
        {
            InitializeComponent();

            vWorld[0] = new Point3D(-100, -100, 50);
            vWorld[1] = new Point3D(100, -100, 50);
            vWorld[2] = new Point3D(100, 100, 50);
            vWorld[3] = new Point3D(-100, 100, 50);

            Paint += Form1_Paint;
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            float canvasWidth = 10;
            float canvasHeight = 10;
            int imageWidth = 800;
            int imageHeight = 800;

            Matrix3D cameraToWorld = new Matrix3D();
            cameraToWorld.Translate(new Vector3D(0, 0, -50));

            cameraToWorld.Invert();
            Matrix3D worldToCamera = cameraToWorld;

            Point3D v0Raster = worldToCamera.ComputePixelCoordinates(vWorld[0], canvasWidth, canvasHeight, imageWidth, imageHeight);
            Point3D v1Raster = worldToCamera.ComputePixelCoordinates(vWorld[1], canvasWidth, canvasHeight, imageWidth, imageHeight);
            Point3D v2Raster = worldToCamera.ComputePixelCoordinates(vWorld[2], canvasWidth, canvasHeight, imageWidth, imageHeight);
            Point3D v3Raster = worldToCamera.ComputePixelCoordinates(vWorld[3], canvasWidth, canvasHeight, imageWidth, imageHeight);

            Point[] raster = new Point[4];
            raster[0] = new Point((int)v0Raster.X, (int)v0Raster.Y);
            raster[1] = new Point((int)v1Raster.X, (int)v1Raster.Y);
            raster[2] = new Point((int)v2Raster.X, (int)v2Raster.Y);
            raster[3] = new Point((int)v3Raster.X, (int)v3Raster.Y);

            e.Graphics.FillPolygon(redBrush, raster, FillMode.Winding);
            //e.Graphics.DrawLine(Pens.Red, raster[0], raster[1]);
            //e.Graphics.DrawLine(Pens.Green, raster[2], raster[3]);
            //e.Graphics.DrawLine(Pens.Blue, raster[4], raster[5]);
        }
    }
}
