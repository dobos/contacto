using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace Contacto.UI
{
    public partial class PersonList : EntityListBase
    {
        private bool readOnly = false;
        private Contacto.Lib.Company parentEntity = null;

        public Contacto.Lib.Company ParentEntity
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
                    RefreshList(parentEntity.Persons, null);
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

        public PersonList()
        {
            InitializeComponent();

            listView.AddEntityColumns();
            listView.SaveColumns();
            listView.itemCreator = ItemCreator;
        }


        public void RefreshList(IEnumerable<Contacto.Lib.Person> persons, Contacto.Lib.Context context)
        {
            listView.RefreshListCompleted +=
                new RunWorkerCompletedEventHandler(delegate(object sender, RunWorkerCompletedEventArgs e)
                {
                    OnCountChanged();
                    if (context != null) context.Dispose();
                });

            listView.RefreshListAsync(persons);
        }

        private ListViewItem ItemCreator(object o)
        {
            Contacto.Lib.Person p = (Contacto.Lib.Person)o;
            p.LoadDetails();

            ListViewItem li = new ListViewItem();

            li.Tag = p;
            li.ImageKey = "card";

            CreateColumns(li, p);

            return li;
        }

        private void OperationHandler(object sender, EventArgs e)
        {
            if (!readOnly && (sender == toolNew || sender == menuNew))
            {
                Main f = (Main)base.FindForm();
                f.CreateEntity(Contacto.Lib.EntityTypes.Person, parentEntity, true);
            }
            else if (sender == toolOpen || sender == menuOpen || sender == listView)
            {
                if (listView.SelectedItems.Count > 0)
                {
                    ((Main)FindForm()).LoadEntity((Contacto.Lib.Entity)listView.SelectedItems[0].Tag, true);
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
                DeleteSelected();
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
                    if (e.Shift)
                        OperationHandler(menuOpenWindow, null);
                    else
                        OperationHandler(toolOpen, null);
                    break;
            }
        }
    }
}
