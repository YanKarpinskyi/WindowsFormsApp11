namespace WindowsFormsApp11
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btnLoadImage = new System.Windows.Forms.Button();
            this.btnLoadText = new System.Windows.Forms.Button();
            this.btnLoadTable = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(12, -15);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(250, 250);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(269, 12);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(243, 200);
            this.textBox1.TabIndex = 1;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 218);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 75;
            this.dataGridView1.Size = new System.Drawing.Size(501, 150);
            this.dataGridView1.TabIndex = 2;
            // 
            // btnLoadImage
            // 
            this.btnLoadImage.Location = new System.Drawing.Point(12, 374);
            this.btnLoadImage.Name = "btnLoadImage";
            this.btnLoadImage.Size = new System.Drawing.Size(175, 30);
            this.btnLoadImage.TabIndex = 3;
            this.btnLoadImage.Text = "Завантажити малюнок";
            this.btnLoadImage.UseVisualStyleBackColor = true;
            this.btnLoadImage.Click += new System.EventHandler(this.btnLoadImage_Click);
            // 
            // btnLoadText
            // 
            this.btnLoadText.Location = new System.Drawing.Point(189, 374);
            this.btnLoadText.Name = "btnLoadText";
            this.btnLoadText.Size = new System.Drawing.Size(152, 30);
            this.btnLoadText.TabIndex = 4;
            this.btnLoadText.Text = "Завантажити текст";
            this.btnLoadText.UseVisualStyleBackColor = true;
            this.btnLoadText.Click += new System.EventHandler(this.btnLoadText_Click);
            // 
            // btnLoadTable
            // 
            this.btnLoadTable.Location = new System.Drawing.Point(344, 374);
            this.btnLoadTable.Name = "btnLoadTable";
            this.btnLoadTable.Size = new System.Drawing.Size(171, 30);
            this.btnLoadTable.TabIndex = 5;
            this.btnLoadTable.Text = "Завантажити таблицю";
            this.btnLoadTable.UseVisualStyleBackColor = true;
            this.btnLoadTable.Click += new System.EventHandler(this.btnLoadTable_Click);
            // 
            // AppForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(522, 416);
            this.Controls.Add(this.btnLoadTable);
            this.Controls.Add(this.btnLoadText);
            this.Controls.Add(this.btnLoadImage);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.pictureBox1);
            this.Name = "AppForm";
            this.Text = "Додаток";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnLoadImage;
        private System.Windows.Forms.Button btnLoadText;
        private System.Windows.Forms.Button btnLoadTable;
    }
}