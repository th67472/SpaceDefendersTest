using System;
using System.Windows.Forms;

namespace WinFormsGUI
{
    public class GameMenu : FlowLayoutPanel
    {
        public Button Start { get; }
        public Button Quit { get; }

        public GameMenu()
        {
            AutoSize = true;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;

            Start = new Button();
            Start.Text = "New Game";
            Quit = new Button();
            Quit.Text = "Quit";

            FlowDirection = FlowDirection.TopDown;
            Controls.Add(Start);
            Controls.Add(Quit);
        }
    }
}
