namespace ComputerFactory.Models.MongoDb
{
    using MongoDB.Bson;

    public class Ram : MongoEntity
    {
        public string Model { get; set; }

        public int Size { get; set; }

        public ObjectId VendorId { get; set; }

        public double Price { get; set; }
    }
}
