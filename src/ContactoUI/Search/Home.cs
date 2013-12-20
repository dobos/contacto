using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace Contacto.UI
{
    public partial class Home : ViewForm, ISearchView
    {
        public Home(Main form)
            : base(form)
        {
            InitializeComponent();
        }

        #region ISearchView Members

        public Contacto.Lib.Entity GetPrevious(Contacto.Lib.Entity selected)
        {
            return null;
        }

        public Contacto.Lib.Entity GetNext(Contacto.Lib.Entity selected)
        {
            return null;
        }

        #endregion
    }
}
