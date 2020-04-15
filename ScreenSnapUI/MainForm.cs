using IniParser;
using IniParser.Model;
using System;
using System.IO;
using System.Windows.Forms;

namespace ScreenSnapUI
{
    public partial class MainForm : Form
    {
        private static string savePath = "images";
        private const string iniPath = "Config.ini";
        private static readonly FileIniDataParser iniParser = new FileIniDataParser();
        private static IniData iniData = new IniData();

        public MainForm()
        {
            InitializeComponent();
            CreateIni();
            UpdateSavePath();
        }

        private static void CreateIni()
        {
            if (!File.Exists(iniPath))
            {
                iniData["Config"]["SavePath"] = "images";
                iniParser.WriteFile(iniPath, iniData);
            }
        }

        private static void UpdateSavePath()
        {
            iniData = iniParser.ReadFile(iniPath);
            savePath = iniData["Config"]["SavePath"].ToString();
            Directory.CreateDirectory(savePath);
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            SaveFolderBox.Text = iniData["Config"]["SavePath"].ToString();
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
    }
}
