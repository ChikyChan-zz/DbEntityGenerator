using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

using Microsoft.Data.SqlClient;

using DbEntityGenerator.Core.Model;

namespace DbEntityGenerator.Core.DataBaseInfoAccessor.SqlServer
{
    /// <summary>
    /// Sql Server数据库信息访问器
    /// </summary>
    public class SqlServerInfoAccessor : BaseInfoAccessor
    {
        private readonly string ConnectionString;

        /// <inheritdoc />
        public SqlServerInfoAccessor(string server, string userName, string password) : base(server, userName, password)
        {
            var connectionStringBuilder = new SqlConnectionStringBuilder()
            {
                DataSource = Server,
                UserID = UserName,
                Password = Password
            };

            ConnectionString = connectionStringBuilder.ConnectionString;
        }

        /// <inheritdoc />
        public override List<string> GetDatabases()
        {
            const string GET_DATABASE_SQL = "SELECT name FROM MASTER.DBO.SYSDATABASES";

            var result = new List<string>();

            using (var conn = new SqlConnection(ConnectionString))
            {
                try
                {
                    conn.Open();
                    using (var cmd = new SqlCommand(GET_DATABASE_SQL, conn))
                    {
                        using (var adapter = new SqlDataAdapter(cmd))
                        {
                            using (var dt = new DataTable())
                            {
                                adapter.Fill(dt);

                                foreach (DataRow row in dt.Rows)
                                {
                                    result.Add(row["name"] as string);
                                }
                            }
                        }
                    }
                }
                finally
                {
                    conn.Close();
                }
            }
            return result;
        }

        /// <inheritdoc />
        public override List<TableInfo> GetDatabaseTables(string dbName)
        {
            const string GET_TABLE_SQL = "SELECT TABLE_SCHEMA, TABLE_NAME FROM {0}.INFORMATION_SCHEMA.TABLES WHERE TABLE_TYPE = 'BASE TABLE';";
            const string GET_TABLE_OBJECT_ID_SQL = "SELECT '{0}' AS TableName, object_id('{0}') AS [object_id]";

            const string GET_TABLE_DESCRIPTION_SQL = @"
SELECT i.TableName, p.value AS Description
FROM {0}.sys.extended_properties p
JOIN ({1}) i ON p.major_id = i.object_id
WHERE p.name = 'MS_Description' AND p.class = 1 AND p.minor_id = 0;";

            var result = new List<TableInfo>();

            using (var conn = new SqlConnection(ConnectionString))
            {
                try
                {
                    conn.Open();
                    using (var cmd = new SqlCommand(string.Format(GET_TABLE_SQL, dbName), conn))
                    {
                        using (var adapter = new SqlDataAdapter(cmd))
                        {
                            using (var dt = new DataTable())
                            {
                                adapter.Fill(dt);

                                foreach (DataRow row in dt.Rows)
                                {
                                    result.Add(new TableInfo()
                                    {
                                        TableSchema = row["TABLE_SCHEMA"] as string,
                                        TableName = row["TABLE_NAME"] as string
                                    });
                                }
                            }
                        }
                    }

                    var tableIdSql = result.Select(t => string.Format(GET_TABLE_OBJECT_ID_SQL, string.Concat(dbName, ".", t.TableSchema, ".", t.TableName))).ToList();

                    using (var cmd = new SqlCommand(string.Format(GET_TABLE_DESCRIPTION_SQL, dbName, string.Join(" UNION ", tableIdSql)), conn))
                    {
                        using (var adapter = new SqlDataAdapter(cmd))
                        {
                            using (var dt = new DataTable())
                            {
                                adapter.Fill(dt);

                                foreach (DataRow row in dt.Rows)
                                {
                                    var tableName = row["TableName"] as string;
                                    var description = row["Description"] as string;

                                    var tableInfo = result.FirstOrDefault(t => string.Concat(dbName, ".", t.TableSchema, ".", t.TableName) == tableName);
                                    if (tableInfo != null)
                                    {
                                        tableInfo.Description = description;
                                    }
                                }
                            }
                        }
                    }
                }
                finally
                {
                    conn.Close();
                }
            }

            return result;
        }

        /// <inheritdoc />
        public override List<ColumnInfo> GetDatabaseTableColumns(string dbName, string schemaName, string tableName)
        {
            const string GET_COLUMN_DESCRIPTION_SQL = @"
SELECT c.name AS ColumnName, p.value AS Description
FROM {0}.sys.extended_properties p
JOIN {0}.sys.columns c ON p.minor_id = c.column_id AND p.major_id = c.object_id
WHERE p.name = 'MS_Description' AND p.class = 1 AND p.major_id = object_id('{0}.{1}.{2}');";

            var result = new List<ColumnInfo>();

            using (var conn = new SqlConnection(ConnectionString))
            {
                try
                {
                    conn.Open();

                    using (var cmd = new SqlCommand(string.Format("SELECT TOP 1 * FROM {0}.{1}.{2}", dbName, schemaName, tableName), conn))
                    {
                        using (var adapter = new SqlDataAdapter(cmd))
                        {
                            using (var dt = new DataTable())
                            {
                                adapter.FillSchema(dt, SchemaType.Mapped);

                                foreach (DataColumn column in dt.Columns)
                                {
                                    result.Add(new ColumnInfo() { ColumnName = column.ColumnName, DataType = column.DataType, Nullable = column.AllowDBNull });
                                }
                            }
                        }
                    }

                    using (var cmd = new SqlCommand(string.Format(GET_COLUMN_DESCRIPTION_SQL, dbName, schemaName, tableName), conn))
                    {
                        using (var adapter = new SqlDataAdapter(cmd))
                        {
                            using (var dt = new DataTable())
                            {
                                adapter.Fill(dt);

                                foreach (DataRow row in dt.Rows)
                                {
                                    var columnName = row["ColumnName"] as string;
                                    var description = row["Description"] as string;

                                    var columnInfo = result.FirstOrDefault(c => c.ColumnName == columnName);
                                    if (columnInfo != null)
                                    {
                                        columnInfo.Description = description;
                                    }
                                }
                            }
                        }
                    }
                }
                finally
                {
                    conn.Close();
                }
            }

            return result;
        }
    }
}