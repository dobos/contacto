using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace Contacto.UI
{
    public partial class Attribute : UserControl
    {
        protected Contacto.Lib.Attribute item;
        protected bool collapse;
        protected bool typeVisible;
        protected bool labelVisible;
        protected int labelWidth;

        public event EventHandler ItemChanged;

        public bool Collapse
        {
            get { return collapse; }
            set
            {
                collapse = value;
                //UpdatePositions();
            }
        }


        public bool TypeVisible
        {
            get { return typeVisible; }
            set
            {
                typeVisible = value;
                table.Visible = value;
            }
        }

        public virtual string LabelText
        {
            get { return string.Empty;  }
            set { }
        }

        /*
        public bool LabelVisible
        {
            get { return labelVisible; }
            set
            {
                labelVisible = value;
                UpdatePositions();
            }
        }

        public int LabelWidth
        {
            get { return labelWidth; }
            set
            {
                labelWidth = value;
                UpdatePositions();
            }
        }

        public string LabelText
        {
            get { return valueLabel.Text; }
            set { valueLabel.Text = value; }
        }*/


        public Attribute()
        {
            InitializeComponent();
            InitializeMembers();
        }

        private void InitializeMembers()
        {
            collapse = false;
            typeVisible = false;
        }

        protected void RefreshTypeList()
        {
            type.Items.Clear();

            foreach (Contacto.Lib.TypeDescription t in item.Context.SchemaManager.GetTypeDescriptions(item.EntityType))
            {
                if (!t.Hidden)
                    type.Items.Add(t);
            }
        }

        public virtual void LoadFields()
        {
            if (item.TypeDescription != null && (item.TypeDescription.Hidden) && item.Type != 0)
            {
                TypeVisible = false;
            }
            else if (typeVisible)
            {
                foreach (Contacto.Lib.TypeDescription t in type.Items)
                {
                    if (t.Id == item.Type)
                        type.SelectedItem = t;
                }
                if (type.SelectedItem == null)
                    type.SelectedItem = type.Items[0];
            }
        }

        public virtual void SaveFields()
        {
            if (typeVisible)
                item.Type = ((Contacto.Lib.TypeDescription)type.SelectedItem).Id;
        }

        protected virtual void Changed(object sender, EventArgs e)
        {
            if (ItemChanged != null)
                ItemChanged(sender, e);
        }
    }
}
