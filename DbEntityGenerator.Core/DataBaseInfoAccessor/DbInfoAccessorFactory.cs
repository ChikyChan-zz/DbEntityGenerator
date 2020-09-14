using System;

using DbEntityGenerator.Core.DataBaseInfoAccessor.SqlServer;
using DbEntityGenerator.Core.Model;

namespace DbEntityGenerator.Core.DataBaseInfoAccessor
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
        /// <param name="server">数据库服务器</param>
        /// <param name="userName">登录用户名</param>
        /// <param name="password">登录密码</param>
        /// <returns></returns>
        public static IDbInfoAccessor GetDbInfoAccessor(DbType dbType, string server, string userName, string password)
        {
            switch (dbType)
            {
                case DbType.SqlServer:
                    return new SqlServerInfoAccessor(server, userName, password);
                default:
                    throw new NotSupportedException("目前仅支持SqlServer数据库");
            }
        }
    }
}