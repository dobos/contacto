namespace Contacto.UI
{
    partial class Identifier
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
            this.value = new System.Windows.Forms.TextBox();
            this.table2 = new System.Windows.Forms.TableLayoutPanel();
            this.valueLabel = new System.Windows.Forms.Label();
            this.table2.SuspendLayout();
            this.SuspendLayout();
            // 
            // value
            // 
            this.value.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.value.Location = new System.Drawing.Point(82, 2);
            this.value.Margin = new System.Windows.Forms.Padding(2);
            this.value.Name = "value";
            this.value.Size = new System.Drawing.Size(70, 20);
            this.value.TabIndex = 3;
            this.value.Enter += new System.EventHandler(this.TextBox_AutoSelect);
            this.value.DoubleClick += new System.EventHandler(this.value_DoubleClick);
            this.value.TextChanged += new System.EventHandler(this.Changed);
            // 
            // table2
            // 
            this.table2.AutoSize = true;
            this.table2.ColumnCount = 2;
            this.table2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.table2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.table2.Controls.Add(this.valueLabel, 0, 0);
            this.table2.Controls.Add(this.value, 1, 0);
            this.table2.Dock = System.Windows.Forms.DockStyle.Top;
            this.table2.Location = new System.Drawing.Point(0, 25);
            this.table2.Margin = new System.Windows.Forms.Padding(0);
            this.table2.Name = "table2";
            this.table2.RowCount = 1;
            this.table2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.table2.Size = new System.Drawing.Size(154, 24);
            this.table2.TabIndex = 36;
            // 
            // valueLabel
            // 
            this.valueLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.valueLabel.AutoSize = true;
            this.valueLabel.Location = new System.Drawing.Point(3, 5);
            this.valueLabel.Name = "valueLabel";
            this.valueLabel.Size = new System.Drawing.Size(35, 13);
            this.valueLabel.TabIndex = 37;
            this.valueLabel.Text = "Érték:";
            // 
            // Identifier
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.table2);
            this.Name = "Identifier";
            this.Size = new System.Drawing.Size(154, 51);
            this.Validated += new System.EventHandler(this.Identifier_Validated);
            this.Validating += new System.ComponentModel.CancelEventHandler(this.Identifier_Validating);
            this.Controls.SetChildIndex(this.table2, 0);
            this.table2.ResumeLayout(false);
            this.table2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox value;
        private System.Windows.Forms.TableLayoutPanel table2;
        private System.Windows.Forms.Label valueLabel;
    }
}
