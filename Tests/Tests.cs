using Chaser.Adapters;
using Chaser.Game;
using Chaser.Game.Commands;
using Chaser.Game.Strategies;
using Chaser.Game.TerrainObjects;
using Chaser.UI;
using Moq;
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
        public void AbstractFactoryPattern()
        {
            var factory = new DefaultSpriteFactory();

            var bullet = new Bullet(default(Directions), null);
            var chaser = new StraightChaser();

            var bulletSprite = factory.CreateSprite(bullet);
            var chaserSprite = factory.CreateSprite(chaser);

            Assert.AreNotSame(bulletSprite.Texture, chaserSprite.Texture);
        }

        [Test]
        public void StrategyPattern()
        {
            GameStateSingleton.Instance.State.Player.State.X = 100;
            GameStateSingleton.Instance.State.Player.State.Y = 100;    
            
            var bullet = new Bullet(Directions.Left, new NullTravelBulletStrategy());
            GameStateSingleton.Instance.State.Bullets.Add(bullet);

            IBulletMovementStrategy homingMoveStrategy = new HomingBuletStrategy();
            IBulletMovementStrategy straightMoveStrategy = new StraightTravelBulletStrategy();

            var straightMoveCommand = straightMoveStrategy.CreateMoveCommand(bullet);
            var homingMoveCommand = homingMoveStrategy.CreateMoveCommand(bullet);

            Assert.That(() => (straightMoveCommand.XDiff != homingMoveCommand.XDiff || straightMoveCommand.YDiff != homingMoveCommand.YDiff));
        }

        [Test]
        public void BuilderPattern()
        {
            var defaultGameState = new GameState();
            var builder = new GameStateBuilder();
            builder.AddPlayer();
            builder.AddGameMap();
            var gameState = builder.GetGameState();

            Assert.That(defaultGameState, Does.Not.EqualTo(gameState));
            Assert.That(defaultGameState.Map, Is.Null);
            Assert.That(gameState.Map, Is.Not.Null);
        }

        [Test]
        public void AdapterPattern()
        {
            var renderingEngineMock = new Mock<RenderingEngine>();
            renderingEngineMock.Setup(x => x.RenderGameState());
            ILoopAdapter adapter = new RenderingEngineAdapter(renderingEngineMock.Object);

            var gameLoopEngine = new GameLoopEngine();
            gameLoopEngine.RegisterComponent(adapter);
            gameLoopEngine.Loop();

            renderingEngineMock.Verify(x => x.RenderGameState(), Times.Once);
        }

        [Test]
        public void PrototypePattern()
        {
            var wall = new Wall(0,0,0,0,10,10);
            var clonedWall = wall.Clone();

            //Id is a generated Guid property inside every GameObject
            Assert.That(clonedWall.Id, Is.EqualTo(wall.Id));
        }

        [Test]
        public void CommandPattern()
        {
            var player = new Player();
            var xBefore = player.State.X;
            var yBefore = player.State.Y;
            Command command = new MoveCommand(player, 10, 15);

            command.Execute();

            //Id is a generated Guid property inside every GameObject
            Assert.That(player.State.X, Is.Not.EqualTo(xBefore));
            Assert.That(player.State.Y, Is.Not.EqualTo(yBefore));
        }
    }
}
