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
        private Material material;

        public MainWindow()
        {
            InitializeComponent();

            // Create a basic material.
            material = ShapeGenerator.GetSimpleMaterial(Colors.LightGray);

            // Create a sphere.
            Transform3DGroup transformGroup = new Transform3DGroup();
            ModelVisual3D sphere = ShapeGenerator.GenerateUnitSphere(30, 30, material);
            mainViewport.Children.Add(sphere);

            // Create and assign the camera.
            GameCamera camera = new GameCamera();
            mainViewport.Camera = camera.Camera;

            // Setup the event handlers.
            MouseMove += camera.MouseMoveEventHandler;
            MouseWheel += camera.MouseWheelHandler;

            List<Point3D> section1 = new List<Point3D>
            {
                new Point3D(0, 0, 0),
                new Point3D(-3, 3, 0),
                new Point3D(-6, 4, 0),
                new Point3D(-9, 1, 0),
                new Point3D(-10, 0, 0),
                new Point3D(-9, -1, 0),
                new Point3D(-6, -4, 0),
                new Point3D(-3, -3, 0),
                new Point3D(0, 0, 0),
            };
            List<Point3D> section2 = new List<Point3D>
            {
                new Point3D(0, 0, 5),
                new Point3D(-3, 3, 5),
                new Point3D(-6, 4, 5),
                new Point3D(-9, 1, 5),
                new Point3D(-10, 0, 5),
                new Point3D(-9, -1, 5),
                new Point3D(-6, -4, 5),
                new Point3D(-3, -3, 5),
                new Point3D(0, 0, 5),
            };

            GenerateAirfoil(section1, section2);
        }

        private void GenerateAirfoil(List<Point3D> section1, List<Point3D> section2)
        {
            if (section1.Count != section2.Count)
            {
                throw new Exception("Each section must have same number of points to be able to make a mesh");
            }

            ModelVisual3D model = new ModelVisual3D();
            Model3DGroup airfoil = new Model3DGroup();

            for (int i = 1; i < section1.Count; ++i)
            {
                Transform3DGroup transformGroup = new Transform3DGroup();
                Model3DGroup quad = ShapeGenerator.CreateQuad(section1[i], section2[i], section2[i - 1], section1[i - 1], material);
                airfoil.Children.Add(quad);
            }

            model.Content = airfoil;

            mainViewport.Children.Add(model);
        }
    }
}
