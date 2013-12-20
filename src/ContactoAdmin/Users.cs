using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace Contacto.Admin
{
    public partial class Users : UserControl
    {
        public Users()
        {
            InitializeComponent();
        }

        public void RefreshList()
        {
            listView.Items.Clear();

            using (Contacto.Lib.Context context = ContextManager.CreateContext(false))
            {

                IEnumerable<Contacto.Lib.User> users = context.SchemaManager.Users;

                foreach (Contacto.Lib.User u in users)
                {
                    ListViewItem ni = new ListViewItem();
                    ni.Text = u.GetFormattedName();
                    ni.SubItems.Add(u.Username);

                    ni.Tag = u;

                    listView.Items.Add(ni);
                }
            }
        }

        
        private void CreateUser()
        {
            using (User f = new User())
            {
                f.Modify = false;
                if (f.ShowDialog() == DialogResult.OK)
                {
                    Contacto.Lib.User u = new Contacto.Lib.User();
                    f.SaveFields(u);

                    using (Contacto.Lib.Context context = ContextManager.CreateContext(true))
                    {
                        u.Context = context;
                        u.CreateLogin();

                        Program.SchemaManager.Context = context;
                        Program.SchemaManager.LoadSchema();
                    }
                    RefreshList();
                }
            }
        }

        /*
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
         * */

        private void DeleteUser(Contacto.Lib.User u)
        {
            if (MessageBox.Show("Valóban törli a következõt: " + u.DisplayName + "?", Application.ProductName, MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.OK)
            {
                using (Contacto.Lib.Context context = ContextManager.CreateContext(true))
                {
                    u.Context = context;
                    u.DeleteLogin();

                    Program.SchemaManager.Context = context;
                    Program.SchemaManager.LoadSchema();
                }

                RefreshList();
            }
        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            
            if (e.ClickedItem == toolNew)
            {
                CreateUser();
            }/*
            else if (!entities && e.ClickedItem == toolModify)
            {
                ModifyTypeDescription((Contacto.Lib.TypeDescription)listView.SelectedItems[0].Tag);
            }*/
            else if (e.ClickedItem == toolDelete)
            {
                DeleteUser((Contacto.Lib.User)listView.SelectedItems[0].Tag);
            }
        }
    }
}
