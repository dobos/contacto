using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;

namespace Contacto.Lib
{
    public class Context : IDisposable
    {
        public User User = null;
        public Company Company = null;

        public DateTime DateLimitFrom;
        public DateTime DateLimitTo;
        public bool ShowHidden;
        public bool ShowDeleted;
        public bool ShowClosed;

        public Contacto.Lib.Directory Templates;

        public SqlConnection Connection;
        public SqlTransaction Transaction;
        public SchemaManager SchemaManager;
        public CheckOutManager CheckoutManager;

        public Guid UserGuid
        {
            get
            {
                if (User != null)
                    return User.Guid;
                else
                    return Guid.Empty;
            }
        }

        public void BeginTransaction()
        {
            Transaction = Connection.BeginTransaction();
        }

        public void Commit()
        {
            if (Transaction != null)
            {
                Transaction.Commit();
                Transaction.Dispose();
                Transaction = null;
            }

            //if (Connection != null)
            //{
            //    Connection.Close();
            //    Connection.Dispose();
            //    Connection = null;
            //}
        }

        public void Rollback()
        {
            if (Transaction != null)
            {
                Transaction.Rollback();
                Transaction.Dispose();
                Transaction = null;
            }

            //if (Connection != null)
            //{
            //    Connection.Close();
            //    Connection.Dispose();
            //    Connection = null;
            //}
        }

        public void Close()
        {
            if (Connection != null)
            {
                Connection.Close();
                Connection.Dispose();
                Connection = null;
            }
        }

        #region IDisposable Members

        public void Dispose()
        {
            Commit();
            Close();
        }

        #endregion
    }
}
