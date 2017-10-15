using System.Runtime.InteropServices;
using Chaser.Game;
using Chaser.UI;
using NUnit.Framework;

namespace Chaser.Tests
{
    [TestFixture]
    public class PatternExamples
    {
        [Test]
        public void SingletonPattern()
        {
            var starterState = GameStateSingleton.Instance.State.GameRunning;

            GameStateSingleton.Instance.State.GameRunning = false;

            var modifiedState = GameStateSingleton.Instance.State.GameRunning;

            Assert.AreNotEqual(starterState, modifiedState);
        }

        [Test]
        public void AbstractFactory()
        {
            var factory = new DefaultSpriteFactory();

            var bullet = new Bullet(default(Directions), null);
            var chaser = new Game.Chaser();

            var bulletSprite = factory.CreateSprite(bullet);
            var chaserSprite = factory.CreateSprite(chaser);

            Assert.AreNotSame(bulletSprite.Texture, chaserSprite.Texture);
        }

        [Test]
        public void 
    }
}
