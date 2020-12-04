namespace HawkLab.Courier.Models
{
    using System;

    public class Thread
    {
        public Thread()
        {
            Id = Guid.NewGuid();
            CreatedAt = DateTime.UtcNow;
            UpdatedAt = DateTime.UtcNow;
        }

        public Guid Id { get; init; }

        public string Subject { get; set; }

        public DateTime CreatedAt { get; init; }

        public DateTime UpdatedAt { get; set; }

        public string Summary { get; set; }
    }
}
