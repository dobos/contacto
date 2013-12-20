using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace Contacto.Lib
{
    public class CategoryDescription : ObjectBase
    {
        #region Member variables

        private int id;
        private int entityType;
        private int type;
        private string description;

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

        public int Type
        {
            get { return type; }
            set { type = value; }
        }

        public string Description
        {
            get { return description; }
            set { description = value; }
        }

        #endregion
        #region Costructors

        public CategoryDescription()
            : base()
        {
            InitializeMembers();
        }

        public CategoryDescription(Context context)
            : base(context)
        {
            InitializeMembers();
        }

        public CategoryDescription(CategoryDescription old)
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
            this.type = 0;
            this.description = string.Empty;
        }

        private void CopyMembers(CategoryDescription old)
        {
            this.id = old.id;
            this.entityType = old.entityType;
            this.type = old.type;
            this.description = old.description;
        }

        public void LoadFromReader(SqlDataReader dr)
        {
            int o = -1;

            this.id = dr.GetInt32(++o);
            this.entityType = dr.GetInt32(++o);
            this.type = dr.GetInt32(++o);
            this.description = dr.GetString(++o);
        }

        #endregion
        #region Database IO functions

        public void Save()
        {
            if (id == 0)
            {
                id = context.SchemaManager.GetNextCategoryDescriptionId(entityType, type);
                Create();
            }
            else
                Modify(false);
        }

        public void Create()
        {
            string sql = "spCreateCategoryDescription";

            using (SqlCommand cmd = CreateStoredProcedureCommand(sql))
            {
                AppendCreateModifyCommandParameters(cmd);
                cmd.ExecuteNonQuery();
            }
        }

        public void Modify(bool withUpdate)
        {
            string sql = "spModifyCategoryDescription";

            using (SqlCommand cmd = CreateStoredProcedureCommand(sql))
            {
                AppendCreateModifyCommandParameters(cmd);
                cmd.ExecuteNonQuery();
            }

            if (withUpdate)
            {
                sql = "spModifyCategoryDescription_WithUpdate";

                using (SqlCommand cmd = CreateStoredProcedureCommand(sql))
                {
                    AppendCreateModifyCommandParameters(cmd);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        private void AppendCreateModifyCommandParameters(SqlCommand cmd)
        {
            cmd.Parameters.Add("@UserGUID", SqlDbType.UniqueIdentifier).Value = context.UserGuid;
            cmd.Parameters.Add("@ID", SqlDbType.Int).Value = id;
            cmd.Parameters.Add("@EntityType", SqlDbType.Int).Value = entityType;
            cmd.Parameters.Add("@Type", SqlDbType.Int).Value = type;
            cmd.Parameters.Add("@Description", SqlDbType.NVarChar, 50).Value = description;
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
