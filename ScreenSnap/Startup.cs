using Microsoft.Win32;
using System.Windows.Forms;

namespace ScreenSnap
{
    class Startup
    {
        private static readonly RegistryKey rkey = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);

        public static void RegisterStartup(string appName)
        {
            if (!Registered(appName))
            {
                rkey.SetValue(appName, Application.ExecutablePath);
            }
        }

        public static void UnregisterStartup(string appName)
        {
            if (Registered(appName))
            {
                rkey.DeleteValue(appName, false);
            }
        }

        public static bool Registered(string appName)
        {
            return rkey.GetValue(appName) != null;
        }
    }
}
