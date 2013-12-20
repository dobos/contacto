using System;
using System.Collections.Generic;
using System.Text;

namespace Contacto.Lib
{
    public class DocumentSearchParameters : CategorySearchParameters
    {
        public string Number;
        public string Title;
        public string Subject;

        public string FromCompany;
        public string FromPerson;
        public string ToCompany;
        public string ToPerson;
        public DateTime DateFrom;
        public DateTime DateTo;
        public string Query;
    }
}
