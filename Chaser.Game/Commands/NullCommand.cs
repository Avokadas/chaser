using System;
using System.Linq;

namespace Chaser.Game.Commands
{
    public class NullCommand : Command
    {
        public override void Execute()
        {
            //Does nothing
        }
    }
    public class BulletDisintegrateCommand : Command
    {
        private readonly Guid _id;

        public BulletDisintegrateCommand(Guid id)
        {
            _id = id;
        }

        public override void Execute()
        {
            //Does nothing
            GameStateSingleton.Instance.State.Bullets = GameStateSingleton.Instance.State.Bullets.Where(x => x.Id != _id).ToList();
        }
    }


}