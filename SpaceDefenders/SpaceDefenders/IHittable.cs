using System;
namespace SpaceDefenders
{
    public interface IHittable : ICollidable
    {
        void Hit(Projectile p);
    }
}
