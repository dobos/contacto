using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Contacto.Admin
{
    public partial class User : Form
    {
        public bool Modify;

        public User()
        {
            InitializeComponent();
        }

        public void SaveFields(Contacto.Lib.User u)
        {
            u.Username = username.Text;
            u.Guid = ((Contacto.Lib.Entity)displayName.Tag).Guid;
            u.Password = password.Text;
            u.Windows = typeWindows.Checked;
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            listView.Items.Clear();

            using (Contacto.Lib.Context context = ContextManager.CreateContext(true))
            {
                Contacto.Lib.EntityFactory f = new Contacto.Lib.EntityFactory(context);

                List<Contacto.Lib.Entity> res = new List<Contacto.Lib.Entity>(f.FindEntities(search.Text, 20000));

                foreach (Contacto.Lib.Entity entity in res)
                {
                    ListViewItem li = new ListViewItem();

                    li.Tag = entity;
                    li.Text = entity.DisplayName;
                    //li.SubItems.Add(context.SchemaManager.GetEntityDescription(entity.EntityType).Description);

                    listView.Items.Add(li);
                }
            }
        }

        private void listView_Click(object sender, EventArgs e)
        {
            if (listView.SelectedItems.Count > 0)
            {

                displayName.Text = ((Contacto.Lib.Entity)listView.SelectedItems[0].Tag).DisplayName;
                displayName.Tag = (Contacto.Lib.Entity)listView.SelectedItems[0].Tag;
            }
        }
    }
}