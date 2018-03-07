using System;
using System.Collections.Generic;

namespace SpaceDefenders
{
    public class Space : Playfield
    {
        internal int FPS;
        const int MinimumHeight = 5;

        public delegate void GameOverHandler();
        public event GameOverHandler GameOver;

        public delegate void ScoreChangedHandler();
        public event ScoreChangedHandler ScoreChanged;

        Player Player;

        LinkedList<ICollidable> Collidables = new LinkedList<ICollidable>();

        Random Random = new Random();

        Collider Collider;

        int score;
        public int Score {
            get => score;
            internal set 
            { 
                score = value;
                ScoreChanged?.Invoke();
            }
        }

        public Space(int fps, int width, int height) : base(width, height)
        {
            Collider = new Collider(width, height);
            Player = new Player(width / 2, 0, this);
            Add(Player);
            FPS = fps;
        }

        public void Tick() 
        {
            SpawnAlien();
            Animate();
            Collide();
        }

        void Collide() 
        {
            Collider.Clear();

            // We first check collisions between hittables (Aliens and Player)
            var collidableArray = new ICollidable[Collidables.Count];
            Collidables.CopyTo(collidableArray, 0);

            foreach (var collidable in collidableArray)
            {
                collidable.Collide(Collider);
            }
        }

        void SpawnAlien()
        {
            // 10% chance to spawn an alien every frame - higher framerate means
            // more aliens. Shoud potentially use a Trigger
            if (Random.Next(10) == 0) {

                var startHeigh = Random.Next(Height - MinimumHeight);
                var startSide = Random.Next(2);

                Alien alien;

                if (startSide == 0) // Left
                {
                    alien = new Alien(0, MinimumHeight + startHeigh, Space.Direction.Right, this);
                }
                else
                {
                    alien = new Alien(Width - 1, MinimumHeight + startHeigh, Space.Direction.Left, this);
                }

                Add(alien);
            }
            
        }

        void Animate() 
        {
            // Since the split of Hittables and Projectiles we must animate both
            var collidableArray = new ICollidable[Collidables.Count];
            Collidables.CopyTo(collidableArray, 0);
            foreach (var collidable in collidableArray) 
            {
                collidable.Tick();
            }
        }

        public void MoveLeft() => Player.Move(Player.Direction.Left);
        public void MoveRight() => Player.Move(Player.Direction.Right);
        public void Fire() => Player.Fire();

        public void SetGameOver()
        {
            GameOver?.Invoke();
        }

        // hittables first, to be collided first
        public void Add(Alien alien) 
        {
            base.Add(alien);
            Collidables.AddFirst(alien);
        }

        public void Add(Player player)
        {
            base.Add(player);
            Collidables.AddFirst(player);
        }

        // projectiles last
        public void Add(Projectile p)
        {
            base.Add(p);
            Collidables.AddLast(p);
        }

        public void Remove(ICollidable collidable)
        {
            base.Remove(collidable);
            Collidables.Remove(collidable);
        }
    }
}
