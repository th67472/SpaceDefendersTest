using System;
using SpaceDefenders;
using System.Drawing;

namespace WinFormsGUI
{
    public class GraphicsRenderer : IRenderer
    {
        Graphics graphics;
        Font font = new Font("Arial", 16);
        Brush brush = new SolidBrush(Color.Black);
        int scale;
        int height;

        public GraphicsRenderer(Graphics graphics, int width, int height, int scale)
        {
            this.graphics = graphics;
            this.scale = scale;
            this.height = height;
        }

        public void PutCharAt(Position position, char c)
        {
            var s = new string(c, 1);
            graphics.DrawString(s, font, brush, new PointF(position.X * scale, (height - position.Y - 1) * scale));
        }
    }
}
