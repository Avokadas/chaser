using System.Collections.Generic;
using System.Data;
using Chaser.Game.Commands;

namespace Chaser.Game
{
    public class Bullet : GameObject, ISmart
    {

        public Bullet()
        {
            X = GameStateSingleton.Instance.State.Chaser.X;
            Y = GameStateSingleton.Instance.State.Chaser.Y;
            Width = 30;
            Height = 30;
            IsCollidable = true;
        }

        public List<Command> ReturnNextMove()
        {
            //Return a new move command which is build based on Direction properties
            return new List<Command>
            {
                new NullCommand()
            };
        }
    }
}