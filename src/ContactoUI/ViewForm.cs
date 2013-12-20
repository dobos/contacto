using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace Contacto.UI
{
    public partial class ViewForm : UserControl
    {

        protected Main form;
        private bool collapse;
        private bool modified;


        public event EventHandler ModifiedChanged;
        public event EventHandler StatusTextChanged;

        public bool Collapse
        {
            get { return collapse; }
            set
            {
                collapse = true;
            }
        }

        public bool Modified
        {
            get { return modified; }
            set
            {
                if (modified != value)
                {
                    modified = value;
                    if (ModifiedChanged != null) ModifiedChanged(this, null);
                }
            }
        }

        public virtual string StatusText
        {
            get { return string.Empty; }
        }

        public ViewForm()
        {
            InitializeComponent();

            this.collapse = false;
            this.modified = false;
            this.form = null;
        }

        public ViewForm(Main form)
        {
            InitializeComponent();

            this.collapse = false;
            this.modified = false;
            this.form = form;
        }

        protected void View_Changed(object sender, EventArgs e)
        {
            Modified = true;
        }

        public virtual void Initialize()
        {

        }

        protected virtual void UpdateEnable()
        {

        }

        public virtual bool Close()
        {
            return true;
        }

        public virtual void Command(Commands command)
        {
        }

        public virtual void OnStatusTextChanged()
        {
            if (StatusTextChanged != null)
                StatusTextChanged(this, null);
        }
    }
}
