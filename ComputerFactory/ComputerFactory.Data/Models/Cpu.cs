namespace ComputerFactory.Data.Models
{
    using MongoDB.Bson;

    public class Cpu : MongoEntity
    {
        public string Model { get; set; }

        public int Cores { get; set; }

        public ObjectId VendorId { get; set; }

        public double Price { get; set; }
    }
}
