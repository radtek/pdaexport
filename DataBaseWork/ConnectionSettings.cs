using System;
using System.IO;
using System.Xml.Serialization;

namespace DataBaseWork
{
    [Serializable]
    public class ConnectionSettings
    {
        public string OracleConnectionString = "";
        public string PDAConnectionString = "";
        public string PDAConString = ""; //Base on PDA
        private static ConnectionSettings _instance = null;
        private static string Filename = "";
        public static void Load(string FileName)
        {
            Filename = FileName;
            try
            {
                FileStream stream = File.Open(FileName, FileMode.Open);
                XmlSerializer serializer = new XmlSerializer(typeof (ConnectionSettings));
                _instance = (ConnectionSettings)serializer.Deserialize(stream);
                stream.Close();
            }
            catch(FileNotFoundException)
            {
                _instance = new ConnectionSettings();
                Save();
            }
            Setup();
        }
        public static void Save()
        {
            try
            {
                FileStream stream = File.Open(Filename, FileMode.Create);
                XmlSerializer serializer = new XmlSerializer(typeof(ConnectionSettings));
                serializer.Serialize(stream, _instance);
                stream.Close();
            }
            catch
            {

            }           
        }
        public static void Setup()
        {
            DataBaseOracle.ConnectionString = 
                string.Format(DataBaseOracle.ConnectionStringTmp, _instance.OracleConnectionString);
            DataBasePDA.ConnectionString = _instance.PDAConnectionString;
        }
        public static ConnectionSettings GetSettings()
        {
            if(_instance==null)
            {
                _instance = new ConnectionSettings();   
            }
            return _instance;
        }
    }
}
