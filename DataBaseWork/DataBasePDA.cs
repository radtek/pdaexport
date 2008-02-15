

// unciomment if you build application for using on PDA and SqlServerCe is referenced ( off for unittesting)
//#define BaseOn


using System.Data.SqlServerCe;

namespace DataBaseWork
{

    public class DataBasePDA
    {

        private SqlCeConnection Connection = null;
        private DataBasePDA()
        {
            Connection = new SqlCeConnection();
        }

        private static DataBasePDA _instance = null;
        public static string ConnectionString = "Data Source = \"C:\\BelmostPDA.sdf\"; Password =\"pdabase\"";
        private static void Create()
        {
            if (_instance == null)
            {
                _instance = new DataBasePDA();
                _instance.ConnectToBase(ConnectionString);
            }            
        }
        public static SqlCeConnection Get()
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
            try
            {
                Connection.Close();
            }
            catch
            {
            }
        }

        private void ConnectToBase(string _string)
        {
            Connection = new SqlCeConnection(_string);
            Connection.Open();
        }
        private SqlCeConnection GetConnection()
        {
            return Connection;
        }
    }

}