using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace Contacto.UI
{
    public partial class EntityListBase : UserControl
    {
        public event EventHandler CountChanged;

        protected virtual void OnCountChanged()
        {
            if (CountChanged != null)
                CountChanged(this, null);
        }

        public EntityListBase()
        {
            InitializeComponent();
        }

        public virtual bool ToolStripVisible
        {
            get { return false; }
            set { }
        }

        public int Count
        {
            get { return listView.Items.Count; }
        }

        public void RefreshList(IEnumerable<Contacto.Lib.Entity> entities, Contacto.Lib.Context context)
        {
            listView.RefreshListCompleted +=
                new RunWorkerCompletedEventHandler(delegate(object sender, RunWorkerCompletedEventArgs e)
                {
                    OnCountChanged();
                    context.Dispose();
                });

            listView.RefreshListAsync(entities);
        }

        public Contacto.Lib.Entity GetPrevious(Contacto.Lib.Entity selected)
        {
            bool found = false;
            int index = 0;
            foreach (ListViewItem li in listView.Items)
            {
                if (((Contacto.Lib.Entity)li.Tag).Guid == selected.Guid)
                {
                    found = true;
                    break;
                }
                index++;
            }

            if (found && index > 0)
            {
                return (Contacto.Lib.Entity)listView.Items[index - 1].Tag;
            }
            else
                return null;

        }

        public Contacto.Lib.Entity GetNext(Contacto.Lib.Entity selected)
        {
            bool found = false;
            int index = 0;
            foreach (ListViewItem li in listView.Items)
            {
                if (((Contacto.Lib.Entity)li.Tag).Guid == selected.Guid)
                {
                    found = true;
                    break;
                }
                index++;
            }

            if (found && index + 1 < listView.Items.Count)
            {
                return (Contacto.Lib.Entity)listView.Items[index + 1].Tag;
            }
            else
                return null;
        }

        protected void DeleteSelected()
        {
            //**** ezt itt meg lehetne írni többelemes törlésre is....
            if (listView.SelectedItems.Count > 0)
            {
                if (EntityForm.DeleteEntity(listView.SelectedItems[0].Tag as Contacto.Lib.Entity))
                {
                    listView.Items.Remove(listView.SelectedItems[0]);
                }
            }
        }

        protected void CopySelected()
        {
            if (listView.SelectedItems.Count > 0)
            {
                using (Contacto.Lib.Context context = ContextManager.CreateContext(this, true))
                {
                    string res = string.Empty;

                    for (int i = 0; i < listView.SelectedItems.Count; i++)
                    {
                        ((Contacto.Lib.Entity)listView.SelectedItems[i].Tag).Context = context;
                        res += ((Contacto.Lib.Entity)listView.SelectedItems[i].Tag).GetClipboardString() + Environment.NewLine;
                    }

                    if (res != string.Empty)
                    {
                        Clipboard.SetText(res);
                    }
                }
            }
        }

        public virtual void Command(Commands command)
        {
            switch (command)
            {
                case Commands.Copy:
                    CopySelected();
                    break;
                case Commands.Delete:
                    DeleteSelected();
                    break;
                case Commands.Save:
                    listView.SaveToFile();
                    break;
            }
        }
    }
}
