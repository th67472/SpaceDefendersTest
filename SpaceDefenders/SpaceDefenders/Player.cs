using System;
namespace SpaceDefenders
{
    public class Player : ICollidable, IHittable
    {
        Position position;

        Space Game;

        public enum Direction { Left, Right }

        public Player(int x, int y, Space game)
        {
            position = new Position(x, y);
            Game = game;
        }

        public void Display(IRenderer renderer) 
        {
            renderer.PutCharAt(position, 'Y');
        }

        public void Tick()
        {
            // ...
        }

        public void Collide(Collider c)
        {
            c.Collide(this, position);
        }

    
        public void Hit(Projectile p)
        {
            Game.SetGameOver();
        }

        public void Fire()
        {
            var shot = new PlayerProjectile(position.X, position.Y, Game);
            Game.Add(shot);
        }

        public void Move(Direction direction) {

            switch (direction) {
                case Direction.Left :
                    Game.Move(ref position, Space.Direction.Left);
                    break;
                case Direction.Right :
                    Game.Move(ref position, Space.Direction.Right);
                    break;
            }
        }
    }
}
