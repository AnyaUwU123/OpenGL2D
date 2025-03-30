using OpenTK.Graphics;

class Square : Shapes
{
    public Square(Color4 color) : base(color)
    {
        vertices = new float[] { -0.5f, -0.5f, 0.5f, -0.5f, 0.5f, 0.5f, -0.5f, 0.5f };
    }
}