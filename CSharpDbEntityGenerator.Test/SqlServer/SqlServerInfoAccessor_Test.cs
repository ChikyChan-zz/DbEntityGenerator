using System;
using System.Linq;

using Xunit;

using CSharpDbEntityGenerator.Core.DataBaseInfoAccessor;
using CSharpDbEntityGenerator.Core.Model;

namespace CSharpDbEntityGenerator.Test.SqlServer
{
    public class SqlServerInfoAccessor_Test
    {
        private IDbInfoAccessor GetDbInfoAccessor()
        {
            var server = ".,1433";
            var userName = "ChikyChan";
            var password = "daxueJIAYOU01";

            return DbInfoAccessorFactory.GetDbInfoAccessor(DbType.SqlServer, server, userName, password);
        }

        [Fact]
        public void GetDatabases_Test()
        {
            var accessor = GetDbInfoAccessor();

            var dbNames = accessor.GetDatabases();

            Assert.True(dbNames.Contains("AdventureWorks2017"));
        }

        [Fact]
        public void GetDatabaseTables_Tes()
        {
            var accessor = GetDbInfoAccessor();

            var tables = accessor.GetDatabaseTables("AdventureWorks2017");

            Assert.True(tables.Any(t => t.TableName == "EmployeePayHistory" && t.TableSchema == "HumanResources" && t.Description == "Employee pay history."));
        }

        [Fact]
        public void GetDatabaseTableColumns_Test()
        {
            var accessor = GetDbInfoAccessor();

            var columns = accessor.GetDatabaseTableColumns("AdventureWorks2017", "HumanResources", "EmployeePayHistory");

            Assert.True(columns.Any(c => c.ColumnName == "BusinessEntityID" && c.DataType == typeof(int) && !c.Nullable && c.Description == "Employee identification number. Foreign key to Employee.BusinessEntityID."));
        }
    }
}