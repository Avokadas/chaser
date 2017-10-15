using System.Collections.Generic;
using Chaser.Game.Commands;
using SFML.System;

namespace Chaser.Game
{
    public class Bullet : GameObject, ISmart
    {
        private readonly Clock _timer = new Clock();
        public Directions Direction { get; }

        public Bullet(Directions direction)
        {
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
            var command = CreateMoveCommand();
            return new List<Command>
            {
                command
            };
        }

        private MoveCommand CreateMoveCommand()
        {
            int x = 0;
            int y = 0;

            if (Direction == Directions.Left)
            {
                x = -1;
            }
            if (Direction == Directions.Right)
            {
                x = 1;
            }
            if (Direction == Directions.Up)
            {
                y = 1;
            }
            if (Direction == Directions.Down)
            {
                y = -1;
            }
            if (Direction == Directions.UpLeft)
            {
                x = -1;
                y = 1;
            }
            if (Direction == Directions.UpRight)
            {
                x = 1;
                y = 1;
            }
            if (Direction == Directions.DownLeft)
            {
                x = -1;
                y = -1;
            }
            if (Direction == Directions.DownRight)
            {
                x = 1;
                y = -1;
            }

            var command = new MoveCommand(this, x, y);
            return command;
        }
    }
}