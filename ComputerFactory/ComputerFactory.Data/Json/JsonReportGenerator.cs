using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerFactory.Data.Json
{
    class JsonReportGenerator
    {
        //change DatabaseType to actual type
        private DatabaseType sqlDatabase;
        private const string FilePath = "../JSONReports/";
        private const string JsonExtension = ".json";

        public JsonReportGenerator(DatabaseType database)
        {
            this.sqlDatabase = database;
        }

        public IDictionary<int, string> GetJSONObjects(int price)
        {
            var computers = this.sqlDatabase.COMPUTERS.Where(c => c.Price >= price).Select(c => new
            {
                VENDORNAME = c.VENDORNAME,
                PRICE = c.Price
            });

            JavaScriptSerializer js = new JavaScriptSerializer();
            var jsonObjects = new Dictionary<int, string>();
            int fileNameIndexer = 1;
            foreach (var computer in computers)
            {
                jsonObjects.Add(fileNameIndexer++, js.Serialize(computer));
            }

            return jsonObjects;
        }

        public void SaveJSONObjectsToFile(int price)
        {
            var jsonObjects = GetJSONObjects(price);

            foreach (var item in jsonObjects)
            {
                File.WriteAllText(FilePath + item.Key.ToString() + JsonExtension, item.Value);
            }

        }
    }
}
