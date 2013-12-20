namespace Contacto.UI
{
    partial class DocumentSearch
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
            this.documentToPerson = new System.Windows.Forms.TextBox();
            this.label26 = new System.Windows.Forms.Label();
            this.documentToCompany = new System.Windows.Forms.TextBox();
            this.label25 = new System.Windows.Forms.Label();
            this.documentFromPerson = new System.Windows.Forms.TextBox();
            this.label24 = new System.Windows.Forms.Label();
            this.documentFromCompany = new System.Windows.Forms.TextBox();
            this.label23 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.documentDateTo = new System.Windows.Forms.DateTimePicker();
            this.documentQuery = new System.Windows.Forms.TextBox();
            this.label28 = new System.Windows.Forms.Label();
            this.documentNumber = new System.Windows.Forms.TextBox();
            this.documentDateFrom = new System.Windows.Forms.DateTimePicker();
            this.label18 = new System.Windows.Forms.Label();
            this.label27 = new System.Windows.Forms.Label();
            this.documentTitle = new System.Windows.Forms.TextBox();
            this.label21 = new System.Windows.Forms.Label();
            this.documentSubject = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.dropdownPanel1 = new Contacto.UI.DropdownPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.categoryPanel = new Contacto.UI.CategoryPanel();
            this.dropdownPanel2 = new Contacto.UI.DropdownPanel();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel1.SuspendLayout();
            this.dropdownPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.dropdownPanel2.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // documentToPerson
            // 
            this.documentToPerson.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.documentToPerson.Location = new System.Drawing.Point(3, 133);
            this.documentToPerson.Name = "documentToPerson";
            this.documentToPerson.Size = new System.Drawing.Size(200, 20);
            this.documentToPerson.TabIndex = 58;
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Location = new System.Drawing.Point(3, 117);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(57, 13);
            this.label26.TabIndex = 57;
            this.label26.Text = "Ügyintéző:";
            // 
            // documentToCompany
            // 
            this.documentToCompany.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.documentToCompany.Location = new System.Drawing.Point(3, 94);
            this.documentToCompany.Name = "documentToCompany";
            this.documentToCompany.Size = new System.Drawing.Size(200, 20);
            this.documentToCompany.TabIndex = 56;
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Location = new System.Drawing.Point(3, 78);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(46, 13);
            this.label25.TabIndex = 55;
            this.label25.Text = "Címzett:";
            // 
            // documentFromPerson
            // 
            this.documentFromPerson.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.documentFromPerson.Location = new System.Drawing.Point(3, 55);
            this.documentFromPerson.Name = "documentFromPerson";
            this.documentFromPerson.Size = new System.Drawing.Size(200, 20);
            this.documentFromPerson.TabIndex = 54;
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(3, 39);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(42, 13);
            this.label24.TabIndex = 53;
            this.label24.Text = "Szerző:";
            // 
            // documentFromCompany
            // 
            this.documentFromCompany.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.documentFromCompany.Location = new System.Drawing.Point(3, 16);
            this.documentFromCompany.Name = "documentFromCompany";
            this.documentFromCompany.Size = new System.Drawing.Size(200, 20);
            this.documentFromCompany.TabIndex = 52;
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(3, 0);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(42, 13);
            this.label23.TabIndex = 51;
            this.label23.Text = "Feladó:";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(3, 0);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(50, 13);
            this.label17.TabIndex = 39;
            this.label17.Text = "Sorszám:";
            // 
            // documentDateTo
            // 
            this.documentDateTo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.documentDateTo.CustomFormat = "yyyy.MM.dd";
            this.documentDateTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.documentDateTo.Location = new System.Drawing.Point(106, 133);
            this.documentDateTo.Name = "documentDateTo";
            this.documentDateTo.Size = new System.Drawing.Size(97, 20);
            this.documentDateTo.TabIndex = 61;
            // 
            // documentQuery
            // 
            this.documentQuery.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel2.SetColumnSpan(this.documentQuery, 2);
            this.documentQuery.Location = new System.Drawing.Point(3, 172);
            this.documentQuery.Name = "documentQuery";
            this.documentQuery.Size = new System.Drawing.Size(200, 20);
            this.documentQuery.TabIndex = 63;
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Location = new System.Drawing.Point(3, 156);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(75, 13);
            this.label28.TabIndex = 62;
            this.label28.Text = "Fájlokon belül:";
            // 
            // documentNumber
            // 
            this.documentNumber.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel2.SetColumnSpan(this.documentNumber, 2);
            this.documentNumber.Location = new System.Drawing.Point(3, 16);
            this.documentNumber.Name = "documentNumber";
            this.documentNumber.Size = new System.Drawing.Size(200, 20);
            this.documentNumber.TabIndex = 40;
            // 
            // documentDateFrom
            // 
            this.documentDateFrom.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.documentDateFrom.CustomFormat = "yyyy.MM.dd";
            this.documentDateFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.documentDateFrom.Location = new System.Drawing.Point(3, 133);
            this.documentDateFrom.Name = "documentDateFrom";
            this.documentDateFrom.Size = new System.Drawing.Size(97, 20);
            this.documentDateFrom.TabIndex = 60;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(3, 39);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(29, 13);
            this.label18.TabIndex = 41;
            this.label18.Text = "Cím:";
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Location = new System.Drawing.Point(3, 117);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(28, 13);
            this.label27.TabIndex = 59;
            this.label27.Text = "Kelt:";
            // 
            // documentTitle
            // 
            this.documentTitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel2.SetColumnSpan(this.documentTitle, 2);
            this.documentTitle.Location = new System.Drawing.Point(3, 55);
            this.documentTitle.Name = "documentTitle";
            this.documentTitle.Size = new System.Drawing.Size(200, 20);
            this.documentTitle.TabIndex = 42;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(3, 78);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(37, 13);
            this.label21.TabIndex = 47;
            this.label21.Text = "Tárgy:";
            // 
            // documentSubject
            // 
            this.documentSubject.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel2.SetColumnSpan(this.documentSubject, 2);
            this.documentSubject.Location = new System.Drawing.Point(3, 94);
            this.documentSubject.Name = "documentSubject";
            this.documentSubject.Size = new System.Drawing.Size(200, 20);
            this.documentSubject.TabIndex = 48;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.dropdownPanel1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.categoryPanel, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.dropdownPanel2, 0, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(212, 429);
            this.tableLayoutPanel1.TabIndex = 69;
            // 
            // dropdownPanel1
            // 
            this.dropdownPanel1.Controls.Add(this.tableLayoutPanel2);
            this.dropdownPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.dropdownPanel1.Location = new System.Drawing.Point(3, 3);
            this.dropdownPanel1.Name = "dropdownPanel1";
            this.dropdownPanel1.Padding = new System.Windows.Forms.Padding(0, 20, 0, 0);
            this.dropdownPanel1.Size = new System.Drawing.Size(206, 215);
            this.dropdownPanel1.State = Contacto.UI.DropdownPanel.DropdownState.Open;
            this.dropdownPanel1.TabIndex = 0;
            this.dropdownPanel1.Text = "Alapadatok Szerint";
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.AutoSize = true;
            this.tableLayoutPanel2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.documentQuery, 0, 9);
            this.tableLayoutPanel2.Controls.Add(this.documentDateTo, 1, 7);
            this.tableLayoutPanel2.Controls.Add(this.label28, 0, 8);
            this.tableLayoutPanel2.Controls.Add(this.label17, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.documentNumber, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.label18, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.documentTitle, 0, 3);
            this.tableLayoutPanel2.Controls.Add(this.label21, 0, 4);
            this.tableLayoutPanel2.Controls.Add(this.documentDateFrom, 0, 7);
            this.tableLayoutPanel2.Controls.Add(this.documentSubject, 0, 5);
            this.tableLayoutPanel2.Controls.Add(this.label27, 0, 6);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 20);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 10;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.Size = new System.Drawing.Size(206, 195);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // categoryPanel
            // 
            this.categoryPanel.AutoSize = true;
            this.categoryPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.categoryPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.categoryPanel.EntityType = 30000;
            this.categoryPanel.Location = new System.Drawing.Point(3, 224);
            this.categoryPanel.Name = "categoryPanel";
            this.categoryPanel.Size = new System.Drawing.Size(206, 20);
            this.categoryPanel.TabIndex = 1;
            // 
            // dropdownPanel2
            // 
            this.dropdownPanel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dropdownPanel2.Controls.Add(this.tableLayoutPanel3);
            this.dropdownPanel2.Location = new System.Drawing.Point(3, 250);
            this.dropdownPanel2.Name = "dropdownPanel2";
            this.dropdownPanel2.Padding = new System.Windows.Forms.Padding(0, 20, 0, 0);
            this.dropdownPanel2.Size = new System.Drawing.Size(206, 176);
            this.dropdownPanel2.State = Contacto.UI.DropdownPanel.DropdownState.Open;
            this.dropdownPanel2.TabIndex = 2;
            this.dropdownPanel2.Text = "Személyek Szerint";
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.AutoSize = true;
            this.tableLayoutPanel3.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel3.ColumnCount = 1;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel3.Controls.Add(this.label23, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.documentFromCompany, 0, 1);
            this.tableLayoutPanel3.Controls.Add(this.label24, 0, 2);
            this.tableLayoutPanel3.Controls.Add(this.documentToPerson, 0, 7);
            this.tableLayoutPanel3.Controls.Add(this.documentFromPerson, 0, 3);
            this.tableLayoutPanel3.Controls.Add(this.label26, 0, 6);
            this.tableLayoutPanel3.Controls.Add(this.label25, 0, 4);
            this.tableLayoutPanel3.Controls.Add(this.documentToCompany, 0, 5);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(0, 20);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 8;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel3.Size = new System.Drawing.Size(206, 156);
            this.tableLayoutPanel3.TabIndex = 0;
            // 
            // DocumentSearch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "DocumentSearch";
            this.Size = new System.Drawing.Size(212, 774);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.dropdownPanel1.ResumeLayout(false);
            this.dropdownPanel1.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.dropdownPanel2.ResumeLayout(false);
            this.dropdownPanel2.PerformLayout();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.DateTimePicker documentDateTo;
        private System.Windows.Forms.TextBox documentQuery;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.TextBox documentNumber;
        private System.Windows.Forms.DateTimePicker documentDateFrom;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.TextBox documentToPerson;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.TextBox documentTitle;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.TextBox documentToCompany;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.TextBox documentSubject;
        private System.Windows.Forms.TextBox documentFromPerson;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.TextBox documentFromCompany;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private DropdownPanel dropdownPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private CategoryPanel categoryPanel;
        private DropdownPanel dropdownPanel2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
    }
}
