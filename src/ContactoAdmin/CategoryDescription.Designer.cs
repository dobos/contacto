namespace Contacto.Admin
{
    partial class CategoryDescription
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
            this.label1 = new System.Windows.Forms.Label();
            this.id = new System.Windows.Forms.TextBox();
            this.ok = new System.Windows.Forms.Button();
            this.cancel = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.description = new System.Windows.Forms.TextBox();
            this.withUpdate = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.colorDialog = new System.Windows.Forms.ColorDialog();
            this.backColor = new System.Windows.Forms.Label();
            this.foreColor = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.pickBackColor = new System.Windows.Forms.Button();
            this.pickForeColor = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(21, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "ID:";
            // 
            // id
            // 
            this.id.Location = new System.Drawing.Point(85, 12);
            this.id.Name = "id";
            this.id.ReadOnly = true;
            this.id.Size = new System.Drawing.Size(100, 20);
            this.id.TabIndex = 1;
            // 
            // ok
            // 
            this.ok.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.ok.Location = new System.Drawing.Point(143, 148);
            this.ok.Name = "ok";
            this.ok.Size = new System.Drawing.Size(75, 23);
            this.ok.TabIndex = 7;
            this.ok.Text = "OK";
            this.ok.UseVisualStyleBackColor = true;
            // 
            // cancel
            // 
            this.cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancel.Location = new System.Drawing.Point(224, 148);
            this.cancel.Name = "cancel";
            this.cancel.Size = new System.Drawing.Size(75, 23);
            this.cancel.TabIndex = 8;
            this.cancel.Text = "Mégse";
            this.cancel.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Érték:";
            // 
            // description
            // 
            this.description.Location = new System.Drawing.Point(85, 38);
            this.description.Name = "description";
            this.description.Size = new System.Drawing.Size(214, 20);
            this.description.TabIndex = 5;
            // 
            // withUpdate
            // 
            this.withUpdate.AutoSize = true;
            this.withUpdate.Location = new System.Drawing.Point(85, 125);
            this.withUpdate.Name = "withUpdate";
            this.withUpdate.Size = new System.Drawing.Size(155, 17);
            this.withUpdate.TabIndex = 6;
            this.withUpdate.Text = "Kategória értékek frissítése";
            this.withUpdate.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 70);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Háttérszín:";
            // 
            // backColor
            // 
            this.backColor.BackColor = System.Drawing.Color.White;
            this.backColor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.backColor.Location = new System.Drawing.Point(82, 66);
            this.backColor.Name = "backColor";
            this.backColor.Size = new System.Drawing.Size(188, 20);
            this.backColor.TabIndex = 10;
            this.backColor.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // foreColor
            // 
            this.foreColor.BackColor = System.Drawing.Color.Black;
            this.foreColor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.foreColor.Location = new System.Drawing.Point(82, 95);
            this.foreColor.Name = "foreColor";
            this.foreColor.Size = new System.Drawing.Size(188, 20);
            this.foreColor.TabIndex = 12;
            this.foreColor.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 98);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(52, 13);
            this.label6.TabIndex = 11;
            this.label6.Text = "Betûszín:";
            // 
            // pickBackColor
            // 
            this.pickBackColor.Location = new System.Drawing.Point(276, 64);
            this.pickBackColor.Name = "pickBackColor";
            this.pickBackColor.Size = new System.Drawing.Size(23, 23);
            this.pickBackColor.TabIndex = 13;
            this.pickBackColor.Text = "…";
            this.pickBackColor.UseVisualStyleBackColor = true;
            this.pickBackColor.Click += new System.EventHandler(this.pickBackColor_Click);
            // 
            // pickForeColor
            // 
            this.pickForeColor.Location = new System.Drawing.Point(276, 93);
            this.pickForeColor.Name = "pickForeColor";
            this.pickForeColor.Size = new System.Drawing.Size(23, 23);
            this.pickForeColor.TabIndex = 14;
            this.pickForeColor.Text = "…";
            this.pickForeColor.UseVisualStyleBackColor = true;
            this.pickForeColor.Click += new System.EventHandler(this.pickForeColor_Click);
            // 
            // CategoryDescription
            // 
            this.AcceptButton = this.ok;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancel;
            this.ClientSize = new System.Drawing.Size(311, 183);
            this.Controls.Add(this.pickForeColor);
            this.Controls.Add(this.pickBackColor);
            this.Controls.Add(this.foreColor);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.backColor);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.withUpdate);
            this.Controls.Add(this.description);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cancel);
            this.Controls.Add(this.ok);
            this.Controls.Add(this.id);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CategoryDescription";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CategoryDescription";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox id;
        private System.Windows.Forms.Button ok;
        private System.Windows.Forms.Button cancel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox description;
        public System.Windows.Forms.CheckBox withUpdate;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ColorDialog colorDialog;
        private System.Windows.Forms.Label backColor;
        private System.Windows.Forms.Label foreColor;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button pickBackColor;
        private System.Windows.Forms.Button pickForeColor;
    }
}