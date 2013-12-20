using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace Contacto.UI
{
    public partial class Browse : ViewForm, ISearchView
    {
        private List<ListView> lists = new List<ListView>();
        
        private TreeNode nodeCompanies;
        private TreeNode nodePersons;
        private TreeNode nodeFolders;
        private TreeNode nodeDocuments;
        private TreeNode nodeReminders;

        public Browse(Main form)
            : base(form)
        {
            InitializeComponent();
            InitializeTreeView();
        }

        private void InitializeTreeView()
        {
            nodeCompanies = new TreeNode("Cégek");
            nodePersons = new TreeNode("Névjegyek");
            nodeFolders = new TreeNode("Mappák");
            nodeDocuments = new TreeNode("Dokumentumok");
            nodeReminders = new TreeNode("Emlékeztetõk");

            AddCategoryNodes(nodeCompanies, Contacto.Lib.EntityTypes.Company);
            AddCategoryNodes(nodePersons, Contacto.Lib.EntityTypes.Person);
            AddCategoryNodes(nodeFolders, Contacto.Lib.EntityTypes.Folder);
            AddCategoryNodes(nodeDocuments, Contacto.Lib.EntityTypes.Document);
            AddCategoryNodes(nodeReminders, Contacto.Lib.EntityTypes.Reminder);

            treeView.Nodes.AddRange(new TreeNode[] {
                nodeCompanies, nodePersons, nodeFolders, nodeDocuments, nodeReminders
            });
        }

        private void AddCategoryNodes(TreeNode node, int entityType)
        {
            using (Contacto.Lib.Context context = ContextManager.CreateContext(this, false))
            {
                //AddTypeDescriptions(node, entityType);

                foreach (Contacto.Lib.TypeDescription t in context.SchemaManager.GetTypeDescriptions(entityType + Contacto.Lib.EntityTypes.Category))
                {
                    TreeNode nn = new TreeNode(t.Description);
                    nn.Tag = t;
                    node.Nodes.Add(nn);

                    AddCategoryDescriptions(nn, t);
                }
            }
        }

        /*
        private void AddTypeDescriptions(TreeNode node, int entityType)
        {
            using (Contacto.Lib.Context context = ContextManager.CreateContext(false))
            {
                foreach (Contacto.Lib.TypeDescription t in context.SchemaManager.GetTypeDescriptions(entityType))
                {
                    TreeNode nn = new TreeNode(t.Description);
                    nn.Tag = t;
                    node.Nodes.Add(nn);

                    AddCategoryDescriptions(nn, t);
                }
            }
        }*/

        private void AddCategoryDescriptions(TreeNode node, Contacto.Lib.TypeDescription t)
        {
            using (Contacto.Lib.Context context = ContextManager.CreateContext(this, false))
            {
                node.Nodes.Clear();
                foreach (Contacto.Lib.CategoryDescription c in context.SchemaManager.GetCategoryDescriptions(t.EntityType - Contacto.Lib.EntityTypes.Category, t.Id))
                {
                    TreeNode nn = new TreeNode();
                    nn.Text = c.Description;
                    nn.Tag = c;

                    node.Nodes.Add(nn);
                }
            }
        }

        private ListView CreateListView()
        {
            ListView lv = new ListView();
            lv.Top = treeView.Top;
            lv.Height = treeView.Height;
            lv.Left = panel.Controls[panel.Controls.Count - 1].Right + 4;
            lv.Width = 200;
            lv.Height = panel.ClientRectangle.Height;
            lv.View = View.List;

            lv.ItemSelectionChanged += new ListViewItemSelectionChangedEventHandler(lv_ItemSelectionChanged);
            lv.DoubleClick += new EventHandler(lv_DoubleClick);

            lists.Add(lv);
            panel.Controls.Add(lv);
            //UpdatePositions();
            panel.ScrollControlIntoView(lv);

            return lv;
        }

        private void RefreshListView(ListView lv, Contacto.Lib.CategoryDescription category)
        {
            using (Contacto.Lib.Context context = ContextManager.CreateContext(this, true))
            {
                Contacto.Lib.EntityFactory f = new Contacto.Lib.EntityFactory(context);

                foreach (Contacto.Lib.Entity e in f.FindEntities(category))
                {
                    ListViewItem ni = new ListViewItem();

                    ni.Text = e.DisplayName;
                    ni.Tag = e;

                    lv.Items.Add(ni);
                }
            }
        }

        private void RefreshListView(ListView lv, Contacto.Lib.Entity entity)
        {
            using (Contacto.Lib.Context context = ContextManager.CreateContext(this, true))
            {
                Contacto.Lib.EntityFactory f = new Contacto.Lib.EntityFactory(context);

                foreach (Contacto.Lib.Entity e in f.FindEntities(entity))
                {
                    ListViewItem ni = new ListViewItem();

                    ni.Text = e.DisplayName;
                    ni.Tag = e;

                    lv.Items.Add(ni);
                }
            }
        }

        private void CloseLists()
        {
            foreach (ListView lv in lists)
            {
                this.Controls.Remove(lv);
                lv.Dispose();
            }

            lists.Clear();
        }

        private void CloseListsBehind(ListView lv)
        {
            int i = lists.IndexOf(lv) + 1;

            while (i < lists.Count)
            {
                this.Controls.Remove(lists[i]);
                lists[i].Dispose();
                lists.RemoveAt(i);
            }
        }

        private void treeView_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Node != null && e.Node.Tag != null && e.Node.Tag.GetType() == typeof(Contacto.Lib.CategoryDescription))
            {
                Contacto.Lib.CategoryDescription c = (Contacto.Lib.CategoryDescription)e.Node.Tag;

                CloseLists();

                ListView lv = CreateListView();
                RefreshListView(lv, c);
            }
        }

        private void lv_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            Contacto.Lib.Entity entity = e.Item.Tag as Contacto.Lib.Entity;

            if (entity != null)
            {
                CloseListsBehind((ListView) sender);

                ListView lv = CreateListView();
                RefreshListView(lv, entity);
            }
        }

        void lv_DoubleClick(object sender, EventArgs e)
        {
            ListView lv = (ListView)sender;

            if (lv.SelectedItems.Count == 1 && lv.SelectedItems[0].Tag != null)
            {
                ((Main)FindForm()).LoadEntity((Contacto.Lib.Entity)lv.SelectedItems[0].Tag, true);
            }
        }

        #region ISearchView Members

        public Contacto.Lib.Entity GetPrevious(Contacto.Lib.Entity selected)
        {
            return null;
        }

        public Contacto.Lib.Entity GetNext(Contacto.Lib.Entity selected)
        {
            return null;
        }

        #endregion
    }
}
