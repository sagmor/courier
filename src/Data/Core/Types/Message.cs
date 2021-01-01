namespace HawkLab.Data.Core.Types
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Threading;
    using MongoDB.Bson.Serialization.Attributes;

    public class Message
    {
        public Message()
        {
            CreatedAt = DateTime.UtcNow;
            UpdatedAt = DateTime.UtcNow;
        }

        [BsonId]
        public Guid Id { get; set; }

        [Required]
        public string Content { get; set; }

        public DateTime CreatedAt { get; init; }

        public DateTime UpdatedAt { get; set; }
    }
}
