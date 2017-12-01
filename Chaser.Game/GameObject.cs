using System;
using System.Linq;

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

        public bool WillNotCollide(int x, int y)
        {
            var trueCount = 0;
            for (int i = 0; i < GameStateSingleton.Instance.State.Map.TerrainObjects.Count; i++) {
                GameObject temp = (GameObject)GameStateSingleton.Instance.State.Map.TerrainObjects[i];
                if (State.X + x > temp.State.X + temp.State.Width
                || State.X + x + State.Width < temp.State.X
                || State.Y + y > temp.State.Y + temp.State.Height
                || State.Y + y + State.Height < temp.State.Y) {
                    trueCount++;
                }
            }

            return trueCount == GameStateSingleton.Instance.State.Map.TerrainObjects.Count;
        }
    }
}
