using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Contacto.UI
{
    public partial class CategoryForm : Form
    {
        public CategoryForm()
        {
            InitializeComponent();
        }

        private void DateForm_Shown(object sender, EventArgs e)
        {
            ok.Top = Category.Bottom + 12;
            cancel.Top = Category.Bottom + 12;
        }
    }
}