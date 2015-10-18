namespace ComputerFactory.Data.Repositories
{
    using System.IO;

    using ComputerFactory.Data.Models;

    using MongoDB.Bson;
    using MongoDB.Driver;

    public class VendorRepository : MongoRepository<Vendor>
    {
        public VendorRepository(MongoDatabase dataContext)
            : base(dataContext)
        {
        }

        public void Generate(TextWriter textWriter)
        {
            string[] vendorNames = { "Acer Inc.", "Gateway, Inc.", "Packard Bell", "AMD", "Apple Inc.", 
                                                   "ASRock", "Asus", "BenQ", "Cooler Master", "Dell", 
                                                   "Fujitsu Technology Solutions", "Gigabyte Technology", "Hewlett-Packard", 
                                                   "Compaq", "IBM", "Intel", "Lenovo", "Microsoft", "Panasonic", 
                                                   "Samsung Electronics", "Sony", "Toshiba" };

            textWriter.Write("Importing vendors");

            for (var i = 0; i < vendorNames.Length; i++)
            {
                if (i % 2 == 0)
                {
                    textWriter.Write(".");
                }

                table.Insert(new Vendor()
                {
                    Id = ObjectId.GenerateNewId(),
                    Name = vendorNames[i]
                });
            }

            textWriter.WriteLine();
        }
    }
}