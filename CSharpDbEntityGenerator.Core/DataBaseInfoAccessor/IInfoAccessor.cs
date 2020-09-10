using System;
using System.Collections.Generic;

namespace CSharpDbEntityGenerator.Core.DataBaseInfoAccessor
{
    /// <summary>
    /// 数据库信息访问器
    /// </summary>
    public interface IInfoAccessor
    {
        /// <summary>
        /// 获取服务器上所有的数据库名称
        /// </summary>
        /// <param name="serverAddress">数据库服务器地址</param>
        /// <returns></returns>
        List<string> GetDatabases(string serverAddress);

        /// <summary>
        /// 获取指定数据库的表名
        /// </summary>
        /// <param name="serverAddress">数据库服务器地址</param>
        /// <param name="dbName">数据库名称</param>
        /// <returns></returns>
        List<string> GetDatabaseTables(string serverAddress, string dbName);

        /// <summary>
        /// 获取指定数据库指定表
        /// </summary>
        /// <param name="serverAddress">数据库服务器地址</param>
        /// <param name="dbName">数据库名称</param>
        /// <param name="tableName">数据库表名称</param>
        /// <returns></returns>
        List<string> GetDatabaseTableColumns(string serverAddress, string dbName, string tableName);
    }
}
