using IniParser;
using IniParser.Model;
using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace ScreenSnapUI
{
    public partial class MainForm : Form
    {
        private const string iniPath = "Config.ini";
        private static readonly FileIniDataParser iniParser = new FileIniDataParser();
        private static IniData iniData;
        private const string snapBinPath = "ScreenSnap.exe";
        private static readonly SnapProcess snapProcess = new SnapProcess(snapBinPath);

        public MainForm()
        {
            CreateIni();
            InitializeComponent();
        }

        private static void CreateIni()
        {
            if (!File.Exists(iniPath))
            {
                iniData = new IniData();
                iniData["Config"]["SavePath"] = "images";
                iniParser.WriteFile(iniPath, iniData);
                Directory.CreateDirectory("images");
            }
            else
            {
                iniData = iniParser.ReadFile(iniPath);
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            SaveFolderBox.Text = iniData["Config"]["SavePath"].ToString();
            if (snapProcess.Running())
            {
                ToggleBackgroundProgramButton.Text = "Stop background program";
            }
        }

        private void SaveFolderButton_Click(object sender, EventArgs e)
        {
            DialogResult result = SaveFolderDialog.ShowDialog();

            if (result == DialogResult.OK)
            {
                SaveFolderBox.Text = SaveFolderDialog.SelectedPath;
                iniData["Config"]["SavePath"] = SaveFolderDialog.SelectedPath;
                iniParser.WriteFile(iniPath, iniData);
                Invalidate();
            }
        }

        private void SaveFolderBox_Changed(object sender, EventArgs e)
        {
            iniData["Config"]["SavePath"] = SaveFolderBox.Text;
            iniParser.WriteFile(iniPath, iniData);
        }

        private void OpenFolderButton_Click(object sender, EventArgs e)
        {
            try
            {
                Process.Start(SaveFolderBox.Text);
            }
            catch
            {
                MessageBox.Show("The specified folder does not exist", "Invalid Folder", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ClearFolderButton_Click(object sender, EventArgs e)
        {
            DialogResult clear = MessageBox.Show("Are you sure you would like to delete the folder contents?", "Clear Folder Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (clear == DialogResult.Yes)
            {
                System.IO.DirectoryInfo di = new DirectoryInfo(SaveFolderBox.Text);
                if (di.Exists)
                {
                    foreach (FileInfo file in di.EnumerateFiles())
                    {
                        file.Delete();
                    }
                    foreach (DirectoryInfo dir in di.EnumerateDirectories())
                    {
                        dir.Delete(true);
                    }
                }
            }
        }

        private void ToggleBackgroundProgramButton_Click(object sender, EventArgs e)
        {
            if (snapProcess.Running())
            {
                snapProcess.Stop();
                ToggleBackgroundProgramButton.Text = "Start background program";
            }
            else
            {
                snapProcess.Start();
                ToggleBackgroundProgramButton.Text = "Stop background program";
            }
        }
    }
}
