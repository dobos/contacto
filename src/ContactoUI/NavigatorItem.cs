using System;
using System.Collections.Generic;
using System.Text;

namespace Contacto.UI
{
    public class NavigatorItem
    {
        private ViewTypes viewType;
        private Guid guid;
        private string displayName;

        public ViewTypes ViewType
        {
            get { return viewType; }
            set { viewType = value; }
        }

        public Guid Guid
        {
            get { return guid; }
            set { guid = value; }
        }

        public string DisplayName
        {
            get { return displayName; }
            set { displayName = value; }
        }
    }
}
