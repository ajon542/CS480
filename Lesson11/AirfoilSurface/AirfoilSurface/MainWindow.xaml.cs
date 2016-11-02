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

            // Create and assign the camera.
            GameCamera camera = new GameCamera();
            mainViewport.Camera = camera.Camera;

            // Setup the event handlers.
            MouseMove += camera.MouseMoveEventHandler;
            MouseWheel += camera.MouseWheelHandler;
        }
    }
}
