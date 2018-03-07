using System;
using SpaceDefenders;
using System.Drawing;
using System.Windows.Forms;

namespace WinFormsGUI
{
    public class BottomPanel : UserControl
    {
        Space game;
        Font font = new Font("Arial", 20);
        Brush brush = new SolidBrush(Color.White);

        public BottomPanel(Space game, int width, int height, int scale) : base()
        {
            BackColor = Color.DarkBlue;
            Width = width * scale;
            Height = 60;

            this.game = game;

            Paint += BottomPanel_Paint;
        }

        void BottomPanel_Paint(object sender, PaintEventArgs e)
        {
            var s = $"Space Defenders {game.Score}";
            e.Graphics.DrawString(s, font, brush, new PointF(15, (Height - font.Height)/2 ));
        }
    }
}
