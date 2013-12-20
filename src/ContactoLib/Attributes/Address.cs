using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace Contacto.Lib
{
    public class Address : Attribute
    {
        #region Member variables

        private string street;
        private string city;
        private string state;
        private string country;
        private string zip;

        #endregion
        #region Properties

        public string Street
        {
            get { return street; }
            set { street = value; }
        }

        public string City
        {
            get { return city; }
            set { city = value; }
        }

        public string State
        {
            get { return state; }
            set { state = value; }
        }

        public string Country
        {
            get { return country; }
            set { country = value; }
        }

        public string Zip
        {
            get { return zip; }
            set { zip = value; }
        }

        public override string DisplayText
        {
            get
            {
                return zip + " " + city + ", " + street;   
            }
        }

        public override TypeDescription TypeDescription
        {
            get
            {
                return context.SchemaManager.GetTypeDescription(parentEntity.EntityType +  EntityTypes.Address, type);
            }
        }

        #endregion
        #region Costructors

        public Address(Entity parentEntity)
            : base(parentEntity)
        {
            InitializeMembers();
        }

        public Address(Entity parentEntity, Context context)
            : base(parentEntity, context)
        {
            InitializeMembers();
        }

        public Address(Address old)
            : base(old)
        {
            CopyMembers(old);
        }

        #endregion
        #region Initializers

        private void InitializeMembers()
        {
            base.entityType = parentEntity.EntityType + EntityTypes.Address;

            this.street = string.Empty;
            this.city = string.Empty;
            this.state = string.Empty;
            this.country = string.Empty;
            this.zip = string.Empty;
        }

        private void CopyMembers(Address old)
        {
            base.entityType = old.entityType;

            this.street = old.street;
            this.city = old.city;
            this.state = old.state;
            this.country = old.country;
            this.zip = old.zip;
        }

        public void LoadFromReader(SqlDataReader dr)
        {
            int o = -1;

            this.guid = dr.GetGuid(++o);
            ++o;
            this.type = dr.GetInt32(++o);
            this.street = dr.GetString(++o);
            this.city = dr.GetString(++o);
            this.state = dr.GetString(++o);
            this.country = dr.GetString(++o);
            this.zip = dr.GetString(++o);
        }

        #endregion
        #region Database IO

        public override void Save(bool forceOverwrite)
        {
            base.Save(forceOverwrite);

            if (!parentEntity.Addresses.Contains(this))
                parentEntity.Addresses.Add(this);
        }

        protected override void Create()
        {
            string sql = "spCreateAddress";

            using (SqlCommand cmd = CreateStoredProcedureCommand(sql))
            {
                AppendCreateModifyCommandParameters(cmd);
                cmd.ExecuteNonQuery();

                parentEntity.UpdateStatistics((int)cmd.Parameters["@Version"].Value, Operations.Modify);
            }
        }

        protected override void Modify()
        {
            string sql = "spModifyAddress";

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
            cmd.Parameters.Add("@Street", SqlDbType.NVarChar, 50).Value = street;
            cmd.Parameters.Add("@City", SqlDbType.NVarChar, 50).Value = city;
            cmd.Parameters.Add("@State", SqlDbType.NVarChar, 50).Value = state;
            cmd.Parameters.Add("@Country", SqlDbType.NVarChar, 50).Value = country;
            cmd.Parameters.Add("@Zip", SqlDbType.NVarChar, 50).Value = zip;
        }

        public override void Load()
        {
            string sql = "spGetAddress";

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
            string sql = "spDeleteAddress";

            using (SqlCommand cmd = CreateStoredProcedureCommand(sql))
            {
                cmd.Parameters.Add("@UserGUID", SqlDbType.UniqueIdentifier).Value = context.UserGuid;
                cmd.Parameters.Add("@GUID", SqlDbType.UniqueIdentifier).Value = guid;
                cmd.Parameters.Add("@Version", SqlDbType.Int).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("@EntityGUID", SqlDbType.UniqueIdentifier).Value = parentEntity.Guid;

                cmd.ExecuteNonQuery();

                parentEntity.UpdateStatistics((int)cmd.Parameters["@Version"].Value, Operations.Modify);
            }

            parentEntity.Addresses.Remove(this);
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
