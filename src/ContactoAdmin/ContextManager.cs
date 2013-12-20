using System;
using System.Collections.Generic;
using System.Text;

namespace Contacto.Admin
{
    class ContextManager
    {
        public static Contacto.Lib.User User = new Contacto.Lib.User();

        public static Contacto.Lib.Context CreateContext(bool openConnection)
        {
            Contacto.Lib.Context context = new Contacto.Lib.Context();

            if (openConnection)
            {
                context.Connection = new System.Data.SqlClient.SqlConnection(Program.ConnectionString);
                context.Connection.Open();

                context.Transaction = context.Connection.BeginTransaction();
            }

            context.User = User;
            context.SchemaManager = Program.SchemaManager;
            context.CheckoutManager = Program.CheckoutManager;

            context.DateLimitFrom = new DateTime(1900, 01, 01);
            context.DateLimitTo = new DateTime(2100, 12, 31);
            context.ShowHidden = false;
            context.ShowDeleted = false;
            context.ShowClosed = true;

            return context;
        }
    }
}
