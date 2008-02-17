using System.Collections.Generic;
using Constants;
using DataBaseWork;


namespace DAO.Bridges
{
    public class BridgesReader
    {
        #region BrViewMode enum

        public enum BrViewMode
        {
            viewRel,
            viewPos
        } ;

        #endregion

        public QuerySelect query;

        /// <summary>
        /// Initializes a new instance of the <see cref="BridgesReader"/> class.
        /// </summary>
        public BridgesReader()
        {
            query = QuerySelect.Create(BaseType.Oracle);
        }

        /// <summary>
        /// Loads bridges for the specified view mode.
        /// </summary>
        /// <param name="viewMode">The view mode.</param>
        /// <returns></returns>
        public virtual List<RoadData> Load(BrViewMode viewMode)
        {
            switch (viewMode)
            {
                case BrViewMode.viewPos:
                    query.Select(SQLSelectBridgesMode.SelectPos);
                    break;
                case BrViewMode.viewRel:
                    query.Select(SQLSelectBridgesMode.SelectRel);
                    break;
            }
            List<DataRows> rows = query.GetRows();
            string LastRoad = "";
            RoadData roadAccum = null;
            List<RoadData> returnRows = new List<RoadData>();
            foreach (DataRows row in rows)
            {
                string RdName = row.FieldByName("NUM") + " " + row.FieldByName("RDNAME");
                if (LastRoad != RdName)
                {
                    // flush
                    if (roadAccum != null)
                        returnRows.Add(roadAccum);
                    // make new
                    roadAccum = new RoadData(RdName);
                }
                // add bridge
                string BrName = "(" + row.FieldByName("KM") + ") " + row.FieldByName("BRNAME");
                if (roadAccum != null)
                    roadAccum.AddBridge(new BridgeData(int.Parse(row.FieldByName("ID")), BrName));
                LastRoad = RdName;
            }
            // flush last
            if (roadAccum != null)
                returnRows.Add(roadAccum);
            return returnRows;
        }
    }
}