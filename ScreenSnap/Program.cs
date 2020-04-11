﻿using System;
using System.Windows.Forms;

namespace ScreenSnap
{
    class Program
    {
        private static bool prtscrPressed = false;
        private static KeyboardHook hook;

        static void Main(string[] args)
        {
            hook = new KeyboardHook(true);
            hook.KeyDown += OnKeyDown;
            hook.KeyUp += OnKeyUp;
            Application.Run();
        }

        private static void OnKeyDown(Keys key, bool shift, bool ctrl, bool alt)
        {
            if (key == Keys.PrintScreen && !prtscrPressed)
            {
                prtscrPressed = true;
                if (!alt)
                    Console.WriteLine("PrintScreen pressed");
                else
                    Console.WriteLine("Alt-PrintScreen pressed");
            }
        }

        private static void OnKeyUp(Keys key, bool shift, bool ctrl, bool alt)
        {
            if (key == Keys.PrintScreen && prtscrPressed)
            {
                prtscrPressed = false;
                if (!alt)
                    Console.WriteLine("PrintScreen released");
                else
                    Console.WriteLine("Alt-PrintScreen released");
            }
        }
    }
}
