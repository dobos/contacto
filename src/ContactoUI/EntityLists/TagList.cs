using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Xml;

namespace Contacto.UI
{
    public partial class TagList : UserControl
    {
        public enum StampActions
        {
            EditedBy = 1,
            DateTime = 2,
            Custom = 4
        }

        private Contacto.Lib.Entity parentEntity = null;
        private RichTextBox rtbTemp = new RichTextBox();

        public Contacto.Lib.Entity ParentEntity
        {
            get
            {
                return parentEntity;
            }
            set
            {
                if (parentEntity != value)
                {
                    parentEntity = value;
                    RefreshList();
                }
            }
        }

        public TagList()
        {
            InitializeComponent();
            InitializeDropDowns();

            //Update the graphics on the toolbar
            UpdateToolbar();
        }

        private void InitializeDropDowns()
        {
            string[] fonts = { "Arial", "Times New Roman", "Courier New" };
            
            foreach (string f in fonts)
            {
                ToolStripMenuItem mi = new ToolStripMenuItem();
                mi.Text = f;
                mi.Tag = f;
                mi.Click += new EventHandler(Font_Click);

                tsbFont.DropDownItems.Add(mi);
            }

            Color[] colors = { Color.Black, Color.Blue, Color.Red, Color.Green,
                Color.Brown, Color.Yellow, Color.Purple, Color.Orange, Color.Cyan, Color.Gray};

            foreach (Color c in colors)
            {
                ToolStripMenuItem mi = new ToolStripMenuItem();
                mi.BackColor = c;
                mi.Text = c.Name;
                mi.Tag = c;
                mi.Click += new EventHandler(Color_Click);

                tsbColor.DropDownItems.Add(mi);
            }

            int[] sizes = { 8, 9, 10, 11, 12, 14, 16, 18, 20, 22, 24, 26, 28, 36, 48, 72 };

            foreach (int i in sizes)
            {
                ToolStripMenuItem mi = new ToolStripMenuItem();
                mi.Text = i.ToString();
                mi.Tag = i;
                mi.Click += new EventHandler(FontSize_Click);

                tsbFontSize.DropDownItems.Add(mi);
            }
        }

        private void RefreshList()
        {
            using (Contacto.Lib.Context context = ContextManager.CreateContext(this, false))
            {
                if (parentEntity.Tag != null)
                {
                    try
                    {
                        XmlDocument xml = new XmlDocument();
                        XmlCDataSection e = null;

                        xml.LoadXml(parentEntity.Tag);
                        XmlNode node = xml.SelectSingleNode("//comments");
                        if (node.ChildNodes.Count > 0)
                            e = node.ChildNodes[0] as XmlCDataSection;

                        if (e != null)
                        {
                            rtb1.Rtf = e.Value;
                        }
                    }
                    catch (System.Exception)
                    {
                    }
                }
            }
        }

        public void Save()
        {
            if (parentEntity != null)
            {
                XmlDocument xml = new XmlDocument();

                if (parentEntity.Tag != null)
                {
                    try
                    {
                        xml.LoadXml(parentEntity.Tag);
                    }
                    catch (System.Exception)
                    {
                        xml.LoadXml("<xml></xml>");
                    }
                }
                else
                {
                    xml.LoadXml("<xml></xml>");
                }

                XmlNode node = xml.SelectSingleNode("//comments");
                if (node == null)
                {
                    node = xml.CreateElement("comments");
                    xml.DocumentElement.AppendChild(node);
                }

                XmlCDataSection e = null;
                if (node.ChildNodes.Count > 0)
                    e = node.ChildNodes[0] as XmlCDataSection;

                if (e == null)
                {
                    e = xml.CreateCDataSection(rtb1.Rtf);
                    node.AppendChild(e);
                }
                else
                {
                    e.Value = rtb1.Rtf;
                }

                parentEntity.Tag = xml.OuterXml;
            }
        }


        [Description("Occurs when the selection is changed"), Category("Behavior")]
        public event System.EventHandler SelChanged;

        [Description("Occurs when the stamp button is clicked"), Category("Behavior")]
        public event System.EventHandler Stamp;

        protected virtual void OnStamp(EventArgs e)
        {
            if (Stamp != null)
                Stamp(this, e);

            switch (StampAction)
            {
                case StampActions.EditedBy:
                    {
                        StringBuilder stamp = new StringBuilder(""); //holds our stamp text
                        if (rtb1.Text.Length > 0) stamp.Append("\r\n\r\n"); //add two lines for space
                        stamp.Append("Edited by ");
                        //use the CurrentPrincipal name if one exsist else use windows logon username
                        if (Thread.CurrentPrincipal == null || Thread.CurrentPrincipal.Identity == null || Thread.CurrentPrincipal.Identity.Name.Length <= 0)
                            stamp.Append(Environment.UserName);
                        else
                            stamp.Append(Thread.CurrentPrincipal.Identity.Name);
                        stamp.Append(" on " + DateTime.Now.ToLongDateString() + "\r\n");

                        rtb1.SelectionLength = 0; //unselect everything basicly
                        rtb1.SelectionStart = rtb1.Text.Length; //start new selection at the end of the text
                        rtb1.SelectionColor = this.StampColor; //make the selection blue
                        rtb1.SelectionFont = new Font(rtb1.SelectionFont, FontStyle.Bold); //set the selection font and style
                        rtb1.AppendText(stamp.ToString()); //add the stamp to the richtextbox
                        rtb1.Focus(); //set focus back on the richtextbox
                    } break; //end edited by stamp
                case StampActions.DateTime:
                    {
                        StringBuilder stamp = new StringBuilder(""); //holds our stamp text
                        if (rtb1.Text.Length > 0) stamp.Append("\r\n\r\n"); //add two lines for space
                        stamp.Append(DateTime.Now.ToLongDateString() + "\r\n");
                        rtb1.SelectionLength = 0; //unselect everything basicly
                        rtb1.SelectionStart = rtb1.Text.Length; //start new selection at the end of the text
                        rtb1.SelectionColor = this.StampColor; //make the selection blue
                        rtb1.SelectionFont = new Font(rtb1.SelectionFont, FontStyle.Bold); //set the selection font and style
                        rtb1.AppendText(stamp.ToString()); //add the stamp to the richtextbox
                        rtb1.Focus(); //set focus back on the richtextbox
                    } break;
            } //end select
        }

        #region Properties

        [Description("The internal toolbar control"), Category("Internal Controls"), DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public ToolStrip ToolStrip
        {
            get { return toolStrip1; }
        }

        [Description("The internal richtextbox control"), Category("Internal Controls"), DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public RichTextBox RichTextBox
        {
            get { return rtb1; }
        }

        [Description("Show the save button or not"), Category("Appearance")]
        public bool ShowSave
        {
            get { return tsbSave.Visible; }
            set { tsbSave.Visible = value; UpdateToolbarSeperators(); }
        }

        /// <summary>
        ///    Show the open button or not 
        /// </summary>
        [Description("Show the open button or not"),
        Category("Appearance")]
        public bool ShowOpen
        {
            get { return tsbOpen.Visible; }
            set { tsbOpen.Visible = value; UpdateToolbarSeperators(); }
        }

        /// <summary>
        ///     Show the stamp button or not
        /// </summary>
        [Description("Show the stamp button or not"),
         Category("Appearance")]
        public bool ShowStamp
        {
            get { return tsbStamp.Visible; }
            set { tsbStamp.Visible = value; }
        }

        /// <summary>
        ///     Show the color button or not
        /// </summary>
        [Description("Show the color button or not"),
        Category("Appearance")]
        public bool ShowColors
        {
            get { return tsbColor.Visible; }
            set { tsbColor.Visible = value; }
        }

        /// <summary>
        ///     Show the undo button or not
        /// </summary>
        [Description("Show the undo button or not"),
        Category("Appearance")]
        public bool ShowUndo
        {
            get { return tsbUndo.Visible; }
            set { tsbUndo.Visible = value; UpdateToolbarSeperators(); }
        }

        /// <summary>
        ///     Show the redo button or not
        /// </summary>
        [Description("Show the redo button or not"),
        Category("Appearance")]
        public bool ShowRedo
        {
            get { return tsbRedo.Visible; }
            set { tsbRedo.Visible = value; UpdateToolbarSeperators(); }
        }

        /// <summary>
        ///     Show the bold button or not
        /// </summary>
        [Description("Show the bold button or not"),
        Category("Appearance")]
        public bool ShowBold
        {
            get { return tsbBold.Visible; }
            set { tsbBold.Visible = value; UpdateToolbarSeperators(); }
        }

        /// <summary>
        ///     Show the italic button or not
        /// </summary>
        [Description("Show the italic button or not"),
        Category("Appearance")]
        public bool ShowItalic
        {
            get { return tsbItalic.Visible; }
            set { tsbItalic.Visible = value; UpdateToolbarSeperators(); }
        }

        /// <summary>
        ///     Show the underline button or not
        /// </summary>
        [Description("Show the underline button or not"),
        Category("Appearance")]
        public bool ShowUnderline
        {
            get { return tsbUnderline.Visible; }
            set { tsbUnderline.Visible = value; UpdateToolbarSeperators(); }
        }

        /// <summary>
        ///     Show the strikeout button or not
        /// </summary>
        [Description("Show the strikeout button or not"),
        Category("Appearance")]
        public bool ShowStrikeout
        {
            get { return tsbStrikeout.Visible; }
            set { tsbStrikeout.Visible = value; UpdateToolbarSeperators(); }
        }

        /// <summary>
        ///     Show the left justify button or not
        /// </summary>
        [Description("Show the left justify button or not"),
        Category("Appearance")]
        public bool ShowLeftJustify
        {
            get { return tsbLeft.Visible; }
            set { tsbLeft.Visible = value; UpdateToolbarSeperators(); }
        }

        /// <summary>
        ///     Show the right justify button or not
        /// </summary>
        [Description("Show the right justify button or not"),
        Category("Appearance")]
        public bool ShowRightJustify
        {
            get { return tsbRight.Visible; }
            set { tsbRight.Visible = value; UpdateToolbarSeperators(); }
        }

        /// <summary>
        ///     Show the center justify button or not
        /// </summary>
        [Description("Show the center justify button or not"),
        Category("Appearance")]
        public bool ShowCenterJustify
        {
            get { return tsbCenter.Visible; }
            set { tsbCenter.Visible = value; UpdateToolbarSeperators(); }
        }

        /// <summary>
        ///     Determines how the stamp button will respond
        /// </summary>
        StampActions m_StampAction = StampActions.EditedBy;
        [Description("Determines how the stamp button will respond"),
        Category("Behavior")]
        public StampActions StampAction
        {
            get { return m_StampAction; }
            set { m_StampAction = value; }
        }

        /// <summary>
        ///     Color of the stamp text
        /// </summary>
        Color m_StampColor = Color.Blue;

        [Description("Color of the stamp text"),
        Category("Appearance")]
        public Color StampColor
        {
            get { return m_StampColor; }
            set { m_StampColor = value; }
        }

        /// <summary>
        ///     Show the font button or not
        /// </summary>
        [Description("Show the font button or not"),
        Category("Appearance")]
        public bool ShowFont
        {
            get { return tsbFont.Visible; }
            set { tsbFont.Visible = value; }
        }

        /// <summary>
        ///     Show the font size button or not
        /// </summary>
        [Description("Show the font size button or not"),
        Category("Appearance")]
        public bool ShowFontSize
        {
            get { return tsbFontSize.Visible; }
            set { tsbFontSize.Visible = value; }
        }

        /// <summary>
        ///     Show the cut button or not
        /// </summary>
        [Description("Show the cut button or not"),
        Category("Appearance")]
        public bool ShowCut
        {
            get { return tsbCut.Visible; }
            set { tsbCut.Visible = value; }
        }

        /// <summary>
        ///     Show the copy button or not
        /// </summary>
        [Description("Show the copy button or not"),
        Category("Appearance")]
        public bool ShowCopy
        {
            get { return tsbCopy.Visible; }
            set { tsbCopy.Visible = value; }
        }

        /// <summary>
        ///     Show the paste button or not
        /// </summary>
        [Description("Show the paste button or not"),
        Category("Appearance")]
        public bool ShowPaste
        {
            get { return tsbPaste.Visible; }
            set { tsbPaste.Visible = value; }
        }

        /// <summary>
        ///     Detect URLs with-in the richtextbox
        /// </summary>
        [Description("Detect URLs with-in the richtextbox"),
        Category("Behavior")]
        public bool DetectURLs
        {
            get { return rtb1.DetectUrls; }
            set { rtb1.DetectUrls = value; }
        }

        /// <summary>
        /// Determines if the TAB key moves to the next control or enters a TAB character in the richtextbox
        /// </summary>
        [Description("Determines if the TAB key moves to the next control or enters a TAB character in the richtextbox"),
        Category("Behavior")]
        public bool AcceptsTab
        {
            get { return rtb1.AcceptsTab; }
            set { rtb1.AcceptsTab = value; }
        }

        /// <summary>
        /// Determines if auto word selection is enabled
        /// </summary>
        [Description("Determines if auto word selection is enabled"),
        Category("Behavior")]
        public bool AutoWordSelection
        {
            get { return rtb1.AutoWordSelection; }
            set { rtb1.AutoWordSelection = value; }
        }

        /// <summary>
        /// Determines if this control can be edited
        /// </summary>
        [Description("Determines if this control can be edited"),
        Category("Behavior")]
        public bool ReadOnly
        {
            get { return rtb1.ReadOnly; }
            set
            {
                toolStrip1.Enabled = !value;
                rtb1.ReadOnly = value;
            }
        }

        private bool _showToolBarText;

        /// <summary>
        /// Determines if the buttons on the toolbar will show there text or not
        /// </summary>
        [Description("Determines if the buttons on the toolbar will show there text or not"),
        Category("Behavior")]
        public bool ShowToolBarText
        {
            get { return _showToolBarText; }
            set
            {
                _showToolBarText = value;

                if (_showToolBarText)
                {
                    tsbSave.Text = "Save";
                    tsbOpen.Text = "Open";
                    tsbBold.Text = "Bold";
                    tsbFont.Text = "Font";
                    tsbFontSize.Text = "Font Size";
                    tsbColor.Text = "Font Color";
                    tsbItalic.Text = "Italic";
                    tsbStrikeout.Text = "Strikeout";
                    tsbUnderline.Text = "Underline";
                    tsbLeft.Text = "Left";
                    tsbCenter.Text = "Center";
                    tsbRight.Text = "Right";
                    tsbUndo.Text = "Undo";
                    tsbRedo.Text = "Redo";
                    tsbCut.Text = "Cut";
                    tsbCopy.Text = "Copy";
                    tsbPaste.Text = "Paste";
                    tsbStamp.Text = "Stamp";
                }
                else
                {
                    tsbSave.Text = "";
                    tsbOpen.Text = "";
                    tsbBold.Text = "";
                    tsbFont.Text = "";
                    tsbFontSize.Text = "";
                    tsbColor.Text = "";
                    tsbItalic.Text = "";
                    tsbStrikeout.Text = "";
                    tsbUnderline.Text = "";
                    tsbLeft.Text = "";
                    tsbCenter.Text = "";
                    tsbRight.Text = "";
                    tsbUndo.Text = "";
                    tsbRedo.Text = "";
                    tsbCut.Text = "";
                    tsbCopy.Text = "";
                    tsbPaste.Text = "";
                    tsbStamp.Text = "";
                }

                this.Invalidate();
                this.Update();
            }
        }

        #endregion

        public void UpdateToolbar()
        {
            // Get the font, fontsize and style to apply to the toolbar buttons
            Font fnt = GetFontDetails();
            // Set font style buttons to the styles applying to the entire selection
            FontStyle style = fnt.Style;

            //Set all the style buttons using the gathered style
            tsbBold.Checked = fnt.Bold; //bold button
            tsbItalic.Checked = fnt.Italic; //italic button
            tsbUnderline.Checked = fnt.Underline; //underline button
            tsbStrikeout.Checked = fnt.Strikeout; //strikeout button
            tsbLeft.Checked = (rtb1.SelectionAlignment == HorizontalAlignment.Left); //justify left
            tsbCenter.Checked = (rtb1.SelectionAlignment == HorizontalAlignment.Center); //justify center
            tsbRight.Checked = (rtb1.SelectionAlignment == HorizontalAlignment.Right); //justify right

            //Check the correct color
            foreach (ToolStripMenuItem mi in tsbColor.DropDownItems)
                mi.Checked = (rtb1.SelectionColor == (Color)mi.Tag);

            //Check the correct font
            foreach (ToolStripMenuItem mi in tsbFont.DropDownItems)
                mi.Checked = (fnt.FontFamily.Name == (string)mi.Tag);

            //Check the correct font size
            foreach (ToolStripMenuItem mi in tsbFontSize.DropDownItems)
                mi.Checked = ((int)fnt.SizeInPoints == (int)mi.Tag);
        }

        private void UpdateToolbarSeperators()
        {
            //Save & Open
            if (!tsbSave.Visible && !tsbOpen.Visible)
                tsbSeparator1.Visible = false;
            else
                tsbSeparator1.Visible = true;

            //Font & Font Size
            if (!tsbFont.Visible && !tsbFontSize.Visible && !tsbColor.Visible)
                tsbSeparator2.Visible = false;
            else
                tsbSeparator2.Visible = true;

            //Bold, Italic, Underline, & Strikeout
            if (!tsbBold.Visible && !tsbItalic.Visible && !tsbUnderline.Visible && !tsbStrikeout.Visible)
                tsbSeparator3.Visible = false;
            else
                tsbSeparator3.Visible = true;

            //Left, Center, & Right
            if (!tsbLeft.Visible && !tsbCenter.Visible && !tsbRight.Visible)
                tsbSeparator4.Visible = false;
            else
                tsbSeparator4.Visible = true;

            //Undo & Redo
            if (!tsbUndo.Visible && !tsbRedo.Visible)
                tsbSeparator5.Visible = false;
            else
                tsbSeparator5.Visible = true;
        }

        #region Change font
        /// <summary>
        ///     Change the richtextbox font for the current selection
        /// </summary>
        public void ChangeFont(string fontFamily)
        {
            //This method should handle cases that occur when multiple fonts/styles are selected
            // Parameters:-
            // fontFamily - the font to be applied, eg "Courier New"

            // Reason: The reason this method and the others exist is because
            // setting these items via the selection font doen't work because
            // a null selection font is returned for a selection with more 
            // than one font!

            int rtb1start = rtb1.SelectionStart;
            int len = rtb1.SelectionLength;
            int rtbTempStart = 0;

            // If len <= 1 and there is a selection font, amend and return
            if (len <= 1 && rtb1.SelectionFont != null)
            {
                rtb1.SelectionFont =
                    new Font(fontFamily, rtb1.SelectionFont.Size, rtb1.SelectionFont.Style);
                return;
            }

            // Step through the selected text one char at a time
            rtbTemp.Rtf = rtb1.SelectedRtf;
            for (int i = 0; i < len; ++i)
            {
                rtbTemp.Select(rtbTempStart + i, 1);
                rtbTemp.SelectionFont = new Font(fontFamily, rtbTemp.SelectionFont.Size, rtbTemp.SelectionFont.Style);
            }

            // Replace & reselect
            rtbTemp.Select(rtbTempStart, len);
            rtb1.SelectedRtf = rtbTemp.SelectedRtf;
            rtb1.Select(rtb1start, len);
            return;
        }
        #endregion

        #region Change font style
        /// <summary>
        ///     Change the richtextbox style for the current selection
        /// </summary>
        public void ChangeFontStyle(FontStyle style, bool add)
        {
            //This method should handle cases that occur when multiple fonts/styles are selected
            // Parameters:-
            //	style - eg FontStyle.Bold
            //	add - IF true then add else remove

            // throw error if style isn't: bold, italic, strikeout or underline
            if (style != FontStyle.Bold
                && style != FontStyle.Italic
                && style != FontStyle.Strikeout
                && style != FontStyle.Underline)
                throw new System.InvalidProgramException("Invalid style parameter to ChangeFontStyle");

            int rtb1start = rtb1.SelectionStart;
            int len = rtb1.SelectionLength;
            int rtbTempStart = 0;

            //if len <= 1 and there is a selection font then just handle and return
            if (len <= 1 && rtb1.SelectionFont != null)
            {
                //add or remove style 
                if (add)
                    rtb1.SelectionFont = new Font(rtb1.SelectionFont, rtb1.SelectionFont.Style | style);
                else
                    rtb1.SelectionFont = new Font(rtb1.SelectionFont, rtb1.SelectionFont.Style & ~style);

                return;
            }

            // Step through the selected text one char at a time	
            rtbTemp.Rtf = rtb1.SelectedRtf;
            for (int i = 0; i < len; ++i)
            {
                rtbTemp.Select(rtbTempStart + i, 1);

                //add or remove style 
                if (add)
                    rtbTemp.SelectionFont = new Font(rtbTemp.SelectionFont, rtbTemp.SelectionFont.Style | style);
                else
                    rtbTemp.SelectionFont = new Font(rtbTemp.SelectionFont, rtbTemp.SelectionFont.Style & ~style);
            }

            // Replace & reselect
            rtbTemp.Select(rtbTempStart, len);
            rtb1.SelectedRtf = rtbTemp.SelectedRtf;
            rtb1.Select(rtb1start, len);
            return;
        }
        #endregion

        #region Change font size
        /// <summary>
        ///     Change the richtextbox font size for the current selection
        /// </summary>
        public void ChangeFontSize(float fontSize)
        {
            //This method should handle cases that occur when multiple fonts/styles are selected
            // Parameters:-
            // fontSize - the fontsize to be applied, eg 33.5

            if (fontSize <= 0.0)
                throw new System.InvalidProgramException("Invalid font size parameter to ChangeFontSize");

            int rtb1start = rtb1.SelectionStart;
            int len = rtb1.SelectionLength;
            int rtbTempStart = 0;

            // If len <= 1 and there is a selection font, amend and return
            if (len <= 1 && rtb1.SelectionFont != null)
            {
                rtb1.SelectionFont =
                    new Font(rtb1.SelectionFont.FontFamily, fontSize, rtb1.SelectionFont.Style);
                return;
            }

            // Step through the selected text one char at a time
            rtbTemp.Rtf = rtb1.SelectedRtf;
            for (int i = 0; i < len; ++i)
            {
                rtbTemp.Select(rtbTempStart + i, 1);
                rtbTemp.SelectionFont = new Font(rtbTemp.SelectionFont.FontFamily, fontSize, rtbTemp.SelectionFont.Style);
            }

            // Replace & reselect
            rtbTemp.Select(rtbTempStart, len);
            rtb1.SelectedRtf = rtbTemp.SelectedRtf;
            rtb1.Select(rtb1start, len);
            return;
        }
        #endregion

        #region Change font color
        /// <summary>
        ///     Change the richtextbox font color for the current selection
        /// </summary>
        public void ChangeFontColor(Color newColor)
        {
            //This method should handle cases that occur when multiple fonts/styles are selected
            // Parameters:-
            //	newColor - eg Color.Red

            int rtb1start = rtb1.SelectionStart;
            int len = rtb1.SelectionLength;
            int rtbTempStart = 0;

            //if len <= 1 and there is a selection font then just handle and return
            if (len <= 1 && rtb1.SelectionFont != null)
            {
                rtb1.SelectionColor = newColor;
                return;
            }

            // Step through the selected text one char at a time	
            rtbTemp.Rtf = rtb1.SelectedRtf;
            for (int i = 0; i < len; ++i)
            {
                rtbTemp.Select(rtbTempStart + i, 1);

                //change color
                rtbTemp.SelectionColor = newColor;
            }

            // Replace & reselect
            rtbTemp.Select(rtbTempStart, len);
            rtb1.SelectedRtf = rtbTemp.SelectedRtf;
            rtb1.Select(rtb1start, len);
            return;
        }
        #endregion

        public Font GetFontDetails()
        {
            //This method should handle cases that occur when multiple fonts/styles are selected

            int rtb1start = rtb1.SelectionStart;
            int len = rtb1.SelectionLength;
            int rtbTempStart = 0;

            if (len <= 1)
            {
                // Return the selection or default font
                if (rtb1.SelectionFont != null)
                    return rtb1.SelectionFont;
                else
                    return rtb1.Font;
            }

            // Step through the selected text one char at a time	
            // after setting defaults from first char
            rtbTemp.Rtf = rtb1.SelectedRtf;

            //Turn everything on so we can turn it off one by one
            FontStyle replystyle =
                FontStyle.Bold | FontStyle.Italic | FontStyle.Strikeout | FontStyle.Underline;

            // Set reply font, size and style to that of first char in selection.
            rtbTemp.Select(rtbTempStart, 1);
            string replyfont = rtbTemp.SelectionFont.Name;
            float replyfontsize = rtbTemp.SelectionFont.Size;
            replystyle = replystyle & rtbTemp.SelectionFont.Style;

            // Search the rest of the selection
            for (int i = 1; i < len; ++i)
            {
                rtbTemp.Select(rtbTempStart + i, 1);

                // Check reply for different style
                replystyle = replystyle & rtbTemp.SelectionFont.Style;

                // Check font
                if (replyfont != rtbTemp.SelectionFont.FontFamily.Name)
                    replyfont = "";

                // Check font size
                if (replyfontsize != rtbTemp.SelectionFont.Size)
                    replyfontsize = (float)0.0;
            }

            // Now set font and size if more than one font or font size was selected
            if (replyfont == "")
                replyfont = rtbTemp.Font.FontFamily.Name;

            if (replyfontsize == 0.0)
                replyfontsize = rtbTemp.Font.Size;

            // generate reply font
            Font reply
                = new Font(replyfont, replyfontsize, replystyle);

            return reply;
        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            // true if style to be added
            // false to remove style
            ToolStripButton button;
            button = e.ClickedItem as ToolStripButton;

            if (button != null)
            {
                bool add = button.Checked;

                //Switch based on the tag of the button pressed
                switch (button.Tag.ToString().ToLower())
                {
                    case "bold":
                        ChangeFontStyle(FontStyle.Bold, add);
                        break;
                    case "italic":
                        ChangeFontStyle(FontStyle.Italic, add);
                        break;
                    case "underline":
                        ChangeFontStyle(FontStyle.Underline, add);
                        break;
                    case "strikeout":
                        ChangeFontStyle(FontStyle.Strikeout, add);
                        break;
                    case "left":
                        //change horizontal alignment to left
                        rtb1.SelectionAlignment = HorizontalAlignment.Left;
                        tsbCenter.Checked = false;
                        tsbRight.Checked = false;
                        break;
                    case "center":
                        //change horizontal alignment to center
                        tsbLeft.Checked = false;
                        rtb1.SelectionAlignment = HorizontalAlignment.Center;
                        tsbRight.Checked = false;
                        break;
                    case "right":
                        //change horizontal alignment to right
                        tsbLeft.Checked = false;
                        tsbCenter.Checked = false;
                        rtb1.SelectionAlignment = HorizontalAlignment.Right;
                        break;
                    case "edit stamp":
                        OnStamp(new EventArgs()); //send stamp event
                        break;
                    case "color":
                        rtb1.SelectionColor = Color.Black;
                        break;
                    case "undo":
                        rtb1.Undo();
                        break;
                    case "redo":
                        rtb1.Redo();
                        break;
                    case "open":
                        try
                        {
                            if (ofd1.ShowDialog() == DialogResult.OK && ofd1.FileName.Length > 0)
                                if (System.IO.Path.GetExtension(ofd1.FileName).ToLower().Equals(".rtf"))
                                    rtb1.LoadFile(ofd1.FileName, RichTextBoxStreamType.RichText);
                                else
                                    rtb1.LoadFile(ofd1.FileName, RichTextBoxStreamType.PlainText);
                        }
                        catch (ArgumentException ae)
                        {
                            if (ae.Message == "Invalid file format.")
                                MessageBox.Show("There was an error loading the file: " + ofd1.FileName);
                        }
                        break;
                    case "save":
                        if (sfd1.ShowDialog() == DialogResult.OK && sfd1.FileName.Length > 0)
                            if (System.IO.Path.GetExtension(sfd1.FileName).ToLower().Equals(".rtf"))
                                rtb1.SaveFile(sfd1.FileName);
                            else
                                rtb1.SaveFile(sfd1.FileName, RichTextBoxStreamType.PlainText);
                        break;
                    case "cut":
                        {
                            if (rtb1.SelectedText.Length <= 0) break;
                            rtb1.Cut();
                            break;
                        }
                    case "copy":
                        {
                            if (rtb1.SelectedText.Length <= 0) break;
                            rtb1.Copy();
                            break;
                        }
                    case "paste":
                        {
                            try
                            {
                                rtb1.Paste();
                            }
                            catch
                            {
                                MessageBox.Show("Paste Failed");
                            }
                            break;
                        }
                } //end select
            }
        }

        private void rtb1_SelectionChanged(object sender, System.EventArgs e)
        {
            //Update the toolbar buttons
            UpdateToolbar();

            //Send the SelChangedEvent
            if (SelChanged != null)
                SelChanged(this, e);
        }

        private void Color_Click(object sender, System.EventArgs e)
        {
            //set the richtextbox color based on the name of the menu item
            ChangeFontColor((Color)((ToolStripMenuItem)sender).Tag);
        }

        private void Font_Click(object sender, System.EventArgs e)
        {
            // Set the font for the entire selection
            ChangeFont((string)((ToolStripMenuItem)sender).Tag);
        }

        private void FontSize_Click(object sender, System.EventArgs e)
        {
            //set the richtextbox font size based on the name of the menu item
            ChangeFontSize((int)((ToolStripMenuItem)sender).Tag);
        }

        private void rtb1_LinkClicked(object sender, System.Windows.Forms.LinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(e.LinkText);
        }

        private void rtb1_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.Modifiers == Keys.Control)
            {
                ToolStripButton tsb = null;

                switch (e.KeyCode)
                {
                    case Keys.B:
                        tsb = this.tsbBold;
                        break;
                    case Keys.I:
                        tsb = this.tsbItalic;
                        break;
                    case Keys.S:
                        tsb = this.tsbStamp;
                        break;
                    case Keys.U:
                        tsb = this.tsbUnderline;
                        break;
                    case Keys.OemMinus:
                        tsb = this.tsbStrikeout;
                        break;
                }

                if (tsb != null)
                {
                    if (e.KeyCode != Keys.S) tsb.Checked = !tsb.Checked;
                    toolStrip1_ItemClicked(tsb, new ToolStripItemClickedEventArgs(tsb));
                }
            }

            //Insert a tab if the tab key was pressed.
            /* NOTE: This was needed because in rtb1_KeyPress I tell the richtextbox not
             * to handle tab events.  I do that because CTRL+I inserts a tab for some
             * strange reason.  What was MicroSoft thinking?
             * Richard Parsons 02/08/2007
             */
            if (e.KeyCode == Keys.Tab)
                rtb1.SelectedText = "\t";

        }

        private void rtb1_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            if ((int)e.KeyChar == 9)
                e.Handled = true; // Stops Ctrl+I from inserting a tab (char HT) into the richtextbox
        }
    }
}
