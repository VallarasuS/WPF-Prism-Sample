using System.Data;

namespace InfoCapture.Sample.DataAccess
{
    public interface IDataStore
    {
        IDbConnection CreateConnection();
        IDbCommand CreateCommand();
        IDbConnection CreateOpenConnection();
        IDbCommand CreateCommand(string commandText, IDbConnection connection);
        IDbCommand CreateStoredProcCommand(string procName, IDbConnection connection);
        IDataParameter CreateParameter(string parameterName, object parameterValue);
    }
}