using OpenTK.Graphics;

static class ShapeFactory
{
    public static Shapes CreateShape(string type, Color4 color)
    {
        switch (type)
        {
            case "Triangle":
                return new Triangle(color);
            case "Square":
                return new Square(color);
            case "Circle":
                return new Circle(color);
            case "Rectangle":
                return new Rectangle(color);
            case "Pentagon":
                return new Pentagon(color);
            default:
                return new Triangle(color);
        }
    }
}

