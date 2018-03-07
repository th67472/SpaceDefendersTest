using System;
namespace SpaceDefenders
{
    public interface IAnimatable : IDisplayable
    {
        void Tick();
    }
}
