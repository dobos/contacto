namespace Contacto.UI
{
    partial class TagList
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TagList));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsbSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.rtb1 = new System.Windows.Forms.RichTextBox();
            this.ofd1 = new System.Windows.Forms.OpenFileDialog();
            this.sfd1 = new System.Windows.Forms.SaveFileDialog();
            this.tsbOpen = new System.Windows.Forms.ToolStripButton();
            this.tsbSave = new System.Windows.Forms.ToolStripButton();
            this.tsbFont = new System.Windows.Forms.ToolStripDropDownButton();
            this.tsbFontSize = new System.Windows.Forms.ToolStripDropDownButton();
            this.tsbColor = new System.Windows.Forms.ToolStripDropDownButton();
            this.tsbBold = new System.Windows.Forms.ToolStripButton();
            this.tsbItalic = new System.Windows.Forms.ToolStripButton();
            this.tsbUnderline = new System.Windows.Forms.ToolStripButton();
            this.tsbStrikeout = new System.Windows.Forms.ToolStripButton();
            this.tsbLeft = new System.Windows.Forms.ToolStripButton();
            this.tsbCenter = new System.Windows.Forms.ToolStripButton();
            this.tsbRight = new System.Windows.Forms.ToolStripButton();
            this.tsbUndo = new System.Windows.Forms.ToolStripButton();
            this.tsbRedo = new System.Windows.Forms.ToolStripButton();
            this.tsbCut = new System.Windows.Forms.ToolStripButton();
            this.tsbCopy = new System.Windows.Forms.ToolStripButton();
            this.tsbPaste = new System.Windows.Forms.ToolStripButton();
            this.tsbStamp = new System.Windows.Forms.ToolStripButton();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbOpen,
            this.tsbSave,
            this.tsbSeparator1,
            this.tsbFont,
            this.tsbFontSize,
            this.tsbColor,
            this.tsbSeparator2,
            this.tsbBold,
            this.tsbItalic,
            this.tsbUnderline,
            this.tsbStrikeout,
            this.tsbSeparator3,
            this.tsbLeft,
            this.tsbCenter,
            this.tsbRight,
            this.tsbSeparator4,
            this.tsbUndo,
            this.tsbRedo,
            this.tsbSeparator5,
            this.tsbCut,
            this.tsbCopy,
            this.tsbPaste,
            this.tsbStamp});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(667, 25);
            this.toolStrip1.TabIndex = 3;
            this.toolStrip1.Text = "toolStrip1";
            this.toolStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.toolStrip1_ItemClicked);
            // 
            // tsbSeparator1
            // 
            this.tsbSeparator1.Name = "tsbSeparator1";
            this.tsbSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // tsbSeparator2
            // 
            this.tsbSeparator2.Name = "tsbSeparator2";
            this.tsbSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // tsbSeparator3
            // 
            this.tsbSeparator3.Name = "tsbSeparator3";
            this.tsbSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // tsbSeparator4
            // 
            this.tsbSeparator4.Name = "tsbSeparator4";
            this.tsbSeparator4.Size = new System.Drawing.Size(6, 25);
            // 
            // tsbSeparator5
            // 
            this.tsbSeparator5.Name = "tsbSeparator5";
            this.tsbSeparator5.Size = new System.Drawing.Size(6, 25);
            // 
            // rtb1
            // 
            this.rtb1.AutoWordSelection = true;
            this.rtb1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtb1.Location = new System.Drawing.Point(0, 25);
            this.rtb1.Name = "rtb1";
            this.rtb1.Size = new System.Drawing.Size(667, 412);
            this.rtb1.TabIndex = 4;
            this.rtb1.Text = "";
            this.rtb1.LinkClicked += new System.Windows.Forms.LinkClickedEventHandler(this.rtb1_LinkClicked);
            this.rtb1.SelectionChanged += new System.EventHandler(this.rtb1_SelectionChanged);
            this.rtb1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.rtb1_KeyDown);
            this.rtb1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.rtb1_KeyPress);
            // 
            // ofd1
            // 
            this.ofd1.DefaultExt = "rtf";
            this.ofd1.Filter = "Rich Text Files|*.rtf|Plain Text File|*.txt";
            this.ofd1.Title = "Open File";
            // 
            // sfd1
            // 
            this.sfd1.DefaultExt = "rtf";
            this.sfd1.Filter = "Rich Text File|*.rtf|Plain Text File|*.txt";
            this.sfd1.Title = "Save As";
            // 
            // tsbOpen
            // 
            this.tsbOpen.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbOpen.Image = global::Contacto.UI.Properties.Resources.open;
            this.tsbOpen.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbOpen.Name = "tsbOpen";
            this.tsbOpen.Size = new System.Drawing.Size(23, 22);
            this.tsbOpen.Tag = "open";
            this.tsbOpen.Text = "toolStripButton2";
            // 
            // tsbSave
            // 
            this.tsbSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbSave.Image = global::Contacto.UI.Properties.Resources.save1;
            this.tsbSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbSave.Name = "tsbSave";
            this.tsbSave.Size = new System.Drawing.Size(23, 22);
            this.tsbSave.Tag = "save";
            this.tsbSave.Text = "toolStripButton1";
            // 
            // tsbFont
            // 
            this.tsbFont.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbFont.Image = global::Contacto.UI.Properties.Resources.font;
            this.tsbFont.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbFont.Name = "tsbFont";
            this.tsbFont.Size = new System.Drawing.Size(29, 22);
            this.tsbFont.Text = "toolStripDropDownButton1";
            // 
            // tsbFontSize
            // 
            this.tsbFontSize.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbFontSize.Image = global::Contacto.UI.Properties.Resources.fontsize;
            this.tsbFontSize.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbFontSize.Name = "tsbFontSize";
            this.tsbFontSize.Size = new System.Drawing.Size(29, 22);
            this.tsbFontSize.Text = "toolStripDropDownButton2";
            // 
            // tsbColor
            // 
            this.tsbColor.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbColor.Image = global::Contacto.UI.Properties.Resources.fontcolor;
            this.tsbColor.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbColor.Name = "tsbColor";
            this.tsbColor.Size = new System.Drawing.Size(29, 22);
            this.tsbColor.Text = "toolStripDropDownButton3";
            // 
            // tsbBold
            // 
            this.tsbBold.CheckOnClick = true;
            this.tsbBold.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbBold.Image = global::Contacto.UI.Properties.Resources.bold;
            this.tsbBold.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbBold.Name = "tsbBold";
            this.tsbBold.Size = new System.Drawing.Size(23, 22);
            this.tsbBold.Tag = "bold";
            this.tsbBold.Text = "toolStripButton3";
            // 
            // tsbItalic
            // 
            this.tsbItalic.CheckOnClick = true;
            this.tsbItalic.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbItalic.Image = global::Contacto.UI.Properties.Resources.italic;
            this.tsbItalic.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbItalic.Name = "tsbItalic";
            this.tsbItalic.Size = new System.Drawing.Size(23, 22);
            this.tsbItalic.Tag = "italic";
            this.tsbItalic.Text = "toolStripButton4";
            // 
            // tsbUnderline
            // 
            this.tsbUnderline.CheckOnClick = true;
            this.tsbUnderline.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbUnderline.Image = global::Contacto.UI.Properties.Resources.underline;
            this.tsbUnderline.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbUnderline.Name = "tsbUnderline";
            this.tsbUnderline.Size = new System.Drawing.Size(23, 22);
            this.tsbUnderline.Tag = "underline";
            this.tsbUnderline.Text = "toolStripButton5";
            // 
            // tsbStrikeout
            // 
            this.tsbStrikeout.CheckOnClick = true;
            this.tsbStrikeout.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbStrikeout.Image = ((System.Drawing.Image)(resources.GetObject("tsbStrikeout.Image")));
            this.tsbStrikeout.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbStrikeout.Name = "tsbStrikeout";
            this.tsbStrikeout.Size = new System.Drawing.Size(23, 22);
            this.tsbStrikeout.Tag = "strikeout";
            this.tsbStrikeout.Text = "toolStripButton6";
            this.tsbStrikeout.Visible = false;
            // 
            // tsbLeft
            // 
            this.tsbLeft.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbLeft.Image = global::Contacto.UI.Properties.Resources.align_left;
            this.tsbLeft.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbLeft.Name = "tsbLeft";
            this.tsbLeft.Size = new System.Drawing.Size(23, 22);
            this.tsbLeft.Tag = "left";
            this.tsbLeft.Text = "toolStripButton7";
            // 
            // tsbCenter
            // 
            this.tsbCenter.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbCenter.Image = global::Contacto.UI.Properties.Resources.align_center;
            this.tsbCenter.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbCenter.Name = "tsbCenter";
            this.tsbCenter.Size = new System.Drawing.Size(23, 22);
            this.tsbCenter.Tag = "center";
            this.tsbCenter.Text = "toolStripButton8";
            // 
            // tsbRight
            // 
            this.tsbRight.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbRight.Image = global::Contacto.UI.Properties.Resources.align_right;
            this.tsbRight.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbRight.Name = "tsbRight";
            this.tsbRight.Size = new System.Drawing.Size(23, 22);
            this.tsbRight.Tag = "right";
            this.tsbRight.Text = "toolStripButton9";
            // 
            // tsbUndo
            // 
            this.tsbUndo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbUndo.Image = global::Contacto.UI.Properties.Resources.undo;
            this.tsbUndo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbUndo.Name = "tsbUndo";
            this.tsbUndo.Size = new System.Drawing.Size(23, 22);
            this.tsbUndo.Tag = "undo";
            this.tsbUndo.Text = "toolStripButton10";
            // 
            // tsbRedo
            // 
            this.tsbRedo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbRedo.Image = global::Contacto.UI.Properties.Resources.redo;
            this.tsbRedo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbRedo.Name = "tsbRedo";
            this.tsbRedo.Size = new System.Drawing.Size(23, 22);
            this.tsbRedo.Tag = "redo";
            this.tsbRedo.Text = "toolStripButton11";
            // 
            // tsbCut
            // 
            this.tsbCut.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbCut.Image = global::Contacto.UI.Properties.Resources.cut;
            this.tsbCut.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbCut.Name = "tsbCut";
            this.tsbCut.Size = new System.Drawing.Size(23, 22);
            this.tsbCut.Tag = "cut";
            this.tsbCut.Text = "toolStripButton12";
            // 
            // tsbCopy
            // 
            this.tsbCopy.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbCopy.Image = global::Contacto.UI.Properties.Resources.copy;
            this.tsbCopy.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbCopy.Name = "tsbCopy";
            this.tsbCopy.Size = new System.Drawing.Size(23, 22);
            this.tsbCopy.Tag = "copy";
            this.tsbCopy.Text = "toolStripButton13";
            // 
            // tsbPaste
            // 
            this.tsbPaste.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbPaste.Image = global::Contacto.UI.Properties.Resources.paste;
            this.tsbPaste.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbPaste.Name = "tsbPaste";
            this.tsbPaste.Size = new System.Drawing.Size(23, 22);
            this.tsbPaste.Tag = "paste";
            this.tsbPaste.Text = "toolStripButton14";
            // 
            // tsbStamp
            // 
            this.tsbStamp.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbStamp.Image = ((System.Drawing.Image)(resources.GetObject("tsbStamp.Image")));
            this.tsbStamp.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbStamp.Name = "tsbStamp";
            this.tsbStamp.Size = new System.Drawing.Size(23, 22);
            this.tsbStamp.Tag = "editstamp";
            this.tsbStamp.Text = "toolStripButton15";
            this.tsbStamp.Visible = false;
            // 
            // TagList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.Controls.Add(this.rtb1);
            this.Controls.Add(this.toolStrip1);
            this.Name = "TagList";
            this.Size = new System.Drawing.Size(667, 437);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tsbSave;
        private System.Windows.Forms.ToolStripButton tsbOpen;
        private System.Windows.Forms.ToolStripSeparator tsbSeparator1;
        private System.Windows.Forms.ToolStripDropDownButton tsbFontSize;
        private System.Windows.Forms.ToolStripDropDownButton tsbColor;
        private System.Windows.Forms.ToolStripSeparator tsbSeparator2;
        private System.Windows.Forms.ToolStripButton tsbBold;
        private System.Windows.Forms.ToolStripButton tsbItalic;
        private System.Windows.Forms.ToolStripButton tsbUnderline;
        private System.Windows.Forms.ToolStripButton tsbStrikeout;
        private System.Windows.Forms.ToolStripSeparator tsbSeparator3;
        private System.Windows.Forms.ToolStripButton tsbLeft;
        private System.Windows.Forms.ToolStripButton tsbCenter;
        private System.Windows.Forms.ToolStripButton tsbRight;
        private System.Windows.Forms.ToolStripSeparator tsbSeparator4;
        private System.Windows.Forms.ToolStripButton tsbUndo;
        private System.Windows.Forms.ToolStripButton tsbRedo;
        private System.Windows.Forms.ToolStripSeparator tsbSeparator5;
        private System.Windows.Forms.ToolStripButton tsbCut;
        private System.Windows.Forms.ToolStripButton tsbCopy;
        private System.Windows.Forms.ToolStripButton tsbPaste;
        private System.Windows.Forms.ToolStripButton tsbStamp;
        private System.Windows.Forms.RichTextBox rtb1;
        private System.Windows.Forms.OpenFileDialog ofd1;
        private System.Windows.Forms.SaveFileDialog sfd1;
        private System.Windows.Forms.ToolStripDropDownButton tsbFont;



    }
}
