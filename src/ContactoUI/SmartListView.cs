using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.ComponentModel;

namespace Contacto.UI
{
    public class SmartListView : ListView
    {
        public List<ColumnHeader> headers;
        private ColumnHeader sortByColumn;
        private SortOrder sortOrder;

        private List<object> cache;

        private bool refreshing = false;
        private BackgroundWorker backgroundWorker;
        public delegate ListViewItem ItemCreator(object item);
        public ItemCreator itemCreator;
        public event RunWorkerCompletedEventHandler RefreshListCancelled;
        public event RunWorkerCompletedEventHandler RefreshListCompleted;

        public SmartListView()
            : base()
        {
            InitializeComponent();
        }

        public ColumnHeader SortByColumn
        {
            get { return sortByColumn; }
            set { sortByColumn = value; }
        }

        public SortOrder SortOrder
        {
            get { return sortOrder; }
            set { sortOrder = value; }
        }

        public List<object> Cache
        {
            get { return cache; }
        }

        private void InitializeComponent()
        {
            base.ColumnClick += new ColumnClickEventHandler(ColumnClickHandler);
        }

        public IEnumerable<ColumnHeader> GenerateEntityColumns()
        {
            string[] cols = {"DisplayName", "Number",
                "EntityType",
                "Type",
                "Owner",
                "Version",
                "System",
                "Hidden",
                "ReadOnly",
                "Closed",
                "Internal",
                "Deleted",
                "Primary",
                "DateCreated",
                "DateAccessed",
                "DateModified",
                "DateDeleted",
                "UserCreated",
                "UserAccessed",
                "UserModified",
                "UserDeleted"};

            string[] names = {"Név", "Iktatószám",
                "Elem",
                "Típus",
                "Tulajdonos",
                "Verzió",
                "Rendszer",
                "Rejtett",
                "Csak olvasható",
                "Lezárva",
                "Belsõ",
                "Törölt",
                "Elsõdleges",
                "Létrehozva",
                "Megnyitva",
                "Módosítva",
                "Törölve",
                "Létrehozta",
                "Megnyitotta",
                "Módosította",
                "Törölte"};

            for (int i = 0; i < cols.Length; i++)
            {
                ColumnHeader ch = new ColumnHeader();
                ch.Text = names[i];
                ch.Tag = cols[i];
                ch.Width = 120;
                ch.Name = cols[i];

                yield return ch;
            }
        }

        public void AddEntityColumns()
        {
            foreach (ColumnHeader ch in GenerateEntityColumns())
                Columns.Add(ch);
        }

        public void SaveColumns()
        {
            headers = new List<ColumnHeader>();
            foreach (ColumnHeader ch in Columns)
                headers.Add(ch);
        }

        public void SelectColumns()
        {
            using (ColumnSelector f = new ColumnSelector())
            {
                foreach (ColumnHeader ch in headers)
                {
                    if (!Columns.Contains(ch))
                        f.listAvailable.Items.Add(ch);
                }
                foreach (ColumnHeader ch in Columns)
                {
                    f.listSelected.Items.Add(ch);
                }

                if (f.ShowDialog(this.FindForm()) == DialogResult.OK)
                {
                    base.Items.Clear();
                    Columns.Clear();

                    foreach (ColumnHeader ch in f.listSelected.Items)
                    {
                        Columns.Add(ch);
                    }

                    if (cache != null)
                        RefreshListAsync(cache);
                }
            }
        }

        public void SaveToFile()
        {
            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                sfd.CheckPathExists = true;
                sfd.AddExtension = true;
                sfd.DefaultExt = ".csv";
                sfd.ValidateNames = true;
                sfd.Title = "Lista mentése";    //****
                sfd.Filter = "Vesszõvel tagolt fájl (*.csv)|*.csv"; //|XML fájl (*.xml)|*.xml|HTML oldal (*.htm)|*.htm|Excel munkalap (*.xls)|*.xls|Access adatbázis (*.mdb)|*.mdb";

                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    SaveToFile(sfd.FileName);
                }
            }
        }

        public void SaveToFile(string fileName)
        {
            string format = System.IO.Path.GetExtension(fileName).ToLower();

            switch (format)
            {
                case ".csv":
                    SaveToCsv(fileName);
                    break;
                default:
                    throw new NotImplementedException();
            }
        }

        private void SaveToCsv(string fileName)
        {
            using (System.IO.StreamWriter outfile = new System.IO.StreamWriter(fileName, false, Encoding.Default))
            {
                // write headers
                outfile.Write("#");
                int q = 0;
                foreach (ColumnHeader ch in Columns)
                {
                    if (q != 0) outfile.Write(";");     //******
                    outfile.Write("{0}", ch.Text.Replace("\"", "\"\"").Replace(";", ","));
                    q++;
                }
                outfile.WriteLine();

                // write data
                foreach (ListViewItem li in Items)
                {
                    for (int i = 0; i < Columns.Count; i++)
                    {
                        string t;

                        if (i > 0)
                        {
                            outfile.Write(System.Threading.Thread.CurrentThread.CurrentCulture.TextInfo.ListSeparator);
                        }

                        t = li.SubItems[i].Text;
                        outfile.Write("{0}", t.Replace("\"", "\"\"").Replace(System.Threading.Thread.CurrentThread.CurrentCulture.TextInfo.ListSeparator, " "));
                    }
                    outfile.WriteLine();
                }
            }
        }

        private void ColumnClickHandler(object sender, ColumnClickEventArgs e)
        {
            base.SuspendLayout();
            if (sortByColumn == base.Columns[e.Column])
            {
                if (sortOrder == SortOrder.Ascending)
                    sortOrder = SortOrder.Descending;
                else
                    sortOrder = SortOrder.Ascending;
            }
            else
            {
                sortByColumn = base.Columns[e.Column];
                sortOrder = SortOrder.Ascending;
            }
            base.ListViewItemSorter = new SmartListViewSorter((string)sortByColumn.Tag, sortOrder);
            base.Sort();
            base.ResumeLayout();
        }

        public class SmartListViewSorter : System.Collections.IComparer
        {
            private string sortByColumn;
            private SortOrder sortOrder;

            public SmartListViewSorter(string column, SortOrder order)
            {
                this.sortByColumn = column;
                this.sortOrder = order;
            }

            public string SortByColumn
            {
                get { return sortByColumn; }
                set { sortByColumn = value; }
            }

            public SortOrder SortOrder
            {
                get { return sortOrder; }
                set { sortOrder = value; }
            }

            #region IComparer Members

            public int Compare(object x, object y)
            {
                if (sortOrder == SortOrder.Ascending)
                    return string.Compare(
                        ((Contacto.Lib.Entity)((ListViewItem)x).Tag).GetFieldFormatted(sortByColumn),
                        ((Contacto.Lib.Entity)((ListViewItem)y).Tag).GetFieldFormatted(sortByColumn),
                        true);
                else
                    return string.Compare(
                        ((Contacto.Lib.Entity)((ListViewItem)y).Tag).GetFieldFormatted(sortByColumn),
                        ((Contacto.Lib.Entity)((ListViewItem)x).Tag).GetFieldFormatted(sortByColumn),
                        true);
            }

            #endregion
        }

        public void RefreshListCancelAsync()
        {
            if (backgroundWorker != null)
                backgroundWorker.CancelAsync();
        }

        public void RefreshListAsync(System.Collections.IEnumerable items)
        {
            if (refreshing) return;
            refreshing = true;

            base.Items.Clear();

            List<object> newcache = new List<object>();

            backgroundWorker = new BackgroundWorker();

            backgroundWorker.DoWork += new DoWorkEventHandler(
                delegate(object sender, DoWorkEventArgs e)
                {
                    BackgroundWorker worker = sender as BackgroundWorker;

                    int q = 0;
                    List<ListViewItem> buffer = new List<ListViewItem>();
                    foreach (object item in items)
                    {
                        newcache.Add(item);

                        buffer.Add(itemCreator(item));
                        q++;

                        if (q % 100 == 0)
                        {
                            worker.ReportProgress(0, buffer.ToArray());
                            buffer.Clear();
                            if (worker.CancellationPending)
                            {
                                e.Cancel = true;
                                break;
                            }
                        }
                    }
                    if (buffer.Count != 0)
                        worker.ReportProgress(0, buffer.ToArray());
                }
                );

            backgroundWorker.ProgressChanged += new ProgressChangedEventHandler(
                delegate(object sender, ProgressChangedEventArgs e)
                {
                    base.Items.AddRange((ListViewItem[])e.UserState);
                    base.Update();
                    // **** causes stack overflow! remove!
                    //Application.DoEvents();
                });


            backgroundWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(
                delegate(object sender, RunWorkerCompletedEventArgs e)
                {
                    cache = newcache;
                    refreshing = false;

                    if (e.Cancelled)
                    {
                        if (RefreshListCancelled != null)
                            RefreshListCancelled(this, e);
                    }

                    if (RefreshListCompleted != null)
                        RefreshListCompleted(this, e);
                });

            backgroundWorker.WorkerReportsProgress = true;
            backgroundWorker.WorkerSupportsCancellation = true;

            backgroundWorker.RunWorkerAsync();
        }

    }
}
