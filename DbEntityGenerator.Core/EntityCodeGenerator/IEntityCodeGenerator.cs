using System.Collections.Generic;

using DbEntityGenerator.Core.Model;

namespace DbEntityGenerator.Core.EntityCodeGenerator
{
    public interface IEntityCodeGenerator
    {
        /// <summary>
        /// 生成实体类代码
        /// </summary>
        /// <param name="tableInfo">表信息</param>
        /// <param name="columns">表列</param>
        /// <returns></returns>
        string Generate(TableInfo tableInfo, List<ColumnInfo> columns);
    }
}