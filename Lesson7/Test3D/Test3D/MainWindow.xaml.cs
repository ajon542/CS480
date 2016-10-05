using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Media3D;
using System.Diagnostics;

namespace Test3D
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {


        public MainWindow()
        {
            InitializeComponent();

            MaterialGroup material = new MaterialGroup();
            material.Children.Add(ShapeGenerator.GetSimpleMaterial(Colors.LightGreen));

            // Create sphere.
            ModelVisual3D sphere = ShapeGenerator.GenerateUnitSphere(30, 30, material);
            sphere.Transform = new TranslateTransform3D(1, 1, 1);
            mainViewport.Children.Add(sphere);

            // Create cube.
            ModelVisual3D cube = ShapeGenerator.GenerateUnitCube(material);
            cube.Transform = new TranslateTransform3D(4, .5, 1);
            mainViewport.Children.Add(cube);

            // Create ground.
            mainViewport.Children.Add(ShapeGenerator.CreatePlane(50, ShapeGenerator.GetSimpleMaterial(Colors.LightGray)));

            // Create wall.
            ModelVisual3D rightWall = ShapeGenerator.CreatePlane(50, ShapeGenerator.GetSimpleMaterial(Color.FromArgb(255, 195, 195, 195)));
            rightWall.Transform = new RotateTransform3D(new AxisAngleRotation3D(new Vector3D(1, 0, 0), 90));
            mainViewport.Children.Add(rightWall);

            // Create wall.
            ModelVisual3D leftWall = ShapeGenerator.CreatePlane(50, ShapeGenerator.GetSimpleMaterial(Color.FromArgb(255, 200, 191, 231)));
            leftWall.Transform = new RotateTransform3D(new AxisAngleRotation3D(new Vector3D(0, 0, 1), -90));
            mainViewport.Children.Add(leftWall);

            MouseDown += HitTest;
        }

        private void HitTest(object sender, MouseButtonEventArgs args)
        {
            Point mouseposition = args.GetPosition(mainViewport);
            Point3D testpoint3D = new Point3D(mouseposition.X, mouseposition.Y, 0);
            Vector3D testdirection = new Vector3D(mouseposition.X, mouseposition.Y, 10);
            PointHitTestParameters pointparams = new PointHitTestParameters(mouseposition);
            RayHitTestParameters rayparams = new RayHitTestParameters(testpoint3D, testdirection);

            // Test for a result in the Viewport3D
            VisualTreeHelper.HitTest(mainViewport, null, HitTestResult, pointparams);
        }

        private HitTestResultBehavior HitTestResult(HitTestResult rawresult)
        {
            RayHitTestResult rayResult = rawresult as RayHitTestResult;

            if (rayResult != null)
            {
                RayMeshGeometry3DHitTestResult rayMeshResult = rayResult as RayMeshGeometry3DHitTestResult;

                if (rayMeshResult != null)
                {
                    GeometryModel3D hitgeo = rayMeshResult.ModelHit as GeometryModel3D;

                    // Change to blue material 
                    hitgeo.Material = ShapeGenerator.GetSimpleMaterial(Colors.Red);
                }
            }

            return HitTestResultBehavior.Stop;
        }
    }
}
