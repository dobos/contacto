using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace Contacto.UI
{
    public partial class CompanySearch : SearchFormBase
    {
        public CompanySearch()
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

            Contacto.Lib.CompanySearchParameters csp = new Contacto.Lib.CompanySearchParameters();

            
            csp.Name = name.Text;

            csp.Country = country.Text;
            csp.City = city.Text;
            csp.Phone = phone.Text;
            csp.Fax = fax.Text;
            csp.Email = email.Text;

            categoryPanel.GetCategories(out csp.CategoryTypes, out csp.CategoryValues);

            return csp;
        }

        protected override void CreateAssociatedList()
        {
            base.list = new CompanyList();
            Program.Settings.SearchCompanyList.Apply(list.listView);
            list.ToolStripVisible = false;
        }

        protected override void DestructAssociatedList()
        {
            Program.Settings.SearchCompanyList.Match(list.listView);
        }

        public override void ExecuteSearch()
        {
            Contacto.Lib.Context context = ContextManager.CreateContext(this, true);

            Contacto.Lib.CompanyFactory f = new Contacto.Lib.CompanyFactory(context);
            ((CompanyList)list).RefreshList(f.FindCompanies((Contacto.Lib.CompanySearchParameters)GetSearchParameters()), context);
        }
    }
}
