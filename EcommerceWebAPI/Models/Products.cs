using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace EcommerceWebAPI.Models
{
    public class Products
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Category { get; set; }
    }
}
