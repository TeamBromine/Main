namespace ComputerFactory.Data.Repositories
{
    using System.IO;
    using System.Linq;

    using ComputerFactory.Common.Utils;
    using ComputerFactory.Data.Models;

    using MongoDB.Bson;
    using MongoDB.Driver;

    public class MotherboardRepository : MongoRepository<Motherboard>
    {
        public MotherboardRepository(MongoDatabase dataContext)
            : base(dataContext)
        {
        }

        public void Generate(VendorRepository vendorRepository, TextWriter textWriter)
        {
            var vendorsList = vendorRepository.GetAll().ToList();

            textWriter.Write("Importing motherboards");

            for (int i = 0; i < 45; i++)
            {
                if (i % 2 == 0)
                {
                    textWriter.Write(".");
                }

                table.Insert(new Motherboard()
                {
                    Id = ObjectId.GenerateNewId(),
                    Model = RandomUtils.GenerateRandomString(RandomUtils.GenerateNumberInRange(2, 5)),
                    Price = RandomUtils.GenerateNumberInRange(150, 350),
                    VendorId = vendorsList[RandomUtils.GenerateNumberInRange(0, vendorsList.Count - 1)].Id
                });
            }

            textWriter.WriteLine();
        }
    }
}