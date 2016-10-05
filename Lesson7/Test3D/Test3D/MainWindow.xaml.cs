using System;
using System.Windows;
using System.Windows.Controls;
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
        }
    }
}
