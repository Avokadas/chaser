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
        private static Sprite playerSprite = new Sprite(new Texture("Assets/player.jpg"));
        private static Sprite chaserSprite = new Sprite(new Texture("Assets/doge.jpg"));

        public RenderingEngine(RenderWindow window)
        {
            this.window = window;

            playerSprite.Position = new Vector2f(
                GameStateSingleton.Instance.State.Player.X,
                GameStateSingleton.Instance.State.Player.Y);
            playerSprite.TextureRect = new IntRect(
                GameStateSingleton.Instance.State.Player.X,
                GameStateSingleton.Instance.State.Player.Y,
                GameStateSingleton.Instance.State.Player.Width,
                GameStateSingleton.Instance.State.Player.Height);

            chaserSprite.Position = new Vector2f(
                GameStateSingleton.Instance.State.Chaser.X,
                GameStateSingleton.Instance.State.Chaser.Y);
            chaserSprite.TextureRect = new IntRect(
                GameStateSingleton.Instance.State.Chaser.X,
                GameStateSingleton.Instance.State.Chaser.Y,
                GameStateSingleton.Instance.State.Chaser.Width,
                GameStateSingleton.Instance.State.Chaser.Height);
        }

        public void RenderGameState()
        {
            playerSprite.Position = new Vector2f(
                GameStateSingleton.Instance.State.Player.X,
                GameStateSingleton.Instance.State.Player.Y);
            chaserSprite.Position = new Vector2f(
                GameStateSingleton.Instance.State.Chaser.X,
                GameStateSingleton.Instance.State.Chaser.Y);

            window.DispatchEvents();
            window.Clear();
            playerSprite.Draw(window, RenderStates.Default);
            chaserSprite.Draw(window, RenderStates.Default);
            window.Display();
        }
    }
}
