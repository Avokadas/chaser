using System.Diagnostics;
using System.Collections.Generic;
using System.Dynamic;
using Chaser.Game.Commands;

namespace Chaser.Game
{
    public class GameState
    {
        public bool GameRunning { get; set; }
        public Player Player { get; set; }
        public GameMap Map { get; set; }
        public Chaser Chaser { get; set; }
        public List<Bullet> Bullets { get; set; } = new List<Bullet>();

        public void MutateGameState()
        {
            var commands = new List<Command>();
            commands.AddRange(Chaser.ReturnNextMove());
            Bullets.ForEach(x => commands.AddRange(x.ReturnNextMove()));

            commands.ForEach(x => x.Execute());
        }
    }
}