namespace Contacto.Admin
{
    partial class Admin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Admin));
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabEntities = new System.Windows.Forms.TabPage();
            this.entityList = new Contacto.Admin.TypeList();
            this.tabTypes = new System.Windows.Forms.TabPage();
            this.typeList = new Contacto.Admin.TypeList();
            this.tabCategories = new System.Windows.Forms.TabPage();
            this.categories = new Contacto.Admin.Categories();
            this.tabUsers = new System.Windows.Forms.TabPage();
            this.users = new Contacto.Admin.Users();
            this.tabDeleted = new System.Windows.Forms.TabPage();
            this.deleted = new Contacto.Admin.Entities();
            this.tabControl.SuspendLayout();
            this.tabEntities.SuspendLayout();
            this.tabTypes.SuspendLayout();
            this.tabCategories.SuspendLayout();
            this.tabUsers.SuspendLayout();
            this.tabDeleted.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabEntities);
            this.tabControl.Controls.Add(this.tabTypes);
            this.tabControl.Controls.Add(this.tabCategories);
            this.tabControl.Controls.Add(this.tabUsers);
            this.tabControl.Controls.Add(this.tabDeleted);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.Location = new System.Drawing.Point(3, 3);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(526, 327);
            this.tabControl.TabIndex = 0;
            this.tabControl.SelectedIndexChanged += new System.EventHandler(this.tabControl_SelectedIndexChanged);
            // 
            // tabEntities
            // 
            this.tabEntities.Controls.Add(this.entityList);
            this.tabEntities.Location = new System.Drawing.Point(4, 22);
            this.tabEntities.Name = "tabEntities";
            this.tabEntities.Padding = new System.Windows.Forms.Padding(3);
            this.tabEntities.Size = new System.Drawing.Size(518, 301);
            this.tabEntities.TabIndex = 3;
            this.tabEntities.Text = "Elemek";
            this.tabEntities.UseVisualStyleBackColor = true;
            // 
            // entityList
            // 
            this.entityList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.entityList.Entities = true;
            this.entityList.Location = new System.Drawing.Point(3, 3);
            this.entityList.Name = "entityList";
            this.entityList.Size = new System.Drawing.Size(512, 295);
            this.entityList.TabIndex = 0;
            // 
            // tabTypes
            // 
            this.tabTypes.Controls.Add(this.typeList);
            this.tabTypes.Location = new System.Drawing.Point(4, 22);
            this.tabTypes.Name = "tabTypes";
            this.tabTypes.Padding = new System.Windows.Forms.Padding(3);
            this.tabTypes.Size = new System.Drawing.Size(518, 301);
            this.tabTypes.TabIndex = 2;
            this.tabTypes.Text = "Típusok";
            this.tabTypes.UseVisualStyleBackColor = true;
            // 
            // typeList
            // 
            this.typeList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.typeList.Entities = false;
            this.typeList.Location = new System.Drawing.Point(3, 3);
            this.typeList.Name = "typeList";
            this.typeList.Size = new System.Drawing.Size(512, 295);
            this.typeList.TabIndex = 0;
            // 
            // tabCategories
            // 
            this.tabCategories.Controls.Add(this.categories);
            this.tabCategories.Location = new System.Drawing.Point(4, 22);
            this.tabCategories.Name = "tabCategories";
            this.tabCategories.Padding = new System.Windows.Forms.Padding(3);
            this.tabCategories.Size = new System.Drawing.Size(518, 301);
            this.tabCategories.TabIndex = 0;
            this.tabCategories.Text = "Kategóriák";
            this.tabCategories.UseVisualStyleBackColor = true;
            // 
            // categories
            // 
            this.categories.Dock = System.Windows.Forms.DockStyle.Fill;
            this.categories.Location = new System.Drawing.Point(3, 3);
            this.categories.Name = "categories";
            this.categories.Size = new System.Drawing.Size(512, 295);
            this.categories.TabIndex = 0;
            // 
            // tabUsers
            // 
            this.tabUsers.Controls.Add(this.users);
            this.tabUsers.Location = new System.Drawing.Point(4, 22);
            this.tabUsers.Name = "tabUsers";
            this.tabUsers.Padding = new System.Windows.Forms.Padding(3);
            this.tabUsers.Size = new System.Drawing.Size(518, 301);
            this.tabUsers.TabIndex = 1;
            this.tabUsers.Text = "Felhasználók";
            this.tabUsers.UseVisualStyleBackColor = true;
            // 
            // users
            // 
            this.users.Dock = System.Windows.Forms.DockStyle.Fill;
            this.users.Location = new System.Drawing.Point(3, 3);
            this.users.Name = "users";
            this.users.Size = new System.Drawing.Size(512, 295);
            this.users.TabIndex = 0;
            // 
            // tabDeleted
            // 
            this.tabDeleted.Controls.Add(this.deleted);
            this.tabDeleted.Location = new System.Drawing.Point(4, 22);
            this.tabDeleted.Name = "tabDeleted";
            this.tabDeleted.Size = new System.Drawing.Size(518, 301);
            this.tabDeleted.TabIndex = 4;
            this.tabDeleted.Text = "Törölt elemek";
            this.tabDeleted.UseVisualStyleBackColor = true;
            // 
            // deleted
            // 
            this.deleted.Dock = System.Windows.Forms.DockStyle.Fill;
            this.deleted.Location = new System.Drawing.Point(0, 0);
            this.deleted.Name = "deleted";
            this.deleted.Size = new System.Drawing.Size(518, 301);
            this.deleted.TabIndex = 0;
            // 
            // Admin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(532, 333);
            this.Controls.Add(this.tabControl);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Admin";
            this.Padding = new System.Windows.Forms.Padding(3);
            this.Text = "Contacto Admin";
            this.tabControl.ResumeLayout(false);
            this.tabEntities.ResumeLayout(false);
            this.tabTypes.ResumeLayout(false);
            this.tabCategories.ResumeLayout(false);
            this.tabUsers.ResumeLayout(false);
            this.tabDeleted.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabCategories;
        private System.Windows.Forms.TabPage tabUsers;
        private System.Windows.Forms.TabPage tabTypes;
        private System.Windows.Forms.TabPage tabEntities;
        private TypeList typeList;
        private TypeList entityList;
        private Categories categories;
        private Users users;
        private System.Windows.Forms.TabPage tabDeleted;
        private Entities deleted;
    }
}

