using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Contacto.Admin
{
    static class Program
    {

        public static string ConnectionString;
        public static Contacto.Lib.SchemaManager SchemaManager = null;
        public static Contacto.Lib.CheckOutManager CheckoutManager = null;

        [STAThread]
        static void Main()
        {
            try
            {
                LoadConnectionString();
                LoadSchema();
            }
            catch (System.Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Admin());
        }

        private static void LoadConnectionString()
        {
            //***
            ConnectionString = "Data Source=localhost;Initial Catalog=Contacto;Integrated Security=True";
        }

        private static void LoadSchema()
        {
            using (Contacto.Lib.Context context = ContextManager.CreateContext(true))
            {
                SchemaManager = new Contacto.Lib.SchemaManager(context);
                SchemaManager.LoadSchema();
            }
        }
    }
}