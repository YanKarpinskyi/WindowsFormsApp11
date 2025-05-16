using Microsoft.Win32;
using System;
using System.IO;
using System.Windows.Forms;

namespace WindowsFormsApp11
{
    public partial class Form1 : Form
    {
        private string imagePath, textPath, tablePath;
        private const string REG_PATH = @"Software\MyApp";

        public Form1()
        {
            InitializeComponent();
            LoadPaths();
        }

        // Load paths from config.txt or registry as fallback
        private void LoadPaths()
        {
            try
            {
                // First try to read from config.txt in the application directory
                string configPath = Path.Combine(Application.StartupPath, "config.txt");
                if (File.Exists(configPath))
                {
                    string[] lines = File.ReadAllLines(configPath);
                    if (lines.Length >= 3)
                    {
                        imagePath = lines[0];
                        textPath = lines[1];
                        tablePath = lines[2];
                        return; // Successfully loaded from config.txt
                    }
                }

                // If config.txt doesn't exist or is invalid, try reading from install.dat
                string installDatPath = Path.Combine(Application.StartupPath, "install.dat");
                if (File.Exists(installDatPath))
                {
                    string[] lines = File.ReadAllLines(installDatPath);
                    string destPath = null;

                    foreach (string line in lines)
                    {
                        if (line.StartsWith("Destination: "))
                        {
                            destPath = line.Substring("Destination: ".Length);
                            break;
                        }
                    }

                    if (!string.IsNullOrEmpty(destPath))
                    {
                        // Build paths based on destination directory
                        imagePath = Path.Combine(destPath, "Resources", "Images", "sample.jpg");
                        textPath = Path.Combine(destPath, "Resources", "Text", "sample.txt");
                        tablePath = Path.Combine(destPath, "Resources", "Tables", "sample.csv");
                        return; // Successfully generated paths from install.dat
                    }
                }

                // As last resort, try reading from registry
                using (RegistryKey key = Registry.CurrentUser.OpenSubKey(REG_PATH))
                {
                    if (key != null)
                    {
                        imagePath = key.GetValue("ImagePath")?.ToString();
                        textPath = key.GetValue("TextPath")?.ToString();
                        tablePath = key.GetValue("TablePath")?.ToString();
                    }
                    else
                    {
                        MessageBox.Show("Application paths could not be found. Please reinstall the application.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading application paths: " + ex.Message);
            }
        }

        // Button1: Load Image
        private void btnLoadImage_Click(object sender, EventArgs e)
        {
            try
            {
                if (String.IsNullOrEmpty(imagePath) || !File.Exists(imagePath))
                {
                    MessageBox.Show("Image file not found: " + imagePath);
                    return;
                }

                pictureBox1.Image = System.Drawing.Image.FromFile(imagePath);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading image: " + ex.Message);
            }
        }

        // Button2: Load Text
        private void btnLoadText_Click(object sender, EventArgs e)
        {
            try
            {
                if (String.IsNullOrEmpty(textPath) || !File.Exists(textPath))
                {
                    MessageBox.Show("Text file not found: " + textPath);
                    return;
                }

                textBox1.Text = File.ReadAllText(textPath);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading text: " + ex.Message);
            }
        }

        // Button3: Load Table
        private void btnLoadTable_Click(object sender, EventArgs e)
        {
            try
            {
                if (String.IsNullOrEmpty(tablePath) || !File.Exists(tablePath))
                {
                    MessageBox.Show("Table file not found: " + tablePath);
                    return;
                }

                string[] lines = File.ReadAllLines(tablePath);
                dataGridView1.RowCount = lines.Length;

                for (int i = 0; i < lines.Length; i++)
                {
                    string[] cells = lines[i].Split(',');
                    dataGridView1.ColumnCount = Math.Max(dataGridView1.ColumnCount, cells.Length);

                    for (int j = 0; j < cells.Length; j++)
                    {
                        dataGridView1[j, i].Value = cells[j];
                    }
                }

                if (lines.Length > 1)
                {
                    dataGridView1.Rows[0].DefaultCellStyle.Font = new System.Drawing.Font(dataGridView1.Font, System.Drawing.FontStyle.Bold);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading table: " + ex.Message);
            }
        }
    }
}