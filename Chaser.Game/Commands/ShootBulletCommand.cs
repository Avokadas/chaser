using System;
using Chaser.Game.Strategies;

namespace Chaser.Game.Commands
{
    public class ShootBulletCommand : Command
    {
        //TODO: Add bullet direction here

        public Directions Direction { get; set; }

        public ShootBulletCommand(Directions direction) {
            Direction = direction;
        }

        public override void Execute()
        {
            var random = new Random();
            if (random.Next(0, 4) == 0)
            {
                GameStateSingleton.Instance.State.Bullets.Add(new Bullet(Direction, new HomingBuletStrategy()));
            }

            GameStateSingleton.Instance.State.Bullets.Add(new Bullet(Direction, new StraightTravelBulletStrategy()));
        }
    }
}