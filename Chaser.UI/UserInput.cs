using System.Data;
using System.Diagnostics;
using SFML.Graphics;
using SFML.Window;

namespace Chaser.UI
{
    public class UserInput
    {
        public bool Up { get; set; }
        public bool Down { get; set; }
        public bool Left { get; set; }
        public bool Right { get; set; }
        public bool Close { get; set; }
        private RenderWindow window { get; set; }


        public UserInput (RenderWindow window)
        {
            this.window = window;
        }

        public void KeyReleased(object sender, KeyEventArgs e)
        {
            if (e.Code == Keyboard.Key.W)
            {
                Up = false;
            }
            if (e.Code == Keyboard.Key.A)
            {
                Left = false;
            }
            if (e.Code == Keyboard.Key.S)
            {
                Down = false;
            }
            if (e.Code == Keyboard.Key.D)
            {
                Right = false;
            }
        }

        public void KeyPressed(object sender, KeyEventArgs e)
        {
            if (e.Code == Keyboard.Key.Escape)
            {
                Close = true;
            }
            if (e.Code == Keyboard.Key.W)
            {
                Up = true;
            }
            if (e.Code == Keyboard.Key.A)
            {
                Left = true;
            }
            if (e.Code == Keyboard.Key.S)
            {
                Down = true;
            }
            if (e.Code == Keyboard.Key.D)
            {
               Right = true;
            }
        }
    }
}