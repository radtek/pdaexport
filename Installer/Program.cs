using System;
using System.Data.SqlServerCe;
using System.IO;
using OpenNETCF.Desktop.Communication;

namespace Installer
{
    class Program
    {
        public static string logpath;
        public static string pathbase;
        public static string path2device = "\\Storage Card\\BelmostPDA.sdf";
        public const string sql="Update MainParams set isLight={0}";
        static void Main(string[] args)
        {
            if (args.Length > 1)
            {
                pathbase = args[1];
                logpath = args[2] + "\\installlog.txt";
                FileDeleter(logpath);
                   switch (args[0])
                {
                    case "full": SetBase(true, pathbase); Copy(pathbase);
                        break;
                    case "light": SetBase(false, pathbase); Copy(pathbase);
                        break;
                    default:
                        break;
                }
            }
        }
        public static void SetBase(bool Dummy,string path)
        {
            string constr = "Data Source = \"{0}\"; Password =\"pdabase\"";
            try
            {
                SqlCeConnection con = new SqlCeConnection(string.Format(constr, path));
                con.Open();
                //SqlCeCommand q=con.CreateCommand();
                SqlCeCommand q;
                if (Dummy)
                {
                    q = new SqlCeCommand(string.Format(sql, 0), con);
                    q.ExecuteNonQuery();
                }
                else
                {
                    q = new SqlCeCommand(string.Format(sql, 1), con);
                    q.ExecuteNonQuery();
                }
                con.Close();
            }
            catch (SqlCeException e)
            {
              Consoler(e.Message);
              Log(e.Message,logpath);
            }
        }

        public static void Copy(String path)
        {
            RAPI r=new RAPI();
            try
            {
                if (r.DevicePresent)
                {
                    r.Connect();
                    Consoler("Copying database to PDA. Wait...");
                    r.CopyFileToDevice(path, path2device, true);
                    FileDeleter(pathbase);
                }
                else
                {
                    Consoler("No Device Connected");
                    Log("No Device Connected",logpath);
                }
            }
            catch(Exception e)
            {
                if (e.Message == "Could not create remote file ")
                    path2device = "\\Sd Card\\BelmostPDA.sdf";
                try 
	            {
                    Consoler("Copying database to PDA. Wait...");
            		r.CopyFileToDevice(path,path2device,true);
                    FileDeleter(pathbase);
	            }
	            catch (Exception ex)
	            {
                    Consoler(ex.Message);
                    Log(ex.Message,logpath);
                }
            }
           
        }
        public static void Log(string exc, string path)
        {
            using (StreamWriter s = new StreamWriter(path, true))
                s.WriteLine(DateTime.Now.ToString() + " :" + exc);
        }
        public static void Consoler(string Message)
        {
            Console.Clear();
            Console.WriteLine(Message);
        }
        public static void FileDeleter(string path)
        {
            FileInfo f=new FileInfo(path);
            if(f.Exists) f.Delete();
        }
    }
}
