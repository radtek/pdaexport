using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace Loging
{
    /// <summary>
    /// ����� ������� ���. � ��� �������� ��������� � ��� ���. ����� ������ ������������� ��������� � ���� 
    /// [���� - �����] ��������� - ��� ��������� � isError == false
    /// [���� - �����] ������: ��������� - ��� ��������� � isError == true
    /// </summary>
    public class Loging
    {
        /// <summary>
        /// ����������� ���������� ��� ������ � �����
        /// </summary>
        public static void StartLog()
        {
            Init();
            _instance._StartLog();
        }
        
        public static void EndLog()
        {
            Init();
            _instance._EndLog();
        }
       
        public static void WriteLog(string Message, bool IsError, bool IsReport)
        {
            Init();
            _instance._WriteLog(Message, IsError, IsReport);
        }
        public static string[] GetLog()
        {
            Init();
            return _instance._GetLog();
        }
        public static void ShowLog()
        {
            Init();
            _instance._ShowLog();
        }
        public static bool WasError()
        {
            Init();
            return _instance._WasError();
        }
        public static void ToFile()
        {
            Init();
            _instance._ToFile();
        }
        /// <summary>
        /// ����� �������������� ������
        /// </summary>
        public static Loging _instance = null;
        
        public bool loging = false;
        public class LogItem
        {
            public string Text;
            public bool Error;
            public bool Report;
            public LogItem(string text, bool err, bool rep)
            {
                Text = text;
                Error = err;
                Report = rep;
            }
        }
        public List<LogItem> Log=new List<LogItem>();
        public bool WasErr = false;
        
        public static void Init()
        {
            if(_instance== null)
                _instance = new Loging();
        }
        /// <summary>
        /// ���������� ������� ���� - ������� ���� ���� 
        /// ��� ��� �������� � �������� ��� � ������
        /// </summary>
        public void _StartLog()
        {
            ///
            /// 
            Log.Clear();
            loging = true;
            WasErr = false;
        }
        /// <summary>
        /// ��������� ������ ������� ����. ����� ����� ������ ��������� 
        /// ������ � ��� ������ ����� ��� ���� ��� �������������
        /// </summary>
        public void _EndLog()
        {
            loging = false;
        }
        /// <summary>
        /// ��������� ������ � ���
        /// </summary>
        /// <param name="Message">������</param>
        /// <param name="IsError">if set to <c>true</c> [������� ��������� �� ������].</param>
        /// <param name="IsReport">if set to <c>true</c> [������� ���� ��� ������ ������ ���������� � �����].</param>
        public void _WriteLog(string Message, bool IsError, bool IsReport)
        {
            if(loging)
            {
               if(IsError)
               {
                   WasErr = true;
               }
                Log.Add(new LogItem(Message,IsError,IsReport));
            }

        }
        /// <summary>
        /// ���������� ��� ������ ����
        /// </summary>
        /// <returns></returns>
        public string[] _GetLog()
        {
            string[] fields = new string[Log.Count];
            int i = 0;
            foreach (LogItem item in Log)
            {
                if(!item.Error)
                {
                    fields[i] = DateTime.Now + " : " + item.Text;
                }
                else fields[i] = DateTime.Now + " ������ : " + item.Text;
                i++;
            }
            return fields;
        }
        /// <summary>
        /// ���������� ����� ��������� ���� - � ����� ������������� ������ � ������� isReport == true
        /// </summary>
        public void _ShowLog()
        {
            LogView form=new LogView();
            ListBox lb = form.listBox1;
            lb.BeginUpdate();
            foreach (LogItem item in Log)
            {
                if (item.Report)
                {
                    if (!item.Error)
                    {
                        lb.Items.Add(DateTime.Now + " : " + item.Text);
                    }
                    else lb.Items.Add(DateTime.Now + " ������ : " + item.Text);
                }
                
            }
            lb.EndUpdate();
            form.ShowDialog();
            
        }

        public void _ToFile()
        {
            SaveFileDialog sv = new SaveFileDialog();
            sv.InitialDirectory = @"C:\";
            sv.DefaultExt = "txt";
            sv.Filter = "Text File|*.txt";
            if (sv.ShowDialog() == DialogResult.OK)
            {
                using (StreamWriter writer = new StreamWriter(sv.FileName, false))
                foreach (LogItem item in Log)
                {
                    if (!item.Error)
                    {
                       writer.WriteLine(DateTime.Now + " : " + item.Text);
                    }
                    else writer.WriteLine(DateTime.Now + " ������ : " + item.Text);
                }
              MessageBox.Show("��� �������� � ���� \n" + sv.FileName, "Message", MessageBoxButtons.OK);
            }
        }

        /// <summary>
        /// ���������� ������� ���� ���� �� ���� ���� ������ � isError == true
        /// </summary>
        /// <returns></returns>
        public bool _WasError()
        {
            return WasErr;
        }
    }
}
