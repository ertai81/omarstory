using OmarStory.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace OmarStory.DBQueries
{
    #region Utility Classes (Dbcolumns, DbValues, DbCondition)
    public class DbColumns
    {
        public IList<string> Columns { get; private set; }

        /// <summary>
        /// Separate the columns (case-sensitive) with commas, like "Id, Value, Timestamp". 
        /// You can use spaces with the commas but not in the column names.
        /// </summary>
        public DbColumns(string columns)
        {
            Columns = columns.Replace(" ", "").Split(',');
        }

        public DbColumns(params string[] columns)
        {
            Columns = columns;
        }
    }

    public class DbValues
    {
        private IDictionary<string, object> _dictionary;
        public object this[string column]
        {
            get { return _dictionary[column]; }
        }
        public IEnumerable<string> Columns
        {
            get { return _dictionary.Keys; }
        }
        public IEnumerable<object> Values
        {
            get { return _dictionary.Values; }
        }
        public int Count
        {
            get { return _dictionary.Count; }
        }

        /// <summary>
        /// Separate the columns (case-sensitive) with commas, like "Id, Value, Timestamp". 
        /// You can use spaces with the commas but not in the column names.
        /// </summary>
        public DbValues(string columns, params object[] values)
        {
            var columnArray = columns.Replace(" ", "").Split(',');
            if (columnArray.Length != values.Length)
            {
                throw new Exception("DbValues: columns and values must have the same length.");
            }
            else
            {
                _dictionary = new Dictionary<string, object>();
                for (int i = 0; i < columnArray.Length; i++)
                    _dictionary.Add(columnArray[i], values[i]);
            }
        }

        public bool Contains(string column)
        {
            return _dictionary.Keys.Contains(column);
        }
    }

    public class DbCondition
    {
        public string Condition { get; private set; }
        public object[] Parameters { get; private set; }

        /// <summary>
        /// Write the condition with question marks for parameters 
        /// (parameters can also be null), like: "Timestamp>?"
        /// </summary>
        public DbCondition(string condition, params object[] parameters)
        {
            Condition = condition;
            Parameters = parameters;
        }

        public override string ToString()
        {
            return Condition;
        }
    }
    #endregion

    public static class DbTable<T> where T : new()
    {
        #region Private Methods
        private static void addParameter(IDbCommand command, string name = null, object value = null)
        {
            var par = command.CreateParameter();

            if (name != null) { par.ParameterName = name; }
            if (value != null) { setParameterValue(par, value); }

            command.Parameters.Add(par);
        }

        private static void setParameterValue(IDbCommand command, string name, object value)
        {
            setParameterValue(command.Parameters[name] as IDbDataParameter, value);
        }

        private static void setParameterValue(IDbCommand command, int index, object value)
        {
            setParameterValue(command.Parameters[index] as IDbDataParameter, value);
        }

        private static void setParameterValue(IDbDataParameter parameter, object value)
        {
            if (parameter != null)
            {
                if (value != null)
                {
                    var type = value.GetType();
                    if (type.GetCustomAttributes(typeof(XmlSerializableAttribute), false).Length > 0)
                    {
                        using (var textWriter = new StringWriter())
                        {
                            var serializer = new XmlSerializer(value.GetType());
                            serializer.Serialize(textWriter, value);
                            value = textWriter.ToString();
                        }
                    }
                    else if (type == typeof(DateTime))
                    {
                        value = ((DateTime)value).ToUniversalTime();
                    }
                }
                parameter.Value = value;
            }
        }

        private static T convertReader(IDataReader reader, IList<PropertyInfo> columns,
                                       IList<PropertyInfo> xmlSerializableColumns = null)
        {
            object item = new T(); // Boxing is necessary to make SetValue() work properly with structs

            foreach (var col in columns)
            {
                var value = reader[col.Name];
                if (!DBNull.Value.Equals(value))
                {
                    if (xmlSerializableColumns != null && xmlSerializableColumns.Contains(col))
                    {
                        using (var textReader = new StringReader(value.ToString()))
                        {
                            var serializer = new XmlSerializer(col.PropertyType);
                            col.SetValue(item, serializer.Deserialize(textReader), null);
                        }
                    }
                    else if (col.PropertyType == typeof(DateTime))
                    {
                        col.SetValue(item, ((DateTime)value).ToUniversalTime(), null);
                    }
                    else
                    {
                        col.SetValue(item, Convert.ChangeType(value, col.PropertyType), null);
                    }
                }
            }

            return (T)item;
        }

        private static string join<TArg>(string separator, IEnumerable<TArg> items)
        {
            bool first = true;
            var builder = new System.Text.StringBuilder();

            foreach (TArg item in items)
            {
                if (first)
                    first = false;
                else
                    builder.Append(separator);

                builder.Append(item);
            }

            return builder.ToString();
        }
        #endregion

        #region Getters
        public static IEnumerable<PropertyInfo> GetColumns()
        {
            foreach (var prop in typeof(T).GetProperties())
            {
                if (Attribute.IsDefined(prop, typeof(DbColumnAttribute)))
                    yield return prop;
            }
        }

        public static IEnumerable<PropertyInfo> GetXmlSerializableColumns(IEnumerable<PropertyInfo> columns)
        {
            foreach (var col in columns)
            {
                if (Attribute.IsDefined(col.PropertyType, typeof(XmlSerializableAttribute)))
                    yield return col;
            }
        }

        public static IEnumerable<string> GetPrimaryKeys(IEnumerable<PropertyInfo> columnProperties)
        {
            foreach (var prop in columnProperties)
            {
                var att = (DbColumnAttribute)prop.GetCustomAttributes(typeof(DbColumnAttribute), false)[0];
                if (att.IsPrimaryKey)
                    yield return prop.Name;
            }
        }
        #endregion

        #region Select Methods
        public static IEnumerable<T> Select(IDbConnection connection, DbColumns columns = null, DbCondition condition = null)
        {
            var myColumns = new List<PropertyInfo>();
            foreach (var col in GetColumns())
            {
                if (columns == null || columns.Columns.Count == 0 || columns.Columns.Contains(col.Name))
                    myColumns.Add(col);
            }

            using (var command = connection.CreateCommand())
            {
                command.CommandText = string.Format
                (
                    "SELECT {0} FROM {1} {2}",
                    columns == null || columns.Columns.Count == 0 ? "*" : join(",", columns.Columns),
                    typeof(T).Name,
                    condition == null ? "" : "WHERE " + condition.Condition
                );

                //Raise the Timeout
                //command.CommandTimeout = 60;

                if (condition != null)
                {
                    foreach (var obj in condition.Parameters)
                        addParameter(command, value: obj);
                }

                var xmlSerializableColumns = GetXmlSerializableColumns(myColumns).ToList();
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                        yield return convertReader(reader, myColumns, xmlSerializableColumns);
                }
            }
        }

        public static IEnumerable<T> SelectJoinStatusData(IDbConnection connection, DbColumns columns = null, DbCondition condition = null)
        {
            var myColumns = new List<PropertyInfo>();
            foreach (var col in GetColumns())
            {
                if (columns == null || columns.Columns.Count == 0 || columns.Columns.Contains(col.Name))
                    myColumns.Add(col);
            }

            using (var command = connection.CreateCommand())
            {
                command.CommandText = string.Format
                (
                    "SELECT {0} FROM {1} t1 JOIN (SELECT ProjectId, RowId, ColId, Username, MAX(Timestamp) Timestamp FROM StatusData {2}",
                    columns == null || columns.Columns.Count == 0 ? "*" : join(",", columns.Columns),
                    typeof(T).Name,
                    condition == null ? "" : "WHERE " + condition.Condition
                );

                //Raise the Timeout
                //command.CommandTimeout = 60;

                if (condition != null)
                {
                    foreach (var obj in condition.Parameters)
                        addParameter(command, value: obj);
                }

                var xmlSerializableColumns = GetXmlSerializableColumns(myColumns).ToList();
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                        yield return convertReader(reader, myColumns, xmlSerializableColumns);
                }
            }
        }

        public static T Select(IDbConnection connection, params object[] primaryKeys)
        {
            var myColumns = GetColumns().ToList();
            var myPrimaryKeys = GetPrimaryKeys(myColumns).ToList();

            if (primaryKeys.Length != myPrimaryKeys.Count)
                throw new ArgumentException("primaryKeys wrong size");

            using (var command = connection.CreateCommand())
            {
                command.CommandText = string.Format("SELECT * FROM {0} WHERE {1}=?",
                                                    typeof(T).Name, join("=? AND ", myPrimaryKeys));

                //Raise the Timeout
                //command.CommandTimeout = 60;

                for (int i = 0; i < myPrimaryKeys.Count; i++)
                    addParameter(command, value: primaryKeys[i]);

                var xmlSerializableColumns = GetXmlSerializableColumns(myColumns).ToList();
                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                        return convertReader(reader, myColumns, xmlSerializableColumns);
                }
            }

            throw new KeyNotFoundException();
        }

        public static IEnumerable<T> Select(IDbConnection connection, IEnumerable<object[]> primaryKeysCollection)
        {
            var myColumns = GetColumns().ToList();
            var myPrimaryKeys = GetPrimaryKeys(myColumns).ToList();

            using (var command = connection.CreateCommand())
            {
                command.CommandText = string.Format("SELECT * FROM {0} WHERE {1}=?",
                                                    typeof(T).Name,
                                                    join("=? AND ", myPrimaryKeys));

                //Raise the Timeout
                //command.CommandTimeout = 60;

                for (int i = 0; i < myPrimaryKeys.Count; i++)
                    addParameter(command);

                foreach (var pKeys in primaryKeysCollection)
                {
                    for (int i = 0; i < myPrimaryKeys.Count; i++)
                        setParameterValue(command, i, pKeys[i]);

                    var xmlSerializableColumns = GetXmlSerializableColumns(myColumns).ToList();
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                            yield return convertReader(reader, myColumns, xmlSerializableColumns);
                    }
                }
            }
            yield break;
        }

        public static IEnumerable<T> Select(IDbConnection connection, long projectId, string extraCondition = null)
        {
            DbColumns columns = new DbColumns();
            var myColumns = GetColumns().ToList();

            using (var command = connection.CreateCommand())
            {
                command.CommandText = string.Format("SELECT * FROM {0} WHERE ProjectId={1}",
                                                    typeof(T).Name, projectId.ToString());

                if (extraCondition != null)
                {
                    command.CommandText += String.Format(" AND {0}", extraCondition);
                }

                var xmlSerializableColumns = GetXmlSerializableColumns(myColumns).ToList();
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        yield return convertReader(reader, myColumns, xmlSerializableColumns);
                    }
                }
            }
        }

        public static IEnumerable<T> Select(IDbConnection connection, string query)
        {
            DbColumns columns = new DbColumns();
            var myColumns = GetColumns().ToList();

            using (var command = connection.CreateCommand())
            {
                command.CommandText = query;

                var xmlSerializableColumns = GetXmlSerializableColumns(myColumns).ToList();
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        yield return convertReader(reader, myColumns, xmlSerializableColumns);
                    }
                }
            }
        }

        public static T SelectOrDefault(IDbConnection cnn, object primaryKey)
        {
            return SelectOrDefault(cnn, new object[] { primaryKey });
        }

        public static T SelectOrDefault(IDbConnection cnn, object[] primaryKeys)
        {
            var myColumns = GetColumns().ToList();
            var myPrimaryKeys = GetPrimaryKeys(myColumns).ToList();

            if (primaryKeys != null && myPrimaryKeys.Count != primaryKeys.Length)
                throw new ArgumentException("primaryKeys wrong size");

            using (var command = cnn.CreateCommand())
            {
                command.CommandText = string.Format("SELECT * FROM {0} WHERE {1}=?",
                                                    typeof(T).Name, join("=? AND ", myPrimaryKeys));

                //Raise the Timeout
                //command.CommandTimeout = 60;

                foreach (object pkey in primaryKeys)
                    addParameter(command, value: pkey);

                var xmlSerializableColumns = GetXmlSerializableColumns(myColumns).ToList();
                using (var reader = command.ExecuteReader())
                {
                    return reader.Read() ? convertReader(reader, myColumns, xmlSerializableColumns) : default(T);
                }
            }
        }

        public static IEnumerable<IDataReader> SelectAsReader(IDbConnection cnn, DbCondition condition = null, params string[] columns)
        {
            using (var command = cnn.CreateCommand())
            {
                command.CommandText = string.Format("SELECT {0} FROM {1} {2}",
                                                    columns == null || columns.Length == 0 ? "*" : join(",", columns),
                                                    typeof(T).Name,
                                                    condition == null ? "" : "WHERE " + condition.Condition);

                //Raise the Timeout
                //command.CommandTimeout = 60;

                if (condition != null)
                {
                    foreach (object obj in condition.Parameters)
                        addParameter(command, value: obj);
                }

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                        yield return reader;
                }
            }
        }


        public static void Delete(IDbConnection connection, long projectId, string ExtraCondition = null)
        {
            using (var command = connection.CreateCommand())
            {
                command.CommandText = string.Format("DELETE FROM {0} WHERE ProjectId={1}",
                                                    typeof(T).Name, projectId.ToString());

                if (ExtraCondition != null)
                {
                    command.CommandText += " AND " + ExtraCondition;
                }

                IDataReader dr = command.ExecuteReader();
                dr.Close();
                return;
            }

            throw new KeyNotFoundException();
        }
        #endregion

        #region SQL Function Methods
        public static long Count(IDbConnection cnn, DbCondition condition = null)
        {
            using (var command = cnn.CreateCommand())
            {
                command.CommandText = string.Format("SELECT COUNT(*) FROM {0} {1}",
                                                    typeof(T).Name,
                                                    condition == null ? "" : "WHERE " + condition.Condition);
                if (condition != null)
                {
                    foreach (object obj in condition.Parameters)
                        addParameter(command, value: obj);
                }

                return (long)command.ExecuteScalar();
            }
        }

        public static int Max(IDbConnection cnn, string column, DbCondition condition = null)
        {
            using (var command = cnn.CreateCommand())
            {
                command.CommandText = string.Format("SELECT MAX({0}) FROM {1} {2}",
                                                    column,
                                                    typeof(T).Name,
                                                    condition == null ? "" : "WHERE " + condition.Condition);
                if (condition != null)
                {
                    foreach (object obj in condition.Parameters)
                        addParameter(command, value: obj);
                }

                object max = command.ExecuteScalar();
                return DBNull.Value.Equals(max) ? 0 : Convert.ToInt32(max);
            }
        }
        #endregion

        #region Insert Methods
        public static int Insert(IDbTransaction trans, T row, bool replace = false)
        {
            return Insert(trans, new T[] { row }, replace);
        }

        public static int Insert(IDbTransaction trans, IEnumerable<T> rows, bool replace = false)
        {
            int rowsInserted = 0;
            var colProps = new List<PropertyInfo>();
            foreach (var col in GetColumns())
            {
                // var att = (DbColumnAttribute)col.GetCustomAttributes(typeof(DbColumnAttribute), false)[0];
                // if (att.IsAutoIncrement) { continue; }
                colProps.Add(col);
            }

            using (var command = trans.Connection.CreateCommand())
            {
                command.Transaction = trans;
                command.CommandText = string.Format("{0} INTO {1} ({2}) VALUES (@{3})",
                                                    replace ? "REPLACE" : "INSERT",
                                                    typeof(T).Name,
                                                    join(",", colProps.Select(c => c.Name)),
                                                    join(",@", colProps.Select(c => c.Name)));

                foreach (var col in colProps)
                    addParameter(command, name: col.Name);

                foreach (var item in rows)
                {
                    foreach (var col in colProps)
                        setParameterValue(command, col.Name, col.GetValue(item, null));

                    rowsInserted += command.ExecuteNonQuery();
                }
            }
            return rowsInserted;
        }

        public static int Insert(IDbTransaction trans, DbValues values, bool replace = false)
        {
            using (var command = trans.Connection.CreateCommand())
            {
                command.Transaction = trans;
                command.CommandText = string.Format("{0} INTO {1} ({2}) VALUES (@{3})",
                                                    replace ? "REPLACE" : "INSERT",
                                                    typeof(T).Name,
                                                    join(",", values.Columns),
                                                    join(",@", values.Columns));

                foreach (var col in values.Columns)
                    addParameter(command, name: col, value: values[col]);

                return command.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// Transfer data from one database to another between tables with the same schema
        /// </summary>
        public static int Insert(IDbConnection sourceConnection, IDbTransaction targetTransaction,
                                 DbValues fixedValues = null, DbCondition condition = null, bool replace = false)
        {
            int rowsInserted = 0;
            var columns = GetColumns().Select(c => c.Name).ToArray();

            using (var targetCommand = targetTransaction.Connection.CreateCommand())
            {
                targetCommand.Transaction = targetTransaction;
                targetCommand.CommandText = string.Format("{0} INTO {1} ({2}) VALUES (@{3})",
                                                          replace ? "REPLACE" : "INSERT",
                                                          typeof(T).Name,
                                                          join(",", columns),
                                                          join(",@", columns));
                foreach (var col in columns)
                {
                    addParameter(targetCommand, name: col);
                    if (fixedValues != null && fixedValues.Contains(col))
                        setParameterValue(targetCommand, col, fixedValues[col]);
                }

                using (var sourceCommand = sourceConnection.CreateCommand())
                {
                    sourceCommand.CommandText = string.Format("SELECT * FROM {0} {1}",
                                                              typeof(T).Name,
                                                              condition == null ? "" : "WHERE " + condition.Condition);
                    if (condition != null)
                    {
                        foreach (var val in condition.Parameters)
                            addParameter(sourceCommand, value: val);
                    }

                    var variableColumns = columns.Where(c => fixedValues == null || !fixedValues.Contains(c)).ToList();
                    using (var reader = sourceCommand.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            foreach (string col in variableColumns)
                                setParameterValue(targetCommand, col, reader[col]);

                            rowsInserted += targetCommand.ExecuteNonQuery();
                        }
                    }
                }
            }
            return rowsInserted;
        }
        #endregion

        #region Update Methods
        public static int Update(IDbTransaction trans, DbValues values, DbCondition condition = null)
        {
            using (var command = trans.Connection.CreateCommand())
            {
                command.Transaction = trans;
                command.CommandText = string.Format("UPDATE {0} SET {1}=? {2}",
                                                    typeof(T).Name,
                                                    join("=?,", values.Columns),
                                                    condition == null ? "" : "WHERE " + condition.Condition);

                foreach (var col in values.Columns)
                    addParameter(command, value: values[col]);

                if (condition != null)
                {
                    foreach (var val in condition.Parameters)
                        addParameter(command, value: val);
                }

                int records = command.ExecuteNonQuery();
                return records;
            }
        }

        public static int Update(IDbTransaction trans, T row)
        {
            return Update(trans, new T[] { row });
        }

        public static int Update(IDbTransaction trans, IEnumerable<T> rows)
        {
            int rowsUpdated = 0;
            var myColumns = GetColumns().ToList();
            var myPrimaryKeys = GetPrimaryKeys(myColumns).ToList();

            using (var command = trans.Connection.CreateCommand())
            {
                command.Transaction = trans;
                var commandText = new System.Text.StringBuilder(string.Format("UPDATE {0} SET ", typeof(T).Name));

                foreach (string column in myColumns.Select(c => c.Name).Where(c => !myPrimaryKeys.Contains(c)))
                {
                    commandText.AppendFormat("{0}=@{0}, ", column);
                    addParameter(command, name: column);
                }
                commandText.Remove(commandText.Length - 2, 2);
                commandText.Append(" WHERE ");

                foreach (string pk in myPrimaryKeys)
                {
                    commandText.AppendFormat("{0}=@{0} AND ", pk);
                    addParameter(command, name: pk);
                }
                commandText.Remove(commandText.Length - 5, 5);
                command.CommandText = commandText.ToString();

                foreach (var item in rows)
                {
                    foreach (var col in myColumns)
                        setParameterValue(command, col.Name, col.GetValue(item, null));

                    rowsUpdated += command.ExecuteNonQuery();
                }
            }
            return rowsUpdated;
        }
        #endregion

        #region Delete Methods
        public static int Delete(IDbTransaction trans, DbCondition condition = null)
        {
            using (var command = trans.Connection.CreateCommand())
            {
                command.Transaction = trans;
                command.CommandText = string.Format("DELETE FROM {0} {1}",
                                                    typeof(T).Name,
                                                    condition == null ? "" : "WHERE " + condition.Condition);
                if (condition != null)
                {
                    foreach (var val in condition.Parameters)
                        addParameter(command, value: val);
                }
                return command.ExecuteNonQuery();
            }
        }

        public static int Delete(IDbTransaction trans, T row)
        {
            return Delete(trans, new T[] { row });
        }

        public static int Delete(IDbTransaction trans, IEnumerable<T> rows)
        {
            int rowsDeleted = 0;
            var myColumns = GetColumns().ToList();
            var myPrimaryKeys = GetPrimaryKeys(myColumns).ToList();

            using (var command = trans.Connection.CreateCommand())
            {
                command.Transaction = trans;
                var commandText = new System.Text.StringBuilder(string.Format("DELETE FROM {0} WHERE ", typeof(T).Name));
                foreach (string pk in myPrimaryKeys)
                {
                    commandText.AppendFormat("{0}=@{0} AND ", pk);
                    addParameter(command, name: pk);
                }
                commandText.Remove(commandText.Length - 5, 5);
                command.CommandText = commandText.ToString();
                var pkProperties = myColumns.Where(c => myPrimaryKeys.Contains(c.Name)).ToList();

                foreach (var item in rows)
                {
                    foreach (var pkProp in pkProperties)
                        setParameterValue(command, pkProp.Name, pkProp.GetValue(item, null));

                    rowsDeleted += command.ExecuteNonQuery();
                }
            }
            return rowsDeleted;
        }
        #endregion
    }

}
