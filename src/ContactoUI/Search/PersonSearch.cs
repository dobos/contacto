using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace Contacto.UI
{
    public partial class PersonSearch : SearchFormBase
    {
        public PersonSearch()
        {
            InitializeComponent();
        }

        public override void Initialize()
        {
            base.Initialize();

            categoryPanel.Initialize();
        }

        public override Contacto.Lib.SearchParameters GetSearchParameters()
        {
            Contacto.Lib.PersonSearchParameters psp = new Contacto.Lib.PersonSearchParameters();

            psp.FirstName = firstName.Text;
            psp.LastName = lastName.Text;
            psp.Phone = personPhone.Text;
            psp.Mobile = personMobile.Text;
            psp.Email = personEmail.Text;

            categoryPanel.GetCategories(out psp.CategoryTypes, out psp.CategoryValues);

            return psp;
        }

        protected override void CreateAssociatedList()
        {
            base.list = new PersonList();
            Program.Settings.SearchPersonList.Apply(list.listView);
            list.ToolStripVisible = false;
        }

        protected override void DestructAssociatedList()
        {
            Program.Settings.SearchPersonList.Match(list.listView);
        }

        public override void ExecuteSearch()
        {
            Contacto.Lib.Context context = ContextManager.CreateContext(this, true);

            Contacto.Lib.PersonFactory f = new Contacto.Lib.PersonFactory(context);
            ((PersonList)list).RefreshList(f.FindPersons((Contacto.Lib.PersonSearchParameters)GetSearchParameters()), context);
        }

    }
}
