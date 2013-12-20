namespace Contacto.UI
{
    partial class DateLimits
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.DateLimitFrom = new System.Windows.Forms.DateTimePicker();
            this.DateLimitTo = new System.Windows.Forms.DateTimePicker();
            this.ShowHidden = new System.Windows.Forms.CheckBox();
            this.ShowDeleted = new System.Windows.Forms.CheckBox();
            this.ShowClosed = new System.Windows.Forms.CheckBox();
            this.cancel = new System.Windows.Forms.Button();
            this.ok = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.DateLimitFrom, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.DateLimitTo, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.ShowHidden, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.ShowDeleted, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.ShowClosed, 1, 4);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 5;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(406, 121);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Kezdeti Dátum:";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Végsõ Dátum:";
            // 
            // DateLimitFrom
            // 
            this.DateLimitFrom.Location = new System.Drawing.Point(206, 3);
            this.DateLimitFrom.Name = "DateLimitFrom";
            this.DateLimitFrom.Size = new System.Drawing.Size(170, 20);
            this.DateLimitFrom.TabIndex = 2;
            // 
            // DateLimitTo
            // 
            this.DateLimitTo.Location = new System.Drawing.Point(206, 29);
            this.DateLimitTo.Name = "DateLimitTo";
            this.DateLimitTo.Size = new System.Drawing.Size(170, 20);
            this.DateLimitTo.TabIndex = 3;
            // 
            // ShowHidden
            // 
            this.ShowHidden.AutoSize = true;
            this.ShowHidden.Location = new System.Drawing.Point(206, 55);
            this.ShowHidden.Name = "ShowHidden";
            this.ShowHidden.Size = new System.Drawing.Size(163, 17);
            this.ShowHidden.TabIndex = 4;
            this.ShowHidden.Text = "Rejtett elemek megjelenítése";
            this.ShowHidden.UseVisualStyleBackColor = true;
            // 
            // ShowDeleted
            // 
            this.ShowDeleted.AutoSize = true;
            this.ShowDeleted.Location = new System.Drawing.Point(206, 78);
            this.ShowDeleted.Name = "ShowDeleted";
            this.ShowDeleted.Size = new System.Drawing.Size(159, 17);
            this.ShowDeleted.TabIndex = 5;
            this.ShowDeleted.Text = "Törölt elemek megjelenítése";
            this.ShowDeleted.UseVisualStyleBackColor = true;
            // 
            // ShowClosed
            // 
            this.ShowClosed.AutoSize = true;
            this.ShowClosed.Location = new System.Drawing.Point(206, 101);
            this.ShowClosed.Name = "ShowClosed";
            this.ShowClosed.Size = new System.Drawing.Size(161, 17);
            this.ShowClosed.TabIndex = 6;
            this.ShowClosed.Text = "Lezárt elemek megjelenítése";
            this.ShowClosed.UseVisualStyleBackColor = true;
            // 
            // cancel
            // 
            this.cancel.CausesValidation = false;
            this.cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancel.Location = new System.Drawing.Point(319, 127);
            this.cancel.Name = "cancel";
            this.cancel.Size = new System.Drawing.Size(75, 23);
            this.cancel.TabIndex = 3;
            this.cancel.Text = "Mégse";
            this.cancel.UseVisualStyleBackColor = true;
            // 
            // ok
            // 
            this.ok.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.ok.Location = new System.Drawing.Point(238, 127);
            this.ok.Name = "ok";
            this.ok.Size = new System.Drawing.Size(75, 23);
            this.ok.TabIndex = 2;
            this.ok.Text = "OK";
            this.ok.UseVisualStyleBackColor = true;
            // 
            // DateLimits
            // 
            this.AcceptButton = this.ok;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancel;
            this.ClientSize = new System.Drawing.Size(406, 159);
            this.Controls.Add(this.cancel);
            this.Controls.Add(this.ok);
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "DateLimits";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Dátum Limitek Megadása";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button cancel;
        private System.Windows.Forms.Button ok;
        public System.Windows.Forms.DateTimePicker DateLimitFrom;
        public System.Windows.Forms.DateTimePicker DateLimitTo;
        public System.Windows.Forms.CheckBox ShowHidden;
        public System.Windows.Forms.CheckBox ShowDeleted;
        public System.Windows.Forms.CheckBox ShowClosed;
    }
}