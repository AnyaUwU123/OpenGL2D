using OpenTK.Graphics;
using OpenTK;
using System;
using System.Collections.Generic;

class Pentagon : Shapes
{
    public Pentagon(Color4 color) : base(color)
    {
        List<float> verts = new List<float>();
        for (int i = 0; i < 360; i += 72) // 360/5 lados
        {
            float rad = MathHelper.DegreesToRadians(i);
            verts.Add((float)Math.Cos(rad) * 0.5f);
            verts.Add((float)Math.Sin(rad) * 0.5f);
        }
        vertices = verts.ToArray();
    }
}
