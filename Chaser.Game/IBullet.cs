using System;

namespace Chaser.Game
{
    public interface IBullet : ISmart
    {
        Guid Id { get; }
        GameObjectState State { get; set; }
        Directions Direction { get; }
    }
}