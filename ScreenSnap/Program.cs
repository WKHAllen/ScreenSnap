using System;
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

        private static void OnKeyDown(Keys key, bool Shift, bool Ctrl, bool Alt)
        {
            if (key == Keys.PrintScreen && !prtscrPressed)
            {
                prtscrPressed = true;
                if (!Alt)
                    Console.WriteLine("PrintScreen pressed");
                else
                    Console.WriteLine("Alt-PrintScreen pressed");
            }
        }

        private static void OnKeyUp(Keys key, bool Shift, bool Ctrl, bool Alt)
        {
            if (key == Keys.PrintScreen && prtscrPressed)
            {
                prtscrPressed = false;
                if (!Alt)
                    Console.WriteLine("PrintScreen released");
                else
                    Console.WriteLine("Alt-PrintScreen released");
            }
        }
    }
}
