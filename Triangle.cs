using OpenTK.Graphics;

class Triangle : Shapes
{
    public Triangle(Color4 color) : base(color)
    {
        vertices = new float[] { -0.5f, -0.5f, 0.5f, -0.5f, 0f, 0.5f };
    }
}