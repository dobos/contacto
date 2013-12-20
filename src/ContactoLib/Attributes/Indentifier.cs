using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;


namespace Contacto.Lib
{
    public class Identifier : Attribute
    {
        #region Member variables

        private string value;

        #endregion
        #region Properties

        public string Value
        {
            get { return this.value; }
            set { this.value = value; }
        }

        public override string DisplayText
        {
            get
            {
                return value;
            }
        }

        public override TypeDescription TypeDescription
        {
            get
            {
                return context.SchemaManager.GetTypeDescription(parentEntity.EntityType + EntityTypes.Identifier, type);
            }
        }

        #endregion
        #region Costructors

        public Identifier(Entity parentEntity)
            : base(parentEntity)
        {
            InitializeMembers();
        }

        public Identifier(Entity parentEntity, Context context)
            : base(parentEntity, context)
        {
            InitializeMembers();
        }

        public Identifier(Identifier old)
            : base(old)
        {
            CopyMembers(old);
        }

        #endregion
        #region Initializers

        private void InitializeMembers()
        {
            base.entityType = parentEntity.EntityType + EntityTypes.Identifier;

            this.value = string.Empty;
        }

        private void CopyMembers(Identifier old)
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
            this.value = dr.GetString(++o);
        }

        #endregion
        #region Database IO

        public override void Save(bool forceOverwrite)
        {
            base.Save(forceOverwrite);

            if (!parentEntity.Identifiers.Contains(this))
                parentEntity.Identifiers.Add(this);
        }

        protected override void Create()
        {
            string sql = "spCreateIdentifier";

            using (SqlCommand cmd = CreateStoredProcedureCommand(sql))
            {
                AppendCreateModifyCommandParameters(cmd);
                cmd.ExecuteNonQuery();

                parentEntity.UpdateStatistics((int)cmd.Parameters["@Version"].Value, Operations.Modify);
            }
        }

        protected override void Modify()
        {
            string sql = "spModifyIdentifier";

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
            cmd.Parameters.Add("@Value", SqlDbType.NVarChar, 50).Value = value;
        }

        public override void Load()
        {
            string sql = "spGetIdentifier";

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
            string sql = "spDeleteIdentifier";

            using (SqlCommand cmd = CreateStoredProcedureCommand(sql))
            {
                cmd.Parameters.Add("@UserGUID", SqlDbType.UniqueIdentifier).Value = context.UserGuid;
                cmd.Parameters.Add("@GUID", SqlDbType.UniqueIdentifier).Value = guid;
                cmd.Parameters.Add("@Version", SqlDbType.Int).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("@EntityGUID", SqlDbType.UniqueIdentifier).Value = parentEntity.Guid;

                cmd.ExecuteNonQuery();

                parentEntity.UpdateStatistics((int)cmd.Parameters["@Version"].Value, Operations.Modify);
            }

            parentEntity.Identifiers.Remove(this);
        }

        public override bool CanModify()
        {
            return true;
        }

        public override bool CanDelete()
        {
            return !TypeDescription.Required;
        }

        public bool IsPhoneNumber()
        {
            return (type == (int)IdentifierTypes.Fax ||
                type == (int)IdentifierTypes.Mobile ||
                type == (int)IdentifierTypes.Phone ||
                type == (int)IdentifierTypes.PrimaryFax ||
                type == (int)IdentifierTypes.PrimaryMobile ||
                type == (int)IdentifierTypes.PrimaryPhone);
        }

        public bool IsEmailAddress()
        {
            return (type == (int)IdentifierTypes.Email ||
                type == (int)IdentifierTypes.MsnId ||
                type == (int)IdentifierTypes.PrimaryEmail);
        }

        public bool IsWebAddress()
        {
            return (type == (int)IdentifierTypes.WebAddress);
        }

        public bool IsValid()
        {
            string vt = value.Trim();

            if (vt != string.Empty)
            {
                System.Text.RegularExpressions.Regex r = null;

                if (IsPhoneNumber())
                    r = new System.Text.RegularExpressions.Regex(@"\+*([0-9 ])+");
                else if (IsEmailAddress())
                    r = new System.Text.RegularExpressions.Regex(@"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$");
                else if (IsWebAddress())
                {
                    r = new System.Text.RegularExpressions.Regex(@"(http|ftp|https)://([\w-]+\.)+(/[\w- ./?%&=]*)?");
                    if (!r.IsMatch(vt))
                        vt = value = "http://" + vt;
                }

                if (r != null)
                    return r.IsMatch(vt);
            }
            
            return true;
        }

        #endregion
        #region Formatters

        public override string GetClipboardString()
        {
            return DisplayText;
        }

        #endregion

        public void FollowLink(string value)
        {
            if (this.IsEmailAddress() || this.IsWebAddress())
            {
                if (value == null) value = this.value;

                // shell execute
                if (this.IsWebAddress() && !value.StartsWith("http://", StringComparison.OrdinalIgnoreCase))
                {
                    value = "http://" + value;
                }
                if (this.IsEmailAddress())
                {
                    value = "mailto:" + value;
                }
                System.Diagnostics.Process.Start(value);
            }
        }
    }
}
