namespace ComputerFactory.Models.MongoDb
{
    using MongoDB.Bson;

    public class Computer : MongoEntity
    {
        public ObjectId CpuId { get; set; }

        public ObjectId MotherboardId { get; set; }

        public ObjectId RamId { get; set; }

        public ObjectId PsuId { get; set; }

        public double Price { get; set; }
    }
}
