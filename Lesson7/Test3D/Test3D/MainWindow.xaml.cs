using System;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Media3D;

namespace Test3D
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private int mouseWheelIndex = 0;

        private double vAngle = 60;
        private double hAngle = 60;
        private double prevX = 0, prevY = 0;
        double distance = 30;

        public MainWindow()
        {
            InitializeComponent();

            MaterialGroup material = new MaterialGroup();
            material.Children.Add(ShapeGenerator.GetSimpleMaterial(Colors.LightGreen));

            // Create Bezier patch.
            Vector3D[,] controlPoints = new Vector3D[,]
            {
                { new Vector3D(0, -10, 0), new Vector3D(2, 0, 0), new Vector3D(8, 0, 0), new Vector3D(10, -10, 0) },
                { new Vector3D(-20, -10, -10), new Vector3D(2, 5, 2), new Vector3D(8, 5, 2), new Vector3D(20, -10, -10) },
                { new Vector3D(-20, -10, 20), new Vector3D(2, 7, 4), new Vector3D(8, 6, 4), new Vector3D(20, -10, 20) },
                { new Vector3D(0, -10, 6), new Vector3D(2, 0, 6), new Vector3D(8, 0, 6), new Vector3D(10, -10, 6) },
            };

            // Add the control points to the model.
            for (int i = 0; i < 4; ++i)
            {
                for (int j = 0; j < 4; ++j)
                {
                    Transform3DGroup transformGroup = new Transform3DGroup();
                    ModelVisual3D sphere = ShapeGenerator.GenerateUnitSphere(30, 30, material);
                    transformGroup.Children.Add(new ScaleTransform3D(0.2, 0.2, 0.2));
                    transformGroup.Children.Add(new TranslateTransform3D(controlPoints[i, j].X, controlPoints[i, j].Y, controlPoints[i, j].Z));
                    sphere.Transform = transformGroup;
                    mainViewport.Children.Add(sphere);
                }
            }

            BezierPatch patch = new BezierPatch(controlPoints);
            mainViewport.Children.Add(patch.Model);

            // Create ground.
            ModelVisual3D ground = ShapeGenerator.CreatePlane(50, ShapeGenerator.GetSimpleMaterial(Colors.LightGray));
            ground.Transform = new TranslateTransform3D(0, -50, 0);
            mainViewport.Children.Add(ground);

            // Defines the camera used to view the 3D object. In order to view the 3D object,
            // the camera must be positioned and pointed such that the object is within view 
            // of the camera.
            PerspectiveCamera myPCamera = new PerspectiveCamera();

            // Define camera's horizontal field of view in degrees.
            myPCamera.FieldOfView = 60;

            // Asign the camera to the viewport
            mainViewport.Camera = myPCamera;

            MouseDown += MouseDownHandler;
            MouseMove += MouseMoveEventHandler;

            MouseWheel += MouseWheelHandler;

            UpdateCameraVectors();
        }

        private void UpdateCameraVectors()
        {
            PerspectiveCamera pCam = (mainViewport.Camera as PerspectiveCamera);

            double vA = vAngle * Math.PI / 180;
            double hA = hAngle * Math.PI / 180;

            double x = distance * Math.Sin(vA) * Math.Cos(hA);
            double y = distance * Math.Cos(vA);
            double z = distance * Math.Sin(vA) * Math.Sin(hA);

            pCam.Position = new Point3D(x, y, z);

            pCam.LookDirection = -(Vector3D)pCam.Position;
            pCam.LookDirection.Normalize();
        }

        private void MouseWheelHandler(object sender, MouseWheelEventArgs args)
        {
            PerspectiveCamera pCam = (mainViewport.Camera as PerspectiveCamera);

            if (mouseWheelIndex != args.Delta)
            {
                if (mouseWheelIndex > args.Delta)
                {
                    distance++;
                }
                if (mouseWheelIndex < args.Delta)
                {
                    distance--;
                }
            }

            UpdateCameraVectors();
        }

        private void MouseMoveEventHandler(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                double hAngleSpeed = 0.5;
                double vAngleSpeed = 0.5;
                hAngle += hAngleSpeed * (e.GetPosition(mainViewport).X - prevX);
                vAngle -= vAngleSpeed * (e.GetPosition(mainViewport).Y - prevY);

                if (vAngle > 179) vAngle = 179;
                else if (vAngle < 1) vAngle = 1;
            }

            prevX = e.GetPosition(mainViewport).X;
            prevY = e.GetPosition(mainViewport).Y;

            UpdateCameraVectors();
        }

        private void MouseDownHandler(object sender, MouseButtonEventArgs args)
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

                    // TODO: Add ability to modify the control point.
                    // TODO: Regenerate the Bezier surface.
                    //TranslateTransform3D transform = new TranslateTransform3D();
                    //hitgeo.Transform = transform;

                    // Change to blue material 
                    //hitgeo.Material = ShapeGenerator.GetSimpleMaterial(Colors.Red);
                }
            }

            return HitTestResultBehavior.Stop;
        }
    }
}
