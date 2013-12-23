using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace Contacto.UI
{
    public partial class EntityList : EntityListBase
    {
        public override bool ToolStripVisible
        {
            get { return toolStrip.Visible; }
            set { toolStrip.Visible = value; }
        }

        public EntityList()
        {
            InitializeComponent();

            listView.AddEntityColumns();
            listView.SaveColumns();
            listView.itemCreator = ItemCreator;
        }

        private ListViewItem ItemCreator(object o)
        {
            Contacto.Lib.Entity entity = (Contacto.Lib.Entity)o;
            ListViewItem li = new ListViewItem();

            li.Tag = entity;
            switch (entity.EntityType)
            {
                case Contacto.Lib.EntityTypes.Company:
                    li.ImageKey = "company"; break;
                case Contacto.Lib.EntityTypes.Person:
                    li.ImageKey = "person"; break;
                case Contacto.Lib.EntityTypes.Document:
                    li.ImageKey = "document"; break;
                case Contacto.Lib.EntityTypes.Folder:
                    li.ImageKey = "folder"; break;
                case Contacto.Lib.EntityTypes.Reminder:
                    li.ImageKey = "reminder"; break;
            }

            CreateColumns(li, entity);

            return li;
        }

        private void OperationHandler(object sender, EventArgs e)
        {
            if (sender == menuOpen || sender == listView)
            {
                if (listView.SelectedItems.Count > 0)
                {
                    Main f = (Main)FindForm();
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
            else if (sender == menuDelete)
            {
                DeleteSelected();
            }
            else if (sender == menuCopy)
            {
                CopySelected();
            }
            else if (sender == menuColumns)
            {
                listView.SelectColumns();
            }
            else if (sender == menuSaveList)
            {
                listView.SaveToFile();
            }
            else if (sender == menuSmallIcons)
            {
                listView.View = View.SmallIcon;
            }
            else if (sender == menuLargeIcons)
            {
                listView.View = View.LargeIcon;
            }
            else if (sender == menuList)
            {
                listView.View = View.List;
            }
            else if (sender == menuDetails)
            {
                listView.View = View.Details;
            }
            else if (sender == menuTiles)
            {
                listView.View = View.Tile;
            }
            else if (sender == toolSaveList || sender == menuSaveList)
            {
                listView.SaveToFile();
            }
        }

    }
}
