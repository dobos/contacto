using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace Contacto.Lib
{
    public class FolderFactory : ObjectBase
    {
        #region Costructors

        public FolderFactory(Context context)
            : base(context)
        {
        }

        #endregion
        #region Database query functions

        public IEnumerable<Folder> FindDocumentFolders(Entity entity)
        {
            LogEntry log = new LogEntry(context, entity, LogOperations.FindFolders);

            try
            {
                using (SqlCommand cmd = CreateStoredProcedureCommand("spQueryDocumentsFolders_ByEntities"))
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
                throw new DBIOException(DBIOMessages.FindFoldersFailed, ex);
            }
        }

        private IEnumerable<Folder> ExecuteCommand(SqlCommand cmd)
        {
            using (SqlDataReader dr = cmd.ExecuteReader())
            {
                while (dr.Read())
                {
                    Folder f = new Folder(context);
                    f.LoadFromReader(dr);
                    yield return f;
                }

                dr.Close();
                cmd.Dispose();
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
