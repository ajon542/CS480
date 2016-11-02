using System;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Media3D;

namespace AirfoilSurface
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
        private double distance = 30;


        public MainWindow()
        {

            InitializeComponent();

            // Create a basic material.
            MaterialGroup material = new MaterialGroup();
            material.Children.Add(ShapeGenerator.GetSimpleMaterial(Colors.LightGreen));

            // Create a sphere.
            Transform3DGroup transformGroup = new Transform3DGroup();
            ModelVisual3D sphere = ShapeGenerator.GenerateUnitSphere(30, 30, material);
            mainViewport.Children.Add(sphere);

            // Create the camera.
            PerspectiveCamera camera = new PerspectiveCamera();
            camera.FieldOfView = 60;
            mainViewport.Camera = camera;
            UpdateCameraVectors();

            // Setup the event handlers.
            MouseMove += MouseMoveEventHandler;
            MouseWheel += MouseWheelHandler;
        }

        /// <summary>
        /// The camera movement will be looking at the origin while rotating
        /// around the object in the center of the scene.
        /// </summary>
        private void UpdateCameraVectors()
        {
            PerspectiveCamera camera = (mainViewport.Camera as PerspectiveCamera);

            double vA = vAngle * Math.PI / 180;
            double hA = hAngle * Math.PI / 180;

            double x = distance * Math.Sin(vA) * Math.Cos(hA);
            double y = distance * Math.Cos(vA);
            double z = distance * Math.Sin(vA) * Math.Sin(hA);

            camera.Position = new Point3D(x, y, z);

            camera.LookDirection = -(Vector3D)camera.Position;
            camera.LookDirection.Normalize();
        }

        #region Event Handlers

        /// <summary>
        /// Handle scene zoom.
        /// </summary>
        private void MouseWheelHandler(object sender, MouseWheelEventArgs args)
        {
            PerspectiveCamera camera = (mainViewport.Camera as PerspectiveCamera);

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

        /// <summary>
        /// Handle scene rotation.
        /// </summary>
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

        #endregion
    }
}
