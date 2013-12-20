using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace Contacto.Admin
{
    public partial class TypeList : UserControl
    {
        private bool entities = false;

        public bool Entities
        {
            get { return entities; }
            set { entities = value; }
        }


        public TypeList()
        {
            InitializeComponent();
        }


        public void RefreshList()
        {
            listView.Items.Clear();

            using (Contacto.Lib.Context context = ContextManager.CreateContext(false))
            {

                IEnumerable<Contacto.Lib.TypeDescription> items;

                if (entities)
                {
                    items = context.SchemaManager.GetAllEntityDescriptions();
                }
                else
                {
                    items = context.SchemaManager.GetAllTypeDescriptions();
                }

                foreach (Contacto.Lib.TypeDescription t in items)
                {
                    ListViewItem ni = new ListViewItem();
                    ni.Text = t.Id.ToString();
                    if (entities)
                        ni.SubItems.Add(t.EntityType.ToString());
                    else
                        ni.SubItems.Add("(" + t.EntityType.ToString() + ") " + context.SchemaManager.GetEntityDescription(t.EntityType));
                    ni.SubItems.Add(t.Description);
                    if (t.LinkedEntityType == 0)
                        ni.SubItems.Add("n/a");
                    else if (entities)
                        ni.SubItems.Add(t.LinkedEntityType.ToString());
                    else
                        ni.SubItems.Add("(" + t.EntityType.ToString() + ") " + context.SchemaManager.GetEntityDescription(t.LinkedEntityType));
                    ni.SubItems.Add(t.System.ToString());
                    ni.SubItems.Add(t.Hidden.ToString());
                    ni.SubItems.Add(t.Multiple.ToString());
                    ni.SubItems.Add(t.Required.ToString());
                    ni.SubItems.Add(t.Freetext.ToString());

                    ni.Tag = t;

                    listView.Items.Add(ni);
                }
            }
        }

        private void CreateTypeDescription()
        {
            using (TypeDescription f = new TypeDescription())
            {
                f.RefreshEntityLists();
                f.Modify = false;
                if (f.ShowDialog() == DialogResult.OK)
                {
                    Contacto.Lib.TypeDescription t = new Contacto.Lib.TypeDescription();
                    f.SaveFields(t);

                    using (Contacto.Lib.Context context = ContextManager.CreateContext(true))
                    {
                        t.Context = context;
                        t.Save();

                        Program.SchemaManager.Context = context;
                        Program.SchemaManager.LoadSchema();
                    }
                    RefreshList();
                }
            }
        }

        private void ModifyTypeDescription(Contacto.Lib.TypeDescription t)
        {
            using (TypeDescription f = new TypeDescription())
            {
                f.RefreshEntityLists();
                f.Modify = true;
                f.LoadFields(t);
                if (f.ShowDialog() == DialogResult.OK)
                {
                    f.SaveFields(t);

                    using (Contacto.Lib.Context context = ContextManager.CreateContext(true))
                    {
                        t.Context = context;
                        t.Save();

                        Program.SchemaManager.Context = context;
                        Program.SchemaManager.LoadSchema();
                    }

                    RefreshList();
                }
            }
        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            if (!entities && e.ClickedItem == toolNew)
            {
                CreateTypeDescription();
            }
            else if (!entities && e.ClickedItem == toolModify)
            {
                ModifyTypeDescription((Contacto.Lib.TypeDescription)listView.SelectedItems[0].Tag);
            }
        }


    }
}
