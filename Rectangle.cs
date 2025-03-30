using OpenTK.Graphics;

class Rectangle : Shapes
{
    public Rectangle(Color4 color) : base(color)
    {
        vertices = new float[] { -0.6f, -0.3f, 0.6f, -0.3f, 0.6f, 0.3f, -0.6f, 0.3f };
    }
}
