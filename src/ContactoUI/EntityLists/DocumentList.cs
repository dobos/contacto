using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace Contacto.UI
{
    public partial class DocumentList : EntityListBase
    {
        private bool readOnly = false;
        private Contacto.Lib.Entity parentEntity = null;

        private TreeNode nodeAll;
        private TreeNode nodeTypes;
        private TreeNode nodeCategories;
        private TreeNode nodeCompanies;
        private TreeNode nodeFolders;

        public Contacto.Lib.Entity ParentEntity
        {
            get
            {
                return parentEntity;
            }
            set
            {
                if (parentEntity != value)
                {
                    parentEntity = value;
                    RefreshList();
                }
            }
        }

        public bool ReadOnly
        {
            get { return readOnly; }
            set
            {
                readOnly = value;

                toolNew.Enabled = !value;
                toolDelete.Enabled = !value;
                menuNew.Enabled = !value;
                menuDelete.Enabled = !value;
            }
        }

        public override bool ToolStripVisible
        {
            get { return toolStrip.Visible; }
            set { toolStrip.Visible = value; }
        }

        public bool TreeVisible
        {
            get { return treeView.Visible; }
            set
            {
                if (value != treeView.Visible)
                {
                    if (value)
                    {
                        SuspendLayout();
                        treeView.Visible = true;
                        splitContainer1.Visible = true;
                        this.Controls.Remove(listView);
                        splitContainer1.Panel2.Controls.Add(listView);
                        ResumeLayout();
                    }
                    else
                    {
                        SuspendLayout();
                        treeView.Visible = false;
                        splitContainer1.Visible = false;
                        splitContainer1.Panel2.Controls.Remove(listView);
                        this.Controls.Add(listView);
                        ResumeLayout();
                    }
                }
            }
        }

        public DocumentList()
        {
            InitializeComponent();

            listView.AddEntityColumns();
            listView.SaveColumns();
            listView.itemCreator = ItemCreator;
        }

        public void RefreshList()
        {
            RefreshTree();
        }

        private void RefreshTree()
        {
            treeView.Nodes.Clear();

            //*** strings to resource
            nodeAll = new TreeNode("Összes dokumentum");

            nodeTypes = new TreeNode("Típusonként");
            nodeTypes.ForeColor = SystemColors.GrayText;

            nodeCategories = new TreeNode("Kategóriák szerint");
            nodeCategories.ForeColor = SystemColors.GrayText;

            nodeCompanies = new TreeNode("Cégek szerint");
            nodeCompanies.ForeColor = SystemColors.GrayText;

            nodeFolders = new TreeNode("Mappák szerint");
            nodeFolders.ForeColor = SystemColors.GrayText;

            treeView.Nodes.Add(nodeAll);
            treeView.Nodes.Add(nodeTypes);
            treeView.Nodes.Add(nodeCategories);
            treeView.Nodes.Add(nodeCompanies);
            treeView.Nodes.Add(nodeFolders);

            nodeCategories.Nodes.Add("#");
            nodeCompanies.Nodes.Add("#");
            nodeFolders.Nodes.Add("#");
        }

        private void RefreshCategories()
        {
            ((Main)FindForm()).SetWaitCursor();

            using (Contacto.Lib.Context context = ContextManager.CreateContext(this, false))
            {
                nodeCategories.Nodes.Clear();
                foreach (Contacto.Lib.TypeDescription t in context.SchemaManager.GetTypeDescriptions(Contacto.Lib.EntityTypes.Document + Contacto.Lib.EntityTypes.Category))
                {
                    TreeNode nn = new TreeNode();
                    nn.Text = t.Description;
                    nn.Tag = t;
                    nn.ForeColor = SystemColors.GrayText;

                    nodeCategories.Nodes.Add(nn);
                    nn.Nodes.Add("#");
                }
            }

            ((Main)FindForm()).ResetWaitCursor();
        }

        private void RefreshCategoryDescriptions(TreeNode node, Contacto.Lib.TypeDescription t)
        {
            ((Main)FindForm()).SetWaitCursor();

            using (Contacto.Lib.Context context = ContextManager.CreateContext(this, false))
            {
                node.Nodes.Clear();
                foreach (Contacto.Lib.CategoryDescription c in context.SchemaManager.CategoryDescriptions[Contacto.Lib.EntityTypes.Document][t.Id].Values)
                {
                    TreeNode nn = new TreeNode();
                    nn.Text = c.Description;
                    nn.Tag = c;

                    node.Nodes.Add(nn);
                }
            }

            ((Main)FindForm()).ResetWaitCursor();
        }

        private void RefreshCompanies()
        {
            ((Main)FindForm()).SetWaitCursor();

            using (Contacto.Lib.Context context = ContextManager.CreateContext(this, true))
            {
                try
                {
                    nodeCompanies.Nodes.Clear();

                    Contacto.Lib.CompanyFactory cf = new Contacto.Lib.CompanyFactory(context);
                    foreach (Contacto.Lib.Company c in cf.FindDocumentCompanies(this.parentEntity))
                    {
                        TreeNode nn = new TreeNode();
                        nn.Text = c.DisplayName;
                        nn.Tag = c;

                        nodeCompanies.Nodes.Add(nn);
                    }
                }
                catch (System.Exception ex)
                {
                    Contacto.Lib.LogEntry log = new Contacto.Lib.LogEntry(context, parentEntity, Contacto.Lib.LogOperations.FindCompanies);
                    Program.HandleError(context, Messages.ErrorFindingCompanies, log, ex);
                }

            }

            ((Main)FindForm()).ResetWaitCursor();
        }

        private void RefreshFolders()
        {
            ((Main)FindForm()).SetWaitCursor();

            using (Contacto.Lib.Context context = ContextManager.CreateContext(this, true))
            {
                try
                {
                    nodeFolders.Nodes.Clear();

                    Contacto.Lib.FolderFactory ff = new Contacto.Lib.FolderFactory(context);
                    foreach (Contacto.Lib.Folder f in ff.FindDocumentFolders(this.parentEntity))
                    {
                        TreeNode nn = new TreeNode();
                        nn.Text = f.DisplayName;
                        nn.Tag = f;

                        nodeFolders.Nodes.Add(nn);
                    }
                }
                catch (System.Exception ex)
                {
                    Contacto.Lib.LogEntry log = new Contacto.Lib.LogEntry(context, parentEntity, Contacto.Lib.LogOperations.FindFolders);
                    Program.HandleError(context, Messages.ErrorFindingFolders, log, ex);
                }
            }

            ((Main)FindForm()).ResetWaitCursor();
        }

        public void RefreshDocuments(IEnumerable<Contacto.Lib.Document> documents, Contacto.Lib.Context context)
        {
            ((Main)FindForm()).SetWaitCursor();

            listView.RefreshListCompleted +=
                new RunWorkerCompletedEventHandler(delegate(object sender, RunWorkerCompletedEventArgs e)
                {
                    OnCountChanged();
                    if (context != null) context.Dispose();
                });

            listView.RefreshListAsync(documents);

            ((Main)FindForm()).ResetWaitCursor();
        }

        private ListViewItem ItemCreator(object o)
        {
            Contacto.Lib.Document doc = (Contacto.Lib.Document)o;
            doc.LoadDetails();

            ListViewItem li = new ListViewItem();

            li.Tag = doc;
            li.ImageKey = "document";

            CreateColumns(li, doc);

            return li;
        }

        private void treeView_BeforeExpand(object sender, TreeViewCancelEventArgs e)
        {
            if (e.Node.Nodes.Count == 1 && e.Node.Nodes[0].Text == "#")
            {
                if (e.Node == nodeCategories)
                {
                    RefreshCategories();
                }
                else if (e.Node == nodeCompanies)
                {
                    RefreshCompanies();
                }
                else if (e.Node == nodeFolders)
                {
                    RefreshFolders();
                }
                else if (e.Node.Tag != null && e.Node.Tag.GetType() == typeof(Contacto.Lib.TypeDescription))
                {
                    RefreshCategoryDescriptions(e.Node, (Contacto.Lib.TypeDescription)e.Node.Tag);
                }
            }
        }

        private void treeView_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Node.Tag != null || e.Node == nodeAll)
            {
                ((Main)FindForm()).SetWaitCursor();

                Contacto.Lib.Context context = ContextManager.CreateContext(this, true);

                try
                {
                    Contacto.Lib.DocumentFactory f = new Contacto.Lib.DocumentFactory(context);
                    if (e.Node == nodeAll)
                    {
                        RefreshDocuments(f.FindDocuments(this.parentEntity), context);
                    }
                    else if (e.Node.Tag.GetType() == typeof(Contacto.Lib.Company))
                    {
                        RefreshDocuments(f.FindDocuments(this.parentEntity, (Contacto.Lib.Company)e.Node.Tag), context);
                    }
                    else if (e.Node.Tag.GetType() == typeof(Contacto.Lib.Folder))
                    {
                        RefreshDocuments(f.FindDocuments(this.parentEntity, (Contacto.Lib.Folder)e.Node.Tag), context);
                    }
                    else if (e.Node.Tag.GetType() == typeof(Contacto.Lib.CategoryDescription))
                    {
                        RefreshDocuments(f.FindDocuments(this.parentEntity, (Contacto.Lib.CategoryDescription)e.Node.Tag), context);
                    }
                }
                catch (System.Exception ex)
                {
                    Contacto.Lib.LogEntry log = new Contacto.Lib.LogEntry(context, parentEntity, Contacto.Lib.LogOperations.FindDocuments);
                    Program.HandleError(context, Messages.ErrorFindingDocuments, log, ex);
                }

                ((Main)FindForm()).ResetWaitCursor();

            }
        }

        private void treeView_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Node.Tag != null)
            {
                Main f = (Main)FindForm();

                if (e.Node.Tag.GetType() == typeof(Contacto.Lib.Company))
                {
                    f.LoadEntity((Contacto.Lib.Company)e.Node.Tag, true);
                }
                else if (e.Node.Tag.GetType() == typeof(Contacto.Lib.Folder))
                {
                    f.LoadEntity((Contacto.Lib.Folder)e.Node.Tag, true);
                }
            }
        }

        private void OperationHandler(object sender, EventArgs e)
        {
            Main f = (Main)FindForm();

            if (!readOnly && (sender == toolNewFolder || sender == menuNewFolder))
            {
                f.CreateEntity(Contacto.Lib.EntityTypes.Folder, this.parentEntity, true);
            }
            else if (!readOnly && (sender == toolNew || sender == menuNew))
            {
                f.CreateEntity(Contacto.Lib.EntityTypes.Document, this.parentEntity, true);
            }
            else if (!readOnly && (sender == toolNewInternal || sender == menuNewInternal))
            {
                f.CreateDocument(this.parentEntity, null, Contacto.Lib.DocumentDirections.Internal, true);
            }
            else if (!readOnly && (sender == toolNewInbound || sender == menuNewInbound))
            {
                f.CreateDocument(this.parentEntity, null, Contacto.Lib.DocumentDirections.Inbound, true);
            }
            if (!readOnly && (sender == toolNewOutbound || sender == menuNewOutbound))
            {
                f.CreateDocument(this.parentEntity, null, Contacto.Lib.DocumentDirections.Outbound, true);
            }
            else if (sender == toolOpen || sender == menuOpen || sender == listView)
            {
                if (listView.SelectedItems.Count > 0)
                {
                    f.LoadEntity((Contacto.Lib.Entity)listView.SelectedItems[0].Tag, true);
                }
            }
            else if (sender == menuOpenWindow)
            {
                if (listView.SelectedItems.Count > 0)
                {
                    Program.CreateMainWindow((Contacto.Lib.Entity)listView.SelectedItems[0].Tag).Show();
                }
            }
            else if (!readOnly && (sender == toolDelete || sender == menuDelete))
            {
                if (listView.SelectedItems.Count > 0)
                {
                    if (EntityForm.DeleteEntity((Contacto.Lib.Entity)listView.SelectedItems[0].Tag))
                    {
                        listView.Cache.Remove((Contacto.Lib.Document)listView.SelectedItems[0].Tag);
                        listView.RefreshListAsync(listView.Cache);
                    }
                }
            }
            else if (sender == menuCopy)
            {
                CopySelected();
            }
            else if (sender == toolColumns || sender == menuColumns)
            {
                listView.SelectColumns();
            }
            else if (sender == toolSmallIcons || sender == menuSmallIcons)
            {
                listView.View = View.SmallIcon;
            }
            else if (sender == toolLargeIcons || sender == menuLargeIcons)
            {
                listView.View = View.LargeIcon;
            }
            else if (sender == toolList || sender == menuList)
            {
                listView.View = View.List;
            }
            else if (sender == toolDetails || sender == menuDetails)
            {
                listView.View = View.Details;
            }
            else if (sender == toolTiles || sender == menuTiles)
            {
                listView.View = View.Tile;
            }
            else if (sender == toolSaveList || sender == menuSaveList)
            {
                listView.SaveToFile();
            }
        }

        private void listView_DoubleClick(object sender, EventArgs e)
        {
            OperationHandler(sender, e);
        }
    }
}
