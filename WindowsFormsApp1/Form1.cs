using Microsoft.Win32;
using System;
using System.IO;
using System.Windows.Forms;
using Microsoft.Win32;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        private string sourceFolder, destFolder;
        private const string REG_PATH = @"Software\MyApp";

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog fbd = new FolderBrowserDialog())
            {
                if (fbd.ShowDialog() == DialogResult.OK)
                {
                    sourceFolder = fbd.SelectedPath;
                    lblDistPath.Text = "Source: " + sourceFolder;
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog fbd = new FolderBrowserDialog())
            {
                if (fbd.ShowDialog() == DialogResult.OK)
                {
                    destFolder = fbd.SelectedPath;
                    lblInstallPath.Text = "Destination: " + destFolder;
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(sourceFolder) || string.IsNullOrEmpty(destFolder))
            {
                MessageBox.Show("Please select source and destination folders.");
                return;
            }

            using (RegistryKey key = Registry.CurrentUser.OpenSubKey(REG_PATH))
            {
                if (key != null)
                {
                    MessageBox.Show("Program is already installed.");
                    return;
                }
            }

            try
            {
                DirectoryCopy(sourceFolder, destFolder, true);

                string imagePath = Path.Combine(destFolder, "Resources", "Images", "sample.jpg");
                string textPath = Path.Combine(destFolder, "Resources", "Text", "sample.txt");
                string tablePath = Path.Combine(destFolder, "Resources", "Tables", "sample.csv");

                File.WriteAllText(Path.Combine(destFolder, "install.dat"),
                    $"Source: {sourceFolder}\nDestination: {destFolder}");

                File.WriteAllText(Path.Combine(destFolder, "config.txt"),
                    $"{imagePath}\n{textPath}\n{tablePath}");

                using (RegistryKey key = Registry.CurrentUser.CreateSubKey(REG_PATH))
                {
                    key.SetValue("InstallPath", destFolder);
                    key.SetValue("ImagePath", imagePath);
                    key.SetValue("TextPath", textPath);
                    key.SetValue("TablePath", tablePath);
                }

                MessageBox.Show("Installation completed successfully!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Installation failed: " + ex.Message);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            using (RegistryKey key = Registry.CurrentUser.OpenSubKey(REG_PATH))
            {
                if (key == null)
                {
                    MessageBox.Show("Program is not installed.");
                    return;
                }

                string installPath = key.GetValue("InstallPath")?.ToString();
                if (Directory.Exists(installPath))
                {
                    try
                    {
                        Directory.Delete(installPath, true);
                        Registry.CurrentUser.DeleteSubKey(REG_PATH);
                        MessageBox.Show("Program uninstalled successfully!");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Uninstallation failed: " + ex.Message);
                    }
                }
                else
                {
                    Registry.CurrentUser.DeleteSubKey(REG_PATH);
                    MessageBox.Show("Registry entries removed, but installation folder was not found.");
                }
            }
        }

        private static void DirectoryCopy(string sourceDir, string destDir, bool copySubDirs)
        {
            DirectoryInfo dir = new DirectoryInfo(sourceDir);
            DirectoryInfo[] dirs = dir.GetDirectories();

            if (!Directory.Exists(destDir))
            {
                Directory.CreateDirectory(destDir);
            }

            foreach (FileInfo file in dir.GetFiles())
            {
                string targetPath = Path.Combine(destDir, file.Name);
                file.CopyTo(targetPath, true);
            }

            if (copySubDirs)
            {
                foreach (DirectoryInfo subDir in dirs)
                {
                    string destSubDir = Path.Combine(destDir, subDir.Name);
                    DirectoryCopy(subDir.FullName, destSubDir, true);
                }
            }
        }
    }
}
