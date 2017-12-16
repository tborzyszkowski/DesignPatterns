namespace AdapterExample
{
    public abstract class Shape
    {
        public int Width { get; set; }

        public int Height { get; set; }

        public string Type { get; set; }
    }

    public class Rectangle : Shape
    {
        public Rectangle()
        {
            this.Type = "Rectangle";
        }
    }

    public class Circle : Shape
    {
        public Circle()
        {
            this.Type = "Circle";
        }
    }

    public class Triangle : Shape
    {
        public Triangle()
        {
            this.Type = "Triangle";
        }
    }
}
