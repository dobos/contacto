namespace Contacto.UI
{
    partial class Link
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Link));
            this.table2 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.edit = new System.Windows.Forms.Button();
            this.value = new System.Windows.Forms.TextBox();
            this.valueLabel = new System.Windows.Forms.Label();
            this.table2.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // table2
            // 
            this.table2.AutoSize = true;
            this.table2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.table2.ColumnCount = 2;
            this.table2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.table2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.table2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.table2.Controls.Add(this.tableLayoutPanel1, 0, 0);
            this.table2.Controls.Add(this.valueLabel, 0, 0);
            this.table2.Dock = System.Windows.Forms.DockStyle.Top;
            this.table2.Location = new System.Drawing.Point(0, 25);
            this.table2.Margin = new System.Windows.Forms.Padding(0);
            this.table2.Name = "table2";
            this.table2.Padding = new System.Windows.Forms.Padding(1);
            this.table2.RowCount = 1;
            this.table2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.table2.Size = new System.Drawing.Size(359, 24);
            this.table2.TabIndex = 37;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Controls.Add(this.edit, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.value, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(81, 1);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 22F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(277, 22);
            this.tableLayoutPanel1.TabIndex = 41;
            // 
            // edit
            // 
            this.edit.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.edit.Image = ((System.Drawing.Image)(resources.GetObject("edit.Image")));
            this.edit.Location = new System.Drawing.Point(258, 1);
            this.edit.Margin = new System.Windows.Forms.Padding(1, 1, 0, 0);
            this.edit.Name = "edit";
            this.edit.Size = new System.Drawing.Size(19, 21);
            this.edit.TabIndex = 37;
            this.edit.TabStop = false;
            this.edit.UseVisualStyleBackColor = true;
            this.edit.Click += new System.EventHandler(this.edit_Click);
            // 
            // value
            // 
            this.value.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.value.Cursor = System.Windows.Forms.Cursors.Hand;
            this.value.Location = new System.Drawing.Point(1, 1);
            this.value.Margin = new System.Windows.Forms.Padding(1);
            this.value.Name = "value";
            this.value.ReadOnly = true;
            this.value.Size = new System.Drawing.Size(255, 20);
            this.value.TabIndex = 36;
            this.value.Text = "LINK VALUE";
            this.value.DoubleClick += new System.EventHandler(this.value_DoubleClick);
            // 
            // valueLabel
            // 
            this.valueLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.valueLabel.AutoSize = true;
            this.valueLabel.Location = new System.Drawing.Point(4, 5);
            this.valueLabel.Name = "valueLabel";
            this.valueLabel.Size = new System.Drawing.Size(35, 13);
            this.valueLabel.TabIndex = 38;
            this.valueLabel.Text = "�rt�k:";
            // 
            // Link
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.table2);
            this.Name = "Link";
            this.Size = new System.Drawing.Size(359, 129);
            this.Controls.SetChildIndex(this.table2, 0);
            this.table2.ResumeLayout(false);
            this.table2.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel table2;
        private System.Windows.Forms.Label valueLabel;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button edit;
        private System.Windows.Forms.TextBox value;
    }
}
