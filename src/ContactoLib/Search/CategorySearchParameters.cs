using System;
using System.Collections.Generic;
using System.Text;

namespace Contacto.Lib
{
    public abstract class CategorySearchParameters : SearchParameters
    {
        public TypeDescription[] CategoryTypes;
        public string[] CategoryValues;
    }
}
