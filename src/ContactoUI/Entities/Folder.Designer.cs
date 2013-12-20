namespace Contacto.UI
{
    partial class Folder
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
            this.titleLabel = new System.Windows.Forms.Label();
            this.title = new System.Windows.Forms.TextBox();
            this.companyLink = new Contacto.UI.Link();
            this.personLink = new Contacto.UI.Link();
            this.orderDate = new Contacto.UI.Date();
            this.dueDate = new Contacto.UI.Date();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.userLink = new Contacto.UI.Link();
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
            this.displayName.Location = new System.Drawing.Point(678, 101);
            this.displayName.Size = new System.Drawing.Size(59, 21);
            this.displayName.TextChanged += new System.EventHandler(this.Changed);
            // 
            // displayNameLabel
            // 
            this.displayNameLabel.Location = new System.Drawing.Point(585, 104);
            // 
            // tab
            // 
            this.tab.Location = new System.Drawing.Point(0, 112);
            this.tab.Size = new System.Drawing.Size(732, 467);
            // 
            // tabDocuments
            // 
            this.tabDocuments.Size = new System.Drawing.Size(724, 441);
            // 
            // documentList
            // 
            this.documentList.Size = new System.Drawing.Size(718, 435);
            // 
            // tabPersons
            // 
            this.tabPersons.Size = new System.Drawing.Size(724, 525);
            // 
            // tabAttributes
            // 
            this.tabAttributes.Size = new System.Drawing.Size(724, 525);
            // 
            // attributeList
            // 
            this.attributeList.Size = new System.Drawing.Size(718, 519);
            // 
            // tabLinks
            // 
            this.tabLinks.Size = new System.Drawing.Size(724, 525);
            // 
            // linkList
            // 
            this.linkList.Size = new System.Drawing.Size(718, 519);
            // 
            // tabDates
            // 
            this.tabDates.Size = new System.Drawing.Size(724, 525);
            // 
            // dateList
            // 
            this.dateList.Size = new System.Drawing.Size(718, 519);
            // 
            // tabCategories
            // 
            this.tabCategories.Size = new System.Drawing.Size(724, 525);
            // 
            // categoryList
            // 
            this.categoryList.Size = new System.Drawing.Size(718, 519);
            // 
            // tabProperties
            // 
            this.tabProperties.Size = new System.Drawing.Size(724, 525);
            // 
            // tabBlobs
            // 
            this.tabBlobs.Size = new System.Drawing.Size(724, 525);
            // 
            // blobList
            // 
            this.blobList.Size = new System.Drawing.Size(718, 519);
            // 
            // number
            // 
            this.number.TextChanged += new System.EventHandler(this.Changed);
            // 
            // propertyList
            // 
            this.propertyList.Size = new System.Drawing.Size(718, 519);
            // 
            // titleLabel
            // 
            this.titleLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.titleLabel.AutoSize = true;
            this.titleLabel.Location = new System.Drawing.Point(3, 6);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(29, 13);
            this.titleLabel.TabIndex = 28;
            this.titleLabel.Text = "Cím:";
            // 
            // title
            // 
            this.title.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.title.Location = new System.Drawing.Point(82, 2);
            this.title.Margin = new System.Windows.Forms.Padding(2);
            this.title.Name = "title";
            this.title.Size = new System.Drawing.Size(322, 20);
            this.title.TabIndex = 45;
            this.title.TextChanged += new System.EventHandler(this.Changed);
            this.title.Leave += new System.EventHandler(this.name_LeaveFocus);
            // 
            // companyLink
            // 
            this.companyLink.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.companyLink.Clickable = true;
            this.companyLink.Collapse = false;
            this.tableLayoutPanel1.SetColumnSpan(this.companyLink, 2);
            this.companyLink.Item = null;
            this.companyLink.LabelText = "Megrendelõ:";
            this.companyLink.Location = new System.Drawing.Point(406, 26);
            this.companyLink.Margin = new System.Windows.Forms.Padding(0);
            this.companyLink.Name = "companyLink";
            this.companyLink.ReadOnly = true;
            this.companyLink.Size = new System.Drawing.Size(326, 26);
            this.companyLink.TabIndex = 46;
            this.companyLink.TypeVisible = false;
            this.companyLink.ItemChanged += new System.EventHandler(this.Changed);
            // 
            // personLink
            // 
            this.personLink.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.personLink.Clickable = true;
            this.personLink.Collapse = false;
            this.tableLayoutPanel1.SetColumnSpan(this.personLink, 2);
            this.personLink.Item = null;
            this.personLink.LabelText = "M. ügyintézõ:";
            this.personLink.Location = new System.Drawing.Point(406, 52);
            this.personLink.Margin = new System.Windows.Forms.Padding(0);
            this.personLink.Name = "personLink";
            this.personLink.ReadOnly = false;
            this.personLink.Size = new System.Drawing.Size(326, 26);
            this.personLink.TabIndex = 47;
            this.personLink.TypeVisible = false;
            this.personLink.BeforeEdit += new System.EventHandler(this.personLink_BeforeEdit);
            this.personLink.ItemChanged += new System.EventHandler(this.Changed);
            // 
            // orderDate
            // 
            this.orderDate.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.orderDate.Collapse = false;
            this.orderDate.Item = null;
            this.orderDate.LabelText = "Megrendelve:";
            this.orderDate.Location = new System.Drawing.Point(406, 0);
            this.orderDate.Margin = new System.Windows.Forms.Padding(0);
            this.orderDate.Name = "orderDate";
            this.orderDate.ReadOnly = false;
            this.orderDate.Size = new System.Drawing.Size(162, 26);
            this.orderDate.TabIndex = 48;
            this.orderDate.TypeVisible = false;
            this.orderDate.ItemChanged += new System.EventHandler(this.Changed);
            // 
            // dueDate
            // 
            this.dueDate.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dueDate.Collapse = false;
            this.dueDate.Item = null;
            this.dueDate.LabelText = "Határidõ:";
            this.dueDate.Location = new System.Drawing.Point(568, 0);
            this.dueDate.Margin = new System.Windows.Forms.Padding(0);
            this.dueDate.Name = "dueDate";
            this.dueDate.ReadOnly = false;
            this.dueDate.Size = new System.Drawing.Size(164, 26);
            this.dueDate.TabIndex = 49;
            this.dueDate.TypeVisible = false;
            this.dueDate.ItemChanged += new System.EventHandler(this.Changed);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.12407F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 24.93796F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 24.93796F));
            this.tableLayoutPanel1.Controls.Add(this.userLink, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.titleLabel, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.orderDate, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.personLink, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.title, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.companyLink, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.dueDate, 3, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 28);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.Padding = new System.Windows.Forms.Padding(0, 0, 0, 6);
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(732, 84);
            this.tableLayoutPanel1.TabIndex = 50;
            // 
            // userLink
            // 
            this.userLink.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.userLink.Clickable = true;
            this.userLink.Collapse = false;
            this.tableLayoutPanel1.SetColumnSpan(this.userLink, 2);
            this.userLink.Item = null;
            this.userLink.LabelText = "Ügyintézõ:";
            this.userLink.Location = new System.Drawing.Point(0, 52);
            this.userLink.Margin = new System.Windows.Forms.Padding(0);
            this.userLink.Name = "userLink";
            this.userLink.ReadOnly = false;
            this.userLink.Size = new System.Drawing.Size(406, 26);
            this.userLink.TabIndex = 50;
            this.userLink.TypeVisible = false;
            this.userLink.ItemChanged += new System.EventHandler(this.Changed);
            // 
            // Folder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "Folder";
            this.Size = new System.Drawing.Size(732, 579);
            this.Controls.SetChildIndex(this.tableLayoutPanel1, 0);
            this.Controls.SetChildIndex(this.displayNameLabel, 0);
            this.Controls.SetChildIndex(this.displayName, 0);
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

        private System.Windows.Forms.Label titleLabel;
        private System.Windows.Forms.TextBox title;
        private Link companyLink;
        private Link personLink;
        private Date orderDate;
        private Date dueDate;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private Link userLink;
    }
}
