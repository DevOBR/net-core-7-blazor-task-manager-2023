using System.ComponentModel.DataAnnotations;

namespace TaskManager.Share.Entities
{
    public class MyTask
    {
        // auto assignable property - primary key table
        public int Id { get; set; }

        [Required]
        [MaxLength(200)]
        public string Description { get; set; } = null!;

        public DateTime Date { get; set; }

        public bool IsCompleted { get; set; }

    }
}

