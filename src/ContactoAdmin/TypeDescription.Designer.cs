namespace Contacto.Admin
{
    partial class TypeDescription
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
            this.ok = new System.Windows.Forms.Button();
            this.cancel = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.id = new System.Windows.Forms.TextBox();
            this.entity = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.description = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.linkedEntity = new System.Windows.Forms.ComboBox();
            this.system = new System.Windows.Forms.CheckBox();
            this.hidden = new System.Windows.Forms.CheckBox();
            this.multiple = new System.Windows.Forms.CheckBox();
            this.required = new System.Windows.Forms.CheckBox();
            this.freeText = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // ok
            // 
            this.ok.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.ok.Location = new System.Drawing.Point(170, 188);
            this.ok.Name = "ok";
            this.ok.Size = new System.Drawing.Size(75, 23);
            this.ok.TabIndex = 13;
            this.ok.Text = "OK";
            this.ok.UseVisualStyleBackColor = true;
            // 
            // cancel
            // 
            this.cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancel.Location = new System.Drawing.Point(251, 188);
            this.cancel.Name = "cancel";
            this.cancel.Size = new System.Drawing.Size(75, 23);
            this.cancel.TabIndex = 14;
            this.cancel.Text = "Cancel";
            this.cancel.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(21, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "ID:";
            // 
            // id
            // 
            this.id.Location = new System.Drawing.Point(107, 12);
            this.id.Name = "id";
            this.id.ReadOnly = true;
            this.id.Size = new System.Drawing.Size(100, 20);
            this.id.TabIndex = 1;
            // 
            // entity
            // 
            this.entity.DisplayMember = "Description";
            this.entity.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.entity.FormattingEnabled = true;
            this.entity.Location = new System.Drawing.Point(107, 38);
            this.entity.Name = "entity";
            this.entity.Size = new System.Drawing.Size(219, 21);
            this.entity.TabIndex = 3;
            this.entity.ValueMember = "Description";
            this.entity.SelectedIndexChanged += new System.EventHandler(this.entity_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(33, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Elem:";
            // 
            // description
            // 
            this.description.Location = new System.Drawing.Point(107, 65);
            this.description.Name = "description";
            this.description.Size = new System.Drawing.Size(219, 20);
            this.description.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 68);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(30, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Név:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 94);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(89, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Hivatkozott elem:";
            // 
            // linkedEntity
            // 
            this.linkedEntity.DisplayMember = "Description";
            this.linkedEntity.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.linkedEntity.FormattingEnabled = true;
            this.linkedEntity.Location = new System.Drawing.Point(107, 91);
            this.linkedEntity.Name = "linkedEntity";
            this.linkedEntity.Size = new System.Drawing.Size(219, 21);
            this.linkedEntity.TabIndex = 7;
            this.linkedEntity.ValueMember = "Description";
            // 
            // system
            // 
            this.system.AutoSize = true;
            this.system.Location = new System.Drawing.Point(107, 119);
            this.system.Name = "system";
            this.system.Size = new System.Drawing.Size(71, 17);
            this.system.TabIndex = 8;
            this.system.Text = "Rendszer";
            this.system.UseVisualStyleBackColor = true;
            // 
            // hidden
            // 
            this.hidden.AutoSize = true;
            this.hidden.Location = new System.Drawing.Point(107, 142);
            this.hidden.Name = "hidden";
            this.hidden.Size = new System.Drawing.Size(57, 17);
            this.hidden.TabIndex = 9;
            this.hidden.Text = "Rejtett";
            this.hidden.UseVisualStyleBackColor = true;
            // 
            // multiple
            // 
            this.multiple.AutoSize = true;
            this.multiple.Location = new System.Drawing.Point(107, 165);
            this.multiple.Name = "multiple";
            this.multiple.Size = new System.Drawing.Size(81, 17);
            this.multiple.TabIndex = 10;
            this.multiple.Text = "Többszörös";
            this.multiple.UseVisualStyleBackColor = true;
            // 
            // required
            // 
            this.required.AutoSize = true;
            this.required.Location = new System.Drawing.Point(221, 119);
            this.required.Name = "required";
            this.required.Size = new System.Drawing.Size(51, 17);
            this.required.TabIndex = 11;
            this.required.Text = "Elõírt";
            this.required.UseVisualStyleBackColor = true;
            // 
            // freeText
            // 
            this.freeText.AutoSize = true;
            this.freeText.Location = new System.Drawing.Point(221, 142);
            this.freeText.Name = "freeText";
            this.freeText.Size = new System.Drawing.Size(62, 17);
            this.freeText.TabIndex = 12;
            this.freeText.Text = "Szabad";
            this.freeText.UseVisualStyleBackColor = true;
            // 
            // TypeDescription
            // 
            this.AcceptButton = this.ok;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancel;
            this.ClientSize = new System.Drawing.Size(341, 224);
            this.Controls.Add(this.freeText);
            this.Controls.Add(this.required);
            this.Controls.Add(this.multiple);
            this.Controls.Add(this.hidden);
            this.Controls.Add(this.system);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.linkedEntity);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.description);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.entity);
            this.Controls.Add(this.id);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cancel);
            this.Controls.Add(this.ok);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TypeDescription";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Típus leírás";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button ok;
        private System.Windows.Forms.Button cancel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox id;
        private System.Windows.Forms.ComboBox entity;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox description;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox linkedEntity;
        private System.Windows.Forms.CheckBox system;
        private System.Windows.Forms.CheckBox hidden;
        private System.Windows.Forms.CheckBox multiple;
        private System.Windows.Forms.CheckBox required;
        private System.Windows.Forms.CheckBox freeText;
    }
}