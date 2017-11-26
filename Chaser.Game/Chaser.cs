using System.Collections.Generic;
using Chaser.Game.Commands;
using SFML.System;
using System;

namespace Chaser.Game
{
    public abstract class Chaser : GameObject, ISmart
    {
        private readonly Clock _timer = new Clock();

        protected Chaser()
        {
            X = 500;
            Y = 400;
            Width = 100;
            Height = 100;
            _timer.Restart();
        }

        public List<Command> ReturnNextMove()
        {
            var commands = new List<Command> {GenerateMoveCommand()};
            if (_timer.ElapsedTime.AsSeconds() > 2)
            {
                _timer.Restart();

                var directions = Directions.GetValues(typeof(Directions));
                var randomDirection = directions.GetValue(new Random().Next(directions.Length));
                
                commands.Add(new ShootBulletCommand((Directions)randomDirection));
            }

            return commands;
        }

        protected abstract MoveCommand GenerateMoveCommand();
    }
}
