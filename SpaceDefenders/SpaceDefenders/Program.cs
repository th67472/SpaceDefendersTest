using System;

namespace SpaceDefenders
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            var game = new Space(50, 40, 20);
            game.Tick();
        }
    }
}
