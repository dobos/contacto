using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace Contacto.UI
{
    public partial class Link : Attribute
    {
        private bool readOnly = false;
        private bool clickable;

        private Contacto.Lib.Entity filterEntity;
        public event EventHandler BeforeEdit;

        public Contacto.Lib.Entity FilterEntity
        {
            set { this.filterEntity = value; }
        }

        public Contacto.Lib.Link Item
        {
            get
            {
                if (item != null)
                    SaveFields();

                return (Contacto.Lib.Link)item;
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

        public bool ReadOnly
        {
            get { return readOnly; }
            set
            {
                readOnly = value;

                type.Enabled = !value;
                edit.Enabled = !value;
            }
        }

        public bool Clickable
        {
            get { return clickable; }
            set
            {
                clickable = value;
                UpdateColor();
            }
        }

        public Link()
        {
            InitializeComponent();
        }

        private void UpdateColor()
        {
            Contacto.Lib.Link l = item as Contacto.Lib.Link;
            if (l != null && l.PointedEntity != null && !l.PointedEntity.Deleted && clickable)
            {
                this.value.Font = new Font(this.Font, FontStyle.Underline);
                this.value.ForeColor = Color.Blue;
                this.value.Cursor = Cursors.Hand;
            }
            else
            {
                this.value.Font = this.Font;
                this.value.ForeColor = SystemColors.WindowText;
                this.value.Cursor = Cursors.IBeam;
            }
        }

        public override void LoadFields()
        {
            base.LoadFields();

            Contacto.Lib.Link l = (Contacto.Lib.Link)item;

            if (l.PointedEntity != null)
            {
                this.value.Text = l.PointedEntity.DisplayName;
                if (l.PointedEntity.Deleted)
                {
                    this.value.Text += " (törölve)";
                }
            }
            else
            {
                this.value.Text = "(nincs kiválasztva)";
            }
            UpdateColor();
        }

        protected override void Changed(object sender, EventArgs e)
        {
            base.Changed(sender, e);
        }

        private void value_DoubleClick(object sender, EventArgs e)
        {
            Contacto.Lib.Link l = (Contacto.Lib.Link)item;

            if (l != null && l.PointedEntity != null && !l.PointedEntity.Deleted && clickable)
            {
                ((Main)FindForm()).LoadEntity(l.PointedEntity, true);
            }
        }

        private void edit_Click(object sender, EventArgs e)
        {
            if (BeforeEdit != null)
                BeforeEdit(this, null);

            using (LinkForm f = new LinkForm())
            {
                f.FilterEntity = filterEntity;
                f.Link.Item = (Contacto.Lib.Link)item;

                if (f.ShowDialog(FindForm()) == DialogResult.OK)
                {
                    LoadFields();
                    Changed(this, null);
                }
            }
        }

    }
}
