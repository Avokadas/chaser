﻿using System.Data;
using System.Diagnostics;
using SFML.Graphics;
using SFML.Window;

namespace Chaser.UI
{
    public class UserInputConfiguration
    {
        public bool Up { get; private set; }
        public bool Down { get; private set; }
        public bool Left { get; private set; }
        public bool Right { get; private set; }
        public bool Close { get; private set; }
        public bool End { get; private set; }
        public bool Save { get; private set; }
        public bool LoadSave { get; private set; }

        public void KeyReleased(object sender, KeyEventArgs e)
        {
            if (e.Code == Keyboard.Key.Q)
            {
                End = false;
            }
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
            if (e.Code == Keyboard.Key.J)
            {
                Save = false;
            }
            if (e.Code == Keyboard.Key.K)
            {
                LoadSave = false;
            }
        }

        public void KeyPressed(object sender, KeyEventArgs e)
        {
            if (e.Code == Keyboard.Key.Escape)
            {
                Close = true;
            }
            if (e.Code == Keyboard.Key.Q)
            {
                End = true;
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
            if (e.Code == Keyboard.Key.J)
            {
                Save = true;
            }
            if (e.Code == Keyboard.Key.K)
            {
                LoadSave = true;
            }
        }
    }
}