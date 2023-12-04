using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Dynamic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;

namespace PTInTem.Helper.SQLite
{

    public static class SqlDataReaderExtension
    {
        public static T LoadAs<T>(this IDataReader reader)
        {
            var obj = Activator.CreateInstance<T>();
            ObjectHelper.LoadAs(reader, obj);

            return obj;
        }

        public static object LoadData<T>(this IDataReader reader)
        {
            var obj = ObjectHelper.LoadData(reader);
            return obj;
        }

        public static T LoadAs<T>(this IDataReader reader, params string[] listColumns)
        {
            var obj = Activator.CreateInstance<T>();
            ObjectHelper.LoadAs(reader, obj, ObjectHelper.GetCachedProperties<T>(), listColumns);

            return obj;
        }
        /// <summary>
        /// Nulls the safe get int32.
        /// </summary>
        /// <param name="reader">The reader.</param>
        /// <param name="ordinal">The ordinal.</param>
        /// <param name="nullValue">The null value.</param>
        /// <returns>System.Int32.</returns>
        public static int NullSafeGetInt32(this SqlDataReader reader, int ordinal, int nullValue = 0)
        {
            return reader[ordinal] != DBNull.Value ? reader.GetInt32(ordinal) : nullValue;
        }
        /// <summary>
        /// Gets the int.
        /// </summary>
        /// <param name="reader">The reader.</param>
        /// <param name="ordinal">The ordinal.</param>
        /// <returns>System.Nullable&lt;System.Int32&gt;.</returns>
        public static int? GetInt(this SqlDataReader reader, int ordinal)
        {
            if (reader[ordinal] != DBNull.Value)
                return reader.GetInt32(ordinal);
            return null;
        }

        /// <summary>
        /// Nulls the safe get byte.
        /// </summary>
        /// <param name="reader">The reader.</param>
        /// <param name="ordinal">The ordinal.</param>
        /// <param name="nullValue">The null value.</param>
        /// <returns>System.Byte.</returns>
        public static byte NullSafeGetByte(this SqlDataReader reader, int ordinal, byte nullValue = 0)
        {
            return reader[ordinal] != DBNull.Value ? reader.GetByte(ordinal) : nullValue;
        }

        /// <summary>
        /// Nulls the safe get int64.
        /// </summary>
        /// <param name="reader">The reader.</param>
        /// <param name="ordinal">The ordinal.</param>
        /// <param name="nullValue">The null value.</param>
        /// <returns>System.Int64.</returns>
        public static long NullSafeGetInt64(this SqlDataReader reader, int ordinal, long nullValue = 0)
        {
            return reader[ordinal] != DBNull.Value ? reader.GetInt64(ordinal) : nullValue;
        }

        /// <summary>
        /// Nulls the safe get decimal.
        /// </summary>
        /// <param name="reader">The reader.</param>
        /// <param name="ordinal">The ordinal.</param>
        /// <param name="nullValue">The null value.</param>
        /// <returns>System.Decimal.</returns>
        public static decimal NullSafeGetDecimal(this SqlDataReader reader, int ordinal, decimal nullValue = 0)
        {
            return reader[ordinal] != DBNull.Value ? reader.GetDecimal(ordinal) : nullValue;
        }

        /// <summary>
        /// Nulls the safe get double.
        /// </summary>
        /// <param name="reader">The reader.</param>
        /// <param name="ordinal">The ordinal.</param>
        /// <param name="nullValue">The null value.</param>
        /// <returns>System.Double.</returns>
        public static double NullSafeGetDouble(this SqlDataReader reader, int ordinal, double nullValue = 0)
        {
            return reader[ordinal] != DBNull.Value ? reader.GetDouble(ordinal) : nullValue;
        }

        /// <summary>
        /// Nulls the safe get bytes.
        /// </summary>
        /// <param name="reader">The reader.</param>
        /// <param name="ordinal">The ordinal.</param>
        /// <param name="dataOffset">The data offset.</param>
        /// <param name="buffer">The buffer.</param>
        /// <param name="bufferOffset">The buffer offset.</param>
        /// <param name="length">The length.</param>
        /// <returns>System.Int64.</returns>
        public static long NullSafeGetBytes(this SqlDataReader reader, int ordinal, long dataOffset, byte[] buffer, int bufferOffset, int length)
        {
            return reader[ordinal] != DBNull.Value ? reader.GetBytes(ordinal, dataOffset, buffer, bufferOffset, length) : 0;
        }

        /// <summary>
        /// Nulls the safe get string.
        /// </summary>
        /// <param name="reader">The reader.</param>
        /// <param name="ordinal">The ordinal.</param>
        /// <returns>System.String.</returns>
        public static string NullSafeGetString(this SqlDataReader reader, int ordinal)
        {
            return reader[ordinal] != DBNull.Value ? reader.GetString(ordinal) : string.Empty;
        }

        /// <summary>
        /// Nulls the safe get date time.
        /// </summary>
        /// <param name="reader">The reader.</param>
        /// <param name="ordinal">The ordinal.</param>
        /// <returns>System.Nullable&lt;DateTime&gt;.</returns>
        public static DateTime? NullSafeGetDateTime(this SqlDataReader reader, int ordinal)
        {
            return reader[ordinal] != DBNull.Value ? (DateTime?)reader.GetDateTime(ordinal) : null;
        }

        /// <summary>
        /// Nulls the safe get SQL XML.
        /// </summary>
        /// <param name="reader">The reader.</param>
        /// <param name="ordinal">The ordinal.</param>
        /// <returns>SqlXml.</returns>
        public static SqlXml NullSafeGetSqlXml(this SqlDataReader reader, int ordinal)
        {
            return reader[ordinal] != DBNull.Value ? reader.GetSqlXml(ordinal) : new SqlXml(Stream.Null);
        }

        /// <summary>
        /// Nulls the safe get bool.
        /// </summary>
        /// <param name="reader">The reader.</param>
        /// <param name="ordinal">The ordinal.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public static bool NullSafeGetBool(this SqlDataReader reader, int ordinal)
        {
            return reader[ordinal] != DBNull.Value ? reader.GetBoolean(ordinal) : false;
        }
        public static bool? GetBool(this SqlDataReader reader, int ordinal)
        {
            if (reader[ordinal] != DBNull.Value)
                return reader.GetBoolean(ordinal);
            return null;
        }

        /// <summary>
        /// To the enum.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="reader">The reader.</param>
        /// <param name="ordinal">The ordinal.</param>
        /// <returns>T.</returns>
        public static T ToEnum<T>(this SqlDataReader reader, int ordinal)
        {
            return reader[ordinal] != DBNull.Value ? (T)Enum.Parse(typeof(T), reader[ordinal].ToString()) : default(T);
        }
    }
    public class ObjectHelper
    {
        // Dictionary to store cached properites
        private static IDictionary<string, PropertyInfo[]> propertiesCache = new Dictionary<string, PropertyInfo[]>();
        // Help with locking
        private static ReaderWriterLockSlim propertiesCacheLock = new ReaderWriterLockSlim();
        /// <summary>
        /// Get an array of PropertyInfo for this type
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns>PropertyInfo[] for this type</returns>
        public static PropertyInfo[] GetCachedProperties<T>()
        {
            PropertyInfo[] props;
            if (propertiesCacheLock.TryEnterUpgradeableReadLock(100))
            {
                try
                {
                    if (!propertiesCache.TryGetValue(typeof(T).FullName, out props))
                    {
                        props = typeof(T).GetProperties();
                        if (propertiesCacheLock.TryEnterWriteLock(100))
                        {
                            try
                            {
                                propertiesCache.Add(typeof(T).FullName, props);
                            }
                            finally
                            {
                                propertiesCacheLock.ExitWriteLock();
                            }
                        }
                    }
                }
                finally
                {
                    propertiesCacheLock.ExitUpgradeableReadLock();
                }
                return props;
            }
            else
            {
                return typeof(T).GetProperties();
            }
        }

        /// <summary>
        /// Load the current row in a DataReader into an object
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="reader"></param>
        /// <param name="objectToLoad"></param>
        public static void LoadAs<T>(IDataReader reader, T objectToLoad)
        {
            if (objectToLoad == null)
                objectToLoad = Activator.CreateInstance<T>();
            // Get all the properties in our Object
            PropertyInfo[] props = GetCachedProperties<T>();
            // For each property get the data from the reader to the object
            var columnList = GetColumnList(reader);
            for (int i = 0; i < props.Length; i++)
            {
                string propertyName = props[i].Name;

                if (columnList.Contains(propertyName) && reader[propertyName] != DBNull.Value)
                {
                    if (props[i].PropertyType.IsEnum)
                    {
                        typeof(T).InvokeMember(propertyName, BindingFlags.SetProperty, null, objectToLoad, new[]
                        {
                            Enum.Parse(props[i].PropertyType, reader[propertyName].ToString())
                        });
                    }
                    else
                    {
                        var a = reader[propertyName];
                        try
                        {
                            typeof(T).InvokeMember(propertyName, BindingFlags.SetProperty, null, objectToLoad, new[] { a });
                        }
                        catch (Exception ex)
                        {
                            throw ex;
                        }

                    }
                }
            }
        }

        public static object LoadData(IDataReader reader)
        {
            var objectToLoad = new ExpandoObject() as IDictionary<string, Object>;
            var columnList = GetColumnList(reader);
            for (int i = 0; i < columnList.Length; i++)
            {
                string propertyName = columnList[i];
                if (columnList.Contains(propertyName) && reader[propertyName] != DBNull.Value)
                {
                    {
                        var a = reader[propertyName];
                        objectToLoad.Add(propertyName, a);
                    }
                }
            }
            return objectToLoad;
        }

        /// <summary>
        /// Load the current row in a DataReader into an object
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="reader"></param>
        /// <param name="objectToLoad"></param>
        /// <param name="props"></param>
        /// <param name="columnList"></param>
        public static void LoadAs<T>(IDataReader reader, T objectToLoad, PropertyInfo[] props, params string[] columnList)
        {
            if (objectToLoad == null)
                objectToLoad = Activator.CreateInstance<T>();
            if (props == null)
                props = GetCachedProperties<T>();
            if (columnList == null)
                columnList = GetColumnList(reader);

            for (int i = 0; i < props.Length; i++)
            {
                if (columnList.Contains(props[i].Name) && reader[props[i].Name] != DBNull.Value)
                    typeof(T).InvokeMember(props[i].Name, BindingFlags.SetProperty, null, objectToLoad, new[] { reader[props[i].Name] });
            }
        }


        /// <summary>
        /// Get a list of column names from the reader
        /// </summary>
        /// <param name="reader">The reader</param>
        /// <returns></returns>
        public static string[] GetColumnList(IDataReader reader)
        {
            DataTable readerSchema = reader.GetSchemaTable();

            var columnList = new string[readerSchema.Rows.Count];
            for (int i = 0; i < readerSchema.Rows.Count; i++)
                columnList[i] = readerSchema.Rows[i]["ColumnName"].ToString();
            return columnList;
        }


    }
}
