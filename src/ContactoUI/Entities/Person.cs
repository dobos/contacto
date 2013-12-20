using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace Contacto.UI
{
    public partial class Person : EntityForm
    {
        public Person(Main form)
            : base(form)
        {
            InitializeComponent();

            tab.Controls.Remove(tabBlobs);
            tab.Controls.Remove(tabPersons);

            preposition.Items.AddRange(Contacto.Lib.Person.GetPrepositions());
            postposition.Items.AddRange(Contacto.Lib.Person.GetPostpositions());

            this.Controls.Remove(displayNameLabel);
            this.Controls.Remove(displayName);

            this.tableLayoutPanel1.Controls.Add(this.displayNameLabel, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.displayName, 1, 3);
            this.tableLayoutPanel1.SetColumnSpan(this.displayName, 3);
        }

        public override bool CreateEntity(Contacto.Lib.Entity parentEntity)
        {
            using (Contacto.Lib.Context context = ContextManager.CreateContext(this, true))
            {
                try
                {
                    item = new Contacto.Lib.Person(context);
                    item.NewEntity(parentEntity);

                    LoadFields();
                    return true;
                }
                catch (System.Exception ex)
                {
                    Contacto.Lib.LogEntry log = new Contacto.Lib.LogEntry(context, item, Contacto.Lib.LogOperations.CreatePerson);
                    Program.HandleError(context, Messages.ErrorCreatingPerson, log, ex);
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
                    item = new Contacto.Lib.Person(context);
                    item.Guid = guid;
                    item.Load();

                    Contacto.Lib.Person p = (Contacto.Lib.Person)item;
                    p.LoadDetails();

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
            Contacto.Lib.Person p = (Contacto.Lib.Person)item;

            this.preposition.Text = p.Preposition;
            this.firstName.Text = p.FirstName;
            this.middleName.Text = p.MiddleName;
            this.lastName.Text = p.LastName;
            this.postposition.Text = p.Postposition;
            this.genderMale.Checked = (p.Gender == Contacto.Lib.Genders.Male);
            this.genderFemale.Checked = (p.Gender == Contacto.Lib.Genders.Female);

            this.displayName.Text = p.DisplayName;
            this.number.Text = p.Number;

            LoadAttributes();

            base.LoadFields();
        }

        private void LoadAttributes()
        {
            status.Item = item.GetCategory((int)Contacto.Lib.CategoryTypes.Primary);

            phone.Item = item.GetIdentifier((int)Contacto.Lib.IdentifierTypes.PrimaryPhone);
            mobile.Item = item.GetIdentifier((int)Contacto.Lib.IdentifierTypes.PrimaryMobile);
            email.Item = item.GetIdentifier((int)Contacto.Lib.IdentifierTypes.PrimaryEmail);
            companyLink.Item = item.GetLink((int)Contacto.Lib.LinkTypes.PersonCompanyLink);
        }

        protected override void SaveFields()
        {
            Contacto.Lib.Person p = (Contacto.Lib.Person)item;

            p.Preposition = this.preposition.Text;
            p.FirstName = this.firstName.Text;
            p.MiddleName = this.middleName.Text;
            p.LastName = this.lastName.Text;
            p.Postposition = this.postposition.Text;
            //p.Gender = (this.genderMale.Checked) ? Contacto.Lib.Genders.Male : Contacto.Lib.Genders.Female;
            p.SetGender();
            p.DisplayName = this.displayName.Text;
            p.Number = this.number.Text;

            phone.SaveFields();
            mobile.SaveFields();
            email.SaveFields();
            status.SaveFields();
            //companyLink.SaveFields();

            attributeList.RefreshList();
            //linkList.RefreshList();
        }

        protected override void RefreshDisplayNameList()
        {
            displayName.Items.Clear();
            displayName.Items.AddRange(item.GetDisplayTextAlternates());
            if (displayName.Text == string.Empty)
                displayName.Text = (string)displayName.Items[0];
        }

        protected override void UpdateEnable()
        {
            base.UpdateEnable();

            bool ro = item.Deleted || item.Closed || item.ReadOnly;

            preposition.Enabled = !ro;
            firstName.ReadOnly = ro;
            middleName.ReadOnly = ro;
            lastName.ReadOnly = ro;
            postposition.Enabled = !ro;
            companyLink.ReadOnly = ro;
            status.ReadOnly = ro;
            phone.ReadOnly = ro;
            mobile.ReadOnly = ro;
            email.ReadOnly = ro;
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
            LoadAttributes();
            RefreshAttributeLists(sender);
        }

        private void tab_Selected(object sender, TabControlEventArgs e)
        {
            RefreshAttributeLists(tab.SelectedTab.Controls[0]);
        }

        private void name_LeaveFocus(object sender, EventArgs e)
        {
            SaveFields();
            RefreshDisplayNameList();
        }

        private new void Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = RequiredValidator(sender,
                new object[] { firstName, lastName, displayName });
        }

        #endregion
    }
}
