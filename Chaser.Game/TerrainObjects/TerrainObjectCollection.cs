using System;
using System.Collections;
namespace Chaser.Game.TerrainObjects
{
    public class TerrainObjectCollection : ITerrainObjectCollection
    {
        private ArrayList _items = new ArrayList();

        public Iterator CreateIterator()
        {
            return new Iterator(this);
        }
        
        public int Count
        {
            get { return _items.Count; }
        }
        
        public object this[int index]
        {
            get { return _items[index]; }
            set { _items.Add(value); }
        }
    }
}
