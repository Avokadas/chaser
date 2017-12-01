using System;
using Chaser.Game.TerrainObjects;

namespace Chaser.Game
{
    public class Iterator : IIterator
    {
        private TerrainObjectCollection _collection;
        private int _current = 0;
        private int _step = 1;
        
        public Iterator(TerrainObjectCollection collection)
        {
            this._collection = collection;
        }
        
        public TerrainObject First()
        {
            _current = 0;
            return _collection[_current] as TerrainObject;
        }
        
        public TerrainObject Next()
        {
            _current += _step;
            if (!IsDone)
                return _collection[_current] as TerrainObject;
            else
                return null;
        }
        
        public int Step
        {
            get { return _step; }
            set { _step = value; }
        }
        
        public TerrainObject CurrentItem
        {
            get { return _collection[_current] as TerrainObject; }
        }
        
        public bool IsDone
        {
            get { return _current >= _collection.Count; }
        }
    }
}
