using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace Contacto.UI
{
    public partial class CompanyList : EntityListBase
    {
        public override bool ToolStripVisible
        {
            get { return toolStrip.Visible; }
            set { toolStrip.Visible = value; }
        }

        public CompanyList()
        {
            InitializeComponent();

            listView.AddEntityColumns();
            listView.SaveColumns();
            listView.itemCreator = ItemCreator;
        }
        
        public void RefreshList(IEnumerable<Contacto.Lib.Company> companies, Contacto.Lib.Context context)
        {
            listView.RefreshListCompleted +=
                new RunWorkerCompletedEventHandler(delegate(object sender, RunWorkerCompletedEventArgs e)
                {
                    OnCountChanged();
                    if (context != null) context.Dispose();
                });

            listView.RefreshListAsync(companies);
        }

        private ListViewItem ItemCreator(object o)
        {
            Contacto.Lib.Company company = (Contacto.Lib.Company)o;
            company.LoadDetails();

            ListViewItem li = new ListViewItem();

            li.Tag = company;
            li.ImageKey = "company";

            CreateColumns(li, company);

            return li;
        }

        private void OperationHandler(object sender, EventArgs e)
        {
            if (sender == toolOpen || sender == menuOpen || sender == listView)
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
            else if (sender == toolDelete || sender == menuDelete)
            {
                DeleteSelected();
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
    }
}
