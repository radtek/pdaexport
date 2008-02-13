using System;
using System.Collections.Generic;
using System.Text;

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
        public static Loging _instance = new Loging();
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

        }
        /// <summary>
        /// ��������� ������ ������� ����. ����� ����� ������ ��������� 
        /// ������ � ��� ������ ����� ��� ���� ��� �������������
        /// </summary>
        public void _EndLog()
        {

        }
        /// <summary>
        /// ��������� ������ � ���
        /// </summary>
        /// <param name="Message">������</param>
        /// <param name="IsError">if set to <c>true</c> [������� ��������� �� ������].</param>
        /// <param name="IsReport">if set to <c>true</c> [������� ���� ��� ������ ������ ���������� � �����].</param>
        public void _WriteLog(string Message, bool IsError, bool IsReport)
        {

        }
        /// <summary>
        /// ���������� ��� ������ ����
        /// </summary>
        /// <returns></returns>
        public string[] _GetLog()
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// ���������� ����� ��������� ���� - � ����� ������������� ������ � ������� isReport == true
        /// </summary>
        public void _ShowLog()
        {

        }
        /// <summary>
        /// ���������� ������� ���� ���� �� ���� ���� ������ � isError == true
        /// </summary>
        /// <returns></returns>
        public bool _WasError()
        {
            throw new NotImplementedException();
        }
    }
}
