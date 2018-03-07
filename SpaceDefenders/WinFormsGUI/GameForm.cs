using System;
using System.Drawing;
using SpaceDefenders;
using System.Windows.Forms;


namespace WinFormsGUI
{
    public class GameForm : Form
    {
        Space game;
        int width = 40;
        int height = 20;
        int FPS = 20;

        GameBoard gameBoard;
        BottomPanel bottomPanel;
        GameMenu menu;
        Timer timer;

        public GameForm() : base()
        {
            AutoSize = true;

            game = new Space(FPS, width, height);
            game.GameOver += Game_GameOver;
            game.ScoreChanged += Game_ScoreChanged;

            timer = new Timer();
            timer.Interval = 1000 / FPS;
            timer.Tick += Timer_Tick;

            var flow = new FlowLayoutPanel();
            flow.FlowDirection = FlowDirection.TopDown;
            flow.AutoSize = true;

            gameBoard = new GameBoard(game, width, height, 20);
            flow.Controls.Add(gameBoard);

            bottomPanel = new BottomPanel(game, width, height, 20);
            flow.Controls.Add(bottomPanel);

            menu = new GameMenu();

            Controls.Add(flow);
            Controls.Add(menu);

            menu.Location = new Point((Width - menu.Width) / 2, (Height - menu.Height) / 2);
            menu.BringToFront();
            menu.Start.Click += Start_Click;
            menu.Quit.Click += Quit_Click;


            KeyDown += GameForm_KeyDown;
            KeyPreview = true;

        }

        void Timer_Tick(object sender, EventArgs e)
        {
            game.Tick();
            gameBoard.Refresh();
        }

        void Start_Click(object sender, EventArgs e)
        {
            timer.Start();
            menu.Visible = false;
        }

        void Quit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        void Game_GameOver()
        {
            timer.Stop();
            menu.Visible = true;
        }

        void Game_ScoreChanged()
        {
            bottomPanel.Refresh();
        }

        void GameForm_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Left:
                    game.MoveLeft();
                    break;
                case Keys.Right:
                    game.MoveRight();
                    break;
                case Keys.Space:
                    game.Fire();
                    break;
                case Keys.Escape:
                    game.SetGameOver();
                    break;
            }
        }


    }
}
