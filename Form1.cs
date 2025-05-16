using System;
using System.IO;
using System.Windows.Forms;

namespace WindowsFormsApp11
{
    public partial class Form1 : Form
    {
        private string imagePath, textPath, tablePath;

        public Form1()
        {
            InitializeComponent();
            LoadConfig();
        }

        // Load paths from config.txt
        private void LoadConfig()
        {
            try
            {
                string[] lines = File.ReadAllLines("config.txt");
                if (lines.Length >= 3)
                {
                    imagePath = lines[0];
                    textPath = lines[1];
                    tablePath = lines[2];
                }
                else
                {
                    MessageBox.Show("Invalid config.txt format.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading config.txt: " + ex.Message);
            }
        }

        // Button1: Load Image
        private void btnLoadImage_Click(object sender, EventArgs e)
        {
            try
            {
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