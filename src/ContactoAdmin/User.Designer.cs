namespace Contacto.Admin
{
    partial class User
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.username = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.displayName = new System.Windows.Forms.TextBox();
            this.typeWindows = new System.Windows.Forms.RadioButton();
            this.label2 = new System.Windows.Forms.Label();
            this.typeSql = new System.Windows.Forms.RadioButton();
            this.listView = new System.Windows.Forms.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.searchButton = new System.Windows.Forms.Button();
            this.search = new System.Windows.Forms.TextBox();
            this.searchLabel = new System.Windows.Forms.Label();
            this.ok = new System.Windows.Forms.Button();
            this.cancel = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.password = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.confirm = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // username
            // 
            this.username.Location = new System.Drawing.Point(102, 12);
            this.username.Name = "username";
            this.username.Size = new System.Drawing.Size(243, 20);
            this.username.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Felhasználónév:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 117);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(30, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Név:";
            // 
            // displayName
            // 
            this.displayName.Location = new System.Drawing.Point(102, 114);
            this.displayName.Name = "displayName";
            this.displayName.ReadOnly = true;
            this.displayName.Size = new System.Drawing.Size(243, 20);
            this.displayName.TabIndex = 4;
            // 
            // typeWindows
            // 
            this.typeWindows.AutoSize = true;
            this.typeWindows.Location = new System.Drawing.Point(102, 39);
            this.typeWindows.Name = "typeWindows";
            this.typeWindows.Size = new System.Drawing.Size(69, 17);
            this.typeWindows.TabIndex = 6;
            this.typeWindows.TabStop = true;
            this.typeWindows.Text = "Windows";
            this.typeWindows.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Típus:";
            // 
            // typeSql
            // 
            this.typeSql.AutoSize = true;
            this.typeSql.Location = new System.Drawing.Point(177, 39);
            this.typeSql.Name = "typeSql";
            this.typeSql.Size = new System.Drawing.Size(85, 17);
            this.typeSql.TabIndex = 8;
            this.typeSql.TabStop = true;
            this.typeSql.Text = "radioButton2";
            this.typeSql.UseVisualStyleBackColor = true;
            // 
            // listView
            // 
            this.listView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1});
            this.listView.Location = new System.Drawing.Point(14, 173);
            this.listView.Name = "listView";
            this.listView.Size = new System.Drawing.Size(355, 146);
            this.listView.TabIndex = 16;
            this.listView.UseCompatibleStateImageBehavior = false;
            this.listView.View = System.Windows.Forms.View.Details;
            this.listView.Click += new System.EventHandler(this.listView_Click);
            // 
            // searchButton
            // 
            this.searchButton.Location = new System.Drawing.Point(312, 143);
            this.searchButton.Name = "searchButton";
            this.searchButton.Size = new System.Drawing.Size(59, 20);
            this.searchButton.TabIndex = 15;
            this.searchButton.Text = "Keresés";
            this.searchButton.UseVisualStyleBackColor = true;
            this.searchButton.Click += new System.EventHandler(this.searchButton_Click);
            // 
            // search
            // 
            this.search.Location = new System.Drawing.Point(100, 143);
            this.search.Name = "search";
            this.search.Size = new System.Drawing.Size(206, 20);
            this.search.TabIndex = 14;
            // 
            // searchLabel
            // 
            this.searchLabel.AutoSize = true;
            this.searchLabel.Location = new System.Drawing.Point(11, 146);
            this.searchLabel.Name = "searchLabel";
            this.searchLabel.Size = new System.Drawing.Size(48, 13);
            this.searchLabel.TabIndex = 13;
            this.searchLabel.Text = "Keresés:";
            // 
            // ok
            // 
            this.ok.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.ok.Location = new System.Drawing.Point(215, 328);
            this.ok.Name = "ok";
            this.ok.Size = new System.Drawing.Size(75, 27);
            this.ok.TabIndex = 12;
            this.ok.Text = "OK";
            this.ok.UseVisualStyleBackColor = true;
            // 
            // cancel
            // 
            this.cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancel.Location = new System.Drawing.Point(296, 328);
            this.cancel.Name = "cancel";
            this.cancel.Size = new System.Drawing.Size(75, 27);
            this.cancel.TabIndex = 11;
            this.cancel.Text = "Mégse";
            this.cancel.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 65);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(39, 13);
            this.label4.TabIndex = 18;
            this.label4.Text = "Jelszó:";
            // 
            // password
            // 
            this.password.Location = new System.Drawing.Point(102, 62);
            this.password.Name = "password";
            this.password.Size = new System.Drawing.Size(243, 20);
            this.password.TabIndex = 17;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 91);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(76, 13);
            this.label5.TabIndex = 20;
            this.label5.Text = "Jelszó még 1x:";
            // 
            // confirm
            // 
            this.confirm.Location = new System.Drawing.Point(102, 88);
            this.confirm.Name = "confirm";
            this.confirm.Size = new System.Drawing.Size(243, 20);
            this.confirm.TabIndex = 19;
            // 
            // User
            // 
            this.AcceptButton = this.ok;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancel;
            this.ClientSize = new System.Drawing.Size(383, 364);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.confirm);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.password);
            this.Controls.Add(this.listView);
            this.Controls.Add(this.searchButton);
            this.Controls.Add(this.search);
            this.Controls.Add(this.searchLabel);
            this.Controls.Add(this.ok);
            this.Controls.Add(this.cancel);
            this.Controls.Add(this.typeSql);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.typeWindows);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.displayName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.username);
            this.Name = "User";
            this.Text = "User";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox username;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox displayName;
        private System.Windows.Forms.RadioButton typeWindows;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RadioButton typeSql;
        private System.Windows.Forms.ListView listView;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.Button searchButton;
        private System.Windows.Forms.TextBox search;
        private System.Windows.Forms.Label searchLabel;
        private System.Windows.Forms.Button ok;
        private System.Windows.Forms.Button cancel;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox password;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox confirm;
    }
}