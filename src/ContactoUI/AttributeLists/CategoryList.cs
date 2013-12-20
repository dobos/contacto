using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace Contacto.UI
{
    public partial class CategoryList : UserControl
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

        public CategoryList()
        {
            InitializeComponent();
        }

        public void RefreshList()
        {
            if (parentEntity != null && parentEntity.Categories != null)
            {
                listView.Items.Clear();

                using (Contacto.Lib.Context context = ContextManager.CreateContext(this, false))
                {
                    foreach (Contacto.Lib.Category c in parentEntity.Categories)
                    {
                        ListViewItem li = new ListViewItem();

                        Contacto.Lib.TypeDescription t = context.SchemaManager.GetTypeDescription(c.EntityType, c.Type);

                        li.Tag = c;
                        li.Text = t.Description;
                        li.SubItems.Add(c.DisplayText);
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

        private bool CreateCategory()
        {
            using (CategoryForm f = new CategoryForm())
            {
                f.Category.Item = new Contacto.Lib.Category(parentEntity);

                if (f.ShowDialog() == DialogResult.Cancel)
                    return false;

                // Save the identifier
                using (Contacto.Lib.Context context = ContextManager.CreateContext(this, true))
                {
                    try
                    {
                        f.Category.Item.Context = context;
                        f.Category.Item.Save();

                        RefreshList();
                        return true;
                    }
                    catch (System.Exception ex)
                    {
                        Contacto.Lib.LogEntry log = new Contacto.Lib.LogEntry(context, parentEntity, Contacto.Lib.LogOperations.CreateCategory);
                        Program.HandleError(context, Messages.ErrorCreatingCategory, log, ex);
                    }
                }
            }
            return false;
        }

        private bool ModifyCategory(Contacto.Lib.Category c)
        {
            using (CategoryForm f = new CategoryForm())
            {
                f.Category.Item = c;

                if (f.ShowDialog() == DialogResult.Cancel)
                    return false;

                // Save the address
                bool forceOverwrite = false;
                while (true)
                {
                    using (Contacto.Lib.Context context = ContextManager.CreateContext(this, true))
                    {
                        f.Category.Item.Context = context;

                        try
                        {
                            f.Category.Item.Save(forceOverwrite);

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
                            Contacto.Lib.LogEntry log = new Contacto.Lib.LogEntry(context, parentEntity, Contacto.Lib.LogOperations.ModifyCategory);
                            Program.HandleError(context, Messages.ErrorModifyingCategory, log, ex);
                        }
                    }
                    return false;
                }
            }
        }

        private bool DeleteCategories(List<Contacto.Lib.Category> categories)
        {
            if (categories.Count > 0)
            {
                if (MessageBox.Show(Messages.ConfirmDelete, Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                {
                    using (Contacto.Lib.Context context = ContextManager.CreateContext(this, true))
                    {
                        foreach (Contacto.Lib.Category c in categories)
                        {
                            if (c.CanDelete())
                            {
                                // Save the attribute
                                bool forceDelete = false;
                                while (true)
                                {
                                    c.Context = context;

                                    try
                                    {
                                        c.Delete(forceDelete);

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
                                        Contacto.Lib.LogEntry log = new Contacto.Lib.LogEntry(context, parentEntity, Contacto.Lib.LogOperations.DeleteCategory);
                                        Program.HandleError(context, Messages.ErrorDeletingCategory, log, ex);
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

        private void CopyCategories(List<Contacto.Lib.Attribute> attributes)
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
                    CreateCategory();
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
                    if (((Contacto.Lib.Category)listView.SelectedItems[0].Tag).CanModify())
                    {
                        Contacto.Lib.Category c = (Contacto.Lib.Category)listView.SelectedItems[0].Tag;
                        ModifyCategory(c);
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
                List<Contacto.Lib.Category> selected = new List<Contacto.Lib.Category>();
                foreach (ListViewItem l in listView.SelectedItems)
                    selected.Add((Contacto.Lib.Category)l.Tag);

                DeleteCategories(selected);
            }
            else if (sender == menuCopy)
            {
                List<Contacto.Lib.Attribute> selected = new List<Contacto.Lib.Attribute>();
                foreach (ListViewItem l in listView.SelectedItems)
                    selected.Add((Contacto.Lib.Attribute)l.Tag);

                CopyCategories(selected);
            }
        }
    }
}
