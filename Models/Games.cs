using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.ComponentModel.DataAnnotations;

namespace DevGames.Models
{
    public class Games
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        [BsonElement("Name")]
        [Required]
        public string GameName { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string[] Plataform { get; set; }
        public decimal Price { get; set; }
    }
}
