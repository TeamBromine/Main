﻿namespace ComputerFactory.Data.Models
{
    using MongoDB.Bson;

    public class Motherboard : MongoEntity
    {
        public string Model { get; set; }

        public ObjectId VendorId { get; set; }

        public double Price { get; set; }
    }
}
