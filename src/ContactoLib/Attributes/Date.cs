using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;


namespace Contacto.Lib
{
    public class Date : Attribute
    {
        #region Member variables

        private DateTime value;

        #endregion
        #region Properties

        public DateTime Value
        {
            get { return this.value; }
            set { this.value = value; }
        }

        public override string DisplayText
        {
            get
            {
                if (value == DateTime.MinValue)
                    return "(nincs beállítva)";
                else
                    return value.ToString();
            }
        }

        public override TypeDescription TypeDescription
        {
            get
            {
                return context.SchemaManager.GetTypeDescription(parentEntity.EntityType + EntityTypes.Date, type);
            }
        }

        #endregion
        #region Costructors

        public Date(Entity parentEntity)
            : base(parentEntity)
        {
            InitializeMembers();
        }

        public Date(Entity parentEntity, Context context)
            : base(parentEntity, context)
        {
            InitializeMembers();
        }

        public Date(Date old)
            : base(old)
        {
            CopyMembers(old);
        }

        #endregion
        #region Initializers

        private void InitializeMembers()
        {
            base.entityType = parentEntity.EntityType + EntityTypes.Date;

            this.value = DateTime.MinValue;
        }

        private void CopyMembers(Date old)
        {
            base.entityType = old.entityType;

            this.value = old.value;
        }

        public void LoadFromReader(SqlDataReader dr)
        {
            int o = -1;

            this.guid = dr.GetGuid(++o);
            ++o;
            this.type = dr.GetInt32(++o);
            this.value = dr.GetDateTime(++o);
        }

        #endregion
        #region Database IO

        public override void Save(bool forceOverwrite)
        {
            base.Save(forceOverwrite);

            if (!parentEntity.Dates.Contains(this))
                parentEntity.Dates.Add(this);
        }

        protected override void Create()
        {
            string sql = "spCreateDate";

            using (SqlCommand cmd = CreateStoredProcedureCommand(sql))
            {
                AppendCreateModifyCommandParameters(cmd);
                cmd.ExecuteNonQuery();

                parentEntity.UpdateStatistics((int)cmd.Parameters["@Version"].Value, Operations.Modify);
            }
        }

        protected override void Modify()
        {
            string sql = "spModifyDate";

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
            cmd.Parameters.Add("@Value", SqlDbType.DateTime).Value = value;
        }

        public override void Load()
        {
            string sql = "spGetDate";

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
            string sql = "spDeleteDate";

            using (SqlCommand cmd = CreateStoredProcedureCommand(sql))
            {
                cmd.Parameters.Add("@UserGUID", SqlDbType.UniqueIdentifier).Value = context.UserGuid;
                cmd.Parameters.Add("@GUID", SqlDbType.UniqueIdentifier).Value = guid;
                cmd.Parameters.Add("@Version", SqlDbType.Int).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("@EntityGUID", SqlDbType.UniqueIdentifier).Value = parentEntity.Guid;

                cmd.ExecuteNonQuery();

                parentEntity.UpdateStatistics((int)cmd.Parameters["@Version"].Value, Operations.Modify);
            }

            parentEntity.Dates.Remove(this);
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
