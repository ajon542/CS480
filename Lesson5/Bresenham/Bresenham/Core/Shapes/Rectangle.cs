
namespace GameEngine.Core.Shapes
{
    public class Rectangle : Shape
    {
        public Rectangle(double x, double y, double width, double height)
        {
            Points.Add(new Vector2(x, y));
            Points.Add(new Vector2(x, y + height));
            Points.Add(new Vector2(x + width, y + height));
            Points.Add(new Vector2(x + width, y));
        }
    }
}
