namespace Chaser.Game
{
    public abstract class GameObjectVisitor
    {
        public abstract void VisitGameObject(GameObject obj);
    }

    public class Stunner : GameObjectVisitor
    {
        public override void VisitGameObject(GameObject obj)
        {
            obj.State.Stunned = true;
        }
    }
}
