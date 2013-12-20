using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace Contacto.UI
{
    public class Navigator
    {

        public class NavigatorEventArgs : EventArgs
        {
            public bool Cancel = false;
            public NavigatorItem Current;
        }

        public delegate void NavigatorEventHandler(object sender, NavigatorEventArgs e);

        private ToolStripButton back;
        private ToolStripButton forward;
        private ToolStripDropDownButton menu;

        private LinkedList<NavigatorItem> items;
        private LinkedListNode<NavigatorItem> current;

        private bool dummy;

        public event NavigatorEventHandler Click;

        public IEnumerable<NavigatorItem> Items
        {
            get { return items; }
        }

        public NavigatorItem Current
        {
            get { return current.Value; }
            set
            {
                current = items.Find(value);
            }
        }

        public NavigatorItem Previous
        {
            get { return current.Previous.Value; }
        }

        public NavigatorItem Next
        {
            get { return current.Next.Value; }
        }

        public Navigator(ToolStripButton back, ToolStripButton forward, ToolStripDropDownButton menu)
        {
            items = new LinkedList<NavigatorItem>();
            current = null;

            this.back = back;
            this.forward = forward;
            this.menu = menu;

            this.dummy = false;

            this.back.Click += new EventHandler(HandleClick);
            this.forward.Click += new EventHandler(HandleClick);

            RefreshMenu();
        }

        public void Enque(Contacto.Lib.Entity entity)
        {
            using (Contacto.Lib.Context context = ContextManager.CreateContext(null, false))
            {
                ViewTypes vt = Main.GetViewType(entity.EntityType);

                NavigatorItem ni = new NavigatorItem();
                ni.DisplayName = entity.DisplayName + " - " + context.SchemaManager.GetEntityDescription(entity.EntityType);
                ni.Guid = entity.Guid;
                ni.ViewType = vt;

                Enque(ni);
            }
        }

        public void Enque(NavigatorItem item)
        {
            // Delete items after the current
            if (current != null)
            {
                while (current.Next != null)
                {
                    items.RemoveLast();
                }
            }

            items.AddLast(item);
            current = items.Last;
            RefreshMenu();
        }

        public void Deque(Contacto.Lib.Entity entity)
        {
            LinkedListNode<NavigatorItem> ni = items.First;
            LinkedListNode<NavigatorItem> prev = null;
            LinkedListNode<NavigatorItem> next = null;

            while (ni != null)
            {
                if (ni.Value.Guid == entity.Guid)
                {
                    prev = ni.Previous;
                    next = ni.Next;

                    items.Remove(ni);
                    ni = next;
                }
                else
                    ni = ni.Next;
            }

            if (next != null)
                current = next;
            else if (prev != null)
                current = prev;
            else
                current = items.Last;

            RefreshMenu();

            if (current != null)
            {
                NavigatorEventArgs e = new NavigatorEventArgs();
                e.Current = current.Value;
                Click(this, e);
            }
        }

        public void EnqueDummy()
        {
            // Delete items after the current
            if (current != null)
            {
                while (current.Next != null)
                {
                    items.RemoveLast();
                }
            }

            dummy = true;
            current = items.Last;
            RefreshMenu();
        }

        private IEnumerable<NavigatorItem> GetRecentItems(int count)
        {
            if (current == null) yield break;

            LinkedListNode<NavigatorItem> from = current;

            for (int i = 0; i < count; i++)
            {
                if (from.Previous != null)
                    from = from.Previous;
            }

            for (int i = 0; i < 2*count; i ++)
            {
                yield return from.Value;
                from = from.Next;
                if (from == null) break;
            }
        }

        public void RefreshMenu()
        {
            menu.DropDownItems.Clear();

            foreach (NavigatorItem ni in GetRecentItems(5))
            {
                ToolStripMenuItem mi = new ToolStripMenuItem();
                mi.Text = ni.DisplayName;
                mi.Tag = ni;

                if (ni == current.Value)
                {
                    mi.Checked = true;
                }
                else
                {
                    mi.Click += new EventHandler(HandleClick);
                }

                menu.DropDownItems.Add(mi);
            }

            menu.Enabled = (menu.DropDownItems.Count != 0);
            back.Enabled = (current != null && current.Previous != null || dummy && items.Last != null);
            forward.Enabled = (current != null && current.Next != null);
        }

        private void HandleClick(object sender, EventArgs ea)
        {
            NavigatorEventArgs e = new NavigatorEventArgs();
            if (current != null)
            {
                if (sender == back)
                {
                    if (dummy && items.Last != null)
                    {
                        e.Current = items.Last.Value;
                        Click(this, e);

                        if (!e.Cancel)
                        {
                            dummy = false;
                            current = items.Last;
                            RefreshMenu();
                        }
                    }
                    else if (current.Previous != null)
                    {
                        e.Current = current.Previous.Value;
                        Click(this, e);

                        if (!e.Cancel)
                        {
                            current = current.Previous;
                            RefreshMenu();
                        }
                    }
                }
                else if (sender == forward)
                {
                    if (current.Next != null)
                    {
                        e.Current = current.Next.Value;
                        Click(this, e);

                        if (!e.Cancel)
                        {
                            current = current.Next;
                            RefreshMenu();
                        }
                    }
                }
                else
                {
                    ToolStripMenuItem mi = sender as ToolStripMenuItem;
                    if (mi != null)
                    {
                        e.Current = ((NavigatorItem)mi.Tag);
                        Click(this, e);

                        if (!e.Cancel)
                        {
                            current = items.Find(e.Current);
                            RefreshMenu();
                        }
                    }
                }
            }
        }
    }
}
