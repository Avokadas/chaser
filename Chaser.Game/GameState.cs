using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Chaser.Game.Commands;
using Newtonsoft.Json;

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

    public class GameSave
    {
        public GameObjectState ChaserState { get; private set; }
        public GameObjectState PlayerState { get; private set; }
        public int Score { get; private set; }
         

        public GameSave(GameState state)
        {
            Score = Score;
            ChaserState = JsonConvert.DeserializeObject<GameObjectState>(JsonConvert.SerializeObject(state.Chaser.State));
            PlayerState = JsonConvert.DeserializeObject<GameObjectState>(JsonConvert.SerializeObject(state.Player.State));
        }
    }
}