using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace Moon.DTOs
{
    public class User 
    {
        [BsonId]
        [BsonRepresentation(BsonType.String)]
        public Guid _id { get; set; }
        public required string  first_name { get; set; }
        public required string second_name { get; set; }
        public required string password { get; set; }
        public long phone_number  { get; set; }

        public required string email { get; set; }
        public required string  location { get; set; }
    }
}
