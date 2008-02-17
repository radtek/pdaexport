using System.Collections.Generic;
using Constants;
using DataBaseWork;
using NUnit.Framework;
using Rhino.Mocks;

namespace DAO.Bridges.Test
{
    [TestFixture]
    public class BridgesReaderTest
    {
        private MockRepository repository;
        private QuerySelect query;
        [SetUp]
        public void SetUp()
        {
            repository = new MockRepository();
            query = repository.CreateMock<QuerySelect>();
        }
        [Test]
        public void LoadOneTest()
        {
            BridgesReader reader = new BridgesReader();
            reader.query = query;
            Expect.Call(query.Select(SQLSelectBridgesMode.SelectRel)).Return(true);
            List<DataRows> rows = new List<DataRows>();
            DataRows row = new DataRows();
            row.AddField(new DataField("BRNAME", "Most1"));
            row.AddField(new DataField("KM", 12.56));
            row.AddField(new DataField("NUM", "P-86"));
            row.AddField(new DataField("RDNAME", "Road"));
            row.AddField(new DataField("ID", 10));
            rows.Add(row);
            Expect.Call(query.GetRows()).Return(rows);
            repository.ReplayAll();
            List<RoadData> records = reader.Load(BridgesReader.BrViewMode.viewRel);
            Assert.AreEqual("P-86 Road", records[0].Name);
            Assert.AreEqual("(12,56) Most1", records[0].Bridges[0].Name);
            Assert.AreEqual(10, records[0].Bridges[0].IDBR);
            repository.VerifyAll();
        }
        [Test]
        public void LoadManyAndSelectPosTest()
        {
            BridgesReader reader = new BridgesReader();
            reader.query = query;
            Expect.Call(query.Select(SQLSelectBridgesMode.SelectPos)).Return(true);
            List<DataRows> rows = new List<DataRows>();
            DataRows row = new DataRows();
            row.AddField(new DataField("BRNAME", "Most1"));
            row.AddField(new DataField("KM", 12.56));
            row.AddField(new DataField("NUM", "P-86"));
            row.AddField(new DataField("RDNAME", "Road1"));
            row.AddField(new DataField("ID", 10));
            rows.Add(row);
            row = new DataRows();
            row.AddField(new DataField("BRNAME", "Most2"));
            row.AddField(new DataField("KM", 14.45));
            row.AddField(new DataField("NUM", "P-86"));
            row.AddField(new DataField("RDNAME", "Road1"));
            row.AddField(new DataField("ID", 11));
            rows.Add(row);
            row = new DataRows();
            row.AddField(new DataField("BRNAME", "Most3"));
            row.AddField(new DataField("KM", 14.45));
            row.AddField(new DataField("NUM", "P-89"));
            row.AddField(new DataField("RDNAME", "Road2"));
            row.AddField(new DataField("ID", 12));
            rows.Add(row);
            row = new DataRows();
            row.AddField(new DataField("BRNAME", "Most4"));
            row.AddField(new DataField("KM", 14.45));
            row.AddField(new DataField("NUM", "P-89"));
            row.AddField(new DataField("RDNAME", "Road2"));
            row.AddField(new DataField("ID", 13));
            rows.Add(row);
            Expect.Call(query.GetRows()).Return(rows);
            repository.ReplayAll();
            List<RoadData> records = reader.Load(BridgesReader.BrViewMode.viewPos);
            Assert.AreEqual("P-86 Road1", records[0].Name);
            Assert.AreEqual("(12,56) Most1", records[0].Bridges[0].Name);
            Assert.AreEqual(10, records[0].Bridges[0].IDBR);
            Assert.AreEqual("P-89 Road2", records[1].Name);
            Assert.AreEqual("(14,45) Most4", records[1].Bridges[1].Name);
            Assert.AreEqual(13, records[1].Bridges[1].IDBR);
            Assert.AreEqual(2, records[0].Bridges.Count);
            Assert.AreEqual(2, records[1].Bridges.Count);
            repository.VerifyAll();            
        }
    }
}