namespace Contacto.UI
{
    partial class BlobList
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BlobList));
            this.listViewMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.menuCheckOut = new System.Windows.Forms.ToolStripMenuItem();
            this.menuCheckIn = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.menuPreview = new System.Windows.Forms.ToolStripMenuItem();
            this.menuSaveAs = new System.Windows.Forms.ToolStripMenuItem();
            this.menuPrint = new System.Windows.Forms.ToolStripMenuItem();
            this.menuDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.menuNew = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.menuColumns = new System.Windows.Forms.ToolStripMenuItem();
            this.menuView = new System.Windows.Forms.ToolStripMenuItem();
            this.menuSmallIcons = new System.Windows.Forms.ToolStripMenuItem();
            this.menuLargeIcons = new System.Windows.Forms.ToolStripMenuItem();
            this.menuList = new System.Windows.Forms.ToolStripMenuItem();
            this.menuDetails = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.toolNew = new System.Windows.Forms.ToolStripDropDownButton();
            this.toolNewFile = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolPreview = new System.Windows.Forms.ToolStripButton();
            this.toolSaveAs = new System.Windows.Forms.ToolStripButton();
            this.toolPrint = new System.Windows.Forms.ToolStripButton();
            this.toolDelete = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolCheckout = new System.Windows.Forms.ToolStripButton();
            this.toolCheckin = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripDropDownButton1 = new System.Windows.Forms.ToolStripDropDownButton();
            this.toolSmallIcons = new System.Windows.Forms.ToolStripMenuItem();
            this.toolLargeIcons = new System.Windows.Forms.ToolStripMenuItem();
            this.toolList = new System.Windows.Forms.ToolStripMenuItem();
            this.toolDetails = new System.Windows.Forms.ToolStripMenuItem();
            this.toolColumns = new System.Windows.Forms.ToolStripButton();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.smallIcons = new System.Windows.Forms.ImageList(this.components);
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.largeIcons = new System.Windows.Forms.ImageList(this.components);
            this.listView = new Contacto.UI.SmartListView();
            this.columnFilename = new System.Windows.Forms.ColumnHeader();
            this.columnSize = new System.Windows.Forms.ColumnHeader();
            this.columnRevision = new System.Windows.Forms.ColumnHeader();
            this.columnCheckedOutBy = new System.Windows.Forms.ColumnHeader();
            this.listViewMenuStrip.SuspendLayout();
            this.toolStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // listViewMenuStrip
            // 
            this.listViewMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuCheckOut,
            this.menuCheckIn,
            this.toolStripSeparator6,
            this.menuPreview,
            this.menuSaveAs,
            this.menuPrint,
            this.menuDelete,
            this.toolStripSeparator4,
            this.menuNew,
            this.toolStripSeparator5,
            this.menuColumns,
            this.menuView});
            this.listViewMenuStrip.Name = "listViewMenuStrip";
            this.listViewMenuStrip.Size = new System.Drawing.Size(243, 220);
            this.listViewMenuStrip.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.listViewMenuStrip_ItemClicked);
            // 
            // menuCheckOut
            // 
            this.menuCheckOut.Image = global::Contacto.UI.Properties.Resources.checkout;
            this.menuCheckOut.Name = "menuCheckOut";
            this.menuCheckOut.Size = new System.Drawing.Size(242, 22);
            this.menuCheckOut.Text = "Megnyitás Szerkesztésre";
            // 
            // menuCheckIn
            // 
            this.menuCheckIn.Image = global::Contacto.UI.Properties.Resources.checkin;
            this.menuCheckIn.Name = "menuCheckIn";
            this.menuCheckIn.Size = new System.Drawing.Size(242, 22);
            this.menuCheckIn.Text = "Szerkesztés Befejezése";
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(239, 6);
            // 
            // menuPreview
            // 
            this.menuPreview.Name = "menuPreview";
            this.menuPreview.Size = new System.Drawing.Size(242, 22);
            this.menuPreview.Text = "Megnyitás";
            // 
            // menuSaveAs
            // 
            this.menuSaveAs.Name = "menuSaveAs";
            this.menuSaveAs.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift)
                        | System.Windows.Forms.Keys.S)));
            this.menuSaveAs.Size = new System.Drawing.Size(242, 22);
            this.menuSaveAs.Text = "Mentés Másként...";
            // 
            // menuPrint
            // 
            this.menuPrint.Name = "menuPrint";
            this.menuPrint.Size = new System.Drawing.Size(242, 22);
            this.menuPrint.Text = "Nyomtatás";
            // 
            // menuDelete
            // 
            this.menuDelete.Name = "menuDelete";
            this.menuDelete.ShortcutKeys = System.Windows.Forms.Keys.Delete;
            this.menuDelete.Size = new System.Drawing.Size(242, 22);
            this.menuDelete.Text = "Törlés";
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(239, 6);
            // 
            // menuNew
            // 
            this.menuNew.Name = "menuNew";
            this.menuNew.Size = new System.Drawing.Size(242, 22);
            this.menuNew.Text = "Új Fájl...";
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(239, 6);
            // 
            // menuColumns
            // 
            this.menuColumns.Name = "menuColumns";
            this.menuColumns.Size = new System.Drawing.Size(242, 22);
            this.menuColumns.Text = "Oszlopok...";
            // 
            // menuView
            // 
            this.menuView.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuSmallIcons,
            this.menuLargeIcons,
            this.menuList,
            this.menuDetails});
            this.menuView.Name = "menuView";
            this.menuView.Size = new System.Drawing.Size(242, 22);
            this.menuView.Text = "Nézet";
            this.menuView.DropDownItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.toolStrip_ItemClicked);
            // 
            // menuSmallIcons
            // 
            this.menuSmallIcons.Name = "menuSmallIcons";
            this.menuSmallIcons.Size = new System.Drawing.Size(141, 22);
            this.menuSmallIcons.Text = "Kis ikonok";
            // 
            // menuLargeIcons
            // 
            this.menuLargeIcons.Name = "menuLargeIcons";
            this.menuLargeIcons.Size = new System.Drawing.Size(141, 22);
            this.menuLargeIcons.Text = "Nagy ikonok";
            // 
            // menuList
            // 
            this.menuList.Name = "menuList";
            this.menuList.Size = new System.Drawing.Size(141, 22);
            this.menuList.Text = "Lista";
            // 
            // menuDetails
            // 
            this.menuDetails.Name = "menuDetails";
            this.menuDetails.Size = new System.Drawing.Size(141, 22);
            this.menuDetails.Text = "Részletek";
            // 
            // toolStrip
            // 
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolNew,
            this.toolPreview,
            this.toolSaveAs,
            this.toolPrint,
            this.toolDelete,
            this.toolStripSeparator1,
            this.toolCheckout,
            this.toolCheckin,
            this.toolStripSeparator2,
            this.toolStripDropDownButton1,
            this.toolColumns});
            this.toolStrip.Location = new System.Drawing.Point(0, 0);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.Size = new System.Drawing.Size(585, 25);
            this.toolStrip.TabIndex = 3;
            this.toolStrip.Text = "toolStrip";
            this.toolStrip.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.toolStrip_ItemClicked);
            // 
            // toolNew
            // 
            this.toolNew.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolNewFile,
            this.toolStripSeparator3});
            this.toolNew.Image = global::Contacto.UI.Properties.Resources._new;
            this.toolNew.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolNew.Name = "toolNew";
            this.toolNew.Size = new System.Drawing.Size(47, 22);
            this.toolNew.Text = "Új";
            // 
            // toolNewFile
            // 
            this.toolNewFile.Name = "toolNewFile";
            this.toolNewFile.Size = new System.Drawing.Size(163, 22);
            this.toolNewFile.Text = "Fájl Beillesztése...";
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(160, 6);
            // 
            // toolPreview
            // 
            this.toolPreview.Image = ((System.Drawing.Image)(resources.GetObject("toolPreview.Image")));
            this.toolPreview.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolPreview.Name = "toolPreview";
            this.toolPreview.Size = new System.Drawing.Size(82, 22);
            this.toolPreview.Text = "Megnyitás";
            // 
            // toolSaveAs
            // 
            this.toolSaveAs.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolSaveAs.Image = global::Contacto.UI.Properties.Resources.save;
            this.toolSaveAs.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolSaveAs.Name = "toolSaveAs";
            this.toolSaveAs.Size = new System.Drawing.Size(23, 22);
            this.toolSaveAs.Text = "Mentés másként";
            // 
            // toolPrint
            // 
            this.toolPrint.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolPrint.Image = global::Contacto.UI.Properties.Resources.print;
            this.toolPrint.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolPrint.Name = "toolPrint";
            this.toolPrint.Size = new System.Drawing.Size(23, 22);
            this.toolPrint.Text = "Nyomtatás";
            // 
            // toolDelete
            // 
            this.toolDelete.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolDelete.Image = global::Contacto.UI.Properties.Resources.delete;
            this.toolDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolDelete.Name = "toolDelete";
            this.toolDelete.Size = new System.Drawing.Size(23, 22);
            this.toolDelete.Text = "Törlés";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // toolCheckout
            // 
            this.toolCheckout.Image = global::Contacto.UI.Properties.Resources.checkout;
            this.toolCheckout.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolCheckout.Name = "toolCheckout";
            this.toolCheckout.Size = new System.Drawing.Size(85, 22);
            this.toolCheckout.Text = "Szerkesztés";
            // 
            // toolCheckin
            // 
            this.toolCheckin.Image = ((System.Drawing.Image)(resources.GetObject("toolCheckin.Image")));
            this.toolCheckin.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolCheckin.Name = "toolCheckin";
            this.toolCheckin.Size = new System.Drawing.Size(110, 22);
            this.toolCheckin.Text = "Szerkesztés kész";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripDropDownButton1
            // 
            this.toolStripDropDownButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripDropDownButton1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolSmallIcons,
            this.toolLargeIcons,
            this.toolList,
            this.toolDetails});
            this.toolStripDropDownButton1.Image = global::Contacto.UI.Properties.Resources.listview;
            this.toolStripDropDownButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton1.Name = "toolStripDropDownButton1";
            this.toolStripDropDownButton1.Size = new System.Drawing.Size(29, 22);
            this.toolStripDropDownButton1.Text = "toolStripDropDownButton1";
            this.toolStripDropDownButton1.DropDownItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.toolStrip_ItemClicked);
            // 
            // toolSmallIcons
            // 
            this.toolSmallIcons.Name = "toolSmallIcons";
            this.toolSmallIcons.Size = new System.Drawing.Size(141, 22);
            this.toolSmallIcons.Text = "Kis ikonok";
            // 
            // toolLargeIcons
            // 
            this.toolLargeIcons.Name = "toolLargeIcons";
            this.toolLargeIcons.Size = new System.Drawing.Size(141, 22);
            this.toolLargeIcons.Text = "Nagy ikonok";
            // 
            // toolList
            // 
            this.toolList.Name = "toolList";
            this.toolList.Size = new System.Drawing.Size(141, 22);
            this.toolList.Text = "Lista";
            // 
            // toolDetails
            // 
            this.toolDetails.Name = "toolDetails";
            this.toolDetails.Size = new System.Drawing.Size(141, 22);
            this.toolDetails.Text = "Részletek";
            // 
            // toolColumns
            // 
            this.toolColumns.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolColumns.Image = global::Contacto.UI.Properties.Resources.columns;
            this.toolColumns.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolColumns.Name = "toolColumns";
            this.toolColumns.Size = new System.Drawing.Size(23, 22);
            this.toolColumns.Text = "toolStripButton2";
            // 
            // openFileDialog
            // 
            this.openFileDialog.Multiselect = true;
            this.openFileDialog.ShowReadOnly = true;
            this.openFileDialog.Title = "Új dokumentum";
            // 
            // smallIcons
            // 
            this.smallIcons.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
            this.smallIcons.ImageSize = new System.Drawing.Size(16, 16);
            this.smallIcons.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // saveFileDialog
            // 
            this.saveFileDialog.Title = "Mentés másként";
            // 
            // folderBrowserDialog
            // 
            this.folderBrowserDialog.Description = "Fájlok mentése";
            // 
            // largeIcons
            // 
            this.largeIcons.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
            this.largeIcons.ImageSize = new System.Drawing.Size(32, 32);
            this.largeIcons.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // listView
            // 
            this.listView.AllowColumnReorder = true;
            this.listView.AllowDrop = true;
            this.listView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnFilename,
            this.columnSize,
            this.columnRevision,
            this.columnCheckedOutBy});
            this.listView.ContextMenuStrip = this.listViewMenuStrip;
            this.listView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView.FullRowSelect = true;
            this.listView.LabelEdit = true;
            this.listView.LargeImageList = this.largeIcons;
            this.listView.Location = new System.Drawing.Point(0, 25);
            this.listView.Name = "listView";
            this.listView.Size = new System.Drawing.Size(585, 395);
            this.listView.SmallImageList = this.smallIcons;
            this.listView.SortByColumn = null;
            this.listView.SortOrder = System.Windows.Forms.SortOrder.None;
            this.listView.TabIndex = 2;
            this.listView.UseCompatibleStateImageBehavior = false;
            this.listView.View = System.Windows.Forms.View.Details;
            this.listView.AfterLabelEdit += new System.Windows.Forms.LabelEditEventHandler(this.listView_AfterLabelEdit);
            this.listView.DoubleClick += new System.EventHandler(this.OperationHandler);
            this.listView.DragDrop += new System.Windows.Forms.DragEventHandler(this.listView_DragDrop);
            this.listView.DragEnter += new System.Windows.Forms.DragEventHandler(this.listView_DragEnter);
            this.listView.KeyDown += new System.Windows.Forms.KeyEventHandler(this.listView_KeyDown);
            this.listView.ItemDrag += new System.Windows.Forms.ItemDragEventHandler(this.listView_ItemDrag);
            // 
            // columnFilename
            // 
            this.columnFilename.Tag = "Filename";
            this.columnFilename.Text = "Fájlnév";
            // 
            // columnSize
            // 
            this.columnSize.Tag = "Size";
            this.columnSize.Text = "Méret";
            // 
            // columnRevision
            // 
            this.columnRevision.Tag = "Revision";
            this.columnRevision.Text = "Változat";
            // 
            // columnCheckedOutBy
            // 
            this.columnCheckedOutBy.Tag = "CheckedOutBy";
            this.columnCheckedOutBy.Text = "Szerkeszti";
            // 
            // BlobList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.listView);
            this.Controls.Add(this.toolStrip);
            this.Name = "BlobList";
            this.Size = new System.Drawing.Size(585, 420);
            this.listViewMenuStrip.ResumeLayout(false);
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.ToolStripButton toolPreview;
        private System.Windows.Forms.ToolStripButton toolDelete;
        private System.Windows.Forms.ContextMenuStrip listViewMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem menuNew;
        private System.Windows.Forms.ToolStripMenuItem menuPreview;
        private System.Windows.Forms.ToolStripMenuItem menuPrint;
        private System.Windows.Forms.ToolStripMenuItem menuSaveAs;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.ToolStripButton toolCheckout;
        private System.Windows.Forms.ToolStripButton toolPrint;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton toolCheckin;
        private System.Windows.Forms.ColumnHeader columnFilename;
        private System.Windows.Forms.ColumnHeader columnSize;
        private System.Windows.Forms.ColumnHeader columnRevision;
        private System.Windows.Forms.ColumnHeader columnCheckedOutBy;
        private System.Windows.Forms.ToolStripMenuItem menuColumns;
        private System.Windows.Forms.ImageList smallIcons;
        private System.Windows.Forms.ToolStripButton toolSaveAs;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton1;
        private System.Windows.Forms.ToolStripMenuItem toolSmallIcons;
        private System.Windows.Forms.ToolStripMenuItem toolLargeIcons;
        private System.Windows.Forms.ToolStripButton toolColumns;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;
        public SmartListView listView;
        private System.Windows.Forms.ImageList largeIcons;
        private System.Windows.Forms.ToolStripMenuItem menuDelete;
        private System.Windows.Forms.ToolStripMenuItem menuView;
        private System.Windows.Forms.ToolStripMenuItem menuSmallIcons;
        private System.Windows.Forms.ToolStripMenuItem menuLargeIcons;
        private System.Windows.Forms.ToolStripMenuItem menuList;
        private System.Windows.Forms.ToolStripMenuItem menuDetails;
        private System.Windows.Forms.ToolStripMenuItem menuCheckOut;
        private System.Windows.Forms.ToolStripMenuItem menuCheckIn;
        private System.Windows.Forms.ToolStripMenuItem toolList;
        private System.Windows.Forms.ToolStripMenuItem toolDetails;
        private System.Windows.Forms.ToolStripDropDownButton toolNew;
        private System.Windows.Forms.ToolStripMenuItem toolNewFile;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;

    }
}
