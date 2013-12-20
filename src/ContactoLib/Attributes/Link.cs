using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;


namespace Contacto.Lib
{
    public class Link : Attribute
    {
        #region Member variables

        private Guid pointer;
        private Entity pointedEntity;

        #endregion
        #region Properties

        public Guid Pointer
        {
            get { return this.pointer; }
            set { this.pointer = value; }
        }

        public Entity PointedEntity
        {
            get { return pointedEntity; }
            set
            {
                pointedEntity = value;
             
                pointer = (value == null) ? Guid.Empty : pointedEntity.Guid;
            }
        }

        public override TypeDescription TypeDescription
        {
            get
            {
                return context.SchemaManager.GetTypeDescription(parentEntity.EntityType + EntityTypes.Link, type);
            }
        }

        public override string DisplayText
        {
            get
            {
                if (pointedEntity == null)
                    return "(nincs megadva)";
                else
                    return pointedEntity.DisplayName;
            }
        }

        #endregion
        #region Costructors

        public Link(Entity parentEntity)
            : base(parentEntity)
        {
            InitializeMembers();
        }

        public Link(Entity parentEntity, Context context)
            : base(parentEntity, context)
        {
            InitializeMembers();
        }

        public Link(Link old)
            : base(old)
        {
            CopyMembers(old);
        }

        #endregion
        #region Initializers

        private void InitializeMembers()
        {
            base.entityType = parentEntity.EntityType + EntityTypes.Link;

            this.pointer = Guid.Empty;
            this.pointedEntity = null;
        }

        private void CopyMembers(Link old)
        {
            base.entityType = old.entityType;

            this.pointer = old.pointer;
            this.pointedEntity = old.pointedEntity;
        }

        public void LoadFromReader(SqlDataReader dr)
        {
            int o;
            if (dr.IsDBNull(0))
            {
                this.pointedEntity = null;
                o = 22; //***
            }
            else
            {
                this.pointedEntity = new Entity(context);
                o = pointedEntity.LoadFromReader(dr);
            }

            this.guid = dr.GetGuid(++o);
            ++o;
            this.type = dr.GetInt32(++o);
            this.pointer = dr.GetGuid(++o);
        }

        #endregion
        #region Database IO

        public override void Save(bool forceOverwrite)
        {
            base.Save(forceOverwrite);

            if (!parentEntity.Links.Contains(this))
                parentEntity.Links.Add(this);
        }

        protected override void Create()
        {
            string sql = "spCreateLink";

            using (SqlCommand cmd = CreateStoredProcedureCommand(sql))
            {
                AppendCreateModifyCommandParameters(cmd);
                cmd.ExecuteNonQuery();

                parentEntity.UpdateStatistics((int)cmd.Parameters["@Version"].Value, Operations.Modify);
            }

        }

        protected override void Modify()
        {
            string sql = "spModifyLink";

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
            cmd.Parameters.Add("@Pointer", SqlDbType.UniqueIdentifier).Value = pointer;
        }

        public override void Load()
        {
            string sql = "spGetLink";

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
            string sql = "spDeleteLink";

            using (SqlCommand cmd = CreateStoredProcedureCommand(sql))
            {
                cmd.Parameters.Add("@UserGUID", SqlDbType.UniqueIdentifier).Value = context.UserGuid;
                cmd.Parameters.Add("@GUID", SqlDbType.UniqueIdentifier).Value = guid;
                cmd.Parameters.Add("@Version", SqlDbType.Int).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("@EntityGUID", SqlDbType.UniqueIdentifier).Value = parentEntity.Guid;

                cmd.ExecuteNonQuery();

                parentEntity.UpdateStatistics((int)cmd.Parameters["@Version"].Value, Operations.Modify);
            }

            parentEntity.Links.Remove(this);
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
