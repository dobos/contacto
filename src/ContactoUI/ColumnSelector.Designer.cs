namespace Contacto.UI
{
    partial class ColumnSelector
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
            this.listAvailable = new System.Windows.Forms.ListBox();
            this.add = new System.Windows.Forms.Button();
            this.listSelected = new System.Windows.Forms.ListBox();
            this.ok = new System.Windows.Forms.Button();
            this.cancel = new System.Windows.Forms.Button();
            this.remove = new System.Windows.Forms.Button();
            this.up = new System.Windows.Forms.Button();
            this.down = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(107, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Választható oszlopok";
            // 
            // listAvailable
            // 
            this.listAvailable.DisplayMember = "Text";
            this.listAvailable.FormattingEnabled = true;
            this.listAvailable.Location = new System.Drawing.Point(16, 30);
            this.listAvailable.Name = "listAvailable";
            this.listAvailable.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.listAvailable.Size = new System.Drawing.Size(200, 290);
            this.listAvailable.TabIndex = 1;
            this.listAvailable.ValueMember = "Text";
            this.listAvailable.DoubleClick += new System.EventHandler(this.add_Click);
            // 
            // add
            // 
            this.add.Font = new System.Drawing.Font("Marlett", 12F);
            this.add.Location = new System.Drawing.Point(222, 30);
            this.add.Name = "add";
            this.add.Size = new System.Drawing.Size(32, 23);
            this.add.TabIndex = 2;
            this.add.Text = "3";
            this.add.UseVisualStyleBackColor = true;
            this.add.Click += new System.EventHandler(this.add_Click);
            // 
            // listSelected
            // 
            this.listSelected.DisplayMember = "Text";
            this.listSelected.FormattingEnabled = true;
            this.listSelected.Location = new System.Drawing.Point(260, 30);
            this.listSelected.Name = "listSelected";
            this.listSelected.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.listSelected.Size = new System.Drawing.Size(200, 290);
            this.listSelected.TabIndex = 3;
            this.listSelected.ValueMember = "Text";
            this.listSelected.DoubleClick += new System.EventHandler(this.remove_Click);
            // 
            // ok
            // 
            this.ok.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.ok.Location = new System.Drawing.Point(306, 326);
            this.ok.Name = "ok";
            this.ok.Size = new System.Drawing.Size(75, 23);
            this.ok.TabIndex = 5;
            this.ok.Text = "OK";
            this.ok.UseVisualStyleBackColor = true;
            // 
            // cancel
            // 
            this.cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancel.Location = new System.Drawing.Point(387, 326);
            this.cancel.Name = "cancel";
            this.cancel.Size = new System.Drawing.Size(75, 23);
            this.cancel.TabIndex = 4;
            this.cancel.Text = "Mégse";
            this.cancel.UseVisualStyleBackColor = true;
            // 
            // remove
            // 
            this.remove.Font = new System.Drawing.Font("Marlett", 12F);
            this.remove.Location = new System.Drawing.Point(222, 59);
            this.remove.Name = "remove";
            this.remove.Size = new System.Drawing.Size(32, 23);
            this.remove.TabIndex = 6;
            this.remove.Text = "4";
            this.remove.UseVisualStyleBackColor = true;
            this.remove.Click += new System.EventHandler(this.remove_Click);
            // 
            // up
            // 
            this.up.Font = new System.Drawing.Font("Marlett", 12F);
            this.up.Location = new System.Drawing.Point(222, 146);
            this.up.Name = "up";
            this.up.Size = new System.Drawing.Size(32, 23);
            this.up.TabIndex = 7;
            this.up.Text = "5";
            this.up.UseVisualStyleBackColor = true;
            this.up.Click += new System.EventHandler(this.up_Click);
            // 
            // down
            // 
            this.down.Font = new System.Drawing.Font("Marlett", 12F);
            this.down.Location = new System.Drawing.Point(222, 175);
            this.down.Name = "down";
            this.down.Size = new System.Drawing.Size(32, 23);
            this.down.TabIndex = 8;
            this.down.Text = "6";
            this.down.UseVisualStyleBackColor = true;
            this.down.Click += new System.EventHandler(this.down_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(252, 11);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(109, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Kiválasztott oszlopok:";
            // 
            // ColumnSelector
            // 
            this.AcceptButton = this.ok;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.CancelButton = this.cancel;
            this.ClientSize = new System.Drawing.Size(474, 356);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.down);
            this.Controls.Add(this.up);
            this.Controls.Add(this.remove);
            this.Controls.Add(this.ok);
            this.Controls.Add(this.cancel);
            this.Controls.Add(this.listSelected);
            this.Controls.Add(this.add);
            this.Controls.Add(this.listAvailable);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ColumnSelector";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Oszlopok kiválasztása";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button add;
        private System.Windows.Forms.Button ok;
        private System.Windows.Forms.Button cancel;
        private System.Windows.Forms.Button remove;
        private System.Windows.Forms.Button up;
        private System.Windows.Forms.Button down;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.ListBox listAvailable;
        public System.Windows.Forms.ListBox listSelected;
    }
}