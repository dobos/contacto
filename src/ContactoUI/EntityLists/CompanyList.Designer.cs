namespace Contacto.UI
{
    partial class CompanyList
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
            System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CompanyList));
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.toolNew = new System.Windows.Forms.ToolStripButton();
            this.toolOpen = new System.Windows.Forms.ToolStripButton();
            this.toolDelete = new System.Windows.Forms.ToolStripButton();
            this.toolColumns = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripDropDownButton();
            this.toolLargeIcons = new System.Windows.Forms.ToolStripMenuItem();
            this.toolSmallIcons = new System.Windows.Forms.ToolStripMenuItem();
            this.toolList = new System.Windows.Forms.ToolStripMenuItem();
            this.toolDetails = new System.Windows.Forms.ToolStripMenuItem();
            this.toolTiles = new System.Windows.Forms.ToolStripMenuItem();
            this.toolSaveList = new System.Windows.Forms.ToolStripButton();
            this.contextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.menuOpen = new System.Windows.Forms.ToolStripMenuItem();
            this.menuOpenWindow = new System.Windows.Forms.ToolStripMenuItem();
            this.menuDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.menuCopy = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.menuNew = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.menuColumns = new System.Windows.Forms.ToolStripMenuItem();
            this.nézetToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuLargeIcons = new System.Windows.Forms.ToolStripMenuItem();
            this.menuSmallIcons = new System.Windows.Forms.ToolStripMenuItem();
            this.menuList = new System.Windows.Forms.ToolStripMenuItem();
            this.menuDetails = new System.Windows.Forms.ToolStripMenuItem();
            this.menuTiles = new System.Windows.Forms.ToolStripMenuItem();
            this.menuSaveList = new System.Windows.Forms.ToolStripMenuItem();
            this.smallImageList = new System.Windows.Forms.ImageList(this.components);
            this.largeImageList = new System.Windows.Forms.ImageList(this.components);
            this.columnName = new System.Windows.Forms.ColumnHeader();
            this.columnCategory = new System.Windows.Forms.ColumnHeader();
            this.columnIndustry = new System.Windows.Forms.ColumnHeader();
            this.columnAddress = new System.Windows.Forms.ColumnHeader();
            this.columnPhone = new System.Windows.Forms.ColumnHeader();
            this.columnFax = new System.Windows.Forms.ColumnHeader();
            this.columnEmail = new System.Windows.Forms.ColumnHeader();
            toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStrip.SuspendLayout();
            this.contextMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // listView
            // 
            this.listView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnName,
            this.columnCategory,
            this.columnIndustry,
            this.columnAddress,
            this.columnPhone,
            this.columnFax,
            this.columnEmail});
            this.listView.ContextMenuStrip = this.contextMenu;
            this.listView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView.FullRowSelect = true;
            this.listView.LargeImageList = this.largeImageList;
            this.listView.Location = new System.Drawing.Point(0, 25);
            this.listView.Size = new System.Drawing.Size(591, 306);
            this.listView.SmallImageList = this.smallImageList;
            this.listView.TabIndex = 2;
            this.listView.View = System.Windows.Forms.View.Details;
            this.listView.DoubleClick += new System.EventHandler(this.OperationHandler);
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStrip
            // 
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolNew,
            this.toolOpen,
            this.toolDelete,
            toolStripSeparator1,
            this.toolColumns,
            this.toolStripButton2,
            this.toolSaveList});
            this.toolStrip.Location = new System.Drawing.Point(0, 0);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.Size = new System.Drawing.Size(591, 25);
            this.toolStrip.TabIndex = 1;
            this.toolStrip.Text = "toolStrip1";
            // 
            // toolNew
            // 
            this.toolNew.Image = global::Contacto.UI.Properties.Resources.card16;
            this.toolNew.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolNew.Name = "toolNew";
            this.toolNew.Size = new System.Drawing.Size(38, 22);
            this.toolNew.Text = "Új";
            this.toolNew.Click += new System.EventHandler(this.OperationHandler);
            // 
            // toolOpen
            // 
            this.toolOpen.Image = ((System.Drawing.Image)(resources.GetObject("toolOpen.Image")));
            this.toolOpen.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolOpen.Name = "toolOpen";
            this.toolOpen.Size = new System.Drawing.Size(82, 22);
            this.toolOpen.Text = "Megnyitás";
            this.toolOpen.Click += new System.EventHandler(this.OperationHandler);
            // 
            // toolDelete
            // 
            this.toolDelete.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolDelete.Image = global::Contacto.UI.Properties.Resources.delete;
            this.toolDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolDelete.Name = "toolDelete";
            this.toolDelete.Size = new System.Drawing.Size(23, 22);
            this.toolDelete.Text = "toolStripButton2";
            this.toolDelete.Click += new System.EventHandler(this.OperationHandler);
            // 
            // toolColumns
            // 
            this.toolColumns.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolColumns.Image = global::Contacto.UI.Properties.Resources.columns;
            this.toolColumns.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolColumns.Name = "toolColumns";
            this.toolColumns.Size = new System.Drawing.Size(23, 22);
            this.toolColumns.Text = "Oszlopok";
            this.toolColumns.Click += new System.EventHandler(this.OperationHandler);
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton2.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolLargeIcons,
            this.toolSmallIcons,
            this.toolList,
            this.toolDetails,
            this.toolTiles});
            this.toolStripButton2.Image = global::Contacto.UI.Properties.Resources.listview;
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(29, 22);
            this.toolStripButton2.Text = "toolStripButton2";
            // 
            // toolLargeIcons
            // 
            this.toolLargeIcons.Name = "toolLargeIcons";
            this.toolLargeIcons.Size = new System.Drawing.Size(141, 22);
            this.toolLargeIcons.Text = "Nagy ikonok";
            this.toolLargeIcons.Click += new System.EventHandler(this.OperationHandler);
            // 
            // toolSmallIcons
            // 
            this.toolSmallIcons.Name = "toolSmallIcons";
            this.toolSmallIcons.Size = new System.Drawing.Size(141, 22);
            this.toolSmallIcons.Text = "Kis ikonok";
            this.toolSmallIcons.Click += new System.EventHandler(this.OperationHandler);
            // 
            // toolList
            // 
            this.toolList.Name = "toolList";
            this.toolList.Size = new System.Drawing.Size(141, 22);
            this.toolList.Text = "Lista";
            this.toolList.Click += new System.EventHandler(this.OperationHandler);
            // 
            // toolDetails
            // 
            this.toolDetails.Name = "toolDetails";
            this.toolDetails.Size = new System.Drawing.Size(141, 22);
            this.toolDetails.Text = "Részletek";
            this.toolDetails.Click += new System.EventHandler(this.OperationHandler);
            // 
            // toolTiles
            // 
            this.toolTiles.Name = "toolTiles";
            this.toolTiles.Size = new System.Drawing.Size(141, 22);
            this.toolTiles.Text = "Kártyák";
            this.toolTiles.Visible = false;
            this.toolTiles.Click += new System.EventHandler(this.OperationHandler);
            // 
            // toolSaveList
            // 
            this.toolSaveList.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolSaveList.Image = ((System.Drawing.Image)(resources.GetObject("toolSaveList.Image")));
            this.toolSaveList.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolSaveList.Name = "toolSaveList";
            this.toolSaveList.Size = new System.Drawing.Size(23, 22);
            this.toolSaveList.Text = "Lista mentése";
            this.toolSaveList.Click += new System.EventHandler(this.OperationHandler);
            // 
            // contextMenu
            // 
            this.contextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuOpen,
            this.menuOpenWindow,
            this.menuDelete,
            this.menuCopy,
            this.toolStripSeparator2,
            this.menuNew,
            this.toolStripSeparator3,
            this.menuColumns,
            this.nézetToolStripMenuItem,
            this.menuSaveList});
            this.contextMenu.Name = "contextMenu";
            this.contextMenu.Size = new System.Drawing.Size(197, 192);
            // 
            // menuOpen
            // 
            this.menuOpen.Name = "menuOpen";
            this.menuOpen.Size = new System.Drawing.Size(196, 22);
            this.menuOpen.Text = "Megnyitás";
            this.menuOpen.Click += new System.EventHandler(this.OperationHandler);
            // 
            // menuOpenWindow
            // 
            this.menuOpenWindow.Name = "menuOpenWindow";
            this.menuOpenWindow.Size = new System.Drawing.Size(196, 22);
            this.menuOpenWindow.Text = "Megnyitás Új Ablakban";
            this.menuOpenWindow.Click += new System.EventHandler(this.OperationHandler);
            // 
            // menuDelete
            // 
            this.menuDelete.Name = "menuDelete";
            this.menuDelete.ShortcutKeys = System.Windows.Forms.Keys.Delete;
            this.menuDelete.Size = new System.Drawing.Size(196, 22);
            this.menuDelete.Text = "Törlés";
            this.menuDelete.Click += new System.EventHandler(this.OperationHandler);
            // 
            // menuCopy
            // 
            this.menuCopy.Name = "menuCopy";
            this.menuCopy.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.C)));
            this.menuCopy.Size = new System.Drawing.Size(196, 22);
            this.menuCopy.Text = "Másolás";
            this.menuCopy.Click += new System.EventHandler(this.OperationHandler);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(193, 6);
            // 
            // menuNew
            // 
            this.menuNew.Name = "menuNew";
            this.menuNew.Size = new System.Drawing.Size(196, 22);
            this.menuNew.Text = "Új Cég";
            this.menuNew.Click += new System.EventHandler(this.OperationHandler);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(193, 6);
            // 
            // menuColumns
            // 
            this.menuColumns.Name = "menuColumns";
            this.menuColumns.Size = new System.Drawing.Size(196, 22);
            this.menuColumns.Text = "Oszlopok...";
            this.menuColumns.Click += new System.EventHandler(this.OperationHandler);
            // 
            // nézetToolStripMenuItem
            // 
            this.nézetToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuLargeIcons,
            this.menuSmallIcons,
            this.menuList,
            this.menuDetails,
            this.menuTiles});
            this.nézetToolStripMenuItem.Name = "nézetToolStripMenuItem";
            this.nézetToolStripMenuItem.Size = new System.Drawing.Size(196, 22);
            this.nézetToolStripMenuItem.Text = "Nézet";
            // 
            // menuLargeIcons
            // 
            this.menuLargeIcons.Name = "menuLargeIcons";
            this.menuLargeIcons.Size = new System.Drawing.Size(141, 22);
            this.menuLargeIcons.Text = "Nagy ikonok";
            this.menuLargeIcons.Click += new System.EventHandler(this.OperationHandler);
            // 
            // menuSmallIcons
            // 
            this.menuSmallIcons.Name = "menuSmallIcons";
            this.menuSmallIcons.Size = new System.Drawing.Size(141, 22);
            this.menuSmallIcons.Text = "Kis ikonok";
            this.menuSmallIcons.Click += new System.EventHandler(this.OperationHandler);
            // 
            // menuList
            // 
            this.menuList.Name = "menuList";
            this.menuList.Size = new System.Drawing.Size(141, 22);
            this.menuList.Text = "Lista";
            this.menuList.Click += new System.EventHandler(this.OperationHandler);
            // 
            // menuDetails
            // 
            this.menuDetails.Name = "menuDetails";
            this.menuDetails.Size = new System.Drawing.Size(141, 22);
            this.menuDetails.Text = "Részletek";
            this.menuDetails.Click += new System.EventHandler(this.OperationHandler);
            // 
            // menuTiles
            // 
            this.menuTiles.Name = "menuTiles";
            this.menuTiles.Size = new System.Drawing.Size(141, 22);
            this.menuTiles.Text = "Kártyák";
            this.menuTiles.Visible = false;
            this.menuTiles.Click += new System.EventHandler(this.OperationHandler);
            // 
            // menuSaveList
            // 
            this.menuSaveList.Name = "menuSaveList";
            this.menuSaveList.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.menuSaveList.Size = new System.Drawing.Size(196, 22);
            this.menuSaveList.Text = "Lista Mentése...";
            this.menuSaveList.Click += new System.EventHandler(this.OperationHandler);
            // 
            // smallImageList
            // 
            this.smallImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("smallImageList.ImageStream")));
            this.smallImageList.TransparentColor = System.Drawing.Color.Transparent;
            this.smallImageList.Images.SetKeyName(0, "company");
            // 
            // largeImageList
            // 
            this.largeImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("largeImageList.ImageStream")));
            this.largeImageList.TransparentColor = System.Drawing.Color.Transparent;
            this.largeImageList.Images.SetKeyName(0, "company");
            // 
            // columnName
            // 
            this.columnName.Tag = "Name";
            this.columnName.Text = "Név";
            // 
            // columnCategory
            // 
            this.columnCategory.Tag = "Category";
            this.columnCategory.Text = "Kategória";
            // 
            // columnIndustry
            // 
            this.columnIndustry.Tag = "Industry";
            this.columnIndustry.Text = "Iparág";
            // 
            // columnAddress
            // 
            this.columnAddress.Tag = "Address";
            this.columnAddress.Text = "Cím";
            // 
            // columnPhone
            // 
            this.columnPhone.Tag = "Phone";
            this.columnPhone.Text = "Telefon";
            // 
            // columnFax
            // 
            this.columnFax.Tag = "Fax";
            this.columnFax.Text = "Telefax";
            // 
            // columnEmail
            // 
            this.columnEmail.Tag = "Email";
            this.columnEmail.Text = "E-mail";
            // 
            // CompanyList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.toolStrip);
            this.Name = "CompanyList";
            this.Size = new System.Drawing.Size(591, 331);
            this.Controls.SetChildIndex(this.toolStrip, 0);
            this.Controls.SetChildIndex(this.listView, 0);
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            this.contextMenu.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.ToolStripButton toolNew;
        private System.Windows.Forms.ToolStripButton toolOpen;
        private System.Windows.Forms.ToolStripButton toolDelete;
        private System.Windows.Forms.ContextMenuStrip contextMenu;
        private System.Windows.Forms.ToolStripMenuItem menuColumns;
        //public SmartListView listView;
        private System.Windows.Forms.ToolStripMenuItem menuNew;
        private System.Windows.Forms.ToolStripMenuItem menuOpen;
        private System.Windows.Forms.ToolStripMenuItem menuDelete;
        private System.Windows.Forms.ToolStripMenuItem menuCopy;
        private System.Windows.Forms.ToolStripMenuItem menuOpenWindow;
        private System.Windows.Forms.ToolStripButton toolColumns;
        private System.Windows.Forms.ToolStripDropDownButton toolStripButton2;
        private System.Windows.Forms.ToolStripMenuItem toolLargeIcons;
        private System.Windows.Forms.ToolStripMenuItem toolSmallIcons;
        private System.Windows.Forms.ToolStripMenuItem toolList;
        private System.Windows.Forms.ToolStripMenuItem toolDetails;
        private System.Windows.Forms.ToolStripMenuItem nézetToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem menuLargeIcons;
        private System.Windows.Forms.ToolStripMenuItem menuSmallIcons;
        private System.Windows.Forms.ToolStripMenuItem menuList;
        private System.Windows.Forms.ToolStripMenuItem menuDetails;
        private System.Windows.Forms.ToolStripMenuItem toolTiles;
        private System.Windows.Forms.ToolStripMenuItem menuTiles;
        private System.Windows.Forms.ImageList smallImageList;
        private System.Windows.Forms.ImageList largeImageList;
        private System.Windows.Forms.ColumnHeader columnName;
        private System.Windows.Forms.ColumnHeader columnCategory;
        private System.Windows.Forms.ColumnHeader columnIndustry;
        private System.Windows.Forms.ColumnHeader columnAddress;
        private System.Windows.Forms.ColumnHeader columnPhone;
        private System.Windows.Forms.ColumnHeader columnFax;
        private System.Windows.Forms.ColumnHeader columnEmail;
        private System.Windows.Forms.ToolStripButton toolSaveList;
        private System.Windows.Forms.ToolStripMenuItem menuSaveList;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
    }
}
