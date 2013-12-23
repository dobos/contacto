using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace Contacto.Admin
{
    public partial class Categories : UserControl
    {
        public Categories()
        {
            InitializeComponent();
        }

        public void RefreshList()
        {
            listView.Items.Clear();

            using (Contacto.Lib.Context context = ContextManager.CreateContext(false))
            {

                IEnumerable<Contacto.Lib.TypeDescription> items;
                items = context.SchemaManager.GetAllTypeDescriptions();

                foreach (Contacto.Lib.TypeDescription t in items)
                {
                    if (t.EntityType - (t.EntityType / 10000) * 10000 == 3)
                    {
                        ListViewItem ni = new ListViewItem();
                        ni.Text = t.Id.ToString();
                        ni.SubItems.Add("(" + t.EntityType.ToString() + ") " + context.SchemaManager.GetEntityDescription(t.EntityType));
                        ni.SubItems.Add(t.Description);

                        ni.Tag = t;

                        listView.Items.Add(ni);
                    }
                }
            }
        }

        private void RefreshOptionsList(Contacto.Lib.TypeDescription t)
        {
            optionsList.Items.Clear();

            using (Contacto.Lib.Context context = ContextManager.CreateContext(false))
            {
                foreach (Contacto.Lib.CategoryDescription d in context.SchemaManager.CategoryDescriptions[t.EntityType - 3][t.Id].Values)
                {
                    ListViewItem ni = new ListViewItem();
                    ni.Text = d.Id.ToString();
                    ni.SubItems.Add(d.Description);

                    ni.Tag = d;

                    ni.BackColor = d.BackColor;
                    ni.ForeColor = d.ForeColor;

                    optionsList.Items.Add(ni);
                }
            }
        }

        private void CreateCategoryDescription()
        {
            Contacto.Lib.TypeDescription t = (Contacto.Lib.TypeDescription)listView.SelectedItems[0].Tag;

            using (CategoryDescription f = new CategoryDescription())
            {
                f.Modify = false;
                if (f.ShowDialog() == DialogResult.OK)
                {
                    Contacto.Lib.CategoryDescription c = new Contacto.Lib.CategoryDescription();
                    f.SaveFields(c);

                    c.EntityType = t.EntityType - 3;    //****
                    c.Type = t.Id;

                    using (Contacto.Lib.Context context = ContextManager.CreateContext(true))
                    {
                        c.Context = context;
                        c.Save();

                        Program.SchemaManager.Context = context;
                        Program.SchemaManager.LoadSchema();
                    }
                    RefreshOptionsList(t);
                }
            }
        }

        private void ModifyCategoryDescription(Contacto.Lib.CategoryDescription c)
        {
            using (CategoryDescription f = new CategoryDescription())
            {
                f.Modify = true;
                f.LoadFields(c);
                if (f.ShowDialog() == DialogResult.OK)
                {
                    f.SaveFields(c);

                    using (Contacto.Lib.Context context = ContextManager.CreateContext(true))
                    {
                        c.Context = context;
                        c.Modify(f.withUpdate.Checked);

                        Program.SchemaManager.Context = context;
                        Program.SchemaManager.LoadSchema();
                    }

                    RefreshOptionsList((Contacto.Lib.TypeDescription)listView.SelectedItems[0].Tag);
                }
            }
        }

        private void listView_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView.SelectedItems.Count == 1)
            {
                RefreshOptionsList((Contacto.Lib.TypeDescription)listView.SelectedItems[0].Tag);
            }
        }

        private void toolStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            if (e.ClickedItem == toolNew)
            {
                CreateCategoryDescription();
            }
            else if (e.ClickedItem == toolModify)
            {
                ModifyCategoryDescription((Contacto.Lib.CategoryDescription)optionsList.SelectedItems[0].Tag);
            }
        }

        private void optionsList_DoubleClick(object sender, EventArgs e)
        {
            ModifyCategoryDescription((Contacto.Lib.CategoryDescription)optionsList.SelectedItems[0].Tag);
        }
    }
}
