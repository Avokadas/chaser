using Chaser.Game;
using SFML.Graphics;

namespace Chaser.UI
{
    public class UserInputProcessor
    {
        public UserInputConfiguration UserInputConfiguration { get; }
        private RenderWindow _window;

        public UserInputProcessor(UserInputConfiguration userInputConfiguration, RenderWindow window)
        {
            UserInputConfiguration = userInputConfiguration;
            _window = window;
        }

        public void Process()
        {
            if (UserInputConfiguration.Close)
            {
                _window.Close();
            }
            if (UserInputConfiguration.Up)
            {
                GameStateSingleton.Instance.State.Player.Y -= 1;
            }
            if (UserInputConfiguration.Down)
            {
                GameStateSingleton.Instance.State.Player.Y += 1;
            }
            if (UserInputConfiguration.Left)
            {
                GameStateSingleton.Instance.State.Player.X -= 1;
            }
            if (UserInputConfiguration.Right)
            {
                GameStateSingleton.Instance.State.Player.X += 1;
            }
        }
    }
}
