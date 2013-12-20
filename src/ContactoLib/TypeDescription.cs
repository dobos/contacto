using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace Contacto.Lib
{
    public class TypeDescription : ObjectBase
    {
        #region Member variables

        private int id;
        private int entityType;
        private string description;
        private int linkedEntityType;
        private bool system;
        private bool hidden;
        private bool multiple;
        private bool required;
        private bool freetext;

        #endregion
        #region Properties

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public int EntityType
        {
            get { return entityType; }
            set { entityType = value; }
        }

        public string Description
        {
            get { return description; }
            set { description = value; }
        }

        public int LinkedEntityType
        {
            get { return linkedEntityType; }
            set { linkedEntityType = value; }
        }

        public bool System
        {
            get { return system; }
            set { system = value; }
        }

        public bool Hidden
        {
            get { return hidden; }
            set { hidden = value; }
        }

        public bool Multiple
        {
            get { return multiple; }
            set { multiple = value; }
        }

        public bool Required
        {
            get { return required; }
            set { required = value; }
        }

        public bool Freetext
        {
            get { return freetext; }
            set { freetext = value; }
        }

        #endregion
        #region Costructors

        public TypeDescription()
            : base()
        {
            InitializeMembers();
        }

        public TypeDescription(Context context)
            : base(context)
        {
            InitializeMembers();
        }

        public TypeDescription(TypeDescription old)
            : base(old)
        {
            CopyMembers(old);
        }

        #endregion
        #region Initializers

        private void InitializeMembers()
        {
            this.id = 0;
            this.entityType = 0;
            this.description = string.Empty;
            this.linkedEntityType = 0;
            this.system = false;
            this.hidden = false;
            this.multiple = false;
            this.required = false;
            this.freetext = false;
        }

        private void CopyMembers(TypeDescription old)
        {
            this.id = old.id;
            this.entityType = old.entityType;
            this.description = old.description;
            this.linkedEntityType = old.linkedEntityType;
            this.system = old.system;
            this.hidden = old.hidden;
            this.multiple = old.multiple;
            this.required = old.required;
            this.freetext = old.freetext;
        }

        public void LoadFromReader(SqlDataReader dr)
        {
            int o = -1;

            this.id = dr.GetInt32(++o);
            this.entityType = dr.GetInt32(++o);
            this.description = dr.GetString(++o);
            this.linkedEntityType = dr.GetInt32(++o);
            this.system = dr.GetBoolean(++o);
            this.hidden = dr.GetBoolean(++o);
            this.multiple = dr.GetBoolean(++o);
            this.required = dr.GetBoolean(++o);
            this.freetext = dr.GetBoolean(++o);
        }

        #endregion
        #region Database IO functions

        public void Save()
        {
            if (id == 0)
            {
                id = context.SchemaManager.GetNextTypeId(entityType);
                Create();
            }
            else
                Modify();
        }

        public void Create()
        {
            string sql = "spCreateTypeDescription";

            using (SqlCommand cmd = CreateStoredProcedureCommand(sql))
            {
                AppendCreateModifyCommandParameters(cmd);
                cmd.ExecuteNonQuery();
            }
        }

        public void Modify()
        {
            string sql = "spModifyTypeDescription";

            using (SqlCommand cmd = CreateStoredProcedureCommand(sql))
            {
                AppendCreateModifyCommandParameters(cmd);
                cmd.ExecuteNonQuery();
            }
        }

        private void AppendCreateModifyCommandParameters(SqlCommand cmd)
        {
            cmd.Parameters.Add("@UserGUID", SqlDbType.UniqueIdentifier).Value = context.UserGuid;
            cmd.Parameters.Add("@ID", SqlDbType.Int).Value = id;
            cmd.Parameters.Add("@EntityType", SqlDbType.Int).Value = entityType;
            cmd.Parameters.Add("@Description", SqlDbType.NVarChar, 50).Value = description;
            cmd.Parameters.Add("@LinkedEntityType", SqlDbType.Int).Value = linkedEntityType;
            cmd.Parameters.Add("@System", SqlDbType.Bit).Value = system;
            cmd.Parameters.Add("@Hidden", SqlDbType.Bit).Value = hidden;
            cmd.Parameters.Add("@Multiple", SqlDbType.Bit).Value = multiple;
            cmd.Parameters.Add("@Required", SqlDbType.Bit).Value = required;
            cmd.Parameters.Add("@Freetext", SqlDbType.Bit).Value = freetext;
        }

        #endregion
        #region Misc functions

        public override string ToString()
        {
            return this.description;
        }

        #endregion
    }
}
