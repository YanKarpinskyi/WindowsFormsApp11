namespace WindowsFormsApp1
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
            this.btnSelectDist = new System.Windows.Forms.Button();
            this.btnSelectInstall = new System.Windows.Forms.Button();
            this.btnInstall = new System.Windows.Forms.Button();
            this.btnUninstall = new System.Windows.Forms.Button();
            this.lblDistPath = new System.Windows.Forms.Label();
            this.lblInstallPath = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnSelectDist
            // 
            this.btnSelectDist.Location = new System.Drawing.Point(12, 12);
            this.btnSelectDist.Name = "btnSelectDist";
            this.btnSelectDist.Size = new System.Drawing.Size(150, 30);
            this.btnSelectDist.TabIndex = 0;
            this.btnSelectDist.Text = "Дистрибутив";
            this.btnSelectDist.UseVisualStyleBackColor = true;
            this.btnSelectDist.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnSelectInstall
            // 
            this.btnSelectInstall.Location = new System.Drawing.Point(168, 12);
            this.btnSelectInstall.Name = "btnSelectInstall";
            this.btnSelectInstall.Size = new System.Drawing.Size(150, 30);
            this.btnSelectInstall.TabIndex = 1;
            this.btnSelectInstall.Text = "Обрати папку";
            this.btnSelectInstall.UseVisualStyleBackColor = true;
            this.btnSelectInstall.Click += new System.EventHandler(this.button2_Click);
            // 
            // btnInstall
            // 
            this.btnInstall.Location = new System.Drawing.Point(12, 48);
            this.btnInstall.Name = "btnInstall";
            this.btnInstall.Size = new System.Drawing.Size(150, 30);
            this.btnInstall.TabIndex = 2;
            this.btnInstall.Text = "Установити";
            this.btnInstall.UseVisualStyleBackColor = true;
            this.btnInstall.Click += new System.EventHandler(this.button3_Click);
            // 
            // btnUninstall
            // 
            this.btnUninstall.Location = new System.Drawing.Point(168, 48);
            this.btnUninstall.Name = "btnUninstall";
            this.btnUninstall.Size = new System.Drawing.Size(150, 30);
            this.btnUninstall.TabIndex = 3;
            this.btnUninstall.Text = "Видалити";
            this.btnUninstall.UseVisualStyleBackColor = true;
            this.btnUninstall.Click += new System.EventHandler(this.button4_Click);
            // 
            // lblDistPath
            // 
            this.lblDistPath.AutoSize = true;
            this.lblDistPath.Location = new System.Drawing.Point(12, 85);
            this.lblDistPath.Name = "lblDistPath";
            this.lblDistPath.Size = new System.Drawing.Size(0, 16);
            this.lblDistPath.TabIndex = 4;
            // 
            // lblInstallPath
            // 
            this.lblInstallPath.AutoSize = true;
            this.lblInstallPath.Location = new System.Drawing.Point(12, 105);
            this.lblInstallPath.Name = "lblInstallPath";
            this.lblInstallPath.Size = new System.Drawing.Size(0, 16);
            this.lblInstallPath.TabIndex = 5;
            // 
            // InstallForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(330, 130);
            this.Controls.Add(this.lblInstallPath);
            this.Controls.Add(this.lblDistPath);
            this.Controls.Add(this.btnUninstall);
            this.Controls.Add(this.btnInstall);
            this.Controls.Add(this.btnSelectInstall);
            this.Controls.Add(this.btnSelectDist);
            this.Name = "InstallForm";
            this.Text = "Установник";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Button btnSelectDist;
        private System.Windows.Forms.Button btnSelectInstall;
        private System.Windows.Forms.Button btnInstall;
        private System.Windows.Forms.Button btnUninstall;
        private System.Windows.Forms.Label lblDistPath;
        private System.Windows.Forms.Label lblInstallPath;
    }
}