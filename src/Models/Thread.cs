namespace HawkLab.Courier.Models
{
    using System;

    public class Thread
    {
        public Thread()
        {
            CreatedAt = DateTime.UtcNow;
            UpdatedAt = DateTime.UtcNow;
        }

        public int Id { get; init; }

        public string Subject { get; set; }

        public DateTime CreatedAt { get; init; }

        public DateTime UpdatedAt { get; set; }

        public string Summary { get; set; }
    }
}
