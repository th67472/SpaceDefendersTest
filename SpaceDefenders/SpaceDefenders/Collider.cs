using System;
namespace SpaceDefenders
{
    public class Collider
    {
        IHittable[,] CollisionMatrix;
        int Width, Height;

        public Collider(int witdh, int height)
        {
            CollisionMatrix = new IHittable[witdh, height];
            Width = witdh; Height = height;
            Clear();
        }

        public void Clear()
        {
            for (var x = 0; x < Width; x++) {
                for (var y = 0; y < Height; y++) {
                    CollisionMatrix[x, y] = null;
                }
            }
        }

        // player and aliens, no collision detection done
        public void Collide(IHittable h, Position position)
        {
            CollisionMatrix[position.X, position.Y] = h;
        }

        public void Collide(AlienProjectile p, Position position)
        {
            if (CollisionMatrix[position.X, position.Y] != null)
            {
                p.Strike(CollisionMatrix[position.X, position.Y]);
            }
            else 
            {
                CollisionMatrix[position.X, position.Y] = p;
            }
        }

        public void Collide(PlayerProjectile p, Position position) 
        {
            if (CollisionMatrix[position.X, position.Y] != null)
            {
                p.Strike(CollisionMatrix[position.X, position.Y]);
            }
        }
    }
}
