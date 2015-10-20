namespace ComputerFactory.Data.LoadDataFromXml.Models
{
    using System.Collections.Generic;
    using System.Xml.Serialization;

    public class Sale
    {
        [XmlAttribute]
        public int Id { get; set; }

        [XmlAttribute]
        public string Month { get; set; }       

        public List<Computer> Computers { get; set; }
    }
}
