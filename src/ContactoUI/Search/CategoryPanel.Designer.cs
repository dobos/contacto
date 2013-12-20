namespace Contacto.UI
{
    partial class CategoryPanel
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
            this.dropdownPanel1 = new Contacto.UI.DropdownPanel();
            this.categoryLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.dropdownPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dropdownPanel1
            // 
            this.dropdownPanel1.Controls.Add(this.categoryLayoutPanel);
            this.dropdownPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.dropdownPanel1.Location = new System.Drawing.Point(0, 0);
            this.dropdownPanel1.Margin = new System.Windows.Forms.Padding(4);
            this.dropdownPanel1.Name = "dropdownPanel1";
            this.dropdownPanel1.Padding = new System.Windows.Forms.Padding(0, 25, 0, 0);
            this.dropdownPanel1.Size = new System.Drawing.Size(0, 25);
            this.dropdownPanel1.State = Contacto.UI.DropdownPanel.DropdownState.Open;
            this.dropdownPanel1.TabIndex = 68;
            this.dropdownPanel1.Text = "Kategóriák Szerint";
            // 
            // categoryLayoutPanel
            // 
            this.categoryLayoutPanel.AutoSize = true;
            this.categoryLayoutPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.categoryLayoutPanel.ColumnCount = 1;
            this.categoryLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.categoryLayoutPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.categoryLayoutPanel.Location = new System.Drawing.Point(0, 25);
            this.categoryLayoutPanel.Margin = new System.Windows.Forms.Padding(4);
            this.categoryLayoutPanel.Name = "categoryLayoutPanel";
            this.categoryLayoutPanel.RowCount = 3;
            this.categoryLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.categoryLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.categoryLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.categoryLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.categoryLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.categoryLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.categoryLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.categoryLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.categoryLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.categoryLayoutPanel.Size = new System.Drawing.Size(0, 0);
            this.categoryLayoutPanel.TabIndex = 0;
            // 
            // CategoryPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Controls.Add(this.dropdownPanel1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "CategoryPanel";
            this.Size = new System.Drawing.Size(0, 25);
            this.dropdownPanel1.ResumeLayout(false);
            this.dropdownPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private DropdownPanel dropdownPanel1;
        private System.Windows.Forms.TableLayoutPanel categoryLayoutPanel;
    }
}
