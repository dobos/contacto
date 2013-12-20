using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace Contacto.Lib
{
    public class Folder : Entity
    {
        #region Member variables

        private string title;

        #endregion
        #region Properties

        public FolderTypes Type
        {
            get { return (FolderTypes)base.type; }
            set { base.type = (int)value; }
        }

        public string Title
        {
            get { return title; }
            set { title = value; }
        }

        #endregion
        #region Costructors

        public Folder()
            : base()
        {
            InitializeMembers();
        }

        public Folder(Context context)
            : base(context)
        {
            InitializeMembers();
        }

        public Folder(Folder old)
            : base(old)
        {
            CopyMembers(old);
        }

        #endregion
        #region Initializers

        private void InitializeMembers()
        {
            base.entityType = EntityTypes.Folder;
            base.type = (int)FolderTypes.Unknown;

            this.title = string.Empty;
        }

        private void CopyMembers(Folder old)
        {
            this.title = old.title;
        }

        #endregion

        public override void NewEntity(Entity parentEntity)
        {
            try
            {
                base.NewEntity(parentEntity);

                Link l = null;

                if (parentEntity == null)
                {
                }
                else if (parentEntity.GetType() == typeof(Company))
                {
                    l = GetLink((int)LinkTypes.FolderCompanyLink);
                    l.PointedEntity = parentEntity;
                }
                else if (parentEntity.GetType() == typeof(Person))
                {
                    l = GetLink((int)LinkTypes.FolderPersonLink);
                    l.PointedEntity = parentEntity;
                }

                l = GetLink((int)LinkTypes.FolderUserLink);
                l.PointedEntity = context.User;
            }
            catch (System.Exception ex)
            {
                throw new DBIOException(DBIOMessages.NewDocumentFailed, ex);
            }
        }

        #region Database IO functions

        protected override void Create()
        {
            try
            {
                base.Create();

                string sql = "spCreateFolder";

                using (SqlCommand cmd = CreateStoredProcedureCommand(sql))
                {
                    AppendCreateModifyCommandParameters(cmd);

                    cmd.ExecuteNonQuery();
                }
            }
            catch (System.Exception ex)
            {
                throw new DBIOException(DBIOMessages.CreateFolderFailed, ex);
            }
        }

        protected override void Modify()
        {
            try
            {
                base.Modify();

                string sql = "spModifyFolder";

                using (SqlCommand cmd = CreateStoredProcedureCommand(sql))
                {
                    AppendCreateModifyCommandParameters(cmd);

                    cmd.ExecuteNonQuery();
                }
            }
            catch (System.Exception ex)
            {
                throw new DBIOException(DBIOMessages.ModifyFolderFailed, ex);
            }
        }

        private void AppendCreateModifyCommandParameters(SqlCommand cmd)
        {
            cmd.Parameters.Add("@UserGUID", SqlDbType.UniqueIdentifier).Value = context.UserGuid;

            cmd.Parameters.Add("@GUID", SqlDbType.UniqueIdentifier).Value = guid;
            cmd.Parameters.Add("@Title", SqlDbType.NVarChar, 50).Value = title;
        }

        public override void Load()
        {
            try
            {
                LogEntry log = new LogEntry(context, this, LogOperations.LoadFolder);
                string sql = "spGetFolder";

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
                throw new DBIOException(DBIOMessages.LoadFolderFailed, ex);
            }
        }

        internal override int LoadFromReader(SqlDataReader dr)
        {
            base.entityType = EntityTypes.Folder;

            int o = base.LoadFromReader(dr);

            ++o;

            if (dr.FieldCount > o)
            {
                this.title = dr.GetString(++o);
            }

            return o;
        }

        #endregion
        #region Document functions

        public override void LoadDocuments()
        {
            try
            {
                LogEntry log = new LogEntry(context, this, LogOperations.LoadDocuments);

                documents = new List<Document>();
                string sql = "spQueryFolderDocuments";

                using (SqlCommand cmd = CreateStoredProcedureCommand(sql))
                {
                    cmd.Parameters.Add("@UserGUID", SqlDbType.UniqueIdentifier).Value = context.UserGuid;
                    cmd.Parameters.Add("@FolderGUID", SqlDbType.UniqueIdentifier).Value = guid;

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            Document d = new Document();
                            ((Entity)d).LoadFromReader(dr);

                            documents.Add(d);
                        }

                        dr.Close();
                    }
                }

                log.WriteOkEntry();
            }
            catch (System.Exception ex)
            {
                throw new DBIOException(DBIOMessages.LoadDocumentsFailed, ex);
            }
        }

        #endregion
        #region Formatting functions

        public override string GetClipboardString()
        {
            return DisplayName + Environment.NewLine;
        }

        public override string[] GetDisplayTextAlternates()
        {
            return new string[]
            {
                title
            };
        }

        #endregion
    }
}
