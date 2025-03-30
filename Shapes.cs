using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;
using GL = OpenTK.Graphics.OpenGL.GL;

abstract class Shapes
{
    protected float[] vertices;
    protected Color4 color;
    protected float angle = 0;
    protected float scale = 1;
    protected Vector2 position = Vector2.Zero;
    internal Color4 Color;

    public Shapes(Color4 color)
    {
        this.color = color;
    }

    public void Draw()
    {
        GL.Color4(color);
        GL.PushMatrix();
        GL.Translate(position.X, position.Y, 0);
        GL.Rotate(angle, 0, 0, 1);
        GL.Scale(scale, scale, 1);
        GL.Begin(PrimitiveType.Polygon);
        for (int i = 0; i < vertices.Length; i += 2)
        {
            GL.Vertex2(vertices[i], vertices[i + 1]);
        }
        GL.End();
        GL.PopMatrix();
    }

    public void Translate(float dx, float dy) => position += new Vector2(dx, dy);
    public void Rotate(float degrees) => angle += degrees;
    public void Scale(float factor) => scale *= factor;
}
