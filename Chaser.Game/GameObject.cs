using System;
using System.Linq;
using System.Threading;
using SFML.System;

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
        public Timer Timer;

        public bool WillNotCollide(int x, int y)
        {
            var trueCount = 1;
            var iterator = GameStateSingleton.Instance.State.Map.TerrainObjects.CreateIterator();
            for (var item = iterator.CurrentItem; iterator.Next() != null; iterator.Next())
            {
                if (State.X + x > item.State.X + item.State.Width
                || State.X + x + State.Width < item.State.X
                || State.Y + y > item.State.Y + item.State.Height
                || State.Y + y + State.Height < item.State.Y) {
                    trueCount++;
                }
            }

            return trueCount == GameStateSingleton.Instance.State.Map.TerrainObjects.Count;
        }

        public void Accept(GameObjectVisitor visitor)
        {
            visitor.VisitGameObject(this);
        }
    }
}
