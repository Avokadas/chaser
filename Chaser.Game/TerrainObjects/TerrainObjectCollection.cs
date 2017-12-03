using System;
using System.Collections;
namespace Chaser.Game.TerrainObjects
{
    public class TerrainObjectCollection : ITerrainObjectCollection
    {
        public ArrayList Items = new ArrayList();

        public Iterator CreateIterator()
        {
            return new Iterator(this);
        }
        
        public int Count
        {
            get { return Items.Count; }
        }
        
        public object this[int index]
        {
            get { return (Items.Count > index)? Items[index] : null; }
            set { Items.Add(value); }
        }
    }
}
