namespace ComputerFactory.Data.Repositories
{
    using System;
    using System.IO;
    using System.Linq;

    using ComputerFactory.Common.Utils;
    using ComputerFactory.Data.Models;

    using MongoDB.Bson;
    using MongoDB.Driver;

    public class RamRepository : MongoRepository<Ram>
    {
        public RamRepository(MongoDatabase dataContext)
            : base(dataContext)
        {
        }

        public void Generate(VendorRepository vendorRepository, TextWriter textWriter)
        {
            int[] ramSizes = { 256, 512, 1024, 2048, 4096, 8192, 16384 };
            var vendorsList = vendorRepository.GetAll().ToList();

            textWriter.Write("Importing RAM sticks");

            for (int i = 0; i < 30; i++)
            {
                if (i % 2 == 0)
                {
                    textWriter.Write(".");
                }

                int currentRamSize = ramSizes[RandomUtils.GenerateNumberInRange(0, ramSizes.Length - 1)];

                table.Insert(new Ram()
                {
                    Id = ObjectId.GenerateNewId(),
                    Model = RandomUtils.GenerateRandomString(RandomUtils.GenerateNumberInRange(2, 6)),
                    Size = currentRamSize,
                    Price = Math.Sqrt(currentRamSize) - RandomUtils.GenerateNumberInRange(-2, 2),
                    VendorId = vendorsList[RandomUtils.GenerateNumberInRange(0, vendorsList.Count - 1)].Id
                });
            }

            textWriter.WriteLine();
        }
    }
}