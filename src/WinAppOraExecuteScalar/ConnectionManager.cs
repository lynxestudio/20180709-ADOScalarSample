
namespace WinAppOraExecuteScalar
{
    using Oracle.DataAccess.Client;
    using System.Data;

    internal sealed class ConnectionManager
    {
        static OracleConnection connection = null;
        internal static OracleConnection OpenAndGetConnection(string connectionString)
        {
            connection = new OracleConnection(connectionString);
            connection.Open();
            return connection;
        }
        internal static void CloseConnection()
        {
            if (connection != null)
            {
                if (connection.State == ConnectionState.Open)
                {
                    connection.Close();
                    connection = null;
                }
            }
        }
    }
}
