using System;
using SpaceDefenders;
using System.Drawing;
using System.Windows.Forms;

namespace WinFormsGUI
{
    public class GameBoard : Control
    {
        Space game;
        int width, height, scale;

        public GameBoard(Space game, int width, int height, int scale) : base()
        {
            this.game = game;
            this.width = width;
            this.height = height;
            this.scale = scale;

            DoubleBuffered = true;

            BackColor = Color.LightBlue;
            Width = width * scale;
            Height = height * scale;

            Paint += GameBoard_Paint;
        }

        void GameBoard_Paint(object sender, PaintEventArgs e) {
            var renderer = new GraphicsRenderer(e.Graphics, width, height, scale);
            game.Display(renderer);
        }

     
    }
}
