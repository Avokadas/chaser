using System.Collections.Generic;
using SFML.Graphics;

namespace Chaser.Game
{
    public class GameFacade
    {
        public GameFacade(RenderWindow window)
        {
            Window = window;
        }

        private RenderWindow Window { get; set; }
        

        public void RemoveAll()
        {
            GameStateSingleton.Instance.State.Chaser = null;
            GameStateSingleton.Instance.State.Player = null;
            GameStateSingleton.Instance.State.Bullets = new List<Bullet>();
            GameStateSingleton.Instance.State.Map.TerrainObjects = new List<GameObject>();
        }
    }
}