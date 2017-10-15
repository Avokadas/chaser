using System.Diagnostics;
using System.Collections.Generic;

namespace Chaser.Game
{
    public class GameState
    {
        public Player Player { get; set; }
        public GameMap Map { get; set; }
        public Chaser Chaser { get; set; }
        public BulletList BulletList { get; set; }
    }
}