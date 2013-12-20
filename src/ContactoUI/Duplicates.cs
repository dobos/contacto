using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Contacto.UI
{
    public partial class Duplicates : Form
    {

        private IEnumerable<Contacto.Lib.Entity> entities;

        public Duplicates()
        {
            InitializeComponent();
        }

        public IEnumerable<Contacto.Lib.Entity> Entities
        {
            set
            {
                entities = value;
                RefreshList();
            }
        }

        private void RefreshList()
        {
            listView.Items.Clear();

            foreach (Contacto.Lib.Entity e in entities)
            {
                ListViewItem ni = new ListViewItem();

                ni.Text = e.DisplayName;

                listView.Items.Add(ni);
            }
        }
    }
}