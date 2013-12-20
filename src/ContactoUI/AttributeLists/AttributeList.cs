using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace Contacto.UI
{
    public partial class AttributeList : UserControl
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

        public AttributeList()
        {
            InitializeComponent();
        }

        public void RefreshList()
        {
            if (parentEntity != null)
            {
                listView.Items.Clear();

                using (Contacto.Lib.Context context = ContextManager.CreateContext(this, false))
                {
                    if (parentEntity.Addresses != null)
                    {
                        foreach (Contacto.Lib.Address a in parentEntity.Addresses)
                        {
                            ListViewItem li = new ListViewItem();

                            Contacto.Lib.TypeDescription t = context.SchemaManager.GetTypeDescription(a.EntityType, a.Type);

                            li.Tag = a;
                            li.Text = t.Description;
                            li.SubItems.Add(a.DisplayText);

                            li.Group = listView.Groups["address"];

                            listView.Items.Add(li);
                        }
                    }
                    if (parentEntity.Identifiers != null)
                    {
                        foreach (Contacto.Lib.Identifier a in parentEntity.Identifiers)
                        {
                            ListViewItem li = new ListViewItem();

                            Contacto.Lib.TypeDescription t = context.SchemaManager.GetTypeDescription(a.EntityType, a.Type);

                            li.Tag = a;
                            li.Text = t.Description;
                            li.SubItems.Add(a.DisplayText);

                            switch ((Contacto.Lib.IdentifierTypes)t.Id)
                            {
                                case Contacto.Lib.IdentifierTypes.PrimaryPhone:
                                case Contacto.Lib.IdentifierTypes.Phone:
                                case Contacto.Lib.IdentifierTypes.PrimaryFax:
                                case Contacto.Lib.IdentifierTypes.PrimaryMobile:
                                case Contacto.Lib.IdentifierTypes.Fax:
                                case Contacto.Lib.IdentifierTypes.Mobile:
                                    li.Group = listView.Groups["phone"];
                                    break;
                                case Contacto.Lib.IdentifierTypes.PrimaryEmail:
                                case Contacto.Lib.IdentifierTypes.Email:
                                    li.Group = listView.Groups["email"];
                                    break;
                                case Contacto.Lib.IdentifierTypes.WebAddress:
                                    li.Group = listView.Groups["web"];
                                    break;
                                case Contacto.Lib.IdentifierTypes.MsnId:
                                case Contacto.Lib.IdentifierTypes.SkypeId:
                                    li.Group = listView.Groups["im"];
                                    break;
                            }


                            listView.Items.Add(li);
                        }
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
                    if (e.Control)
                    {
                        OperationHandler(menuCopy, null);
                    }
                    break;
                case Keys.Enter:
                    OperationHandler(toolModify, null);
                    break;
            }
        }

        private bool CreateAddress()
        {
            using (AddressForm f = new AddressForm())
            {
                f.Address.Item = new Contacto.Lib.Address(parentEntity);

                if (f.ShowDialog() == DialogResult.Cancel)
                    return false;

                // Save the address
                using (Contacto.Lib.Context context = ContextManager.CreateContext(this, true))
                {
                    try
                    {
                        f.Address.Item.Context = context;
                        f.Address.Item.Save();

                        RefreshList();
                        return true;
                    }
                    catch (System.Exception ex)
                    {
                        Contacto.Lib.LogEntry log = new Contacto.Lib.LogEntry(context, parentEntity, Contacto.Lib.LogOperations.CreateAddress);
                        Program.HandleError(context, Messages.ErrorCreatingAddress, log, ex);
                    }
                }
            }

            return false;
        }

        private bool ModifyAddress(Contacto.Lib.Address a)
        {
            using (AddressForm f = new AddressForm())
            {
                f.Address.Item = a;

                if (f.ShowDialog() == DialogResult.Cancel)
                    return false;

                // Save the address
                bool forceOverwrite = false;
                while (true)
                {
                    using (Contacto.Lib.Context context = ContextManager.CreateContext(this, true))
                    {
                        f.Address.Item.Context = context;

                        try
                        {
                            f.Address.Item.Save(forceOverwrite);

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
                            Contacto.Lib.LogEntry log = new Contacto.Lib.LogEntry(context, parentEntity, Contacto.Lib.LogOperations.ModifyAddress);
                            Program.HandleError(context, Messages.ErrorModifyingAddress, log, ex);
                        }
                    }

                    return false;
                }
            }
        }

        private bool CreateIdentifier()
        {
            using (IdentifierForm f = new IdentifierForm())
            {
                f.Identifier.Item = new Contacto.Lib.Identifier(parentEntity);

                if (f.ShowDialog() == DialogResult.Cancel)
                    return false;

                using (Contacto.Lib.Context context = ContextManager.CreateContext(this, true))
                {
                    try
                    {

                        f.Identifier.Item.Context = context;
                        f.Identifier.Item.Save();

                        RefreshList();
                        return true;
                    }

                    catch (System.Exception ex)
                    {
                        Contacto.Lib.LogEntry log = new Contacto.Lib.LogEntry(context, parentEntity, Contacto.Lib.LogOperations.CreateIdentifier);
                        Program.HandleError(context, Messages.ErrorCreatingIdentifier, log, ex);
                    }
                }
            }
            return false;
        }

        private bool ModifyIdentifier(Contacto.Lib.Identifier i)
        {
            using (IdentifierForm f = new IdentifierForm())
            {
                f.Identifier.Item = i;

                if (f.ShowDialog() == DialogResult.Cancel)
                    return false;

                // Save the address
                bool forceOverwrite = false;
                while (true)
                {
                    using (Contacto.Lib.Context context = ContextManager.CreateContext(this, true))
                    {
                        f.Identifier.Item.Context = context;

                        try
                        {
                            f.Identifier.Item.Save(forceOverwrite);

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
                            Contacto.Lib.LogEntry log = new Contacto.Lib.LogEntry(context, parentEntity, Contacto.Lib.LogOperations.ModifyIdentifier);
                            Program.HandleError(context, Messages.ErrorModifyingIdentifier, log, ex);
                        }
                    }

                    return false;
                }
            }
        }

        private bool DeleteAttributes(List<Contacto.Lib.Attribute> attributes)
        {
            if (attributes.Count > 0)
            {
                if (MessageBox.Show(Messages.ConfirmDelete, Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                {

                    using (Contacto.Lib.Context context = ContextManager.CreateContext(this, true))
                    {
                        foreach (Contacto.Lib.Attribute a in attributes)
                        {
                            if (a.CanDelete())
                            {
                                // Save the attribute
                                bool forceDelete = false;
                                while (true)
                                {
                                    a.Context = context;

                                    try
                                    {
                                        a.Delete(forceDelete);

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
                                        Contacto.Lib.LogEntry log = new Contacto.Lib.LogEntry(context, parentEntity, Contacto.Lib.LogOperations.DeleteAttribute);
                                        Program.HandleError(context, Messages.ErrorDeletingAttribute, log, ex);
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

        private void CopyAttributes(List<Contacto.Lib.Attribute> attributes)
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
            if (!readOnly && (sender == toolNewAddress || sender == menuNewAddress))
            {
                CreateAddress();
            }
            else if (!readOnly && (sender == toolNewIdentifier || sender == menuNewIdentifier))
            {
                CreateIdentifier();
            }
            if (!readOnly && (sender == toolModify || sender == menuModify || sender == listView))
            {
                if (listView.SelectedItems.Count > 1)
                {
                    MessageBox.Show(Messages.SingleModify, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                if (listView.SelectedItems.Count != 0)
                {
                    if (((Contacto.Lib.Attribute)listView.SelectedItems[0].Tag).CanModify())
                    {
                        if (listView.SelectedItems[0].Tag.GetType() == typeof(Contacto.Lib.Address))
                        {
                            Contacto.Lib.Address a = (Contacto.Lib.Address)listView.SelectedItems[0].Tag;
                            ModifyAddress(a);
                        }
                        else if (listView.SelectedItems[0].Tag.GetType() == typeof(Contacto.Lib.Identifier))
                        {
                            Contacto.Lib.Identifier i = (Contacto.Lib.Identifier)listView.SelectedItems[0].Tag;
                            ModifyIdentifier(i);
                        }
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
                List<Contacto.Lib.Attribute> selected = new List<Contacto.Lib.Attribute>();
                foreach (ListViewItem l in listView.SelectedItems)
                    selected.Add((Contacto.Lib.Attribute)l.Tag);

                DeleteAttributes(selected);
            }
            else if (sender == menuCopy)
            {
                List<Contacto.Lib.Attribute> selected = new List<Contacto.Lib.Attribute>();
                foreach (ListViewItem l in listView.SelectedItems)
                    selected.Add((Contacto.Lib.Attribute)l.Tag);

                CopyAttributes(selected);
            }
            else if (sender == menuFollowLink)
            {
                if (listView.SelectedItems.Count > 0)
                {
                    Contacto.Lib.Identifier i = listView.SelectedItems[0].Tag as Contacto.Lib.Identifier;
                    if (i != null)
                    {
                        i.FollowLink(null);
                    }
                }
            }
            else if (sender == toolSaveList || sender == menuSaveList)
            {
                
            }
        }
    }
}
