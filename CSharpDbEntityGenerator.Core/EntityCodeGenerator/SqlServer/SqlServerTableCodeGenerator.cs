using System.Collections.Generic;

using CSharpDbEntityGenerator.Core.Model;

namespace CSharpDbEntityGenerator.Core.EntityCodeGenerator.SqlServer
{
    public class SqlServerTableCodeGenerator : IDbTableCodeGenerator
    {
        /// <inheritdoc />
        public string Generate(string tableName, List<ColumnInfo> columns)
        {
            return string.Empty;
        }
    }
}