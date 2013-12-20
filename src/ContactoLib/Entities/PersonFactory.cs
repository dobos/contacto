using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace Contacto.Lib
{
    public class PersonFactory : ObjectBase
    {
        #region Costructors

        public PersonFactory()
            : base()
        {

        }

        public PersonFactory(Context context)
            : base(context)
        {

        }

        #endregion
        #region Search function

        public IEnumerable<Person> FindPersons(PersonSearchParameters psp)
        {
            try
            {
                LogEntry log = new LogEntry(context, null, LogOperations.FindPersons);

                using (SqlCommand cmd = CreateTextCommand())
                {
                    string sql = "SELECT Entities.*, Persons.* FROM Entities INNER JOIN Persons ON Persons.GUID = Entities.GUID";
                    string where = string.Empty;

                    for (int i = 0; i < psp.CategoryTypes.Length; i++)
                    {
                        if (psp.CategoryValues[i] != string.Empty)
                        {
                            sql += String.Format(" INNER JOIN Categories cat{0} ON cat{0}.EntityGUID = Entities.GUID AND cat{0}.Type = {1}", i, psp.CategoryTypes[i].Id.ToString());
                            where += String.Format(" AND cat{0}.Text LIKE @cat{0}", i);
                            cmd.Parameters.Add(String.Format("@cat{0}", i), SqlDbType.NVarChar).Value = psp.CategoryValues[i];
                        }
                    }

                    if (psp.FirstName != string.Empty)
                    {
                        where += " AND Persons.FirstName LIKE @FirstName";
                        cmd.Parameters.Add("@FirstName", SqlDbType.NVarChar, 128).Value = psp.FirstName + "%";
                    }
                    if (psp.LastName != string.Empty)
                    {
                        where += " AND Persons.LastName LIKE @LastName";
                        cmd.Parameters.Add("@LastName", SqlDbType.NVarChar, 128).Value = psp.LastName + "%";
                    }

                    if (psp.Phone != string.Empty)
                    {
                        sql += " INNER JOIN Identifiers Phone ON Phone.EntityGUID = Entities.GUID AND Phone.Type = " + ((int)Contacto.Lib.IdentifierTypes.PrimaryPhone).ToString();
                        where += " AND Phone.Value LIKE @Phone";
                        cmd.Parameters.Add("@Phone", SqlDbType.NVarChar, 50).Value = psp.Phone + "%";
                    }
                    if (psp.Mobile != string.Empty)
                    {
                        sql += " INNER JOIN Identifiers Mobile ON Mobile.EntityGUID = Entities.GUID AND Mobile.Type = " + ((int)Contacto.Lib.IdentifierTypes.PrimaryMobile).ToString();
                        where += " AND Mobile.Value LIKE @Mobile";
                        cmd.Parameters.Add("@Mobile", SqlDbType.NVarChar, 50).Value = psp.Mobile + "%";
                    }
                    if (psp.Email != string.Empty)
                    {
                        sql += " INNER JOIN Identifiers Email ON Email.EntityGUID = Entities.GUID AND Email.Type = " + ((int)Contacto.Lib.IdentifierTypes.PrimaryEmail).ToString();
                        where += " AND Email.Value LIKE @Email";
                        cmd.Parameters.Add("@Email", SqlDbType.NVarChar, 50).Value = psp.Email + "%";
                    }

                    if (!context.ShowHidden)
                        where += " AND Entities.Hidden = 0";

                    if (!context.ShowDeleted)
                        where += " AND Entities.Deleted = 0";

                    if (!context.ShowClosed)
                        where += " AND Entities.Closed = 0";

                    if (where != string.Empty)
                        sql += " WHERE " + where.Substring(5);

                    cmd.CommandText = sql;

                    log.WriteOkEntry();

                    return ExecuteCommand(cmd);
                }
            }
            catch (System.Exception ex)
            {
                throw new DBIOException(DBIOMessages.FindEntitiesFailed, ex);
            }
        }

        public IEnumerable<Person> FindPersons(Company company)
        {
            LogEntry log = new LogEntry(context, company, LogOperations.LoadPersons);

            try
            {
                using (SqlCommand cmd = CreateStoredProcedureCommand("spQueryCompanyPersons"))
                {
                    cmd.Parameters.Add("@UserGUID", SqlDbType.UniqueIdentifier).Value = context.UserGuid;
                    cmd.Parameters.Add("@CompanyGUID", SqlDbType.UniqueIdentifier).Value = company.Guid;

                    AppendLimitParameters(cmd);

                    log.WriteOkEntry();

                    return ExecuteCommand(cmd);
                }
            }
            catch (System.Exception ex)
            {
                throw new DBIOException(DBIOMessages.LoadPersonsFailed, ex);
            }
        }

        private IEnumerable<Person> ExecuteCommand(SqlCommand cmd)
        {
            using (SqlDataReader dr = cmd.ExecuteReader())
            {
                while (dr.Read())
                {
                    Person p = new Person(context);
                    p.LoadFromReader(dr);
                    yield return p;
                }

                dr.Close();
            }
        }

        private void AppendLimitParameters(SqlCommand cmd)
        {
            cmd.Parameters.Add("@ShowHidden", SqlDbType.Bit).Value = context.ShowHidden;
            cmd.Parameters.Add("@ShowDeleted", SqlDbType.Bit).Value = context.ShowDeleted;
            cmd.Parameters.Add("@ShowClosed", SqlDbType.Bit).Value = context.ShowClosed;
        }

        #endregion
    }
}
