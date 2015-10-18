namespace ComputerFactory.Data.Repositories
{
    using System.IO;
    using System.Linq;

    using ComputerFactory.Common.Utils;
    using ComputerFactory.Data.Models;

    using MongoDB.Driver;
    using MongoDB.Bson;

    public class ComputerRepository : MongoRepository<Computer>
    {
        public ComputerRepository(MongoDatabase dataContext) 
            : base(dataContext)
        {
        }

        public void Generate(CpuRepository cpuRepository, MotherboardRepository moboRepository, PsuRepository psuRepository, RamRepository ramRepository, TextWriter textWriter)
        {
            var cpuList = cpuRepository.GetAll().ToList();
            var moboList = moboRepository.GetAll().ToList();
            var psuList = psuRepository.GetAll().ToList();
            var ramList = ramRepository.GetAll().ToList();

            textWriter.Write("Importing computers");

            for (int i = 0; i < 10; i++)
            {
                if (i % 2 == 0)
                {
                    textWriter.Write(".");
                }

                var cpu = cpuList[RandomUtils.GenerateNumberInRange(0, cpuList.Count - 1)];
                var mobo = moboList[RandomUtils.GenerateNumberInRange(0, moboList.Count - 1)];
                var psu = psuList[RandomUtils.GenerateNumberInRange(0, psuList.Count - 1)];
                var ram = ramList[RandomUtils.GenerateNumberInRange(0, ramList.Count - 1)];
                double price = cpu.Price + mobo.Price + psu.Price + ram.Price;

                table.Insert(new Computer()
                {
                    Id = ObjectId.GenerateNewId(),
                    CpuId = cpu.Id,
                    PsuId = psu.Id,
                    RamId = ram.Id,
                    MotherboardId = mobo.Id,
                    Price = price
                });
            }

            textWriter.WriteLine();
        }
    }
}