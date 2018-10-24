using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Web;

namespace ToolBox.DBTools
{
    public class Connection
    {
        public string InvariantName { get; set; }
        private string ConnectionString { get; set; }
        private DbProviderFactory Factory { get; set; }

        public Connection(string invariantName, string connectionString)
        {
            InvariantName = invariantName;
            ConnectionString = connectionString;
            Factory = DbProviderFactories.GetFactory(InvariantName);
            using (DbConnection conn = CreateConnection())
            {
                conn.Open();
            }
        }

        private DbConnection CreateConnection()
        {
            DbConnection conn = Factory.CreateConnection();
            conn.ConnectionString = ConnectionString;
            return conn;
        }

        private DbCommand CreateCommand(DbConnection conn, Command command)
        {
            DbCommand cmd = conn.CreateCommand();
            cmd.CommandType = (command.IsStoredProcedure) ? CommandType.StoredProcedure : CommandType.Text;
            cmd.CommandText = command.Query;
            foreach (KeyValuePair<string, object> keyValue in command.Parameters)
            {
                DbParameter param = Factory.CreateParameter();
                param.ParameterName = keyValue.Key;
                param.Value = (keyValue.Value is null) ? DBNull.Value : keyValue.Value;
                cmd.Parameters.Add(param);
            }
            return cmd;
        }

        public int ExecuteNonQuery(Command command)
        {
            using (DbConnection conn = this.CreateConnection())
            {
                conn.Open();
                using (DbCommand cmd = this.CreateCommand(conn, command))
                {
                    return cmd.ExecuteNonQuery();
                }
            }
        }
        public object ExecuteScalar(Command command)
        {
            using (DbConnection conn = this.CreateConnection())
            {
                conn.Open();
                using (DbCommand cmd = this.CreateCommand(conn, command))
                {
                    var result = cmd.ExecuteScalar();
                    return (result == DBNull.Value)? null : result;
                }
            }
        }
        public IEnumerable<T> ExecuteReader<T>(Command command, Func<IDataReader, T> func) where T : new()
        {
            using (DbConnection conn = this.CreateConnection())
            {
                conn.Open();
                using (DbCommand cmd = this.CreateCommand(conn, command))
                {
                    DbDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        yield return func(reader);
                    }
                }
            }
        }
    }
}
