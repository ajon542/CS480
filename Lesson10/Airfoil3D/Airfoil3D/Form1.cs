﻿using System;
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

        GameModel quad = new GameModel();

        float canvasWidth = 10;
        float canvasHeight = 10;
        int imageWidth = 800;
        int imageHeight = 800;

        public Form1()
        {
            InitializeComponent();

            quad.ModelCoordinates.Add(new Point3D(-0.5, -0.5, 0));
            quad.ModelCoordinates.Add(new Point3D(0.5, -0.5, 0));
            quad.ModelCoordinates.Add(new Point3D(0.5, 0.5, 0));
            quad.ModelCoordinates.Add(new Point3D(-0.5, 0.5, 0));
            quad.Transform.Position = new Vector3D(0, 0, 0);
            //quad.Transform.Scale = new Vector3D(2, 2, 2);

            Paint += Form1_Paint;
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            // Setup camera position in the world.
            Matrix3D cameraToWorld = new Matrix3D();
            cameraToWorld.Translate(new Vector3D(0, 0, -1));

            // Create the world to camera coordinates matrix.
            cameraToWorld.Invert();
            Matrix3D worldToCamera = cameraToWorld;

            // Compute the final pixel coords from the world coords.
            List<Point3D> quadWorldCoords = quad.ComputeWorldCoordinates();
            List<Point> rasterCoords = new List<Point>();

            foreach (Point3D worldCoord in quadWorldCoords)
            {
                Point3D raster = worldToCamera.ComputePixelCoordinates(worldCoord, canvasWidth, canvasHeight, imageWidth, imageHeight);
                rasterCoords.Add(new Point((int)raster.X, (int)raster.Y));
            }

            // Draw the model onscreen.
            //e.Graphics.FillPolygon(redBrush, quadRasterCoords.ToArray(), FillMode.Winding);

            for (int i = 0; i < rasterCoords.Count - 1; ++i)
            {
                e.Graphics.DrawLine(Pens.Red, rasterCoords[i], rasterCoords[i + 1]);
            }
        }
    }
}
