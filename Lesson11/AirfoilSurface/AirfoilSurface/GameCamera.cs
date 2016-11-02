using System;
using System.Windows.Input;
using System.Windows.Media.Media3D;

namespace AirfoilSurface
{
    public class GameCamera
    {
        private int mouseWheelIndex = 0;
        private double vAngle = 60;
        private double hAngle = 60;
        private double prevX = 0, prevY = 0;
        private double distance = 30;

        public PerspectiveCamera Camera { get; private set; }

        public GameCamera()
        {
            // Create the camera.
            Camera = new PerspectiveCamera();
            Camera.FieldOfView = 60;
            UpdateCameraVectors();
        }

        /// <summary>
        /// The camera movement will be looking at the origin while rotating
        /// around the object in the center of the scene.
        /// </summary>
        private void UpdateCameraVectors()
        {
            double vA = vAngle * Math.PI / 180;
            double hA = hAngle * Math.PI / 180;

            double x = distance * Math.Sin(vA) * Math.Cos(hA);
            double y = distance * Math.Cos(vA);
            double z = distance * Math.Sin(vA) * Math.Sin(hA);

            Camera.Position = new Point3D(x, y, z);

            Camera.LookDirection = -(Vector3D)Camera.Position;
            Camera.LookDirection.Normalize();
        }

        #region Event Handlers

        /// <summary>
        /// Handle scene zoom.
        /// </summary>
        public void MouseWheelHandler(object sender, MouseWheelEventArgs args)
        {
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
        public void MouseMoveEventHandler(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                double hAngleSpeed = 0.5;
                double vAngleSpeed = 0.5;
                hAngle += hAngleSpeed * (e.GetPosition(null).X - prevX);
                vAngle -= vAngleSpeed * (e.GetPosition(null).Y - prevY);

                if (vAngle > 179) vAngle = 179;
                else if (vAngle < 1) vAngle = 1;
            }

            prevX = e.GetPosition(null).X;
            prevY = e.GetPosition(null).Y;

            UpdateCameraVectors();
        }

        #endregion
    }
}
