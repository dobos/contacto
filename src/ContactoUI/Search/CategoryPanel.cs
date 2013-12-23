using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace Contacto.UI
{
    public partial class CategoryPanel : UserControl
    {
        private int entityType;

        private List<Label> categoryLabels = new List<Label>();
        private List<ComboBox> categoryTypes = new List<ComboBox>();
        private List<ComboBox> categoryValues = new List<ComboBox>();

        public int EntityType
        {
            get { return entityType; }
            set { entityType = value; }
        }

        public CategoryPanel()
        {
            InitializeComponent();
        }

        public void Initialize()
        {
            AddCategoryList();
            RefreshCategoryLists();
        }

        public void GetCategories(out Contacto.Lib.TypeDescription[] categoryTypes, out string[] categoryValues)
        {
            List<Contacto.Lib.TypeDescription> types = new List<Contacto.Lib.TypeDescription>();
            List<string> values = new List<string>();

            foreach (ComboBox c in this.categoryTypes)
            {
                if (c.SelectedItem is Contacto.Lib.TypeDescription)
                {
                    types.Add(c.SelectedItem as Contacto.Lib.TypeDescription);
                    values.Add(((ComboBox)c.Tag).Text);
                }
            }
            categoryTypes = types.ToArray();
            categoryValues = values.ToArray();
        }

        private void AddCategoryList()
        {
            using (Contacto.Lib.Context context = ContextManager.CreateContext(this, false))
            {
                // Create label
                Label l = new Label();
                l.Height = 17;
                l.Scale(new SizeF(this.CurrentAutoScaleDimensions.Width / 96f, this.CurrentAutoScaleDimensions.Height / 96f));
                l.Anchor = AnchorStyles.Left | AnchorStyles.Top | AnchorStyles.Right | AnchorStyles.Bottom;
                

                // Create type selector list
                ComboBox type = new ComboBox();
                type.DropDownStyle = ComboBoxStyle.DropDownList;
                type.Anchor = AnchorStyles.Left | AnchorStyles.Top | AnchorStyles.Right;
                type.Sorted = true;
                type.SelectedIndexChanged += new EventHandler(type_SelectedIndexChanged);

                foreach (Contacto.Lib.TypeDescription t in context.SchemaManager.GetTypeDescriptions(entityType + Contacto.Lib.EntityTypes.Category))
                {
                    type.Items.Add(t);
                }
                type.Items.Add("(mindegy)"); // ****

                // Create value selector list
                ComboBox value = new ComboBox();
                value.DropDownStyle = ComboBoxStyle.DropDown;
                value.Anchor = AnchorStyles.Left | AnchorStyles.Top | AnchorStyles.Right;
                value.Sorted = true;

                type.Tag = value;
                value.Tag = type;

                categoryLabels.Add(l);
                categoryTypes.Add(type);
                categoryValues.Add(value);
            }
        }

        void type_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox type = (ComboBox)sender;

            if (type.SelectedItem is Contacto.Lib.TypeDescription)
            {
                ComboBox value = (ComboBox)type.Tag;

                Contacto.Lib.TypeDescription td = (Contacto.Lib.TypeDescription)type.SelectedItem;

                using (Contacto.Lib.Context context = ContextManager.CreateContext(this, false))
                {
                    value.Items.Clear();
                    foreach (Contacto.Lib.CategoryDescription cd in context.SchemaManager.CategoryDescriptions[entityType][td.Id].Values)
                    {
                        value.Items.Add(cd);
                    }
                }

                // if no other category with no type selected, add new
                bool found = false;

                foreach (ComboBox t in categoryTypes)
                {
                    if (t.SelectedItem == null)
                    {
                        found = true;
                        break;
                    }
                }

                if (!found && categoryTypes.Count < 5)
                {
                    AddCategoryList();
                    RefreshCategoryLists();
                }
            }
            else if (type.SelectedItem is string)
            {
                // remove
                int i = categoryTypes.IndexOf(type);

                // if no other category with no type selected, add new
                bool found = false;

                foreach (ComboBox t in categoryTypes)
                {
                    if ((t.SelectedItem == null || t.SelectedItem is string) && t != type)
                    {
                        found = true;
                        break;
                    }
                }

                if (found && categoryTypes.Count > 1)
                {
                    RemoveCategoryList(i);
                    RefreshCategoryLists();
                }
            }
        }

        private void RemoveCategoryList(int i)
        {
            categoryLabels.RemoveAt(i);
            categoryTypes.RemoveAt(i);
            categoryValues.RemoveAt(i);
        }

        private void RefreshCategoryLists()
        {
            SuspendLayout();

            categoryLayoutPanel.Controls.Clear();
            categoryLayoutPanel.RowCount = 0;
            categoryLayoutPanel.RowStyles.Clear();

            for (int i = 0; i < categoryTypes.Count; i++)
            {
                categoryLayoutPanel.RowCount += 3;
                categoryLayoutPanel.RowStyles.Add(new RowStyle(SizeType.AutoSize, 0));
                categoryLayoutPanel.RowStyles.Add(new RowStyle(SizeType.AutoSize, 0));
                categoryLayoutPanel.RowStyles.Add(new RowStyle(SizeType.AutoSize, 0));

                categoryLabels[i].Text = string.Format("{0}. kategória:", i + 1);    //*****

                categoryLayoutPanel.Controls.Add(categoryLabels[i], 0, i * 3);
                categoryLayoutPanel.Controls.Add(categoryTypes[i], 0, i * 3 + 1);
                categoryLayoutPanel.Controls.Add(categoryValues[i], 0, i * 3 + 2);

                categoryLayoutPanel.Refresh();
            }

            this.Refresh();

            ResumeLayout();
        }
    }
}
