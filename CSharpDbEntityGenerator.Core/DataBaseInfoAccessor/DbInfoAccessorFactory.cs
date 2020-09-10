using System;

using CSharpDbEntityGenerator.Core.DataBaseInfoAccessor.SqlServer;
using CSharpDbEntityGenerator.Core.Model;

namespace CSharpDbEntityGenerator.Core.DataBaseInfoAccessor
{
    /// <summary>
    /// 用于创建获取数据库信息访问器的工厂
    /// </summary>
    public class DbInfoAccessorFactory
    {
        /// <summary>
        /// 获取数据库信息访问器
        /// </summary>
        /// <param name="dbType"></param>
        /// <returns></returns>
        public static IInfoAccessor GetDbInfoAccessor(DbType dbType)
        {
            switch(dbType)
            {
                case DbType.SqlServer:
                    return new SqlServerInfoAccessor();
                default:
                    throw new NotSupportedException("目前仅支持SqlServer数据库");
            }
        }
    }
}