using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace Contacto.UI
{
    public partial class PropertyList : UserControl
    {
        private Contacto.Lib.Entity parentEntity = null;

        public Contacto.Lib.Entity ParentEntity
        {
            get
            {
                return parentEntity;
            }
            set
            {
                if (parentEntity != value)
                {
                    parentEntity = value;
                    RefreshList();
                }
            }
        }

        public PropertyList()
        {
            InitializeComponent();
        }

        private void RefreshList()
        {
            using (Contacto.Lib.Context context = ContextManager.CreateContext(this, false))
            {
                displayName.Text = parentEntity.DisplayName;
                entityType.Text = context.SchemaManager.GetEntityDescription(parentEntity.EntityType).Description;
                type.Text = ""; //*******
                owner.Text = Contacto.Lib.Util.UserName(context.SchemaManager.GetUser(parentEntity.OwnerGuid));
                system.Checked = parentEntity.System;
                hidden.Checked = parentEntity.Hidden;
                readOnly.Checked = parentEntity.ReadOnly;
                closed.Checked = parentEntity.Closed;
                @internal.Checked = parentEntity.Internal;
                deleted.Checked = parentEntity.Deleted;
                primary.Checked = parentEntity.Primary;
                version.Text = parentEntity.Version.ToString();
                dateCreated.Text = Contacto.Lib.Util.SmartDate(parentEntity.DateCreated);
                dateAccessed.Text = Contacto.Lib.Util.SmartDate(parentEntity.DateAccessed);
                dateModified.Text = Contacto.Lib.Util.SmartDate(parentEntity.DateModified);
                dateDeleted.Text = Contacto.Lib.Util.SmartDate(parentEntity.DateDeleted);
                userCreated.Text = Contacto.Lib.Util.UserName(context.SchemaManager.GetUser(parentEntity.UserCreated));
                userAccessed.Text = Contacto.Lib.Util.UserName(context.SchemaManager.GetUser(parentEntity.UserAccessed));
                userModified.Text = Contacto.Lib.Util.UserName(context.SchemaManager.GetUser(parentEntity.UserModified));
                userDeleted.Text = Contacto.Lib.Util.UserName(context.SchemaManager.GetUser(parentEntity.UserDeleted));
            }
        }
    }
}
