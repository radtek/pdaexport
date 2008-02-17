namespace Constants
{
    public class SQLSelectBridgesMode
    {
        public const string SelectPos =
            "SELECT Br.idBr as ID, Br.brName AS BRNAME, BrGen.brKm AS KM, Rd.rdNum AS NUM, Rd.rdName AS RDNAME " +
            "FROM Br INNER JOIN " +
            "BrGen ON Br.idBr = BrGen.idBr INNER JOIN " +
            "Rd ON BrGen.idRd = Rd.idRd " +
            "ORDER BY NUM, KM, BRNAME";
        public const string SelectRel =
            "SELECT Br.idBr as ID, Br.brName AS BRNAME, BrGen.brRelKm AS KM, Rd.rdNum AS NUM, Rd.rdName AS RDNAME " +
            "FROM Br INNER JOIN " +
            "BrGen ON Br.idBr = BrGen.idBr INNER JOIN " +
            "Rd ON BrGen.idRelRd = Rd.idRd " +
            "ORDER BY NUM, KM, BRNAME";
    }
}