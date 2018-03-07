using System;
using System.Threading;
using SpaceDefenders;

namespace ConsoleGUI
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            var gui = new ConsoleGUI();
            gui.Run();
        }
    }

    class ConsoleGUI 
    {
        Space game;
        ConsoleRenderer renderer;
        int FPS = 60;
        int width = 40;
        int height = 20;

        bool isGameOver = false;

        public ConsoleGUI() 
        {
            game = new Space(FPS, width, height);
            renderer = new ConsoleRenderer(width, height);

            game.GameOver += Game_GameOver;
        }

        public void Run()
        {
            while (!isGameOver)
            {
                HandleKey();
                game.Tick();

                renderer.Clear();
                game.Display(renderer);
                renderer.Display();

                Thread.Sleep(1000 / FPS);
            }
        }

        void HandleKey()
        {
            if (Console.KeyAvailable)
            {
                var key = Console.ReadKey(true);

                switch (key.Key)
                {
                    case ConsoleKey.LeftArrow:
                        game.MoveLeft();
                        break;
                    case ConsoleKey.RightArrow:
                        game.MoveRight();
                        break;
                    case ConsoleKey.Spacebar:
                        game.Fire();
                        break;
                    case ConsoleKey.Escape:
                        game.SetGameOver();
                        break;
                }
            }
        }

        void Game_GameOver()
        {
            isGameOver = true;
        }
    }
}
