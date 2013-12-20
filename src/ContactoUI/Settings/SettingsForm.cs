using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Contacto.UI
{
    public partial class SettingsForm : Form
    {
        public SettingsForm()
        {
            InitializeComponent();
        }

        public void SaveFields(Settings sets)
        {
            System.Data.SqlClient.SqlConnectionStringBuilder csb =
                new System.Data.SqlClient.SqlConnectionStringBuilder();

            csb.DataSource = server.Text.Trim();
            if (instance.Text.Trim() != string.Empty)
                csb.DataSource += "\\" + instance.Text.Trim();
            csb.InitialCatalog = database.Text;
            csb.MultipleActiveResultSets = true;

            sets.SqlConnectionString = csb.ConnectionString;

            sets.TemplatePath = templates.Text;
        }
    }
}