namespace Contacto.UI
{
    partial class AttributeList
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.ListViewGroup listViewGroup1 = new System.Windows.Forms.ListViewGroup("Címek", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup2 = new System.Windows.Forms.ListViewGroup("Telefonszámok", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup3 = new System.Windows.Forms.ListViewGroup("E-mail címek", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup4 = new System.Windows.Forms.ListViewGroup("Weboldal címek", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup5 = new System.Windows.Forms.ListViewGroup("Azonnali üzenetküldõ azonosítók", System.Windows.Forms.HorizontalAlignment.Left);
            this.listView = new System.Windows.Forms.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.listViewMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.menuModify = new System.Windows.Forms.ToolStripMenuItem();
            this.menuCopy = new System.Windows.Forms.ToolStripMenuItem();
            this.menuDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.menuNew = new System.Windows.Forms.ToolStripMenuItem();
            this.menuNewAddress = new System.Windows.Forms.ToolStripMenuItem();
            this.menuNewIdentifier = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.menuFollowLink = new System.Windows.Forms.ToolStripMenuItem();
            this.menuSaveList = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolNew = new System.Windows.Forms.ToolStripDropDownButton();
            this.toolNewAddress = new System.Windows.Forms.ToolStripMenuItem();
            this.toolNewIdentifier = new System.Windows.Forms.ToolStripMenuItem();
            this.toolModify = new System.Windows.Forms.ToolStripButton();
            this.toolDelete = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolSaveList = new System.Windows.Forms.ToolStripButton();
            this.listViewMenuStrip.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // listView
            // 
            this.listView.AllowColumnReorder = true;
            this.listView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.listView.ContextMenuStrip = this.listViewMenuStrip;
            this.listView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView.FullRowSelect = true;
            listViewGroup1.Header = "Címek";
            listViewGroup1.Name = "address";
            listViewGroup2.Header = "Telefonszámok";
            listViewGroup2.Name = "phone";
            listViewGroup3.Header = "E-mail címek";
            listViewGroup3.Name = "email";
            listViewGroup4.Header = "Weboldal címek";
            listViewGroup4.Name = "web";
            listViewGroup5.Header = "Azonnali üzenetküldõ azonosítók";
            listViewGroup5.Name = "im";
            this.listView.Groups.AddRange(new System.Windows.Forms.ListViewGroup[] {
            listViewGroup1,
            listViewGroup2,
            listViewGroup3,
            listViewGroup4,
            listViewGroup5});
            this.listView.Location = new System.Drawing.Point(0, 25);
            this.listView.Name = "listView";
            this.listView.Size = new System.Drawing.Size(585, 395);
            this.listView.TabIndex = 2;
            this.listView.UseCompatibleStateImageBehavior = false;
            this.listView.View = System.Windows.Forms.View.Details;
            this.listView.DoubleClick += new System.EventHandler(this.OperationHandler);
            this.listView.KeyDown += new System.Windows.Forms.KeyEventHandler(this.listView_KeyDown);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Tag = "Title";
            this.columnHeader1.Text = "Elérhetõség";
            this.columnHeader1.Width = 118;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Tag = "Value";
            this.columnHeader2.Text = "Adatok";
            this.columnHeader2.Width = 354;
            // 
            // listViewMenuStrip
            // 
            this.listViewMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuModify,
            this.menuCopy,
            this.menuDelete,
            this.menuNew,
            this.toolStripSeparator1,
            this.menuFollowLink,
            this.menuSaveList});
            this.listViewMenuStrip.Name = "listViewMenuStrip";
            this.listViewMenuStrip.Size = new System.Drawing.Size(196, 164);
            // 
            // menuModify
            // 
            this.menuModify.Image = global::Contacto.UI.Properties.Resources.edit;
            this.menuModify.Name = "menuModify";
            this.menuModify.ShortcutKeys = System.Windows.Forms.Keys.F2;
            this.menuModify.Size = new System.Drawing.Size(195, 22);
            this.menuModify.Text = "Módosítás";
            this.menuModify.Click += new System.EventHandler(this.OperationHandler);
            // 
            // menuCopy
            // 
            this.menuCopy.Name = "menuCopy";
            this.menuCopy.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.C)));
            this.menuCopy.Size = new System.Drawing.Size(195, 22);
            this.menuCopy.Text = "Másolás";
            this.menuCopy.Click += new System.EventHandler(this.OperationHandler);
            // 
            // menuDelete
            // 
            this.menuDelete.Image = global::Contacto.UI.Properties.Resources.delete;
            this.menuDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.menuDelete.Name = "menuDelete";
            this.menuDelete.ShortcutKeys = System.Windows.Forms.Keys.Delete;
            this.menuDelete.Size = new System.Drawing.Size(195, 22);
            this.menuDelete.Text = "Törlés";
            this.menuDelete.Click += new System.EventHandler(this.OperationHandler);
            // 
            // menuNew
            // 
            this.menuNew.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuNewAddress,
            this.menuNewIdentifier});
            this.menuNew.Name = "menuNew";
            this.menuNew.Size = new System.Drawing.Size(195, 22);
            this.menuNew.Text = "Új";
            // 
            // menuNewAddress
            // 
            this.menuNewAddress.Name = "menuNewAddress";
            this.menuNewAddress.Size = new System.Drawing.Size(270, 22);
            this.menuNewAddress.Text = "Cím...";
            this.menuNewAddress.Click += new System.EventHandler(this.OperationHandler);
            // 
            // menuNewIdentifier
            // 
            this.menuNewIdentifier.Name = "menuNewIdentifier";
            this.menuNewIdentifier.Size = new System.Drawing.Size(270, 22);
            this.menuNewIdentifier.Text = "Telefonszám Vagy Egyéb Azonosító...";
            this.menuNewIdentifier.Click += new System.EventHandler(this.OperationHandler);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(192, 6);
            // 
            // menuFollowLink
            // 
            this.menuFollowLink.Name = "menuFollowLink";
            this.menuFollowLink.Size = new System.Drawing.Size(195, 22);
            this.menuFollowLink.Text = "Hivatkozás Követése";
            this.menuFollowLink.Click += new System.EventHandler(this.OperationHandler);
            // 
            // menuSaveList
            // 
            this.menuSaveList.Name = "menuSaveList";
            this.menuSaveList.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.menuSaveList.Size = new System.Drawing.Size(195, 22);
            this.menuSaveList.Text = "Lista Mentése...";
            this.menuSaveList.Click += new System.EventHandler(this.OperationHandler);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolNew,
            this.toolModify,
            this.toolDelete,
            this.toolStripSeparator2,
            this.toolSaveList});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(585, 25);
            this.toolStrip1.TabIndex = 3;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolNew
            // 
            this.toolNew.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolNewAddress,
            this.toolNewIdentifier});
            this.toolNew.Image = global::Contacto.UI.Properties.Resources._new;
            this.toolNew.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolNew.Name = "toolNew";
            this.toolNew.Size = new System.Drawing.Size(47, 22);
            this.toolNew.Text = "Új";
            // 
            // toolNewAddress
            // 
            this.toolNewAddress.Name = "toolNewAddress";
            this.toolNewAddress.Size = new System.Drawing.Size(267, 22);
            this.toolNewAddress.Text = "Cím...";
            this.toolNewAddress.Click += new System.EventHandler(this.OperationHandler);
            // 
            // toolNewIdentifier
            // 
            this.toolNewIdentifier.Name = "toolNewIdentifier";
            this.toolNewIdentifier.Size = new System.Drawing.Size(267, 22);
            this.toolNewIdentifier.Text = "Telefonszám vagy egyéb azonosító...";
            this.toolNewIdentifier.Click += new System.EventHandler(this.OperationHandler);
            // 
            // toolModify
            // 
            this.toolModify.Image = global::Contacto.UI.Properties.Resources.edit;
            this.toolModify.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolModify.Name = "toolModify";
            this.toolModify.Size = new System.Drawing.Size(82, 22);
            this.toolModify.Text = "Módosítás";
            this.toolModify.Click += new System.EventHandler(this.OperationHandler);
            // 
            // toolDelete
            // 
            this.toolDelete.Image = global::Contacto.UI.Properties.Resources.delete;
            this.toolDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolDelete.Name = "toolDelete";
            this.toolDelete.Size = new System.Drawing.Size(59, 22);
            this.toolDelete.Text = "Törlés";
            this.toolDelete.Click += new System.EventHandler(this.OperationHandler);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // toolSaveList
            // 
            this.toolSaveList.Image = global::Contacto.UI.Properties.Resources.save;
            this.toolSaveList.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolSaveList.Name = "toolSaveList";
            this.toolSaveList.Size = new System.Drawing.Size(99, 22);
            this.toolSaveList.Text = "Lista mentése";
            this.toolSaveList.Click += new System.EventHandler(this.OperationHandler);
            // 
            // AttributeList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.listView);
            this.Controls.Add(this.toolStrip1);
            this.Name = "AttributeList";
            this.Size = new System.Drawing.Size(585, 420);
            this.listViewMenuStrip.ResumeLayout(false);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolModify;
        private System.Windows.Forms.ToolStripButton toolDelete;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ToolStripDropDownButton toolNew;
        private System.Windows.Forms.ToolStripMenuItem toolNewAddress;
        private System.Windows.Forms.ToolStripMenuItem toolNewIdentifier;
        private System.Windows.Forms.ContextMenuStrip listViewMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem menuNew;
        private System.Windows.Forms.ToolStripMenuItem menuNewAddress;
        private System.Windows.Forms.ToolStripMenuItem menuNewIdentifier;
        private System.Windows.Forms.ToolStripMenuItem menuModify;
        private System.Windows.Forms.ToolStripMenuItem menuCopy;
        private System.Windows.Forms.ToolStripMenuItem menuDelete;
        public System.Windows.Forms.ListView listView;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem menuFollowLink;
        private System.Windows.Forms.ToolStripMenuItem menuSaveList;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton toolSaveList;
    }
}
