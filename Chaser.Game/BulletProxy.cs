using System.Collections.Generic;
using System.Linq;
using Chaser.Game.Commands;

namespace Chaser.Game
{
    public class BulletProxy : GameObject, IBullet
    {
        private Bullet Bullet { get; set; }

        public BulletProxy(Bullet bullet)
        {
            this.Bullet = bullet;
        }

        public GameObjectState State
        {
            get => Bullet.State;
            set => Bullet.State = value;
        }

        public Directions Direction
        {
            get => Bullet.Direction;
        }

        public List<Command> ReturnNextMove()
        {
            var nextMove = Bullet.ReturnNextMove();

            if(nextMove.Count == 0 || nextMove[0] is BulletDisintegrateCommand)
            {
                GameStateSingleton.Instance.State.Bullets =
                    GameStateSingleton.Instance.State.Bullets.Where(x => x.Id != Id).ToList();
                GameStateSingleton.Instance.State.Score += 5;
            }

            return nextMove;
        }
    }
}