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

            // Create Bezier patch.
            Vector3D[,] controlPoints = new Vector3D[,]
            {
                { new Vector3D(0, 0, 0), new Vector3D(2, 5, 0), new Vector3D(8, 5, 0), new Vector3D(10, 0, 0) },
                { new Vector3D(0, 0, 2), new Vector3D(2, 5, 2), new Vector3D(8, 5, 2), new Vector3D(10, 0, 2) },
                { new Vector3D(0, 0, 4), new Vector3D(2, 5, 4), new Vector3D(8, 5, 4), new Vector3D(10, 0, 4) },
                { new Vector3D(0, 0, 6), new Vector3D(2, 5, 6), new Vector3D(8, 5, 6), new Vector3D(10, 0, 6) },
            };

            BezierPatch patch = new BezierPatch(controlPoints);
            mainViewport.Children.Add(patch.Model);

            // Create ground.
            mainViewport.Children.Add(ShapeGenerator.CreatePlane(50, ShapeGenerator.GetSimpleMaterial(Colors.LightGray)));

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
