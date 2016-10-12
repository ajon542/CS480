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
        private int mouseWheelIndex = 0;
        private float Yaw = -90;
        private float Pitch = 0;
        private float xDelta = 0;
        private float yDelta = 0;

        public Vector3D Up { get; set; }
        public Vector3D Right { get; set; }

        public MainWindow()
        {
            InitializeComponent();

            MaterialGroup material = new MaterialGroup();
            material.Children.Add(ShapeGenerator.GetSimpleMaterial(Colors.Black));

            // Create Bezier patch.
            Vector3D[,] controlPoints = new Vector3D[,]
            {
                { new Vector3D(0, 0, 0), new Vector3D(2, 0, 0), new Vector3D(8, 0, 0), new Vector3D(10, 0, 0) },
                { new Vector3D(0, 0, 2), new Vector3D(2, 5, 2), new Vector3D(8, 5, 2), new Vector3D(10, 0, 2) },
                { new Vector3D(0, 0, 4), new Vector3D(2, 7, 4), new Vector3D(8, 6, 4), new Vector3D(10, 0, 4) },
                { new Vector3D(0, 0, 6), new Vector3D(2, 0, 6), new Vector3D(8, 0, 6), new Vector3D(10, 0, 6) },
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
            mainViewport.Children.Add(ShapeGenerator.CreatePlane(50, ShapeGenerator.GetSimpleMaterial(Colors.LightGray)));

            // Defines the camera used to view the 3D object. In order to view the 3D object,
            // the camera must be positioned and pointed such that the object is within view 
            // of the camera.
            PerspectiveCamera myPCamera = new PerspectiveCamera();

            // Specify where in the 3D scene the camera is.
            myPCamera.Position = new Point3D(5, 15, 15);

            // Specify the direction that the camera is pointing.
            myPCamera.LookDirection = new Vector3D(0, -1.5, -1);
            myPCamera.LookDirection.Normalize();

            // Define camera's horizontal field of view in degrees.
            myPCamera.FieldOfView = 60;

            // Asign the camera to the viewport
            mainViewport.Camera = myPCamera;

            MouseDown += MouseDownHandler;
            MouseUp += MouseUpHandler;
            KeyDown += KeyDownEventHandler;

            MouseWheel += MouseWheelHandler;
        }

        private void UpdateCameraVectors()
        {
            PerspectiveCamera pCam = (mainViewport.Camera as PerspectiveCamera);

            // Calculate the new look direction vector.
            pCam.LookDirection = new Vector3D(
                (float)(Math.Cos(ConvertToRadians(Yaw)) * Math.Cos(ConvertToRadians(Pitch))),
                (float)(Math.Sin(ConvertToRadians(Pitch))),
                (float)(Math.Sin(ConvertToRadians(Yaw)) * Math.Cos(ConvertToRadians(Pitch)))
            );
            pCam.LookDirection.Normalize();


            // Re-calculate the Right and Up vector.
            // Normalize the vectors, because their length gets closer to 0
            // the more you look up or down which results in slower movement.
            Right = Vector3D.CrossProduct(pCam.LookDirection, new Vector3D(0, 1, 0));
            Right.Normalize();
            Up = Vector3D.CrossProduct(Right, pCam.LookDirection);
            Up.Normalize();
        }

        private void KeyDownEventHandler(object sender, KeyEventArgs e)
        {
            PerspectiveCamera pCam = (mainViewport.Camera as PerspectiveCamera);

            if (e.Key == Key.A)
            {
                pCam.Position -= Right;
            }

            if (e.Key == Key.D)
            {
                pCam.Position += Right;
            }

            UpdateCameraVectors();
        }

        private void MouseWheelHandler(object sender, MouseWheelEventArgs args)
        {
            PerspectiveCamera pCam = (mainViewport.Camera as PerspectiveCamera);

            if (mouseWheelIndex != args.Delta)
            {
                if (mouseWheelIndex > args.Delta)
                {
                    pCam.Position -= pCam.LookDirection;
                }
                if (mouseWheelIndex < args.Delta)
                {
                    pCam.Position += pCam.LookDirection;
                }
            }
        }

        private void MouseUpHandler(object sender, MouseButtonEventArgs args)
        {
            Point mouseposition = args.GetPosition(mainViewport);

            xDelta = (xDelta - (float)mouseposition.X) * 0.1f;
            yDelta = (yDelta - (float)mouseposition.Y) * 0.1f;

            Yaw += xDelta;
            Pitch -= yDelta;

            UpdateCameraVectors();
        }

        private void MouseDownHandler(object sender, MouseButtonEventArgs args)
        {
            Point mouseposition = args.GetPosition(mainViewport);

            xDelta = (float)mouseposition.X;
            yDelta = (float)mouseposition.Y;

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

        private double ConvertToRadians(double angle)
        {
            return (Math.PI / 180) * angle;
        }
    }
}
