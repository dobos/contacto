using System;
using System.Collections.Generic;
using System.Text;

namespace Contacto.Lib
{
    public class SearchParameters : ObjectBase
    {
        public bool IncludeCompanies;
        public bool IncludePersons;
        public bool IncludeFolders;
        public bool IncludeDocuments;
        public bool IncludeReminders;

        public string GetEntityIdList()
        {
            string res = string.Empty;

            if (IncludeCompanies) res += "," + EntityTypes.Company.ToString();
            if (IncludePersons) res += "," + EntityTypes.Person.ToString();
            if (IncludeFolders) res += "," + EntityTypes.Folder.ToString();
            if (IncludeDocuments) res += "," + EntityTypes.Document.ToString();
            if (IncludeReminders) res += "," + EntityTypes.Reminder.ToString();

            if (res != string.Empty)
                return res.Substring(1);
            else
                return string.Empty;
        }
    }
}
