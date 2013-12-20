using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace Contacto.UI
{
    public partial class DateList : UserControl
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

        public DateList()
        {
            InitializeComponent();
        }

        public void RefreshList()
        {
            if (parentEntity != null && parentEntity.Dates != null)
            {
                listView.Items.Clear();

                using (Contacto.Lib.Context context = ContextManager.CreateContext(this, false))
                {
                    foreach (Contacto.Lib.Date d in parentEntity.Dates)
                    {
                        ListViewItem li = new ListViewItem();

                        Contacto.Lib.TypeDescription t = context.SchemaManager.GetTypeDescription(d.EntityType, d.Type);

                        li.Tag = d;
                        li.Text = t.Description;
                        li.SubItems.Add(d.DisplayText);
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

        private bool CreateDate()
        {
            using (DateForm f = new DateForm())
            {
                f.Date.Item = new Contacto.Lib.Date(parentEntity);

                if (f.ShowDialog() == DialogResult.Cancel)
                    return false;

                // Save the identifier
                using (Contacto.Lib.Context context = ContextManager.CreateContext(this, true))
                {
                    try
                    {
                        f.Date.Item.Context = context;
                        f.Date.Item.Save();

                        RefreshList();
                        return true;
                    }
                    catch (System.Exception ex)
                    {
                        Contacto.Lib.LogEntry log = new Contacto.Lib.LogEntry(context, parentEntity, Contacto.Lib.LogOperations.CreateDate);
                        Program.HandleError(context, Messages.ErrorCreatingDate, log, ex);
                    }
                }
            }
            return false;
        }

        private bool ModifyDate(Contacto.Lib.Date d)
        {
            using (DateForm f = new DateForm())
            {
                f.Date.Item = d;

                if (f.ShowDialog() == DialogResult.Cancel)
                    return false;

                // Save the address
                bool forceOverwrite = false;
                while (true)
                {
                    using (Contacto.Lib.Context context = ContextManager.CreateContext(this, true))
                    {
                        f.Date.Item.Context = context;

                        try
                        {
                            f.Date.Item.Save(forceOverwrite);
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
                            Contacto.Lib.LogEntry log = new Contacto.Lib.LogEntry(context, parentEntity, Contacto.Lib.LogOperations.ModifyDate);
                            Program.HandleError(context, Messages.ErrorModifyingDate, log, ex);
                        }
                    }
                    return false;
                }
            }
        }

        private bool DeleteDates(List<Contacto.Lib.Date> dates)
        {
            if (dates.Count > 0)
            {
                if (MessageBox.Show(Messages.ConfirmDelete, Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                {
                    using (Contacto.Lib.Context context = ContextManager.CreateContext(this, true))
                    {
                        foreach (Contacto.Lib.Date d in dates)
                        {
                            if (d.CanDelete())
                            {
                                // Save the attribute
                                bool forceDelete = false;
                                while (true)
                                {
                                    d.Context = context;

                                    try
                                    {
                                        d.Delete(forceDelete);

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
                                        Contacto.Lib.LogEntry log = new Contacto.Lib.LogEntry(context, parentEntity, Contacto.Lib.LogOperations.DeleteDate);
                                        Program.HandleError(context, Messages.ErrorDeletingDate, log, ex);
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

        private void CopyDates(List<Contacto.Lib.Attribute> attributes)
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
                    CreateDate();
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
                    if (((Contacto.Lib.Date)listView.SelectedItems[0].Tag).CanModify())
                    {
                        Contacto.Lib.Date d = (Contacto.Lib.Date)listView.SelectedItems[0].Tag;
                        ModifyDate(d);
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
                List<Contacto.Lib.Date> selected = new List<Contacto.Lib.Date>();
                foreach (ListViewItem l in listView.SelectedItems)
                    selected.Add((Contacto.Lib.Date)l.Tag);

                DeleteDates(selected);
            }
            else if (sender == menuCopy)
            {
                List<Contacto.Lib.Attribute> selected = new List<Contacto.Lib.Attribute>();
                foreach (ListViewItem l in listView.SelectedItems)
                    selected.Add((Contacto.Lib.Attribute)l.Tag);

                CopyDates(selected);
            }
        }
    }
}
