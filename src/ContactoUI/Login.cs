using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Contacto.UI
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();

            version.Text = Application.ProductVersion.Substring(0, Application.ProductVersion.LastIndexOf("."));
        }

        private void Login_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                username.Enabled = false;
                password.Enabled = false;

                operationLabel.Visible = true;
                operation.Visible = true;
                operation.Text = "Bejelentkezés a rendszerbe...";
                Application.DoEvents();

                try
                {
                    ContextManager.AuthenticationMode = AuthenticationMode.Sql;
                    ContextManager.User.Username = username.Text;
                    ContextManager.User.Password = password.Text;
                    using (Contacto.Lib.Context context = ContextManager.CreateContext(null, true))
                    {
                        ContextManager.User.Context = context;
                        ContextManager.Company.Context = context;
                        Program.LoginUser();
                    }
                }
                catch (System.Exception ex)
                {
                    //*****
                    MessageBox.Show("Login failed: " + ex.Message);

                    System.Threading.Thread.Sleep(2000);

                    username.Enabled = true;
                    password.Enabled = true;
                    operationLabel.Visible = false;
                    operation.Visible = false;
                    Application.DoEvents();

                    password.Focus();
                    return;
                }

                LoadSchema();
            }
            if (e.KeyCode == Keys.Escape)
            {
                Close();
            }
        }

        private void password_Enter(object sender, EventArgs e)
        {
            password.SelectAll();
        }

        private void LoadSchema()
        {
            operationLabel.Visible = true;
            operation.Visible = true;
            operation.Text = Messages.LoadingSchema;
            Application.DoEvents();

            Program.LoadSchema();

            closeTimer.Enabled = true;
        }

        private void closeTimer_Tick(object sender, EventArgs e)
        {
            Close();
        }

        private void Login_Shown(object sender, EventArgs e)
        {
            // First try : windows authentication
            operation.Text = "Bejelentkezés a rendszerbe...";
            Application.DoEvents();

            ContextManager.AuthenticationMode = AuthenticationMode.Windows;
            using (Contacto.Lib.Context context = ContextManager.CreateContext(null, true))
            {
                ContextManager.User.Context = context;
                ContextManager.Company.Context = context;

                try
                {
                    Program.LoginUser();
                }
                catch (Contacto.Lib.DBIOException)
                {
                    // Windows authentication failed

                    username.Enabled = username.Visible = usernameLabel.Visible = true;
                    password.Enabled = password.Visible = passwordLabel.Visible = true;
                    operationLabel.Visible = false;
                    operation.Visible = false;
                    Application.DoEvents();

                    password.Focus();
                    return;
                }
            }

            LoadSchema();
        }
    }
}