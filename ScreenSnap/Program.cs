using System;
using System.IO;
using System.Windows.Forms;

namespace ScreenSnap
{
    class Program
    {
        private static KeyboardHook hook;
        private static string saveDir = "images";
        private const string timestampFormat = "yyyy.MM.dd-HH.mm.ss";
        private const string imgExt = ".png";

        [STAThread]
        static void Main()
        {
            Directory.CreateDirectory(saveDir);

            hook = new KeyboardHook(true);
            hook.KeyUp += OnKeyUp;

            Application.Run();
        }

        private static void OnKeyUp(Keys key, bool Shift, bool Ctrl, bool Alt)
        {
            if (key == Keys.PrintScreen && Clipboard.ContainsImage())
            {
                System.Drawing.Image img = Clipboard.GetImage();
                try
                {
                    if (img != null)
                    {
                        string path = NewImagePath();
                        img.Save(path);
                        Console.WriteLine(path);
                    }
                }
                catch (Exception)
                {
#if DEBUG
                    throw;
#endif
                }
            }
        }

        private static string NewImagePath()
        {
            string timestamp = TimestampString();
            string[] paths = { saveDir, timestamp };
            string path = Path.Combine(paths);

            string fullpath = path + "-0" + imgExt;
            for (int fileID = 0; File.Exists(fullpath); fileID++)
            {
                fullpath = path + "-" + fileID.ToString() + imgExt;
            }
            return fullpath;
        }

        private static string TimestampString()
        {
            return DateTime.UtcNow.ToString(timestampFormat);
        }
    }
}
