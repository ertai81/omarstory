using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OmarStory.DBQueries
{
    public class DbSession : IDisposable
    {
        public bool _disposed;
        public IDbConnection Connection { get; private set; }
        public IDbTransaction Transaction { get; private set; }

        public DbSession(IDbConnection cnn, bool beginTransaction)
        {
            Connection = cnn;
            if (Connection.State == ConnectionState.Closed) { Connection.Open(); }
            if (beginTransaction) { Transaction = Connection.BeginTransaction(); }
        }

        public void BeginTransaction()
        {
            if (Transaction == null)
                Transaction = Connection.BeginTransaction();
        }

        public void BeginTransaction(IsolationLevel il)
        {
            if (Transaction == null)
                Transaction = Connection.BeginTransaction(il);
        }

        ~DbSession()
        {
            Dispose(false);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    if (Connection != null && Connection.State != ConnectionState.Closed)
                    {
                        if (Transaction != null)
                            Transaction.Dispose();

                        Connection.Dispose();
                    }
                }
            }
            _disposed = true;
        }
    }
}
