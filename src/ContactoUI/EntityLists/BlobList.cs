using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace Contacto.UI
{
    public partial class BlobList : UserControl
    {
        private bool readOnly = false;
        private Contacto.Lib.Document parentEntity = null;
        public event EventHandler Changed;

        public Contacto.Lib.Document ParentEntity
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
                toolCheckout.Enabled = !value;
                toolCheckin.Enabled = !value;
                menuNew.Enabled = !value;
                menuDelete.Enabled = !value;
                menuCheckOut.Enabled = !value;
                menuCheckIn.Enabled = !value;
            }
        }

        public BlobList()
        {
            InitializeComponent();
            GenerateMenu();

            listView.AddEntityColumns();
            listView.SaveColumns();
            listView.itemCreator = ItemCreator;
        }

        private void GenerateMenu()
        {
            using (Contacto.Lib.Context context = ContextManager.CreateContext(this, false))
            {
                if (context.Templates != null)
                {
                    toolNew.DropDownItems.AddRange(GenerateMenuFromTemplateDir(context.Templates));
                }
            }
        }

        private ToolStripItem[] GenerateMenuFromTemplateDir(Contacto.Lib.Directory dir)
        {
            List<ToolStripItem> res = new List<ToolStripItem>();

            foreach (Contacto.Lib.Directory d in dir.Directories)
            {
                ToolStripItem[] items = GenerateMenuFromTemplateDir(d);
                if (items.Length > 0)
                {
                    ToolStripMenuItem mi = new ToolStripMenuItem(Path.GetFileName(d.Path));
                    mi.DropDownItems.AddRange(items);
                    res.Add(mi);
                }
            }

            foreach (string file in dir.Files)
            {
                ToolStripMenuItem mi = new ToolStripMenuItem(Path.GetFileName(file));
                mi.Tag = file;
                mi.Click += new EventHandler(Template_Click);
                res.Add(mi);
            }

            return res.ToArray();
        }

        private void Template_Click(object sender, EventArgs e)
        {
            CreateBlobs(new string[] { (string)((ToolStripMenuItem)sender).Tag });
        }

        public void RefreshList()
        {
            RefreshList(parentEntity.Blobs, null);
        }

        public void RefreshList(IEnumerable<Contacto.Lib.Blob> blobs, Contacto.Lib.Context context)
        {
            listView.RefreshListCompleted +=
                new RunWorkerCompletedEventHandler(delegate(object sender, RunWorkerCompletedEventArgs e)
                {
                    if (context != null) context.Dispose();
                });

            listView.RefreshListAsync(blobs);
        }


        private ListViewItem ItemCreator(object o)
        {
            Contacto.Lib.Blob b = (Contacto.Lib.Blob)o;

            ListViewItem li = new ListViewItem();

            li.Tag = b;

            for (int i = 0; i < listView.Columns.Count; i++)
            {
                string value = b.GetFieldFormatted((string)listView.Columns[i].Tag);

                if (i == 0)
                    li.Text = value;
                else
                    li.SubItems.Add(value);
            }


            string ext = System.IO.Path.GetExtension(b.Filename).ToLower();
            if (ext.StartsWith(".")) ext = ext.Substring(1);
            // icon
            try
            {
                if (!listView.SmallImageList.Images.ContainsKey(ext))
                {
                    listView.SmallImageList.Images.Add(ext, IconHandler.IconFromExtension(ext, IconSize.Small));
                    listView.LargeImageList.Images.Add(ext, IconHandler.IconFromExtension(ext, IconSize.Large));
                }

                li.ImageKey = ext;
            }
            catch (System.Exception)
            {
            }

            return li;
        }

        private bool CreateBlob()
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                return CreateBlobs(openFileDialog.FileNames);
            }
            else
                return false;
        }

        private bool CreateBlobs(string[] files)
        {
            using (Contacto.Lib.Context context = ContextManager.CreateContext(this, true))
            {
                try
                {
                    foreach (string filename in files)
                    {
                        Contacto.Lib.Blob b = new Contacto.Lib.Blob(context);
                        b.NewEntity(this.parentEntity);

                        b.Filename = System.IO.Path.GetFileName(filename);
                        if (b.CheckFilenameDuplicate())
                        {
                            MessageBox.Show(Messages.DuplicateBlobFilename, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                            context.Rollback();
                            RefreshList();
                            return false;
                        }

                        b.Save();
                        b.SetData(filename);
                        parentEntity.Blobs.Add(b);
                    }
                }
                catch (System.Exception ex)
                {
                    Contacto.Lib.LogEntry log = new Contacto.Lib.LogEntry(context, parentEntity, Contacto.Lib.LogOperations.CreateBlob);
                    Program.HandleError(context, Messages.ErrorCreatingBlob, log, ex);
                }
            }

            RefreshList();
            return true;
        }

        private bool CreateBlobs(string[] filenames, MemoryStream[] mss)
        {
            using (Contacto.Lib.Context context = ContextManager.CreateContext(this, true))
            {
                try
                {
                    for (int i = 0; i < filenames.Length; i++)
                    {
                        Contacto.Lib.Blob b = new Contacto.Lib.Blob(context);
                        b.NewEntity(this.parentEntity);

                        b.Filename = System.IO.Path.GetFileName(filenames[i]);
                        if (b.CheckFilenameDuplicate())
                        {
                            MessageBox.Show(Messages.DuplicateBlobFilename, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                            context.Rollback();
                            RefreshList();
                            return false;
                        }

                        b.Save();
                        b.SetData(filenames[i], mss[i]);
                        parentEntity.Blobs.Add(b);
                    }
                }
                catch (System.Exception ex)
                {
                    Contacto.Lib.LogEntry log = new Contacto.Lib.LogEntry(context, parentEntity, Contacto.Lib.LogOperations.CreateBlob);
                    Program.HandleError(context, Messages.ErrorCreatingBlob, log, ex);
                }
            }

            RefreshList();
            return true;
        }

        private bool DeleteBlobs(List<Contacto.Lib.Blob> blobs)
        {
            if (blobs.Count > 0)
            {
                if (MessageBox.Show(Messages.ConfirmDelete, Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                {
                    using (Contacto.Lib.Context context = ContextManager.CreateContext(this, true))
                    {
                        foreach (Contacto.Lib.Blob d in blobs)
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

                                        //*** ezt itt át lehet rakni?
                                        parentEntity.Blobs.Remove(d);

                                        // refresh
                                        RefreshList();
                                        if (Changed != null) Changed(this, null);

                                        break;
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
                                        Contacto.Lib.LogEntry log = new Contacto.Lib.LogEntry(context, d, Contacto.Lib.LogOperations.DeleteBlob);
                                        Program.HandleError(context, Messages.ErrorDeletingBlob, log, ex);
                                    }

                                    break;
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

        private bool CheckInBlobs(List<Contacto.Lib.Blob> blobs)
        {
            foreach (Contacto.Lib.Blob blob in blobs)
            {
                bool tryDelete = true;
                while (true)
                {
                    using (Contacto.Lib.Context context = ContextManager.CreateContext(this, true))
                    {
                        try
                        {
                            blob.Context = context;

                            blob.CheckIn(tryDelete);
                            RefreshList();

                            break;
                        }
                        catch (System.Exception)
                        {
                            //**** itt amúgy is van hibaüzenet, ez nem kell
                            /*
                            Contacto.Lib.LogEntry log = new Contacto.Lib.LogEntry(context, blob, Contacto.Lib.LogOperations.CheckInBlob);
                            Program.HandleError(context, Messages.ErrorCheckinBlob, log, ex);
                             * */

                            DialogResult dr = MessageBox.Show(Messages.ErrorCheckinBlob, Application.ProductName, MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2);
                            if (dr == DialogResult.Retry)
                                continue;
                            if (dr == DialogResult.Ignore)
                            {
                                tryDelete = false;
                                continue;
                            }
                            if (dr == DialogResult.Abort)
                                return false;
                        }
                    }
                }
            }
            return true;
        }

        public bool CheckInAll()
        {
            // check in
            Contacto.Lib.Document doc = parentEntity;

            using (Contacto.Lib.Context context = ContextManager.CreateContext(this, false))
            {
                List<Contacto.Lib.Blob> tocheckin = new List<Contacto.Lib.Blob>();
                foreach (Contacto.Lib.Blob blb in doc.Blobs)
                {
                    // find the corresponding blob among checked out ones
                    Contacto.Lib.Blob blob = context.CheckoutManager.CheckedoutBlobs.Find(
                        delegate(Contacto.Lib.Blob b)
                        {
                            return b.Guid == blb.Guid;
                        });

                    if (blob != null) tocheckin.Add(blob);
                }

                return CheckInBlobs(tocheckin);
            }
        }

        private bool CheckOutBlobs(List<Contacto.Lib.Blob> blobs, Contacto.Lib.CheckOutMode mode)
        {
            using (Contacto.Lib.Context context = ContextManager.CreateContext(this, true))
            {
                try
                {
                    foreach (ListViewItem li in listView.SelectedItems)
                    {
                        Contacto.Lib.Blob b = (Contacto.Lib.Blob)li.Tag;

                        b.Context = context;
                        b.CheckOut(mode);

                        switch (mode)
                        {
                            case Contacto.Lib.CheckOutMode.ReadOnly:
                                context.CheckoutManager.OpenForPreview(b);
                                break;
                            case Contacto.Lib.CheckOutMode.Edit:
                                context.CheckoutManager.OpenForEdit(b);
                                break;
                            case Contacto.Lib.CheckOutMode.Print:
                                context.CheckoutManager.OpenForPrint(b);
                                break;
                        }
                    }
                }
                catch (System.Exception ex)
                {
                    Contacto.Lib.LogEntry log = new Contacto.Lib.LogEntry(context, parentEntity, Contacto.Lib.LogOperations.CheckOutBlob);
                    Program.HandleError(context, Messages.ErrorCheckoutBlob, log, ex);
                }

                RefreshList();
                return true;
            }
        }

        private bool SaveAsBlobs(List<Contacto.Lib.Blob> blobs)
        {
            if (blobs.Count == 0) return false;

            using (Contacto.Lib.Context context = ContextManager.CreateContext(this, true))
            {
                try
                {
                    if (listView.SelectedItems.Count == 1)
                    {
                        Contacto.Lib.Blob b = (Contacto.Lib.Blob)listView.SelectedItems[0].Tag;

                        b.Context = context;
                        saveFileDialog.FileName = b.Filename;
                        if (saveFileDialog.ShowDialog() == DialogResult.OK)
                        {
                            b.SaveToFile(saveFileDialog.FileName);
                        }
                    }
                    else
                    {
                        if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
                        {
                            foreach (ListViewItem li in listView.SelectedItems)
                            {
                                Contacto.Lib.Blob b = (Contacto.Lib.Blob)li.Tag;

                                b.Context = context;
                                b.SaveToFile(folderBrowserDialog.SelectedPath + System.IO.Path.DirectorySeparatorChar + b.Filename);
                            }
                        }
                    }
                    return true;
                }
                catch (System.Exception ex)
                {
                    Contacto.Lib.LogEntry log = new Contacto.Lib.LogEntry(context, parentEntity, Contacto.Lib.LogOperations.SaveAsBlob);
                    Program.HandleError(context, Messages.ErrorSavingBlob, log, ex);
                    return false;
                }
            }
        }

        #region Event Handlers

        private void OperationHandler(object sender, EventArgs e)
        {
            List<Contacto.Lib.Blob> selected = new List<Contacto.Lib.Blob>();
            foreach (ListViewItem l in listView.SelectedItems)
                selected.Add((Contacto.Lib.Blob)l.Tag);

            if (!readOnly && (sender == toolNewFile || sender == menuNew))
            {
                CreateBlob();
            }
            else if (!readOnly && (sender == toolDelete || sender == menuDelete))
            {
                DeleteBlobs(selected);
            }
            else if (!readOnly && (sender == toolCheckout || sender == menuCheckOut))
            {
                CheckOutBlobs(selected, Contacto.Lib.CheckOutMode.Edit);
            }
            else if (sender == toolPreview || sender == menuPreview || sender == listView)
            {
                CheckOutBlobs(selected, Contacto.Lib.CheckOutMode.ReadOnly);
            }
            else if (sender == toolPrint || sender == menuPrint)
            {
                CheckOutBlobs(selected, Contacto.Lib.CheckOutMode.Print);
            }
            else if (!readOnly && (sender == toolCheckin || sender == menuCheckIn))
            {
                CheckInBlobs(selected);
            }
            else if (sender == toolSaveAs || sender == menuSaveAs)
            {
                SaveAsBlobs(selected);
            }
            else if (sender == menuColumns || sender == toolColumns)
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
        }

        private void toolStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            OperationHandler(e.ClickedItem, (EventArgs)e);
        }

        private void listViewMenuStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            OperationHandler(e.ClickedItem, (EventArgs)e);
        }

        private void listView_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Delete:
                    OperationHandler(toolDelete, null);
                    break;
                case Keys.Enter:
                    OperationHandler(toolPreview, null);
                    break;
            }
        }

        private void listView_DragDrop(object sender, DragEventArgs e)
        {
            try
            {
                InteropManager im = new InteropManager(e);

                string[] filenames = im.GetFilenames();
                MemoryStream[] mss = im.GetData();

                if (filenames != null && mss != null)
                {
                    CreateBlobs(filenames, mss);
                }
            }
            catch (System.Exception)
            {
                //*******
            }
        }

        private void listView_DragEnter(object sender, DragEventArgs e)
        {
            try
            {
                InteropManager im = new InteropManager(e);
                im.EnableDropOnEnter();
            }
            catch (System.Exception)
            {
                //*****
            }
        }

        private void listView_ItemDrag(object sender, ItemDragEventArgs e)
        {
            try
            {
                List<Stream> msa = new List<Stream>();
                List<string> filenames = new List<string>();

                using (Contacto.Lib.Context context = ContextManager.CreateContext(this, true))
                {
                    foreach (ListViewItem l in listView.SelectedItems)
                    {
                        Contacto.Lib.Blob b = (Contacto.Lib.Blob)l.Tag;
                        b.Context = context;
                        b.GetData();

                        msa.Add(b.GetDataStream());
                        filenames.Add(b.Filename);
                    }
                }

                InteropManager im = new InteropManager();
                this.DoDragDrop(im.StartDrag(msa.ToArray(), filenames.ToArray()), DragDropEffects.Copy);
            }
            catch (System.Exception)
            {
                //******
            }
        }

        #endregion

        private void listView_AfterLabelEdit(object sender, LabelEditEventArgs e)
        {
            if (e.Label == null) return;    // no change

            Contacto.Lib.Blob b = (Contacto.Lib.Blob)listView.Items[e.Item].Tag;

            if (Path.GetExtension(b.Filename) != Path.GetExtension(e.Label))
            {
                if (MessageBox.Show(Messages.ConfirmChangeExtension, Application.ProductName, MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.Cancel)
                {
                    e.CancelEdit = true;
                    return;
                }
            }

            using (Contacto.Lib.Context context = ContextManager.CreateContext(this, true))
            {
                b.Context = context;
                b.LoadDetails();
                b.Filename = e.Label;
                b.Format = Path.GetExtension(e.Label);

                if (b.CheckFilenameDuplicate())
                {
                    MessageBox.Show(Messages.DuplicateBlobFilename, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    context.Rollback();
                    e.CancelEdit = true;
                    return;
                }

                b.Save();
            }

            RefreshList();

        }

    }
}
