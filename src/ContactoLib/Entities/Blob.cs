using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.IO;

namespace Contacto.Lib
{
    public class Blob : Entity
    {
        #region Member variables

        private int revision;
        private Guid checkedOutBy;
        private bool current;
        private string filename;
        private string format;
        private int size;
        private byte[] data;

        private string tempFilename;
        private DateTime checkoutTime;

        #endregion
        #region Properties

        public BlobTypes Type
        {
            get { return (BlobTypes)base.type; }
            set { base.type = (int)value; }
        }

        public int Revision
        {
            get { return revision; }
            set { revision = value; }
        }

        public Guid CheckedOutBy
        {
            get { return checkedOutBy; }
            set { checkedOutBy = value; }
        }

        public bool Current
        {
            get { return current; }
            set { current = value; }
        }

        public string Filename
        {
            get { return filename; }
            set
            {
                filename = value;
                DisplayName = value;
            }
        }

        public string Format
        {
            get { return format; }
            set { format = value; }
        }

        public int Size
        {
            get { return size; }
        }

        public string TempFilename
        {
            get { return tempFilename; }
            set { tempFilename = value; }
        }

        public DateTime CheckoutTime
        {
            get { return this.checkoutTime; }
            set { this.checkoutTime = value; }
        }

        #endregion
        #region Costructors

        public Blob()
            : base()
        {
            InitializeMembers();
        }

        public Blob(Context context)
            : base(context)
        {
            InitializeMembers();
        }

        public Blob(Blob old)
            : base(old)
        {
            CopyMembers(old);
        }

        #endregion
        #region Initializers

        private void InitializeMembers()
        {
            base.entityType = EntityTypes.Blob;
            base.type = (int)BlobTypes.Unknown;

            this.revision = 0;
            this.checkedOutBy = Guid.Empty;
            this.current = true;
            this.filename = string.Empty;
            this.format = string.Empty;
            this.size = 0;
            this.data = null;

            this.tempFilename = null;
        }

        private void CopyMembers(Blob old)
        {
            this.revision = old.revision;
            this.checkedOutBy = old.checkedOutBy;
            this.current = old.current;
            this.filename = old.filename;
            this.format = old.format;
            this.size = old.size;
            this.data = old.data;

            this.tempFilename = old.tempFilename;
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
                else if (parentEntity.GetType() == typeof(Document))
                {
                    Link l = GetLink((int)LinkTypes.BlobToDocumentLink);
                    l.PointedEntity = parentEntity;
                }
            }
            catch (System.Exception ex)
            {
                throw new DBIOException(DBIOMessages.NewBlobFailed, ex);
            }
        }

        #region Database IO functions

        public override void LoadDetails()
        {
            LoadLinks();
        }

        protected override void Create()
        {
            try
            {
                base.Create();

                string sql = "spCreateBlob";

                using (SqlCommand cmd = CreateStoredProcedureCommand(sql))
                {
                    AppendCreateModifyCommandParameters(cmd);

                    cmd.ExecuteNonQuery();
                }
            }
            catch (System.Exception ex)
            {
                throw new DBIOException(DBIOMessages.CreateBlobFailed, ex);
            }
        }

        protected override void Modify()
        {
            try
            {
                base.Modify();

                string sql = "spModifyBlob";

                using (SqlCommand cmd = CreateStoredProcedureCommand(sql))
                {
                    AppendCreateModifyCommandParameters(cmd);

                    cmd.ExecuteNonQuery();
                }
            }
            catch (System.Exception ex)
            {
                throw new DBIOException(DBIOMessages.ModifyBlobFailed, ex);
            }
        }

        private void AppendCreateModifyCommandParameters(SqlCommand cmd)
        {
            cmd.Parameters.Add("@UserGUID", SqlDbType.UniqueIdentifier).Value = context.UserGuid;

            cmd.Parameters.Add("@GUID", SqlDbType.UniqueIdentifier).Value = guid;
            cmd.Parameters.Add("@Filename", SqlDbType.NVarChar, 250).Value = filename;
            cmd.Parameters.Add("@Format", SqlDbType.NVarChar, 5).Value = format;
        }

        public override void Load()
        {
            try
            {
                LogEntry log = new LogEntry(context, this, LogOperations.LoadBlob);

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
                throw new DBIOException(DBIOMessages.LoadBlobFailed, ex);
            }
        }

        internal override int LoadFromReader(SqlDataReader dr)
        {
            base.entityType = EntityTypes.Document;

            int o = base.LoadFromReader(dr);

            ++o;

            if (dr.FieldCount > o)
            {
                this.checkedOutBy = dr.IsDBNull(++o) ? Guid.Empty : dr.GetGuid(o);
                this.current = dr.GetBoolean(++o);
                this.filename = dr.GetString(++o);
                this.format = dr.GetString(++o);
                this.size = (int)(dr.IsDBNull(++o) ? 0 : dr.GetInt32(o));
            }

            return o;
        }

        public bool CheckFilenameDuplicate()
        {
            try
            {
                LogEntry log = new LogEntry(context, this, LogOperations.CheckBlobFilenameDuplicate);

                string sql = "spCheckBlobFilenameDuplicate";

                using (SqlCommand cmd = CreateStoredProcedureCommand(sql))
                {
                    cmd.Parameters.Add("@UserGUID", SqlDbType.UniqueIdentifier).Value = context.UserGuid;
                    cmd.Parameters.Add("@DocumentGUID", SqlDbType.UniqueIdentifier).Value = GetLink((int)LinkTypes.BlobToDocumentLink).Pointer;
                    cmd.Parameters.Add("@Filename", SqlDbType.NVarChar, 250).Value = filename;
                    cmd.Parameters.Add("RETVAL", SqlDbType.Int).Direction = ParameterDirection.ReturnValue;

                    cmd.ExecuteNonQuery();

                    log.WriteOkEntry();

                    return (((int)cmd.Parameters["RETVAL"].Value) > 0);
                }
            }
            catch (System.Exception ex)
            {
                throw new DBIOException(DBIOMessages.CheckBlobFilenameDuplicateFailed, ex);
            }
        }

        public void SetData(string filename)
        {
            using (FileStream infile = new FileStream(filename, FileMode.Open, FileAccess.Read, FileShare.None))
            {
                SetData(filename, infile);
                infile.Close();
            }
        }

        public void SetData(string filename, Stream ms)
        {
            try
            {
                LogEntry log = new LogEntry(context, this, LogOperations.SetBlobData);

                this.filename = Path.GetFileName(filename);
                this.format = Path.GetExtension(filename);

                data = new byte[(int)ms.Length];
                ms.Read(data, 0, data.Length);

                this.size = data.Length;

                string sql = "spSetBlobData";
                using (SqlCommand cmd = CreateStoredProcedureCommand(sql))
                {
                    cmd.Parameters.Add("@UserGUID", SqlDbType.UniqueIdentifier).Value = context.UserGuid;
                    cmd.Parameters.Add("@EntityGUID", SqlDbType.UniqueIdentifier).Value = this.guid;
                    cmd.Parameters.Add("@Version", SqlDbType.Int).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("@Filename", SqlDbType.NVarChar, 250).Value = this.filename;
                    cmd.Parameters.Add("@Format", SqlDbType.NVarChar, 5).Value = this.format;
                    cmd.Parameters.Add("@Data", SqlDbType.VarBinary, this.data.Length).Value = this.data;

                    cmd.ExecuteNonQuery();

                    Version = (int)cmd.Parameters["@Version"].Value;
                }

                log.WriteOkEntry();
            }
            catch (System.Exception ex)
            {
                throw new DBIOException(DBIOMessages.SetBlobDataFailed, ex);
            }
        }

        public void GetData()
        {
            try
            {
                LogEntry log = new LogEntry(context, this, LogOperations.GetBlobData);

                if (this.data == null)
                {
                    string sql = "spGetBlobData";
                    using (SqlCommand cmd = CreateStoredProcedureCommand(sql))
                    {
                        cmd.Parameters.Add("@UserGUID", SqlDbType.UniqueIdentifier).Value = context.UserGuid;
                        cmd.Parameters.Add("@GUID", SqlDbType.UniqueIdentifier).Value = this.guid;

                        using (SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.SingleRow))
                        {
                            dr.Read();

                            data = dr.GetSqlBytes(0).Value;

                            dr.Close();
                        }
                    }
                }
                log.WriteOkEntry();
            }
            catch (System.Exception ex)
            {
                throw new DBIOException(DBIOMessages.GetBlobDataFailed, ex);
            }
        }

        public void UpdateData()
        {
            try
            {
                LogEntry log = new LogEntry(context, this, LogOperations.UpdateBlobData);

                using (FileStream infile = new FileStream(tempFilename, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                {
                    data = new byte[(int)infile.Length];
                    infile.Read(data, 0, data.Length);
                    infile.Close();
                }

                string sql = "spSetBlobData";
                using (SqlCommand cmd = CreateStoredProcedureCommand(sql))
                {
                    cmd.Parameters.Add("@UserGUID", SqlDbType.UniqueIdentifier).Value = context.UserGuid;
                    cmd.Parameters.Add("@EntityGUID", SqlDbType.UniqueIdentifier).Value = this.guid;
                    cmd.Parameters.Add("@Version", SqlDbType.Int).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("@Filename", SqlDbType.NVarChar, 250).Value = this.filename;
                    cmd.Parameters.Add("@Format", SqlDbType.NVarChar, 5).Value = this.format;
                    cmd.Parameters.Add("@Data", SqlDbType.VarBinary, this.data.Length).Value = this.data;

                    cmd.ExecuteNonQuery();

                    Version = (int)cmd.Parameters["@Version"].Value;
                }

                log.WriteOkEntry();
            }
            catch (System.Exception ex)
            {
                throw new DBIOException(DBIOMessages.UpdateBlobDataFailed, ex);
            }
        }

        public void CheckOut(CheckOutMode mode)
        {
            if (context.CheckoutManager.IsCheckedOut(this))
            {
                throw new CheckOutException("already checked out");
            }

            try
            {
                LogEntry log = new LogEntry(context, this, LogOperations.CheckOutBlob);

                if (mode == CheckOutMode.Edit)
                {
                    string sql = "spCheckOutBlob";
                    using (SqlCommand cmd = CreateStoredProcedureCommand(sql))
                    {
                        cmd.Parameters.Add("@UserGUID", SqlDbType.UniqueIdentifier).Value = context.UserGuid;
                        cmd.Parameters.Add("@GUID", SqlDbType.UniqueIdentifier).Value = this.guid;

                        int res = cmd.ExecuteNonQuery();
                        if (res != 1)
                            //****
                            throw new CheckOutException("cannot check out");
                    }
                }


                tempFilename = context.CheckoutManager.GetTempfileName(this);

                SaveToFile(tempFilename);

                if (mode == CheckOutMode.Edit)
                {
                    checkoutTime = File.GetLastWriteTime(tempFilename);
                    checkedOutBy = context.UserGuid;
                }

                if (mode == CheckOutMode.ReadOnly || mode == CheckOutMode.Print)
                    File.SetAttributes(tempFilename, FileAttributes.ReadOnly);

                log.WriteOkEntry();
            }
            catch (System.Exception ex)
            {
                throw new DBIOException(DBIOMessages.CheckOutBlobFailed, ex);
            }
        }

        public void SaveToFile(string filename)
        {
            GetData();
            using (FileStream outfile = new FileStream(filename, FileMode.CreateNew, FileAccess.Write, FileShare.None))
            {
                outfile.Write(data, 0, data.Length);
                outfile.Close();
            }
        }

        public MemoryStream GetDataStream()
        {
            return new MemoryStream(data);
        }

        public void CheckIn(bool tryDelete)
        {
            try
            {
                LogEntry log = new LogEntry(context, this, LogOperations.CheckInBlob);
                // delete temp file
                // it is going to throw an error if the file is still being locked by
                // the editor program
                if (tryDelete) File.Delete(tempFilename);

                // check tempfile
                string sql = "spCheckInBlob";
                using (SqlCommand cmd = CreateStoredProcedureCommand(sql))
                {
                    cmd.Parameters.Add("@UserGUID", SqlDbType.UniqueIdentifier).Value = context.UserGuid;
                    cmd.Parameters.Add("@GUID", SqlDbType.UniqueIdentifier).Value = this.guid;

                    if (cmd.ExecuteNonQuery() != 1)
                        //****
                        throw new CheckOutException("cannot check in");
                }

                context.CheckoutManager.CheckedoutBlobs.RemoveAll
                    (delegate(Blob bb)
                    {
                        return bb.guid == this.guid;
                    });
                //context.CheckoutManager.CheckedoutBlobs.Remove(this);

                tempFilename = null;
                checkedOutBy = Guid.Empty;

                log.WriteOkEntry();
            }
            catch (System.Exception ex)
            {
                throw new DBIOException(DBIOMessages.CheckInBlobFailed, ex);
            }
        }

        #endregion
        #region Formatter functions

        public override string GetClipboardString()
        {
            return string.Empty;
        }

        public override string GetFieldFormatted(string field)
        {
            string res;

            switch (field)
            {
                case "Filename":
                    res = filename;
                    break;
                case "Size":
                    res = Contacto.Lib.Util.SmartFileSize(size);
                    break;
                case "Revision":
                    res = revision.ToString();
                    break;
                case "CheckedOutBy":
                    if (checkedOutBy == Guid.Empty)
                        res = "(senki)";
                    else
                        res = Contacto.Lib.Util.UserName(context.SchemaManager.GetUser(checkedOutBy));
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
