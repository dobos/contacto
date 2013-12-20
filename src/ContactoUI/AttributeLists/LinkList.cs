using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace Contacto.UI
{
    public partial class LinkList : UserControl
    {
        private bool readOnly = false;
        private Contacto.Lib.Entity parentEntity = null;
        public event EventHandler Changed;

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
                toolModify.Enabled = !value;
                toolDelete.Enabled = !value;
                menuNew.Enabled = !value;
                menuModify.Enabled = !value;
                menuDelete.Enabled = !value;
            }
        }

        public LinkList()
        {
            InitializeComponent();
        }

        public void RefreshList()
        {
            if (parentEntity != null && parentEntity.Links != null)
            {
                listView.Items.Clear();

                using (Contacto.Lib.Context context = ContextManager.CreateContext(this, false))
                {
                    foreach (Contacto.Lib.Link l in parentEntity.Links)
                    {
                        ListViewItem li = new ListViewItem();

                        Contacto.Lib.TypeDescription t = context.SchemaManager.GetTypeDescription(l.EntityType, l.Type);

                        li.Tag = l;
                        li.Text = t.Description;
                        li.SubItems.Add(l.DisplayText);
                        listView.Items.Add(li);
                    }
                }
            }
        }
        private void listView_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Delete:
                    OperationHandler(toolDelete, null);
                    break;
                case Keys.C:
                    //   ***                 if (e.Control)

                    break;
                case Keys.Enter:
                    OperationHandler(toolModify, null);
                    break;
            }
        }

        private bool CreateLink()
        {
            using (LinkForm f = new LinkForm())
            {
                f.Link.Item = new Contacto.Lib.Link(parentEntity);

                if (f.ShowDialog(FindForm()) == DialogResult.Cancel)
                    return false;

                // Save the identifier
                using (Contacto.Lib.Context context = ContextManager.CreateContext(this, true))
                {
                    try
                    {
                        f.Link.Item.Context = context;
                        f.Link.Item.Save();

                        RefreshList();
                        return true;
                    }
                    catch (System.Exception ex)
                    {
                        Contacto.Lib.LogEntry log = new Contacto.Lib.LogEntry(context, parentEntity, Contacto.Lib.LogOperations.CreateLink);
                        Program.HandleError(context, Messages.ErrorCreatingLink, log, ex);
                    }
                }
            }
            return false;
        }

        private bool ModifyLink(Contacto.Lib.Link l)
        {
            using (LinkForm f = new LinkForm())
            {
                f.Link.Item = l;

                if (f.ShowDialog(FindForm()) == DialogResult.Cancel)
                    return false;

                // Save the link
                bool forceOverwrite = false;
                while (true)
                {
                    using (Contacto.Lib.Context context = ContextManager.CreateContext(this, true))
                    {
                        f.Link.Item.Context = context;

                        try
                        {
                            f.Link.Item.Save(forceOverwrite);

                            RefreshList();
                            if (Changed != null) Changed(this, null);

                            return true;
                        }
                        catch (Contacto.Lib.InvalidVersionException)
                        {
                            if (MessageBox.Show(Messages.InvalidVersionModify, Application.ProductName, MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation) == DialogResult.OK)
                            {
                                context.Rollback();
                                forceOverwrite = true;
                                continue;
                            }
                            else
                                return false;
                        }
                        catch (System.Exception ex)
                        {
                            Contacto.Lib.LogEntry log = new Contacto.Lib.LogEntry(context, parentEntity, Contacto.Lib.LogOperations.ModifyLink);
                            Program.HandleError(context, Messages.ErrorModifyingLink, log, ex);
                        }
                    }
                    return false;
                }
            }
        }

        private bool DeleteLinks(List<Contacto.Lib.Link> links)
        {
            if (links.Count > 0)
            {
                if (MessageBox.Show(Messages.ConfirmDelete, Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                {
                    using (Contacto.Lib.Context context = ContextManager.CreateContext(this, true))
                    {
                        foreach (Contacto.Lib.Link l in links)
                        {
                            if (l.CanDelete())
                            {
                                // Save the attribute
                                bool forceDelete = false;
                                while (true)
                                {
                                    l.Context = context;

                                    try
                                    {
                                        l.Delete(forceDelete);

                                        // refresh
                                        RefreshList();
                                        if (Changed != null) Changed(this, null);

                                        return true;
                                    }
                                    catch (Contacto.Lib.InvalidVersionException)
                                    {
                                        if (MessageBox.Show(Messages.InvalidVersionDelete, Application.ProductName, MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation) == DialogResult.OK)
                                        {
                                            context.Rollback();
                                            forceDelete = true;
                                            continue;
                                        }
                                        else
                                        {
                                            return false;
                                        }
                                    }
                                    catch (System.Exception ex)
                                    {
                                        Contacto.Lib.LogEntry log = new Contacto.Lib.LogEntry(context, parentEntity, Contacto.Lib.LogOperations.DeleteLink);
                                        Program.HandleError(context, Messages.ErrorDeletingLink, log, ex);
                                    }

                                    return false;
                                }
                            }
                            else
                            {
                                MessageBox.Show(Messages.CannotDelete, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                    }
                }
            }
            return false;
        }

        private void CopyLinks(List<Contacto.Lib.Attribute> attributes)
        {
            string res = string.Empty;

            foreach (Contacto.Lib.Attribute a in attributes)
            {
                res += a.GetClipboardString() + "\r\n";
            }

            Clipboard.SetText(res);
        }

        private void OperationHandler(object sender, EventArgs e)
        {
            if (!readOnly && (sender == toolNew || sender == menuNew))
            {
                try     // ****** hekk, hogy ne dobjon hibát, ha nincsen szabad kategória...
                {
                    CreateLink();
                }
                catch (System.Exception)
                {
                }
            }
            else if (!readOnly && (sender == toolModify || sender == menuModify || sender == listView))
            {
                if (listView.SelectedItems.Count > 1)
                {
                    MessageBox.Show(Messages.SingleModify, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                if (listView.SelectedItems.Count != 0)
                {
                    if (((Contacto.Lib.Link)listView.SelectedItems[0].Tag).CanModify())
                    {
                        Contacto.Lib.Link l = (Contacto.Lib.Link)listView.SelectedItems[0].Tag;
                        ModifyLink(l);
                    }
                    else
                    {
                        MessageBox.Show(Messages.CannotModify, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }

                }
            }
            else if (!readOnly && (sender == toolDelete || sender == menuDelete))
            {
                List<Contacto.Lib.Link> selected = new List<Contacto.Lib.Link>();
                foreach (ListViewItem l in listView.SelectedItems)
                    selected.Add((Contacto.Lib.Link)l.Tag);

                DeleteLinks(selected);
            }
            else if (sender == menuCopy)
            {
                List<Contacto.Lib.Attribute> selected = new List<Contacto.Lib.Attribute>();
                foreach (ListViewItem l in listView.SelectedItems)
                    selected.Add((Contacto.Lib.Attribute)l.Tag);

                CopyLinks(selected);
            }
        }

    }
}
