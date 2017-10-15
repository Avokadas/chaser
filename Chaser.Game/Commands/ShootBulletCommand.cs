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
            GameStateSingleton.Instance.State.Bullets.Add(new Bullet(Direction));
        }
    }
}