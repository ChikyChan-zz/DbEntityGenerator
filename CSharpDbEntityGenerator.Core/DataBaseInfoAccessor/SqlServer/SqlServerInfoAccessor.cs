using System;
using System.Collections.Generic;

using Microsoft.Data.SqlClient;

namespace CSharpDbEntityGenerator.Core.DataBaseInfoAccessor.SqlServer
{
    /// <summary>
    /// Sql Server数据库信息访问器
    /// </summary>
    public class SqlServerInfoAccessor : IInfoAccessor
    {
        /// <inheritdoc />
        public List<string> GetDatabases(string serverAddress)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        public List<string> GetDatabaseTables(string serverAddress, string dbName)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        public List<string> GetDatabaseTableColumns(string serverAddress, string dbName, string tableName)
        {
            throw new NotImplementedException();
        }
    }
}