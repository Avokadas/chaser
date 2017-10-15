using Chaser.Game;
using Chaser.UI;

namespace Chaser.Adapters
{
    public class UserInputProcessorAdapter : ILoopAdapter
    {
        private UserInputProcessor _inputProcessor;

        public UserInputProcessorAdapter(UserInputProcessor inputProcessor)
        {
            _inputProcessor = inputProcessor;
        }

        public void PerformLoopAction()
        {
            if (GameStateSingleton.Instance.State.GameRunning)
            {
                _inputProcessor.Process();
            }
        }
    }
}