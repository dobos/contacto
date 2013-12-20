using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace Contacto.Lib
{
    public class Company : Entity
    {
        #region Member variables

        private string shortName;
        private string longName;

        protected List<Person> persons;

        #endregion
        #region Properties

        public CompanyTypes Type
        {
            get { return (CompanyTypes)base.type; }
            set { base.type = (int)value; }
        }

        public string ShortName
        {
            get { return shortName; }
            set { shortName = value; }
        }

        public string LongName
        {
            get { return longName; }
            set { longName = value; }
        }

        public List<Person> Persons
        {
            get { return persons; }
        }

        #endregion
        #region Costructors

        public Company()
            : base()
        {
            InitializeMembers();
        }

        public Company(Context context)
            : base(context)
        {
            InitializeMembers();
        }

        public Company(Company old)
            : base(old)
        {
            CopyMembers(old);
        }

        #endregion
        #region Initializers

        private void InitializeMembers()
        {
            base.entityType = EntityTypes.Company;
            base.type = (int)CompanyTypes.Unknown;
            this.shortName = string.Empty;
            this.longName = string.Empty;

            this.persons = null;
        }

        private void CopyMembers(Company old)
        {
            base.entityType = old.entityType;
            base.type = old.type;
            this.shortName = old.shortName;
            this.longName = old.longName;

            this.persons = old.persons;
        }

        #endregion
        #region Database IO functions

        protected override void Create()
        {
            try
            {
                base.Create();

                string sql = "spCreateCompany";
                using (SqlCommand cmd = CreateStoredProcedureCommand(sql))
                {
                    AppendCreateModifyCommandParameters(cmd);

                    cmd.ExecuteNonQuery();
                }
            }
            catch (System.Exception ex)
            {
                throw new DBIOException(DBIOMessages.CreateCompanyFailed, ex);
            }
        }

        protected override void Modify()
        {
            try
            {
                base.Modify();

                string sql = "spModifyCompany";

                using (SqlCommand cmd = CreateStoredProcedureCommand(sql))
                {
                    AppendCreateModifyCommandParameters(cmd);

                    cmd.ExecuteNonQuery();
                }
            }
            catch (System.Exception ex)
            {
                throw new DBIOException(DBIOMessages.ModifyCompanyFailed, ex);
            }
        }

        private void AppendCreateModifyCommandParameters(SqlCommand cmd)
        {
            cmd.Parameters.Add("@UserGUID", SqlDbType.UniqueIdentifier).Value = context.UserGuid;

            cmd.Parameters.Add("@GUID", SqlDbType.UniqueIdentifier).Value = guid;
            cmd.Parameters.Add("@ShortName", SqlDbType.NVarChar, 50).Value = shortName;
            cmd.Parameters.Add("@LongName", SqlDbType.NVarChar, 250).Value = longName;
        }

        public override void Load()
        {
            try
            {
                LogEntry log = new LogEntry(context, this, LogOperations.LoadCompany);
                string sql = "spGetCompany";

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

                log.WriteOkEntry();
            }
            catch (System.Exception ex)
            {
                throw new DBIOException(DBIOMessages.LoadCompanyFailed, ex);
            }
        }

        internal override int LoadFromReader(SqlDataReader dr)
        {
            base.entityType = EntityTypes.Company;

            int o = base.LoadFromReader(dr);

            ++o;

            if (dr.FieldCount > o)
            {
                this.shortName = dr.GetString(++o);
                this.longName = dr.GetString(++o);
            }

            return o;
        }

        public override void LoadDetails()
        {
            if (!detailsLoaded)
            {
                this.LoadAddresses();
                this.LoadIdentifiers();
                this.LoadCategories();

                detailsLoaded = true;
            }
        }

        public override IEnumerable<Entity> CheckDuplicates()
        {
            LogEntry log = new LogEntry(context, this, LogOperations.CheckCompanyDuplicates);
            SqlDataReader dr = null;

            try
            {

                string sql = "spCheckCompanyDuplicates";

                using (SqlCommand cmd = CreateStoredProcedureCommand(sql))
                {
                    cmd.Parameters.Add("@UserGUID", SqlDbType.UniqueIdentifier).Value = context.UserGuid;
                    cmd.Parameters.Add("@ShortName", SqlDbType.NVarChar, 50).Value = shortName;

                    dr = cmd.ExecuteReader();
                }

                log.WriteOkEntry();
            }
            catch (System.Exception ex)
            {
                throw new DBIOException(DBIOMessages.CheckCompanyDuplicatesFailed, ex);
            }

            if (dr != null)
            {
                while (dr.Read())
                {
                    Company c = new Company(context);
                    c.LoadFromReader(dr);
                    yield return c;
                }

                dr.Close();
                dr.Dispose();

                log.WriteOkEntry();
            }
        }

        #endregion
        #region Formatters

        public override string ToString()
        {
            return DisplayName;
        }

        public override string GetClipboardString()
        {
            LoadDetails();

            string res = string.Empty;

            if (number != "") res += number.ToString() + " - ";
            res += DisplayName + Environment.NewLine;
            res += "Telefon: " + GetIdentifier((int)IdentifierTypes.PrimaryPhone).DisplayText + Environment.NewLine;
            res += "Telefax: " + GetIdentifier((int)IdentifierTypes.PrimaryFax).DisplayText + Environment.NewLine;
            res += "Cím: " + GetAddress((int)AddressTypes.Primary).DisplayText + Environment.NewLine;
            res += "Internet: " + GetIdentifier((int)IdentifierTypes.WebAddress).DisplayText + Environment.NewLine;
            res += "E-mail: " + GetIdentifier((int)IdentifierTypes.PrimaryEmail).DisplayText + Environment.NewLine;

            return res;
        }

        public override string[] GetDisplayTextAlternates()
        {
            return new string[] 
            {
                shortName,
                longName
            };
        }

        #endregion
        #region Person functions

        public void LoadPersons()
        {
            PersonFactory pf = new PersonFactory(context);
            persons = new List<Person>(pf.FindPersons(this));
            foreach (Person p in persons)
                p.LoadDetails();
        }

        public override string GetFieldFormatted(string field)
        {
            string res;

            switch (field)
            {
                case "Name":
                    res = shortName;
                    break;
                case "Category":
                    res = this.GetCategory((int)Contacto.Lib.CategoryTypes.Primary).DisplayText;
                    break;
                case "Industry":
                    res = this.GetCategory((int)Contacto.Lib.CategoryTypes.PrimaryIndustry).DisplayText;
                    break;
                case "Address":
                    res = this.GetAddress((int)Contacto.Lib.AddressTypes.Primary).DisplayText;
                    break;
                case "Phone":
                    res = this.GetIdentifier((int)Contacto.Lib.IdentifierTypes.PrimaryPhone).DisplayText;
                    break;
                case "Fax":
                    res = this.GetIdentifier((int)Contacto.Lib.IdentifierTypes.PrimaryFax).DisplayText;
                    break;
                case "Email":
                    res = this.GetIdentifier((int)Contacto.Lib.IdentifierTypes.PrimaryEmail).DisplayText;
                    break;
                default:
                    res = base.GetFieldFormatted(field);
                    break;
            }

            return res;
        }

        #endregion
    }
}
