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
            _inputProcessor.Process();
        }
    }
}