using System.Diagnostics;
using System.IO;

namespace ScreenSnapUI
{
    class SnapProcess
    {
        private Process process;
        private readonly string binPath;
        private bool running;

        public SnapProcess(string snapBinPath)
        {
            binPath = snapBinPath;
            string processName = Path.GetFileNameWithoutExtension(binPath);
            Process[] processes = Process.GetProcessesByName(processName);

            if (processes.Length == 0)
            {
                running = false;
                process = null;
            }
            else
            {
                running = true;
                process = processes[0];
                
                for (int i = 1; i < processes.Length; i++)
                {
                    processes[i].Kill();
                }
            }
        }

        public void Start()
        {
            if (!running)
            {
                process = Process.Start(binPath);
                running = true;
            }
        }

        public void Stop()
        {
            if (running)
            {
                try
                {
                    process.Kill();
                }
                catch { }
                running = false;
            }
        }

        public bool Running()
        {
            return running;
        }
    }
}
