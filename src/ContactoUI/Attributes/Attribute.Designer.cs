namespace Contacto.UI
{
    partial class Attribute
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
            this.typeLabel = new System.Windows.Forms.Label();
            this.type = new System.Windows.Forms.ComboBox();
            this.table = new System.Windows.Forms.TableLayoutPanel();
            this.table.SuspendLayout();
            this.SuspendLayout();
            // 
            // typeLabel
            // 
            this.typeLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.typeLabel.Location = new System.Drawing.Point(3, 6);
            this.typeLabel.Margin = new System.Windows.Forms.Padding(3);
            this.typeLabel.Name = "typeLabel";
            this.typeLabel.Size = new System.Drawing.Size(38, 13);
            this.typeLabel.TabIndex = 32;
            this.typeLabel.Text = "Típus:";
            // 
            // type
            // 
            this.type.Dock = System.Windows.Forms.DockStyle.Top;
            this.type.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.type.FormattingEnabled = true;
            this.type.Location = new System.Drawing.Point(82, 2);
            this.type.Margin = new System.Windows.Forms.Padding(2);
            this.type.Name = "type";
            this.type.Size = new System.Drawing.Size(290, 21);
            this.type.TabIndex = 34;
            // 
            // table
            // 
            this.table.AutoSize = true;
            this.table.ColumnCount = 2;
            this.table.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.table.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.table.Controls.Add(this.type, 1, 0);
            this.table.Controls.Add(this.typeLabel, 0, 0);
            this.table.Dock = System.Windows.Forms.DockStyle.Top;
            this.table.Location = new System.Drawing.Point(0, 0);
            this.table.Margin = new System.Windows.Forms.Padding(0);
            this.table.Name = "table";
            this.table.RowCount = 1;
            this.table.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.table.Size = new System.Drawing.Size(374, 25);
            this.table.TabIndex = 35;
            // 
            // Attribute
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.table);
            this.Name = "Attribute";
            this.Size = new System.Drawing.Size(374, 86);
            this.table.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        protected System.Windows.Forms.Label typeLabel;
        protected System.Windows.Forms.ComboBox type;
        protected System.Windows.Forms.TableLayoutPanel table;

    }
}
