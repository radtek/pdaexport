using System.Collections.Generic;

namespace DAO.Bridges
{
    public class RoadData
    {
        public List<BridgeData> Bridges = null;
        public string Name = "";

        /// <summary>
        /// Initializes a new instance of the <see cref="RoadData"/> class.
        /// </summary>
        public RoadData()
        {
            Name = "";
            Bridges = new List<BridgeData>();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="RoadData"/> class.
        /// </summary>
        /// <param name="name">The name.</param>
        public RoadData(string name)
        {
            Name = name;
            Bridges = new List<BridgeData>();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="RoadData"/> class.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="bridges">The bridges.</param>
        public RoadData(string name, IEnumerable<BridgeData> bridges)
        {
            Name = name;
            Bridges = new List<BridgeData>(bridges);
        }

        /// <summary>
        /// Adds the bridge.
        /// </summary>
        /// <param name="bridgeData">The bridge data.</param>
        public void AddBridge(BridgeData bridgeData)
        {
            if (Bridges == null)
                Bridges = new List<BridgeData>();
            Bridges.Add(bridgeData);
        }
    }
}