using System;
using System.Collections.Generic;
using System.Data;

using CSharpDbEntityGenerator.Core.Model;

namespace CSharpDbEntityGenerator.Core.DataBaseInfoAccessor
{
    /// <summary>
    /// 定义数据库信息访问器的基类
    /// </summary>
    public abstract class BaseInfoAccessor : IDbInfoAccessor
    {
        /// <summary>
        /// 服务器IP
        /// </summary>
        /// <value></value>
        public string Server { protected get; set; }

        /// <summary>
        /// 登录用户名
        /// </summary>
        /// <value></value>
        public string UserName { protected get; set; }

        /// <summary>
        /// 登录密码
        /// </summary>
        /// <value></value>
        public string Password { protected get; set; }

        /// <summary>
        /// 创建一个IInfoAccessor类型的实例
        /// </summary>
        /// <param name="server">数据库服务器</param>
        /// <param name="userName">登录用户名</param>
        /// <param name="password">登录密码</param>
        public BaseInfoAccessor(string server, string userName, string password)
        {
            Server = server;
            UserName = userName;
            Password = password;
        }

        /// <inheritdoc />
        public abstract List<string> GetDatabases();

        /// <inheritdoc />
        public abstract List<TableInfo> GetDatabaseTables(string dbName);

        /// <inheritdoc />
        public abstract List<ColumnInfo> GetDatabaseTableColumns(string dbName, string schemaName, string tableName);
    }
}