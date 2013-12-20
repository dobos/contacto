using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Contacto.UI
{
    public partial class IdentifierForm : Form
    {
        public IdentifierForm()
        {
            InitializeComponent();
        }

        private void IdentifierForm_Shown(object sender, EventArgs e)
        {
            ok.Top = Identifier.Bottom + 12;
            cancel.Top = Identifier.Bottom + 12;
        }
    }
}