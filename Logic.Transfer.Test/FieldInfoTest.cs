using System.Collections.Generic;
using DataBaseWork;
using NUnit.Framework;
using Rhino.Mocks;

namespace Logic.Transfer.Test
{
    [TestFixture]
     public class FieldInfoTest
    {
        private MockRepository repository;
        private QuerySelectPDA query;
        
        [SetUp]
        public void SetUp()
        {
            repository = new MockRepository();
            query = repository.CreateMock<QuerySelectPDA>();
        }

        [Test]
        public void  LoadTest()
        {   List<FieldInfo> lf;
            FieldInfo.query = query;
            Expect.Call(query.Select(string.Format(FieldInfo.sql,1))).Return(true);
            List<DataRows> rows=new List<DataRows>();
            DataRows row = new DataRows();
            row.AddField(new DataField("fieldname","testvalue"));
            rows.Add(row);
            Expect.Call(query.GetRows()).Return(rows);
            repository.ReplayAll();
            lf=FieldInfo.LoadFields(1);
            repository.VerifyAll();
            Assert.AreEqual(1,lf.Count);
            Assert.AreEqual("testvalue",lf[0].fieldName);


        }
    }
}
