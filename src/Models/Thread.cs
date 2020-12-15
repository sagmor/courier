namespace HawkLab.Courier.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class Thread
    {
        public Thread()
        {
            CreatedAt = DateTime.UtcNow;
            UpdatedAt = DateTime.UtcNow;
        }

        public int Id { get; set; }

        [Required]
        public string Subject { get; set; }

        public DateTime CreatedAt { get; init; }

        public DateTime UpdatedAt { get; set; }

        [Required]
        public string Summary { get; set; }
    }
}
