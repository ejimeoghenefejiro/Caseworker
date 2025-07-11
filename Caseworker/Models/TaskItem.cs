namespace Caseworker.Models
{
    public class TaskItem
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string? Description { get; set; } 

        public string Status { get; set; } // e.g. "Pending", "In Progress", "Completed"

        public DateTime DueDate { get; set; }

        public DateTime CreatedOn { get; set; } = DateTime.UtcNow;
        public int UserId { get; set; }
    }
}
