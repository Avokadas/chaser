namespace Chaser.Game.TerrainObjects
{
    public class TerrainObject : GameObject
    {
        public TerrainObject(int x, int y, int xpic, int ypic, int width, int height) : 
            base(x, y, xpic, ypic, width, height, true)
        {

        }

        public TerrainObject()
        {

        }
    }
}