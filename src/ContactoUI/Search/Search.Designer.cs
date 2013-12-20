namespace Contacto.UI
{
    partial class Search
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Search));
            this.split = new System.Windows.Forms.SplitContainer();
            this.panel = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.auto = new System.Windows.Forms.CheckBox();
            this.ok = new System.Windows.Forms.Button();
            this.tab = new System.Windows.Forms.TabControl();
            this.tabSimple = new System.Windows.Forms.TabPage();
            this.entitySearch = new Contacto.UI.EntitySearch();
            this.tabCompanies = new System.Windows.Forms.TabPage();
            this.companySearch = new Contacto.UI.CompanySearch();
            this.tabPersons = new System.Windows.Forms.TabPage();
            this.personSearch = new Contacto.UI.PersonSearch();
            this.tabDocuments = new System.Windows.Forms.TabPage();
            this.documentSearch1 = new Contacto.UI.DocumentSearch();
            this.smallImageList = new System.Windows.Forms.ImageList(this.components);
            this.split.Panel1.SuspendLayout();
            this.split.SuspendLayout();
            this.panel.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.tab.SuspendLayout();
            this.tabSimple.SuspendLayout();
            this.tabCompanies.SuspendLayout();
            this.tabPersons.SuspendLayout();
            this.tabDocuments.SuspendLayout();
            this.SuspendLayout();
            // 
            // split
            // 
            this.split.Dock = System.Windows.Forms.DockStyle.Fill;
            this.split.Location = new System.Drawing.Point(0, 28);
            this.split.Name = "split";
            // 
            // split.Panel1
            // 
            this.split.Panel1.Controls.Add(this.panel);
            this.split.Size = new System.Drawing.Size(747, 611);
            this.split.SplitterDistance = 250;
            this.split.TabIndex = 30;
            // 
            // panel
            // 
            this.panel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel.Controls.Add(this.tableLayoutPanel1);
            this.panel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel.Location = new System.Drawing.Point(0, 0);
            this.panel.Name = "panel";
            this.panel.Size = new System.Drawing.Size(250, 611);
            this.panel.TabIndex = 0;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.auto, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.ok, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.tab, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(246, 607);
            this.tableLayoutPanel1.TabIndex = 42;
            // 
            // auto
            // 
            this.auto.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.auto.AutoSize = true;
            this.auto.Location = new System.Drawing.Point(26, 584);
            this.auto.Margin = new System.Windows.Forms.Padding(26, 3, 3, 3);
            this.auto.Name = "auto";
            this.auto.Size = new System.Drawing.Size(71, 17);
            this.auto.TabIndex = 40;
            this.auto.Text = "Automata";
            this.auto.UseVisualStyleBackColor = true;
            this.auto.Visible = false;
            // 
            // ok
            // 
            this.ok.Location = new System.Drawing.Point(183, 581);
            this.ok.Name = "ok";
            this.ok.Size = new System.Drawing.Size(60, 23);
            this.ok.TabIndex = 39;
            this.ok.Text = "Keresés";
            this.ok.UseVisualStyleBackColor = true;
            this.ok.Click += new System.EventHandler(this.ok_Click);
            // 
            // tab
            // 
            this.tab.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.SetColumnSpan(this.tab, 2);
            this.tab.Controls.Add(this.tabSimple);
            this.tab.Controls.Add(this.tabCompanies);
            this.tab.Controls.Add(this.tabPersons);
            this.tab.Controls.Add(this.tabDocuments);
            this.tab.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.tab.ImageList = this.smallImageList;
            this.tab.Location = new System.Drawing.Point(0, 0);
            this.tab.Margin = new System.Windows.Forms.Padding(0);
            this.tab.Multiline = true;
            this.tab.Name = "tab";
            this.tab.SelectedIndex = 0;
            this.tab.Size = new System.Drawing.Size(246, 578);
            this.tab.TabIndex = 41;
            this.tab.SelectedIndexChanged += new System.EventHandler(this.tab_SelectedIndexChanged);
            // 
            // tabSimple
            // 
            this.tabSimple.Controls.Add(this.entitySearch);
            this.tabSimple.ImageIndex = 5;
            this.tabSimple.Location = new System.Drawing.Point(4, 42);
            this.tabSimple.Name = "tabSimple";
            this.tabSimple.Size = new System.Drawing.Size(238, 532);
            this.tabSimple.TabIndex = 0;
            this.tabSimple.Text = "Egyszerû keresõ";
            this.tabSimple.UseVisualStyleBackColor = true;
            // 
            // entitySearch
            // 
            this.entitySearch.AutoSize = true;
            this.entitySearch.Dock = System.Windows.Forms.DockStyle.Top;
            this.entitySearch.Location = new System.Drawing.Point(0, 0);
            this.entitySearch.Name = "entitySearch";
            this.entitySearch.Size = new System.Drawing.Size(238, 189);
            this.entitySearch.TabIndex = 0;
            // 
            // tabCompanies
            // 
            this.tabCompanies.AutoScroll = true;
            this.tabCompanies.Controls.Add(this.companySearch);
            this.tabCompanies.ImageIndex = 0;
            this.tabCompanies.Location = new System.Drawing.Point(4, 42);
            this.tabCompanies.Name = "tabCompanies";
            this.tabCompanies.Size = new System.Drawing.Size(238, 532);
            this.tabCompanies.TabIndex = 2;
            this.tabCompanies.Text = "Cégkeresõ";
            this.tabCompanies.UseVisualStyleBackColor = true;
            // 
            // companySearch
            // 
            this.companySearch.AutoSize = true;
            this.companySearch.Dock = System.Windows.Forms.DockStyle.Top;
            this.companySearch.Location = new System.Drawing.Point(0, 0);
            this.companySearch.Name = "companySearch";
            this.companySearch.Size = new System.Drawing.Size(238, 330);
            this.companySearch.TabIndex = 0;
            // 
            // tabPersons
            // 
            this.tabPersons.AutoScroll = true;
            this.tabPersons.Controls.Add(this.personSearch);
            this.tabPersons.ImageIndex = 1;
            this.tabPersons.Location = new System.Drawing.Point(4, 42);
            this.tabPersons.Name = "tabPersons";
            this.tabPersons.Size = new System.Drawing.Size(238, 532);
            this.tabPersons.TabIndex = 3;
            this.tabPersons.Text = "Névjegykeresõ";
            this.tabPersons.UseVisualStyleBackColor = true;
            // 
            // personSearch
            // 
            this.personSearch.AutoSize = true;
            this.personSearch.Dock = System.Windows.Forms.DockStyle.Top;
            this.personSearch.Location = new System.Drawing.Point(0, 0);
            this.personSearch.Name = "personSearch";
            this.personSearch.Size = new System.Drawing.Size(238, 290);
            this.personSearch.TabIndex = 0;
            // 
            // tabDocuments
            // 
            this.tabDocuments.Controls.Add(this.documentSearch1);
            this.tabDocuments.ImageIndex = 2;
            this.tabDocuments.Location = new System.Drawing.Point(4, 42);
            this.tabDocuments.Name = "tabDocuments";
            this.tabDocuments.Size = new System.Drawing.Size(238, 532);
            this.tabDocuments.TabIndex = 1;
            this.tabDocuments.Text = "Dokumentum keresõ";
            this.tabDocuments.UseVisualStyleBackColor = true;
            // 
            // documentSearch1
            // 
            this.documentSearch1.AutoSize = true;
            this.documentSearch1.Dock = System.Windows.Forms.DockStyle.Top;
            this.documentSearch1.Location = new System.Drawing.Point(0, 0);
            this.documentSearch1.Name = "documentSearch1";
            this.documentSearch1.Size = new System.Drawing.Size(238, 492);
            this.documentSearch1.TabIndex = 0;
            // 
            // smallImageList
            // 
            this.smallImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("smallImageList.ImageStream")));
            this.smallImageList.TransparentColor = System.Drawing.Color.Transparent;
            this.smallImageList.Images.SetKeyName(0, "company");
            this.smallImageList.Images.SetKeyName(1, "person");
            this.smallImageList.Images.SetKeyName(2, "document");
            this.smallImageList.Images.SetKeyName(3, "folder");
            this.smallImageList.Images.SetKeyName(4, "reminder");
            this.smallImageList.Images.SetKeyName(5, "search");
            // 
            // Search
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.Controls.Add(this.split);
            this.Name = "Search";
            this.Size = new System.Drawing.Size(747, 639);
            this.Load += new System.EventHandler(this.Search_Load);
            this.Controls.SetChildIndex(this.split, 0);
            this.split.Panel1.ResumeLayout(false);
            this.split.ResumeLayout(false);
            this.panel.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tab.ResumeLayout(false);
            this.tabSimple.ResumeLayout(false);
            this.tabSimple.PerformLayout();
            this.tabCompanies.ResumeLayout(false);
            this.tabCompanies.PerformLayout();
            this.tabPersons.ResumeLayout(false);
            this.tabPersons.PerformLayout();
            this.tabDocuments.ResumeLayout(false);
            this.tabDocuments.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer split;
        private System.Windows.Forms.Panel panel;
        private System.Windows.Forms.TabPage tabSimple;
        private System.Windows.Forms.TabPage tabDocuments;
        private System.Windows.Forms.TabPage tabCompanies;
        private System.Windows.Forms.CheckBox auto;
        private System.Windows.Forms.Button ok;
        private System.Windows.Forms.TabPage tabPersons;
        private System.Windows.Forms.ImageList smallImageList;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        public System.Windows.Forms.TabControl tab;
        private CompanySearch companySearch;
        private PersonSearch personSearch;
        private DocumentSearch documentSearch1;
        public EntitySearch entitySearch;
    }
}
