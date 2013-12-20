using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace Contacto.UI
{
    public partial class Date : Attribute
    {
        private bool readOnly = false;

        public Contacto.Lib.Date Item
        {
            get
            {
                if (item != null)
                    SaveFields();

                return (Contacto.Lib.Date) item;
            }
            set
            {
                item = value;

                if (item != null)
                {
                    RefreshTypeList();
                    LoadFields();
                }
            }
        }

        public bool ReadOnly
        {
            get { return readOnly; }
            set
            {
                readOnly = value;

                this.type.Enabled = !value;
                this.value.Enabled = !value;
            }
        }

        public Date()
        {
            InitializeComponent();
        }

        public override string LabelText
        {
            get
            {
                return valueLabel.Text;
            }
            set
            {
                valueLabel.Text = value;
            }
        }

        /*
        protected override void UpdatePositions()
        {
            SuspendLayout();

            int lw = (labelVisible) ? labelWidth : 0;

            type.Left = lw;
            type.Width = Math.Max(this.Width - type.Left, 0);
            value.Left = lw;
            value.Width = Math.Max(this.Width - value.Left, 0);

            typeLabel.Visible = typeVisible;
            type.Visible = typeVisible;
            if (typeVisible)
            {
                valueLabel.Top = 30;
                value.Top = 27;
            }
            else
            {
                valueLabel.Top = 3;
                value.Top = 0;
            }

            Height = value.Bottom;

            ResumeLayout();
        }
         * */

        public override void SaveFields()
        {
            if (typeVisible)
                item.Type = ((Contacto.Lib.TypeDescription)type.SelectedItem).Id;

            Contacto.Lib.Date d = (Contacto.Lib.Date)item;

            d.Value = this.value.Value;
        }

        public override void LoadFields()
        {
            base.LoadFields();

            Contacto.Lib.Date d = (Contacto.Lib.Date)item;

            this.value.Value = (d.Value == DateTime.MinValue) ? DateTime.Now : d.Value;
        }

    }
}
