namespace ComputerFactory.Data.Repositories
{
    using System.IO;
    using System.Linq;

    using ComputerFactory.Common.Utils;
    using ComputerFactory.Data.Models;

    using MongoDB.Driver;
    using MongoDB.Bson;

    public class CpuRepository : MongoRepository<Cpu>
    {
        public CpuRepository(MongoDatabase dataContext)
            : base(dataContext)
        {
        }

        public void Generate(VendorRepository vendorRepository, TextWriter textWriter)
        {
            int[] cpuCores = { 2, 3, 4, 6 };

            var vendorsList = vendorRepository.GetAll().ToList();

            textWriter.Write("Importing CPUs");

            for (int i = 0; i < 42; i++)
            {
                if (i % 2 == 0)
                {
                    textWriter.Write(".");
                }

                int currentCpuCoresCount = cpuCores[RandomUtils.GenerateNumberInRange(0, cpuCores.Length - 1)];
                table.Insert(new Cpu()
                {
                    Id = ObjectId.GenerateNewId(),
                    Cores = currentCpuCoresCount,
                    Model = RandomUtils.GenerateRandomString(RandomUtils.GenerateNumberInRange(2, 5)),
                    Price = currentCpuCoresCount * RandomUtils.GenerateNumberInRange(100, 120),
                    VendorId = vendorsList[RandomUtils.GenerateNumberInRange(0, vendorsList.Count - 1)].Id
                });
            }

            textWriter.WriteLine();
        }
    }
}