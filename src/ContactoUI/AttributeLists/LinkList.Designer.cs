namespace Contacto.UI
{
    partial class LinkList
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
            this.listView = new System.Windows.Forms.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolNew = new System.Windows.Forms.ToolStripButton();
            this.toolModify = new System.Windows.Forms.ToolStripButton();
            this.toolDelete = new System.Windows.Forms.ToolStripButton();
            this.listViewMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.menuModify = new System.Windows.Forms.ToolStripMenuItem();
            this.menuCopy = new System.Windows.Forms.ToolStripMenuItem();
            this.menuDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.menuNew = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip1.SuspendLayout();
            this.listViewMenuStrip.SuspendLayout();
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
            this.columnHeader1.Width = 163;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Tag = "Value";
            this.columnHeader2.Text = "Adatok";
            this.columnHeader2.Width = 246;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolNew,
            this.toolModify,
            this.toolDelete});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(585, 25);
            this.toolStrip1.TabIndex = 3;
            this.toolStrip1.Text = "toolStrip1";
            this.toolStrip1.Click += new System.EventHandler(this.OperationHandler);
            // 
            // toolNew
            // 
            this.toolNew.Image = global::Contacto.UI.Properties.Resources._new;
            this.toolNew.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolNew.Name = "toolNew";
            this.toolNew.Size = new System.Drawing.Size(38, 22);
            this.toolNew.Text = "Új";
            this.toolNew.Click += new System.EventHandler(this.OperationHandler);
            // 
            // toolModify
            // 
            this.toolModify.Image = global::Contacto.UI.Properties.Resources.edit;
            this.toolModify.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolModify.Name = "toolModify";
            this.toolModify.Size = new System.Drawing.Size(84, 22);
            this.toolModify.Text = "Módosítás";
            this.toolModify.Click += new System.EventHandler(this.OperationHandler);
            // 
            // toolDelete
            // 
            this.toolDelete.Image = global::Contacto.UI.Properties.Resources.delete;
            this.toolDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolDelete.Name = "toolDelete";
            this.toolDelete.Size = new System.Drawing.Size(61, 22);
            this.toolDelete.Text = "Törlés";
            // 
            // listViewMenuStrip
            // 
            this.listViewMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuModify,
            this.menuCopy,
            this.menuDelete,
            this.menuNew});
            this.listViewMenuStrip.Name = "listViewMenuStrip";
            this.listViewMenuStrip.Size = new System.Drawing.Size(138, 92);
            // 
            // menuModify
            // 
            this.menuModify.Image = global::Contacto.UI.Properties.Resources.edit;
            this.menuModify.Name = "menuModify";
            this.menuModify.Size = new System.Drawing.Size(137, 22);
            this.menuModify.Text = "Módosítás";
            this.menuModify.Click += new System.EventHandler(this.OperationHandler);
            // 
            // menuCopy
            // 
            this.menuCopy.Name = "menuCopy";
            this.menuCopy.Size = new System.Drawing.Size(137, 22);
            this.menuCopy.Text = "Másolás";
            this.menuCopy.Click += new System.EventHandler(this.OperationHandler);
            // 
            // menuDelete
            // 
            this.menuDelete.Image = global::Contacto.UI.Properties.Resources.delete;
            this.menuDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.menuDelete.Name = "menuDelete";
            this.menuDelete.Size = new System.Drawing.Size(137, 22);
            this.menuDelete.Text = "Törlés";
            this.menuDelete.Click += new System.EventHandler(this.OperationHandler);
            // 
            // menuNew
            // 
            this.menuNew.Name = "menuNew";
            this.menuNew.Size = new System.Drawing.Size(137, 22);
            this.menuNew.Text = "Új";
            this.menuNew.Click += new System.EventHandler(this.OperationHandler);
            // 
            // LinkList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.listView);
            this.Controls.Add(this.toolStrip1);
            this.Name = "LinkList";
            this.Size = new System.Drawing.Size(585, 420);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.listViewMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolModify;
        private System.Windows.Forms.ToolStripButton toolDelete;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ToolStripButton toolNew;
        public System.Windows.Forms.ListView listView;
        private System.Windows.Forms.ContextMenuStrip listViewMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem menuModify;
        private System.Windows.Forms.ToolStripMenuItem menuCopy;
        private System.Windows.Forms.ToolStripMenuItem menuDelete;
        private System.Windows.Forms.ToolStripMenuItem menuNew;
    }
}
