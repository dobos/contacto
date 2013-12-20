using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Contacto.UI
{
    public partial class ColumnSelector : Form
    {
        public ColumnSelector()
        {
            InitializeComponent();
        }

        private void add_Click(object sender, EventArgs e)
        {
            int i = 0;
            while (i < listAvailable.Items.Count)
            {
                if (listAvailable.SelectedItems.Contains(listAvailable.Items[i]))
                {
                    listSelected.Items.Add(listAvailable.Items[i]);
                    listAvailable.Items.RemoveAt(i);
                    continue;
                }
                i++;
            }
        }

        private void remove_Click(object sender, EventArgs e)
        {
            int i = 0;
            while (i < listSelected.Items.Count)
            {
                if (listSelected.SelectedItems.Contains(listSelected.Items[i]))
                {
                    listAvailable.Items.Add(listSelected.Items[i]);
                    listSelected.Items.RemoveAt(i);
                    continue;
                }
                i++;
            }
        }

        private void up_Click(object sender, EventArgs e)
        {
            int i = listSelected.SelectedIndex;
            if (i > 0)
            {
                object item = listSelected.SelectedItem;

                listSelected.Items.RemoveAt(i);
                listSelected.Items.Insert(i - 1, item);
                listSelected.SelectedIndex = i - 1;
            }
        }

        private void down_Click(object sender, EventArgs e)
        {
            int i = listSelected.SelectedIndex;
            if (i != -1 && i < listSelected.Items.Count - 1)
            {
                object item = listSelected.SelectedItem;

                listSelected.Items.RemoveAt(i);
                listSelected.Items.Insert(i + 1, item);
                listSelected.SelectedIndex = i + 1;
            }
        }
    }
}