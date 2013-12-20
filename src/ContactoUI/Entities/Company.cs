using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace Contacto.UI
{
    public partial class Company : EntityForm
    {
        public Company(Main form)
            : base(form)
        {
            InitializeComponent();

            tab.Controls.Remove(tabBlobs);

            this.Controls.Remove(displayNameLabel);
            this.Controls.Remove(displayName);

            this.tableLayoutPanel2.Controls.Add(this.displayNameLabel, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.displayName, 1, 2);
            this.tableLayoutPanel2.SetColumnSpan(this.displayName, 3);
        }

        public override bool CreateEntity(Contacto.Lib.Entity parentEntity)
        {
            using (Contacto.Lib.Context context = ContextManager.CreateContext(this, true))
            {
                try
                {
                    item = new Contacto.Lib.Company(context);
                    item.NewEntity(parentEntity);

                    LoadFields();
                    return true;
                }
                catch (System.Exception ex)
                {
                    Contacto.Lib.LogEntry log = new Contacto.Lib.LogEntry(context, item, Contacto.Lib.LogOperations.CreateCompany);
                    Program.HandleError(context, Messages.ErrorCreatingCompany, log, ex);
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
                    item = new Contacto.Lib.Company(context);
                    item.Guid = guid;
                    item.Load();

                    Contacto.Lib.Company c = (Contacto.Lib.Company)item;

                    c.LoadDetails();

                    return base.LoadEntity(guid);
                }
                catch (System.Exception ex)
                {
                    Contacto.Lib.LogEntry log = new Contacto.Lib.LogEntry(context, item, Contacto.Lib.LogOperations.LoadCompany);
                    Program.HandleError(context, Messages.ErrorLoadingCompany, log, ex);
                }
            }
            return false;
        }

        protected override void LoadFields()
        {
            Contacto.Lib.Company c = (Contacto.Lib.Company)item;

            this.number.Text = c.Number;
            this.shortName.Text = c.ShortName;
            this.longName.Text = c.LongName;
            this.displayName.Text = c.DisplayName;

            LoadAttributes();

            base.LoadFields();
        }

        private void LoadAttributes()
        {
            classification.Item = item.GetCategory((int)Contacto.Lib.CategoryTypes.Classification);
            category.Item = item.GetCategory((int)Contacto.Lib.CategoryTypes.Primary);
            industry.Item = item.GetCategory((int)Contacto.Lib.CategoryTypes.PrimaryIndustry);

            address.Item = item.GetAddress((int)Contacto.Lib.AddressTypes.Primary);
            phone.Item = item.GetIdentifier((int)Contacto.Lib.IdentifierTypes.PrimaryPhone);
            email.Item = item.GetIdentifier((int)Contacto.Lib.IdentifierTypes.PrimaryEmail);
            webAddress.Item = item.GetIdentifier((int)Contacto.Lib.IdentifierTypes.WebAddress);
            fax.Item = item.GetIdentifier((int)Contacto.Lib.IdentifierTypes.PrimaryFax);
        }

        protected override void SaveFields()
        {
            Contacto.Lib.Company c = (Contacto.Lib.Company)item;

            c.ShortName = this.shortName.Text;
            c.LongName = this.longName.Text;
            c.DisplayName = this.displayName.Text;
            c.Number = this.number.Text;

            SaveAttributes();
        }

        private void SaveAttributes()
        {
            classification.SaveFields();
            category.SaveFields();
            industry.SaveFields();

            address.SaveFields();
            phone.SaveFields();
            email.SaveFields();
            webAddress.SaveFields();
            fax.SaveFields();

            attributeList.RefreshList();
            categoryList.RefreshList();
        }

        protected override void UpdateEnable()
        {
            base.UpdateEnable();

            bool ro = item.Deleted || item.Closed || item.ReadOnly;

            shortName.ReadOnly = ro;
            longName.ReadOnly = ro;
            classification.ReadOnly = ro;
            category.ReadOnly = ro;
            industry.ReadOnly = ro;
            phone.ReadOnly = ro;
            fax.ReadOnly = ro;
            address.ReadOnly = ro;
            email.ReadOnly = ro;
            webAddress.ReadOnly = ro;
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

        private void linkList_Changed(object sender, EventArgs e)
        {
            RefreshAttributeLists(sender);
        }

        private void name_LeaveFocus(object sender, EventArgs e)
        {
            SaveFields();
            RefreshDisplayNameList();
        }

        private new void Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = RequiredValidator(sender,
                new object[] { shortName, displayName });
        }

        #endregion
    }
}
