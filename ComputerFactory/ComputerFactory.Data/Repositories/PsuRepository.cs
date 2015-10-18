namespace ComputerFactory.Data.Repositories
{
    using System.IO;
    using System.Linq;
    using System;

    using ComputerFactory.Common.Utils;
    using ComputerFactory.Data.Models;

    using MongoDB.Driver;
    using MongoDB.Bson;

    public class PsuRepository : MongoRepository<Psu>
    {
        public PsuRepository(MongoDatabase dataContext)
            : base(dataContext)
        {
        }

        public void Generate(VendorRepository vendorRepository, TextWriter textWriter)
        {
            int[] psuPowers = { 400, 450, 500, 600, 650, 700, 750 };
            var vendorsList = vendorRepository.GetAll().ToList();

            textWriter.Write("Importing PSUs");

            for (int i = 0; i < 25; i++)
            {
                if (i % 2 == 0)
                {
                    textWriter.Write(".");
                }

                int currentPsuPower = psuPowers[RandomUtils.GenerateNumberInRange(0, psuPowers.Length - 1)];

                table.Insert(new Psu()
                {
                    Id = ObjectId.GenerateNewId(),
                    Model = RandomUtils.GenerateRandomString(RandomUtils.GenerateNumberInRange(2, 5)),
                    Power = currentPsuPower,
                    Price = currentPsuPower / RandomUtils.GenerateNumberInRange(3, 5),
                    VendorId = vendorsList[RandomUtils.GenerateNumberInRange(0, vendorsList.Count - 1)].Id
                });
            }

            textWriter.WriteLine();
        }
    }
}