using System;
using Chaser.Game;
using SFML.Graphics;
using SFML.System;
using SFML.Window;

namespace Chaser.UI
{
    public class RenderingEngine
    {
        public RenderWindow window { get; set; }
        private static Sprite dogSprite = new Sprite(new Texture("Assets/doge.jpg"));

        public RenderingEngine(RenderWindow window)
        {
            this.window = window;
            
            dogSprite.Position = new Vector2f(
                GameStateSingleton.Instance.State.Player.X,
                GameStateSingleton.Instance.State.Player.Y);
            dogSprite.TextureRect = new IntRect(
                GameStateSingleton.Instance.State.Player.X,
                GameStateSingleton.Instance.State.Player.Y,
                GameStateSingleton.Instance.State.Player.Width,
                GameStateSingleton.Instance.State.Player.Height);
        }

        public void RenderGameState()
        {
            dogSprite.Position = new Vector2f(
                GameStateSingleton.Instance.State.Player.X,
                GameStateSingleton.Instance.State.Player.Y);

            window.DispatchEvents();
            window.Clear();
            dogSprite.Draw(window, RenderStates.Default);
            window.Display();
        }
    }
}
