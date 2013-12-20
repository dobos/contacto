using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Contacto.UI
{
    class Program : ApplicationContext
    {

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        internal static extern bool SetProcessDPIAware();

        public static Settings Settings = new Settings();
        public static Contacto.Lib.Directory Templates = null;
        public static Contacto.Lib.SchemaManager SchemaManager = null;
        public static Contacto.Lib.CheckOutManager CheckoutManager = null;

        public static List<Main> windows;

        public Program()
        {
            //Application.ApplicationExit += new EventHandler(this.OnApplicationExit);

            windows = new List<Main>();

            using (Login l = new Login())
            {
                l.ShowDialog();
            }

            if (SchemaManager == null || !SchemaManager.Loaded)
                return;

            CheckoutManager = new Contacto.Lib.CheckOutManager();
            CheckoutManager.Changed += new EventHandler(CheckoutManager_Changed);

            //WindowClosedEvent = new System.Threading.EventWaitHandle(false, System.Threading.EventResetMode.AutoReset);
            CreateMainWindow(null).Show();
        }

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // for vista screen scaling
            try
            {
                SetProcessDPIAware();
            }
            catch (System.Exception)
            {
            }

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            if (!LoadSettings())
                return;

            Application.Run(new Program());

            /*
            Application.Run(new Login());

            if (SchemaManager == null || !SchemaManager.Loaded)
                return;

            CheckoutManager = new Contacto.Lib.CheckOutManager();
            CheckoutManager.Changed += new EventHandler(CheckoutManager_Changed);

            WindowClosedEvent = new System.Threading.EventWaitHandle(false, System.Threading.EventResetMode.AutoReset);
            OpenMainWindow();

            while (true)
            {
                WindowClosedEvent.WaitOne();

                // unload closed windows
                lock (windows)
                {
                    int i = 0;
                    while (i < windows.Count)
                    {
                        if (windows[i].IsClosed)
                        {
                            windows.RemoveAt(i);
                            continue;
                        }
                        i++;
                    }

                    // if all windows closed program ends
                    if (windows.Count == 0)
                        break;
                }
            }
             * */

            using (Contacto.Lib.Context context = ContextManager.CreateContext(null, true))
            {
                try
                {
                    context.User.Context = context;
                    context.User.Logoff();
                }
                catch (System.Exception ex)
                {
                    SchemaManager = null;

                    Contacto.Lib.LogEntry log = new Contacto.Lib.LogEntry(context, null, Contacto.Lib.LogOperations.UserLogoff);
                    HandleError(context, Messages.ErrorUserLogoff, log, ex);
                }
            }

            // clean up temp directory
            CleanUpTemp();
            CheckoutManager.Cleanup();
            SaveSettings();
        }

        public static void LoginUser()
        {
            ContextManager.User.Login();
            ContextManager.User.LoadDetails();

            ContextManager.Company.Guid = ContextManager.User.GetLink((int)Contacto.Lib.LinkTypes.PersonCompanyLink).Pointer;
            ContextManager.Company.Load();
        }

        public static void LoadSchema()
        {
            using (Contacto.Lib.Context context = ContextManager.CreateContext(null, true))
            {
                try
                {
                    SchemaManager = new Contacto.Lib.SchemaManager(context);
                    SchemaManager.LoadSchema();
                }
                catch (System.Exception ex)
                {
                    SchemaManager = null;

                    Contacto.Lib.LogEntry log = new Contacto.Lib.LogEntry(context, null, Contacto.Lib.LogOperations.LoadSchema);
                    HandleError(context, Messages.ErrorLoadingSchema, log, ex);
                }
            }

            Program.Templates = LoadTemplates(Program.Settings.TemplatePath);
        }

        private static Contacto.Lib.Directory LoadTemplates(string path)
        {
            try
            {
                Contacto.Lib.Directory res = new Contacto.Lib.Directory();
                res.Path = path;

                string[] dirs = System.IO.Directory.GetDirectories(path);
                res.Directories = new Contacto.Lib.Directory[dirs.Length];
                for (int i = 0; i < res.Directories.Length; i++)
                {
                    res.Directories[i] = LoadTemplates(dirs[i]);
                }

                res.Files = System.IO.Directory.GetFiles(path);

                return res;
            }
            catch (System.Exception)
            {
                return null;
            }
        }

        public static void HandleError(Contacto.Lib.Context context, string message, Contacto.Lib.LogEntry log, System.Exception ex)
        {
            //try
            //{
            context.Rollback();

            context.BeginTransaction();
            log.WriteErrorEntry(ex);
            //}
            //finally
            //{
            //MessageBox.Show(message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Stop);
            Error f = new Error();
            f.errorText.Text = string.Format(Messages.ErrorTemplate, message);
            f.errorDetails.Text = ex.ToString();
            f.ShowDialog();
            //}
        }

        /*
        public static void OpenMainWindow()
        {
            OpenMainWindow(null);
        }

        public static void OpenMainWindow(Contacto.Lib.Entity entity)
        {
            System.Threading.Thread t = new System.Threading.Thread(
                new System.Threading.ThreadStart(
                delegate()
                {
                    Main m = new Main();
                    if (entity != null) m.LoadEntity(entity, true);

                    lock (windows)
                    {
                        windows.Add(m);
                    }
                    Application.Run(m);
                }));

            t.Name = "Contacto Windows Thread";
            t.SetApartmentState(System.Threading.ApartmentState.STA);
            t.Start();
        }
         * */

        public static Main CreateMainWindow(Contacto.Lib.Entity entity)
        {
            Main m = new Main();
            if (entity != null) m.LoadEntity(entity, true);

            lock (windows)
            {
                windows.Add(m);
            }
            return m;
        }

        public static void DestructMainWindow(Main m)
        {
            lock (windows)
            {
                windows.Remove(m);

                if (windows.Count == 0)
                    Application.Exit();
            }
        }

        public static void EndProgram()
        {
            lock (windows)
            {
                while (windows.Count > 0)
                {
                    Main m = windows[0];
                    if (!m.IsClosed)
                    {
                        System.Threading.EventWaitHandle e = new System.Threading.EventWaitHandle(false, System.Threading.EventResetMode.ManualReset);
                        m.AsyncOp.Post(new System.Threading.SendOrPostCallback(m.TryClose), e);
                        Application.DoEvents();
                        e.WaitOne();
                        if (!m.IsClosed) break;
                    }
                }
            }
        }

        private static string GetSettingsFile()
        {
            return System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Contacto\\settings.config");
        }

        private static void SaveSettings()
        {
            string filename = GetSettingsFile();
            string dir = System.IO.Path.GetDirectoryName(filename);
            if (!System.IO.Directory.Exists(dir))
                System.IO.Directory.CreateDirectory(dir);

            System.IO.StringWriter sw = new System.IO.StringWriter();

            System.Xml.Serialization.XmlSerializer ser = new System.Xml.Serialization.XmlSerializer(typeof(Settings));
            ser.Serialize(sw, Settings);

            if (sw.ToString().Length != 0)
                System.IO.File.WriteAllText(filename, sw.ToString());
        }

        private static bool LoadSettings()
        {
            string filename = GetSettingsFile();

            if (!System.IO.File.Exists(filename) || new System.IO.FileInfo(filename).Length == 0)
            {
                SettingsForm sf = new SettingsForm();
                if (sf.ShowDialog() == DialogResult.OK)
                {
                    sf.SaveFields(Settings);
                    return true;
                }
                else
                    return false;
            }
            else
            {
                using (System.IO.StreamReader infile = new System.IO.StreamReader(filename))
                {
                    System.Xml.Serialization.XmlSerializer ser = new System.Xml.Serialization.XmlSerializer(typeof(Settings));
                    Settings = (Settings)ser.Deserialize(infile);
                    infile.Close();

                    if (Settings.TemplatePath == null || Settings.TemplatePath == string.Empty)
                    {
                        SettingsForm sf = new SettingsForm();
                        if (sf.ShowDialog() == DialogResult.OK)
                        {
                            sf.SaveFields(Settings);
                            return true;
                        }
                        else
                            return false;
                    }

                    return true;
                }
            }
        }

        private static void CleanUpTemp()
        {
            string tempPath = Contacto.Lib.Util.TempDirName();

            foreach (string file in System.IO.Directory.GetFiles(tempPath))
            {
                try
                {
                    System.IO.File.SetAttributes(file, System.IO.FileAttributes.Normal);
                    System.IO.File.Delete(file);
                }
                catch (System.Exception)
                {
                }
            }
            foreach (string dir in System.IO.Directory.GetDirectories(tempPath))
            {
                try
                {
                    System.IO.Directory.Delete(dir, true);
                }
                catch (System.Exception)
                {
                }
            }

        }

        public static void CheckoutManager_Changed(object sender, EventArgs e)
        {
            Contacto.Lib.Blob blob = (Contacto.Lib.Blob)sender;

            // update blob automatically
            using (Contacto.Lib.Context context = ContextManager.CreateContext(null, true))
            {
                blob.Context = context;
                blob.UpdateData();
            }
        }

    }
}