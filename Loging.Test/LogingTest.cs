using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using Rhino.Mocks;


namespace Loging.Test
{
    [TestFixture]
    public class LogingTest
    {
        private MockRepository repository;
        private Loging Log;

        [SetUp]
        public void SetUp()
        {
            repository=new MockRepository();
            Log = repository.CreateMock<Loging>();
        }
        [Test]
        public void InitTest()
        {
            Loging._instance = null;
            Loging.Init();
            Assert.IsNotNull(Loging._instance);
        }
        [Test]
        public void StartLogTest()
        {
            Log.loging = false;
            Loging._instance = Log;
            repository.ReplayAll();
            Log._StartLog();
            repository.VerifyAll();
            Assert.AreEqual(true, Log.loging, "Не установлен флаг ведения лога");
            Assert.IsEmpty(Log.Log, "Лог не очищен");

        }

        [Test]
        public void EndLogTest()
        {
            Log.loging = true;
            Loging._instance = Log;
            repository.ReplayAll();
            Log._EndLog();
            Log._WriteLog("Тест",true,true);
            repository.VerifyAll();
            Assert.AreEqual(false, Log.loging, "Не установлен флаг ведения лога");
            Assert.AreEqual(false, Log.Log.ContainsKey("Тест"),"Не закрылся  для записи лог");
        }

        public void WriteLogTest()
        {
            string mes = "Тест" + new Random().Next();
            Log.loging = true;
            Loging._instance = Log;
            repository.ReplayAll();
            Log._WriteLog(mes, true, false);
            repository.VerifyAll();
            Assert.AreEqual(true, Log.Log.ContainsKey(mes), "Не записалось в лог");
            Assert.AreEqual(true, Log.Log[mes][0]);
            Assert.AreEqual(false, Log.Log[mes][1]);
        }

        [Test]
        public void GetLogTest()
        {
            List<string> log=new List<string>();
            Loging._instance = Log;
            repository.ReplayAll();
            Log._StartLog();
            Log._WriteLog("раз месага", true, false);
            Log._WriteLog("два месага", false, true);
            log.AddRange(Log._GetLog());
            repository.VerifyAll();
            Assert.AreEqual(2,log.Count);
          
        }

        [Test]
        public void WasErrorTestTrue()
        {
            Loging._instance = Log;
            repository.ReplayAll();
            Log._StartLog();
            Log._WriteLog("раз месага", true, true);
            Log._WriteLog("два месага", false, true);
            repository.VerifyAll();
            Assert.AreEqual(true, Log._WasError());

        }
        [Test]
        public void WasErrorTestFalse()
        {
            Loging._instance = Log;
            repository.ReplayAll();
            Log._StartLog();
            Log._WriteLog("раз месага", false, true);
            Log._WriteLog("два месага", false, true);
            repository.VerifyAll();
            Assert.AreEqual(false, Log._WasError());

        }
    }
}
