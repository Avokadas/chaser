using System;
using Chaser.Game.TerrainObjects;

namespace Chaser.Game
{
    public interface IIterator
    {
        TerrainObject First();
        TerrainObject Next();
        bool IsDone { get; }
        TerrainObject CurrentItem { get; }
    }
}
