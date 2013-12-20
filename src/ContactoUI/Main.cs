using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Contacto.UI
{
    public partial class Main : Form
    {
        public AsyncOperation AsyncOp;
        public bool IsClosed = false;

        private int waitCursorCounter = 0;

        private ViewForm activeView = null;
        private ViewForm searchView = null;
        private ViewForm view = null;

        private Navigator navigator = null;
        private object acceptButtonCache = null;

        public Navigator Navigator
        {
            get { return navigator; }
        }

        public Main()
        {
            AsyncOp = System.ComponentModel.AsyncOperationManager.CreateOperation(null);

            InitializeComponent();

            DateTime now = DateTime.Now;
            DateLimitFrom.Tag = new DateTime(now.Year - 2, 1, 1);
            DateLimitFrom.Text = new DateTime(now.Year - 2, 1, 1).ToString("d");
            DateLimitTo.Tag = new DateTime(now.Year, 12, 31);
            DateLimitTo.Text = new DateTime(now.Year, 12, 31).ToString("d");


            Program.Settings.MainForm.Apply(this);

            navigator = new Navigator(toolBack, toolForward, toolJump);
            navigator.Click += new Navigator.NavigatorEventHandler(navigator_Click);
        }

        private void Main_Load(object sender, EventArgs e)
        {

            statusUser.Text = ContextManager.User.Username;

            toolStripNavigation.Location = new Point(3, 0);
            toolStrip.Location = new Point(toolStripNavigation.Right, 0);
            toolStripView.Location = new Point(toolStrip.Right, 0);

            // DEBUG CODE
            /*ContactoControls.ToolStripNavigator Navigator =
                new ContactoControls.ToolStripNavigator();

            toolStrip1.Items.Add(Navigator);*/

            //Navigator.Enque(new ContactoControls.Navigator.Item("Elsõ", "1"));
            //Navigator.Enque(new ContactoControls.Navigator.Item("Második", "2"));
            //Navigator.Enque(new ContactoControls.Navigator.Item("Harmadik", "3"));

            //OpenView(ViewTypes.Company, new Guid("ea717b0e-fa45-49a2-8f48-cf7770a99373"));
            //OpenView(ViewTypes.Company);

            //OpenView(ViewTypes.Person, new Guid("C8A4F293-3967-48A2-9A2E-151FD84EB02B"));
            //OpenView(ViewTypes.Person);

            //OpenView(ViewTypes.Document, new Guid("f6777f06-d8dd-4947-a354-1f0b4c5f95c7"));
            //OpenView(ViewTypes.Document);

            //OpenView(ViewTypes.Search);

            //OpenView(ViewTypes.Folder);
            //Contacto.Lib.Folder f = new Contacto.Lib.Folder();
            //f.Guid = new Guid("bf3188f4-8c04-4530-8889-427244c5d0ce");
            //LoadEntity(f, true);
        }

        private void toolStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            if (activeView != null && e.ClickedItem == toolRefresh)
            {
                activeView.Command(Commands.Reload);
            }
            else if (activeView != null && e.ClickedItem == toolUp)
            {
                activeView.Command(Commands.Previous);
            }
            else if (activeView != null && e.ClickedItem == toolDown)
            {
                activeView.Command(Commands.Next);
            }
            else if (activeView != null && e.ClickedItem == toolSave)
            {
                activeView.Command(Commands.Save);
            }
            else if (activeView != null && e.ClickedItem == toolDelete)
            {
                activeView.Command(Commands.Delete);
            }
            else if (activeView != null && e.ClickedItem == toolLock)
            {
                activeView.Command(Commands.Lock);
            }
            else if (activeView != null && e.ClickedItem == toolUnlock)
            {
                activeView.Command(Commands.Unlock);
            }
            else if (e.ClickedItem == toolHome)
            {
                /*
                if (searchView is Home)
                {
                    SwitchView(searchView);
                }
                else
                {
                    if (CloseSearchView())
                        OpenView(ViewTypes.Home);
                }
                 * */
            }
            if (e.ClickedItem == toolBrowser)
            {
                /*
                if (searchView is Browse)
                {
                    if (CloseSearchView())
                        OpenView(ViewTypes.Browse);
                }
                else
                    SwitchView(searchView);
                 * */
            }
            if (e.ClickedItem == toolSearch)
            {
                if (searchView is Search)
                {
                    if (CloseView())
                    {
                        SwitchView(searchView);
                    }
                }
                else if (CloseView() && CloseSearchView())
                    OpenView(ViewTypes.Search);
            }
        }

        public void LoadEntity(Contacto.Lib.Entity entity, bool enqueInNavigator)
        {
            this.SetWaitCursor();

            using (Contacto.Lib.Context context = ContextManager.CreateContext(this, false))
            {
                if (CloseView())
                {
                    ViewTypes vt = GetViewType(entity.EntityType);
                    EntityForm vf = (EntityForm)OpenView(vt);

                    if (vf != null)
                    {
                        if (vf.LoadEntity(entity.Guid))
                        {
                            if (enqueInNavigator)
                                navigator.Enque(entity);
                        }
                        else
                        {
                            CloseView();
                        }
                    }
                }
            }

            this.ResetWaitCursor();
        }

        public void MovePrevious(Contacto.Lib.Entity entity)
        {
            if (searchView != null)
            {
                Contacto.Lib.Entity e = ((ISearchView)searchView).GetPrevious(entity);
                if (e != null)
                    LoadEntity(e, true);
            }
        }

        public void MoveNext(Contacto.Lib.Entity entity)
        {
            if (searchView != null)
            {
                Contacto.Lib.Entity e = ((ISearchView)searchView).GetNext(entity);
                if (e != null)
                    LoadEntity(e, true);
            }
        }

        public void CreateEntity(int entityType)
        {
            CreateEntity(entityType, null, true);
        }

        public void CreateEntity(int entityType, Contacto.Lib.Entity parentEntity, bool enqueInNavigator)
        {
            if (CloseView())
            {
                ViewTypes vt = GetViewType(entityType);
                EntityForm vf = (EntityForm)OpenView(vt);

                if (vf != null)
                {
                    if (vf.CreateEntity(parentEntity))
                    {
                        if (enqueInNavigator)
                            navigator.EnqueDummy();
                    }
                    else
                    {
                        CloseView();
                    }
                }
            }
        }

        public void CreateDocument(Contacto.Lib.Entity parentEntity, Contacto.Lib.Folder folder, Contacto.Lib.DocumentDirections direction, bool enqueInNavigator)
        {
            if (CloseView())
            {
                Document vf = (Document)OpenView(ViewTypes.Document);

                if (vf != null)
                {
                    if (vf.CreateEntity(parentEntity, folder, direction))
                    {
                        if (enqueInNavigator)
                            navigator.EnqueDummy();
                    }
                    else
                    {
                        CloseView();
                    }
                }
            }
        }

        public static ViewTypes GetViewType(int entityType)
        {
            switch (entityType)
            {
                case Contacto.Lib.EntityTypes.Person:
                    return ViewTypes.Person;
                case Contacto.Lib.EntityTypes.Company:
                    return ViewTypes.Company;
                case Contacto.Lib.EntityTypes.Document:
                    return ViewTypes.Document;
                case Contacto.Lib.EntityTypes.Folder:
                    return ViewTypes.Folder;
            }
            return ViewTypes.Search;
        }

        private ViewForm OpenView(ViewTypes type)
        {
            ViewForm newview = null;

            switch (type)
            {
                case ViewTypes.Company:
                    newview = new Company(this);
                    break;
                case ViewTypes.Person:
                    newview = new Person(this);
                    break;
                case ViewTypes.Document:
                    newview = new Document(this);
                    break;
                case ViewTypes.Folder:
                    newview = new Folder(this);
                    break;
                case ViewTypes.Home:
                    if (!(searchView is Home))
                    {
                        newview = new Home(this);
                    }
                    else
                    {
                        newview = searchView;
                    }
                    break;
                case ViewTypes.Browse:
                    if (!(searchView is Browse))
                    {
                        newview = new Browse(this);
                    }
                    else
                    {
                        newview = searchView;
                    }
                    break;
                case ViewTypes.Search:
                    if (!(searchView is Search))
                    {
                        newview = new Search(this);
                    }
                    else
                    {
                        newview = searchView;
                    }
                    break;
            }

            newview.Visible = false;

            // Show new view
            newview.Left = viewPanel.Padding.Left;
            newview.Top = viewPanel.Padding.Right;
            newview.Width = Math.Max(viewPanel.ClientRectangle.Width - viewPanel.Padding.Left - viewPanel.Padding.Right, 0);
            newview.Height = Math.Max(viewPanel.ClientRectangle.Height - viewPanel.Padding.Top - viewPanel.Padding.Bottom, 0);

            newview.Dock = DockStyle.Fill;
            newview.ModifiedChanged += View_ModifiedChanged;
            newview.StatusTextChanged += View_StatusTextChanged;

            viewPanel.Controls.Add(newview);
            newview.PerformLayout();
            newview.Initialize();

            return SwitchView(newview);
        }

        private ViewForm SwitchView(ViewForm newView)
        {
            this.SuspendLayout();

            newView.Visible = true;

            // Update statusbar
            //**
            statusChanged.Text = string.Empty;

            this.ResumeLayout(false);
            this.PerformLayout();

            if (newView is ISearchView)
            {
                searchView = newView;
            }
            else
            {
                view = newView;
            }

            statusLabel.Text = newView.StatusText;
            newView.BringToFront();

            activeView = newView;

            return newView;
        }

        public bool CloseView()
        {
            // Close old view
            if (view != null)
            {
                this.SuspendLayout();
                if (!view.Close())
                {
                    this.ResumeLayout();
                    return false;
                }

                view.Dispose();
                view = null;
            }
            if (searchView != null)
            {
                this.SuspendLayout();
                if (!searchView.Close())
                {
                    this.ResumeLayout();
                    return false;
                }

                searchView.Dispose();
                searchView = null;
            }
            this.ResumeLayout();
            return true;
        }

        public bool CloseSearchView()
        {
            // Close old view
            if (searchView != null)
            {
                this.SuspendLayout();
                if (!searchView.Close())
                {
                    this.ResumeLayout();
                    return false;
                }

                searchView.Dispose();
                searchView = null;
            }
            this.ResumeLayout();
            return true;
        }

        public void TryClose(object e)
        {
            System.Threading.EventWaitHandle eh = (System.Threading.EventWaitHandle)e;

            bool res = CloseView();
            if (res) Close();

            eh.Set();
        }

        private void toolNew_Click(object sender, EventArgs e)
        {
            if (sender == toolNewCompany)
            {
                CreateEntity(Contacto.Lib.EntityTypes.Company);
            }
            else if (sender == toolNewPerson)
            {
                CreateEntity(Contacto.Lib.EntityTypes.Person);
            }
            else if (sender == toolNewDocument)
            {
                CreateEntity(Contacto.Lib.EntityTypes.Document);
            }
            else if (sender == toolNewFolder)
            {
                CreateEntity(Contacto.Lib.EntityTypes.Folder);
            }
        }

        private void View_ModifiedChanged(object sender, EventArgs e)
        {
            if (view == null) return;

            if (view.Modified)
                statusChanged.Text = Messages.Modified;
            else
                statusChanged.Text = string.Empty;
        }

        private void View_StatusTextChanged(object sender, EventArgs e)
        {
            statusLabel.Text = ((ViewForm)sender).StatusText;
        }

        private void navigator_Click(object sender, Navigator.NavigatorEventArgs e)
        {
            if (CloseView())
            {
                EntityForm vf = (EntityForm)OpenView(e.Current.ViewType);
                if (vf != null)
                {
                    if (!vf.LoadEntity(e.Current.Guid))
                    {
                        CloseView();
                    }
                }
            }
            else
            {
                e.Cancel = true;
            }
        }

        private void toolMenu_Click(object sender, EventArgs e)
        {

        }

        private void Main_FormClosed(object sender, FormClosedEventArgs e)
        {
            Program.Settings.MainForm.Match(this);
            IsClosed = true;
            Program.DestructMainWindow(this);
        }

        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = !CloseView();
        }

        private void quickSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Return)
            {
                if (searchView is Search)
                {
                    if (CloseView())
                    {
                        SwitchView(searchView);
                    }
                }
                else if (CloseView() && CloseSearchView())
                    OpenView(ViewTypes.Search);

                Search s = activeView as Search;
                s.entitySearch.query.Text = quickSearch.Text;
                s.tab.SelectedIndex = 0;
                s.RefreshList();
            }
        }

        private void quickSearch_Enter(object sender, EventArgs e)
        {
            acceptButtonCache = AcceptButton;
            AcceptButton = null;
        }

        private void quickSearch_Leave(object sender, EventArgs e)
        {
            if (acceptButtonCache != null)
                AcceptButton = acceptButtonCache as IButtonControl;
        }

        private void menu_Click(object sender, EventArgs e)
        {
            if (sender == menuFileNew)
            {
                Program.CreateMainWindow(null).Show();
            }
            else if (sender == menuFileSave)
            {
                view.Command(Commands.Save);
            }
            else if (sender == menuFileNewItemCompany)
            {
                CreateEntity(Contacto.Lib.EntityTypes.Company);
            }
            else if (sender == menuFileNewItemPerson)
            {
                CreateEntity(Contacto.Lib.EntityTypes.Person);
            }
            else if (sender == menuFileNewItemDocument)
            {
                CreateEntity(Contacto.Lib.EntityTypes.Document);
            }
            else if (sender == menuFileNewItemFolder)
            {
                CreateEntity(Contacto.Lib.EntityTypes.Folder);
            }
            else if (sender == menuFileClose)
            {
                Close();
            }
            else if (sender == menuFileExit)
            {
                Program.EndProgram();
            }
            else if (sender == menuEditCopy)
            {
                view.Command(Commands.Copy);
            }
            else if (sender == menuEditDelete)
            {
                view.Command(Commands.Delete);
            }
            else if (sender == menuHelpAbout)
            {
                (new AboutBox()).ShowDialog();
            }
        }

        private void SelectDate_ButtonClick(object sender, EventArgs e)
        {
            using (DateLimits f = new DateLimits())
            {
                f.DateLimitFrom.Value = (DateTime)this.DateLimitFrom.Tag;
                f.DateLimitTo.Value = (DateTime)this.DateLimitTo.Tag;
                f.ShowClosed.Checked = this.ShowClosed.Checked;
                f.ShowDeleted.Checked = this.ShowDeleted.Checked;
                f.ShowHidden.Checked = this.ShowHidden.Checked;

                if (f.ShowDialog() == DialogResult.OK)
                {
                    this.DateLimitFrom.Tag = f.DateLimitFrom.Value;
                    this.DateLimitFrom.Text = f.DateLimitFrom.Value.ToString("d");
                    this.DateLimitTo.Tag = f.DateLimitTo.Value;
                    this.DateLimitTo.Text = f.DateLimitTo.Value.ToString("d");
                    this.ShowClosed.Checked = f.ShowClosed.Checked;
                    this.ShowDeleted.Checked = f.ShowDeleted.Checked;
                    this.ShowHidden.Checked = f.ShowHidden.Checked;

                    if (view != null) view.Refresh();
                }
            }
        }

        public void SetWaitCursor()
        {
            if (waitCursorCounter == 0)
            {
                this.Cursor = Cursors.WaitCursor;
            }

            waitCursorCounter++;
        }

        public void ResetWaitCursor()
        {
            waitCursorCounter--;

            if (waitCursorCounter == 0)
            {
                this.Cursor = Cursors.Default;
            }
        }

    }
}