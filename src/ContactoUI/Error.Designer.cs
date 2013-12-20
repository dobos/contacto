namespace Contacto.UI
{
    partial class Error
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
            this.ok = new System.Windows.Forms.Button();
            this.details = new System.Windows.Forms.Button();
            this.errorText = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.errorDetails = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // ok
            // 
            this.ok.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.ok.Location = new System.Drawing.Point(343, 212);
            this.ok.Name = "ok";
            this.ok.Size = new System.Drawing.Size(75, 23);
            this.ok.TabIndex = 0;
            this.ok.Text = "OK";
            this.ok.UseVisualStyleBackColor = true;
            // 
            // details
            // 
            this.details.Location = new System.Drawing.Point(262, 212);
            this.details.Name = "details";
            this.details.Size = new System.Drawing.Size(75, 23);
            this.details.TabIndex = 1;
            this.details.Text = "Részletek";
            this.details.UseVisualStyleBackColor = true;
            // 
            // errorText
            // 
            this.errorText.Location = new System.Drawing.Point(55, 13);
            this.errorText.Name = "errorText";
            this.errorText.Size = new System.Drawing.Size(363, 65);
            this.errorText.TabIndex = 2;
            // 
            // pictureBox1
            // 
            this.pictureBox1.InitialImage = global::Contacto.UI.Properties.Resources.error;
            this.pictureBox1.Location = new System.Drawing.Point(12, 13);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(37, 34);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // errorDetails
            // 
            this.errorDetails.Location = new System.Drawing.Point(58, 81);
            this.errorDetails.Multiline = true;
            this.errorDetails.Name = "errorDetails";
            this.errorDetails.ReadOnly = true;
            this.errorDetails.Size = new System.Drawing.Size(360, 125);
            this.errorDetails.TabIndex = 4;
            // 
            // Error
            // 
            this.AcceptButton = this.ok;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(430, 247);
            this.Controls.Add(this.errorDetails);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.errorText);
            this.Controls.Add(this.details);
            this.Controls.Add(this.ok);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Error";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Contacto Hibaüzenet";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button ok;
        private System.Windows.Forms.Button details;
        private System.Windows.Forms.PictureBox pictureBox1;
        public System.Windows.Forms.Label errorText;
        public System.Windows.Forms.TextBox errorDetails;
    }
}