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
            X = 500;
            Y = 400;
            Width = 100;
            Height = 100;
            _timer.Restart();
        }

        public List<Command> ReturnNextMove()
        {
            var commands = new List<Command> {GenerateMoveCommand()};
            MoveBullets();
            if (_timer.ElapsedTime.AsSeconds() > 2)
            {
                _timer.Restart();

                var directions = Directions.GetValues(typeof(Directions));
                var randomDirection = directions.GetValue(new Random().Next(directions.Length));
                
                commands.Add(new ShootBulletCommand((Directions)randomDirection));
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

        private static void MoveBullets()
        {
            foreach (var bullet in GameStateSingleton.Instance.State.Bullets)
            {
                var x = bullet.X;
                var y = bullet.Y;

                if (bullet.Direction == Directions.Left)
                {
                    x -= 1;
                }
                if (bullet.Direction == Directions.Right)
                {
                    x += 1;
                }
                if (bullet.Direction == Directions.Up)
                {
                    y += 1;
                }
                if (bullet.Direction == Directions.Down)
                {
                    y -= 1;
                }
                if (bullet.Direction == Directions.UpLeft)
                {
                    x -= 1;
                    y += 1;
                }
                if (bullet.Direction == Directions.UpRight)
                {
                    x += 1;
                    y += 1;
                }
                if (bullet.Direction == Directions.DownLeft)
                {
                    x -= 1;
                    y -= 1;
                }
                if (bullet.Direction == Directions.DownRight)
                {
                    x += 1;
                    y -= 1;
                }

                bullet.X = x;
                bullet.Y = y;
            }
        }
    }
}
