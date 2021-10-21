using Core.Entities;
using Core.Subcriptions.Abstract;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TableDependency.SqlClient;

namespace Core.Subcriptions.SqlTableDependency
{
    public abstract class BaseDatabaseSubscription<T> : IDatabaseSubscription where T:class,IEntity, new()
    {
        SqlTableDependency<T> _tableDependency;

        string _connectionString;

        public BaseDatabaseSubscription(string connectionString)
        {
            _connectionString = connectionString;

        }

        public void Configure(string tableName)
        {
            _tableDependency = new SqlTableDependency<T>(_connectionString,tableName);
            _tableDependency.OnChanged += OnChange;
            _tableDependency.OnError += OnError;
            _tableDependency.Start();
        }

        protected virtual void OnError(object sender, TableDependency.SqlClient.Base.EventArgs.ErrorEventArgs e)
        {
        }

        protected virtual void OnChange(object sender, TableDependency.SqlClient.Base.EventArgs.RecordChangedEventArgs<T> e)
        {

        }

        ~BaseDatabaseSubscription()
        {
            _tableDependency.Stop();
        }
    }
}
