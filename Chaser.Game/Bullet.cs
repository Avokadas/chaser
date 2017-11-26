using System;
using System.Collections.Generic;
using Chaser.Game.Commands;
using Chaser.Game.Strategies;
using SFML.System;

namespace Chaser.Game
{
    public class Bullet : GameObject, IBullet
    {
        private readonly IBulletMovementStrategy _strategy;
        private readonly Clock _timer = new Clock();
        public Directions Direction { get; }

        public Bullet(Directions direction, IBulletMovementStrategy strategy)
        {
            _strategy = strategy;
            State.X = GameStateSingleton.Instance.State.Chaser.State.X;
            State.Y = GameStateSingleton.Instance.State.Chaser.State.Y;
            State.Width = 30;
            State.Height = 30;
            Direction = direction;
            State.IsCollidable = true;
        }

        public List<Command> ReturnNextMove()
        {
            if (_timer.ElapsedTime.AsSeconds() > 5)
            {
                _timer.Restart();
                return new List<Command>
                {
                    new BulletDisintegrateCommand(Id)
                };
            }

            var nextCommand = _strategy.CreateMoveCommand(this);

            if (nextCommand != null)
            {
                return new List<Command>
                {
                    _strategy.CreateMoveCommand(this)
                };
            }
            //Return a new move command which is build based on Direction properties
            return new List<Command>();
        }

    }
}