using Chaser.Game;
using SFML.Graphics;

namespace Chaser.UI
{
    public class UserInputProcessor
    {
        private readonly UserInputConfiguration _userInputConfiguration;
        private readonly RenderWindow _window;

        public UserInputProcessor(UserInputConfiguration userInputConfiguration, RenderWindow window)
        {
            _userInputConfiguration = userInputConfiguration;
            _window = window;

            window.KeyPressed += _userInputConfiguration.KeyPressed;
            window.KeyReleased += _userInputConfiguration.KeyReleased;
        }

        public void Process()
        {
            if (_userInputConfiguration.Close)
            {
                _window.Close();
            }
            if (_userInputConfiguration.End)
            {
                var facade = new GameFacade(_window);
                GameStateSingleton.Instance.State.GameRunning = false;
                facade.RemoveAll();
            }
            if (_userInputConfiguration.Up)
            {
                GameStateSingleton.Instance.State.Player.State.Y -= 1;
            }
            if (_userInputConfiguration.Down)
            {
                GameStateSingleton.Instance.State.Player.State.Y += 1;
            }
            if (_userInputConfiguration.Left)
            {
                GameStateSingleton.Instance.State.Player.State.X -= 1;
            }
            if (_userInputConfiguration.Right)
            {
                GameStateSingleton.Instance.State.Player.State.X += 1;
            }
        }
    }
}
