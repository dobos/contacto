using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;


namespace Contacto.Lib
{
    public class Category : Attribute
    {
        #region Member variables

        private int value;
        private string text;

        #endregion
        #region Properties

        public int Value
        {
            get { return this.value; }
            set { this.value = value; }
        }

        public string Text
        {
            get { return this.text; }
            set { this.text = value; }
        }

        public override string DisplayText
        {
            get
            {
                return text;
            }
        }

        public override TypeDescription TypeDescription
        {
            get
            {
                return context.SchemaManager.GetTypeDescription(parentEntity.EntityType + EntityTypes.Category, type);
            }
        }

        #endregion
        #region Costructors

        public Category(Entity parentEntity)
            : base(parentEntity)
        {
            InitializeMembers();
        }

        public Category(Entity parentEntity, Context context)
            : base(parentEntity, context)
        {
            InitializeMembers();
        }

        public Category(Category old)
            : base(old)
        {
            CopyMembers(old);
        }

        #endregion
        #region Initializers

        private void InitializeMembers()
        {
            base.entityType = parentEntity.EntityType + EntityTypes.Category;

            this.value = 0;
            this.text = string.Empty;
        }

        private void CopyMembers(Category old)
        {
            base.entityType = old.entityType;

            this.value = old.value;
            this.text = old.text;
        }

        public void LoadFromReader(SqlDataReader dr)
        {
            int o = -1;

            this.guid = dr.GetGuid(++o);
            ++o;
            this.type = dr.GetInt32(++o);
            this.value = dr.GetInt32(++o);
            this.text = dr.GetString(++o);
        }

        #endregion
        #region Database IO

        public override void Save(bool forceOverwrite)
        {
            base.Save(forceOverwrite);

            if (!parentEntity.Categories.Contains(this))
                parentEntity.Categories.Add(this);
        }

        protected override void Create()
        {
            string sql = "spCreateCategory";

            using (SqlCommand cmd = CreateStoredProcedureCommand(sql))
            {
                AppendCreateModifyCommandParameters(cmd);
                cmd.ExecuteNonQuery();

                parentEntity.UpdateStatistics((int)cmd.Parameters["@Version"].Value, Operations.Modify);
            }
        }

        protected override void Modify()
        {
            string sql = "spModifyCategory";

            using (SqlCommand cmd = CreateStoredProcedureCommand(sql))
            {
                AppendCreateModifyCommandParameters(cmd);
                cmd.ExecuteNonQuery();

                parentEntity.UpdateStatistics((int)cmd.Parameters["@Version"].Value, Operations.Modify);
            }
        }

        private void AppendCreateModifyCommandParameters(SqlCommand cmd)
        {
            cmd.Parameters.Add("@UserGUID", SqlDbType.UniqueIdentifier).Value = context.UserGuid;
            cmd.Parameters.Add("@GUID", SqlDbType.UniqueIdentifier).Value = guid;
            cmd.Parameters.Add("@Version", SqlDbType.Int).Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@EntityGUID", SqlDbType.UniqueIdentifier).Value = ParentEntity.Guid;
            cmd.Parameters.Add("@Type", SqlDbType.Int).Value = type;
            cmd.Parameters.Add("@Value", SqlDbType.Int).Value = value;
            cmd.Parameters.Add("@Text", SqlDbType.NVarChar, 50).Value = text;
        }

        public override void Load()
        {
            string sql = "spGetCategory";

            using (SqlCommand cmd = CreateStoredProcedureCommand(sql))
            {
                cmd.Parameters.Add("@UserGUID", SqlDbType.UniqueIdentifier).Value = context.UserGuid;
                cmd.Parameters.Add("@GUID", SqlDbType.UniqueIdentifier).Value = guid;

                using (SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.SingleRow))
                {
                    dr.Read();
                    LoadFromReader(dr);
                    dr.Close();
                }
            }
        }

        protected override void Delete()
        {
            string sql = "spDeleteCategory";

            using (SqlCommand cmd = CreateStoredProcedureCommand(sql))
            {
                cmd.Parameters.Add("@UserGUID", SqlDbType.UniqueIdentifier).Value = context.UserGuid;
                cmd.Parameters.Add("@GUID", SqlDbType.UniqueIdentifier).Value = guid;
                cmd.Parameters.Add("@Version", SqlDbType.Int).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("@EntityGUID", SqlDbType.UniqueIdentifier).Value = parentEntity.Guid;

                cmd.ExecuteNonQuery();

                parentEntity.UpdateStatistics((int)cmd.Parameters["@Version"].Value, Operations.Modify);
            }

            parentEntity.Categories.Remove(this);
        }

        public override bool CanModify()
        {
            return true;
        }

        public override bool CanDelete()
        {
            return !TypeDescription.Required;
        }

        #endregion
        #region Formatters

        public override string GetClipboardString()
        {
            return DisplayText;
        }

        #endregion
    }
}
