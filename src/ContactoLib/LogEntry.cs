using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace Contacto.Lib
{
    public class LogEntry : ObjectBase
    {
        private Entity entity;
        private LogOperations operation;
        private LogResults result;
        private string details;

        public Entity Entity
        {
            get { return entity; }
            set { entity = value; }
        }

        public LogOperations Operation
        {
            get { return operation; }
            set { operation = value; }
        }

        public LogResults Result
        {
            get { return result; }
            set { result = value; }
        }

        public string Details
        {
            get { return details; }
            set { details = value; }
        }

        public LogEntry(Context context)
            : base(context)
        {
            InitializeMembers();
        }

        public LogEntry(Context context, Entity entity, LogOperations operation)
            :base(context)
        {
            InitializeMembers();

            this.entity = entity;
            this.operation = operation;
        }

        private void InitializeMembers()
        {
            entity = null;
            operation = LogOperations.Unknown;
            result = LogResults.Unknown;
            details = null;
        }

        private void Create()
        {
            try
            {
                string sql = "spCreateLogEntry";

                using (SqlCommand cmd = CreateStoredProcedureCommand(sql))
                {
                    cmd.Parameters.Add("@UserGUID", SqlDbType.UniqueIdentifier).Value = context.UserGuid;
                    if (entity != null)
                    {
                        cmd.Parameters.Add("@EntityType", SqlDbType.Int).Value = entity.EntityType;
                        cmd.Parameters.Add("@EntityGUID", SqlDbType.UniqueIdentifier).Value = entity.Guid;
                    }
                    else
                    {
                        cmd.Parameters.Add("@EntityType", SqlDbType.Int).Value = DBNull.Value;
                        cmd.Parameters.Add("@EntityGUID", SqlDbType.UniqueIdentifier).Value = DBNull.Value;
                    }
                    cmd.Parameters.Add("@Operation", SqlDbType.Int).Value = (int)operation;
                    cmd.Parameters.Add("@Result", SqlDbType.Int).Value = (int)result;
                    if (details != null && details.Trim() != string.Empty)
                        cmd.Parameters.Add("@Details", SqlDbType.NText).Value = details;
                    else
                        cmd.Parameters.Add("@Details", SqlDbType.NText).Value = DBNull.Value;

                    cmd.ExecuteNonQuery();
                }
            }
            catch (System.Exception ex)
            {
                // dump error
                using (System.IO.StreamWriter log = new System.IO.StreamWriter(System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Contacto\\errors.log"), true))
                {
                    log.WriteLine(ex.ToString() + ":" + ex.Message + "\r\n" + ex.StackTrace);
                    log.Close();
                }
            }
        }

        public void WriteOkEntry()
        {
            result = LogResults.OK;
            Create();
        }

        public void WriteErrorEntry(System.Exception ex)
        {
            result = LogResults.Error;

            details = ex.ToString() + ":" + ex.Message + "\r\n" + ex.StackTrace;

            Create();
        }
    }

    public enum LogOperations
    {
        Unknown = 0,
        LoadSchema = 1,
        LoadTypeDescriptions = 2,
        LoadCategoryDescriptions = 3,
        
        CreateEntity = 10,
        LoadEntity = 11, // not used
        ModifyEntity = 12,
        DeleteEntity = 13,
        SaveEntity = 14,
        FindEntities = 15,
        LoadEntities = 16,  // not used
        CloseEntity = 17,
        OpenEntity = 18,
        RecoverEntity = 19,

        CreateCompany = 10010,
        LoadCompany = 10011,
        FindCompanies = 10015,
        CheckCompanyDuplicates = 10020,
        
        CreatePerson = 20010,
        LoadPerson = 20011,
        FindPersons = 20015,
        LoadPersons = 20016,
        CheckPersonDuplicates = 20020,

        LoadUsers = 20036,
        CreateLogin = 20040,
        DeleteLogin = 20043,
        UserLogin = 20050,
        UserLogoff = 20051,

        CreateDocument = 30010,
        LoadDocument = 30011,
        FindDocuments = 30015,
        LoadDocuments = 30016,

        CreateBlob = 40010,
        LoadBlob = 40011,
        DeleteBlob = 40013,
        LoadBlobs = 40016,
        CheckBlobFilenameDuplicate = 40020,
        SetBlobData = 40031,
        GetBlobData = 40032,
        UpdateBlobData = 40033,
        CheckOutBlob = 40034,
        CheckInBlob = 40035,
        SaveAsBlob = 40036,

        CreateFolder = 50010,
        LoadFolder = 50011,
        FindFolders = 50015,

        LoadAttributes = 990016,
        DeleteAttribute = 990013,

        CreateIdentifier = 1000010,
        ModifyIdentifier = 1000012,
        LoadIdentifiers = 1000016,
        SaveRequiredIdentifiers = 1000030,

        CreateAddress = 2000010,
        ModifyAddress = 2000012,
        LoadAddresses = 2000016,
        SaveRequiredAddresses = 2000030,

        CreateCategory = 3000010,
        ModifyCategory = 3000012,
        DeleteCategory = 3000013,
        LoadCategories = 3000016,
        SaveRequiredCategories = 3000030,

        CreateDate = 4000010,
        ModifyDate = 4000012,
        DeleteDate = 4000013,
        LoadDates = 4000016,
        SaveRequiredDates = 4000030,

        CreateLink = 5000010,
        ModifyLink = 5000012,
        DeleteLink = 5000013,
        LoadLinks = 5000016,
        SaveRequiredLinks = 5000030,
    }

    public enum LogResults
    {
        OK = 0,
        Error = 1,
        Unknown = 2
    }
}
