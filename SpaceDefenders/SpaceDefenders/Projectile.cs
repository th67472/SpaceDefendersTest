using System;
namespace SpaceDefenders
{
    public abstract class Projectile : ICollidable
    {
        protected Position position;
        protected Space Game;

        protected Trigger MoveTrigger = new Trigger();
        protected Space.Direction Direction;

        public Projectile(int x, int y, Space game)
        {
            position = new Position(x, y);
            Game = game;
            MoveTrigger.Triggered += Move;
        }

        public void Strike(IHittable h)
        {
            h.Hit(this);
            Game.Remove(this);
        }

        // must be abstract - double dispatch requires implementation in every class
        public abstract void Collide(Collider c);

        public void Tick()
        {
            MoveTrigger.Tick();
        }

        public abstract void Display(IRenderer renderer);
        public abstract void Move();
 

    }


 
}
