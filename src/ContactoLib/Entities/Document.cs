using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace Contacto.Lib
{
    public class Document : Entity
    {
        #region Member variables

        private string title;
        private string subject;
        private string foreignNumber;

        private List<Contacto.Lib.Blob> blobs;

        #endregion
        #region Properties

        public DocumentTypes Type
        {
            get { return (DocumentTypes)base.type; }
            set { base.type = (int)value; }
        }

        public string Title
        {
            get { return title; }
            set { title = value; }
        }

        public string Subject
        {
            get { return subject; }
            set { subject = value; }
        }

        public string ForeignNumber
        {
            get { return foreignNumber; }
            set { foreignNumber = value; }
        }

        public List<Blob> Blobs
        {
            get { return blobs; }
        }

        #endregion
        #region Costructors

        public Document()
            : base()
        {
            InitializeMembers();
        }

        public Document(Context context)
            : base(context)
        {
            InitializeMembers();
        }

        public Document(Document old)
            : base(old)
        {
            CopyMembers(old);
        }

        #endregion
        #region Initializers

        private void InitializeMembers()
        {
            base.entityType = EntityTypes.Document;
            base.type = (int)DocumentTypes.Unknown;

            this.title = string.Empty;
            this.subject = string.Empty;
            this.foreignNumber = string.Empty;

            this.blobs = null;
        }

        private void CopyMembers(Document old)
        {
            this.title = old.title;
            this.subject = old.subject;
            this.foreignNumber = old.foreignNumber;

            this.blobs = old.blobs;
        }

        #endregion

        public override void NewEntity(Entity parentEntity)
        {
            base.NewEntity(parentEntity);

            NewEntity(parentEntity, null, DocumentDirections.Unknown);
        }

        public void NewEntity(Entity parentEntity, Folder folder, DocumentDirections direction)
        {
            base.NewEntity(parentEntity);

            GetCategory((int)CategoryTypes.DocumentDirection).Value = (int)direction;

            try
            {
                if (direction == DocumentDirections.Outbound)
                {
                    GetLink((int)LinkTypes.DocumentFromCompanyLink).PointedEntity = context.Company;
                    GetLink((int)LinkTypes.DocumentFromPersonLink).PointedEntity = context.User;
                }
                else if (direction == DocumentDirections.Inbound)
                {
                    GetLink((int)LinkTypes.DocumentToCompanyLink).PointedEntity = context.Company;
                    GetLink((int)LinkTypes.DocumentToPersonLink).PointedEntity = context.User;
                }

                if (parentEntity != null && parentEntity.GetType() == typeof(Folder) || folder != null)
                {
                    if (folder != null) parentEntity = folder;

                    GetLink((int)LinkTypes.DocumentFolderLink).PointedEntity = parentEntity;

                    switch (direction)
                    {
                        case DocumentDirections.Outbound:
                            GetLink((int)LinkTypes.DocumentToCompanyLink).PointedEntity = parentEntity.GetLink((int)LinkTypes.FolderCompanyLink).PointedEntity;
                            GetLink((int)LinkTypes.DocumentToPersonLink).PointedEntity = parentEntity.GetLink((int)LinkTypes.FolderPersonLink).PointedEntity;
                            break;
                        case DocumentDirections.Inbound:
                            GetLink((int)LinkTypes.DocumentFromCompanyLink).PointedEntity = parentEntity.GetLink((int)LinkTypes.FolderCompanyLink).PointedEntity;
                            GetLink((int)LinkTypes.DocumentFromPersonLink).PointedEntity = parentEntity.GetLink((int)LinkTypes.FolderPersonLink).PointedEntity;
                            break;
                    }
                }

                if (parentEntity == null || direction == DocumentDirections.Internal)
                {
                    GetLink((int)LinkTypes.DocumentFromCompanyLink).PointedEntity = context.Company;
                    GetLink((int)LinkTypes.DocumentFromPersonLink).PointedEntity = context.User;
                }
                else if (parentEntity.GetType() == typeof(Company))
                {
                    switch (direction)
                    {
                        case DocumentDirections.Outbound:
                            GetLink((int)LinkTypes.DocumentToCompanyLink).PointedEntity = parentEntity;
                            break;
                        case DocumentDirections.Inbound:
                            GetLink((int)LinkTypes.DocumentFromCompanyLink).PointedEntity = parentEntity;
                            break;
                    }
                }
                else if (parentEntity.GetType() == typeof(Person))
                {
                    switch (direction)
                    {
                        case DocumentDirections.Outbound:
                            GetLink((int)LinkTypes.DocumentToCompanyLink).PointedEntity = parentEntity.GetLink((int)LinkTypes.PersonCompanyLink).PointedEntity;
                            GetLink((int)LinkTypes.DocumentToPersonLink).PointedEntity = parentEntity;
                            break;
                        case DocumentDirections.Inbound:
                            GetLink((int)LinkTypes.DocumentFromCompanyLink).PointedEntity = parentEntity.GetLink((int)LinkTypes.PersonCompanyLink).PointedEntity;
                            GetLink((int)LinkTypes.DocumentFromPersonLink).PointedEntity = parentEntity;
                            break;
                    }
                }
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

                string sql = "spCreateDocument";

                using (SqlCommand cmd = CreateStoredProcedureCommand(sql))
                {
                    AppendCreateModifyCommandParameters(cmd);

                    cmd.ExecuteNonQuery();
                }
            }
            catch (System.Exception ex)
            {
                throw new DBIOException(DBIOMessages.CreateDocumentFailed, ex);
            }
        }

        protected override void Modify()
        {
            try
            {
                base.Modify();

                string sql = "spModifyDocument";

                using (SqlCommand cmd = CreateStoredProcedureCommand(sql))
                {
                    AppendCreateModifyCommandParameters(cmd);

                    cmd.ExecuteNonQuery();
                }
            }
            catch (System.Exception ex)
            {
                throw new DBIOException(DBIOMessages.ModifyDocumentFailed, ex);
            }
        }

        private void AppendCreateModifyCommandParameters(SqlCommand cmd)
        {
            cmd.Parameters.Add("@UserGUID", SqlDbType.UniqueIdentifier).Value = context.UserGuid;

            cmd.Parameters.Add("@GUID", SqlDbType.UniqueIdentifier).Value = guid;
            cmd.Parameters.Add("@Title", SqlDbType.NVarChar, 50).Value = title;
            cmd.Parameters.Add("@Subject", SqlDbType.NVarChar, 250).Value = subject;
            cmd.Parameters.Add("@ForeignNumber", SqlDbType.NVarChar, 50).Value = foreignNumber;
        }

        public override void Load()
        {
            try
            {
                LogEntry log = new LogEntry(context, this, LogOperations.LoadDocument);

                string sql = "spGetDocument";
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
                throw new DBIOException(DBIOMessages.LoadDocumentFailed, ex);
            }
        }

        internal override int LoadFromReader(SqlDataReader dr)
        {
            base.entityType = EntityTypes.Document;

            int o = base.LoadFromReader(dr);

            ++o;

            if (dr.FieldCount > o)
            {
                this.title = dr.GetString(++o);
                this.subject = dr.GetString(++o);
                this.foreignNumber = dr.GetString(++o);
            }

            return o;
        }

        public override void LoadDetails()
        {
            if (!detailsLoaded)
            {
                this.LoadDates();
                this.LoadLinks();
                this.LoadCategories();

                detailsLoaded = true;
            }
        }

        #endregion
        #region Blob functions

        public void LoadBlobs()
        {
            try
            {
                LogEntry log = new LogEntry(context, this, LogOperations.LoadBlobs);

                if (blobs == null)
                    blobs = new List<Blob>();
                else
                    blobs.Clear();

                string sql = "spQueryDocumentBlobs";

                using (SqlCommand cmd = CreateStoredProcedureCommand(sql))
                {
                    cmd.Parameters.Add("@UserGUID", SqlDbType.UniqueIdentifier).Value = context.UserGuid;
                    cmd.Parameters.Add("@DocumentGUID", SqlDbType.UniqueIdentifier).Value = guid;

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            Blob blob = new Blob(context);
                            ((Entity)blob).LoadFromReader(dr);

                            blobs.Add(blob);
                        }

                        dr.Close();
                    }
                }
                log.WriteOkEntry();
            }
            catch (System.Exception ex)
            {
                throw new DBIOException(DBIOMessages.LoadBlobsFailed, ex);
            }
        }

        #endregion
        #region Formatters

        public override string GetClipboardString()
        {
            LoadDetails();

            string res = string.Empty;

            if (number != null) res += number.ToString() + " - ";

            res += DisplayName + Environment.NewLine;
            res += GetCategory((int)CategoryTypes.Primary).DisplayText + Environment.NewLine;
            res += "Tárgy: " + subject + Environment.NewLine;

            res += "Kelt: " + GetDate((int)DateTypes.Primary).DisplayText + Environment.NewLine;
            res += "Irány: " + GetCategory((int)CategoryTypes.DocumentDirection).DisplayText + Environment.NewLine;

            Entity c = GetLink((int)LinkTypes.DocumentFolderLink).PointedEntity;
            if (c != null)
                res += "Mappa: " + c.DisplayName + Environment.NewLine;
            c = GetLink((int)LinkTypes.DocumentFromCompanyLink).PointedEntity;
            if (c != null)
                res += "Feladó: " + c.DisplayName + Environment.NewLine;
            c = GetLink((int)LinkTypes.DocumentFromPersonLink).PointedEntity;
            if (c != null)
                res += "Szerzõ: " + c.DisplayName + Environment.NewLine;
            c = GetLink((int)LinkTypes.DocumentToCompanyLink).PointedEntity;
            if (c != null)
                res += "Címzett: " + c.DisplayName + Environment.NewLine;
            c = GetLink((int)LinkTypes.DocumentToPersonLink).PointedEntity;
            if (c != null)
                res += "Ügyinzézõ: " + c.DisplayName + Environment.NewLine;

            return res;
        }

        public override string[] GetDisplayTextAlternates()
        {
            return new string[]
            {
                title,
                number,
                title + " - " + number,
                subject,
                subject + " - " + title,
                title + " - " + subject,
            };
        }

        public override string GetFieldFormatted(string field)
        {
            string res;

            switch (field)
            {
                case "Title":
                    res = title;
                    break;
                case "Subject":
                    res = subject;
                    break;
                case "ForeignNumber":
                    res = foreignNumber;
                    break;
                case "Category":
                    res = this.GetCategory((int)Contacto.Lib.CategoryTypes.Primary).DisplayText;
                    break;
                case "Date":
                    res = this.GetDate((int)Contacto.Lib.DateTypes.Primary).DisplayText;
                    break;
                case "Direction":
                    res = this.GetCategory((int)Contacto.Lib.CategoryTypes.DocumentDirection).DisplayText;
                    break;
                case "Brand":
                    res = this.GetCategory((int)Contacto.Lib.CategoryTypes.Brand).DisplayText;
                    break;
                case "FromCompany":
                    res = this.GetLink((int)Contacto.Lib.LinkTypes.DocumentFromCompanyLink).DisplayText;
                    break;
                case "FromPerson":
                    res = this.GetLink((int)Contacto.Lib.LinkTypes.DocumentFromPersonLink).DisplayText;
                    break;
                case "ToCompany":
                    res = this.GetLink((int)Contacto.Lib.LinkTypes.DocumentToCompanyLink).DisplayText;
                    break;
                case "ToPerson":
                    res = this.GetLink((int)Contacto.Lib.LinkTypes.DocumentToPersonLink).DisplayText;
                    break;
                case "Folder":
                    res = this.GetLink((int)Contacto.Lib.LinkTypes.DocumentFolderLink).DisplayText;
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
