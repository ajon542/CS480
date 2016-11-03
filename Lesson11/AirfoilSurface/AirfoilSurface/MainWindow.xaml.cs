using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Media3D;

namespace AirfoilSurface
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private double t, p, m;
        private float[] xu, xl, yu, yl, yc;

        private Material material;

        public MainWindow()
        {
            InitializeComponent();

            // Create a basic material.
            material = ShapeGenerator.GetSimpleMaterial(Colors.LightGray);

            // Create and assign the camera.
            GameCamera camera = new GameCamera();
            mainViewport.Camera = camera.Camera;

            // Setup the event handlers.
            MouseMove += camera.MouseMoveEventHandler;
            MouseWheel += camera.MouseWheelHandler;

            Generate();
        }

        private void Generate()
        {
            GenerateAirfoilPoints();

            // Specify sample points for the natural spline.
            int u0 = 100;
            int u1 = 70;
            int u2 = 45;
            int u3 = 20;
            int u4 = 6;
            int u5 = 2;
            int u6 = 0;
            int l1 = 2;
            int l2 = 6;
            int l3 = 25;
            int l4 = 60;
            int l5 = 80;
            int l6 = 100;

            // Index the points from the original.
            List<Vector3D> section1 = new List<Vector3D>
            {
                new Vector3D(xu[u0], yu[u0], -3),
                new Vector3D(xu[u1], yu[u1], -3),
                new Vector3D(xu[u2], yu[u2], -3),
                new Vector3D(xu[u3], yu[u3], -3),
                new Vector3D(xu[u4], yu[u4], -3),
                new Vector3D(xu[u5], yu[u5], -3),
                new Vector3D(xu[u6], yu[u6], -3),
                new Vector3D(xl[l1], yl[l1], -3),
                new Vector3D(xl[l2], yl[l2], -3),
                new Vector3D(xl[l3], yl[l3], -3),
                new Vector3D(xl[l4], yl[l4], -3),
                new Vector3D(xl[l5], yl[l5], -3),
                new Vector3D(xl[l6], yl[l6], -3),
            };

            List<Vector3D> section2 = new List<Vector3D>
            {
                new Vector3D(xu[u0], yu[u0], 3),
                new Vector3D(xu[u1], yu[u1], 3),
                new Vector3D(xu[u2], yu[u2], 3),
                new Vector3D(xu[u3], yu[u3], 3),
                new Vector3D(xu[u4], yu[u4], 3),
                new Vector3D(xu[u5], yu[u5], 3),
                new Vector3D(xu[u6], yu[u6], 3),
                new Vector3D(xl[l1], yl[l1], 3),
                new Vector3D(xl[l2], yl[l2], 3),
                new Vector3D(xl[l3], yl[l3], 3),
                new Vector3D(xl[l4], yl[l4], 3),
                new Vector3D(xl[l5], yl[l5], 3),
                new Vector3D(xl[l6], yl[l6], 3),
            };

            // Create the airfoil sections.
            GameObject airfoilSpline1 = new NaturalSpline(section1);
            GameObject airfoilSpline2 = new NaturalSpline(section2);
            GenerateAirfoil(airfoilSpline1.GetPoints(), airfoilSpline2.GetPoints());
        }

        /// <summary>
        /// Generate the original NACA airfoil points.
        /// </summary>
        private void GenerateAirfoilPoints()
        {
            float x, c, yt, temp, ts, tt, tf, r, dycdx, theta;

            int naca, thick, camb, cambd, front;
            float mask;
            p = 0.0;
            t = 0.0;
            m = 0.0;
            naca = 6412;

            mask = (float)naca;
            mask = (float)(mask / 100.0);
            front = naca / 100;
            mask = (float)((mask - front) * 100.0 + 0.001);
            thick = (int)mask;
            mask = (float)front;
            camb = front / 10;
            mask = (float)(mask / 10.0);
            mask = (float)((mask - camb) * 10.0);
            cambd = (int)(mask + 0.01);
            t = (float)(thick / 100.0);
            t = (float)(thick / 100.0);
            p = (double)(cambd) / 10;
            m = (double)(camb) / 100.0;

            xl = new float[101];
            yl = new float[101];
            xu = new float[101];
            yu = new float[101];
            yc = new float[101];
            c = (float)1.0;

            for (int i = 0; i <= 100; i++)
            {
                x = i;
                x = x / (float)100.0;
                temp = x / c;
                ts = temp * temp;
                tt = ts * temp;
                tf = tt * temp;
                yt = (float)(5.0 * t * c * (0.2969 * Math.Sqrt(temp) - 0.1260 * (temp) - 0.3516 * ts + 0.2843 * tt - 0.1015 * tf));
                if (p < 0.00001)
                {
                    yc[i] = (float)0.0;
                    dycdx = (float)0.0;
                    theta = (float)0.0;
                }
                else
                {
                    if (x <= p * c)
                    {
                        yc[i] = (float)(m * (x / (p * p)) * (2.0 * p - x / c));
                        dycdx = (float)((2.0 * m) / (p * p) * (p - x / c));
                    }
                    else
                    {
                        yc[i] = (float)(m * (c - x) / ((1 - p) * (1 - p)) * (1.0 + x / c - 2.0 * p));
                        dycdx = (float)((2.0 * m) / ((1 - p) * (1 - p)) * (p - x / c));
                    }
                    theta = (float)Math.Atan(dycdx);
                }
                xl[i] = (float)(x + yt * Math.Sin(theta));
                yl[i] = (float)(yc[i] - yt * Math.Cos(theta));
                xu[i] = (float)(x - yt * Math.Sin(theta));
                yu[i] = (float)(yc[i] + yt * Math.Cos(theta));
            }

            r = (float)(1.1019 * t * t);
        }

        private void GenerateAirfoil(Point3D[] section1, Point3D[] section2)
        {
            if (section1.Length != section2.Length)
            {
                throw new Exception("Each section must have same number of points to be able to make a mesh");
            }

            ModelVisual3D model = new ModelVisual3D();
            Model3DGroup airfoil = new Model3DGroup();

            for (int i = 1; i < section1.Length; ++i)
            {
                Transform3DGroup transformGroup = new Transform3DGroup();
                Model3DGroup quad = ShapeGenerator.CreateQuad(section1[i], section2[i], section2[i - 1], section1[i - 1], material);
                airfoil.Children.Add(quad);
            }

            model.Content = airfoil;

            mainViewport.Children.Add(model);
        }

        private void GenerateButton_Click(object sender, RoutedEventArgs e)
        {
            // TODO: Need to figure out how to clean up..
            Generate();
        }
    }
}
