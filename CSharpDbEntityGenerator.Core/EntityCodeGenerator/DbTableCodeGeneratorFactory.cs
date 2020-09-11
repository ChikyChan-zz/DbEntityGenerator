using System;

using CSharpDbEntityGenerator.Core.Model;
using CSharpDbEntityGenerator.Core.EntityCodeGenerator.SqlServer;

namespace CSharpDbEntityGenerator.Core.EntityCodeGenerator
{
    public class DbTableCodeGeneratorFactory
    {
        /// <summary>
        /// 获取实体类生成器
        /// </summary>
        /// <param name="dbType">数据库类型</param>
        /// <returns></returns>
        public static IDbTableCodeGenerator GetDbTableCodeGenerator(DbType dbType)
        {
            switch (dbType)
            {
                case DbType.SqlServer:
                    return new SqlServerTableCodeGenerator();
                default:
                    throw new NotSupportedException();
            }
        }
    }
}