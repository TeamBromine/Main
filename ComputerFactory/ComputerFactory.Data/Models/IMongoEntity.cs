namespace ComputerFactory.Data.Models
{
    using MongoDB.Bson;

    public interface IMongoEntity
    {
        ObjectId Id { get; set; }
    }
}
