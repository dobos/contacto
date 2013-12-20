using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Contacto.Admin
{
    public partial class CategoryDescription : Form
    {
        private bool modify;

        public bool Modify
        {
            get { return modify; }
            set
            {
                modify = value;
            }
        }

        public CategoryDescription()
        {
            InitializeComponent();
        }

        public void LoadFields(Contacto.Lib.CategoryDescription c)
        {
            using (Contacto.Lib.Context context = ContextManager.CreateContext(false))
            {
                id.Text = c.Id.ToString();
                description.Text = c.Description;
            }
        }

        public void SaveFields(Contacto.Lib.CategoryDescription c)
        {
            if (!modify)
                c.Id = 0;   // it have to be saved

            c.Description = description.Text;
        }
    }
}