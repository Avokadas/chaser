namespace Chaser.Game.Commands
{
    public class ShootBulletCommand : Command
    {
        //TODO: Add bullet direction here

        public override void Execute()
        {
            GameStateSingleton.Instance.State.Bullets.Add(new Bullet());
        }
    }
}