

// unciomment if you build application for using on PDA and SqlServerCe is referenced ( off for unittesting)
//#define BaseOn
using System.Data;
using System.Data.OracleClient;

namespace DataBaseWork
{

    public class DataBaseOracle
    {

        private OracleConnection Connection = null;
        private DataBaseOracle()
        {
            Connection = new OracleConnection();
        }

        private static DataBaseOracle _instance = null;
        public static string ConnectionString = "Data Source=BM;Persist Security Info=True;Password=bmcl3isd;User ID=BMCLIENT";
        private static void Create()
        {
            if (_instance == null)
            {
                _instance = new DataBaseOracle();
                _instance.ConnectToBase(ConnectionString);
            }            
        }
        public static OracleConnection Get()
        {
            Create();
            return _instance.GetConnection();
        }
        public static void Disconnect()
        {
            Create();
            _instance.DisconnectFromBase();
            _instance = null;
        }

        private void DisconnectFromBase()
        {
          if(Connection.State==ConnectionState.Open) Connection.Close();
        }

        private void ConnectToBase(string _string)
        {
            Connection = new OracleConnection(_string);
            Connection.Open();
        }
        private OracleConnection GetConnection()
        {
            return Connection;
        }
    }

}