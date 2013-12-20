using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace Contacto.UI
{
    public partial class EntitySearch : SearchFormBase
    {
        public EntitySearch()
        {
            InitializeComponent();
        }

        public override Contacto.Lib.SearchParameters GetSearchParameters()
        {
            Contacto.Lib.SimpleSearchParameters ssp = new Contacto.Lib.SimpleSearchParameters();

            ssp.IncludeCompanies = includeCompanies.Checked;
            ssp.IncludePersons = includePersons.Checked;
            ssp.IncludeFolders = includeFolders.Checked;
            ssp.IncludeDocuments = includeDocuments.Checked;
            ssp.IncludeReminders = includeReminders.Checked;
            ssp.Query = query.Text;

            return ssp;
        }

        protected override void CreateAssociatedList()
        {
            base.list = new EntityList();
            Program.Settings.SearchEntityList.Apply(list.listView);
            list.ToolStripVisible = false;
        }

        protected override void DestructAssociatedList()
        {
            Program.Settings.SearchEntityList.Match(list.listView);
        }

        public override void ExecuteSearch()
        {
            Contacto.Lib.Context context = ContextManager.CreateContext(this, true);

            Contacto.Lib.EntityFactory f = new Contacto.Lib.EntityFactory(context);
            ((EntityList)list).RefreshList(f.FindEntities((Contacto.Lib.SimpleSearchParameters)GetSearchParameters()), context);
        }
    }
}
