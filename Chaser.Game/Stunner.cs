using System;
using System.Threading;

namespace Chaser.Game
{
    public class Stunner : GameObjectVisitor
    {
        public override void VisitGameObject(GameObject obj)
        {
            obj.State.Stunned = true;
            obj.Timer = new Timer(state =>
            {
                obj.State.Stunned = false;
                Console.WriteLine("Unstunned player");
            }, null, 10000, 0);
        }
    }
}