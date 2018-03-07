using System;
namespace SpaceDefenders
{
    public class Alien : IHittable
    {
        Position position;

        Space Game;
        Space.Direction Direction;

        Trigger MoveTrigger = new Trigger();
        Trigger FireTrigger = new Trigger(); 

        Random Random = new Random();

        public Alien(int x, int y, Space.Direction direction, Space game)
        {
            position = new Position(x, y);
            Game = game;
            Direction = direction;

            MoveTrigger.Threshold = Game.FPS / 2;
            FireTrigger.Threshold = Game.FPS / 5;

            MoveTrigger.Triggered += Move;
            FireTrigger.Triggered += Fire;
        }

        public void Collide(Collider c)
        {
            c.Collide(this, position);
        }

        public void Hit(Projectile p)
        {
            Game.Score += Settings.AlienExplosion;
            Game.Remove(this);
        }


        public void Tick() {
            MoveTrigger.Tick();
            FireTrigger.Tick();
        }

        void Move()
        {
            if (!Game.Move(ref position, Direction))
            {
                Game.Score += Settings.AlienEscaped;
                Game.Remove(this);
            }
        }

        void Fire()
        {
            if (Random.Next(10) <= 1) // 20% chance every 10th second 
            {
                var shot = new AlienProjectile(position.X, position.Y, Game);
                Game.Add(shot);
            }
        }

        public void Display(IRenderer renderer)
        {
            renderer.PutCharAt(position, 'X');
        }
    }
}
