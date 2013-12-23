namespace Contacto.UI
{
    partial class Login
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Login));
            this.password = new System.Windows.Forms.TextBox();
            this.passwordLabel = new System.Windows.Forms.Label();
            this.usernameLabel = new System.Windows.Forms.Label();
            this.username = new System.Windows.Forms.TextBox();
            this.operation = new System.Windows.Forms.Label();
            this.operationLabel = new System.Windows.Forms.Label();
            this.version = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.closeTimer = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // password
            // 
            this.password.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.password.Location = new System.Drawing.Point(388, 261);
            this.password.MaxLength = 32;
            this.password.Name = "password";
            this.password.PasswordChar = '*';
            this.password.Size = new System.Drawing.Size(60, 20);
            this.password.TabIndex = 3;
            this.password.Text = "pumps";
            this.password.UseSystemPasswordChar = true;
            this.password.Visible = false;
            this.password.Enter += new System.EventHandler(this.password_Enter);
            // 
            // passwordLabel
            // 
            this.passwordLabel.AutoSize = true;
            this.passwordLabel.BackColor = System.Drawing.Color.Transparent;
            this.passwordLabel.ForeColor = System.Drawing.Color.White;
            this.passwordLabel.Location = new System.Drawing.Point(343, 263);
            this.passwordLabel.Name = "passwordLabel";
            this.passwordLabel.Size = new System.Drawing.Size(39, 13);
            this.passwordLabel.TabIndex = 2;
            this.passwordLabel.Text = "&Jelszó:";
            this.passwordLabel.Visible = false;
            // 
            // usernameLabel
            // 
            this.usernameLabel.AutoSize = true;
            this.usernameLabel.BackColor = System.Drawing.Color.Transparent;
            this.usernameLabel.ForeColor = System.Drawing.Color.White;
            this.usernameLabel.Location = new System.Drawing.Point(181, 263);
            this.usernameLabel.Name = "usernameLabel";
            this.usernameLabel.Size = new System.Drawing.Size(84, 13);
            this.usernameLabel.TabIndex = 0;
            this.usernameLabel.Text = "&Felhasználónév:";
            this.usernameLabel.Visible = false;
            // 
            // username
            // 
            this.username.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.username.Location = new System.Drawing.Point(271, 261);
            this.username.Name = "username";
            this.username.Size = new System.Drawing.Size(60, 20);
            this.username.TabIndex = 1;
            this.username.Text = "valasek";
            this.username.Visible = false;
            // 
            // operation
            // 
            this.operation.AutoSize = true;
            this.operation.BackColor = System.Drawing.Color.Transparent;
            this.operation.ForeColor = System.Drawing.Color.White;
            this.operation.Location = new System.Drawing.Point(64, 298);
            this.operation.Name = "operation";
            this.operation.Size = new System.Drawing.Size(14, 13);
            this.operation.TabIndex = 13;
            this.operation.Text = "#";
            // 
            // operationLabel
            // 
            this.operationLabel.AutoSize = true;
            this.operationLabel.BackColor = System.Drawing.Color.Transparent;
            this.operationLabel.ForeColor = System.Drawing.Color.White;
            this.operationLabel.Location = new System.Drawing.Point(10, 298);
            this.operationLabel.Name = "operationLabel";
            this.operationLabel.Size = new System.Drawing.Size(48, 13);
            this.operationLabel.TabIndex = 12;
            this.operationLabel.Text = "Mûvelet:";
            // 
            // version
            // 
            this.version.AutoSize = true;
            this.version.BackColor = System.Drawing.Color.Transparent;
            this.version.ForeColor = System.Drawing.Color.White;
            this.version.Location = new System.Drawing.Point(425, 10);
            this.version.Name = "version";
            this.version.Size = new System.Drawing.Size(35, 13);
            this.version.TabIndex = 11;
            this.version.Text = "label5";
            this.version.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(336, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(62, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "verziószám:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(335, 29);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(140, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "(c) 2007-2013 Dobos László";
            this.label3.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // closeTimer
            // 
            this.closeTimer.Interval = 2000;
            this.closeTimer.Tick += new System.EventHandler(this.closeTimer_Tick);
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(480, 320);
            this.ControlBox = false;
            this.Controls.Add(this.operation);
            this.Controls.Add(this.operationLabel);
            this.Controls.Add(this.version);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.username);
            this.Controls.Add(this.usernameLabel);
            this.Controls.Add(this.passwordLabel);
            this.Controls.Add(this.password);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Login";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Contacto bejelentkezés";
            this.TopMost = true;
            this.Shown += new System.EventHandler(this.Login_Shown);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Login_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox password;
        private System.Windows.Forms.Label passwordLabel;
        private System.Windows.Forms.Label usernameLabel;
        private System.Windows.Forms.TextBox username;
        private System.Windows.Forms.Label operationLabel;
        private System.Windows.Forms.Label version;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        public System.Windows.Forms.Label operation;
        private System.Windows.Forms.Timer closeTimer;
    }
}