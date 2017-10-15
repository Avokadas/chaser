using System.Collections.Generic;
using Chaser.Game.Commands;
using Chaser.Game.Strategies;
using SFML.System;

namespace Chaser.Game
{
    public class Bullet : GameObject, ISmart
    {
        private readonly IBulletMovementStrategy _strategy;
        private readonly Clock _timer = new Clock();
        public Directions Direction { get; }

        public Bullet(Directions direction, IBulletMovementStrategy strategy)
        {
            _strategy = strategy;
            X = GameStateSingleton.Instance.State.Chaser.X;
            Y = GameStateSingleton.Instance.State.Chaser.Y;
            Width = 30;
            Height = 30;
            Direction = direction;
            IsCollidable = true;
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

            //Return a new move command which is build based on Direction properties
            return new List<Command>
            {
                _strategy.CreateMoveCommand(this)
            };
        }

    }
}