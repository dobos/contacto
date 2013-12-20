using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Contacto.UI
{
    public partial class AddressForm : Form
    {
        public AddressForm()
        {
            InitializeComponent();
        }

        private void AddressForm_Shown(object sender, EventArgs e)
        {
            ok.Top = Address.Bottom + 12;
            cancel.Top = Address.Bottom + 12;
        }
    }
}