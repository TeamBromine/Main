using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace ComputerFactory.Data.Xml
{
    class XmlReportGenerator
    {
        //change DatabaseType to actual type
        private DatabaseType database;
        private const string XmlReportFilePath = "../XmlReports/";

        private const string XmlVersion = "1.0";
        private const string XmlEncoding = "UTF-8";
        private const string XmlStandalone = null;
        private const string XmlExtension = ".xml";

        private const string XmlRootElement = "computer";
        private const string XmlRootFirstAttribute = "vendor";

        private const string XmlChildElementTierOne = "motherBoard";
        private const string XmlChildElementTierOneAttribute = "model";

        public XmlReportGenerator(DatabaseType database)
        {
            this.database = database;
        }

        /// <summary>
        /// Generates an XML report for the computer by vendor
        /// </summary>
        /// <param name="vendor">The name of the vendor</param>
        public void GenerateXMLReport(string vendorName)
        {
            if (this.database.COMPUTERS.Where(c => c.VENDORNAME == vendorName).FirstOrDefault() == null)
            {
                throw new ArgumentException("There is no computer with vendor " + vendorName);
            }

            var computers = this.database.COMPUTERS.Where(c => c.VENDORNAME == vendorName).Select(c => c.VENDORNAME);

            XmlDocument doc = new XmlDocument();
            XmlNode docNode = doc.CreateXmlDeclaration(XmlVersion, XmlEncoding, XmlStandalone);
            doc.AppendChild(docNode);

            XmlNode computerNode = doc.CreateElement(XmlRootElement);
            XmlAttribute computerVendorAttribute = doc.CreateAttribute(XmlRootFirstAttribute);
            computerVendorAttribute.Value = vendorName;

            computerNode.Attributes.Append(computerVendorAttribute);

            foreach (var item in computers)
            {
                XmlNode motherboardNode = doc.CreateElement(XmlChildElementTierOne);
                XmlAttribute motherboardModelAttribute = doc.CreateAttribute(XmlChildElementTierOneAttribute);
                motherboardModelAttribute.Value = item;
                motherboardNode.Attributes.Append(motherboardModelAttribute);

                doc.AppendChild(motherboardNode);

                doc.Save(XmlReportFilePath + vendorName + XmlExtension);
            }
        }
    }
}
