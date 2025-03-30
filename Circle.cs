using OpenTK.Graphics;
using OpenTK;
using System;
using System.Collections.Generic;

class Circle : Shapes
{
    public Circle(Color4 color) : base(color)
    {
        List<float> verts = new List<float>();
        for (int i = 0; i < 360; i += 5) // Menor incremento para más suavidad
        {
            float rad = MathHelper.DegreesToRadians(i);
            verts.Add((float)Math.Cos(rad) * 0.5f);
            verts.Add((float)Math.Sin(rad) * 0.5f);
        }
        vertices = verts.ToArray();
    }
}

