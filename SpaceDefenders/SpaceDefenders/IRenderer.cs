using System;
namespace SpaceDefenders
{
    public interface IRenderer
    {
        void PutCharAt(Position position, char c);
    }
}
