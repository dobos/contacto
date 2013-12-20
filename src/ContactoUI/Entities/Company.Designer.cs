namespace Contacto.UI
{
    partial class Company
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
            this.shortNameLabel = new System.Windows.Forms.Label();
            this.shortName = new System.Windows.Forms.TextBox();
            this.longName = new System.Windows.Forms.TextBox();
            this.longNameLabel = new System.Windows.Forms.Label();
            this.address = new Contacto.UI.Address();
            this.email = new Contacto.UI.Identifier();
            this.phone = new Contacto.UI.Identifier();
            this.category = new Contacto.UI.Category();
            this.fax = new Contacto.UI.Identifier();
            this.webAddress = new Contacto.UI.Identifier();
            this.industry = new Contacto.UI.Category();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.classification = new Contacto.UI.Category();
            this.tab.SuspendLayout();
            this.tabDocuments.SuspendLayout();
            this.tabAttributes.SuspendLayout();
            this.tabLinks.SuspendLayout();
            this.tabDates.SuspendLayout();
            this.tabCategories.SuspendLayout();
            this.tabProperties.SuspendLayout();
            this.tabBlobs.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // displayName
            // 
            this.displayName.FormattingEnabled = true;
            this.displayName.Location = new System.Drawing.Point(769, 186);
            this.displayName.Size = new System.Drawing.Size(106, 21);
            this.displayName.TabIndex = 7;
            this.displayName.Validating += new System.ComponentModel.CancelEventHandler(this.Validating);
            this.displayName.SelectedIndexChanged += new System.EventHandler(this.Changed);
            this.displayName.TextChanged += new System.EventHandler(this.Changed);
            // 
            // displayNameLabel
            // 
            this.displayNameLabel.Location = new System.Drawing.Point(692, 189);
            this.displayNameLabel.TabIndex = 6;
            // 
            // tab
            // 
            this.tab.Location = new System.Drawing.Point(0, 185);
            this.tab.Size = new System.Drawing.Size(897, 469);
            this.tab.TabIndex = 15;
            // 
            // tabDocuments
            // 
            this.tabDocuments.Size = new System.Drawing.Size(889, 443);
            // 
            // documentList
            // 
            this.documentList.Size = new System.Drawing.Size(883, 437);
            // 
            // tabPersons
            // 
            this.tabPersons.Size = new System.Drawing.Size(889, 600);
            // 
            // tabAttributes
            // 
            this.tabAttributes.Size = new System.Drawing.Size(889, 600);
            // 
            // attributeList
            // 
            this.attributeList.Size = new System.Drawing.Size(883, 594);
            this.attributeList.Changed += new System.EventHandler(this.attributeList_Changed);
            // 
            // tabLinks
            // 
            this.tabLinks.Size = new System.Drawing.Size(889, 600);
            // 
            // linkList
            // 
            this.linkList.Size = new System.Drawing.Size(883, 594);
            this.linkList.Changed += new System.EventHandler(this.linkList_Changed);
            // 
            // tabDates
            // 
            this.tabDates.Size = new System.Drawing.Size(889, 600);
            // 
            // dateList
            // 
            this.dateList.Size = new System.Drawing.Size(883, 594);
            // 
            // tabCategories
            // 
            this.tabCategories.Size = new System.Drawing.Size(889, 600);
            // 
            // categoryList
            // 
            this.categoryList.Size = new System.Drawing.Size(883, 594);
            this.categoryList.Changed += new System.EventHandler(this.attributeList_Changed);
            // 
            // tabProperties
            // 
            this.tabProperties.Size = new System.Drawing.Size(889, 600);
            // 
            // tabBlobs
            // 
            this.tabBlobs.Size = new System.Drawing.Size(889, 600);
            // 
            // blobList
            // 
            this.blobList.Size = new System.Drawing.Size(883, 594);
            // 
            // number
            // 
            this.number.TextChanged += new System.EventHandler(this.Changed);
            // 
            // propertyList
            // 
            this.propertyList.Size = new System.Drawing.Size(883, 594);
            // 
            // shortNameLabel
            // 
            this.shortNameLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.shortNameLabel.AutoSize = true;
            this.shortNameLabel.Location = new System.Drawing.Point(3, 5);
            this.shortNameLabel.Name = "shortNameLabel";
            this.shortNameLabel.Size = new System.Drawing.Size(47, 13);
            this.shortNameLabel.TabIndex = 2;
            this.shortNameLabel.Text = "Cégnév:";
            // 
            // shortName
            // 
            this.shortName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel2.SetColumnSpan(this.shortName, 3);
            this.shortName.Location = new System.Drawing.Point(82, 2);
            this.shortName.Margin = new System.Windows.Forms.Padding(2);
            this.shortName.Name = "shortName";
            this.shortName.Size = new System.Drawing.Size(364, 20);
            this.shortName.TabIndex = 3;
            this.shortName.TextChanged += new System.EventHandler(this.Changed);
            this.shortName.Leave += new System.EventHandler(this.name_LeaveFocus);
            this.shortName.Validating += new System.ComponentModel.CancelEventHandler(this.Validating);
            // 
            // longName
            // 
            this.longName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel2.SetColumnSpan(this.longName, 3);
            this.longName.Location = new System.Drawing.Point(82, 26);
            this.longName.Margin = new System.Windows.Forms.Padding(2);
            this.longName.Name = "longName";
            this.longName.Size = new System.Drawing.Size(364, 20);
            this.longName.TabIndex = 5;
            this.longName.TextChanged += new System.EventHandler(this.Changed);
            this.longName.Leave += new System.EventHandler(this.name_LeaveFocus);
            // 
            // longNameLabel
            // 
            this.longNameLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.longNameLabel.AutoSize = true;
            this.longNameLabel.Location = new System.Drawing.Point(3, 29);
            this.longNameLabel.Name = "longNameLabel";
            this.longNameLabel.Size = new System.Drawing.Size(59, 13);
            this.longNameLabel.TabIndex = 4;
            this.longNameLabel.Text = "Teljes név:";
            // 
            // address
            // 
            this.address.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.address.Collapse = false;
            this.address.Item = null;
            this.address.LabelText = "";
            this.address.Location = new System.Drawing.Point(448, 0);
            this.address.Margin = new System.Windows.Forms.Padding(0, 0, 0, 6);
            this.address.Name = "address";
            this.address.ReadOnly = false;
            this.address.Size = new System.Drawing.Size(449, 99);
            this.address.TabIndex = 12;
            this.address.TypeVisible = false;
            this.address.ItemChanged += new System.EventHandler(this.Changed);
            // 
            // email
            // 
            this.email.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.email.Collapse = false;
            this.email.Item = null;
            this.email.LabelText = "E-mail:";
            this.email.Location = new System.Drawing.Point(448, 105);
            this.email.Margin = new System.Windows.Forms.Padding(0);
            this.email.Name = "email";
            this.email.ReadOnly = false;
            this.email.Size = new System.Drawing.Size(449, 26);
            this.email.TabIndex = 13;
            this.email.TypeVisible = false;
            this.email.ItemChanged += new System.EventHandler(this.Changed);
            // 
            // phone
            // 
            this.phone.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.phone.Collapse = false;
            this.phone.Item = null;
            this.phone.LabelText = "Telefon:";
            this.phone.Location = new System.Drawing.Point(0, 0);
            this.phone.Margin = new System.Windows.Forms.Padding(0);
            this.phone.Name = "phone";
            this.phone.ReadOnly = false;
            this.phone.Size = new System.Drawing.Size(224, 26);
            this.phone.TabIndex = 10;
            this.phone.TypeVisible = false;
            this.phone.ItemChanged += new System.EventHandler(this.Changed);
            // 
            // category
            // 
            this.category.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.category.Collapse = false;
            this.category.Item = null;
            this.category.LabelText = "Kategória:";
            this.category.Location = new System.Drawing.Point(180, 54);
            this.category.Margin = new System.Windows.Forms.Padding(0, 6, 0, 0);
            this.category.Name = "category";
            this.category.ReadOnly = false;
            this.category.Size = new System.Drawing.Size(268, 26);
            this.category.TabIndex = 8;
            this.category.TypeVisible = false;
            this.category.ItemChanged += new System.EventHandler(this.Changed);
            // 
            // fax
            // 
            this.fax.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.fax.Collapse = false;
            this.fax.Item = null;
            this.fax.LabelText = "Fax:";
            this.fax.Location = new System.Drawing.Point(224, 0);
            this.fax.Margin = new System.Windows.Forms.Padding(0);
            this.fax.Name = "fax";
            this.fax.ReadOnly = false;
            this.fax.Size = new System.Drawing.Size(224, 26);
            this.fax.TabIndex = 11;
            this.fax.TypeVisible = false;
            this.fax.ItemChanged += new System.EventHandler(this.Changed);
            // 
            // webAddress
            // 
            this.webAddress.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.webAddress.Collapse = false;
            this.webAddress.Item = null;
            this.webAddress.LabelText = "Internet:";
            this.webAddress.Location = new System.Drawing.Point(448, 131);
            this.webAddress.Margin = new System.Windows.Forms.Padding(0);
            this.webAddress.Name = "webAddress";
            this.webAddress.ReadOnly = false;
            this.webAddress.Size = new System.Drawing.Size(449, 26);
            this.webAddress.TabIndex = 14;
            this.webAddress.TypeVisible = false;
            this.webAddress.ItemChanged += new System.EventHandler(this.Changed);
            // 
            // industry
            // 
            this.industry.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.industry.Collapse = false;
            this.industry.Item = null;
            this.industry.LabelText = "Iparág:";
            this.industry.Location = new System.Drawing.Point(0, 105);
            this.industry.Margin = new System.Windows.Forms.Padding(0);
            this.industry.Name = "industry";
            this.industry.ReadOnly = false;
            this.industry.Size = new System.Drawing.Size(448, 26);
            this.industry.TabIndex = 9;
            this.industry.TypeVisible = false;
            this.industry.ItemChanged += new System.EventHandler(this.Changed);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel3, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.industry, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.webAddress, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.email, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.address, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 28);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(897, 157);
            this.tableLayoutPanel1.TabIndex = 26;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel3.AutoSize = true;
            this.tableLayoutPanel3.ColumnCount = 2;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Controls.Add(this.phone, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.fax, 1, 0);
            this.tableLayoutPanel3.Location = new System.Drawing.Point(0, 131);
            this.tableLayoutPanel3.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(448, 26);
            this.tableLayoutPanel3.TabIndex = 27;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel2.AutoSize = true;
            this.tableLayoutPanel2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel2.ColumnCount = 4;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.classification, 0, 3);
            this.tableLayoutPanel2.Controls.Add(this.longNameLabel, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.longName, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.category, 3, 3);
            this.tableLayoutPanel2.Controls.Add(this.shortNameLabel, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.shortName, 1, 0);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 4;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(448, 105);
            this.tableLayoutPanel2.TabIndex = 27;
            // 
            // classification
            // 
            this.classification.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.classification.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.classification.Collapse = false;
            this.tableLayoutPanel2.SetColumnSpan(this.classification, 3);
            this.classification.Item = null;
            this.classification.LabelText = "Besorolás:";
            this.classification.Location = new System.Drawing.Point(3, 51);
            this.classification.Name = "classification";
            this.classification.ReadOnly = false;
            this.classification.Size = new System.Drawing.Size(174, 29);
            this.classification.TabIndex = 10;
            this.classification.TypeVisible = false;
            this.classification.ItemChanged += new System.EventHandler(this.Changed);
            // 
            // Company
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "Company";
            this.Size = new System.Drawing.Size(897, 654);
            this.Controls.SetChildIndex(this.tableLayoutPanel1, 0);
            this.Controls.SetChildIndex(this.tab, 0);
            this.Controls.SetChildIndex(this.displayName, 0);
            this.Controls.SetChildIndex(this.displayNameLabel, 0);
            this.tab.ResumeLayout(false);
            this.tabDocuments.ResumeLayout(false);
            this.tabAttributes.ResumeLayout(false);
            this.tabLinks.ResumeLayout(false);
            this.tabDates.ResumeLayout(false);
            this.tabCategories.ResumeLayout(false);
            this.tabProperties.ResumeLayout(false);
            this.tabBlobs.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label shortNameLabel;
        private System.Windows.Forms.TextBox shortName;
        private System.Windows.Forms.TextBox longName;
        private System.Windows.Forms.Label longNameLabel;
        private Address address;
        private Identifier email;
        private Identifier phone;
        private Category category;
        private Identifier fax;
        private Identifier webAddress;
        private Category industry;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private Category classification;
    }
}
