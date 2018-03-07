using System;
namespace SpaceDefenders
{
    public interface ICollidable : IAnimatable
    {
        void Collide(Collider c);
    }
}
