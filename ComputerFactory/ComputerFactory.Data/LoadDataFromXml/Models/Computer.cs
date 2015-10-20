using System.Xml.Serialization;

namespace ComputerFactory.Data.LoadDataFromXml.Models
{
    public class Computer
    {
        [XmlAttribute]
        public string Model { get; set; }

        [XmlText]
        public double Price { get; set; } 
    }
}
