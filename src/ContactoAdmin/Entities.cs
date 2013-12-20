using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace Contacto.Admin
{
    public partial class Entities : UserControl
    {
        public Entities()
        {
            InitializeComponent();
        }

        public void RefreshList()
        {
            listView.Items.Clear();

            using (Contacto.Lib.Context context = ContextManager.CreateContext(true))
            {
                Contacto.Lib.EntityFactory f = new Contacto.Lib.EntityFactory(context);

                foreach (Contacto.Lib.Entity e in f.FindDeletedEntities())
                {
                    ListViewItem ni = new ListViewItem();
                    ni.Text = e.DisplayName;
                    ni.SubItems.Add(context.SchemaManager.GetEntityDescription(e.EntityType).Description);
                    ni.SubItems.Add(e.DateDeleted.ToShortDateString());

                    ni.Tag = e;

                    listView.Items.Add(ni);
                }
            }
        }

        private void RecoverEntity(Contacto.Lib.Entity e)
        {
            if (MessageBox.Show("Valóban visszaállítja a következõt: " + e.DisplayName + "?", Application.ProductName, MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.OK)
            {
                using (Contacto.Lib.Context context = ContextManager.CreateContext(true))
                {
                    e.Context = context;
                    e.Recover();
                }

                RefreshList();
            }
        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

            if (e.ClickedItem == toolRecover)
            {
                foreach (ListViewItem li in listView.SelectedItems)
                {
                    RecoverEntity((Contacto.Lib.Entity)li.Tag);
                }
            }
        }
    }
}
