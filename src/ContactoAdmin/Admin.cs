using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Contacto.Admin
{
    public partial class Admin : Form
    {
        public Admin()
        {
            InitializeComponent();
        }

        private void tabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl.SelectedTab == tabEntities)
            {
                entityList.RefreshList();
            }
            else if (tabControl.SelectedTab == tabTypes)
            {
                typeList.RefreshList();
            }
            else if (tabControl.SelectedTab == tabCategories)
            {
                categories.RefreshList();
            }
            else if (tabControl.SelectedTab == tabUsers)
            {
                users.RefreshList();
            }
            else if (tabControl.SelectedTab == tabDeleted)
            {
                deleted.RefreshList();
            }
        }
    }
}