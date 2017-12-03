using System;
using System.Collections.Generic;
using Chaser.Game.Commands;
using Chaser.Game.Strategies;
using SFML.System;

namespace Chaser.Game
{
    public class Bullet : GameObject, IBullet
    {
        public readonly IBulletMovementStrategy Strategy;
        private readonly Clock _timer = new Clock();
        public Directions Direction { get; }
        private CloseBulletHandler closeBulletHandler;

        public Bullet(Directions direction, 
            IBulletMovementStrategy strategy, 
            CloseBulletHandler closeBulletHandler)
        {
            Strategy = strategy;
            State.X = GameStateSingleton.Instance.State.Chaser.State.X;
            State.Y = GameStateSingleton.Instance.State.Chaser.State.Y;
            State.Width = 30;
            State.Height = 30;
            Direction = direction;
            State.IsCollidable = true;
            this.closeBulletHandler = closeBulletHandler;
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

            var nextCommand = Strategy.CreateMoveCommand(this);

            if (nextCommand != null)
            {
                if (Math.Abs(State.X - GameStateSingleton.Instance.State.Player.State.X) < 10 &&
                    Math.Abs(State.Y - GameStateSingleton.Instance.State.Player.State.Y) < 10)
                {
                    closeBulletHandler.HandleBullet(Strategy);
                    return new List<Command>
                    {
                        new BulletDisintegrateCommand(Id)
                    };
                }

                return new List<Command>
                {
                    Strategy.CreateMoveCommand(this)
                };
            }
            //Return a new move command which is build based on Direction properties
            return new List<Command>();
        }

    }
}