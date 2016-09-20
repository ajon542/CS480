
namespace Windmill.Shapes
{
    public class Circle : Shape
    {
        public Circle(Vector2 center, double radius)
        {
            Vector2 point = new Vector2(center.x + radius, center.y);
            Points.Add(point);
            for (int i = 1; i < 360; ++i)
            {
                point = Shape.Rotate(point, center, 1);
                Points.Add(point);
            }
        }
    }
}
