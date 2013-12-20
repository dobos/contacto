namespace Contacto.UI
{
    partial class DocumentList
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DocumentList));
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.toolNewFolder = new System.Windows.Forms.ToolStripButton();
            this.toolNew = new System.Windows.Forms.ToolStripDropDownButton();
            this.toolNewInternal = new System.Windows.Forms.ToolStripMenuItem();
            this.toolNewInbound = new System.Windows.Forms.ToolStripMenuItem();
            this.toolNewOutbound = new System.Windows.Forms.ToolStripMenuItem();
            this.toolOpen = new System.Windows.Forms.ToolStripButton();
            this.toolDelete = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolColumns = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripDropDownButton();
            this.toolLargeIcons = new System.Windows.Forms.ToolStripMenuItem();
            this.toolSmallIcons = new System.Windows.Forms.ToolStripMenuItem();
            this.toolList = new System.Windows.Forms.ToolStripMenuItem();
            this.toolDetails = new System.Windows.Forms.ToolStripMenuItem();
            this.toolTiles = new System.Windows.Forms.ToolStripMenuItem();
            this.toolSaveList = new System.Windows.Forms.ToolStripButton();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.treeView = new System.Windows.Forms.TreeView();
            this.columnTitle = new System.Windows.Forms.ColumnHeader();
            this.columnSubject = new System.Windows.Forms.ColumnHeader();
            this.columnForeignNumber = new System.Windows.Forms.ColumnHeader();
            this.columnCategory = new System.Windows.Forms.ColumnHeader();
            this.columnDate = new System.Windows.Forms.ColumnHeader();
            this.columnDirection = new System.Windows.Forms.ColumnHeader();
            this.columnBrand = new System.Windows.Forms.ColumnHeader();
            this.columnFromCompany = new System.Windows.Forms.ColumnHeader();
            this.columnFromPerson = new System.Windows.Forms.ColumnHeader();
            this.columnToCompany = new System.Windows.Forms.ColumnHeader();
            this.columnToPerson = new System.Windows.Forms.ColumnHeader();
            this.columnFolder = new System.Windows.Forms.ColumnHeader();
            this.contextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.menuOpen = new System.Windows.Forms.ToolStripMenuItem();
            this.menuOpenWindow = new System.Windows.Forms.ToolStripMenuItem();
            this.menuDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.menuCopy = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.menuNewFolder = new System.Windows.Forms.ToolStripMenuItem();
            this.menuNew = new System.Windows.Forms.ToolStripMenuItem();
            this.menuNewInternal = new System.Windows.Forms.ToolStripMenuItem();
            this.menuNewInbound = new System.Windows.Forms.ToolStripMenuItem();
            this.menuNewOutbound = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.menuColumns = new System.Windows.Forms.ToolStripMenuItem();
            this.nézetToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuLargeIcons = new System.Windows.Forms.ToolStripMenuItem();
            this.menuSmallIcons = new System.Windows.Forms.ToolStripMenuItem();
            this.menuList = new System.Windows.Forms.ToolStripMenuItem();
            this.menuDetails = new System.Windows.Forms.ToolStripMenuItem();
            this.menuTiles = new System.Windows.Forms.ToolStripMenuItem();
            this.menuSaveList = new System.Windows.Forms.ToolStripMenuItem();
            this.largeImageList = new System.Windows.Forms.ImageList(this.components);
            this.smallImageList = new System.Windows.Forms.ImageList(this.components);
            this.toolStrip.SuspendLayout();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.contextMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // listView
            // 
            this.listView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnTitle,
            this.columnSubject,
            this.columnForeignNumber,
            this.columnCategory,
            this.columnDate,
            this.columnDirection,
            this.columnBrand,
            this.columnFromCompany,
            this.columnFromPerson,
            this.columnToCompany,
            this.columnToPerson,
            this.columnFolder});
            this.listView.ContextMenuStrip = this.contextMenu;
            this.listView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView.FullRowSelect = true;
            this.listView.LargeImageList = this.largeImageList;
            this.listView.Location = new System.Drawing.Point(0, 0);
            this.listView.Size = new System.Drawing.Size(471, 392);
            this.listView.SmallImageList = this.smallImageList;
            this.listView.View = System.Windows.Forms.View.Details;
            this.listView.DoubleClick += new System.EventHandler(this.OperationHandler);
            // 
            // toolStrip
            // 
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolNewFolder,
            this.toolNew,
            this.toolOpen,
            this.toolDelete,
            this.toolStripSeparator1,
            this.toolColumns,
            this.toolStripButton2,
            this.toolSaveList});
            this.toolStrip.Location = new System.Drawing.Point(0, 0);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.Size = new System.Drawing.Size(712, 25);
            this.toolStrip.TabIndex = 0;
            this.toolStrip.Text = "toolStrip1";
            // 
            // toolNewFolder
            // 
            this.toolNewFolder.Image = ((System.Drawing.Image)(resources.GetObject("toolNewFolder.Image")));
            this.toolNewFolder.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolNewFolder.Name = "toolNewFolder";
            this.toolNewFolder.Size = new System.Drawing.Size(78, 22);
            this.toolNewFolder.Text = "Új mappa";
            this.toolNewFolder.Click += new System.EventHandler(this.OperationHandler);
            // 
            // toolNew
            // 
            this.toolNew.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolNewInternal,
            this.toolNewInbound,
            this.toolNewOutbound});
            this.toolNew.Image = global::Contacto.UI.Properties.Resources._new;
            this.toolNew.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolNew.Name = "toolNew";
            this.toolNew.Size = new System.Drawing.Size(47, 22);
            this.toolNew.Text = "Új";
            // 
            // toolNewInternal
            // 
            this.toolNewInternal.Name = "toolNewInternal";
            this.toolNewInternal.Size = new System.Drawing.Size(191, 22);
            this.toolNewInternal.Text = "Belsõ dokumentum";
            this.toolNewInternal.Click += new System.EventHandler(this.OperationHandler);
            // 
            // toolNewInbound
            // 
            this.toolNewInbound.Name = "toolNewInbound";
            this.toolNewInbound.Size = new System.Drawing.Size(191, 22);
            this.toolNewInbound.Text = "Bejövõ dokumentum";
            this.toolNewInbound.Click += new System.EventHandler(this.OperationHandler);
            // 
            // toolNewOutbound
            // 
            this.toolNewOutbound.Name = "toolNewOutbound";
            this.toolNewOutbound.Size = new System.Drawing.Size(191, 22);
            this.toolNewOutbound.Text = "Kimenõ dokumentum";
            this.toolNewOutbound.Click += new System.EventHandler(this.OperationHandler);
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
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
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
            this.toolSaveList.Image = global::Contacto.UI.Properties.Resources.save;
            this.toolSaveList.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolSaveList.Name = "toolSaveList";
            this.toolSaveList.Size = new System.Drawing.Size(23, 22);
            this.toolSaveList.Text = "toolStripButton1";
            this.toolSaveList.Click += new System.EventHandler(this.OperationHandler);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 25);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.treeView);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.listView);
            this.splitContainer1.Size = new System.Drawing.Size(712, 392);
            this.splitContainer1.SplitterDistance = 237;
            this.splitContainer1.TabIndex = 1;
            // 
            // treeView
            // 
            this.treeView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeView.Location = new System.Drawing.Point(0, 0);
            this.treeView.Name = "treeView";
            this.treeView.Size = new System.Drawing.Size(237, 392);
            this.treeView.TabIndex = 0;
            this.treeView.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.treeView_NodeMouseDoubleClick);
            this.treeView.BeforeExpand += new System.Windows.Forms.TreeViewCancelEventHandler(this.treeView_BeforeExpand);
            this.treeView.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.treeView_NodeMouseClick);
            // 
            // columnTitle
            // 
            this.columnTitle.Tag = "Title";
            this.columnTitle.Text = "Cím";
            // 
            // columnSubject
            // 
            this.columnSubject.Tag = "Subject";
            this.columnSubject.Text = "Tárgy";
            // 
            // columnForeignNumber
            // 
            this.columnForeignNumber.Tag = "Number";
            this.columnForeignNumber.Text = "Partner iktatószáma:";
            // 
            // columnCategory
            // 
            this.columnCategory.Tag = "Category";
            this.columnCategory.Text = "Típus";
            // 
            // columnDate
            // 
            this.columnDate.Tag = "Date";
            this.columnDate.Text = "Kelt";
            // 
            // columnDirection
            // 
            this.columnDirection.Tag = "Direction";
            this.columnDirection.Text = "Irány";
            // 
            // columnBrand
            // 
            this.columnBrand.Tag = "Brand";
            this.columnBrand.Text = "Gyártó";
            // 
            // columnFromCompany
            // 
            this.columnFromCompany.Tag = "FromCompany";
            this.columnFromCompany.Text = "Feladó";
            // 
            // columnFromPerson
            // 
            this.columnFromPerson.Tag = "FromPerson";
            this.columnFromPerson.Text = "Szerzõ";
            // 
            // columnToCompany
            // 
            this.columnToCompany.Tag = "ToCompany";
            this.columnToCompany.Text = "Címzett";
            // 
            // columnToPerson
            // 
            this.columnToPerson.Tag = "ToPerson";
            this.columnToPerson.Text = "Ügyintézõ";
            // 
            // columnFolder
            // 
            this.columnFolder.Tag = "Folder";
            this.columnFolder.Text = "Mappa";
            // 
            // contextMenu
            // 
            this.contextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuOpen,
            this.menuOpenWindow,
            this.menuDelete,
            this.menuCopy,
            this.toolStripSeparator2,
            this.menuNewFolder,
            this.menuNew,
            this.toolStripSeparator3,
            this.menuColumns,
            this.nézetToolStripMenuItem,
            this.menuSaveList});
            this.contextMenu.Name = "contextMenu";
            this.contextMenu.Size = new System.Drawing.Size(197, 214);
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
            // menuNewFolder
            // 
            this.menuNewFolder.Name = "menuNewFolder";
            this.menuNewFolder.Size = new System.Drawing.Size(196, 22);
            this.menuNewFolder.Text = "Új Mappa";
            this.menuNewFolder.Click += new System.EventHandler(this.OperationHandler);
            // 
            // menuNew
            // 
            this.menuNew.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuNewInternal,
            this.menuNewInbound,
            this.menuNewOutbound});
            this.menuNew.Name = "menuNew";
            this.menuNew.Size = new System.Drawing.Size(196, 22);
            this.menuNew.Text = "Új Dokumentum";
            // 
            // menuNewInternal
            // 
            this.menuNewInternal.Name = "menuNewInternal";
            this.menuNewInternal.Size = new System.Drawing.Size(192, 22);
            this.menuNewInternal.Text = "Belsõ Dokumentum";
            this.menuNewInternal.Click += new System.EventHandler(this.OperationHandler);
            // 
            // menuNewInbound
            // 
            this.menuNewInbound.Name = "menuNewInbound";
            this.menuNewInbound.Size = new System.Drawing.Size(192, 22);
            this.menuNewInbound.Text = "Bejövõ Dokumentum";
            this.menuNewInbound.Click += new System.EventHandler(this.OperationHandler);
            // 
            // menuNewOutbound
            // 
            this.menuNewOutbound.Name = "menuNewOutbound";
            this.menuNewOutbound.Size = new System.Drawing.Size(192, 22);
            this.menuNewOutbound.Text = "Kimenõ Dokumentum";
            this.menuNewOutbound.Click += new System.EventHandler(this.OperationHandler);
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
            // largeImageList
            // 
            this.largeImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("largeImageList.ImageStream")));
            this.largeImageList.TransparentColor = System.Drawing.Color.Transparent;
            this.largeImageList.Images.SetKeyName(0, "document");
            // 
            // smallImageList
            // 
            this.smallImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("smallImageList.ImageStream")));
            this.smallImageList.TransparentColor = System.Drawing.Color.Transparent;
            this.smallImageList.Images.SetKeyName(0, "document");
            // 
            // DocumentList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.toolStrip);
            this.Name = "DocumentList";
            this.Size = new System.Drawing.Size(712, 417);
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.contextMenu.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TreeView treeView;
        private System.Windows.Forms.ColumnHeader columnTitle;
        private System.Windows.Forms.ColumnHeader columnSubject;
        private System.Windows.Forms.ToolStripButton toolOpen;
        private System.Windows.Forms.ToolStripButton toolDelete;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton toolColumns;
        private System.Windows.Forms.ToolStripDropDownButton toolStripButton2;
        private System.Windows.Forms.ToolStripMenuItem toolLargeIcons;
        private System.Windows.Forms.ToolStripMenuItem toolSmallIcons;
        //public SmartListView listView;
        private System.Windows.Forms.ColumnHeader columnForeignNumber;
        private System.Windows.Forms.ToolStripMenuItem toolList;
        private System.Windows.Forms.ToolStripMenuItem toolDetails;
        private System.Windows.Forms.ToolStripMenuItem toolTiles;
        private System.Windows.Forms.ContextMenuStrip contextMenu;
        private System.Windows.Forms.ToolStripMenuItem menuOpen;
        private System.Windows.Forms.ToolStripMenuItem menuOpenWindow;
        private System.Windows.Forms.ToolStripMenuItem menuDelete;
        private System.Windows.Forms.ToolStripMenuItem menuCopy;
        private System.Windows.Forms.ToolStripMenuItem menuNew;
        private System.Windows.Forms.ToolStripMenuItem menuColumns;
        private System.Windows.Forms.ToolStripMenuItem nézetToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem menuLargeIcons;
        private System.Windows.Forms.ToolStripMenuItem menuSmallIcons;
        private System.Windows.Forms.ToolStripMenuItem menuList;
        private System.Windows.Forms.ToolStripMenuItem menuDetails;
        private System.Windows.Forms.ToolStripMenuItem menuTiles;
        private System.Windows.Forms.ImageList smallImageList;
        private System.Windows.Forms.ImageList largeImageList;
        private System.Windows.Forms.ColumnHeader columnCategory;
        private System.Windows.Forms.ColumnHeader columnDate;
        private System.Windows.Forms.ColumnHeader columnDirection;
        private System.Windows.Forms.ColumnHeader columnBrand;
        private System.Windows.Forms.ColumnHeader columnFromCompany;
        private System.Windows.Forms.ColumnHeader columnFromPerson;
        private System.Windows.Forms.ColumnHeader columnToCompany;
        private System.Windows.Forms.ColumnHeader columnToPerson;
        private System.Windows.Forms.ColumnHeader columnFolder;
        private System.Windows.Forms.ToolStripButton toolNewFolder;
        private System.Windows.Forms.ToolStripMenuItem menuNewFolder;
        private System.Windows.Forms.ToolStripMenuItem menuNewInternal;
        private System.Windows.Forms.ToolStripMenuItem menuNewInbound;
        private System.Windows.Forms.ToolStripMenuItem menuNewOutbound;
        private System.Windows.Forms.ToolStripDropDownButton toolNew;
        private System.Windows.Forms.ToolStripMenuItem toolNewInternal;
        private System.Windows.Forms.ToolStripMenuItem toolNewInbound;
        private System.Windows.Forms.ToolStripMenuItem toolNewOutbound;
        private System.Windows.Forms.ToolStripButton toolSaveList;
        private System.Windows.Forms.ToolStripMenuItem menuSaveList;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
    }
}
