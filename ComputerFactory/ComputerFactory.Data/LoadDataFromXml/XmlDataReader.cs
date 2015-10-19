namespace ComputerFactory.Data.LoadDataFromXml
{
    using Models;
    using System.Collections.Generic;
    using System.IO;
    using System.Xml.Serialization;

    public class XmlDataReader
    {
        private const string SalesRootElementName = "sales-by-month";

        public IEnumerable<Sale> ReadFile(string path)
        {
            var serializer = new XmlSerializer(typeof(List<Sale>), new XmlRootAttribute(SalesRootElementName));
            IEnumerable<Sale> sales;
            using (var reader = new StreamReader(path))
            {
                sales = (IEnumerable<Sale>)serializer.Deserialize(reader);
            }

            return sales;
        }
    }
}
