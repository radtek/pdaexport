namespace DAO.Bridges
{
    public class BridgeData
    {
        public int IDBR = -1;
        public string Name = "";

        /// <summary>
        /// Initializes a new instance of the <see cref="BridgeData"/> class.
        /// </summary>
        public BridgeData()
        {
            IDBR = -1;
            Name = "";
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BridgeData"/> class.
        /// </summary>
        /// <param name="IDBR">The IDBR.</param>
        /// <param name="Name">The name.</param>
        public BridgeData(int IDBR, string Name)
        {
            this.IDBR = IDBR;
            this.Name = Name;
        }
    }
}