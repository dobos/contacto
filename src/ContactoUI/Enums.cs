using System;
using System.Collections.Generic;
using System.Text;

namespace Contacto.UI
{
    public enum ViewTypes
    {
        Company,
        Person,
        Document,
        Folder,
        Home,
        Browse,
        Search
    }

    public enum AuthenticationMode
    {
        Windows,
        Sql
    }

    public enum Commands
    {
        Save,
        Lock,
        Unlock,
        Cut,
        Copy,
        Paste,
        Delete,
        Reload,
        Previous,
        Next,
    }
}
