using System;
using System.Collections.Generic;
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
        /// ����������� ����������� ��� ������ � �����
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
        /// <summary>
        /// ����� �������������� ������
        /// </summary>
        public static Loging _instance = null;
        
        public bool loging = false;
        public Dictionary<string, bool[]> Log = new Dictionary<string, bool[]>();
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
            bool[] flag=new bool[]{IsError,IsReport};
            if(loging)
            {
               if(IsError)
               {
                   WasErr = true;
               }
                Log.Add(Message,flag);
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
            foreach (KeyValuePair<string, bool[]> pair in Log)
            {
                if(!pair.Value[0])
                {
                    fields[i] = DateTime.Now+" : "+pair.Key;
                }
                else fields[i] = DateTime.Now + " ������ : " + pair.Key;
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
            foreach (KeyValuePair<string, bool[]> pair in Log)
            {
                if (pair.Value[1])
                {
                    if (!pair.Value[0])
                    {
                        lb.Items.Add(DateTime.Now + " : " + pair.Key);
                    }
                    else lb.Items.Add(DateTime.Now + " ������ : " + pair.Key);
                }
                
            }
            form.ShowDialog();
            
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