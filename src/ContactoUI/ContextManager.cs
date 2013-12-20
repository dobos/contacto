using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace Contacto.UI
{
    class ContextManager
    {
        public static AuthenticationMode AuthenticationMode = AuthenticationMode.Windows;
        public static Contacto.Lib.User User = new Contacto.Lib.User();
        public static Contacto.Lib.Company Company = new Contacto.Lib.Company();

        public static Contacto.Lib.Context CreateContext(Control control, bool openConnection)
        {
            Contacto.Lib.Context context = new Contacto.Lib.Context();

            if (control != null)
            {
                Main f = control.FindForm() as Main;
                if (f != null)
                {
                    context.DateLimitFrom = (DateTime)f.DateLimitFrom.Tag;
                    context.DateLimitTo = (DateTime)f.DateLimitTo.Tag;
                    context.ShowClosed = f.ShowClosed.Checked;
                    context.ShowHidden = f.ShowHidden.Checked;
                    context.ShowDeleted = f.ShowDeleted.Checked;
                }
            }

            if (openConnection)
            {
                //***** cache connection string after successful login
                System.Data.SqlClient.SqlConnectionStringBuilder csb =
                    new System.Data.SqlClient.SqlConnectionStringBuilder(Program.Settings.SqlConnectionString);

                if (AuthenticationMode == AuthenticationMode.Windows)
                    csb.IntegratedSecurity = true;
                else
                {
                    csb.IntegratedSecurity = false;
                    csb.PersistSecurityInfo = true;
                    csb.UserID = User.Username;
                    csb.Password = User.Password;
                }

                context.Connection = new System.Data.SqlClient.SqlConnection(csb.ConnectionString);
                context.Connection.Open();

                context.Transaction = context.Connection.BeginTransaction();
            }

            context.Templates = Program.Templates;
            context.User = User;
            context.Company = Company;
            context.SchemaManager = Program.SchemaManager;
            context.CheckoutManager = Program.CheckoutManager;

            return context;
        }
    }
}
