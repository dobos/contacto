using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace Contacto.Lib
{
    public class EntityFactory : ObjectBase
    {
        #region Costructors

        public EntityFactory()
            : base()
        {

        }

        public EntityFactory(Context context)
            : base(context)
        {

        }

        #endregion
        #region Search function

        public IEnumerable<Entity> FindEntities(SimpleSearchParameters ssp)
        {
            try
            {
                LogEntry log = new LogEntry(context, null, LogOperations.FindEntities);

                using (SqlCommand cmd = CreateStoredProcedureCommand("spFindEntities"))
                {
                    cmd.Parameters.Add("@UserGUID", SqlDbType.UniqueIdentifier).Value = context.UserGuid;
                    cmd.Parameters.Add("@Query", SqlDbType.NVarChar, 50).Value = ssp.Query;
                    cmd.Parameters.Add("@EntityTypes", SqlDbType.NVarChar, 1000).Value = ssp.GetEntityIdList();
                    AppendLimitParameters(cmd);

                    log.WriteOkEntry();

                    return ExecuteCommand(cmd);
                }
            }
            catch (System.Exception ex)
            {
                throw new DBIOException(DBIOMessages.FindEntitiesFailed, ex);
            }
        }

        public IEnumerable<Entity> FindEntities(string query)
        {
            return FindEntities(query, null);
        }

        
        public IEnumerable<Entity> FindEntities(string query, int? entityType)
        {
            try
            {
                LogEntry log = new LogEntry(context, null, LogOperations.FindEntities);

                using (SqlCommand cmd = CreateStoredProcedureCommand("spFindEntities"))
                {
                    cmd.Parameters.Add("@UserGUID", SqlDbType.UniqueIdentifier).Value = context.UserGuid;
                    cmd.Parameters.Add("@Query", SqlDbType.NVarChar, 50).Value = query;
                    cmd.Parameters.Add("@EntityTypes", SqlDbType.NVarChar, 1000).Value = entityType.HasValue ? (object)entityType.ToString() : DBNull.Value;
                    AppendLimitParameters(cmd);

                    log.WriteOkEntry();

                    return ExecuteCommand(cmd);
                }
            }
            catch (System.Exception ex)
            {
                throw new DBIOException(DBIOMessages.FindEntitiesFailed, ex);
            }
        }

        public IEnumerable<Entity> FindEntities(Entity entity, string query)
        {
            return FindEntities(entity, query, null);
        }

        public IEnumerable<Entity> FindEntities(Entity entity, string query, int? entityType)
        {
            try
            {
                LogEntry log = new LogEntry(context, null, LogOperations.FindEntities);

                using (SqlCommand cmd = CreateStoredProcedureCommand("spFindEntities_ByEntity"))
                {
                    cmd.Parameters.Add("@UserGUID", SqlDbType.UniqueIdentifier).Value = context.UserGuid;
                    cmd.Parameters.Add("@Query", SqlDbType.NVarChar, 50).Value = query;
                    cmd.Parameters.Add("@EntityTypes", SqlDbType.NVarChar, 1000).Value = entityType.ToString();
                    cmd.Parameters.Add("@EntityGUID", SqlDbType.UniqueIdentifier).Value = entity.Guid;
                    AppendLimitParameters(cmd);

                    log.WriteOkEntry();

                    return ExecuteCommand(cmd);
                }
            }
            catch (System.Exception ex)
            {
                throw new DBIOException(DBIOMessages.FindEntitiesFailed, ex);
            }
        }

        public IEnumerable<Entity> FindEntities(CategoryDescription category)
        {
            try
            {
                LogEntry log = new LogEntry(context, null, LogOperations.FindEntities);

                using (SqlCommand cmd = CreateStoredProcedureCommand("spQueryEntities_ByCategory"))
                {
                    cmd.Parameters.Add("@UserGUID", SqlDbType.UniqueIdentifier).Value = context.UserGuid;
                    cmd.Parameters.Add("@EntityType", SqlDbType.Int).Value = category.EntityType;
                    cmd.Parameters.Add("@CategoryType", SqlDbType.Int).Value = category.Type;
                    cmd.Parameters.Add("@CategoryValue", SqlDbType.Int).Value = category.Id;
                    AppendLimitParameters(cmd);

                    log.WriteOkEntry();

                    return ExecuteCommand(cmd);
                }
            }
            catch (System.Exception ex)
            {
                throw new DBIOException(DBIOMessages.FindEntitiesFailed, ex);
            }
        }

        public IEnumerable<Entity> FindEntities(Entity entity)
        {
            try
            {
                LogEntry log = new LogEntry(context, null, LogOperations.FindEntities);

                using (SqlCommand cmd = CreateStoredProcedureCommand("spQueryEntities_ByEntity"))
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
                throw new DBIOException(DBIOMessages.FindEntitiesFailed, ex);
            }
        }

        public IEnumerable<Entity> FindDeletedEntities()
        {
            try
            {
                LogEntry log = new LogEntry(context, null, LogOperations.FindEntities);

                using (SqlCommand cmd = CreateStoredProcedureCommand("spQueryDeletedEntities"))
                {
                    log.WriteOkEntry();

                    return ExecuteCommand(cmd);
                }
            }
            catch (System.Exception ex)
            {
                throw new DBIOException(DBIOMessages.FindEntitiesFailed, ex);
            }
        }

        private IEnumerable<Entity> ExecuteCommand(SqlCommand cmd)
        {
            using (SqlDataReader dr = cmd.ExecuteReader())
            {
                while (dr.Read())
                {
                    Entity e;

                    switch (dr.GetInt32(1))
                    {
                        case EntityTypes.Company:
                            e = new Company(context);
                            break;
                        case EntityTypes.Person:
                            e = new Person(context);
                            break;
                        case EntityTypes.Document:
                            e = new Document(context);
                            break;
                        case EntityTypes.Folder:
                            e = new Folder(context);
                            break;
                        default:
                            e = null;
                            break;
                    }

                    if (e != null)
                    {
                        e.LoadFromReader(dr);
                        yield return e;
                    }
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
