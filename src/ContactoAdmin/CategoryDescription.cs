using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Contacto.Admin
{
    public partial class CategoryDescription : Form
    {
        private bool modify;

        public bool Modify
        {
            get { return modify; }
            set
            {
                modify = value;
            }
        }

        public CategoryDescription()
        {
            InitializeComponent();
        }

        public void LoadFields(Contacto.Lib.CategoryDescription c)
        {
                id.Text = c.Id.ToString();
                description.Text = c.Description;
                backColor.BackColor = c.BackColor;
                foreColor.BackColor = c.ForeColor;
        }

        public void SaveFields(Contacto.Lib.CategoryDescription c)
        {
            if (!modify)
                c.Id = 0;   // it have to be saved

            c.Description = description.Text;
            c.BackColor = backColor.BackColor;
            c.ForeColor = foreColor.BackColor;
        }

        private void pickBackColor_Click(object sender, EventArgs e)
        {
            backColor.BackColor = PickColor(backColor.BackColor);
        }

        private void pickForeColor_Click(object sender, EventArgs e)
        {
            foreColor.BackColor = PickColor(foreColor.BackColor);
        }

        private Color PickColor(Color color)
        {
            colorDialog.Color = color;

            if (colorDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                return colorDialog.Color;
            }
            else
            {
                return color;
            }
        }
    }
}