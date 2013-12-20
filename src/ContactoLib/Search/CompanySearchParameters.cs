using System;
using System.Collections.Generic;
using System.Text;

namespace Contacto.Lib
{
    public class CompanySearchParameters : CategorySearchParameters
    {
        public string Name;

        public string Country;
        public string City;
        public string Phone;
        public string Fax;
        public string Email;
    }
}
