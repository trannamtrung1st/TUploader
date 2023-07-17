namespace TUploader.MainApp
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.fileSystemWatcher = new System.IO.FileSystemWatcher();
            this.txtWatchingPath = new System.Windows.Forms.TextBox();
            this.txtResult = new System.Windows.Forms.TextBox();
            this.txtDriveFolder = new System.Windows.Forms.TextBox();
            this.lblWatchingFolder = new System.Windows.Forms.Label();
            this.lblDriveFolder = new System.Windows.Forms.Label();
            this.lblUploadedFile = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.lblEmail = new System.Windows.Forms.Label();
            this.btnLogin = new System.Windows.Forms.Button();
            this.lblDescription = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher)).BeginInit();
            this.SuspendLayout();
            // 
            // fileSystemWatcher
            // 
            this.fileSystemWatcher.EnableRaisingEvents = true;
            this.fileSystemWatcher.IncludeSubdirectories = true;
            this.fileSystemWatcher.NotifyFilter = ((System.IO.NotifyFilters)(((System.IO.NotifyFilters.FileName | System.IO.NotifyFilters.Size) 
            | System.IO.NotifyFilters.LastWrite)));
            this.fileSystemWatcher.SynchronizingObject = this;
            this.fileSystemWatcher.Changed += new System.IO.FileSystemEventHandler(this.fileSystemWatcher_Changed);
            this.fileSystemWatcher.Created += new System.IO.FileSystemEventHandler(this.fileSystemWatcher_Changed);
            // 
            // txtWatchingPath
            // 
            this.txtWatchingPath.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtWatchingPath.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtWatchingPath.Location = new System.Drawing.Point(0, 16);
            this.txtWatchingPath.Name = "txtWatchingPath";
            this.txtWatchingPath.Size = new System.Drawing.Size(797, 41);
            this.txtWatchingPath.TabIndex = 0;
            this.txtWatchingPath.TextChanged += new System.EventHandler(this.txtWatchingPath_TextChanged);
            // 
            // txtResult
            // 
            this.txtResult.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtResult.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtResult.Location = new System.Drawing.Point(0, 130);
            this.txtResult.Name = "txtResult";
            this.txtResult.ReadOnly = true;
            this.txtResult.Size = new System.Drawing.Size(797, 41);
            this.txtResult.TabIndex = 2;
            // 
            // txtDriveFolder
            // 
            this.txtDriveFolder.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtDriveFolder.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDriveFolder.Location = new System.Drawing.Point(0, 73);
            this.txtDriveFolder.Name = "txtDriveFolder";
            this.txtDriveFolder.Size = new System.Drawing.Size(797, 41);
            this.txtDriveFolder.TabIndex = 1;
            this.txtDriveFolder.TextChanged += new System.EventHandler(this.txtDriveFolder_TextChanged);
            // 
            // lblWatchingFolder
            // 
            this.lblWatchingFolder.AutoSize = true;
            this.lblWatchingFolder.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblWatchingFolder.Location = new System.Drawing.Point(0, 0);
            this.lblWatchingFolder.Name = "lblWatchingFolder";
            this.lblWatchingFolder.Size = new System.Drawing.Size(100, 16);
            this.lblWatchingFolder.TabIndex = 3;
            this.lblWatchingFolder.Text = "Watching folder";
            // 
            // lblDriveFolder
            // 
            this.lblDriveFolder.AutoSize = true;
            this.lblDriveFolder.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblDriveFolder.Location = new System.Drawing.Point(0, 57);
            this.lblDriveFolder.Name = "lblDriveFolder";
            this.lblDriveFolder.Size = new System.Drawing.Size(76, 16);
            this.lblDriveFolder.TabIndex = 4;
            this.lblDriveFolder.Text = "Drive folder";
            // 
            // lblUploadedFile
            // 
            this.lblUploadedFile.AutoSize = true;
            this.lblUploadedFile.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblUploadedFile.Location = new System.Drawing.Point(0, 114);
            this.lblUploadedFile.Name = "lblUploadedFile";
            this.lblUploadedFile.Size = new System.Drawing.Size(88, 16);
            this.lblUploadedFile.TabIndex = 5;
            this.lblUploadedFile.Text = "Uploaded file";
            // 
            // txtEmail
            // 
            this.txtEmail.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtEmail.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEmail.Location = new System.Drawing.Point(0, 187);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(797, 41);
            this.txtEmail.TabIndex = 6;
            this.txtEmail.TextChanged += new System.EventHandler(this.txtEmail_TextChanged);
            // 
            // lblEmail
            // 
            this.lblEmail.AutoSize = true;
            this.lblEmail.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblEmail.Location = new System.Drawing.Point(0, 171);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(41, 16);
            this.lblEmail.TabIndex = 7;
            this.lblEmail.Text = "Email";
            // 
            // btnLogin
            // 
            this.btnLogin.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnLogin.Location = new System.Drawing.Point(0, 228);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(797, 32);
            this.btnLogin.TabIndex = 8;
            this.btnLogin.Text = "Login";
            this.btnLogin.UseVisualStyleBackColor = true;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblDescription.Location = new System.Drawing.Point(0, 260);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Padding = new System.Windows.Forms.Padding(10);
            this.lblDescription.Size = new System.Drawing.Size(786, 84);
            this.lblDescription.TabIndex = 9;
            this.lblDescription.Text = resources.GetString("lblDescription.Text");
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(797, 450);
            this.Controls.Add(this.lblDescription);
            this.Controls.Add(this.btnLogin);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.lblEmail);
            this.Controls.Add(this.txtResult);
            this.Controls.Add(this.lblUploadedFile);
            this.Controls.Add(this.txtDriveFolder);
            this.Controls.Add(this.lblDriveFolder);
            this.Controls.Add(this.txtWatchingPath);
            this.Controls.Add(this.lblWatchingFolder);
            this.Name = "MainForm";
            this.Text = "TUploader";
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.IO.FileSystemWatcher fileSystemWatcher;
        private System.Windows.Forms.TextBox txtWatchingPath;
        private System.Windows.Forms.TextBox txtResult;
        private System.Windows.Forms.TextBox txtDriveFolder;
        private System.Windows.Forms.Label lblWatchingFolder;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.Label lblUploadedFile;
        private System.Windows.Forms.Label lblDriveFolder;
        private System.Windows.Forms.Label lblDescription;
    }
}

