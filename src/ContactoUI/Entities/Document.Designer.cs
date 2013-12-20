namespace Contacto.UI
{
    partial class Document
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
            this.subjectLabel = new System.Windows.Forms.Label();
            this.subject = new System.Windows.Forms.TextBox();
            this.titleLabel = new System.Windows.Forms.Label();
            this.title = new System.Windows.Forms.TextBox();
            this.linkFromCompany = new Contacto.UI.Link();
            this.linkFromPerson = new Contacto.UI.Link();
            this.linkToCompany = new Contacto.UI.Link();
            this.linkToPerson = new Contacto.UI.Link();
            this.category = new Contacto.UI.Category();
            this.direction = new Contacto.UI.Category();
            this.date = new Contacto.UI.Date();
            this.brand = new Contacto.UI.Category();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.linkFolder = new Contacto.UI.Link();
            this.foreignNumberLabel = new System.Windows.Forms.Label();
            this.foreignNumber = new System.Windows.Forms.TextBox();
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
            this.displayName.Location = new System.Drawing.Point(641, 143);
            this.displayName.Size = new System.Drawing.Size(75, 21);
            this.displayName.TextChanged += new System.EventHandler(this.Changed);
            // 
            // displayNameLabel
            // 
            this.displayNameLabel.Location = new System.Drawing.Point(548, 146);
            // 
            // tab
            // 
            this.tab.Location = new System.Drawing.Point(0, 156);
            this.tab.Size = new System.Drawing.Size(829, 439);
            // 
            // tabDocuments
            // 
            this.tabDocuments.Size = new System.Drawing.Size(821, 413);
            // 
            // documentList
            // 
            this.documentList.Size = new System.Drawing.Size(815, 407);
            // 
            // tabPersons
            // 
            this.tabPersons.Size = new System.Drawing.Size(821, 541);
            // 
            // tabAttributes
            // 
            this.tabAttributes.Size = new System.Drawing.Size(821, 541);
            // 
            // attributeList
            // 
            this.attributeList.Size = new System.Drawing.Size(815, 535);
            // 
            // tabLinks
            // 
            this.tabLinks.Size = new System.Drawing.Size(821, 541);
            // 
            // linkList
            // 
            this.linkList.Size = new System.Drawing.Size(815, 535);
            this.linkList.Changed += new System.EventHandler(this.attributeList_Changed);
            // 
            // tabDates
            // 
            this.tabDates.Size = new System.Drawing.Size(821, 541);
            // 
            // dateList
            // 
            this.dateList.Size = new System.Drawing.Size(815, 535);
            this.dateList.Changed += new System.EventHandler(this.attributeList_Changed);
            // 
            // tabCategories
            // 
            this.tabCategories.Size = new System.Drawing.Size(821, 541);
            // 
            // categoryList
            // 
            this.categoryList.Size = new System.Drawing.Size(815, 535);
            this.categoryList.Changed += new System.EventHandler(this.attributeList_Changed);
            // 
            // tabProperties
            // 
            this.tabProperties.Size = new System.Drawing.Size(821, 541);
            // 
            // tabBlobs
            // 
            this.tabBlobs.Size = new System.Drawing.Size(821, 541);
            // 
            // blobList
            // 
            this.blobList.Size = new System.Drawing.Size(815, 535);
            // 
            // number
            // 
            this.number.TextChanged += new System.EventHandler(this.Changed);
            // 
            // propertyList
            // 
            this.propertyList.Size = new System.Drawing.Size(815, 535);
            // 
            // subjectLabel
            // 
            this.subjectLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.subjectLabel.AutoSize = true;
            this.subjectLabel.Location = new System.Drawing.Point(3, 83);
            this.subjectLabel.Name = "subjectLabel";
            this.subjectLabel.Size = new System.Drawing.Size(37, 13);
            this.subjectLabel.TabIndex = 32;
            this.subjectLabel.Text = "Tárgy:";
            // 
            // subject
            // 
            this.subject.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.SetColumnSpan(this.subject, 2);
            this.subject.Location = new System.Drawing.Point(82, 80);
            this.subject.Margin = new System.Windows.Forms.Padding(2);
            this.subject.Name = "subject";
            this.subject.Size = new System.Drawing.Size(370, 20);
            this.subject.TabIndex = 30;
            this.subject.TextChanged += new System.EventHandler(this.Changed);
            this.subject.Leave += new System.EventHandler(this.name_LeaveFocus);
            // 
            // titleLabel
            // 
            this.titleLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.titleLabel.AutoSize = true;
            this.titleLabel.Location = new System.Drawing.Point(3, 32);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(29, 13);
            this.titleLabel.TabIndex = 28;
            this.titleLabel.Text = "Cím:";
            // 
            // title
            // 
            this.title.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.title.Location = new System.Drawing.Point(82, 28);
            this.title.Margin = new System.Windows.Forms.Padding(2);
            this.title.Name = "title";
            this.title.Size = new System.Drawing.Size(183, 20);
            this.title.TabIndex = 45;
            this.title.TextChanged += new System.EventHandler(this.Changed);
            this.title.Leave += new System.EventHandler(this.name_LeaveFocus);
            // 
            // linkFromCompany
            // 
            this.linkFromCompany.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.linkFromCompany.Clickable = true;
            this.linkFromCompany.Collapse = true;
            this.linkFromCompany.Item = null;
            this.linkFromCompany.LabelText = "Feladó:";
            this.linkFromCompany.Location = new System.Drawing.Point(454, 26);
            this.linkFromCompany.Margin = new System.Windows.Forms.Padding(0);
            this.linkFromCompany.Name = "linkFromCompany";
            this.linkFromCompany.ReadOnly = false;
            this.linkFromCompany.Size = new System.Drawing.Size(375, 26);
            this.linkFromCompany.TabIndex = 47;
            this.linkFromCompany.TypeVisible = false;
            this.linkFromCompany.ItemChanged += new System.EventHandler(this.Changed);
            // 
            // linkFromPerson
            // 
            this.linkFromPerson.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.linkFromPerson.Clickable = true;
            this.linkFromPerson.Collapse = true;
            this.linkFromPerson.Item = null;
            this.linkFromPerson.LabelText = "Szerzõ:";
            this.linkFromPerson.Location = new System.Drawing.Point(454, 52);
            this.linkFromPerson.Margin = new System.Windows.Forms.Padding(0);
            this.linkFromPerson.Name = "linkFromPerson";
            this.linkFromPerson.ReadOnly = false;
            this.linkFromPerson.Size = new System.Drawing.Size(375, 24);
            this.linkFromPerson.TabIndex = 48;
            this.linkFromPerson.TypeVisible = false;
            this.linkFromPerson.BeforeEdit += new System.EventHandler(this.linkFromPerson_BeforeEdit);
            this.linkFromPerson.ItemChanged += new System.EventHandler(this.Changed);
            // 
            // linkToCompany
            // 
            this.linkToCompany.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.linkToCompany.Clickable = true;
            this.linkToCompany.Collapse = true;
            this.linkToCompany.Item = null;
            this.linkToCompany.LabelText = "Címzett:";
            this.linkToCompany.Location = new System.Drawing.Point(454, 78);
            this.linkToCompany.Margin = new System.Windows.Forms.Padding(0);
            this.linkToCompany.Name = "linkToCompany";
            this.linkToCompany.ReadOnly = false;
            this.linkToCompany.Size = new System.Drawing.Size(375, 24);
            this.linkToCompany.TabIndex = 49;
            this.linkToCompany.TypeVisible = false;
            this.linkToCompany.ItemChanged += new System.EventHandler(this.Changed);
            // 
            // linkToPerson
            // 
            this.linkToPerson.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.linkToPerson.Clickable = true;
            this.linkToPerson.Collapse = true;
            this.linkToPerson.Item = null;
            this.linkToPerson.LabelText = "Ügyintézõ:";
            this.linkToPerson.Location = new System.Drawing.Point(454, 102);
            this.linkToPerson.Margin = new System.Windows.Forms.Padding(0);
            this.linkToPerson.Name = "linkToPerson";
            this.linkToPerson.ReadOnly = false;
            this.linkToPerson.Size = new System.Drawing.Size(375, 26);
            this.linkToPerson.TabIndex = 50;
            this.linkToPerson.TypeVisible = false;
            this.linkToPerson.BeforeEdit += new System.EventHandler(this.linkToPerson_BeforeEdit);
            this.linkToPerson.ItemChanged += new System.EventHandler(this.Changed);
            // 
            // category
            // 
            this.category.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.category.Collapse = false;
            this.tableLayoutPanel1.SetColumnSpan(this.category, 2);
            this.category.Item = null;
            this.category.LabelText = "Típus:";
            this.category.Location = new System.Drawing.Point(0, 0);
            this.category.Margin = new System.Windows.Forms.Padding(0);
            this.category.Name = "category";
            this.category.ReadOnly = false;
            this.category.Size = new System.Drawing.Size(267, 26);
            this.category.TabIndex = 53;
            this.category.TypeVisible = false;
            this.category.ItemChanged += new System.EventHandler(this.Changed);
            // 
            // direction
            // 
            this.direction.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.direction.Collapse = false;
            this.direction.Item = null;
            this.direction.LabelText = "Irány:";
            this.direction.Location = new System.Drawing.Point(267, 26);
            this.direction.Margin = new System.Windows.Forms.Padding(0);
            this.direction.Name = "direction";
            this.direction.ReadOnly = false;
            this.direction.Size = new System.Drawing.Size(187, 26);
            this.direction.TabIndex = 54;
            this.direction.TypeVisible = false;
            this.direction.ItemChanged += new System.EventHandler(this.Changed);
            // 
            // date
            // 
            this.date.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.date.Collapse = false;
            this.date.Item = null;
            this.date.LabelText = "Kelt:";
            this.date.Location = new System.Drawing.Point(267, 0);
            this.date.Margin = new System.Windows.Forms.Padding(0);
            this.date.Name = "date";
            this.date.ReadOnly = false;
            this.date.Size = new System.Drawing.Size(187, 26);
            this.date.TabIndex = 55;
            this.date.TypeVisible = false;
            this.date.ItemChanged += new System.EventHandler(this.Changed);
            // 
            // brand
            // 
            this.brand.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.brand.Collapse = false;
            this.brand.Item = null;
            this.brand.LabelText = "Gyártó:";
            this.brand.Location = new System.Drawing.Point(454, 0);
            this.brand.Margin = new System.Windows.Forms.Padding(0);
            this.brand.Name = "brand";
            this.brand.ReadOnly = false;
            this.brand.Size = new System.Drawing.Size(375, 26);
            this.brand.TabIndex = 56;
            this.brand.TypeVisible = false;
            this.brand.ItemChanged += new System.EventHandler(this.Changed);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.linkToPerson, 3, 4);
            this.tableLayoutPanel1.Controls.Add(this.brand, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.linkToCompany, 3, 3);
            this.tableLayoutPanel1.Controls.Add(this.linkFromPerson, 3, 2);
            this.tableLayoutPanel1.Controls.Add(this.linkFromCompany, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.direction, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.subject, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.subjectLabel, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.date, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.linkFolder, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.category, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.titleLabel, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.title, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.foreignNumberLabel, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.foreignNumber, 1, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 28);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 5;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(829, 128);
            this.tableLayoutPanel1.TabIndex = 57;
            // 
            // linkFolder
            // 
            this.linkFolder.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.linkFolder.Clickable = true;
            this.linkFolder.Collapse = true;
            this.linkFolder.Item = null;
            this.linkFolder.LabelText = "Mappa:";
            this.linkFolder.Location = new System.Drawing.Point(267, 52);
            this.linkFolder.Margin = new System.Windows.Forms.Padding(0);
            this.linkFolder.Name = "linkFolder";
            this.linkFolder.ReadOnly = false;
            this.linkFolder.Size = new System.Drawing.Size(187, 26);
            this.linkFolder.TabIndex = 57;
            this.linkFolder.TypeVisible = false;
            this.linkFolder.ItemChanged += new System.EventHandler(this.Changed);
            // 
            // foreignNumberLabel
            // 
            this.foreignNumberLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.foreignNumberLabel.AutoSize = true;
            this.foreignNumberLabel.Location = new System.Drawing.Point(3, 58);
            this.foreignNumberLabel.Name = "foreignNumberLabel";
            this.foreignNumberLabel.Size = new System.Drawing.Size(59, 13);
            this.foreignNumberLabel.TabIndex = 58;
            this.foreignNumberLabel.Text = "Partner isz:";
            // 
            // foreignNumber
            // 
            this.foreignNumber.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.foreignNumber.Location = new System.Drawing.Point(83, 55);
            this.foreignNumber.Name = "foreignNumber";
            this.foreignNumber.Size = new System.Drawing.Size(181, 20);
            this.foreignNumber.TabIndex = 59;
            this.foreignNumber.TextChanged += new System.EventHandler(this.Changed);
            // 
            // Document
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "Document";
            this.Size = new System.Drawing.Size(829, 595);
            this.Controls.SetChildIndex(this.tableLayoutPanel1, 0);
            this.Controls.SetChildIndex(this.displayName, 0);
            this.Controls.SetChildIndex(this.displayNameLabel, 0);
            this.Controls.SetChildIndex(this.tab, 0);
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

        private System.Windows.Forms.Label subjectLabel;
        private System.Windows.Forms.TextBox subject;
        private System.Windows.Forms.Label titleLabel;
        private System.Windows.Forms.TextBox title;
        private Link linkFromCompany;
        private Link linkFromPerson;
        private Link linkToCompany;
        private Link linkToPerson;
        private Category category;
        private Category direction;
        private Date date;
        private Category brand;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private Link linkFolder;
        private System.Windows.Forms.Label foreignNumberLabel;
        private System.Windows.Forms.TextBox foreignNumber;
    }
}
