using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace Contacto.UI
{
    public partial class Search : ViewForm, ISearchView
    {
        private EntityListBase list;

        public Search(Main form)
            : base(form)
        {
            InitializeComponent();
            topLabel.Text = "Keresés"; //*****
        }

        public override void Initialize()
        {
            base.Initialize();

            foreach (TabPage t in tab.TabPages)
            {
                ((SearchFormBase)t.Controls[0]).Initialize();
            }

            AttachListView();
        }

        public override bool Close()
        {
            FindForm().AcceptButton = null;

            DetachListView();

            foreach (TabPage t in tab.TabPages)
            {
                ((SearchFormBase)t.Controls[0]).Deinitialize();
            }

            return true;
        }

        private void DetachListView()
        {
            if (list != null)
            {
                this.split.Panel2.Controls.Remove(this.list);
                this.list = null;
            }
        }

        private void AttachListView()
        {
            SuspendLayout();

            DetachListView();

            this.list = ((SearchFormBase)tab.SelectedTab.Controls[0]).List;
            this.Controls.Add(this.list);

            this.list.Size = this.split.Panel2.ClientRectangle.Size;

            this.split.Panel2.Controls.Add(this.list);

            this.list.Dock = System.Windows.Forms.DockStyle.Fill;
            this.list.Location = new System.Drawing.Point(0, 0);
            this.list.Name = "list";
            this.list.TabIndex = 0;

            this.list.CountChanged += new EventHandler(list_CountChanged);

            ResumeLayout();
        }

        /*
        private void CreateListView()
        {
            SuspendLayout();

            /*
            CloseListView();

            if (tab.SelectedTab == tabSimple)
            {
                entityList = new EntityList();
                entityList.ToolStripVisible = false;
                this.Controls.Add(entityList);
                Program.Settings.SearchEntityList.Apply(entityList.listView);

                this.list = entityList;
            }
            else if (tab.SelectedTab == tabCompanies)
            {
                companyList = new CompanyList();
                companyList.ToolStripVisible = false;
                this.Controls.Add(companyList);
                Program.Settings.SearchCompanyList.Apply(companyList.listView);

                this.list = companyList;
            }
            else if (tab.SelectedTab == tabPersons)
            {
                personList = new PersonList();
                personList.ToolStripVisible = false;
                this.Controls.Add(personList);
                Program.Settings.SearchPersonList.Apply(personList.listView);

                this.list = personList;
            }
            else if (tab.SelectedTab == tabDocuments)
            {
                documentList = new DocumentList();
                documentList.ToolStripVisible = false;
                documentList.TreeVisible = false;
                this.Controls.Add(documentList);
                Program.Settings.SearchDocumentList.Apply(documentList.listView);

                this.list = documentList;
            }
             *

            // 
            // listView
            // 

            if (list != null)
            {
                this.list.Size = this.split.Panel2.ClientRectangle.Size;

                this.split.Panel2.Controls.Add(this.list);

                this.list.Dock = System.Windows.Forms.DockStyle.Fill;
                this.list.Location = new System.Drawing.Point(0, 0);
                this.list.Name = "list";
                this.list.TabIndex = 0;

                this.list.CountChanged += new EventHandler(list_CountChanged);
            }

            ResumeLayout();
        }
         * */

        void list_CountChanged(object sender, EventArgs e)
        {
            OnStatusTextChanged();
        }

        public void RefreshList()
        {
            ((Main)FindForm()).SetWaitCursor();
            ok.Enabled = false;

            AttachListView();

            ((SearchFormBase)tab.SelectedTab.Controls[0]).ExecuteSearch();

            OnStatusTextChanged();

            ((Main)FindForm()).ResetWaitCursor();
            ok.Enabled = true;
        }

        public override void Command(Commands command)
        {
            switch (command)
            {
                case Commands.Reload:
                    RefreshList();
                    break;
                default:
                    list.Command(command);
                    break;
            }
        }

        private void ok_Click(object sender, EventArgs e)
        {
            RefreshList();
        }

        private void Search_Load(object sender, EventArgs e)
        {
            Form f = FindForm();
            f.AcceptButton = ok;
        }

        private void tab_SelectedIndexChanged(object sender, EventArgs e)
        {
            //RefreshSearchForms();
        }

        #region ISearchView Members

        public Contacto.Lib.Entity GetPrevious(Contacto.Lib.Entity selected)
        {
            /*
            if (entityList != null)
                return entityList.GetPrevious(selected);
            if (companyList != null)
                return companyList.GetPrevious(selected);
            if (personList != null)
                return personList.GetPrevious(selected);
            if (documentList != null)
                return documentList.GetPrevious(selected);
            else*/

            if (list != null)
                return list.GetPrevious(selected);
            else
                return null;
        }

        public Contacto.Lib.Entity GetNext(Contacto.Lib.Entity selected)
        {
            /*
            if (entityList != null)
                return entityList.GetNext(selected);
            if (companyList != null)
                return companyList.GetNext(selected);
            if (personList != null)
                return personList.GetNext(selected);
            if (documentList != null)
                return documentList.GetNext(selected);
            else*/


            if (list != null)
                return list.GetNext(selected);
            else
                return null;
        }

        #endregion

        public override string StatusText
        {
            get
            {
                if (list != null)
                    return string.Format(Messages.SearchResultCount, ((EntityListBase)list).Count);
                else
                    return string.Empty;
            }
        }
    }
}
