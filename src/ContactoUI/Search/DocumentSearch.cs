using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace Contacto.UI
{
    public partial class DocumentSearch : SearchFormBase
    {
        public DocumentSearch()
        {
            InitializeComponent();
        }

        public override void Initialize()
        {
            base.Initialize();

            using (Contacto.Lib.Context context = ContextManager.CreateContext(this, false))
            {
                documentDateFrom.Value = context.DateLimitFrom;
                documentDateTo.Value = context.DateLimitTo;
            }

            categoryPanel.Initialize();
        }

        public override Contacto.Lib.SearchParameters GetSearchParameters()
        {
            Contacto.Lib.DocumentSearchParameters dsp = new Contacto.Lib.DocumentSearchParameters();

            dsp.Number = documentNumber.Text;
            dsp.Title = documentTitle.Text;
            dsp.Subject = documentSubject.Text;

            dsp.FromCompany = documentFromCompany.Text;
            dsp.FromPerson = documentFromPerson.Text;
            dsp.ToCompany = documentToCompany.Text;
            dsp.ToPerson = documentToPerson.Text;
            dsp.DateFrom = documentDateFrom.Value;
            dsp.DateTo = documentDateTo.Value;
            dsp.Query = documentQuery.Text;

            categoryPanel.GetCategories(out dsp.CategoryTypes, out dsp.CategoryValues);

            return dsp;
        }

        protected override void CreateAssociatedList()
        {
            base.list = new DocumentList();
            Program.Settings.SearchDocumentList.Apply(list.listView);
            ((DocumentList)list).ToolStripVisible = false;
            ((DocumentList)list).TreeVisible = false;
        }

        protected override void DestructAssociatedList()
        {
            Program.Settings.SearchDocumentList.Match(list.listView);
        }

        public override void ExecuteSearch()
        {
            Contacto.Lib.Context context = ContextManager.CreateContext(this, true);

            Contacto.Lib.DocumentFactory f = new Contacto.Lib.DocumentFactory(context);
            ((DocumentList)list).RefreshDocuments(f.FindDocuments((Contacto.Lib.DocumentSearchParameters)GetSearchParameters()), context);
        }
    }
}
