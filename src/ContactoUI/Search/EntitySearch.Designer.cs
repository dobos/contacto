namespace Contacto.UI
{
    partial class EntitySearch
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
            this.simpleTable = new System.Windows.Forms.TableLayoutPanel();
            this.includeReminders = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.query = new System.Windows.Forms.TextBox();
            this.includeDocuments = new System.Windows.Forms.CheckBox();
            this.includeCompanies = new System.Windows.Forms.CheckBox();
            this.includePersons = new System.Windows.Forms.CheckBox();
            this.includeFolders = new System.Windows.Forms.CheckBox();
            this.simpleTable.SuspendLayout();
            this.SuspendLayout();
            // 
            // simpleTable
            // 
            this.simpleTable.AutoSize = true;
            this.simpleTable.ColumnCount = 1;
            this.simpleTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.simpleTable.Controls.Add(this.includeReminders, 0, 7);
            this.simpleTable.Controls.Add(this.label2, 0, 0);
            this.simpleTable.Controls.Add(this.label1, 0, 2);
            this.simpleTable.Controls.Add(this.query, 0, 1);
            this.simpleTable.Controls.Add(this.includeDocuments, 0, 6);
            this.simpleTable.Controls.Add(this.includeCompanies, 0, 3);
            this.simpleTable.Controls.Add(this.includePersons, 0, 4);
            this.simpleTable.Controls.Add(this.includeFolders, 0, 5);
            this.simpleTable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.simpleTable.Location = new System.Drawing.Point(0, 0);
            this.simpleTable.Name = "simpleTable";
            this.simpleTable.Padding = new System.Windows.Forms.Padding(6);
            this.simpleTable.RowCount = 9;
            this.simpleTable.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.simpleTable.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.simpleTable.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.simpleTable.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.simpleTable.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.simpleTable.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.simpleTable.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.simpleTable.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.simpleTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.simpleTable.Size = new System.Drawing.Size(238, 188);
            this.simpleTable.TabIndex = 46;
            // 
            // includeReminders
            // 
            this.includeReminders.AutoSize = true;
            this.includeReminders.Checked = true;
            this.includeReminders.CheckState = System.Windows.Forms.CheckState.Checked;
            this.includeReminders.Location = new System.Drawing.Point(15, 162);
            this.includeReminders.Margin = new System.Windows.Forms.Padding(9, 3, 3, 3);
            this.includeReminders.Name = "includeReminders";
            this.includeReminders.Size = new System.Drawing.Size(90, 17);
            this.includeReminders.TabIndex = 43;
            this.includeReminders.Text = "Emlékeztetők";
            this.includeReminders.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 6);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(105, 13);
            this.label2.TabIndex = 37;
            this.label2.Text = "Keresendő kifejezés:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 51);
            this.label1.Margin = new System.Windows.Forms.Padding(3, 6, 3, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(106, 13);
            this.label1.TabIndex = 44;
            this.label1.Text = "Keresés ezek között:";
            // 
            // query
            // 
            this.query.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.query.Location = new System.Drawing.Point(9, 22);
            this.query.Name = "query";
            this.query.Size = new System.Drawing.Size(220, 20);
            this.query.TabIndex = 38;
            // 
            // includeDocuments
            // 
            this.includeDocuments.AutoSize = true;
            this.includeDocuments.Checked = true;
            this.includeDocuments.CheckState = System.Windows.Forms.CheckState.Checked;
            this.includeDocuments.Location = new System.Drawing.Point(15, 139);
            this.includeDocuments.Margin = new System.Windows.Forms.Padding(9, 3, 3, 3);
            this.includeDocuments.Name = "includeDocuments";
            this.includeDocuments.Size = new System.Drawing.Size(101, 17);
            this.includeDocuments.TabIndex = 42;
            this.includeDocuments.Text = "Dokumentumok";
            this.includeDocuments.UseVisualStyleBackColor = true;
            // 
            // includeCompanies
            // 
            this.includeCompanies.AutoSize = true;
            this.includeCompanies.Checked = true;
            this.includeCompanies.CheckState = System.Windows.Forms.CheckState.Checked;
            this.includeCompanies.Location = new System.Drawing.Point(15, 70);
            this.includeCompanies.Margin = new System.Windows.Forms.Padding(9, 3, 3, 3);
            this.includeCompanies.Name = "includeCompanies";
            this.includeCompanies.Size = new System.Drawing.Size(57, 17);
            this.includeCompanies.TabIndex = 39;
            this.includeCompanies.Text = "Cégek";
            this.includeCompanies.UseVisualStyleBackColor = true;
            // 
            // includePersons
            // 
            this.includePersons.AutoSize = true;
            this.includePersons.Checked = true;
            this.includePersons.CheckState = System.Windows.Forms.CheckState.Checked;
            this.includePersons.Location = new System.Drawing.Point(15, 93);
            this.includePersons.Margin = new System.Windows.Forms.Padding(9, 3, 3, 3);
            this.includePersons.Name = "includePersons";
            this.includePersons.Size = new System.Drawing.Size(77, 17);
            this.includePersons.TabIndex = 40;
            this.includePersons.Text = "Névjegyek";
            this.includePersons.UseVisualStyleBackColor = true;
            // 
            // includeFolders
            // 
            this.includeFolders.AutoSize = true;
            this.includeFolders.Checked = true;
            this.includeFolders.CheckState = System.Windows.Forms.CheckState.Checked;
            this.includeFolders.Location = new System.Drawing.Point(15, 116);
            this.includeFolders.Margin = new System.Windows.Forms.Padding(9, 3, 3, 3);
            this.includeFolders.Name = "includeFolders";
            this.includeFolders.Size = new System.Drawing.Size(65, 17);
            this.includeFolders.TabIndex = 41;
            this.includeFolders.Text = "Mappák";
            this.includeFolders.UseVisualStyleBackColor = true;
            // 
            // EntitySearch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.Controls.Add(this.simpleTable);
            this.Name = "EntitySearch";
            this.Size = new System.Drawing.Size(238, 188);
            this.simpleTable.ResumeLayout(false);
            this.simpleTable.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel simpleTable;
        private System.Windows.Forms.CheckBox includeReminders;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.TextBox query;
        private System.Windows.Forms.CheckBox includeDocuments;
        private System.Windows.Forms.CheckBox includeCompanies;
        private System.Windows.Forms.CheckBox includePersons;
        private System.Windows.Forms.CheckBox includeFolders;
    }
}
