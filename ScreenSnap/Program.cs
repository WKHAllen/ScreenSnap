using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ScreenSnap
{
    class Program
    {
        static void Main(string[] args)
        {
            InterceptKeys.Start(OnKeyPress);
        }

        static void OnKeyPress(int keycode)
        {
            Console.WriteLine(keycode);
            Console.WriteLine((Keys)keycode);
            Console.WriteLine((Keys)keycode == Keys.PrintScreen);
        }
    }
}
