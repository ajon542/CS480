
namespace Windmill.Shapes
{
    public class Triangle : Shape
    {
        public Triangle(Vector2 a, Vector2 b, Vector2 c)
        {
            Points.Add(a);
            Points.Add(b);
            Points.Add(c);
        }
    }
}
