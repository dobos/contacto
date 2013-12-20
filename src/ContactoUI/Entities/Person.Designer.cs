namespace Contacto.UI
{
    partial class Person
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
            this.phone = new Contacto.UI.Identifier();
            this.email = new Contacto.UI.Identifier();
            this.firstNameLabel = new System.Windows.Forms.Label();
            this.firstName = new System.Windows.Forms.TextBox();
            this.lastName = new System.Windows.Forms.TextBox();
            this.lastNameLabel = new System.Windows.Forms.Label();
            this.middleName = new System.Windows.Forms.TextBox();
            this.middleNameLabel = new System.Windows.Forms.Label();
            this.genderMale = new System.Windows.Forms.RadioButton();
            this.preposition = new System.Windows.Forms.ComboBox();
            this.postposition = new System.Windows.Forms.ComboBox();
            this.genderFemale = new System.Windows.Forms.RadioButton();
            this.companyLink = new Contacto.UI.Link();
            this.mobile = new Contacto.UI.Identifier();
            this.status = new Contacto.UI.Category();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tab.SuspendLayout();
            this.tabDocuments.SuspendLayout();
            this.tabAttributes.SuspendLayout();
            this.tabLinks.SuspendLayout();
            this.tabDates.SuspendLayout();
            this.tabCategories.SuspendLayout();
            this.tabProperties.SuspendLayout();
            this.tabBlobs.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // displayName
            // 
            this.displayName.Location = new System.Drawing.Point(496, 151);
            this.displayName.Size = new System.Drawing.Size(231, 21);
            this.displayName.Validating += new System.ComponentModel.CancelEventHandler(this.Validating);
            this.displayName.TextChanged += new System.EventHandler(this.Changed);
            // 
            // displayNameLabel
            // 
            this.displayNameLabel.Location = new System.Drawing.Point(404, 154);
            // 
            // tab
            // 
            this.tab.Location = new System.Drawing.Point(0, 140);
            this.tab.Size = new System.Drawing.Size(725, 466);
            // 
            // tabDocuments
            // 
            this.tabDocuments.Size = new System.Drawing.Size(717, 440);
            // 
            // documentList
            // 
            this.documentList.Size = new System.Drawing.Size(711, 434);
            this.documentList.TreeVisible = false;
            // 
            // tabPersons
            // 
            this.tabPersons.Size = new System.Drawing.Size(717, 552);
            // 
            // tabAttributes
            // 
            this.tabAttributes.Size = new System.Drawing.Size(717, 552);
            // 
            // attributeList
            // 
            this.attributeList.Size = new System.Drawing.Size(711, 546);
            this.attributeList.Changed += new System.EventHandler(this.attributeList_Changed);
            // 
            // tabLinks
            // 
            this.tabLinks.Size = new System.Drawing.Size(717, 552);
            // 
            // linkList
            // 
            this.linkList.Size = new System.Drawing.Size(711, 546);
            this.linkList.Changed += new System.EventHandler(this.linkList_Changed);
            // 
            // tabDates
            // 
            this.tabDates.Size = new System.Drawing.Size(717, 552);
            // 
            // dateList
            // 
            this.dateList.Size = new System.Drawing.Size(711, 546);
            // 
            // tabCategories
            // 
            this.tabCategories.Size = new System.Drawing.Size(717, 552);
            // 
            // categoryList
            // 
            this.categoryList.Size = new System.Drawing.Size(711, 546);
            // 
            // tabProperties
            // 
            this.tabProperties.Size = new System.Drawing.Size(717, 552);
            // 
            // tabBlobs
            // 
            this.tabBlobs.Size = new System.Drawing.Size(717, 552);
            // 
            // blobList
            // 
            this.blobList.Size = new System.Drawing.Size(711, 546);
            // 
            // number
            // 
            this.number.TextChanged += new System.EventHandler(this.Changed);
            // 
            // propertyList
            // 
            this.propertyList.Size = new System.Drawing.Size(711, 546);
            // 
            // phone
            // 
            this.phone.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.phone.Collapse = false;
            this.phone.Item = null;
            this.phone.LabelText = "Telefonszám:";
            this.phone.Location = new System.Drawing.Point(402, 54);
            this.phone.Margin = new System.Windows.Forms.Padding(0);
            this.phone.Name = "phone";
            this.phone.ReadOnly = false;
            this.phone.Size = new System.Drawing.Size(161, 26);
            this.phone.TabIndex = 38;
            this.phone.TypeVisible = false;
            this.phone.ItemChanged += new System.EventHandler(this.Changed);
            // 
            // email
            // 
            this.email.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.email.Collapse = false;
            this.tableLayoutPanel1.SetColumnSpan(this.email, 2);
            this.email.Item = null;
            this.email.LabelText = "E-mail cím:";
            this.email.Location = new System.Drawing.Point(402, 80);
            this.email.Margin = new System.Windows.Forms.Padding(0);
            this.email.Name = "email";
            this.email.ReadOnly = false;
            this.email.Size = new System.Drawing.Size(323, 26);
            this.email.TabIndex = 37;
            this.email.TypeVisible = false;
            this.email.ItemChanged += new System.EventHandler(this.Changed);
            // 
            // firstNameLabel
            // 
            this.firstNameLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.firstNameLabel.AutoSize = true;
            this.firstNameLabel.Location = new System.Drawing.Point(3, 34);
            this.firstNameLabel.Name = "firstNameLabel";
            this.firstNameLabel.Size = new System.Drawing.Size(63, 13);
            this.firstNameLabel.TabIndex = 32;
            this.firstNameLabel.Text = "Keresztnév:";
            // 
            // firstName
            // 
            this.firstName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.SetColumnSpan(this.firstName, 2);
            this.firstName.Location = new System.Drawing.Point(83, 30);
            this.firstName.Name = "firstName";
            this.firstName.Size = new System.Drawing.Size(187, 20);
            this.firstName.TabIndex = 30;
            this.firstName.TextChanged += new System.EventHandler(this.Changed);
            this.firstName.Leave += new System.EventHandler(this.name_LeaveFocus);
            this.firstName.Validating += new System.ComponentModel.CancelEventHandler(this.Validating);
            // 
            // lastName
            // 
            this.lastName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.SetColumnSpan(this.lastName, 2);
            this.lastName.Location = new System.Drawing.Point(147, 3);
            this.lastName.Name = "lastName";
            this.lastName.Size = new System.Drawing.Size(252, 20);
            this.lastName.TabIndex = 29;
            this.lastName.TextChanged += new System.EventHandler(this.Changed);
            this.lastName.Leave += new System.EventHandler(this.name_LeaveFocus);
            this.lastName.Validating += new System.ComponentModel.CancelEventHandler(this.Validating);
            // 
            // lastNameLabel
            // 
            this.lastNameLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lastNameLabel.AutoSize = true;
            this.lastNameLabel.Location = new System.Drawing.Point(3, 7);
            this.lastNameLabel.Name = "lastNameLabel";
            this.lastNameLabel.Size = new System.Drawing.Size(67, 13);
            this.lastNameLabel.TabIndex = 28;
            this.lastNameLabel.Text = "Vezetéknév:";
            // 
            // middleName
            // 
            this.middleName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.SetColumnSpan(this.middleName, 3);
            this.middleName.Location = new System.Drawing.Point(83, 57);
            this.middleName.Name = "middleName";
            this.middleName.Size = new System.Drawing.Size(316, 20);
            this.middleName.TabIndex = 39;
            this.middleName.TextChanged += new System.EventHandler(this.Changed);
            this.middleName.Leave += new System.EventHandler(this.name_LeaveFocus);
            // 
            // middleNameLabel
            // 
            this.middleNameLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.middleNameLabel.AutoSize = true;
            this.middleNameLabel.Location = new System.Drawing.Point(3, 60);
            this.middleNameLabel.Name = "middleNameLabel";
            this.middleNameLabel.Size = new System.Drawing.Size(71, 13);
            this.middleNameLabel.TabIndex = 40;
            this.middleNameLabel.Text = "Második név:";
            // 
            // genderMale
            // 
            this.genderMale.AutoSize = true;
            this.genderMale.Location = new System.Drawing.Point(651, 129);
            this.genderMale.Name = "genderMale";
            this.genderMale.Size = new System.Drawing.Size(36, 17);
            this.genderMale.TabIndex = 41;
            this.genderMale.TabStop = true;
            this.genderMale.Text = "Ffi";
            this.genderMale.UseVisualStyleBackColor = true;
            this.genderMale.Visible = false;
            // 
            // preposition
            // 
            this.preposition.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.preposition.FormattingEnabled = true;
            this.preposition.Location = new System.Drawing.Point(83, 3);
            this.preposition.Name = "preposition";
            this.preposition.Size = new System.Drawing.Size(58, 21);
            this.preposition.TabIndex = 42;
            this.preposition.SelectionChangeCommitted += new System.EventHandler(this.Changed);
            this.preposition.Leave += new System.EventHandler(this.name_LeaveFocus);
            this.preposition.TextUpdate += new System.EventHandler(this.Changed);
            // 
            // postposition
            // 
            this.postposition.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.postposition.FormattingEnabled = true;
            this.postposition.Location = new System.Drawing.Point(276, 30);
            this.postposition.Name = "postposition";
            this.postposition.Size = new System.Drawing.Size(123, 21);
            this.postposition.TabIndex = 43;
            this.postposition.SelectionChangeCommitted += new System.EventHandler(this.Changed);
            this.postposition.Leave += new System.EventHandler(this.name_LeaveFocus);
            this.postposition.TextUpdate += new System.EventHandler(this.Changed);
            // 
            // genderFemale
            // 
            this.genderFemale.AutoSize = true;
            this.genderFemale.Location = new System.Drawing.Point(688, 129);
            this.genderFemale.Name = "genderFemale";
            this.genderFemale.Size = new System.Drawing.Size(39, 17);
            this.genderFemale.TabIndex = 44;
            this.genderFemale.TabStop = true;
            this.genderFemale.Text = "Nõ";
            this.genderFemale.UseVisualStyleBackColor = true;
            this.genderFemale.Visible = false;
            // 
            // companyLink
            // 
            this.companyLink.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.companyLink.Clickable = true;
            this.companyLink.Collapse = false;
            this.tableLayoutPanel1.SetColumnSpan(this.companyLink, 2);
            this.companyLink.Item = null;
            this.companyLink.LabelText = "Cég:";
            this.companyLink.Location = new System.Drawing.Point(402, 0);
            this.companyLink.Margin = new System.Windows.Forms.Padding(0);
            this.companyLink.Name = "companyLink";
            this.companyLink.ReadOnly = true;
            this.companyLink.Size = new System.Drawing.Size(323, 27);
            this.companyLink.TabIndex = 45;
            this.companyLink.TypeVisible = false;
            this.companyLink.ItemChanged += new System.EventHandler(this.Changed);
            // 
            // mobile
            // 
            this.mobile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.mobile.Collapse = false;
            this.mobile.Item = null;
            this.mobile.LabelText = "Mobil:";
            this.mobile.Location = new System.Drawing.Point(563, 54);
            this.mobile.Margin = new System.Windows.Forms.Padding(0);
            this.mobile.Name = "mobile";
            this.mobile.ReadOnly = false;
            this.mobile.Size = new System.Drawing.Size(162, 26);
            this.mobile.TabIndex = 46;
            this.mobile.TypeVisible = false;
            this.mobile.ItemChanged += new System.EventHandler(this.Changed);
            // 
            // status
            // 
            this.status.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.status.Collapse = false;
            this.tableLayoutPanel1.SetColumnSpan(this.status, 2);
            this.status.Item = null;
            this.status.LabelText = "Beosztás:";
            this.status.Location = new System.Drawing.Point(402, 27);
            this.status.Margin = new System.Windows.Forms.Padding(0);
            this.status.Name = "status";
            this.status.ReadOnly = false;
            this.status.Size = new System.Drawing.Size(323, 26);
            this.status.TabIndex = 47;
            this.status.TypeVisible = false;
            this.status.ItemChanged += new System.EventHandler(this.Changed);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.ColumnCount = 6;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.Controls.Add(this.companyLink, 4, 0);
            this.tableLayoutPanel1.Controls.Add(this.mobile, 5, 2);
            this.tableLayoutPanel1.Controls.Add(this.status, 4, 1);
            this.tableLayoutPanel1.Controls.Add(this.postposition, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.middleName, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.phone, 4, 2);
            this.tableLayoutPanel1.Controls.Add(this.preposition, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.email, 4, 3);
            this.tableLayoutPanel1.Controls.Add(this.firstName, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.lastNameLabel, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.lastName, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.middleNameLabel, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.firstNameLabel, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 28);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.Padding = new System.Windows.Forms.Padding(0, 0, 0, 6);
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(725, 112);
            this.tableLayoutPanel1.TabIndex = 48;
            // 
            // Person
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.Controls.Add(this.genderFemale);
            this.Controls.Add(this.genderMale);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "Person";
            this.Size = new System.Drawing.Size(725, 606);
            this.Controls.SetChildIndex(this.tableLayoutPanel1, 0);
            this.Controls.SetChildIndex(this.displayNameLabel, 0);
            this.Controls.SetChildIndex(this.displayName, 0);
            this.Controls.SetChildIndex(this.tab, 0);
            this.Controls.SetChildIndex(this.genderMale, 0);
            this.Controls.SetChildIndex(this.genderFemale, 0);
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
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Identifier phone;
        private Identifier email;
        private System.Windows.Forms.Label firstNameLabel;
        private System.Windows.Forms.TextBox firstName;
        private System.Windows.Forms.TextBox lastName;
        private System.Windows.Forms.Label lastNameLabel;
        private System.Windows.Forms.TextBox middleName;
        private System.Windows.Forms.Label middleNameLabel;
        private System.Windows.Forms.RadioButton genderMale;
        private System.Windows.Forms.ComboBox preposition;
        private System.Windows.Forms.ComboBox postposition;
        private System.Windows.Forms.RadioButton genderFemale;
        private Link companyLink;
        private Identifier mobile;
        private Category status;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
    }
}
