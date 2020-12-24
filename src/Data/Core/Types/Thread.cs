namespace HawkLab.Data.Core.Types
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using MongoDB.Bson.Serialization.Attributes;

    public class Thread
    {
        public Thread()
        {
            CreatedAt = DateTime.UtcNow;
            UpdatedAt = DateTime.UtcNow;
        }

        [BsonId]
        public Guid Id { get; set; }

        [Required]
        public string Subject { get; set; }

        public DateTime CreatedAt { get; init; }

        public DateTime UpdatedAt { get; set; }

        [Required]
        public string Summary { get; set; }
    }
}
