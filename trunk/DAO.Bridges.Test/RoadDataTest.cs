using System.Collections.Generic;
using NUnit.Framework;

namespace DAO.Bridges.Test
{
    [TestFixture]
    public class RoadDataTest
    {
        [Test]
        public void CreateTest()
        {
            RoadData recordRoad = new RoadData();
            Assert.AreEqual("", recordRoad.Name);
            Assert.AreEqual(0, recordRoad.Bridges.Count);
            recordRoad = new RoadData("Name");
            Assert.AreEqual("Name", recordRoad.Name);
            Assert.AreEqual(0, recordRoad.Bridges.Count);
            List<BridgeData> recordsBridges = new List<BridgeData>();
            recordsBridges.Add(new BridgeData());
            recordsBridges.Add(new BridgeData(1, "Name"));
            recordRoad = new RoadData("Name", recordsBridges);
            Assert.AreEqual("Name", recordRoad.Name);
            Assert.AreEqual(2, recordRoad.Bridges.Count);
            Assert.AreEqual(1, recordRoad.Bridges[1].IDBR);
        }
        [Test]
        public void AddTest()
        {
            RoadData recordRoadData = new RoadData("Test");
            recordRoadData.AddBridge(new BridgeData(1, "Bridge"));
            Assert.AreEqual(1, recordRoadData.Bridges.Count);
            Assert.AreEqual("Bridge", recordRoadData.Bridges[0].Name);
            Assert.AreEqual(1, recordRoadData.Bridges[0].IDBR);
            recordRoadData = new RoadData("Test");
            recordRoadData.Bridges = null;
            recordRoadData.AddBridge(new BridgeData(1, "Bridge"));
            Assert.AreEqual(1, recordRoadData.Bridges.Count);
            Assert.AreEqual("Bridge", recordRoadData.Bridges[0].Name);
            Assert.AreEqual(1, recordRoadData.Bridges[0].IDBR);
        }

    }
}