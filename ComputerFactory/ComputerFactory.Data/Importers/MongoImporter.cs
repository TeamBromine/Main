namespace ComputerFactory.Data.Importers
{
    using System.IO;
    using System.Linq;

    using ComputerFactory.Models.MongoDb;
    using ComputerFactory.Data.Repositories;
    using ComputerFactory.Common.Utils;

    using MongoDB.Driver;
    using MongoDB.Bson;
    using System;

    public class MongoImporter : IDataImporter
    {
        private const string ConnectionString = "mongodb://localhost";
        private const string DatabaseName = "ComputerFactory";

        private TextWriter textWriter;
        private IComputerFactoryMongoDbContext dbContext;

        public MongoImporter(IComputerFactoryMongoDbContext dbContext, TextWriter textWriter)
        {
            this.dbContext = dbContext;
            this.textWriter = textWriter;
        }

        public void ImportAll()
        {
            this.ImportVendors();
            this.ImportMotherboards();
            this.ImportPsus();
            this.ImportCpus();
            this.ImportRams();
        }

        private void ImportVendors()
        {
            IRepository<Vendor> vendorRepository = new MongoRepository<Vendor>(this.dbContext);

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

                vendorRepository.Add(new Vendor()
                {
                    Id = ObjectId.GenerateNewId(),
                    Name = vendorNames[i]
                });
            }

            textWriter.WriteLine();
        }

        private void ImportMotherboards()
        {
            IRepository<Motherboard> motherboardRepository = new MongoRepository<Motherboard>(this.dbContext);
            IRepository<Vendor> vendorRepository = new MongoRepository<Vendor>(this.dbContext);

            var vendorsList = vendorRepository.GetAll().ToList();

            textWriter.Write("Importing motherboards");

            for (int i = 0; i < 45; i++)
            {
                if (i % 2 == 0)
                {
                    textWriter.Write(".");
                }

                motherboardRepository.Add(new Motherboard()
                {
                    Id = ObjectId.GenerateNewId(),
                    Model = RandomUtils.GenerateRandomString(RandomUtils.GenerateNumberInRange(2, 5)),
                    Price = RandomUtils.GenerateNumberInRange(150, 350),
                    VendorId = vendorsList[RandomUtils.GenerateNumberInRange(0, vendorsList.Count - 1)].Id
                });
            }

            textWriter.WriteLine();
        }

        private void ImportPsus()
        {
            int[] psuPowers = { 400, 450, 500, 600, 650, 700, 750 };

            IRepository<Psu> psuRepository = new MongoRepository<Psu>(this.dbContext);
            IRepository<Vendor> vendorRepository = new MongoRepository<Vendor>(this.dbContext);
            var vendorsList = vendorRepository.GetAll().ToList();

            textWriter.Write("Importing PSUs");

            for (int i = 0; i < 25; i++)
            {
                if (i % 2 == 0)
                {
                    textWriter.Write(".");
                }

                int currentPsuPower = psuPowers[RandomUtils.GenerateNumberInRange(0, psuPowers.Length - 1)];

                psuRepository.Add(new Psu()
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
        private void ImportCpus()
        {
            int[] cpuCores = { 2, 3, 4, 6 };

            IRepository<Cpu> cpuRepository = new MongoRepository<Cpu>(this.dbContext);
            IRepository<Vendor> vendorRepository = new MongoRepository<Vendor>(this.dbContext);
            var vendorsList = vendorRepository.GetAll().ToList();

            textWriter.Write("Importing CPUs");

            for (int i = 0; i < 42; i++)
            {
                if (i % 2 == 0)
                {
                    textWriter.Write(".");
                }

                int currentCpuCoresCount = cpuCores[RandomUtils.GenerateNumberInRange(0, cpuCores.Length - 1)];
                cpuRepository.Add(new Cpu()
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

        private void ImportRams()
        {
            int[] ramSizes = { 256, 512, 1024, 2048, 4096, 8192, 16384 };

            IRepository<Ram> ramRepository = new MongoRepository<Ram>(this.dbContext);
            IRepository<Vendor> vendorRepository = new MongoRepository<Vendor>(this.dbContext);
            var vendorsList = vendorRepository.GetAll().ToList();

            textWriter.Write("Importing RAM sticks");

            for (int i = 0; i < 30; i++)
            {
                if (i % 2 == 0)
                {
                    textWriter.Write(".");
                }

                int currentRamSize = ramSizes[RandomUtils.GenerateNumberInRange(0, ramSizes.Length - 1)];

                ramRepository.Add(new Ram()
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
