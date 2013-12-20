using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace Contacto.UI
{
    public partial class Folder : EntityForm
    {
        public Folder(Main form)
            : base(form)
        {
            InitializeComponent();

            tab.TabPages.Remove(tabBlobs);
            tab.TabPages.Remove(tabPersons);
            tab.TabPages.Remove(tabAttributes);

            this.Controls.Remove(displayNameLabel);
            this.Controls.Remove(displayName);

            this.tableLayoutPanel1.Controls.Add(this.displayNameLabel, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.displayName, 1, 1);
        }

        public override bool CreateEntity(Contacto.Lib.Entity parentEntity)
        {
            using (Contacto.Lib.Context context = ContextManager.CreateContext(this, true))
            {
                try
                {
                    item = new Contacto.Lib.Folder(context);
                    item.NewEntity(parentEntity);

                    LoadFields();
                    return true;
                }
                catch (System.Exception ex)
                {
                    Contacto.Lib.LogEntry log = new Contacto.Lib.LogEntry(context, item, Contacto.Lib.LogOperations.CreateFolder);
                    Program.HandleError(context, Messages.ErrorCreatingFolder, log, ex);
                }
            }

            return false;
        }

        public override bool LoadEntity(Guid guid)
        {
            using (Contacto.Lib.Context context = ContextManager.CreateContext(this, true))
            {
                try
                {
                    item = new Contacto.Lib.Folder(context);
                    item.Guid = guid;
                    item.Load();

                    Contacto.Lib.Folder f = (Contacto.Lib.Folder)item;

                    f.LoadLinks();
                    f.LoadDates();

                    LoadFields();
                    RefreshAttributeLists(tab.SelectedTab.Controls[0]);
                    
                    return base.LoadEntity(guid);
                }
                catch (System.Exception ex)
                {
                    Contacto.Lib.LogEntry log = new Contacto.Lib.LogEntry(context, item, Contacto.Lib.LogOperations.LoadPerson);
                    Program.HandleError(context, Messages.ErrorLoadingPerson, log, ex);
                }
            }

            return false;
        }

        protected override void LoadFields()
        {
            Contacto.Lib.Folder f = (Contacto.Lib.Folder)item;

            this.title.Text = f.Title;
            this.displayName.Text = f.DisplayName;
            this.number.Text = f.Number;

            LoadAttributes();

            base.LoadFields();
        }

        private void LoadAttributes()
        {
            userLink.Item = item.GetLink((int)Contacto.Lib.LinkTypes.FolderUserLink);
            companyLink.Item = item.GetLink((int)Contacto.Lib.LinkTypes.FolderCompanyLink);
            personLink.Item = item.GetLink((int)Contacto.Lib.LinkTypes.FolderPersonLink);
            orderDate.Item = item.GetDate((int)Contacto.Lib.DateTypes.FolderOrderDate);
            dueDate.Item = item.GetDate((int)Contacto.Lib.DateTypes.FolderDueDate);
        }

        protected override void SaveFields()
        {
            Contacto.Lib.Folder f = (Contacto.Lib.Folder)item;

            f.Title = this.title.Text;
            f.DisplayName = this.displayName.Text;
            f.Number = this.number.Text;

            userLink.SaveFields();
            companyLink.SaveFields();
            personLink.SaveFields();
            orderDate.SaveFields();
            dueDate.SaveFields();

            linkList.RefreshList();
            dateList.RefreshList();
        }

        protected override void UpdateEnable()
        {
            base.UpdateEnable();

            bool enabled = !(item.Deleted || item.Closed || item.ReadOnly);

            title.ReadOnly = !enabled;
            companyLink.ReadOnly = !enabled;
            personLink.ReadOnly = !enabled;
            userLink.ReadOnly = !enabled;
            orderDate.ReadOnly = !enabled;
            dueDate.ReadOnly = !enabled;
        }

        #region Event handlers

        private void Changed(object sender, EventArgs e)
        {
            base.View_Changed(sender, e);
        }

        private void linkList_Changed(object sender, EventArgs e)
        {
            LoadAttributes();
            RefreshAttributeLists(sender);
        }

        private void dateList_Changed(object sender, EventArgs e)
        {
            LoadAttributes();
            RefreshAttributeLists(sender);
        }

        private void name_LeaveFocus(object sender, EventArgs e)
        {
            SaveFields();
            RefreshDisplayNameList();
        }

        #endregion

        private void personLink_BeforeEdit(object sender, EventArgs e)
        {
            personLink.FilterEntity = companyLink.Item.PointedEntity;
        }
    }
}
