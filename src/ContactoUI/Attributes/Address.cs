using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace Contacto.UI
{
    public partial class Address : Attribute
    {
        private bool readOnly = false;

        public Contacto.Lib.Address Item
        {
            get
            {
                if (item != null)
                    SaveFields();

                return (Contacto.Lib.Address)item;
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

                type.Enabled = !value;
                street.ReadOnly = value;
                city.ReadOnly = value;
                zip.ReadOnly = value;
                state.Enabled = !value;
                country.Enabled = !value;
            }
        }

        public Address()
        {
            InitializeComponent();
        }

        /*
        protected override void UpdatePositions()
        {
            SuspendLayout();

            int lw = (labelVisible) ? labelWidth : 0;

            type.Left = lw;
            type.Width = Math.Max(this.Width - type.Left, 0);
            street.Left = lw;
            street.Width = Math.Max(this.Width - street.Left, 0);
            zip.Left = Math.Max(this.Width - zip.Width, 0);
            zipLabel.Left = Math.Max(zip.Left - zipLabel.Width - 8, 0);
            city.Left = lw;
            city.Width = Math.Max(zipLabel.Left - city.Left - 8, 0);
            state.Left = lw;
            state.Width = Math.Max(this.Width - state.Left, 0);
            country.Left = lw;
            country.Width = Math.Max(this.Width - country.Left, 0);

            typeLabel.Visible = typeVisible;
            type.Visible = typeVisible;
            if (typeVisible)
            {
                streetLabel.Top = 30;
                street.Top = 27;
                cityLabel.Top = 56;
                city.Top = 53;
                zipLabel.Top = 56;
                zip.Top = 53;
                stateLabel.Top = 82;
                state.Top = 79;
                countryLabel.Top = 108;
                country.Top = 105;
            }
            else
            {
                streetLabel.Top = 3;
                street.Top = 0;
                cityLabel.Top = 29;
                city.Top = 26;
                zipLabel.Top = 29;
                zip.Top = 26;
                stateLabel.Top = 55;
                state.Top = 52;
                countryLabel.Top = 81;
                country.Top = 78;
            }

            stateLabel.Visible = !collapse;
            state.Visible = !collapse;
            countryLabel.Visible = !collapse;
            country.Visible = !collapse;

            if (collapse)
                Height = city.Bottom;
            else
                Height = country.Bottom;

            ResumeLayout();
        }
         * */

        public override void SaveFields()
        {
            base.SaveFields();

            Contacto.Lib.Address a = (Contacto.Lib.Address)item;

            a.Street = this.street.Text;
            a.City = this.city.Text;
            a.State = this.state.Text;
            a.Country = this.country.Text;
            a.Zip = this.zip.Text;
        }

        public override void LoadFields()
        {
            base.LoadFields();

            Contacto.Lib.Address a = (Contacto.Lib.Address)item;

            this.street.Text = a.Street;
            this.city.Text = a.City;
            this.state.Text = a.State;
            this.country.Text = a.Country;
            this.zip.Text = a.Zip;
        }

        protected override void Changed(object sender, EventArgs e)
        {
            base.Changed(sender, e);
        }


    }
}
