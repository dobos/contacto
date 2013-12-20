namespace Contacto.UI
{
    partial class PersonSearch
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
            this.personTable = new System.Windows.Forms.TableLayoutPanel();
            this.dropdownPanel1 = new Contacto.UI.DropdownPanel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lastName = new System.Windows.Forms.TextBox();
            this.firstName = new System.Windows.Forms.TextBox();
            this.categoryPanel = new Contacto.UI.CategoryPanel();
            this.dropdownPanel2 = new Contacto.UI.DropdownPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.personEmail = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.personPhone = new System.Windows.Forms.TextBox();
            this.personMobile = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.personTable.SuspendLayout();
            this.dropdownPanel1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.dropdownPanel2.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // personTable
            // 
            this.personTable.AutoSize = true;
            this.personTable.ColumnCount = 1;
            this.personTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.personTable.Controls.Add(this.dropdownPanel1, 0, 0);
            this.personTable.Controls.Add(this.categoryPanel, 0, 1);
            this.personTable.Controls.Add(this.dropdownPanel2, 0, 2);
            this.personTable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.personTable.Location = new System.Drawing.Point(0, 0);
            this.personTable.Margin = new System.Windows.Forms.Padding(4);
            this.personTable.Name = "personTable";
            this.personTable.Padding = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.personTable.RowCount = 3;
            this.personTable.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.personTable.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.personTable.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.personTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.personTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.personTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.personTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.personTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.personTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.personTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.personTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.personTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.personTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.personTable.Size = new System.Drawing.Size(221, 462);
            this.personTable.TabIndex = 53;
            // 
            // dropdownPanel1
            // 
            this.dropdownPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dropdownPanel1.Controls.Add(this.tableLayoutPanel1);
            this.dropdownPanel1.Location = new System.Drawing.Point(12, 11);
            this.dropdownPanel1.Margin = new System.Windows.Forms.Padding(4);
            this.dropdownPanel1.Name = "dropdownPanel1";
            this.dropdownPanel1.Padding = new System.Windows.Forms.Padding(0, 25, 0, 0);
            this.dropdownPanel1.Size = new System.Drawing.Size(197, 119);
            this.dropdownPanel1.State = Contacto.UI.DropdownPanel.DropdownState.Open;
            this.dropdownPanel1.TabIndex = 52;
            this.dropdownPanel1.Text = "Név Szerint";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label4, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.lastName, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.firstName, 0, 3);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 25);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(4);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(197, 94);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(4, 0);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(86, 17);
            this.label3.TabIndex = 39;
            this.label3.Text = "Vezetéknév:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(4, 47);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(83, 17);
            this.label4.TabIndex = 41;
            this.label4.Text = "Keresztnév:";
            // 
            // lastName
            // 
            this.lastName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lastName.Location = new System.Drawing.Point(4, 21);
            this.lastName.Margin = new System.Windows.Forms.Padding(4);
            this.lastName.Name = "lastName";
            this.lastName.Size = new System.Drawing.Size(189, 22);
            this.lastName.TabIndex = 42;
            // 
            // firstName
            // 
            this.firstName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.firstName.Location = new System.Drawing.Point(4, 68);
            this.firstName.Margin = new System.Windows.Forms.Padding(4);
            this.firstName.Name = "firstName";
            this.firstName.Size = new System.Drawing.Size(189, 22);
            this.firstName.TabIndex = 40;
            // 
            // categoryPanel
            // 
            this.categoryPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.categoryPanel.AutoSize = true;
            this.categoryPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.categoryPanel.EntityType = 20000;
            this.categoryPanel.Location = new System.Drawing.Point(13, 139);
            this.categoryPanel.Margin = new System.Windows.Forms.Padding(5);
            this.categoryPanel.Name = "categoryPanel";
            this.categoryPanel.Size = new System.Drawing.Size(195, 25);
            this.categoryPanel.TabIndex = 53;
            // 
            // dropdownPanel2
            // 
            this.dropdownPanel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dropdownPanel2.Controls.Add(this.tableLayoutPanel2);
            this.dropdownPanel2.Location = new System.Drawing.Point(12, 173);
            this.dropdownPanel2.Margin = new System.Windows.Forms.Padding(4);
            this.dropdownPanel2.Name = "dropdownPanel2";
            this.dropdownPanel2.Padding = new System.Windows.Forms.Padding(0, 25, 0, 0);
            this.dropdownPanel2.Size = new System.Drawing.Size(197, 166);
            this.dropdownPanel2.State = Contacto.UI.DropdownPanel.DropdownState.Open;
            this.dropdownPanel2.TabIndex = 54;
            this.dropdownPanel2.Text = "Elérhetőség Szerint";
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.AutoSize = true;
            this.tableLayoutPanel2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.Controls.Add(this.personEmail, 0, 5);
            this.tableLayoutPanel2.Controls.Add(this.label6, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.label8, 0, 4);
            this.tableLayoutPanel2.Controls.Add(this.personPhone, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.personMobile, 0, 3);
            this.tableLayoutPanel2.Controls.Add(this.label7, 0, 2);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 25);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(4);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 6;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.Size = new System.Drawing.Size(197, 141);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // personEmail
            // 
            this.personEmail.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.personEmail.Location = new System.Drawing.Point(4, 115);
            this.personEmail.Margin = new System.Windows.Forms.Padding(4);
            this.personEmail.Name = "personEmail";
            this.personEmail.Size = new System.Drawing.Size(189, 22);
            this.personEmail.TabIndex = 50;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(4, 0);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(93, 17);
            this.label6.TabIndex = 45;
            this.label6.Text = "Telefonszám:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(4, 94);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(76, 17);
            this.label8.TabIndex = 49;
            this.label8.Text = "E-mail cím:";
            // 
            // personPhone
            // 
            this.personPhone.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.personPhone.Location = new System.Drawing.Point(4, 21);
            this.personPhone.Margin = new System.Windows.Forms.Padding(4);
            this.personPhone.Name = "personPhone";
            this.personPhone.Size = new System.Drawing.Size(189, 22);
            this.personPhone.TabIndex = 46;
            // 
            // personMobile
            // 
            this.personMobile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.personMobile.Location = new System.Drawing.Point(4, 68);
            this.personMobile.Margin = new System.Windows.Forms.Padding(4);
            this.personMobile.Name = "personMobile";
            this.personMobile.Size = new System.Drawing.Size(189, 22);
            this.personMobile.TabIndex = 48;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(4, 47);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(45, 17);
            this.label7.TabIndex = 47;
            this.label7.Text = "Mobil:";
            // 
            // PersonSearch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.Controls.Add(this.personTable);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "PersonSearch";
            this.Size = new System.Drawing.Size(221, 462);
            this.personTable.ResumeLayout(false);
            this.personTable.PerformLayout();
            this.dropdownPanel1.ResumeLayout(false);
            this.dropdownPanel1.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.dropdownPanel2.ResumeLayout(false);
            this.dropdownPanel2.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel personTable;
        private System.Windows.Forms.TextBox personEmail;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox lastName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox firstName;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox personPhone;
        private System.Windows.Forms.TextBox personMobile;
        private DropdownPanel dropdownPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private CategoryPanel categoryPanel;
        private DropdownPanel dropdownPanel2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
    }
}
