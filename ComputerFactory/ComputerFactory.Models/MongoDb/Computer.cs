namespace ComputerFactory.Models.MongoDb
{
    using MongoDB.Bson;

    public class Computer : MongoEntity
    {
        public Computer(string model, double price)
        {
            this.Model = model;
            this.Price = price;
        }

        public string Model { get; set; }

        public ObjectId CpuId { get; set; }

        public ObjectId MotherboardId { get; set; }

        public ObjectId RamId { get; set; }

        public ObjectId PsuId { get; set; }

        public ObjectId SaleId { get; set; }

        public double Price { get; set; }
    }
}
