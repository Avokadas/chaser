using System.Collections.Generic;
using System.Threading;
using Chaser.Game.Commands;
using SFML.System;

namespace Chaser.Game
{
    public class Chaser : GameObject, ISmart
    {
        private Clock _timer = new Clock();

        public Chaser()
        {
            X = 500;
            Y = 400;
            Width = 100;
            Height = 100;
        }

        public List<Command> ReturnNextMove()
        {
            var commands = new List<Command>();

            commands.Add(GenerateMoveCommand());

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

            var distance = 200;

            if (x - playerX > distance || y - playerY > distance
                || playerX - x > distance || playerY - y > distance)
            {
                if (playerX > x)
                {
                    x += 1;
                }
                if (playerX < x)
                {
                    x -= 1;
                }
                if (playerY > y)
                {
                    y += 1;
                }
                if (playerY < y)
                {
                    y -= 1;
                }
            }

            var command = new MoveCommand(this, x, y);
            return command;
        }
    }
}
