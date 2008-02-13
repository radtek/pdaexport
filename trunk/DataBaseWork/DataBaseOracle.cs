

// unciomment if you build application for using on PDA and SqlServerCe is referenced ( off for unittesting)
//#define BaseOn
using System;


using System;
using System.Data.OleDb;


namespace DataBaseWork
{

    public class DataBaseOracle
    {

        private OleDbConnection Connection = null;
        private DataBaseOracle()
        {
            Connection = new OleDbConnection();
        }

        private static DataBaseOracle _instance = null;
        public static string ConnectionString = "Provider=OraOLEDB.Oracle.1;Data Source=BM;Persist Security Info=True;Password=bmcl3isd;User ID=BMCLIENT";
        private static void Create()
        {
            if (_instance == null)
            {
                _instance = new DataBaseOracle();
                _instance.ConnectToBase(ConnectionString);
            }            
        }
        public static OleDbConnection Get()
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
            Connection = new OleDbConnection(_string);
            Connection.Open();
        }
        private OleDbConnection GetConnection()
        {
            return Connection;
        }
    }

}