using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace Contacto.UI
{
    public partial class Document : EntityForm
    {
        public Document(Main form)
            : base(form)
        {
            InitializeComponent();

            tab.Controls.Remove(tabDocuments);
            tab.Controls.Remove(tabPersons);
            tab.Controls.Remove(tabAttributes);

            this.Controls.Remove(displayNameLabel);
            this.Controls.Remove(displayName);

            this.tableLayoutPanel1.Controls.Add(this.displayNameLabel, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.displayName, 1, 4);
            this.tableLayoutPanel1.SetColumnSpan(this.displayName, 2);
        }

        public override bool CreateEntity(Contacto.Lib.Entity parentEntity)
        {
            return CreateEntity(parentEntity, null, Contacto.Lib.DocumentDirections.Unknown);
        }

        public bool CreateEntity(Contacto.Lib.Entity parentEntity, Contacto.Lib.Folder folder, Contacto.Lib.DocumentDirections direction)
        {
            using (Contacto.Lib.Context context = ContextManager.CreateContext(this, true))
            {
                try
                {
                    item = new Contacto.Lib.Document(context);
                    ((Contacto.Lib.Document)item).NewEntity(parentEntity, folder, direction);

                    LoadFields();
                    return true;
                }
                catch (System.Exception ex)
                {
                    Contacto.Lib.LogEntry log = new Contacto.Lib.LogEntry(context, item, Contacto.Lib.LogOperations.CreateDocument);
                    Program.HandleError(context, Messages.ErrorCreatingDocument, log, ex);
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
                    item = new Contacto.Lib.Document(context);
                    item.Guid = guid;
                    item.Load();

                    Contacto.Lib.Document d = (Contacto.Lib.Document)item;

                    d.LoadDetails();

                    return base.LoadEntity(guid);
                }
                catch (System.Exception ex)
                {
                    Contacto.Lib.LogEntry log = new Contacto.Lib.LogEntry(context, item, Contacto.Lib.LogOperations.LoadDocument);
                    Program.HandleError(context, Messages.ErrorLoadingDocument, log, ex);
                }
            }

            return false;
        }

        protected override void LoadFields()
        {
            Contacto.Lib.Document d = (Contacto.Lib.Document)item;

            this.title.Text = d.Title;
            this.subject.Text = d.Subject;
            this.foreignNumber.Text = d.ForeignNumber;

            this.number.Text = d.Number;
            this.displayName.Text = d.DisplayName;

            LoadAttributes();

            base.LoadFields();
        }

        private void LoadAttributes()
        {
            date.Item = item.GetDate((int)Contacto.Lib.DateTypes.Primary);

            category.Item = item.GetCategory((int)Contacto.Lib.CategoryTypes.Primary);
            direction.Item = item.GetCategory((int)Contacto.Lib.CategoryTypes.DocumentDirection);
            brand.Item = item.GetCategory((int)Contacto.Lib.CategoryTypes.Brand);

            linkFolder.Item = item.GetLink((int)Contacto.Lib.LinkTypes.DocumentFolderLink);
            linkFromCompany.Item = item.GetLink((int)Contacto.Lib.LinkTypes.DocumentFromCompanyLink);
            linkFromPerson.Item = item.GetLink((int)Contacto.Lib.LinkTypes.DocumentFromPersonLink);
            linkToCompany.Item = item.GetLink((int)Contacto.Lib.LinkTypes.DocumentToCompanyLink);
            linkToPerson.Item = item.GetLink((int)Contacto.Lib.LinkTypes.DocumentToPersonLink);
        }

        protected override void SaveFields()
        {
            Contacto.Lib.Document d = (Contacto.Lib.Document)item;

            d.Title = this.title.Text;
            d.Subject = this.subject.Text;
            d.ForeignNumber = this.foreignNumber.Text;
            d.DisplayName = this.title.Text;
            d.Number = this.number.Text;

            date.SaveFields();

            category.SaveFields();
            direction.SaveFields();
            brand.SaveFields();

            linkFolder.SaveFields();
            linkFromCompany.SaveFields();
            linkFromPerson.SaveFields();
            linkToCompany.SaveFields();
            linkToPerson.SaveFields();

            linkList.RefreshList();
            categoryList.RefreshList();
            dateList.RefreshList();
        }

        protected override void UpdateEnable()
        {
            base.UpdateEnable();

            bool ro = item.Deleted || item.Closed || item.ReadOnly;

            number.ReadOnly = ro;
            date.ReadOnly = ro;
            category.ReadOnly = ro;
            direction.ReadOnly = ro;
            title.ReadOnly = ro;
            linkFolder.ReadOnly = ro;
            subject.ReadOnly = ro;
            brand.ReadOnly = ro;
            linkFromCompany.ReadOnly = ro;
            linkFromPerson.ReadOnly = ro;
            linkToCompany.ReadOnly = ro;
            linkToPerson.ReadOnly = ro;
        }

        #region Event handlers

        private void Changed(object sender, EventArgs e)
        {
            base.View_Changed(sender, e);
        }

        private void attributeList_Changed(object sender, EventArgs e)
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

        private void linkFromPerson_BeforeEdit(object sender, EventArgs e)
        {
            linkFromPerson.FilterEntity = linkFromCompany.Item.PointedEntity;
        }

        private void linkToPerson_BeforeEdit(object sender, EventArgs e)
        {
            linkToPerson.FilterEntity = linkToCompany.Item.PointedEntity;
        }
    }
}
