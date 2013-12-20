using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace Contacto.UI
{
    public class ListViewSettings
    {
        public List<ColumnSettings> Columns;
        public string SortByColumn;
        public SortOrder SortOrder;

        public ListViewSettings()
        {
            InitializeMembers();
        }

        private void InitializeMembers()
        {
            Columns = null;
            SortByColumn = null;
            SortOrder = SortOrder.None;
        }

        public void Apply(ListView listView)
        {
            if (Columns != null && Columns.Count > 0)
            {
                foreach (ColumnHeader ch in listView.Columns)
                {
                    ColumnSettings c =
                        Columns.Find(delegate(ColumnSettings cs) { return (cs.Tag == (string)ch.Tag); });

                    if (c != null) ch.Width = c.Width;
                }
            }

            //Sort(listView);
        }

        public void Apply(SmartListView listView)
        {
            if (Columns != null && Columns.Count > 0)
            {
                listView.Columns.Clear();

                foreach (ColumnSettings cs in Columns)
                {
                    ColumnHeader ch =
                        listView.headers.Find(delegate(ColumnHeader h) { return (cs.Tag == (string)h.Tag); });

                    if (ch != null && !listView.Columns.Contains(ch))
                    {
                        ch.Width = cs.Width;
                        listView.Columns.Add(ch);
                    }
                }
            }

            Sort(listView);
        }

        private void Sort(SmartListView listView)
        {
            if (SortOrder != SortOrder.None && SortByColumn != null)
            {
                listView.SuspendLayout();

                listView.ListViewItemSorter = new SmartListView.SmartListViewSorter(SortByColumn, SortOrder);
                listView.Sort();

                listView.ResumeLayout();

                listView.SortByColumn = listView.Columns[SortByColumn];
                listView.SortOrder = SortOrder;
            }
        }

        public void Match(ListView listView)
        {
            Columns = new List<ColumnSettings>();

            foreach (ColumnHeader ch in listView.Columns)
            {
                ColumnSettings cs = new ColumnSettings();
                cs.Tag = (string) ch.Tag;
                cs.Width = ch.Width;

                Columns.Add(cs);
            }

            SmartListView.SmartListViewSorter sorter = listView.ListViewItemSorter as SmartListView.SmartListViewSorter;
            if (sorter != null)
            {
                SortByColumn = sorter.SortByColumn;
                SortOrder = sorter.SortOrder;
            }
            else
            {
                SortByColumn = null;
                SortOrder = SortOrder.None;
            }
        }
    }
}
