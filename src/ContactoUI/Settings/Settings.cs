using System;
using System.Collections.Generic;
using System.Text;

namespace Contacto.UI
{
    public class Settings
    {
        public string SqlConnectionString;
        public string Username;
        public string TemplatePath;

        public FormSettings MainForm;

        public ListViewSettings CompanyList;
        public ListViewSettings PersonList;
        public ListViewSettings AttributeList;
        public ListViewSettings LinkList;
        public ListViewSettings DateList;
        public ListViewSettings CategoryList;
        public ListViewSettings DocumentList;
        public ListViewSettings BlobList;

        public ListViewSettings SearchEntityList;
        public ListViewSettings SearchCompanyList;
        public ListViewSettings SearchPersonList;
        public ListViewSettings SearchDocumentList;

        public Settings()
        {
            InitializeMembers();
        }

        private void InitializeMembers()
        {
            SqlConnectionString = string.Empty;
            Username = string.Empty;
            TemplatePath = string.Empty;

            MainForm = new FormSettings();
            CompanyList = new ListViewSettings();
            PersonList = new ListViewSettings();
            AttributeList = new ListViewSettings();
            LinkList = new ListViewSettings();
            DateList = new ListViewSettings();
            CategoryList = new ListViewSettings();
            DocumentList = new ListViewSettings();
            BlobList = new ListViewSettings();

            SearchEntityList = new ListViewSettings();
            SearchCompanyList = new ListViewSettings();
            SearchPersonList = new ListViewSettings();
            SearchDocumentList = new ListViewSettings();

        }
    }
}
