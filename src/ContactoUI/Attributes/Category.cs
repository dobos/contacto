using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace Contacto.UI
{
    public partial class Category : Attribute
    {
        private bool readOnly = false;

        public Contacto.Lib.Category Item
        {
            get
            {
                if (item != null)
                    SaveFields();

                return (Contacto.Lib.Category)item;
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

        public Category()
            : base()
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


        public override void SaveFields()
        {
            if (typeVisible)
                item.Type = ((Contacto.Lib.TypeDescription)type.SelectedItem).Id;

            Contacto.Lib.Category c = (Contacto.Lib.Category)item;

            if (this.value.FindString(this.value.Text) > -1 && this.value.SelectedItem != null)
                c.Value = ((Contacto.Lib.CategoryDescription)this.value.SelectedItem).Id;
            else
                c.Value = -1;    // free text

            c.Text = this.value.Text;
        }

        public override void LoadFields()
        {
            base.LoadFields();

            RefreshValueList();

            Contacto.Lib.Category c = (Contacto.Lib.Category)item;


            if (c.Value == -1)
                this.value.Text = c.Text;
            else
            {
                for (int i = 0; i < this.value.Items.Count; i++)
                    if (((Contacto.Lib.CategoryDescription)this.value.Items[i]).Id == c.Value)
                        this.value.SelectedIndex = i;
            }

        }

        private void RefreshValueList()
        {
            using (Contacto.Lib.Context context = ContextManager.CreateContext(null, false))
            {
                Contacto.Lib.TypeDescription t;

                if (type.SelectedItem != null)
                    t = (Contacto.Lib.TypeDescription)type.SelectedItem;
                else
                    t = context.SchemaManager.GetTypeDescription(item.EntityType, item.Type);

                if (t.Freetext)
                    this.value.DropDownStyle = ComboBoxStyle.DropDown;
                else
                    this.value.DropDownStyle = ComboBoxStyle.DropDownList;


                this.value.Items.Clear();
                foreach (Contacto.Lib.CategoryDescription c in context.SchemaManager.CategoryDescriptions[t.EntityType - Contacto.Lib.EntityTypes.Category][t.Id].Values)
                {
                    this.value.Items.Add(c);
                }
            }

            if (this.value.Items.Count > 0)
                this.value.SelectedIndex = 0;
        }

        //*** törölhetõ?
        /*
        private void type_SelectedIndexChanged(object sender, EventArgs e)
        {
            RefreshValueList();
        }
         * */

    }
}
