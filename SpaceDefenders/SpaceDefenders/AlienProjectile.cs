using System;
namespace SpaceDefenders
{
    public class AlienProjectile : Projectile, IHittable
    {

        public AlienProjectile(int x, int y, Space game) : base(x, y, game)
        {
            MoveTrigger.Threshold = game.FPS / 2;
            Direction = Space.Direction.Down;
            game.Move(ref position, Direction);
        }

        public override void Collide(Collider c)
        {
            c.Collide(this, position);
        }

        public void Hit(Projectile p)
        {
            Game.Remove(this);
        }

        override public void Display(IRenderer renderer)
        {
            renderer.PutCharAt(position, '.');
        }

        public override void Move()
        {
            if (!Game.Move(ref position, Direction))
            {
                Game.Score += Settings.BombExplosion;
                Game.Remove(this);
            }
        }

    }

}
