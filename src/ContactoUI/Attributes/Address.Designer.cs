namespace Contacto.UI
{
    partial class Address
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
            this.country = new System.Windows.Forms.ComboBox();
            this.state = new System.Windows.Forms.ComboBox();
            this.zip = new System.Windows.Forms.TextBox();
            this.city = new System.Windows.Forms.TextBox();
            this.street = new System.Windows.Forms.TextBox();
            this.zipLabel = new System.Windows.Forms.Label();
            this.countryLabel = new System.Windows.Forms.Label();
            this.stateLabel = new System.Windows.Forms.Label();
            this.cityLabel = new System.Windows.Forms.Label();
            this.streetLabel = new System.Windows.Forms.Label();
            this.table2 = new System.Windows.Forms.TableLayoutPanel();
            this.table2.SuspendLayout();
            this.SuspendLayout();
            // 
            // country
            // 
            this.country.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.table2.SetColumnSpan(this.country, 3);
            this.country.FormattingEnabled = true;
            this.country.Location = new System.Drawing.Point(82, 75);
            this.country.Margin = new System.Windows.Forms.Padding(2);
            this.country.Name = "country";
            this.country.Size = new System.Drawing.Size(401, 21);
            this.country.TabIndex = 11;
            this.country.SelectedIndexChanged += new System.EventHandler(this.Changed);
            this.country.TextChanged += new System.EventHandler(this.Changed);
            // 
            // state
            // 
            this.state.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.table2.SetColumnSpan(this.state, 3);
            this.state.FormattingEnabled = true;
            this.state.Location = new System.Drawing.Point(82, 50);
            this.state.Margin = new System.Windows.Forms.Padding(2);
            this.state.Name = "state";
            this.state.Size = new System.Drawing.Size(401, 21);
            this.state.TabIndex = 9;
            this.state.SelectedIndexChanged += new System.EventHandler(this.Changed);
            this.state.TextChanged += new System.EventHandler(this.Changed);
            // 
            // zip
            // 
            this.zip.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.zip.Location = new System.Drawing.Point(407, 26);
            this.zip.Margin = new System.Windows.Forms.Padding(2);
            this.zip.Name = "zip";
            this.zip.Size = new System.Drawing.Size(76, 20);
            this.zip.TabIndex = 7;
            this.zip.TextChanged += new System.EventHandler(this.Changed);
            // 
            // city
            // 
            this.city.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.city.Location = new System.Drawing.Point(82, 26);
            this.city.Margin = new System.Windows.Forms.Padding(2);
            this.city.Name = "city";
            this.city.Size = new System.Drawing.Size(281, 20);
            this.city.TabIndex = 5;
            this.city.TextChanged += new System.EventHandler(this.Changed);
            // 
            // street
            // 
            this.street.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.table2.SetColumnSpan(this.street, 3);
            this.street.Location = new System.Drawing.Point(82, 2);
            this.street.Margin = new System.Windows.Forms.Padding(2);
            this.street.Name = "street";
            this.street.Size = new System.Drawing.Size(401, 20);
            this.street.TabIndex = 3;
            this.street.TextChanged += new System.EventHandler(this.Changed);
            // 
            // zipLabel
            // 
            this.zipLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.zipLabel.AutoSize = true;
            this.zipLabel.Location = new System.Drawing.Point(368, 29);
            this.zipLabel.Name = "zipLabel";
            this.zipLabel.Size = new System.Drawing.Size(29, 13);
            this.zipLabel.TabIndex = 6;
            this.zipLabel.Text = "Irsz.:";
            // 
            // countryLabel
            // 
            this.countryLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.countryLabel.AutoSize = true;
            this.countryLabel.Location = new System.Drawing.Point(3, 79);
            this.countryLabel.Name = "countryLabel";
            this.countryLabel.Size = new System.Drawing.Size(43, 13);
            this.countryLabel.TabIndex = 10;
            this.countryLabel.Text = "Ország:";
            // 
            // stateLabel
            // 
            this.stateLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.stateLabel.AutoSize = true;
            this.stateLabel.Location = new System.Drawing.Point(3, 54);
            this.stateLabel.Name = "stateLabel";
            this.stateLabel.Size = new System.Drawing.Size(42, 13);
            this.stateLabel.TabIndex = 8;
            this.stateLabel.Text = "Megye:";
            // 
            // cityLabel
            // 
            this.cityLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.cityLabel.AutoSize = true;
            this.cityLabel.Location = new System.Drawing.Point(3, 29);
            this.cityLabel.Name = "cityLabel";
            this.cityLabel.Size = new System.Drawing.Size(37, 13);
            this.cityLabel.TabIndex = 4;
            this.cityLabel.Text = "Város:";
            // 
            // streetLabel
            // 
            this.streetLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.streetLabel.AutoSize = true;
            this.streetLabel.Location = new System.Drawing.Point(3, 5);
            this.streetLabel.Name = "streetLabel";
            this.streetLabel.Size = new System.Drawing.Size(33, 13);
            this.streetLabel.TabIndex = 2;
            this.streetLabel.Text = "Utca:";
            // 
            // table2
            // 
            this.table2.AutoSize = true;
            this.table2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.table2.ColumnCount = 4;
            this.table2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.table2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.table2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.table2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.table2.Controls.Add(this.streetLabel, 0, 0);
            this.table2.Controls.Add(this.countryLabel, 0, 3);
            this.table2.Controls.Add(this.country, 1, 3);
            this.table2.Controls.Add(this.stateLabel, 0, 2);
            this.table2.Controls.Add(this.street, 1, 0);
            this.table2.Controls.Add(this.state, 1, 2);
            this.table2.Controls.Add(this.city, 1, 1);
            this.table2.Controls.Add(this.cityLabel, 0, 1);
            this.table2.Controls.Add(this.zipLabel, 2, 1);
            this.table2.Controls.Add(this.zip, 3, 1);
            this.table2.Dock = System.Windows.Forms.DockStyle.Top;
            this.table2.Location = new System.Drawing.Point(0, 25);
            this.table2.Margin = new System.Windows.Forms.Padding(0);
            this.table2.Name = "table2";
            this.table2.RowCount = 4;
            this.table2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.table2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.table2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.table2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.table2.Size = new System.Drawing.Size(485, 98);
            this.table2.TabIndex = 35;
            // 
            // Address
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.table2);
            this.Name = "Address";
            this.Size = new System.Drawing.Size(485, 192);
            this.Controls.SetChildIndex(this.table2, 0);
            this.table2.ResumeLayout(false);
            this.table2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox country;
        private System.Windows.Forms.ComboBox state;
        private System.Windows.Forms.TextBox zip;
        private System.Windows.Forms.TextBox city;
        private System.Windows.Forms.TextBox street;
        private System.Windows.Forms.Label zipLabel;
        private System.Windows.Forms.Label countryLabel;
        private System.Windows.Forms.Label stateLabel;
        private System.Windows.Forms.Label cityLabel;
        private System.Windows.Forms.Label streetLabel;
        private System.Windows.Forms.TableLayoutPanel table2;
    }
}
