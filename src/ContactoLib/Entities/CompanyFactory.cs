using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace Contacto.Lib
{
    public class CompanyFactory : ObjectBase
    {
        #region Costructors

        public CompanyFactory(Context context)
            : base(context)
        {
        }

        #endregion
        #region Database query functions

        public IEnumerable<Company> FindCompanies(CompanySearchParameters csp)
        {
            try
            {
                LogEntry log = new LogEntry(context, null, LogOperations.FindCompanies);

                SqlCommand cmd = CreateTextCommand();

                string sql = "SELECT Entities.*, Companies.* FROM Entities INNER JOIN Companies ON Companies.GUID = Entities.GUID";
                string where = string.Empty;

                for (int i = 0; i < csp.CategoryTypes.Length; i++)
                {
                    if (csp.CategoryValues[i] != string.Empty)
                    {
                        sql += String.Format(" INNER JOIN Categories cat{0} ON cat{0}.EntityGUID = Entities.GUID AND cat{0}.Type = {1}", i, csp.CategoryTypes[i].Id.ToString());
                        where += String.Format(" AND cat{0}.Text LIKE @cat{0}", i);
                        cmd.Parameters.Add(String.Format("@cat{0}", i), SqlDbType.NVarChar).Value = csp.CategoryValues[i];
                    }
                }


                if (csp.Country != string.Empty || csp.City != string.Empty)
                {
                    sql += " INNER JOIN Addresses ON Addresses.EntityGUID = Entities.GUID AND Addresses.Type = " + ((int)Contacto.Lib.AddressTypes.Primary).ToString();
                }
                if (csp.Country != string.Empty)
                {
                    where += " AND Addresses.Country LIKE @Country";
                    cmd.Parameters.Add("@Country", SqlDbType.NVarChar, 50).Value = csp.Country + "%";
                }
                if (csp.City != string.Empty)
                {
                    where += " AND Addresses.City LIKE @City";
                    cmd.Parameters.Add("@City", SqlDbType.NVarChar, 50).Value = csp.City + "%";
                }

                if (csp.Phone != string.Empty)
                {
                    sql += " INNER JOIN Identifiers Phone ON Phone.EntityGUID = Entities.GUID AND Phone.Type = " + ((int)Contacto.Lib.IdentifierTypes.PrimaryPhone).ToString();
                    where += " AND Phone.Value LIKE @Phone";
                    cmd.Parameters.Add("@Phone", SqlDbType.NVarChar, 50).Value = csp.Phone + "%";
                }
                if (csp.Fax != string.Empty)
                {
                    sql += " INNER JOIN Identifiers Fax ON Fax.EntityGUID = Entities.GUID AND Fax.Type = " + ((int)Contacto.Lib.IdentifierTypes.PrimaryFax).ToString();
                    where += " AND Fax.Value LIKE @Fax";
                    cmd.Parameters.Add("@Fax", SqlDbType.NVarChar, 50).Value = csp.Fax + "%";
                }
                if (csp.Email != string.Empty)
                {
                    sql += " INNER JOIN Identifiers Email ON Email.EntityGUID = Entities.GUID AND Email.Type = " + ((int)Contacto.Lib.IdentifierTypes.PrimaryEmail).ToString();
                    where += " AND Email.Value LIKE @Email";
                    cmd.Parameters.Add("@Email", SqlDbType.NVarChar, 50).Value = csp.Email + "%";
                }
                if (csp.Name != string.Empty)
                {
                    where += " AND Companies.ShortName LIKE @Name";
                    cmd.Parameters.Add("@Name", SqlDbType.NVarChar, 128).Value = csp.Name + "%";
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
            catch (System.Exception ex)
            {
                throw new DBIOException(DBIOMessages.FindCompaniesFailed, ex);
            }
        }

        public IEnumerable<Company> FindDocumentCompanies(Entity entity)
        {
            LogEntry log = new LogEntry(context, entity, LogOperations.FindCompanies);

            try
            {
                using (SqlCommand cmd = CreateStoredProcedureCommand("spQueryDocumentsCompanies_ByEntities"))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@UserGUID", SqlDbType.UniqueIdentifier).Value = context.UserGuid;
                    cmd.Parameters.Add("@EntityGUID", SqlDbType.UniqueIdentifier).Value = entity.Guid;
                    cmd.Parameters.Add("@DateFrom", SqlDbType.DateTime).Value = context.DateLimitFrom;
                    cmd.Parameters.Add("@DateTo", SqlDbType.DateTime).Value = context.DateLimitTo;
                    AppendLimitParameters(cmd);

                    log.WriteOkEntry();

                    return ExecuteCommand(cmd);
                }
            }
            catch (System.Exception ex)
            {
                throw new DBIOException(DBIOMessages.FindCompaniesFailed, ex);
            }
        }

        private IEnumerable<Company> ExecuteCommand(SqlCommand cmd)
        {
            using (SqlDataReader dr = cmd.ExecuteReader())
            {
                while (dr.Read())
                {
                    Company c = new Company(context);
                    c.LoadFromReader(dr);
                    yield return c;
                }

                dr.Close();
                cmd.Dispose();
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
