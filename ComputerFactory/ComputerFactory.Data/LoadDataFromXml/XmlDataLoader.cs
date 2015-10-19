namespace ComputerFactory.Data.LoadDataFromXml
{
    using DataImporters;

    public static class XmlDataLoader
    {
        private const string SalesFilePath = "../../../Data/sales-per-month.xml";

        public static void Load()
        {
            var xmlDataReader = new XmlDataReader();
            var loadedXml = xmlDataReader.ReadFile(SalesFilePath);
            new XmlToMongoDbDataImporter().ImportData(loadedXml);
            new XmlToMSSQLDataImporter().ImportData(loadedXml);
        }
    }
}
