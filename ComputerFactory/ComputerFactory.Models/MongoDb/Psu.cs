namespace ComputerFactory.Models.MongoDb
{
    using MongoDB.Bson;

    public class Psu : MongoEntity
    {
        public string Model { get; set; }

        public int Power { get; set; }

        public ObjectId VendorId { get; set; }

        public double Price { get; set; }
    }
}
