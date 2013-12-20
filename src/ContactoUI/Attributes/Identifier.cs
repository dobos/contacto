using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace Contacto.UI
{
    public partial class Identifier : Attribute
    {
        private bool readOnly = false;

        public Contacto.Lib.Identifier Item
        {
            get
            {
                if (item != null)
                    SaveFields();

                return (Contacto.Lib.Identifier) item;
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
                this.value.ReadOnly = value;
            }
        }

        public Identifier()
            :base()
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
            SaveFields(item);
        }

        private void SaveFields(Contacto.Lib.Attribute item)
        {
            if (typeVisible)
                item.Type = ((Contacto.Lib.TypeDescription)type.SelectedItem).Id;

            Contacto.Lib.Identifier i = (Contacto.Lib.Identifier)item;

            i.Value = this.value.Text;
        }

        public override void LoadFields()
        {
            base.LoadFields();

            Contacto.Lib.Identifier i = (Contacto.Lib.Identifier)item;

            if (i.IsPhoneNumber())
            {
                this.value.Text = i.Value;
            }
            else
                this.value.Text = i.Value;

            SetLink(i);
        }

        private void SetLink(Contacto.Lib.Identifier item)
        {
            if (item.IsEmailAddress() || item.IsWebAddress())
            {
                Font f = new Font(this.Font, FontStyle.Underline);
                value.Font = f;
                value.ForeColor = Color.Blue;
                value.Cursor = Cursors.Hand;
            }
            else
            {
                value.ForeColor = SystemColors.WindowText;
                value.Cursor = Cursors.IBeam;
            }
        }

        protected override void Changed(object sender, EventArgs e)
        {
            base.Changed(sender, e);
        }

        private void TextBox_AutoSelect(object sender, EventArgs e)
        {
            ((TextBox)sender).SelectAll();
        }

        private void Identifier_Validating(object sender, CancelEventArgs e)
        {
            Contacto.Lib.Identifier dummy = new Contacto.Lib.Identifier((Contacto.Lib.Identifier)item);
            SaveFields(dummy);
            if (!dummy.IsValid())
            {
                MessageBox.Show(Messages.InvalidValue, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                e.Cancel = true;
            }
            if (dummy.Value != value.Text) value.Text = dummy.Value;
            SetLink(dummy);
        }

        private void Identifier_Validated(object sender, EventArgs e)
        {
            
        }

        private void value_DoubleClick(object sender, EventArgs e)
        {
            Contacto.Lib.Identifier i = (Contacto.Lib.Identifier) item;
            i.FollowLink(value.Text);
            
        }

    }
}
