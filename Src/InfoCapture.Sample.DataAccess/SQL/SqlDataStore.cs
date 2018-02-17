using System.Data;
using System.Data.SqlClient;

namespace InfoCapture.Sample.DataAccess
{
    public class SqlDataStore : IDataStore
    {
        private string connectionString;

        public SqlDataStore(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public System.Data.IDbConnection CreateConnection()
        {
            return new SqlConnection(connectionString);
        }

        public System.Data.IDbCommand CreateCommand()
        {
            return new SqlCommand();
        }

        public System.Data.IDbConnection CreateOpenConnection()
        {
            var connection = CreateConnection();
            connection.Open();

            return connection;
        }

        public System.Data.IDbCommand CreateCommand(string commandText, System.Data.IDbConnection connection)
        {
            var command = CreateCommand();
            command.CommandText = commandText;
            command.Connection = connection;
            command.CommandType = CommandType.Text;

            return command;
        }

        public System.Data.IDbCommand CreateStoredProcCommand(string procName, System.Data.IDbConnection connection)
        {
            var command = CreateCommand();
            command.CommandText = procName;
            command.Connection = connection;
            command.CommandType = CommandType.StoredProcedure;

            return command;
        }

        public System.Data.IDataParameter CreateParameter(string parameterName, object parameterValue)
        {
            return new SqlParameter(parameterName, parameterValue);
        }
    }
}
