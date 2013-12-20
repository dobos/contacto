using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace Contacto.Lib
{
    public abstract class ObjectBase
    {
        #region Member variables

        protected Context context;

        #endregion
        #region Properties

        public Context Context
        {
            get
            {
                return this.context;
            }
            set
            {
                this.context = value;
            }
        }

        #endregion
        #region Costructors

        public ObjectBase()
        {
            InitializeMembers();
        }

        public ObjectBase(Context context)
        {
            InitializeMembers();

            this.context = context;
        }

        public ObjectBase(ObjectBase old)
        {
            CopyMembers(old);
        }

        #endregion
        #region Initializers

        private void InitializeMembers()
        {
            this.context = null;
        }

        private void CopyMembers(ObjectBase old)
        {
            this.context = old.context;
        }

        #endregion
        #region Data access utility functions

        protected SqlCommand CreateStoredProcedureCommand(string sql)
        {
            SqlCommand cmd = new SqlCommand(sql, context.Connection, context.Transaction);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandTimeout = 120;   //*****
            return cmd;
        }

        protected SqlCommand CreateTextCommand()
        {
            return CreateTextCommand(string.Empty);
        }

        protected SqlCommand CreateTextCommand(string sql)
        {
            SqlCommand cmd = new SqlCommand(sql, context.Connection, context.Transaction);
            cmd.CommandType = CommandType.Text;
            return cmd;
        }

        #endregion
    }
}
