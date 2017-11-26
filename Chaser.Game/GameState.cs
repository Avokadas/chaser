using System.Collections.Generic;
using Chaser.Game.Commands;

namespace Chaser.Game
{
    public class GameState
    {
        public bool GameRunning { get; set; }
        public int Score { get; set; }
        public Player Player { get; set; }
        public GameMap Map { get; set; }
        public Chaser Chaser { get; set; }
        public List<IBullet> Bullets { get; set; } = new List<IBullet>();

        public void MutateGameState()
        {
            var commands = new List<Command>();
            commands.AddRange(Chaser.ReturnNextMove());
            Bullets.ForEach(x => commands.AddRange(x.ReturnNextMove()));

            commands.ForEach(x => x.Execute());
        }
    }
}