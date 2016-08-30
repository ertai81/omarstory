using OmarStory.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace OmarStory.DBQueries
{
    public static class DbContext
    {
        public static IDbConnection OpenConnection(string provider, string connectionString)
        {
            if (provider == "MySql.Data.MySqlClient")
                connectionString = Crypto.DecryptStringAES(connectionString, "ogZ7aYQCv6zCky");

            var cnn = DbProviderFactories.GetFactory(provider).CreateConnection();
            cnn.ConnectionString = connectionString;
            cnn.Open();
            return cnn;
        }

        public static DbSession OpenSession(string provider, string connectionString, bool beginTransaction = true)
        {
            return new DbSession(OpenConnection(provider, connectionString), beginTransaction);
        }

        /// <summary>Convenience method to execute SELECT queries</summary>
        public static IEnumerable<IDataReader> ExecuteReader(IDbConnection cnn, string query)
        {
            using (var command = cnn.CreateCommand())
            {
                command.CommandText = query;
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        yield return reader;
                    }
                }
            }
        }
        public static object ExecuteScalar(IDbConnection cnn, string query)
        {
            using (var command = cnn.CreateCommand())
            {
                command.CommandText = query;
                return command.ExecuteScalar();
            }
        }
        public static int ExecuteNonQuery(IDbConnection cnn, string sql)
        {
            using (var command = cnn.CreateCommand())
            {
                command.CommandText = sql;
                return command.ExecuteNonQuery();
            }
        }

        /// <summary>Valid only for SQLite and MySQL providers. SQLite is UTC while MySQL is local.</summary>
        public static DateTime GetCurrentTimestamp(IDbConnection cnn, string provider)
        {
            if (provider == "System.Data.SQLite")
            {
                return DateTime.Parse(ExecuteScalar(cnn, "SELECT datetime('now')").ToString());
            }
            else if (provider == "MySql.Data.MySqlClient")
            {
                return DateTime.Parse(ExecuteScalar(cnn, "SELECT NOW()").ToString());
            }
            throw new Exception("Unknown provider");
        }

        public static void CreateSQLiteDatabase<T>(IDbConnection cnn)
        {
            var sqliteTypeMappings = new Dictionary<Type, string>()
            {
                { typeof(int),      "INT" },
                { typeof(long),     "INTEGER" },
                { typeof(uint),     "INT UNSIGNED" },
                { typeof(ulong),    "INTEGER UNSIGNED" },
                { typeof(string),   "TEXT" },
                { typeof(float),    "REAL" },
                { typeof(double),   "DOUBLE" },
                { typeof(bool),     "BOOLEAN" },
                { typeof(DateTime), "DATETIME" }
            };

            using (var command = cnn.CreateCommand())
            {
                var tables = new List<PropertyInfo>();
                foreach (var prop in typeof(T).GetProperties())
                {
                    if (Attribute.IsDefined(prop, typeof(DbTableAttribute)))
                        tables.Add(prop);
                }

                foreach (var tableProp in tables)
                {
                    var tabletype = tableProp.PropertyType;
                    var commandText = new System.Text.StringBuilder();
                    commandText.AppendFormat("CREATE TABLE [{0}] (", tabletype.Name);

                    var pkeys = new List<string>();
                    var indexes = new List<string>();
                    var colProps = tabletype.GetProperties();

                    for (int i = 0; i < colProps.Length; i++)
                    {
                        if (!Attribute.IsDefined(colProps[i], typeof(DbColumnAttribute)))
                            continue;

                        var att = (DbColumnAttribute)colProps[i].GetCustomAttributes(typeof(DbColumnAttribute), false)[0];
                        if (att.IsIndexed) { indexes.Add(colProps[i].Name); }
                        if (att.IsPrimaryKey && !att.IsAutoIncrement) { pkeys.Add(colProps[i].Name); }

                        string type = "TEXT";
                        if (sqliteTypeMappings.ContainsKey(colProps[i].PropertyType))
                        {
                            type = sqliteTypeMappings[colProps[i].PropertyType];
                        }
                        else if (colProps[i].PropertyType.IsEnum)
                        {
                            type = "INT";
                        }

                        commandText.AppendFormat
                        (
                            "[{0}] {1}{2}{3}{4}, ",
                            colProps[i].Name,
                            type,
                            att.IsAutoIncrement ? " PRIMARY KEY AUTOINCREMENT " : "",
                            att.IsNotNull ? " NOT NULL " : "",
                            att.IsUnique ? " UNIQUE " : "",
                            !string.IsNullOrEmpty(att.DefaultValue) ? string.Format(" DEFAULT {0} ", att.DefaultValue) : ""
                        );
                    }
                    commandText.Remove(commandText.Length - 2, 2); // Remove last comma

                    if (pkeys.Count > 0)
                    {
                        commandText.Append(", PRIMARY KEY (");
                        for (int i = 0; i < pkeys.Count; i++)
                            commandText.AppendFormat("[{0}]{1}", pkeys[i], i < pkeys.Count - 1 ? ", " : ")");
                    }

                    commandText.Append(")");
                    command.CommandText = commandText.ToString();
                    command.ExecuteNonQuery();

                    foreach (string index in indexes)
                    {
                        command.CommandText = string.Format("CREATE INDEX [{0}_{1}_idx] ON [{0}] ([{1}])", tabletype.Name, index);
                        command.ExecuteNonQuery();
                    }
                }
            }
        }

    }
}
