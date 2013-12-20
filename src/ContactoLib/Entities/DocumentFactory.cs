using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace Contacto.Lib
{
    public class DocumentFactory : ObjectBase
    {
        #region Costructors

        public DocumentFactory(Context context)
            : base(context)
        {
        }

        #endregion
        #region Database query functions

        public IEnumerable<Document> FindDocuments(DocumentSearchParameters dsp)
        {
            try
            {
                LogEntry log = new LogEntry(context, null, LogOperations.FindDocuments);

                using (SqlCommand cmd = CreateTextCommand())
                {
                    string sql = "SELECT Entities.*, Documents.* FROM Entities INNER JOIN Documents ON Entities.GUID = Documents.GUID";
                    string where = string.Empty;

                    for (int i = 0; i < dsp.CategoryTypes.Length; i++)
                    {
                        if (dsp.CategoryValues[i] != string.Empty)
                        {
                            sql += String.Format(" INNER JOIN Categories cat{0} ON cat{0}.EntityGUID = Entities.GUID AND cat{0}.Type = {1}", i, dsp.CategoryTypes[i].Id.ToString());
                            where += String.Format(" AND cat{0}.Text LIKE @cat{0}", i);
                            cmd.Parameters.Add(String.Format("@cat{0}", i), SqlDbType.NVarChar).Value = dsp.CategoryValues[i];
                        }
                    }
                    
                    if (dsp.Number != string.Empty)
                    {
                        where += " AND Entities.Number LIKE @Number";
                        cmd.Parameters.Add("@Number", SqlDbType.NVarChar, 20).Value = dsp.Number + "%";
                    }
                    if (dsp.Title != string.Empty)
                    {
                        where += " AND Documents.Title LIKE @Title";
                        cmd.Parameters.Add("@Title", SqlDbType.NVarChar, 50).Value = "%" + dsp.Title + "%";
                    }
                    if (dsp.Subject != string.Empty)
                    {
                        where += " AND Documents.Subject LIKE @Subject";
                        cmd.Parameters.Add("@Subject", SqlDbType.NVarChar, 50).Value = "%" + dsp.Subject + "%";
                    }
                    if (dsp.FromCompany != string.Empty)
                    {
                        sql += " INNER JOIN Links FromCompanyLinks ON FromCompanyLinks.EntityGUID = Entities.GUID AND FromCompanyLinks.Type = " + ((int)Contacto.Lib.LinkTypes.DocumentFromCompanyLink).ToString();
                        sql += " INNER JOIN Entities FromCompany ON FromCompany.GUID = FromCompanyLinks.Pointer";
                        where += " AND FromCompany.DisplayName LIKE @FromCompany";
                        cmd.Parameters.Add("@FromCompany", SqlDbType.NVarChar, 50).Value = dsp.FromCompany + "%";
                    }
                    if (dsp.FromPerson != string.Empty)
                    {
                        sql += " INNER JOIN Links FromPersonLinks ON FromPersonLinks.EntityGUID = Entities.GUID AND FromPersonLinks.Type = " + ((int)Contacto.Lib.LinkTypes.DocumentFromPersonLink).ToString();
                        sql += " INNER JOIN Entities FromPerson ON FromPerson.GUID = FromPersonLinks.Pointer";
                        where += " AND FromPerson.DisplayName LIKE @FromPerson";
                        cmd.Parameters.Add("@FromPerson", SqlDbType.NVarChar, 50).Value = "%" + dsp.FromPerson + "%";
                    }
                    if (dsp.ToCompany != string.Empty)
                    {
                        sql += " INNER JOIN Links ToCompanyLinks ON ToCompanyLinks.EntityGUID = Entities.GUID AND ToCompanyLinks.Type = " + ((int)Contacto.Lib.LinkTypes.DocumentToCompanyLink).ToString();
                        sql += " INNER JOIN Entities ToCompany ON ToCompany.GUID = ToCompanyLinks.Pointer";
                        where += " AND ToCompany.DisplayName LIKE @ToCompany";
                        cmd.Parameters.Add("@ToCompany", SqlDbType.NVarChar, 50).Value = dsp.ToCompany + "%";
                    }
                    if (dsp.ToPerson != string.Empty)
                    {
                        sql += " INNER JOIN Links ToPersonLinks ON ToPersonLinks.EntityGUID = Entities.GUID AND ToPersonLinks.Type = " + ((int)Contacto.Lib.LinkTypes.DocumentToPersonLink).ToString();
                        sql += " INNER JOIN Entities ToPerson ON ToPerson.GUID = ToPersonLinks.Pointer";
                        where += " AND ToPerson.DisplayName LIKE @ToPerson";
                        cmd.Parameters.Add("@ToPerson", SqlDbType.NVarChar, 50).Value = "%" + dsp.ToPerson + "%";
                    }
                    
                    // dates
                    sql += " INNER JOIN Dates ON Dates.EntityGUID = Entities.GUID AND Dates.Type = " + ((int)Contacto.Lib.DateTypes.Primary).ToString();
                    where += " AND Dates.Value BETWEEN @DateFrom AND @DateTo";
                    cmd.Parameters.Add("@DateFrom", SqlDbType.DateTime).Value = dsp.DateFrom;
                    cmd.Parameters.Add("@DateTo", SqlDbType.DateTime).Value = dsp.DateTo;
                    
                    if (dsp.Query != string.Empty)
                    {
                        sql += " INNER JOIN Links BlobLinks ON BlobLinks.Pointer = Entities.GUID";
                        sql += " INNER JOIN (SELECT GUID FROM Blobs WHERE CONTAINS(*, @Query)) Blobs ON Blobs.GUID = BlobLinks.EntityGUID";
                        cmd.Parameters.Add("@Query", SqlDbType.NVarChar, 50).Value = dsp.Query;
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
                throw new DBIOException(DBIOMessages.FindCompaniesFailed, ex);
            }
        }

        public IEnumerable<Document> FindDocuments(Entity entity)
        {
            LogEntry log = new LogEntry(context, null, LogOperations.FindDocuments);

            try
            {
                using (SqlCommand cmd = CreateStoredProcedureCommand("spQueryDocuments_ByEntity"))
                {
                    cmd.Parameters.Add("@UserGUID", SqlDbType.UniqueIdentifier).Value = context.UserGuid;
                    cmd.Parameters.Add("@EntityGUID", SqlDbType.UniqueIdentifier).Value = entity.Guid;
                    AppendLimitParameters(cmd);

                    log.WriteOkEntry();

                    return ExecuteCommand(cmd);
                }

            }
            catch (System.Exception ex)
            {
                throw new DBIOException(DBIOMessages.FindDocumentsFailed, ex);
            }
        }

        public IEnumerable<Document> FindDocuments(Entity entity, Company company)
        {
            LogEntry log = new LogEntry(context, null, LogOperations.FindDocuments);

            try
            {
                using (SqlCommand cmd = CreateStoredProcedureCommand("spQueryDocuments_ByEntityAndCompany"))
                {
                    cmd.Parameters.Add("@UserGUID", SqlDbType.UniqueIdentifier).Value = context.UserGuid;
                    cmd.Parameters.Add("@EntityGUID", SqlDbType.UniqueIdentifier).Value = entity.Guid;
                    cmd.Parameters.Add("@CompanyGUID", SqlDbType.UniqueIdentifier).Value = company.Guid;
                    AppendLimitParameters(cmd);

                    log.WriteOkEntry();

                    return ExecuteCommand(cmd);
                }
            }
            catch (System.Exception ex)
            {
                throw new DBIOException(DBIOMessages.FindDocumentsFailed, ex);
            }
        }

        public IEnumerable<Document> FindDocuments(Entity entity, Folder folder)
        {
            LogEntry log = new LogEntry(context, null, LogOperations.FindDocuments);

            try
            {
                using (SqlCommand cmd = CreateStoredProcedureCommand("spQueryDocuments_ByEntityAndFolder"))
                {
                    cmd.Parameters.Add("@UserGUID", SqlDbType.UniqueIdentifier).Value = context.UserGuid;
                    cmd.Parameters.Add("@EntityGUID", SqlDbType.UniqueIdentifier).Value = entity.Guid;
                    cmd.Parameters.Add("@FolderGUID", SqlDbType.UniqueIdentifier).Value = folder.Guid;
                    AppendLimitParameters(cmd);

                    log.WriteOkEntry();

                    return ExecuteCommand(cmd);
                }
            }
            catch (System.Exception ex)
            {
                throw new DBIOException(DBIOMessages.FindDocumentsFailed, ex);
            }
        }

        public IEnumerable<Document> FindDocuments(Entity entity, CategoryDescription category)
        {
            LogEntry log = new LogEntry(context, null, LogOperations.FindDocuments);

            try
            {
                using (SqlCommand cmd = CreateStoredProcedureCommand("spQueryDocuments_ByEntityAndCategory"))
                {
                    cmd.Parameters.Add("@UserGUID", SqlDbType.UniqueIdentifier).Value = context.UserGuid;
                    cmd.Parameters.Add("@EntityGUID", SqlDbType.UniqueIdentifier).Value = entity.Guid;
                    cmd.Parameters.Add("@CategoryType", SqlDbType.Int).Value = category.Type;
                    cmd.Parameters.Add("@CategoryValue", SqlDbType.Int).Value = category.Id;
                    AppendLimitParameters(cmd);

                    log.WriteOkEntry();

                    return ExecuteCommand(cmd);
                }
            }
            catch (System.Exception ex)
            {
                throw new DBIOException(DBIOMessages.FindDocumentsFailed, ex);
            }
        }

        private IEnumerable<Contacto.Lib.Document> ExecuteCommand(SqlCommand cmd)
        {
            using (SqlDataReader dr = cmd.ExecuteReader())
            {
                while (dr.Read())
                {
                    Document d = new Document(context);

                    d.LoadFromReader(dr);
                    yield return d;
                }

                dr.Close();
            }
        }

        private void AppendLimitParameters(SqlCommand cmd)
        {
            cmd.Parameters.Add("@DateFrom", SqlDbType.DateTime).Value = context.DateLimitFrom;
            cmd.Parameters.Add("@DateTo", SqlDbType.DateTime).Value = context.DateLimitTo;
            cmd.Parameters.Add("@ShowHidden", SqlDbType.Bit).Value = context.ShowHidden;
            cmd.Parameters.Add("@ShowDeleted", SqlDbType.Bit).Value = context.ShowDeleted;
            cmd.Parameters.Add("@ShowClosed", SqlDbType.Bit).Value = context.ShowClosed;
        }

        #endregion
    }
}
