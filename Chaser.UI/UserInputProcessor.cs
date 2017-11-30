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
            var player = GameStateSingleton.Instance.State.Player;
            
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

            if (_userInputConfiguration.Up && player.WillNotCollide(0, -1))
            {
                player.State.Y -= player.State.Velocity;
            }
            else
            { 
                player.State.Y += player.State.Velocity;
            }

            if (_userInputConfiguration.Down && player.WillNotCollide(0, 1))
            {
                player.State.Y += player.State.Velocity;
            }
            else
            {
                player.State.Y -= player.State.Velocity;
            }

            if (_userInputConfiguration.Left && player.WillNotCollide(-1, 0))
            {
                player.State.X -= player.State.Velocity;
            }
            else
            {
                player.State.X += player.State.Velocity;
            }

            if (_userInputConfiguration.Right && player.WillNotCollide(1, 0))
            {
                player.State.X += player.State.Velocity;
            }
            else
            {
                player.State.X -= player.State.Velocity;
            }
        }
    }
}
