using System.Collections.Generic;
using System.Threading;
using Chaser.Game.Commands;
using SFML.System;

namespace Chaser.Game
{
    public class Chaser : GameObject, ISmart
    {
        private readonly Clock _timer = new Clock();

        public Chaser()
        {
            X = 500;
            Y = 400;
            Width = 100;
            Height = 100;
        }

        public List<Command> ReturnNextMove()
        {
            var commands = new List<Command> {GenerateMoveCommand()};

            if (_timer.ElapsedTime.AsSeconds() > 2)
            {
                _timer.Restart();
                commands.Add(new ShootBulletCommand());
            }

            return commands;
        }

        private MoveCommand GenerateMoveCommand()
        {
            var playerX = GameStateSingleton.Instance.State.Player.X;
            var playerY = GameStateSingleton.Instance.State.Player.Y;

            var x = GameStateSingleton.Instance.State.Chaser.X;
            var y = GameStateSingleton.Instance.State.Chaser.Y;

            int deltaX = 0, deltaY = 0;

            var distance = 200;

            if (x - playerX > distance || y - playerY > distance
                || playerX - x > distance || playerY - y > distance)
            {
                if (playerX > x)
                {
                    deltaX = 1;
                }
                if (playerX < x)
                {
                    deltaX = -1;
                }
                if (playerY > y)
                {
                    deltaY = 1;
                }
                if (playerY < y)
                {
                    deltaY = -1;
                }
            }

            var command = new MoveCommand(this, deltaX, deltaY);
            return command;
        }
    }
}
