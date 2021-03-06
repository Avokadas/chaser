﻿namespace Chaser.Game
{
    public class GameObjectState
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int Xpic { get; set; }
        public int Ypic { get; set; }
        public int Health { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public bool IsCollidable { get; set; }
        public int Velocity { get; set; } = 1;
        public bool Stunned { get; set; }
    }
}