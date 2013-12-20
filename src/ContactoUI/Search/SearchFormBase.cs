using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace Contacto.UI
{
    public partial class SearchFormBase : UserControl
    {
        protected EntityListBase list;

        public EntityListBase List
        {
            get { return list; }
        }

        public SearchFormBase()
        {
            InitializeComponent();
        }

        public virtual void Initialize()
        {
            CreateAssociatedList();
        }

        public virtual void Deinitialize()
        {
            DestructAssociatedList();
        }

        public virtual Contacto.Lib.SearchParameters GetSearchParameters()
        {
            throw new NotImplementedException();
        }

        protected virtual void CreateAssociatedList()
        {
            throw new NotImplementedException();
        }

        protected virtual void DestructAssociatedList()
        {
            throw new NotImplementedException();
        }

        public virtual void ExecuteSearch()
        {
            throw new NotImplementedException();
        }
    }
}
