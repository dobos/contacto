using System;
using System.Collections.Generic;
using System.Text;

namespace Contacto.UI
{
    interface ISearchView
    {
        Contacto.Lib.Entity GetPrevious(Contacto.Lib.Entity selected);
        Contacto.Lib.Entity GetNext(Contacto.Lib.Entity selected);
    }
}
