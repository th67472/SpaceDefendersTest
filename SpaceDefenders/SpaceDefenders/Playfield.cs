using System;
using System.Collections.Generic;

namespace SpaceDefenders
{
    public class Playfield
    {
        protected int Width, Height;

        List<IDisplayable> Displayables = new List<IDisplayable>();
        public enum Direction { Left, Right, Up, Down }


        public Playfield(int width, int height)
        {
            Width = width; Height = height;
        }

        public bool Move(ref Position position, Direction direction)
        {
            switch (direction)
            {
                case Direction.Left:
                    if (position.X > 0)
                    {
                        position.X--;
                        return true;
                    }
                    break;

                case Direction.Right:
                    if (position.X < Width - 1)
                    {
                        position.X++;
                        return true;
                    }
                    break;

                case Direction.Up:
                    if (position.Y < Height - 1)
                    {
                        position.Y++;
                        return true;
                    }
                    break;
                case Direction.Down:
                    if (position.Y > 0)
                    {
                        position.Y--;
                        return true;
                    }
                    break;
            }
            return false;
        }

        public void Add(IDisplayable displayable) {
            Displayables.Add(displayable);
        }
        public void Remove(IDisplayable displayble) {
            Displayables.Remove(displayble);
        }

        public void Display(IRenderer renderer) {
            foreach (var displayable in Displayables) {
                displayable.Display(renderer);
            }
        }

    }

    /*
    public class Position : Position
    {
        int Width, Height;

        public enum Direction { Left, Right, Up, Down }

        public Position(int width, int height, int x, int y) : base(x,y) 
        {
            Width = width; Height = height;
        }


    }
*/
}
