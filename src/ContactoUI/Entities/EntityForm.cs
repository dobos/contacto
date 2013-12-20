using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace Contacto.UI
{
    public class EntityForm : ViewForm
    {
        private delegate bool Operation(Contacto.Lib.Context context, bool forceOperation);

        protected Contacto.Lib.Entity item;

        protected ComboBox displayName;
        protected Label displayNameLabel;

        protected TabControl tab;
        protected TabPage tabDocuments;
        protected DocumentList documentList;
        protected TabPage tabPersons;
        protected TabPage tabAttributes;
        protected AttributeList attributeList;
        protected TabPage tabLinks;
        protected LinkList linkList;
        protected TabPage tabDates;
        protected DateList dateList;
        protected TabPage tabCategories;
        protected CategoryList categoryList;
        protected TabPage tabProperties;
        protected TabPage tabBlobs;
        protected BlobList blobList;
        private Contacto.UI.PersonList personList;
        private TabPage tabTag;
        private TagList tagList;
        private Label numberLabel;
        protected TextBox number;
        protected PropertyList propertyList;


        public EntityForm()
            : base()
        {
            InitializeComponent();

            personList.ToolStripVisible = true;
            documentList.ToolStripVisible = true;
        }

        public EntityForm(Main form)
            : base(form)
        {
            InitializeComponent();

            this.topPanel.Controls.Add(numberLabel, 2, 0);
            this.topPanel.Controls.Add(number, 3, 0);

            personList.ToolStripVisible = true;
            documentList.ToolStripVisible = true;

            Program.Settings.AttributeList.Apply(attributeList.listView);
            Program.Settings.LinkList.Apply(linkList.listView);
            Program.Settings.DateList.Apply(dateList.listView);
            Program.Settings.CategoryList.Apply(categoryList.listView);

            Program.Settings.BlobList.Apply(blobList.listView);
            Program.Settings.DocumentList.Apply(documentList.listView);
            Program.Settings.PersonList.Apply(personList.listView);
        }

        private void InitializeComponent()
        {
            this.displayName = new System.Windows.Forms.ComboBox();
            this.displayNameLabel = new System.Windows.Forms.Label();
            this.tab = new System.Windows.Forms.TabControl();
            this.tabDocuments = new System.Windows.Forms.TabPage();
            this.documentList = new Contacto.UI.DocumentList();
            this.tabBlobs = new System.Windows.Forms.TabPage();
            this.blobList = new Contacto.UI.BlobList();
            this.tabPersons = new System.Windows.Forms.TabPage();
            this.personList = new Contacto.UI.PersonList();
            this.tabAttributes = new System.Windows.Forms.TabPage();
            this.attributeList = new Contacto.UI.AttributeList();
            this.tabLinks = new System.Windows.Forms.TabPage();
            this.linkList = new Contacto.UI.LinkList();
            this.tabDates = new System.Windows.Forms.TabPage();
            this.dateList = new Contacto.UI.DateList();
            this.tabCategories = new System.Windows.Forms.TabPage();
            this.categoryList = new Contacto.UI.CategoryList();
            this.tabTag = new System.Windows.Forms.TabPage();
            this.tagList = new Contacto.UI.TagList();
            this.tabProperties = new System.Windows.Forms.TabPage();
            this.propertyList = new Contacto.UI.PropertyList();
            this.numberLabel = new System.Windows.Forms.Label();
            this.number = new System.Windows.Forms.TextBox();
            this.tab.SuspendLayout();
            this.tabDocuments.SuspendLayout();
            this.tabBlobs.SuspendLayout();
            this.tabPersons.SuspendLayout();
            this.tabAttributes.SuspendLayout();
            this.tabLinks.SuspendLayout();
            this.tabDates.SuspendLayout();
            this.tabCategories.SuspendLayout();
            this.tabTag.SuspendLayout();
            this.tabProperties.SuspendLayout();
            this.SuspendLayout();
            // 
            // displayName
            // 
            this.displayName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.displayName.Location = new System.Drawing.Point(110, 161);
            this.displayName.Margin = new System.Windows.Forms.Padding(2);
            this.displayName.Name = "displayName";
            this.displayName.Size = new System.Drawing.Size(121, 21);
            this.displayName.TabIndex = 0;
            // 
            // displayNameLabel
            // 
            this.displayNameLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.displayNameLabel.AutoSize = true;
            this.displayNameLabel.Location = new System.Drawing.Point(5, 164);
            this.displayNameLabel.Name = "displayNameLabel";
            this.displayNameLabel.Size = new System.Drawing.Size(72, 13);
            this.displayNameLabel.TabIndex = 0;
            this.displayNameLabel.Text = "Megjelenítve:";
            // 
            // tab
            // 
            this.tab.Controls.Add(this.tabDocuments);
            this.tab.Controls.Add(this.tabBlobs);
            this.tab.Controls.Add(this.tabPersons);
            this.tab.Controls.Add(this.tabAttributes);
            this.tab.Controls.Add(this.tabLinks);
            this.tab.Controls.Add(this.tabDates);
            this.tab.Controls.Add(this.tabCategories);
            this.tab.Controls.Add(this.tabTag);
            this.tab.Controls.Add(this.tabProperties);
            this.tab.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tab.Location = new System.Drawing.Point(0, 24);
            this.tab.Name = "tab";
            this.tab.SelectedIndex = 0;
            this.tab.Size = new System.Drawing.Size(742, 607);
            this.tab.TabIndex = 26;
            this.tab.Selected += new System.Windows.Forms.TabControlEventHandler(this.tab_Selected);
            // 
            // tabDocuments
            // 
            this.tabDocuments.Controls.Add(this.documentList);
            this.tabDocuments.Location = new System.Drawing.Point(4, 22);
            this.tabDocuments.Name = "tabDocuments";
            this.tabDocuments.Padding = new System.Windows.Forms.Padding(3);
            this.tabDocuments.Size = new System.Drawing.Size(734, 581);
            this.tabDocuments.TabIndex = 3;
            this.tabDocuments.Text = "Dokumentumok";
            this.tabDocuments.UseVisualStyleBackColor = true;
            // 
            // documentList
            // 
            this.documentList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.documentList.Location = new System.Drawing.Point(3, 3);
            this.documentList.Name = "documentList";
            this.documentList.ParentEntity = null;
            this.documentList.ReadOnly = false;
            this.documentList.Size = new System.Drawing.Size(728, 575);
            this.documentList.TabIndex = 0;
            this.documentList.ToolStripVisible = false;
            this.documentList.TreeVisible = false;
            // 
            // tabBlobs
            // 
            this.tabBlobs.Controls.Add(this.blobList);
            this.tabBlobs.Location = new System.Drawing.Point(4, 22);
            this.tabBlobs.Name = "tabBlobs";
            this.tabBlobs.Padding = new System.Windows.Forms.Padding(3);
            this.tabBlobs.Size = new System.Drawing.Size(734, 581);
            this.tabBlobs.TabIndex = 7;
            this.tabBlobs.Text = "Fájlok";
            this.tabBlobs.UseVisualStyleBackColor = true;
            // 
            // blobList
            // 
            this.blobList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.blobList.Location = new System.Drawing.Point(3, 3);
            this.blobList.Name = "blobList";
            this.blobList.ParentEntity = null;
            this.blobList.ReadOnly = false;
            this.blobList.Size = new System.Drawing.Size(728, 575);
            this.blobList.TabIndex = 0;
            // 
            // tabPersons
            // 
            this.tabPersons.Controls.Add(this.personList);
            this.tabPersons.Location = new System.Drawing.Point(4, 22);
            this.tabPersons.Name = "tabPersons";
            this.tabPersons.Padding = new System.Windows.Forms.Padding(3);
            this.tabPersons.Size = new System.Drawing.Size(734, 581);
            this.tabPersons.TabIndex = 0;
            this.tabPersons.Text = "Névjegyek";
            this.tabPersons.UseVisualStyleBackColor = true;
            // 
            // personList
            // 
            this.personList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.personList.Location = new System.Drawing.Point(3, 3);
            this.personList.Name = "personList";
            this.personList.ParentEntity = null;
            this.personList.ReadOnly = false;
            this.personList.Size = new System.Drawing.Size(728, 575);
            this.personList.TabIndex = 0;
            this.personList.ToolStripVisible = false;
            // 
            // tabAttributes
            // 
            this.tabAttributes.Controls.Add(this.attributeList);
            this.tabAttributes.Location = new System.Drawing.Point(4, 22);
            this.tabAttributes.Name = "tabAttributes";
            this.tabAttributes.Padding = new System.Windows.Forms.Padding(3);
            this.tabAttributes.Size = new System.Drawing.Size(734, 581);
            this.tabAttributes.TabIndex = 1;
            this.tabAttributes.Text = "Elérhetõségek";
            this.tabAttributes.UseVisualStyleBackColor = true;
            // 
            // attributeList
            // 
            this.attributeList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.attributeList.Location = new System.Drawing.Point(3, 3);
            this.attributeList.Name = "attributeList";
            this.attributeList.ParentEntity = null;
            this.attributeList.ReadOnly = false;
            this.attributeList.Size = new System.Drawing.Size(728, 575);
            this.attributeList.TabIndex = 0;
            // 
            // tabLinks
            // 
            this.tabLinks.Controls.Add(this.linkList);
            this.tabLinks.Location = new System.Drawing.Point(4, 22);
            this.tabLinks.Name = "tabLinks";
            this.tabLinks.Padding = new System.Windows.Forms.Padding(3);
            this.tabLinks.Size = new System.Drawing.Size(734, 581);
            this.tabLinks.TabIndex = 5;
            this.tabLinks.Text = "Hivatkozások";
            this.tabLinks.UseVisualStyleBackColor = true;
            // 
            // linkList
            // 
            this.linkList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.linkList.Location = new System.Drawing.Point(3, 3);
            this.linkList.Name = "linkList";
            this.linkList.ParentEntity = null;
            this.linkList.ReadOnly = false;
            this.linkList.Size = new System.Drawing.Size(728, 575);
            this.linkList.TabIndex = 0;
            // 
            // tabDates
            // 
            this.tabDates.Controls.Add(this.dateList);
            this.tabDates.Location = new System.Drawing.Point(4, 22);
            this.tabDates.Name = "tabDates";
            this.tabDates.Padding = new System.Windows.Forms.Padding(3);
            this.tabDates.Size = new System.Drawing.Size(734, 581);
            this.tabDates.TabIndex = 6;
            this.tabDates.Text = "Dátumok";
            this.tabDates.UseVisualStyleBackColor = true;
            // 
            // dateList
            // 
            this.dateList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dateList.Location = new System.Drawing.Point(3, 3);
            this.dateList.Name = "dateList";
            this.dateList.ParentEntity = null;
            this.dateList.ReadOnly = false;
            this.dateList.Size = new System.Drawing.Size(728, 575);
            this.dateList.TabIndex = 0;
            // 
            // tabCategories
            // 
            this.tabCategories.Controls.Add(this.categoryList);
            this.tabCategories.Location = new System.Drawing.Point(4, 22);
            this.tabCategories.Name = "tabCategories";
            this.tabCategories.Padding = new System.Windows.Forms.Padding(3);
            this.tabCategories.Size = new System.Drawing.Size(734, 581);
            this.tabCategories.TabIndex = 2;
            this.tabCategories.Text = "Kategóriák";
            this.tabCategories.UseVisualStyleBackColor = true;
            // 
            // categoryList
            // 
            this.categoryList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.categoryList.Location = new System.Drawing.Point(3, 3);
            this.categoryList.Name = "categoryList";
            this.categoryList.ParentEntity = null;
            this.categoryList.ReadOnly = false;
            this.categoryList.Size = new System.Drawing.Size(728, 575);
            this.categoryList.TabIndex = 0;
            // 
            // tabTag
            // 
            this.tabTag.Controls.Add(this.tagList);
            this.tabTag.Location = new System.Drawing.Point(4, 22);
            this.tabTag.Name = "tabTag";
            this.tabTag.Size = new System.Drawing.Size(734, 581);
            this.tabTag.TabIndex = 8;
            this.tabTag.Text = "Jegyzetek";
            this.tabTag.UseVisualStyleBackColor = true;
            // 
            // tagList
            // 
            this.tagList.AcceptsTab = false;
            this.tagList.AutoScroll = true;
            this.tagList.AutoWordSelection = true;
            this.tagList.DetectURLs = true;
            this.tagList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tagList.Location = new System.Drawing.Point(0, 0);
            this.tagList.Name = "tagList";
            this.tagList.Padding = new System.Windows.Forms.Padding(3);
            this.tagList.ParentEntity = null;
            this.tagList.ReadOnly = false;
            // 
            // 
            // 
            this.tagList.RichTextBox.AutoWordSelection = true;
            this.tagList.RichTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tagList.RichTextBox.Location = new System.Drawing.Point(3, 28);
            this.tagList.RichTextBox.Name = "rtb1";
            this.tagList.RichTextBox.Size = new System.Drawing.Size(728, 550);
            this.tagList.RichTextBox.TabIndex = 4;
            this.tagList.ShowBold = false;
            this.tagList.ShowCenterJustify = false;
            this.tagList.ShowColors = false;
            this.tagList.ShowCopy = false;
            this.tagList.ShowCut = false;
            this.tagList.ShowFont = false;
            this.tagList.ShowFontSize = false;
            this.tagList.ShowItalic = false;
            this.tagList.ShowLeftJustify = false;
            this.tagList.ShowOpen = false;
            this.tagList.ShowPaste = false;
            this.tagList.ShowRedo = false;
            this.tagList.ShowRightJustify = false;
            this.tagList.ShowSave = false;
            this.tagList.ShowStamp = false;
            this.tagList.ShowStrikeout = false;
            this.tagList.ShowToolBarText = false;
            this.tagList.ShowUnderline = false;
            this.tagList.ShowUndo = false;
            this.tagList.Size = new System.Drawing.Size(734, 581);
            this.tagList.StampAction = Contacto.UI.TagList.StampActions.EditedBy;
            this.tagList.StampColor = System.Drawing.Color.Blue;
            this.tagList.TabIndex = 0;
            // 
            // 
            // 
            this.tagList.ToolStrip.Location = new System.Drawing.Point(3, 3);
            this.tagList.ToolStrip.Name = "toolStrip1";
            this.tagList.ToolStrip.Size = new System.Drawing.Size(728, 25);
            this.tagList.ToolStrip.TabIndex = 3;
            this.tagList.ToolStrip.Text = "toolStrip1";
            // 
            // tabProperties
            // 
            this.tabProperties.Controls.Add(this.propertyList);
            this.tabProperties.Location = new System.Drawing.Point(4, 22);
            this.tabProperties.Name = "tabProperties";
            this.tabProperties.Padding = new System.Windows.Forms.Padding(3);
            this.tabProperties.Size = new System.Drawing.Size(734, 581);
            this.tabProperties.TabIndex = 4;
            this.tabProperties.Text = "Tulajdonságok";
            this.tabProperties.UseVisualStyleBackColor = true;
            // 
            // propertyList
            // 
            this.propertyList.AutoScroll = true;
            this.propertyList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.propertyList.Location = new System.Drawing.Point(3, 3);
            this.propertyList.Name = "propertyList";
            this.propertyList.ParentEntity = null;
            this.propertyList.Size = new System.Drawing.Size(728, 575);
            this.propertyList.TabIndex = 0;
            // 
            // numberLabel
            // 
            this.numberLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.numberLabel.AutoSize = true;
            this.numberLabel.Location = new System.Drawing.Point(585, 0);
            this.numberLabel.Name = "numberLabel";
            this.numberLabel.Size = new System.Drawing.Size(35, 13);
            this.numberLabel.TabIndex = 27;
            this.numberLabel.Text = "Iktatószám:";
            this.numberLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // number
            // 
            this.number.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.number.Location = new System.Drawing.Point(665, 3);
            this.number.Name = "number";
            this.number.Size = new System.Drawing.Size(74, 20);
            this.number.TabIndex = 28;
            // 
            // EntityForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.Controls.Add(this.tab);
            this.Controls.Add(this.displayNameLabel);
            this.Controls.Add(this.displayName);
            this.Name = "EntityForm";
            this.Size = new System.Drawing.Size(742, 631);
            this.Resize += new System.EventHandler(this.EntityForm_Resize);
            this.Controls.SetChildIndex(this.displayName, 0);
            this.Controls.SetChildIndex(this.displayNameLabel, 0);
            this.Controls.SetChildIndex(this.tab, 0);
            this.tab.ResumeLayout(false);
            this.tabDocuments.ResumeLayout(false);
            this.tabBlobs.ResumeLayout(false);
            this.tabPersons.ResumeLayout(false);
            this.tabAttributes.ResumeLayout(false);
            this.tabLinks.ResumeLayout(false);
            this.tabDates.ResumeLayout(false);
            this.tabCategories.ResumeLayout(false);
            this.tabTag.ResumeLayout(false);
            this.tabProperties.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        public virtual bool CreateEntity(Contacto.Lib.Entity parentEntity)
        {
            throw new NotImplementedException();
        }

        public virtual bool LoadEntity(Guid guid)
        {
            LoadFields();
            RefreshAttributeLists(tab.SelectedTab.Controls[0]);

            return true;
        }

        private bool TryOperation(Operation operation, string invalidVersionMessage, Contacto.Lib.LogOperations logOperation, string errorMessage)
        {
            bool forceOperation = false;

            while (true)
            {
                using (Contacto.Lib.Context context = ContextManager.CreateContext(this, true))
                {
                    try
                    {
                        return operation(context, forceOperation);
                    }
                    catch (Contacto.Lib.InvalidVersionException)
                    {
                        if (MessageBox.Show(invalidVersionMessage, Application.ProductName, MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation) == DialogResult.OK)
                        {
                            context.Rollback();
                            forceOperation = true;
                            continue;
                        }
                        else
                            return false;
                    }
                    catch (System.Exception ex)
                    {
                        Contacto.Lib.LogEntry log = new Contacto.Lib.LogEntry(context, item, logOperation);
                        Program.HandleError(context, errorMessage, log, ex);
                        return false;
                    }
                }
            }
        }

        public virtual bool SaveEntity()
        {
            if (ValidateChildren())
            {
                SaveFields();

                tagList.Save();

                if (!CheckDuplicates())
                    return false;

                bool forceOverwrite = false;
                while (true)
                {
                    using (Contacto.Lib.Context context = ContextManager.CreateContext(this, true))
                    {
                        try
                        {
                            bool enque = (item.Guid == Guid.Empty);

                            item.Context = context;
                            item.Save(forceOverwrite);

                            // ***
                            context.Commit();
                            context.BeginTransaction();

                            if (enque)
                                ((Main)FindForm()).Navigator.Enque(item);

                            LoadFields();
                            RefreshAttributeLists(tab.SelectedTab.Controls[0]);

                            return true;
                        }
                        catch (Contacto.Lib.InvalidVersionException)
                        {
                            if (MessageBox.Show(Messages.InvalidVersionModify, Application.ProductName, MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation) == DialogResult.OK)
                            {
                                context.Rollback();
                                forceOverwrite = true;
                                continue;
                            }
                            else
                                return false;
                        }
                        catch (System.Exception ex)
                        {
                            Contacto.Lib.LogEntry log = new Contacto.Lib.LogEntry(context, item, Contacto.Lib.LogOperations.SaveEntity);
                            Program.HandleError(context, Messages.ErrorSavingEntity, log, ex);
                        }
                    }
                }
            }
            return false;
        }

        public virtual bool CloseEntity()
        {
            if (item.CanClose())
            {
                return TryOperation(
                    delegate(Contacto.Lib.Context context, bool forceOperation)
                    {
                        item.Context = context;
                        item.Close(forceOperation);

                        LoadFields();
                        return true;
                    },
                    Messages.InvalidVersionModify,
                    Contacto.Lib.LogOperations.CloseEntity,
                    Messages.ErrorClosingEntity);
            }
            return false;
        }

        public virtual bool OpenEntity()
        {
            if (item.CanOpen())
            {
                return TryOperation(
                    delegate(Contacto.Lib.Context context, bool forceOperation)
                    {
                        item.Context = context;
                        item.Open(forceOperation);

                        LoadFields();
                        return true;
                    },
                    Messages.InvalidVersionModify,
                    Contacto.Lib.LogOperations.OpenEntity,
                    Messages.ErrorOpeningEntity);
            }
            return false;
        }

        private bool CheckDuplicates()
        {
            if (item.Guid == Guid.Empty)
            {
                List<Contacto.Lib.Entity> duplicates = null;
                using (Contacto.Lib.Context context = ContextManager.CreateContext(this, true))
                {
                    try
                    {
                        item.Context = context;
                        duplicates = new List<Contacto.Lib.Entity>(item.CheckDuplicates());
                    }
                    catch (System.Exception ex)
                    {
                        Contacto.Lib.LogEntry log = new Contacto.Lib.LogEntry(context, item, Contacto.Lib.LogOperations.SaveEntity);
                        Program.HandleError(context, Messages.ErrorSavingEntity, log, ex);
                        return false;
                    }
                }
                if (duplicates.Count > 0)
                {
                    Duplicates df = new Duplicates();
                    df.Entities = duplicates;
                    if (df.ShowDialog() == DialogResult.Cancel)
                        return false;
                }
            }
            return true;
        }

        public bool DeleteEntity()
        {
            return DeleteEntity(item);
        }

        public static bool DeleteEntity(Contacto.Lib.Entity entity)
        {
            if (MessageBox.Show(string.Format(Messages.ConfirmDeleteEntity, entity.DisplayName), Application.ProductName, MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.OK)
            {

                bool forceDelete = false;
                while (true)
                {
                    //******
                    using (Contacto.Lib.Context context = ContextManager.CreateContext(null, true))
                    {
                        try
                        {
                            entity.Context = context;
                            entity.Delete(forceDelete);

                            return true;
                        }
                        catch (Contacto.Lib.InvalidVersionException)
                        {
                            if (MessageBox.Show(Messages.InvalidVersionDelete, Application.ProductName, MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation) == DialogResult.OK)
                            {
                                context.Rollback();
                                forceDelete = true;
                                continue;
                            }
                            else
                                return false;
                        }
                        catch (System.Exception ex)
                        {
                            Contacto.Lib.LogEntry log = new Contacto.Lib.LogEntry(context, entity, Contacto.Lib.LogOperations.DeleteEntity);
                            Program.HandleError(context, Messages.ErrorDeletingEntity, log, ex);
                            return false;
                        }
                    }
                }
            }
            else
                return false;
        }

        protected virtual void LoadFields()
        {
            using (Contacto.Lib.Context context = ContextManager.CreateContext(this, false))
            {
                this.topLabel.Text = item.DisplayName + " - " + context.SchemaManager.GetEntityDescription(item.EntityType);
            }

            RefreshDisplayNameList();
            Modified = false;

            UpdateEnable();
        }

        protected override void UpdateEnable()
        {
            base.UpdateEnable();

            bool newitem = (item.Guid == Guid.Empty);

            tab.Enabled = !newitem;

            // lock, if deleted
            if (item.Deleted)
            {
                this.topLabel.Text += " - " + Messages.Deleted;
            }
            if (item.Closed)
            {
                this.topLabel.Text += " - " + Messages.Closed;
            }
            if (item.ReadOnly)
            {
                this.topLabel.Text += " - " + Messages.ReadOnly;
            }

            bool enabled = !(item.Deleted || item.Closed || item.ReadOnly);

            displayName.Enabled = enabled;
            numberLabel.Enabled = enabled;

            documentList.ReadOnly = !enabled;
            attributeList.ReadOnly = !enabled;
            linkList.ReadOnly = !enabled;
            dateList.ReadOnly = !enabled;
            categoryList.ReadOnly = !enabled;
            blobList.ReadOnly = !enabled;
            personList.ReadOnly = !enabled;
            tagList.ReadOnly = !enabled;
        }

        protected virtual void SaveFields()
        {
            throw new NotImplementedException();
        }

        protected virtual void RefreshDisplayNameList()
        {
            displayName.Items.Clear();
            displayName.Items.AddRange(item.GetDisplayTextAlternates());
            if (displayName.Text == string.Empty)
                displayName.Text = (string)displayName.Items[0];
        }

        protected void RefreshAttributeLists(object sender)
        {
            if (item != null)
            {
                if (sender == documentList)
                {
                    documentList.ParentEntity = item;
                }
                if (sender == blobList)
                {
                    RefreshBlobList();
                }
                else if (sender == personList)
                {
                    RefreshPersonList();
                }
                else if (sender == attributeList)
                {
                    RefreshAttributeList();
                }
                else if (sender == linkList)
                {
                    RefreshLinkList();
                }
                else if (sender == dateList)
                {
                    RefreshDateList();
                }
                else if (sender == categoryList)
                {
                    RefreshCategoryList();
                }
                else if (sender == tagList)
                {
                    tagList.ParentEntity = item;
                }
                else if (sender == propertyList)
                {
                    propertyList.ParentEntity = item;
                }
            }
        }

        private void RefreshBlobList()
        {
            Contacto.Lib.Document doc = item as Contacto.Lib.Document;
            if (doc != null)
            {
                if (doc.Blobs == null)
                {
                    using (Contacto.Lib.Context context = ContextManager.CreateContext(this, true))
                    {
                        try
                        {
                            doc.Context = context;
                            doc.LoadBlobs();
                        }
                        catch (System.Exception ex)
                        {
                            Contacto.Lib.LogEntry log = new Contacto.Lib.LogEntry(context, item, Contacto.Lib.LogOperations.LoadBlobs);
                            Program.HandleError(context, Messages.ErrorLoadingBlobs, log, ex);
                            return;
                        }
                    }
                }

                blobList.ParentEntity = doc;
            }
        }

        private void RefreshPersonList()
        {
            Contacto.Lib.Company c = item as Contacto.Lib.Company;

            if (c != null)
            {
                if (c.Persons == null)
                {
                    using (Contacto.Lib.Context context = ContextManager.CreateContext(this, true))
                    {
                        try
                        {
                            c.Context = context;
                            c.LoadPersons();
                        }
                        catch (System.Exception ex)
                        {
                            Contacto.Lib.LogEntry log = new Contacto.Lib.LogEntry(context, item, Contacto.Lib.LogOperations.LoadPersons);
                            Program.HandleError(context, Messages.ErrorLoadingPersons, log, ex);
                            return;
                        }
                    }
                }
                personList.ParentEntity = c;
            }
        }

        private void RefreshAttributeList()
        {
            if (item.Addresses == null || item.Identifiers == null)
            {
                using (Contacto.Lib.Context context = ContextManager.CreateContext(this, true))
                {
                    try
                    {
                        item.Context = context;
                        item.LoadAddresses();
                        item.LoadIdentifiers();
                    }
                    catch (System.Exception ex)
                    {
                        Contacto.Lib.LogEntry log = new Contacto.Lib.LogEntry(context, item, Contacto.Lib.LogOperations.LoadAttributes);
                        Program.HandleError(context, Messages.ErrorLoadingAttributes, log, ex);
                        return;
                    }
                }
            }
            attributeList.ParentEntity = item;
        }

        private void RefreshLinkList()
        {
            if (item.Links == null)
            {
                using (Contacto.Lib.Context context = ContextManager.CreateContext(this, true))
                {
                    try
                    {
                        item.Context = context;
                        item.LoadLinks();
                    }
                    catch (System.Exception ex)
                    {
                        Contacto.Lib.LogEntry log = new Contacto.Lib.LogEntry(context, item, Contacto.Lib.LogOperations.LoadLinks);
                        Program.HandleError(context, Messages.ErrorLoadingLinks, log, ex);
                        return;
                    }
                }
            }
            linkList.ParentEntity = item;
        }

        private void RefreshDateList()
        {
            if (item.Dates == null)
            {
                using (Contacto.Lib.Context context = ContextManager.CreateContext(this, true))
                {
                    try
                    {
                        item.Context = context;
                        item.LoadDates();
                    }
                    catch (System.Exception ex)
                    {
                        Contacto.Lib.LogEntry log = new Contacto.Lib.LogEntry(context, item, Contacto.Lib.LogOperations.LoadDates);
                        Program.HandleError(context, Messages.ErrorLoadingDates, log, ex);
                        return;
                    }
                }
            }
            dateList.ParentEntity = item;
        }

        private void RefreshCategoryList()
        {
            if (item.Categories == null)
            {
                using (Contacto.Lib.Context context = ContextManager.CreateContext(this, true))
                {
                    try
                    {
                        item.Context = context;
                        item.LoadCategories();
                    }
                    catch (System.Exception ex)
                    {
                        Contacto.Lib.LogEntry log = new Contacto.Lib.LogEntry(context, item, Contacto.Lib.LogOperations.LoadCategories);
                        Program.HandleError(context, Messages.ErrorLoadingCategories, log, ex);
                        return;
                    }
                }
            }
            categoryList.ParentEntity = item;
        }

        public override bool Close()
        {

            Program.Settings.BlobList.Match(blobList.listView);
            Program.Settings.DocumentList.Match(documentList.listView);
            Program.Settings.PersonList.Match(personList.listView);
            Program.Settings.AttributeList.Match(attributeList.listView);
            Program.Settings.LinkList.Match(linkList.listView);
            Program.Settings.DateList.Match(dateList.listView);
            Program.Settings.CategoryList.Match(categoryList.listView);

            if (Modified)
            {
                FindForm().BringToFront();
                Application.DoEvents();
                switch (MessageBox.Show(Messages.SaveChanges, Application.ProductName, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1))
                {
                    case DialogResult.Yes:
                        return SaveEntity();
                    case DialogResult.No:
                        return true;
                    case DialogResult.Cancel:
                        return false;
                }

            }

            return true;
        }

        public override void Command(Commands command)
        {
            switch (command)
            {
                case Commands.Save:
                    SaveEntity();
                    break;
                case Commands.Lock:
                    CloseEntity();
                    break;
                case Commands.Unlock:
                    OpenEntity();
                    break;
                case Commands.Delete:
                    Delete();
                    break;
                case Commands.Reload:
                    Reload();
                    break;
                case Commands.Previous:
                    MovePrevious();
                    break;
                case Commands.Next:
                    MoveNext();
                    break;
            }
        }

        private void MovePrevious()
        {
            ((Main)FindForm()).MovePrevious(this.item);
        }

        private void MoveNext()
        {
            ((Main)FindForm()).MoveNext(this.item);
        }

        private void Delete()
        {
            if (DeleteEntity())
            {
                Main f = ((Main)FindForm());
                f.CloseView();
                f.Navigator.Deque(item);
            }
        }

        private bool Reload()
        {
            if (Modified)
            {
                switch (MessageBox.Show(Messages.SaveChanges, Application.ProductName, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1))
                {
                    case DialogResult.Yes:
                        SaveEntity();
                        break;
                    case DialogResult.No:
                        break;
                    case DialogResult.Cancel:
                        return false;
                }
            }

            return LoadEntity(item.Guid);
        }

        protected bool RequiredValidator(object sender, object[] controls)
        {
            List<object> l = new List<object>(controls);
            if (l.Contains(sender))
            {
                TextBox tb = sender as TextBox;
                if (tb != null)
                {
                    if (tb.Text.Trim() == string.Empty)
                    {
                        MessageBox.Show(Messages.InvalidValue, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return true;
                    }
                }

                ComboBox cb = sender as ComboBox;
                if (cb != null)
                {
                    if (cb.Text.Trim() == string.Empty)
                    {
                        MessageBox.Show(Messages.InvalidValue, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return true;
                    }
                }
            }
            return false;
        }

        private void tab_Selected(object sender, TabControlEventArgs e)
        {
            RefreshAttributeLists(tab.SelectedTab.Controls[0]);
        }

        private void EntityForm_Resize(object sender, EventArgs e)
        {
            SuspendLayout();

            tab.Width = Math.Max(ClientRectangle.Width - 2 * tab.Left, 0);
            tab.Height = Math.Max(ClientRectangle.Height - tab.Left - tab.Top, 0);

            ResumeLayout();
        }
    }
}

