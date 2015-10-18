namespace ComputerFactory.CLI
{
    using System;
    using System.Linq;

    using ComputerFactory.Data.Repositories;

    using MongoDB.Driver;

    public class Startup
    {
        // TODO: Extract this into the Data project instead of creating repositories here and use ComputerFactory.Data only
        private const string ConnectionString = "mongodb://localhost";
        private const string DatabaseName = "ComputerFactory";

        public static void Main(string[] args)
        {
            var mongoClient = new MongoClient(ConnectionString);
            var mongoServer = mongoClient.GetServer();

            var dbContext = mongoServer.GetDatabase(DatabaseName);

            var vendorRepository = new VendorRepository(dbContext);
            vendorRepository.Generate(Console.Out);

            var ramRepository = new RamRepository(dbContext);
            ramRepository.Generate(vendorRepository, Console.Out);

            var psuRepository = new PsuRepository(dbContext);
            psuRepository.Generate(vendorRepository, Console.Out);

            var moboRepository = new MotherboardRepository(dbContext);
            moboRepository.Generate(vendorRepository, Console.Out);

            var cpuRepository = new CpuRepository(dbContext);
            cpuRepository.Generate(vendorRepository, Console.Out);

            var computersRepository = new ComputerRepository(dbContext);
            computersRepository.Generate(cpuRepository, moboRepository, psuRepository, ramRepository, Console.Out);
        }
    }
}