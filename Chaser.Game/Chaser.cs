using System.Collections.Generic;
using Chaser.Game.Commands;
using SFML.System;
using System;

namespace Chaser.Game
{
    public class Chaser : GameObject, ISmart
    {
        private readonly Clock _timer = new Clock();

        public Chaser()
        {
            State.X = 500;
            State.Y = 400;
            State.Width = 100;
            State.Height = 100;
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

        protected virtual MoveCommand GenerateMoveCommand()
        {
            throw new NotImplementedException();
        }
    }
}
