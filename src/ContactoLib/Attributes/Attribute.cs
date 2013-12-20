using System;
using System.Collections.Generic;
using System.Text;

namespace Contacto.Lib
{
    public abstract class Attribute : ObjectBase
    {

        #region Member variables

        internal Entity parentEntity;
        protected int entityType;

        protected Guid guid;
        protected int type;

        #endregion
        #region Properties

        public Entity ParentEntity
        {
            get { return parentEntity; }
        }

        public Guid Guid
        {
            get { return guid; }
            set { guid = value; }
        }

        public int Type
        {
            get { return type; }
            set { type = value; }
        }

        public virtual TypeDescription TypeDescription
        {
            get { throw new NotImplementedException(); }
        }

        public int EntityType
        {
            get { return entityType; }
            set { entityType = value; }
        }

        public virtual string DisplayText
        {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }

        #endregion
        #region Costructors

        public Attribute(Entity parentEntity)
            : base(parentEntity.Context)
        {
            InitializeMembers();

            this.parentEntity = parentEntity;
        }

        public Attribute(Entity parentEntity, Context context)
            : base(context)
        {
            InitializeMembers();

            this.parentEntity = parentEntity;
        }

        public Attribute(Attribute old)
            : base(old)
        {
            CopyMembers(old);
        }

        #endregion
        #region Initializers

        private void InitializeMembers()
        {
            this.parentEntity = null;

            this.guid = Guid.Empty;
            this.type = 0;
        }

        private void CopyMembers(Attribute old)
        {
            this.parentEntity = old.parentEntity;

            this.guid = old.guid;
            this.type = old.type;
        }

        #endregion
        #region Database IO

        public void Save()
        {
            Save(false);
        }

        public virtual void Save(bool forceOverwrite)
        {
            if (guid == Guid.Empty)
            {
                guid = Guid.NewGuid();
                Create();
            }
            else
            {
                if (!forceOverwrite)
                {
                    if (!CheckVersion())
                    {
                        throw new InvalidVersionException();
                    }
                }
                Modify();
            }
        }

        private bool CheckVersion()
        {
            parentEntity.Context = this.context;
            return parentEntity.CheckVersion();
        }

        protected virtual void Create()
        {
            throw new NotImplementedException();
        }

        protected virtual void Modify()
        {
            throw new NotImplementedException();
        }

        public virtual void Load()
        {
            throw new NotImplementedException();
        }

        public virtual void Delete(bool forceDelete)
        {
            if (!forceDelete)
            {
                if (!CheckVersion())
                {
                    throw new InvalidVersionException();
                }
            }
            Delete();
        }

        protected virtual void Delete()
        {
            throw new NotImplementedException();
        }

        public virtual bool CanModify()
        {
            throw new NotImplementedException();
        }

        public virtual bool CanDelete()
        {
            throw new NotImplementedException();
        }

        #endregion
        #region Formatters

        public virtual string GetClipboardString()
        {
            return string.Empty;
        }

        #endregion
    }
}
