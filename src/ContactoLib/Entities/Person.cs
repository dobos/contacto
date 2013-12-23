using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;

namespace Contacto.Lib
{
    public class Person : Entity
    {
        #region Member variables

        private Genders gender;
        private string preposition;
        private string firstName;
        private string middleName;
        private string lastName;
        private string postposition;

        #endregion
        #region Properties

        public PersonTypes Type
        {
            get { return (PersonTypes)base.type; }
            set { base.type = (int)value; }
        }

        public Genders Gender
        {
            get { return gender; }
            set { gender = value; }
        }

        public string Preposition
        {
            get { return preposition; }
            set { preposition = value; }
        }

        public string FirstName
        {
            get { return firstName; }
            set { firstName = value; }
        }

        public string MiddleName
        {
            get { return middleName; }
            set { middleName = value; }
        }

        public string LastName
        {
            get { return lastName; }
            set { lastName = value; }
        }

        public string Postposition
        {
            get { return postposition; }
            set { postposition = value; }
        }

        #endregion
        #region Costructors

        public Person()
            : base()
        {
            InitializeMembers();
        }

        public Person(Context context)
            : base(context)
        {
            InitializeMembers();
        }

        public Person(Person old)
            : base(old)
        {
            CopyMembers(old);
        }

        #endregion
        #region Initializers

        private void InitializeMembers()
        {
            base.entityType = EntityTypes.Person;
            base.type = (int)PersonTypes.Unknown;
            this.gender = Genders.Male;
            this.preposition = string.Empty;
            this.firstName = string.Empty;
            this.middleName = string.Empty;
            this.lastName = string.Empty;
            this.postposition = string.Empty;
        }

        private void CopyMembers(Person old)
        {
            base.entityType = old.entityType;
            base.type = old.type;
            this.gender = old.gender;
            this.preposition = old.preposition;
            this.firstName = old.firstName;
            this.middleName = old.middleName;
            this.lastName = old.lastName;
            this.postposition = old.postposition;
        }

        #endregion

        public override void NewEntity(Entity parentEntity)
        {
            try
            {
                base.NewEntity(parentEntity);

                if (parentEntity == null)
                {
                }
                else if (parentEntity.GetType() == typeof(Company))
                {
                    Link l = GetLink((int)LinkTypes.PersonCompanyLink);
                    l.PointedEntity = parentEntity;
                }
            }
            catch (System.Exception ex)
            {
                throw new DBIOException(DBIOMessages.NewPersonFailed, ex);
            }
        }

        #region Database IO functions

        protected override void Create()
        {
            try
            {
                base.Create();

                string sql = "spCreatePerson";

                using (SqlCommand cmd = CreateStoredProcedureCommand(sql))
                {
                    AppendCreateModifyCommandParameters(cmd);

                    cmd.ExecuteNonQuery();
                }
            }
            catch (System.Exception ex)
            {
                throw new DBIOException(DBIOMessages.CreatePersonFailed, ex);
            }
        }

        protected override void Modify()
        {
            try
            {
                base.Modify();

                string sql = "spModifyPerson";

                using (SqlCommand cmd = CreateStoredProcedureCommand(sql))
                {
                    AppendCreateModifyCommandParameters(cmd);

                    cmd.ExecuteNonQuery();
                }
            }
            catch (System.Exception ex)
            {
                throw new DBIOException(DBIOMessages.ModifyPersonFailed, ex);
            }
        }

        private void AppendCreateModifyCommandParameters(SqlCommand cmd)
        {
            cmd.Parameters.Add("@UserGUID", SqlDbType.UniqueIdentifier).Value = context.UserGuid;

            cmd.Parameters.Add("@GUID", SqlDbType.UniqueIdentifier).Value = guid;
            cmd.Parameters.Add("@Gender", SqlDbType.Bit).Value = (gender == Genders.Male);
            cmd.Parameters.Add("@Preposition", SqlDbType.NVarChar, 10).Value = preposition;
            cmd.Parameters.Add("@FirstName", SqlDbType.NVarChar, 50).Value = firstName;
            cmd.Parameters.Add("@MiddleName", SqlDbType.NVarChar, 50).Value = middleName;
            cmd.Parameters.Add("@LastName", SqlDbType.NVarChar, 50).Value = lastName;
            cmd.Parameters.Add("@Postposition", SqlDbType.NVarChar, 10).Value = postposition;
        }

        public override void Load()
        {
            try
            {
                LogEntry log = new LogEntry(context, this, LogOperations.LoadPerson);
                string sql = "spGetPerson";

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
                throw new DBIOException(DBIOMessages.LoadPersonFailed, ex);
            }
        }

        internal override int LoadFromReader(SqlDataReader dr)
        {
            base.entityType = EntityTypes.Person;

            int o = base.LoadFromReader(dr);

            ++o;

            if (dr.FieldCount > o)
            {
                this.gender = dr.GetBoolean(++o) ? Genders.Male : Genders.Female;
                this.preposition = dr.GetString(++o);
                this.firstName = dr.GetString(++o);
                this.middleName = dr.GetString(++o);
                this.lastName = dr.GetString(++o);
                this.postposition = dr.GetString(++o);
            }

            return o;
        }

        public override void LoadDetails()
        {
            if (!detailsLoaded)
            {
                this.LoadAddresses();
                this.LoadIdentifiers();
                this.LoadLinks();
                this.LoadCategories();

                detailsLoaded = true;
            }
        }

        public override IEnumerable<Entity> CheckDuplicates()
        {
            LogEntry log = new LogEntry(context, this, LogOperations.CheckPersonDuplicates);
            SqlDataReader dr = null;

            try
            {
                string sql = "spCheckPersonDuplicates";

                using (SqlCommand cmd = CreateStoredProcedureCommand(sql))
                {
                    cmd.Parameters.Add("@UserGUID", SqlDbType.UniqueIdentifier).Value = context.UserGuid;

                    Contacto.Lib.Link l;
                    if ((l = GetLink((int)LinkTypes.PersonCompanyLink)) != null && l.Pointer != Guid.Empty)
                    {
                        cmd.Parameters.Add("@CompanyGUID", SqlDbType.UniqueIdentifier).Value = l.Pointer;
                    }
                    else
                        cmd.Parameters.Add("@CompanyGUID", SqlDbType.UniqueIdentifier).Value = DBNull.Value;
                    cmd.Parameters.Add("@FirstName", SqlDbType.NVarChar, 50).Value = firstName;
                    cmd.Parameters.Add("@LastName", SqlDbType.NVarChar, 50).Value = lastName;

                    dr = cmd.ExecuteReader();
                }

                log.WriteOkEntry();
            }
            catch (System.Exception ex)
            {
                throw new DBIOException(DBIOMessages.CheckPersonDuplicatesFailed, ex);
            }
            if (dr != null)
            {
                while (dr.Read())
                {
                    Person p = new Person(context);
                    p.LoadFromReader(dr);
                    yield return p;
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

            res += DisplayName + Environment.NewLine;
            res += GetCategory((int)CategoryTypes.Primary).DisplayText + Environment.NewLine;

            Entity c = GetLink((int)LinkTypes.PersonCompanyLink).PointedEntity;
            if (c != null)
                res += c.DisplayName + Environment.NewLine;

            res += "Telefon: " + GetIdentifier((int)IdentifierTypes.PrimaryPhone).DisplayText + Environment.NewLine;
            res += "Mobil: " + GetIdentifier((int)IdentifierTypes.PrimaryMobile).DisplayText + Environment.NewLine;
            res += "E-mail: " + GetIdentifier((int)IdentifierTypes.PrimaryEmail).DisplayText + Environment.NewLine;

            return res;
        }

        public static string[] GetPrepositions()
        {
            return new string[]
            {
                "Dr.", "Prof.", "Prof. Dr.", "Ifj.", "Id.",
                "Mr.", "Mrs.", "Ms."
            };
        }

        public static string[] GetPostpositions()
        {
            return new string[]
            {
                "úr", "asszony", "kisasszony"
            };
        }

        public void SetGender()
        {
            if (preposition.StartsWith("Mr") || postposition.StartsWith("úr"))
                gender = Genders.Male;
            else if (preposition.StartsWith("Mrs") || preposition.StartsWith("Ms") ||
                    postposition.StartsWith("assz") || postposition.StartsWith("kisassz"))
                gender = Genders.Female;
        }

        public string GetFormattedName()
        {
            string res = string.Empty;

            if (preposition != string.Empty)
                res += preposition + " ";

            res += (LastName + " " + firstName).Trim();

            if (postposition != string.Empty)
                res += " " + postposition;

            return res.Trim();
        }

        public override string[] GetDisplayTextAlternates()
        {
            return new string[]
            {
                (preposition + " " + lastName + ", " + firstName + (" " + middleName).TrimEnd()).Trim(),
                (preposition + " " + lastName + " " + firstName + (" " + middleName).TrimEnd() + " " + postposition).Trim(),
                (preposition + " " + lastName + ", " + firstName + (" " + middleName).TrimEnd() + " " + postposition).Trim(),
                (preposition + " " + firstName + (" " + middleName).TrimEnd() + " " + lastName + " " + postposition).Trim(),
                lastName + " " + firstName,
                lastName + ", " + firstName,
                firstName + " " + lastName
            };
        }

        public override string GetFieldFormatted(string field, out Color backColor, out Color foreColor)
        {
            string res = base.GetFieldFormatted(field, out backColor, out foreColor);

            switch (field)
            {
                case "Gender":
                    if (gender == Genders.Male)
                        res = "férfi";
                    else
                        res = "nõ";
                    break;
                case "Preposition":
                    res = preposition;
                    break;
                case "FirstName":
                    res = firstName;
                    break;
                case "MiddleName":
                    res = middleName;
                    break;
                case "LastName":
                    res = lastName;
                    break;
                case "Postposition":
                    res = postposition;
                    break;
                case "Company":
                    res = this.GetLink((int)Contacto.Lib.LinkTypes.PersonCompanyLink).DisplayText;
                    break;
                case "Status":
                    res = this.GetFieldCategory((int)Contacto.Lib.CategoryTypes.Primary, out backColor, out foreColor);
                    break;
                case "Phone":
                    res = this.GetIdentifier((int)Contacto.Lib.IdentifierTypes.PrimaryPhone).DisplayText;
                    break;
                case "Mobile":
                    res = this.GetIdentifier((int)Contacto.Lib.IdentifierTypes.PrimaryMobile).DisplayText;
                    break;
                case "Email":
                    res = this.GetIdentifier((int)Contacto.Lib.IdentifierTypes.PrimaryEmail).DisplayText;
                    break;
            }

            return res;
        }

        #endregion
    }
}
