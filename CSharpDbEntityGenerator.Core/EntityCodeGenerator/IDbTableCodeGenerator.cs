using System.Collections.Generic;

using CSharpDbEntityGenerator.Core.Model;

namespace CSharpDbEntityGenerator.Core.EntityCodeGenerator
{
    public interface IDbTableCodeGenerator
    {
        /// <summary>
        /// 生成实体类代码
        /// </summary>
        /// <param name="tableName">表名</param>
        /// <param name="columns">表列</param>
        /// <returns></returns>
        string Generate(string tableName, List<ColumnInfo> columns);
    }
}