using System;
namespace SpaceDefenders
{
    public class PlayerProjectile : Projectile
    {

        public PlayerProjectile(int x, int y, Space game) : base(x, y, game)
        {
            MoveTrigger.Threshold = Game.FPS / 5;
            Direction = Space.Direction.Up;
            game.Move(ref position, Direction);
        }

        public override void Collide(Collider c)
        {
            c.Collide(this, position);
        }

        public override void Display(IRenderer renderer)
        {
            renderer.PutCharAt(position, '|');
        }

        public override void Move()
        {
            if (!Game.Move(ref position, Direction))
            {
                Game.Remove(this);
            }
        }        

    }
}
