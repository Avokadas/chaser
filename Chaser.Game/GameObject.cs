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
            return
            GameStateSingleton.Instance.State.Map.TerrainObjects.All(terrainObject =>  
                (State.X + x > terrainObject.State.X + terrainObject.State.Width
                || State.X + x + State.Width < terrainObject.State.X
                || State.Y + y > terrainObject.State.Y + terrainObject.State.Height
                || State.Y + y + State.Height < terrainObject.State.Y)
            );
        }
    }
}
