using Chaser.Game;
using NUnit.Framework;


namespace Chaser.PatternExamples
{
    [TestFixture]
    public class PatternExamples
    {
        [Test]
        public void SingletonPatternExample()
        {
            var starterState = GameStateSingleton.Instance.State.GameRunning;

            GameStateSingleton.Instance.State.GameRunning = false;

            var modifiedState = GameStateSingleton.Instance.State.GameRunning;

            Assert.AreNotEqual(starterState, modifiedState);
        }
    }
}
