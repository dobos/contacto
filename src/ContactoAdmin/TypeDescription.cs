using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Contacto.Admin
{
    public partial class TypeDescription : Form
    {
        private bool modify;

        public bool Modify
        {
            get { return modify; }
            set
            {
                modify = value;

                entity.Enabled = !modify;
            }
        }

        public TypeDescription()
        {
            InitializeComponent();
        }

        public void RefreshEntityLists()
        {
            entity.Items.Clear();
            linkedEntity.Items.Clear();
            linkedEntity.Items.Add("(nincs)");

            using (Contacto.Lib.Context context = ContextManager.CreateContext(false))
            {
                foreach (Contacto.Lib.TypeDescription t in context.SchemaManager.GetAllEntityDescriptions())
                {
                    entity.Items.Add(t);
                    linkedEntity.Items.Add(t);
                }
            }

        }

        public void LoadFields(Contacto.Lib.TypeDescription t)
        {
            using (Contacto.Lib.Context context = ContextManager.CreateContext(false))
            {
                id.Text = t.Id.ToString();
                if (t.EntityType != 0)
                {
                    entity.SelectedItem = context.SchemaManager.GetEntityDescription(t.EntityType);
                }
                else
                {
                    entity.SelectedIndex = 0;
                }
                description.Text = t.Description;
                if (t.LinkedEntityType != 0)
                {
                    linkedEntity.SelectedItem = context.SchemaManager.GetEntityDescription(t.LinkedEntityType);
                }
                else
                {
                    linkedEntity.SelectedIndex = 0;
                }
                system.Checked = t.System;
                hidden.Checked = t.Hidden;
                required.Checked = t.Required;
                multiple.Checked = t.Multiple;
                freeText.Checked = t.Freetext;
            }
        }

        public void SaveFields(Contacto.Lib.TypeDescription t)
        {
            if (!modify)
                t.Id = 0;   // it have to be saved
            t.EntityType = ((Contacto.Lib.TypeDescription)entity.SelectedItem).EntityType;
            t.Description = description.Text;
            if (linkedEntity.SelectedIndex == 0)
                t.LinkedEntityType = 0;
            else
                t.LinkedEntityType = ((Contacto.Lib.TypeDescription)linkedEntity.SelectedItem).EntityType;
            t.System = system.Checked;
            t.Hidden = hidden.Checked;
            t.Required = required.Checked;
            t.Multiple = multiple.Checked;
            t.Freetext = freeText.Checked;
        }

        private void entity_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!modify)
            {
                using (Contacto.Lib.Context context = ContextManager.CreateContext(false))
                {
                    id.Text = context.SchemaManager.GetNextTypeId(((Contacto.Lib.TypeDescription)entity.SelectedItem).EntityType).ToString();
                }
            }
        }
    }
}