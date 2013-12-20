using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace Contacto.Lib
{
    public class User : Person
    {

        #region Member variables

        private string username;
        private string password;
        private DateTime dateLogin;
        private bool windows;

        #endregion
        #region Properties

        public string Username
        {
            get { return username; }
            set { username = value; }
        }

        public string Password
        {
            get { return password; }
            set { password = value; }
        }

        public DateTime DateLogin
        {
            get { return dateLogin; }
            set { dateLogin = value; }
        }

        public bool Windows
        {
            get { return windows; }
            set { windows = value; }
        }

        #endregion
        #region Costructors

        public User()
            : base()
        {
            InitializeMembers();
        }

        public User(Context context)
            : base(context)
        {
            InitializeMembers();
        }

        public User(User old)
            : base(old)
        {
            CopyMembers(old);
        }

        #endregion
        #region Initializers

        private void InitializeMembers()
        {
            this.username = string.Empty;
            this.password = string.Empty;
            this.dateLogin = DateTime.MinValue;
        }

        private void CopyMembers(User old)
        {
            this.username = old.username;
            this.password = old.password;
            this.dateLogin = old.dateLogin;
        }

        #endregion
        #region Database IO functions

        public void Login()
        {
            try
            {
                LogEntry log = new LogEntry(context, null, LogOperations.UserLogin);
                log.Details = "Client name: " + Environment.MachineName;

                string sql = "spLoginUser";
                using (SqlCommand cmd = CreateStoredProcedureCommand(sql))
                {
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
                throw new DBIOException(DBIOMessages.LoginFailed, ex);
            }
        }

        public void Logoff()
        {
            try
            {
                LogEntry log = new LogEntry(context, null, LogOperations.UserLogoff);

                string sql = "spLogoffUser";
                using (SqlCommand cmd = CreateStoredProcedureCommand(sql))
                {
                    cmd.Parameters.Add("@UserGUID", SqlDbType.UniqueIdentifier).Value = guid;
                    cmd.ExecuteNonQuery();
                }

                log.WriteOkEntry();
            }
            catch (System.Exception ex)
            {
                throw new DBIOException(DBIOMessages.LogoffFailed, ex);
            }
        }

        internal override int LoadFromReader(SqlDataReader dr)
        {
            base.entityType = EntityTypes.Person;

            int o = base.LoadFromReader(dr);

            ++o;

            if (dr.FieldCount > o)
            {
                this.username = dr.GetString(++o);
                this.dateLogin = dr.IsDBNull(++o) ? DateTime.MinValue : dr.GetDateTime(o);
            }

            this.windows = (this.username.IndexOf('\\') >= 0);

            return o;
        }

        public void CreateLogin()
        {
            try
            {
                LogEntry log = new LogEntry(context, null, LogOperations.CreateLogin);

                string sql = "spCreateUser";
                using (SqlCommand cmd = CreateStoredProcedureCommand(sql))
                {
                    cmd.Parameters.Add("@EntityGUID", SqlDbType.UniqueIdentifier).Value = guid;
                    cmd.Parameters.Add("@Username", SqlDbType.NVarChar, 50).Value = username;
                    cmd.ExecuteNonQuery();
                }

                if (!windows)
                {

                    sql = "CREATE LOGIN [" + username + "] WITH PASSWORD='" + password + "'";
                    using (SqlCommand cmd = CreateTextCommand(sql))
                        cmd.ExecuteNonQuery();

                    sql = "CREATE USER [" + username + "]";
                    using (SqlCommand cmd = CreateTextCommand(sql))
                        cmd.ExecuteNonQuery();

                    context.Commit();

                    sql = "sp_addrolemember";
                    using (SqlCommand cmd = CreateStoredProcedureCommand(sql))
                    {
                        cmd.Transaction = null;
                        cmd.Parameters.Add("@rolename", SqlDbType.NVarChar, 50).Value = "ContactoUser";
                        cmd.Parameters.Add("@membername", SqlDbType.NVarChar, 50).Value = username;
                        cmd.ExecuteNonQuery();
                    }

                    context.BeginTransaction();
                }

                log.WriteOkEntry();
            }
            catch (System.Exception ex)
            {
                throw new DBIOException(DBIOMessages.CreateLoginFailed, ex);
            }
        }

        public void DeleteLogin()
        {
            try
            {
                LogEntry log = new LogEntry(context, null, LogOperations.DeleteLogin);

                string sql = "spDeleteUser";
                using (SqlCommand cmd = CreateStoredProcedureCommand(sql))
                {
                    cmd.Parameters.Add("@EntityGUID", SqlDbType.UniqueIdentifier).Value = guid;
                    cmd.ExecuteNonQuery();
                }

                if (!windows)
                {

                    sql = "DROP LOGIN [" + username + "]";
                    using (SqlCommand cmd = CreateTextCommand(sql))
                        cmd.ExecuteNonQuery();

                    sql = "DROP USER [" + username + "]";
                    using (SqlCommand cmd = CreateTextCommand(sql))
                        cmd.ExecuteNonQuery();
                }

                log.WriteOkEntry();
            }
            catch (System.Exception ex)
            {
                throw new DBIOException(DBIOMessages.DeleteLoginFailed, ex);
            }
        }

        #endregion
    }
}
