using System;

namespace Chaser.Game
{
    public class GameObject
    {
        public GameObject(int x, int y, int xpic, int ypic, int width, int height, bool isCollidable)
        {
            //position
            State.X = x;
            State.Y = y;

            //picture x y
            State.Xpic = xpic;
            State.Ypic = ypic;
            State.Width = width;
            State.Height = height;
            State.IsCollidable = isCollidable;
            Id = Guid.NewGuid();
        }

        public GameObject()
        {
            Id = Guid.NewGuid();
        }

        public Guid Id { get; }
        public GameObjectState State { get; set; } = new GameObjectState();
    }
}
