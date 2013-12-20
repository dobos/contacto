using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Contacto.UI
{
    public partial class LinkForm : Form
    {
        private Contacto.Lib.Entity filterEntity;

        public Contacto.Lib.Entity FilterEntity
        {
            set
            {
                filterEntity = value;

                this.filterEntityEnabled.Checked = (filterEntity != null);
                this.filterEntityEnabled.Enabled = (filterEntity != null);
            }
        }

        public LinkForm()
        {
            InitializeComponent();
        }

        private void LinkForm_Shown(object sender, EventArgs e)
        {
            searchLabel.Top = Link.Bottom + 11;
            search.Top = Link.Bottom + 8;
            searchButton.Top = Link.Bottom + 8;

            listView.Top = search.Bottom + 8;

            ok.Top = listView.Bottom + 12;
            cancel.Top = listView.Bottom + 12;
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            listView.Items.Clear();

            using (Contacto.Lib.Context context = ContextManager.CreateContext(this.Owner, true))
            {
                Contacto.Lib.EntityFactory f = new Contacto.Lib.EntityFactory(context);

                IEnumerable<Contacto.Lib.Entity> res;

                if (filterEntity == null || !filterEntityEnabled.Checked)
                    if (Link.Item.TypeDescription.LinkedEntityType != 0)
                    {
                        res = f.FindEntities(search.Text, Link.Item.TypeDescription.LinkedEntityType);
                    }
                    else
                    {
                        res = f.FindEntities(search.Text);
                    }
                else
                {
                    if (Link.Item.TypeDescription.LinkedEntityType != 0)
                    {
                        res = f.FindEntities(filterEntity, search.Text, Link.Item.TypeDescription.LinkedEntityType);
                    }
                    else
                    {
                        res = f.FindEntities(filterEntity, search.Text);
                    }
                }

                foreach (Contacto.Lib.Entity entity in res)
                {
                    ListViewItem li = new ListViewItem();

                    li.Tag = entity;
                    li.Text = entity.DisplayName;
                    if (entity is Contacto.Lib.Person)
                    {
                        entity.LoadLinks();
                        Contacto.Lib.Link link = ((Contacto.Lib.Person)entity).GetLink((int)Contacto.Lib.LinkTypes.PersonCompanyLink);
                        if (link != null && link.PointedEntity != null)
                        {
                            li.SubItems.Add(link.PointedEntity.DisplayName);
                        }
                    }
                    //li.SubItems.Add(context.SchemaManager.GetEntityDescription(entity.EntityType).Description);

                    listView.Items.Add(li);
                }
                listView.Sort();
            }
        }

        private void listView_Click(object sender, EventArgs e)
        {
            if (listView.SelectedItems.Count > 0)
            {
                Link.Item.PointedEntity = (Contacto.Lib.Entity)listView.SelectedItems[0].Tag;
                Link.LoadFields();
            }
        }

        private void search_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                searchButton_Click(sender, e);
            }
        }

        private void search_Enter(object sender, EventArgs e)
        {
            AcceptButton = null;
        }

        private void search_Leave(object sender, EventArgs e)
        {
            AcceptButton = ok;
        }
    }
}