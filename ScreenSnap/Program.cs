using IniParser;
using IniParser.Model;
using System;
using System.IO;
using System.Windows.Forms;

namespace ScreenSnap
{
    class Program
    {
        private static KeyboardHook hook;
        private static string savePath = "images";
        private const string timestampFormat = "yyyy.MM.dd-HH.mm.ss";
        private const string imgExt = ".png";
        private const string iniPath = "Config.ini";
        private static readonly FileIniDataParser iniParser = new FileIniDataParser();

        [STAThread]
        static void Main()
        {
            Startup.RegisterStartup("ScreenSnap");
            CreateIni();
            UpdateSavePath();

            hook = new KeyboardHook(true);
            hook.KeyUp += OnKeyUp;

            Application.Run();
        }

        private static void CreateIni()
        {
            if (!File.Exists(iniPath))
            {
                IniData data = new IniData();
                data["Config"]["SavePath"] = "images";
                iniParser.WriteFile(iniPath, data);
            }
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
            UpdateSavePath();
            string timestamp = TimestampString();
            string[] paths = { savePath, timestamp };
            string path = Path.Combine(paths);

            string fullpath = path + "-0" + imgExt;
            for (int fileID = 0; File.Exists(fullpath); fileID++)
            {
                fullpath = path + "-" + fileID.ToString() + imgExt;
            }
            return fullpath;
        }

        private static void UpdateSavePath()
        {
            IniData data = iniParser.ReadFile(iniPath);
            savePath = data["Config"]["SavePath"].ToString();
            Directory.CreateDirectory(savePath);
        }

        private static string TimestampString()
        {
            return DateTime.UtcNow.ToString(timestampFormat);
        }
    }
}
