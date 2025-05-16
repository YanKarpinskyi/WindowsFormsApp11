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

        // Button1: Select Source Folder
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

        // Button2: Select Destination Folder
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

        // Button3: Install
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
                // Copy files
                DirectoryCopy(sourceFolder, destFolder, true);

                // Define resource paths
                string imagePath = Path.Combine(destFolder, "Resources", "Images", "sample.jpg");
                string textPath = Path.Combine(destFolder, "Resources", "Text", "sample.txt");
                string tablePath = Path.Combine(destFolder, "Resources", "Tables", "sample.csv");

                // Create install.dat
                File.WriteAllText(Path.Combine(destFolder, "install.dat"),
                    $"Source: {sourceFolder}\nDestination: {destFolder}");

                // Create config.txt for the AppForm to use
                File.WriteAllText(Path.Combine(destFolder, "config.txt"),
                    $"{imagePath}\n{textPath}\n{tablePath}");

                // Write to registry
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

        // Button4: Uninstall
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

        // Helper method to copy directory
        private static void DirectoryCopy(string sourceDir, string destDir, bool copySubDirs)
        {
            DirectoryInfo dir = new DirectoryInfo(sourceDir);
            DirectoryInfo[] dirs = dir.GetDirectories();

            // Create destination directory if it doesn't exist
            if (!Directory.Exists(destDir))
            {
                Directory.CreateDirectory(destDir);
            }

            // Copy files
            foreach (FileInfo file in dir.GetFiles())
            {
                string targetPath = Path.Combine(destDir, file.Name);
                file.CopyTo(targetPath, true);
            }

            // Copy subdirectories
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