using System;
using System.Collections.Generic;
using System.Data;

using DbEntityGenerator.Core.Model;

namespace DbEntityGenerator.Core.DataBaseInfoAccessor
{
    /// <summary>
    /// 数据库信息访问器
    /// </summary>
    public interface IDbInfoAccessor
    {
        /// <summary>
        /// 服务器IP
        /// </summary>
        /// <value></value>
        string Server { set; }

        /// <summary>
        /// 登录用户名
        /// </summary>
        /// <value></value>
        string UserName { set; }

        /// <summary>
        /// 登录密码
        /// </summary>
        /// <value></value>
        string Password { set; }

        /// <summary>
        /// 获取服务器上所有的数据库名称
        /// </summary>
        /// <returns></returns>
        List<string> GetDatabases();

        /// <summary>
        /// 获取指定数据库的表名
        /// </summary>
        /// <param name="dbName">数据库名称</param>
        /// <returns></returns>
        List<TableInfo> GetDatabaseTables(string dbName);

        /// <summary>
        /// 获取指定数据库指定表
        /// </summary>
        /// <param name="dbName">数据库名称</param>
        /// <param name="schemaName">数据库表所属架构</param>
        /// <param name="tableName">数据库表名称</param>
        /// <returns></returns>
        List<ColumnInfo> GetDatabaseTableColumns(string dbName, string schemaName, string tableName);
    }
}
