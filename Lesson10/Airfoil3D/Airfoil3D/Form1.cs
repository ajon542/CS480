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
        void computePixelCoordinates(
            Vector3D pWorld,
            out Vector3D pRaster,
            Matrix3D worldToCamera,
            float canvasWidth,
            float canvasHeight,
            int imageWidth,
            int imageHeight)
        {
            Vector3D pCamera = pWorld * worldToCamera;

            Vector3D pScreen = new Vector3D(
                pCamera.X / -pCamera.Z,
                pCamera.Y / -pCamera.Z,
                0);

            Vector3D pNDC = new Vector3D(
                (pScreen.X + canvasWidth * 0.5) / canvasWidth,
                (pScreen.Y + canvasHeight * 0.5) / canvasHeight,
                0);

            pRaster = new Vector3D(
                (pNDC.X * imageWidth),
                ((1 - pNDC.Y) * imageHeight),
                0);
        }

        private SolidBrush brownBrush = new SolidBrush(Color.Brown);
        private SolidBrush redBrush = new SolidBrush(Color.Red);
        Point[] points = new Point[3];

        Vector3D[] vWorld = new Vector3D[4];

        public Form1()
        {
            InitializeComponent();

            points[0] = new Point(100, 100);
            points[1] = new Point(200, 100);
            points[2] = new Point(150, 150);

            vWorld[0] = new Vector3D(0, 0, 200);
            vWorld[1] = new Vector3D(200, 0, 200);
            vWorld[2] = new Vector3D(200, 200, 200);
            vWorld[3] = new Vector3D(0, 200, 200);

            Paint += Form1_Paint;
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.FillPolygon(brownBrush, points, FillMode.Winding);

            float canvasWidth = 5;
            float canvasHeight = 5;
            int imageWidth = 800;
            int imageHeight = 600;

            Matrix3D cameraToWorld = new Matrix3D(
                 0.871214, 0, -0.490904, 0,
                -0.192902, 0.919559, -0.342346, 0,
                 0.451415, 0.392953, 0.801132, 0,
                14.777467, 29.361945, 27.993464, 1);

            cameraToWorld.Invert();
            Matrix3D worldToCamera = cameraToWorld;

            Vector3D v0Raster, v1Raster, v2Raster, v3Raster, v4Raster, v5Raster;
            computePixelCoordinates(vWorld[0], out v0Raster, worldToCamera, canvasWidth, canvasHeight, imageWidth, imageHeight);
            computePixelCoordinates(vWorld[1], out v1Raster, worldToCamera, canvasWidth, canvasHeight, imageWidth, imageHeight);
            computePixelCoordinates(vWorld[2], out v2Raster, worldToCamera, canvasWidth, canvasHeight, imageWidth, imageHeight);
            computePixelCoordinates(vWorld[3], out v3Raster, worldToCamera, canvasWidth, canvasHeight, imageWidth, imageHeight);

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
